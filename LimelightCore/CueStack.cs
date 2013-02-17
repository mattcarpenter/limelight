using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class CueStack
    {
        public string Label { get; set; }
        public List<Cue> Cues { get; set; }
        public List<Fixture> Fixtures { get; set; } // Each running cue's fixtures are normalized into this list
        public int LastRunCue { get; set; }
        public CueStackTiming Timing { get; set; }
        public double FaderValue { get; set; }
        public CueStackStatus Status { get; set; }

        /// <summary>
        /// Computes the normalized Fixtures list for all running cues in the stack
        /// </summary>
        public void Update()
        {
            foreach (Cue cue in Cues)
            {
                foreach (Fixture fixture in cue.Fixtures)
                {
                    Fixture normalizedFixture = ExistsInFixtures(fixture);
                    if (normalizedFixture != null)
                    {
                        normalizedFixture.Combine(fixture);
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
                if (normalizedFixture.Master.Equals(fixture))
                    return fixture;
            return null;
        }
    }
}
