using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class Application
    {
        public List<Universe> Universes;
        public List<CueStack> CueStacks;
        public List<Playback> Playbacks;
        public List<Fixture> Fixtures;
        public double Tempo;
        public bool Blackout;
        public Programmer CueProgrammer;
        public bool BreakMe;
        public int currentPage;

        public Application()
        {
            Universes = new List<Universe>();
            CueStacks = new List<CueStack>();
            Playbacks = new List<Playback>();
            Fixtures = new List<Fixture>();
        }

        /// <summary>
        /// Enumerate each running cuestack's normalized fixture list and
        /// compute the final DMX address values
        /// </summary>
        public void UpdateOld()
        {
            foreach (CueStack stack in CueStacks)
            {
                stack.Update();

                foreach (Fixture fixture in stack.Fixtures)
                {
                    foreach (FixtureAttribute fa in fixture.Attributes)
                    {
                        foreach (FixtureAttributeChannel c in fa.Channels)
                        {
                            // Only bother if the channel is pending a render. Don't want a channel that's been un-updated
                            // for eight minutes while dwelling to take presidence over something else that was updated
                            // 30 seconds ago.
                            if (c.PendingRender || true)
                            {
                                Channel outChannel = Universes[fixture.Universe].Channels[fixture.PatchAddress + c.RelativeChannelNumber - 1];

                                if (c.Presidence == ChannelPresidence.HTP)
                                {
                                    // Highest takes presidence
                                    if (c.RenderedValue != null && c.RenderedValue > outChannel.Value)
                                    {
                                        outChannel.Value = (double)c.RenderedValue;
                                        outChannel.LastUpdated = DateTime.Now.Ticks;
                                    }
                                }
                                else
                                {
                                    // Latest takes presidence
                                    if (c.RenderedValue != null && c.LastUpdated > outChannel.LastUpdated)
                                    {
                                        outChannel.Value = (double)c.RenderedValue;
                                        outChannel.LastUpdated = DateTime.Now.Ticks;
                                    }
                                }
                                c.PendingRender = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// New core update function
        /// </summary>
        public void Update()
        {
            Fixtures.Clear();
            // Update both cue stacks
            foreach (CueStack stack in CueStacks)
                stack.Update();
            if (BreakMe == true)
                Console.WriteLine("break");

            foreach (CueStack stack in CueStacks)
            {
                foreach (Fixture fixture in stack.Fixtures)
                {
                    Fixture normalizedFixture = ExistsInFixtures(fixture);
                    if (normalizedFixture != null)
                    {
                        normalizedFixture.Combine(fixture, false,true);
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
                if (normalizedFixture.Master.Equals(fixture.Master))
                    return normalizedFixture;
            return null;
        }
    }
}
