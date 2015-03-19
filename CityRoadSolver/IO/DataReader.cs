using System;
using System.Security.Cryptography.X509Certificates;

namespace CityRoadSolver.IO
{
    public sealed class DataReader : IDataReader
    {
        
        private const string filename = @"\input.txt";
        private string[] lines;
        Data IDataReader.ReadInputData()
        {
            try
            {
                lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading : " + e.Message);
            }

            if (lines.Length < 2)
            {
                Console.WriteLine("Not enough lines in file");
                return null;
            }

            
            var answer = new Data();

            //resolving target cities
            var targets = lines[0];
            var divider = Char.Parse(" ");
            var cities = targets.Split(divider);
            answer.TargetCities = cities;

            //resolving road infos

            return answer;
        }
    }
}