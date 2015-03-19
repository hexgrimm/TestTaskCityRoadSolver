using System;
using System.IO;
using System.Linq;

namespace CityRoadSolver.IO
{
    public sealed class DataReader : IDataReader
    {
        private const string filename = @"\input.txt";
        private readonly char divider = Char.Parse(" ");
        private string[] lines;
       
        Data IDataReader.ReadInputData()
        {
            try
            {
                lines = File.ReadAllLines(Environment.CurrentDirectory + filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading : " + e.Message);
            }

            if (lines == null || lines.Length < 2)
            {
                Console.WriteLine("Not enough lines in file");
                return null;
            }

            
            var answer = new Data();

            //resolving target cities
            var targets = lines[0];
           
            var cities = targets.Split(divider);
            answer.TargetCities = cities;

            //resolving road infos
            for (int i = 1; i < lines.Length; i++)
            {
                var s = lines[i];
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Line '{0}' is not readable at input.txt", i);
                    continue;
                }

                answer.Roads.Add(ParseString(lines[i]));
            }

            return answer;
        }

        private Data.RoadInfo ParseString(string input)
        {
            Data.RoadInfo output;

            var rawStrings =  input.Split(divider);
            if (rawStrings.Length != 3 || rawStrings.Any(string.IsNullOrEmpty))
            {
                Console.WriteLine("Line '{0}' is not readable at input.txt", input);
            }

            output.CityNames = new[] {rawStrings[0], rawStrings[1]};
            output.FuelCost = float.Parse(rawStrings[2]);

            return output;
        }
    }
}