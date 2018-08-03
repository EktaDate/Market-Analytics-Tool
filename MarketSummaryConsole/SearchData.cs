using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSummaryConsole
{
    public class SearchData
    {
        //[JsonProperty(PropertyName = "id")]
        //public string Id { get; set; }

        [JsonProperty(PropertyName = "prospectname")]
        public string ProspectName { get; set; }

        [JsonProperty(PropertyName = "searchcriteria")]
        public string SearchCriteria { get; set; }

        [JsonProperty(PropertyName = "results")]
        public string Results { get; set; }

        [JsonProperty(PropertyName = "allresultdata")]
        public string AllResultData { get; set; }

       
    }
}
