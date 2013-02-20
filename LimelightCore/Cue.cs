using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    [Serializable]
    public class Cue
    {
        public string Label { get; set; }
        public CueFinishOperation OnFinished { get; set; }
        public List<Fixture> Fixtures { get; set; }
        public double FadeInTime { get; set; }
        public double FadeOutTime { get; set; }
        public double? DwellTime { get; set; }
        public List<ICueEffect> Effects { get; set;}
        public CueStatus Status { get; set; }
        public double StatusPct { get; set; }
        public long Ticks { get; set; }
        public bool RenderedDwell { get; set; }
        public bool RenderedNotRunning { get; set; }
        public CueStack cueStack { get; set; }
        public int? NextCue { get; set; }
        public int CueNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Cue()
        {
            Status = CueStatus.NotRunning;
            StatusPct = 0;
            DwellTime = null;
            Fixtures = new List<Fixture>();
        }

        /// <summary>
        /// Adds a new fixture object to the cue
        /// </summary>
        /// <param name="fixture">Fixture to add</param>
        /// <returns>True on success</returns>
        public bool AddFixture(Fixture fixture)
        {
            Fixtures.Add(fixture);
            fixture.cue = this;
            return true;
        }

        /// <summary>
        /// Activates the cue from the beginning
        /// </summary>
        public void Go()
        {
            // Update the cue stack's last cue executed
            if(cueStack != null)
                cueStack.LastCueExecuted = CueNumber;

            // Set some beginning values
            ResetCue();

            // Activate the cue. Status depends on whether or not there's a fade in time
            if (FadeInTime > 0)
                Status = CueStatus.FadingIn;
            else
            {
                Status = CueStatus.Dwelling;
                StatusPct = 0.0f;
            }
        }

        /// <summary>
        /// Resets status and runtime values
        /// </summary>
        public void ResetCue()
        {
            RenderedDwell = false;
            RenderedNotRunning = false;
            StatusPct = 0.0f;
            Ticks = 0;
            Status = CueStatus.FadingIn;
        }

        /// <summary>
        /// Fades channels and updates effects
        /// </summary>
        public void Update()
        {
            double fadeIncrement = 0;
            long deltaTicks = 0;

            // If the cue is paused, we don't need to do anything
            if (Status == CueStatus.NotRunning || Status == CueStatus.Paused)
                return;

            // Timing updates
            if (Ticks == 0)
                Ticks = DateTime.Now.Ticks;
            deltaTicks = DateTime.Now.Ticks - Ticks;
            Ticks = DateTime.Now.Ticks;

            // Fades
            switch (Status)
            {
                case CueStatus.FadingIn:
                    fadeIncrement = deltaTicks / (FadeInTime * TimeSpan.TicksPerSecond);
                    break;
                case CueStatus.FadingOut:
                    fadeIncrement = deltaTicks / (FadeOutTime * TimeSpan.TicksPerSecond);
                    break;
                case CueStatus.Dwelling:
                    if(DwellTime != null)
                        fadeIncrement = deltaTicks / ((double)DwellTime * TimeSpan.TicksPerSecond);
                    break;
            }
            StatusPct += fadeIncrement;

            // Check if the status needs updating
            if (StatusPct >= 1)
            {
                // Determine what the next status should be
                switch (Status)
                {
                    case CueStatus.FadingIn:
                        Status = CueStatus.Dwelling;
                        StatusPct = 0;
                        break;
                    case CueStatus.Dwelling:
                        if (DwellTime != null)
                        {
                            Status = CueStatus.FadingOut;
                            StatusPct = 0;
                            if (OnFinished == CueFinishOperation.Follow && cueStack != null)
                                cueStack.ExecuteNextCue();
                        }
                        break;
                    case CueStatus.FadingOut:
                        Status = CueStatus.Releasing;
                        StatusPct = 0;
                        break;
                }
            }

            // Compute the RenderedValue based on the status pct
            RenderChannels();
        }

        /// <summary>
        /// Computes each channel's rendered value based on the status pct
        /// </summary>
        private void RenderChannels()
        {
            foreach(Fixture f in Fixtures)
            {
                foreach (FixtureAttribute fa in f.Attributes)
                {
                    foreach (FixtureAttributeChannel c in fa.Channels)
                    {
                        // Don't bother if this particular channel hasn't been written into the cue
                        if (c.Value == null)
                            continue;

                        switch (Status)
                        {
                            case CueStatus.Dwelling:
                                // Only invalidate this channel once during the dwell period
                                if (!RenderedDwell)
                                {
                                    c.LastUpdated = DateTime.Now.Ticks;
                                    c.PendingRender = true;
                                    RenderedDwell = true;
                                }
                                else
                                    c.PendingRender = false;
                                c.RenderedValue = c.Value;
                                break;
                            case CueStatus.FadingIn:
                                c.RenderedValue = c.Value * StatusPct;
                                break;
                            case CueStatus.FadingOut:
                                c.RenderedValue = c.Value - (c.Value * StatusPct);
                                break;
                            case CueStatus.NotRunning:
                                if (!RenderedNotRunning)
                                {
                                    c.RenderedValue = 0;
                                    c.PendingRender = true;
                                    c.LastUpdated = DateTime.Now.Ticks;
                                    RenderedNotRunning = true;
                                }
                                break;
                            case CueStatus.Releasing:
                                c.RenderedValue = 0;
                                break;
                        }

                        if (Status != CueStatus.NotRunning && Status != CueStatus.Paused && Status != CueStatus.Dwelling)
                        {
                            c.LastUpdated = DateTime.Now.Ticks;
                            c.PendingRender = true;
                        }
                    }
                }
            }
        }
    }
}
