using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    [Serializable]
    public class FixtureAttribute
    {
        public string Title { get; set; }
        public List<FixtureAttributeChannel> Channels { get; set; }
        public FixtureAttributeType Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FixtureAttribute()
        {
            Channels = new List<FixtureAttributeChannel>();
        }
    }
}
