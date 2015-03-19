using CityRoadSolver.IO;

namespace CityRoadSolver.Calculation
{
    public interface ISolver
    {
        int SolveBestPath(Data data);
    }

    public sealed class Solver : ISolver
    {
        int ISolver.SolveBestPath(Data data)
        {
            return 0;
        }
    }
}
