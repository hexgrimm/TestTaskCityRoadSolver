using System.Collections.Generic;
using CityRoadSolver.IO;

namespace CityRoadSolver.Calculation
{
    public sealed class Solver : ISolver
    {
        private float bestPathCost;
        private IDictionary<string, Node> nodes = new Dictionary<string, Node>();

        float ISolver.SolveBestPath(Data data)
        {
            bestPathCost = float.MaxValue;
            nodes.Clear();


            //TODO: realize calculation

            //create nodes

            //force all path variations with cost calculation

            return 0f;
        }
    }
}