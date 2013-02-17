﻿using System;
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
        public void update_combinesTwoCues()
        {
            // Create two cues with the same fixture. One fixture's 1st chan value is 1,
            // the other fixture's 1st chan value is 0.5.
            // Combined value should be 1 (HTP)
            Cue cue1 = new Cue();
            Cue cue2 = new Cue();

            cue1.Fixtures.Add(MasterFixture.Clone());
            cue2.Fixtures.Add(MasterFixture.Clone());

            // Pause after fade in
            cue1.DwellTime = null;
            cue2.DwellTime = null;

            cue1.Fixtures[0].Attributes[0].Channels[0].Value = 0.5;
            cue2.Fixtures[0].Attributes[0].Channels[0].Value = 0.9;

            CueStack cs = new CueStack();

            cs.Cues.Add(cue1);
            cs.Cues.Add(cue2);

            cue1.Go();
            cue2.Go();

            cs.Update();

            Assert.AreEqual(1, cs.Fixtures.Count);
        }
    }
}
