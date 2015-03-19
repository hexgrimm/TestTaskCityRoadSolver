using System.Collections.Generic;

namespace CityRoadSolver.Calculation
{
    /// <summary>
    /// this class is used to represent city with all links connected to it with known cost
    /// </summary>
    public sealed class Node
    {
        public string Name;
        /// <summary>
        /// Key - conneted city, Value - cost to travel this way
        /// </summary>
        public IDictionary<string, float> ConnectedNodes = new Dictionary<string, float>();
    }
}