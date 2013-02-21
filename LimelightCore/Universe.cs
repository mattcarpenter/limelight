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
        public Double[] Addresses { get; set;}

        public Universe()
        {
            Addresses = new double[512];
        }
    }
}
