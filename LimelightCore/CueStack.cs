using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    [Serializable]
    public class CueStack
    {
        public string Label { get; set; }
        public List<Cue> Cues { get; set; }
        public List<Fixture> Fixtures { get; set; } // Each running cue's fixtures are normalized into this list
        public int LastRunCue { get; set; }
        public double _faderValue;
        public double FaderValue
        { 
            get
            {
                return _faderValue;   
            }

            set
            {
                _faderValue = value;

                // Invalidate everything
                foreach (Cue cue in Cues)
                {
                    if (cue.Status == CueStatus.NotRunning)
                        continue;

                    foreach (Fixture f in cue.Fixtures)
                        foreach (FixtureAttribute fa in f.Attributes)
                            foreach (FixtureAttributeChannel c in fa.Channels)
                            {
                                c.PendingRender = true;
                                //c.LastUpdated++;
                                c.LastUpdated = DateTime.Now.Ticks;
                            }
                }
            }
        }
        public CueStackStatus Status { get; set; }
        public int? LastCueExecuted { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CueStack()
        {
            Cues = new List<Cue>();
            Fixtures = new List<Fixture>();
            LastCueExecuted = null;
        }

        /// <summary>
        /// Adds a cue to this stack's list of cues. Also assigns the cuestack reference
        /// </summary>
        /// <param name="cue">Cue to add</param>
        public void AddCue(Cue cue)
        {
            cue.cueStack = this;
            cue.CueNumber = Cues.Count;
            this.Cues.Add(cue);
        }

        /// <summary>
        /// Computes the normalized Fixtures list for all running cues in the stack
        /// </summary>
        public void Update()
        {
            Fixtures.Clear();

            foreach (Cue cue in Cues)
            {
                // Update the cue
                cue.Update();

                if (cue.Status == CueStatus.NotRunning)
                    continue;

                foreach (Fixture fixture in cue.Fixtures)
                {
                    Fixture normalizedFixture = ExistsInFixtures(fixture);
                    if (normalizedFixture != null)
                    {
                        bool add = (cue.Status == CueStatus.FadingOut || cue.Status == CueStatus.FadingIn ? true : false);
                        normalizedFixture.Combine(fixture, add);
                    }
                    else
                    {
                        // Current fixture does not exist in the normalized list of fixtures.
                        // Add it and set the master fixture
                        Fixture master = fixture.Master;
                        normalizedFixture = fixture.Clone();
                        normalizedFixture.Master = master;
                        Fixtures.Add(normalizedFixture);
                    }
                }
            
                // If this cue was releasing, mark it as not running. The zeroed fixtures should've been inserted into
                // normalized fixtures, unless another running cue is using that fixture.
                if (cue.Status == CueStatus.Releasing)
                    cue.Status = CueStatus.NotRunning;
            }

            // Apply the cue stack's fader value to each fixture's intensity attribute (if applicable)
            ApplyFader();
        }

        /// <summary>
        /// Applies the cuestack's fader value to each normalized fixture's
        /// intensity attributes
        /// </summary>
        public void ApplyFader()
        {
            foreach (Fixture fixture in Fixtures)
            {
                foreach(FixtureAttribute attribute in fixture.Attributes)
                {
                    foreach (FixtureAttributeChannel channel in attribute.Channels)
                    {
                        if (channel.AffectedByFader || attribute.Type == FixtureAttributeType.Intensity)
                            channel.RenderedValue = channel.RenderedValue * _faderValue;
                    }
                }
            }
        }

        /// <summary>
        /// Determines if the specified fixture exists in the list of normalized fixtures
        /// </summary>
        /// <param name="fixture">Fixture to search for in Fixtures list</param>
        /// <returns>The normalized fixture if exists, null if no match</returns>
        private Fixture ExistsInFixtures(Fixture fixture)
        {
            foreach (Fixture normalizedFixture in Fixtures)
                if (normalizedFixture.Master.Equals(fixture.Master))
                    return normalizedFixture;
            return null;
        }

        /// <summary>
        /// Executes the next cue
        /// </summary>
        public void ExecuteNextCue()
        {
            // Nothing to execute? Execute nothing!
            if (Cues.Count == 0)
                return;

            // First time executing a cue on this playback? Go to cue 0.
            if (LastCueExecuted == null)
            {
                GoToCue(0);
                return;
            }

            // What's the last cue that we executed?
            Cue lastCue = Cues[(int)LastCueExecuted];

            // If it was the last cue, go back to the first one.
            // Else, execute the last cue 
            if (lastCue.CueNumber + 1 == Cues.Count)
                GoToCue(0);
            else
                GoToCue(lastCue.CueNumber + 1);
        }

        /// <summary>
        /// Go to the specified cue. Indefinite cues currently running will be released
        /// </summary>
        /// <param name="cueNumber">Cue number to go to</param>
        public void GoToCue(int cueNumber)
        {
            // Release anything that doesn't fade out automagically
            ReleaseIndefiniteCues();
            LastCueExecuted = cueNumber;

            // Execute the specified cue
            Cues[cueNumber].Go();
        }

        /// <summary>
        /// Any cue that is dwelling indefinitely needs to be
        /// marked as releasing so that the rendered values can be set to 0
        /// and added to the normalized fixtures for this playback. Once all
        /// normalized fixtures have been generated, any cue with a status of
        /// releasing will be set to NotRunning.
        /// </summary>
        public void ReleaseIndefiniteCues()
        {
            foreach (Cue c in Cues)
                if (c.Status == CueStatus.Dwelling && c.DwellTime == null)
                {
                    c.Status = CueStatus.Releasing;
                    
                    // Zero all fixtures in cue - !!! Don't think this is needed anymore !!!
                    //foreach (Fixture f in c.Fixtures)
                    //    f.Zero();
                }
        }
    }
}
