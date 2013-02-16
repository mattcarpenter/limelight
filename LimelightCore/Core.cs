using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class Application
    {
        protected List<Universe> Universes;
        protected List<CueStack> CueStacks;
        protected List<Playback> Playbacks;
        protected double Tempo;
        protected bool Blackout;
        protected Programmer CueProgrammer;
    }
}
