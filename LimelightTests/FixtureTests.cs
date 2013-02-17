using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Limelight.Core;
using NUnit.Framework;

namespace Limelight.Tests
{
    [TestFixture]
    public class FixtureTests
    {
        private Fixture MasterFixture;
        private Fixture TestFixture;

        [SetUp]
        public void Init()
        {
            MasterFixture = new Fixture();
            MasterFixture.Label = "Test";
        }

        [Test]
        public void clone_shouldCloneAndSetMaster()
        {
            TestFixture = MasterFixture.Clone();
            Assert.AreEqual("Test", TestFixture.Label);
        }

        [Test]
        public void clone_shouldHaveReferenceToMaster()
        {
            TestFixture = MasterFixture.Clone();
            TestFixture.Master.Label = "Updated";

            Assert.AreEqual("Updated", MasterFixture.Label);
        }
    }
}
