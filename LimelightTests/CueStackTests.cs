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
    class CueStackTests
    {
        private Fixture MasterFixture;
        private Fixture MasterFixture2;
        
        [SetUp]
        public void Init()
        {
            // Mock a fixture with a single intensity channel and set the value to 1
            MasterFixture = new Fixture();
            MasterFixture.Label = "Test";
            MasterFixture.PatchAddress = 2;

            FixtureAttribute fa = new FixtureAttribute();
            fa.Type = FixtureAttributeType.Intensity;

            FixtureAttributeChannel c = new FixtureAttributeChannel();
            c.Type = FixtureAttributeChannelType.Default;
            c.Value = 1;

            fa.Channels.Add(c);
            MasterFixture.Attributes.Add(fa);

            MasterFixture2 = new Fixture();
            MasterFixture2.Label = "Test2";
            MasterFixture2.PatchAddress = 3;
            FixtureAttribute fa2 = new FixtureAttribute();
            fa2.Type = FixtureAttributeType.Intensity;

            FixtureAttributeChannel c2 = new FixtureAttributeChannel();
            c2.Type = FixtureAttributeChannelType.Default;
            c2.Value = 1;

            fa2.Channels.Add(c2);
            MasterFixture2.Attributes.Add(fa2);
        }

        [Test]
        public void update_combinesTwoCues()
        {
            // Create two cues with the same fixture. One fixture's 1st chan value is 1,
            // the other fixture's 1st chan value is 0.5.
            // Combined value should be 1 (HTP)
            Cue cue1 = new Cue();
            Cue cue2 = new Cue();

            cue1.AddFixture(MasterFixture.Clone());
            cue2.AddFixture(MasterFixture.Clone());

            // Pause after fade in
            cue1.DwellTime = null;
            cue2.DwellTime = null;

            cue1.Fixtures[0].Attributes[0].Channels[0].Value = 0.5;
            cue2.Fixtures[0].Attributes[0].Channels[0].Value = 0.9;

            CueStack cs = new CueStack();

            cs.Cues.Add(cue1);
            cs.Cues.Add(cue2);

            cs.ExecuteNextCue();
            cs.ExecuteNextCue();

            cs.Update();

            Assert.AreEqual(1, cs.Fixtures.Count);
        }

        [Test]
        public void update_intensityChannelsAffectedByFader()
        {
            Cue cue1 = new Cue();

            // Set up the cue and fixtures
            cue1.AddFixture(MasterFixture.Clone());
            cue1.Fixtures[0].Attributes[0].Channels[0].Value = 0.75;
            cue1.DwellTime = null;
            cue1.OnFinished = CueFinishOperation.Pause;
            cue1.FadeInTime = 0;

            // Create the cue stack
            CueStack cs = new CueStack();
            cs.AddCue(cue1);
            cs.FaderValue = 0.5;

            // Start the cue and update one frame
            cs.ExecuteNextCue();
            cs.Update();

            Assert.AreEqual(CueStatus.Dwelling, cue1.Status);
            Assert.AreEqual(0.375, cs.Fixtures[0].Attributes[0].Channels[0].RenderedValue);
        }

        [Test]
        public void update_cuesWithSameFixtureSameIntensity_channelValue_isConstant()
        {
            OpenDMX.start();
                        
            Cue cue1 = new Cue();
            Cue cue2 = new Cue();

            // Set up fixtures
            cue1.AddFixture(MasterFixture.Clone());
            cue1.FadeInTime = 1;
            cue1.DwellTime = 0;
            cue1.FadeOutTime =1;
            cue1.OnFinished = CueFinishOperation.Follow;

            cue2.AddFixture(MasterFixture.Clone());
            cue2.AddFixture(MasterFixture2.Clone());
            cue2.DwellTime = 0;
            cue2.FadeInTime = 1;
            cue2.FadeOutTime = 1;
            cue2.OnFinished = CueFinishOperation.Follow;
            cue2.Fixtures[0].Attributes[0].Channels[0].Value = 0;
            cue2.Fixtures[1].Attributes[0].Channels[0].Value = 1;

            // Create the cue stack
            CueStack cs = new CueStack();
            cs.AddCue(cue1);
            cs.AddCue(cue2);
            cs.FaderValue = 0.5f;

            cs.ExecuteNextCue();

            while(1==1)
            {
                cs.Update();
                //Console.WriteLine("c1f1: " + cue1.Fixtures[0].Attributes[0].Channels[0].RenderedValue);

                WriteFixturesToDMX(cs.Fixtures);
                
                Thread.Sleep(10);
            }
        }

        public void WriteFixturesToDMX(List<Fixture> fixtures)
        {
            foreach (Fixture fixture in fixtures)
            {
                Byte DMXValue = Convert.ToByte(fixture.Attributes[0].Channels[0].RenderedValue * 255.0f);
                OpenDMX.setDmxValue(fixture.PatchAddress, DMXValue);
            }
        }
    }
}
