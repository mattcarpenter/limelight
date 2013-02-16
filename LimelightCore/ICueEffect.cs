using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Limelight.Core
{
    public interface ICueEffect
    {
        string Title { get; set; }
        List<FixtureAttributeType> CompatibleAttributeTypes { get; set; } // Types that it may operate on
        FixtureAttribute AttributeType { get; set; } // Type that this instance is set to operate on
        List<Fixture> Fixtures { get; set; }
        double Speed { get; set; }
        double Spread { get; set; }
        double SizeX { get; set; }
        double SizeY { get; set; }
        double Size { get; set; }
    }
}
