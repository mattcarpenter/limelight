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
            fixture = new Fixture(u);
            fixture.Label = "Red";
            fixture.PatchAddress = 1;

            FixtureAttribute fa = new FixtureAttribute();
            fa.Type = FixtureAttributeType.Intensity;

            FixtureAttributeChannel c = new FixtureAttributeChannel();
            c.Type = FixtureAttributeChannelType.Default;
            fa.Channels.Add(c);
            fixture.Attributes.Add(fa);
        }

        [Test]
        public void update_PlaybackCueStacksCombined()
        {
            // Create cues and cue stacks
            CueStack cs1 = new CueStack();
            Cue c1 = new Cue();
            c1.AddFixture(fixture.Clone());
            c1.Fixtures[0].Attributes[0].Channels[0].Value = 1;
            c1.DwellTime = null;
            cs1.AddCue(c1);

            CueStack cs2 = new CueStack();
            Cue c2 = new Cue();
            c2.AddFixture(fixture.Clone());
            c2.Fixtures[0].Attributes[0].Channels[0].Value = 0.3;
            c2.DwellTime = null;
            cs2.AddCue(c2);

            // Create playbacks
            Playback pb1 = new Playback();
            Playback pb2 = new Playback();

            pb1.Stack = cs1;
            pb2.Stack = cs2;

            // Start both cue stacks
            cs1.ExecuteNextCue();
            cs2.ExecuteNextCue();

            cs1.Update();
            cs2.Update();

            Console.WriteLine("Before core update:");
            Console.WriteLine("cs1f1c1: " + cs1.Cues[0].Fixtures[0].Attributes[0].Channels[0].RenderedValue);
            Console.WriteLine("cs2f1c1: " + cs2.Cues[0].Fixtures[0].Attributes[0].Channels[0].RenderedValue);

            app.Update();
        }
    }
}