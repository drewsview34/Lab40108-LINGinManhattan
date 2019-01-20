using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Lab40108_LINGinManhattan.Class;



namespace Lab40108_LINGinManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Lab08: LINQ");
                ConvertJson();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }


        /// <summary>
        /// Converts the json
        /// </summary>
        static void ConvertJson()
        {
            string path = "../../data.json";
            string filePathText = "";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    filePathText = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }


            ///<summary>
            /// DESIRIALIZATION
            /// </summary>
            var convertedJson = JsonConvert.DeserializeObject<FeatureCollection>(filePathText);

            ///<summary>
            /// Prints ALL neighborhoods in Feature Collection
            /// </summary>
            var neighborhoodsQuery = convertedJson.Features.Select(x => x.Properties.Neighborhood);

            Console.WriteLine("-------------------------------Print Out Of All Neighborhoods In Manhattan------------------------------------------");
            foreach (var hood in neighborhoodsQuery)
            {
                Console.WriteLine(hood);
            }

            ///<summary>
            /// Prints out all valid neighborhoods
            /// </summary>

            var validateNeighborhoods = from hoods in neighborhoodsQuery
                                        where hoods.Length > 0
                                        select hoods;

            Console.WriteLine("-------------------------------Validated Manhattan Neighborhoods------------------------------------------");
            foreach (var validHoods in validateNeighborhoods)
            {
                Console.WriteLine(validHoods);
            }


            ///<summary>
            /// Print distinct neighborhoods
            /// </summary>
            var distinctNeighborhoods = validateNeighborhoods.Select(x => x).Distinct();

            Console.WriteLine("-------------------------------Distinct Manhattan Neighborhoods------------------------------------------");
            foreach (var distinctHoods in distinctNeighborhoods)
            {
                Console.WriteLine(distinctHoods);
            }


            ///<summary>
            /// All Manhattan Neighborhoods query's consolidated
            /// </summary>
            var oneQueryThroughNeighborhoods = convertedJson.Features.Select(x => x)
                                                .Select(x => x.Properties)
                                                .Select(x => x.Neighborhood)
                                                .Where(x => x.Length > 0)
                                                .Distinct();
            Console.WriteLine("-------------------------------One query Of All Manhattan Neighborhoods------------------------------------------");
            foreach (var hoods in oneQueryThroughNeighborhoods)
            {
                Console.WriteLine(hoods);
            }

            ///<summary>
            /// Using lambda to print out all Manhattan neighborhoods
            /// </summary>
            var neighborhoods = neighborhoodsQuery.Where(x => x.Length > 0);

            Console.WriteLine("-------------------------------Print Out Of Manhattan Neighborhoods Using Lambda------------------------------------------");
            foreach (var hood in neighborhoodsQuery)
            {
                Console.WriteLine(hood);
            }
        }

    }
}