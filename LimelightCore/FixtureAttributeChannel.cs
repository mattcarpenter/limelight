using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class FixtureAttributeChannel
    {
        public string Title { get; set; }
        public int RelativeChannelNumber { get; set; }
        public int Resolution { get; set; }
        public double? Value { get; set; }
        public double? LocateValue { get; set; }
        public ChannelPresidence Priority { get; set; }
        public bool Inverted { get; set; }
        public double? EffectValue { get; set; }
        public FixtureAttributeChannelType Type { get; set; }
    }
}
