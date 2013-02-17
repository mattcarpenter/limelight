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
    class CueTests
    {
        private Fixture MasterFixture;
        
        [SetUp]
        public void Init()
        {
            // Mock a fixture with a single intensity channel and set the value to 1
            MasterFixture = new Fixture();
            MasterFixture.Label = "Test";

            FixtureAttribute fa = new FixtureAttribute();
            fa.Type = FixtureAttributeType.Intensity;

            FixtureAttributeChannel c = new FixtureAttributeChannel();
            c.Type = FixtureAttributeChannelType.Default;
            c.Value = 1;

            fa.Channels.Add(c);
            MasterFixture.Attributes.Add(fa);
        }

        [Test]
        public void go_FadesCueIn()
        {
            // Create a cue
            Cue c = new Cue();
            c.FadeInTime = 5;
            c.DwellTime = 2;
            c.FadeOutTime = 5;
            c.AddFixture(MasterFixture);

            c.Go();
            while (c.Status != CueStatus.NotRunning)
            {
                c.Update();
                Console.WriteLine("Intensity: " + c.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
                Console.WriteLine("Invalidated? " + c.Fixtures[0].Attributes[0].Channels[0].PendingRender);
                Thread.Sleep(1000);
            }

            Assert.True(true);
        }

        [Test]
        public void go_PausesOnNullDwellTime()
        {
            Cue c = new Cue();
            c.FadeInTime = 5;
            c.DwellTime = null;
            c.AddFixture(MasterFixture);

            c.Go();

            for (int i = 0; i < 8; i++)
            {
                c.Update();
                Console.WriteLine("Intensity: " + c.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
                Console.WriteLine("Invalidated? " + c.Fixtures[0].Attributes[0].Channels[0].PendingRender);
                Thread.Sleep(1000);
            }
        }

        [Test]
        public void combine_CombinesTwoCues()
        {
            // Create two cues with the same fixture. One fixture's 1st chan value is 1,
            // the other fixture's 1st chan value is 0.5.
            // Combined value should be 1 (HTP)
            Cue cue1 = new Cue();
            Cue cue2 = new Cue();

            cue1.AddFixture(MasterFixture.Clone());
            cue2.AddFixture(MasterFixture.Clone());

            // Pause after fade in
            cue1.DwellTime = 10;
            cue2.DwellTime = 10;
            cue1.FadeInTime = 1;
            cue2.FadeInTime = 1;

            cue1.Fixtures[0].Attributes[0].Channels[0].Value = 0.5;
            cue2.Fixtures[0].Attributes[0].Channels[0].Value = 0.9;

            CueStack cs = new CueStack();
            cs.AddCue(cue1);
            cs.AddCue(cue2);

            cs.ExecuteNextCue();
            cs.ExecuteNextCue();

            for (int i = 0; i < 3; i++)
            {
                cs.Update();

                Console.WriteLine("c1f1 Intensity: " + cue1.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
                Console.WriteLine("c2f1 Intensity: " + cue2.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
                Thread.Sleep(1000);
            }

            // Combine f1 from both cues
            cue1.Fixtures[0].Combine(cue2.Fixtures[0],false);
            Console.WriteLine("c1f1 Intensity after combining: " + cue1.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
            Assert.AreEqual(0.9, cue1.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
        }
    }
}
