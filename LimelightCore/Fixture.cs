using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    /// <summary>
    /// Represents a fixture with with all its attributes and channels
    /// </summary>
    [Serializable]
    public class Fixture
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public Fixture Master { get; set; }
        public int PatchAddress { get; set; }
        public int PatchUniverse { get; set; }
        public List<FixtureAttribute> Attributes { get; set; }
        public Cue cue { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Fixture()
        {
            Attributes = new List<FixtureAttribute>();
        }

        /// <summary>
        /// Clones this fixture instance and sets the master fixture reference
        /// </summary>
        /// <returns></returns>
        public Fixture Clone()
        {
            // Clone this fixture instance 
            Fixture newFixture = new Fixture();
            newFixture = ObjectCopier.Clone<Fixture>(this);
            
            // Set the master fixture reference to this instance
            newFixture.Master = this;

            return newFixture;
        }

        /// <summary>
        /// Combines current instance with fixture
        /// </summary>
        /// <param name="fixture">Fixture to be combined with current instance</param>
        public void Combine(Fixture fixture, bool add)
        {
            for (int attrCur = 0; attrCur < this.Attributes.Count; attrCur++)
            {
                for (int attrChanCur = 0; attrChanCur < this.Attributes[attrCur].Channels.Count; attrChanCur++)
                {
                    FixtureAttributeChannel thisChannel = this.Attributes[attrCur].Channels[attrChanCur];
                    FixtureAttributeChannel otherChannel = fixture.Attributes[attrCur].Channels[attrChanCur];

                    // While combining, treat everything as HTP and invalidate. If both rendered values are null (e.g. neither fixtures have
                    // this channel written into the cue), we can skip this channel.
                    if (thisChannel.RenderedValue == null && otherChannel.RenderedValue == null)
                        continue;
                    else
                    {
                        if (add && otherChannel.RenderedValue != null)
                        {
                            if (thisChannel.RenderedValue == null)
                                thisChannel.RenderedValue = 0;
                            thisChannel.RenderedValue += otherChannel.RenderedValue;
                            if (thisChannel.RenderedValue > 1)
                                thisChannel.RenderedValue = 1;
                        }
                        else
                        {
                            if (thisChannel.RenderedValue < otherChannel.RenderedValue || (thisChannel.RenderedValue == null && otherChannel.RenderedValue != null))
                                thisChannel.RenderedValue = otherChannel.RenderedValue;
                        }
                        this.Attributes[attrCur].Channels[attrChanCur].PendingRender = true;
                        this.Attributes[attrCur].Channels[attrChanCur].LastUpdated = DateTime.Now.Ticks;
                    }
                }
            }
        }
    }
}
