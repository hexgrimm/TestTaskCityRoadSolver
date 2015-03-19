using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityRoadSolver.IO
{
    public sealed class Data
    {
        public struct RoadInfo
        {
            public float FuelCost;
            public string[] CityNames;
        }

        public List<RoadInfo> Roads;
        public string[] TargetCities;

        public Data()
        {
            Roads = new List<RoadInfo>();
            TargetCities = new string[2];
        }
    }
}
