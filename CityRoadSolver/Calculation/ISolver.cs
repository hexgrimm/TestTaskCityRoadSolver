using CityRoadSolver.IO;

namespace CityRoadSolver.Calculation
{
    public interface ISolver
    {
        float SolveBestPath(Data data);
    }
}
