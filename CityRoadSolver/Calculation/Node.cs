using System.Collections.Generic;

namespace CityRoadSolver.Calculation
{
    public sealed class Node
    {
        public string Name;
        public IDictionary<string, float> ConnectedNodes = new Dictionary<string, float>();
    }
}