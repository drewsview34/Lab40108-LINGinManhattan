using System.Collections.Generic;

namespace Lab40108_LINGinManhattan.Class
{
    public class FeatureCollection
    {
        ///<summary>
        /// create properties that will hold the bulk of the information in the JSON file
        /// </summary>

        public string Type { get; set; }
        public List<Feature> Features { get; set; }
    }
}