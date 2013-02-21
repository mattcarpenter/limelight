using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public class Application
    {
        public List<Universe> Universes;
        public List<CueStack> CueStacks;
        public List<Playback> Playbacks;
        public double Tempo;
        public bool Blackout;
        public Programmer CueProgrammer;

        /// <summary>
        /// Enumerate each running cuestack's normalized fixture list and
        /// compute the final DMX address values
        /// </summary>
        public void Update()
        {
            foreach (CueStack stack in CueStacks)
            {

            }
        }
    }
}
