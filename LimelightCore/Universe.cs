using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    [Serializable]
    public class Universe
    {
        public int Id { get; set; }
        public Channel[] Channels { get; set;}

        public Universe()
        {
            Channels = new Channel[512];

            for (int i = 0; i < 512; i++)
            {
                Channels[i] = new Channel();
            }
        }
    }
}
