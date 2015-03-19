using System;
using System.Collections.Generic;
using CityRoadSolver.IO;

namespace CityRoadSolver.Calculation
{
    public sealed class Solver : ISolver
    {
        private float bestPathCost;
        private float currentPathCost;
        private IDictionary<string, Node> nodes = new Dictionary<string, Node>();
        private IList<Node> usedInResolvingNodes = new List<Node>();
        private Data data;
        private string targetCity;

        float ISolver.SolveBestPath(Data inputData)
        {
            //возвращаем значения для работы в исходный вид, если кто то догадается выполнить несколько операций с одним инстансом.
            data = inputData;
            bestPathCost = float.MaxValue;
            currentPathCost = 0;
            nodes.Clear();
            usedInResolvingNodes.Clear();
            targetCity = data.TargetCities[1];

            //Создаем ноды
            nodes = CollectNodes(inputData);

            var startNode = nodes[inputData.TargetCities[0]];

            usedInResolvingNodes.Add(startNode);

            //call recursiv
            RecursivelySolveNode(startNode);

            //
            if (Math.Abs(bestPathCost - float.MaxValue) < 0.0001f)
            {
                Console.WriteLine("cannot find any path between target cities");
                return 0;
            }

            return bestPathCost;
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

        private void RecursivelySolveNode(Node node)
        {
            if (node.Name == targetCity)
            {
                if (currentPathCost < bestPathCost)
                {
                    bestPathCost = currentPathCost;
                }
            }

            foreach (var connectedNode in node.ConnectedNodes)
            {
                //отбрасываем пути превышающие текущий лучший вариант
                if (connectedNode.Value + currentPathCost > bestPathCost) 
                {
                    continue;
                }

                //отбрасываем пути если узел уже использовался раньше в этом пути. Ликвидация циклов.
                if (usedInResolvingNodes.Contains(nodes[connectedNode.Key])) 
                {
                    continue;
                }

                //прогоняем рекур вызов по всем следующим узлам.
                currentPathCost += connectedNode.Value;
                usedInResolvingNodes.Add(node);

                RecursivelySolveNode(nodes[connectedNode.Key]);

                currentPathCost -= connectedNode.Value;
                usedInResolvingNodes.Remove(node);
            }
        }
    }
}