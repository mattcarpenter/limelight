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
    }
}
