using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class Fixture
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public Fixture Master { get; set; }
        public int PatchAddress { get; set; }
        public int PatchUniverse { get; set; }
    }
}
