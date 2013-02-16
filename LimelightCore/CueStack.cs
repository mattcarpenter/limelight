using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class CueStack
    {
        public string Label { get; set; }
        public List<Cue> Cues { get; set; }
        public int ActiveCue { get; set; }
        public int NextCue { get; set; }
        public CueStackTiming Timing { get; set; }
        public double FaderValue { get; set; }
        public CueStackStatus Status { get; set; }
        public double ActiveCueCurrentOutTime { get; set; }
        public double NextCueCurrentInTime { get; set; }
    }
}
