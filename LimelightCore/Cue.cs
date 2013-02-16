using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class Cue
    {
        public string Label { get; set; }
        public CueFinished OnFinished { get; set; }
        public List<Fixture> Fixtures { get; set; }
        public double FadeIn { get; set; }
        public double FadeOut { get; set; }
        public double Dwell { get; set; }
        public List<ICueEffect> Effects { get; set;}
    }
}
