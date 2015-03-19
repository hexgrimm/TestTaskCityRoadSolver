using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CityRoadSolver.IO
{
    public interface IDataReader
    {
        Data ReadInputData();
    }
}
