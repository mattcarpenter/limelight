using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Limelight.Core;
using System.Threading;

namespace Limelight.Tests
{
    [TestFixture]
    class CoreTests
    {
        private Fixture fixture;
        private Core.Application app;

        [SetUp]
        public void Init()
        {
            // Set up the core application
            app = new Core.Application();

            // Set up a universe
            Universe u = new Universe();
            app.Universes.Add(u);

            // Mock a fixture with a single intensity channel and set the value to 1
            fixture = new Fixture(0);
            fixture.Label = "Red";
            fixture.PatchAddress = 1;

            FixtureAttribute fa = new FixtureAttribute();
            fa.Type = FixtureAttributeType.Intensity;

            FixtureAttributeChannel c = new FixtureAttributeChannel();
            c.Type = FixtureAttributeChannelType.Default;
            c.Presidence = ChannelPresidence.LTP;
            fa.Channels.Add(c);
            fixture.Attributes.Add(fa);
        }

        [Test]
        public void update_PlaybackCueStacksCombined()
        {
            // Create cues and cue stacks
            CueStack cs1 = new CueStack();
            Cue c1 = new Cue();
            Fixture f = fixture.Clone();

            c1.AddFixture(f);
            c1.Fixtures[0].Attributes[0].Channels[0].Value = 0.7;
            c1.DwellTime = null;
            cs1.AddCue(c1);

            CueStack cs2 = new CueStack();
            Cue c2 = new Cue();
            Fixture f2 = fixture.Clone();

            c2.AddFixture(f2);
            c2.Fixtures[0].Attributes[0].Channels[0].Value = 0.25;
            c2.DwellTime = null;
            cs2.AddCue(c2);

            cs1.FaderValue = 1;
            cs2.FaderValue = 1;

            // Create playbacks
            Playback pb1 = new Playback();
            Playback pb2 = new Playback();

            pb1.Stack = cs1;
            pb2.Stack = cs2;

            app.CueStacks.Add(cs1);
            app.CueStacks.Add(cs2);

            // Start the first cue stack and update everything
            cs1.ExecuteNextCue();
            app.Update();

            // Sleep a bit
            Thread.Sleep(1000);

            // Start the next one
            cs2.ExecuteNextCue();
            app.Update();

            // What's the value of Universe 0 Channel 0?
            Console.WriteLine("u0c0: " + app.Universes[0].Channels[0].Value);
        }
    }
}