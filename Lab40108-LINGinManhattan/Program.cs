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
            string location = "../../data.json";
            string fileLocation = "";

            try
            {
                using (StreamReader sr = File.OpenText(location))
                {
                    fileLocation = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }


            ///<summary>
            /// DESIRIALIZATION
            /// </summary>
            var convertedJson = JsonConvert.DeserializeObject<FeatureCollection>(fileLocation);

            ///<summary>
            /// Prints ALL neighborhoods in Feature Collection
            /// </summary>
            var queryNeighborhoods = convertedJson.Features.Select(x => x.Properties.Neighborhood);

            Console.WriteLine("PRINT OUT OF ALL NEIGHBORHOODS IN MANHATTAN");
            foreach (var hood in queryNeighborhoods)
            {
                Console.WriteLine(hood);
            }

            ///<summary>
            /// Prints out all valid neighborhoods
            /// </summary>

            var verifyNeighborhoods = from hoods in queryNeighborhoods
                                        where hoods.Length > 0
                                        select hoods;

            Console.WriteLine("VERIFIED MANHATTAN NEIGHBORHOODS");
            foreach (var verifiedNeighborhoods in verifyNeighborhoods)
            {
                Console.WriteLine(verifiedNeighborhoods);
            }


            ///<summary>
            /// Print distinct neighborhoods
            /// </summary>
            var specificNeighborhoods = verifyNeighborhoods.Select(x => x).Distinct();

            Console.WriteLine("SPECIFIC MANHATTAN NEIGHBORHOODS");
            foreach (var exactNieghborhoods in specificNeighborhoods)
            {
                Console.WriteLine(exactNieghborhoods);
            }


            ///<summary>
            /// All Manhattan Neighborhoods query's consolidated
            /// </summary>
            var QueryOneThroughNeighborhoods = convertedJson.Features.Select(x => x)
                                                .Select(x => x.Properties)
                                                .Select(x => x.Neighborhood)
                                                .Where(x => x.Length > 0)
                                                .Distinct();
            Console.WriteLine("ONE QUERY OF ALL MANHATTAN NEIGHBORHOODS");
            foreach (var hoods in QueryOneThroughNeighborhoods)
            {
                Console.WriteLine(hoods);
            }

            ///<summary>
            /// Using lambda to print out all Manhattan neighborhoods
            /// </summary>
            var neighborhoods = queryNeighborhoods.Where(x => x.Length > 0);

            Console.WriteLine("PRINT OUT OF MANHATTAN NEIGHBORHOODS USING LAMBDA");
            foreach (var hood in queryNeighborhoods)
            {
                Console.WriteLine(hood);
            }
        }

    }
}