using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    [Serializable]
    public class FixtureAttributeChannel
    {
        public string Title { get; set; }
        public int RelativeChannelNumber { get; set; }
        public int Resolution { get; set; }
        public double? Value { get; set; }
        public double? RenderedValue { get; set; }
        public double? LocateValue { get; set; }
        public ChannelPresidence Priority { get; set; }
        public bool Inverted { get; set; }
        public FixtureAttributeChannelType Type { get; set; }
        public long LastUpdated { get; set; }
        public bool PendingRender { get; set; }
        public bool AffectedByFader { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FixtureAttributeChannel()
        {
            // Every time a fixture (and its attribute channels) are instantiated,
            // they should be pending a render.
            PendingRender = true;

            // By default, the Value and RenderedValue should be null
            Value = null;
            RenderedValue = null;
        }
    }
}
