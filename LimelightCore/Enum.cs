using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public enum FixtureAttributeType { Position, Intensity, Color, Gobo, Other }
    public enum FixtureAttributeChannelType { Pan, Tilt, Red, Green, Blue, White, Amber, Default }
    public enum ChannelPresidence { HTP, LTP }
    public enum CueFinished { Follow, Pause }
    public enum CueStackTiming { Cue, Chase, TapSync }
    public enum CueStackStatus { Active, Released }
}
