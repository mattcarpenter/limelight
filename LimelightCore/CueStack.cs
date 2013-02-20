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
        public double FaderValue { get; set; }
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
                            channel.RenderedValue = channel.RenderedValue * FaderValue;
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
            ReleaseIndefiniteCues();

            Console.WriteLine("executeNextCue");

            if (Cues.Count == 0)
                return;

            if (LastCueExecuted == null)
            {
                Console.WriteLine("Executing cue 0");
                Cues[0].Go();
                return;
            }

            Cue lastCue = Cues[(int)LastCueExecuted];
            int cueNumberToExecute = 0;

            if (lastCue.CueNumber + 1 == Cues.Count)
                cueNumberToExecute = 0;
            else
                cueNumberToExecute = lastCue.CueNumber + 1;

            Console.WriteLine("Executing cue " + cueNumberToExecute);

            Cues[cueNumberToExecute].Go();
        }

        public void ReleaseIndefiniteCues()
        {
            foreach (Cue c in Cues)
                if (c.Status == CueStatus.Dwelling && c.DwellTime == null)
                {
                    Console.WriteLine("Releasing cue " + c.CueNumber);
                    c.Status = CueStatus.Releasing;
                    
                    // Zero all fixtures in cue
                    foreach (Fixture f in c.Fixtures)
                        f.Zero();
                }
        }
    }
}
