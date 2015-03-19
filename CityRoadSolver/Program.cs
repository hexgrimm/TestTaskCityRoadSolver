using System;
using CityRoadSolver.Calculation;
using CityRoadSolver.IO;

namespace CityRoadSolver
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            IDataReader dataReader = new DataReader();
            ISolver solver = new Solver();
            solver.SolveBestPath(dataReader.ReadInputData());
            Console.ReadLine();
        }
    }
}
