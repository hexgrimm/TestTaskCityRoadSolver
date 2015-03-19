using System;
using System.Globalization;
using System.IO;

namespace CityRoadSolver.IO
{
    public sealed class DataWriter : IDataWriter
    {
        private const string filename = @"\output.txt";
        void IDataWriter.WriteAnsverToFile(float ansver)
        {
            try
            {
                File.WriteAllText(Environment.CurrentDirectory + filename, ansver.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                Console.WriteLine("cant write into file. " + e.Message);
            }
        }
    }
}