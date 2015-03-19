using CityRoadSolver.IO;

namespace CityRoadSolver.Calculation
{
    public interface ISolver
    {
        float SolveBestPath(Data data);
    }

    public sealed class Solver : ISolver
    {
        float ISolver.SolveBestPath(Data data)
        {
            //TODO: realize calculation
            return 0f;
        }
    }
}
