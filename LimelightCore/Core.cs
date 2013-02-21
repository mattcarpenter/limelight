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
        public double Tempo;
        public bool Blackout;
        public Programmer CueProgrammer;

        public Application()
        {
            Universes = new List<Universe>();
            CueStacks = new List<CueStack>();
            Playbacks = new List<Playback>();
        }

        /// <summary>
        /// Enumerate each running cuestack's normalized fixture list and
        /// compute the final DMX address values
        /// </summary>
        public void Update()
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
                            if (c.PendingRender)
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
    }
}
