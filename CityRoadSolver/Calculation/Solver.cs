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
            nodes = CollectNodes(data);

            //force all path variations with cost calculation

            return 0f;
        }

        private IDictionary<string, Node> CollectNodes(Data input)
        {
            var collectedNodes = new Dictionary<string, Node>();
            foreach (var road in input.Roads)
            {
                if (collectedNodes.ContainsKey(road.CityNames[0]))
                {
                    collectedNodes[road.CityNames[0]].ConnectedNodes.Add(road.CityNames[1], road.FuelCost);
                }
                else
                {
                    var nod = new Node {Name = road.CityNames[0]};
                    nod.ConnectedNodes.Add(road.CityNames[1], road.FuelCost);
                    collectedNodes[road.CityNames[0]] = nod;
                }

                if (collectedNodes.ContainsKey(road.CityNames[1]))
                {
                    collectedNodes[road.CityNames[1]].ConnectedNodes.Add(road.CityNames[0], road.FuelCost);
                }
                else
                {
                    var nod = new Node { Name = road.CityNames[1] };
                    nod.ConnectedNodes.Add(road.CityNames[0], road.FuelCost);
                    collectedNodes[road.CityNames[1]] = nod;
                }
            }
            return collectedNodes;
        }
    }
}