﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSummaryConsole
{
    public class ProspectSearchCriteria
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "prospectname")]

        public string ProspectName { get; set; }

        [JsonProperty(PropertyName = "searchcriteria")]
        public string SearchCriteria { get; set; }

        [JsonProperty(PropertyName = "twitterhandler")]
        [DisplayName("Twitter Updates")]
        public bool TwitterHandler { get; set; }

        [JsonProperty(PropertyName = "fbhandler")]
        [DisplayName("Facebook Updates")]
        public bool FacebookHandler { get; set; }

        [JsonProperty(PropertyName = "linkedinhandler")]
        [DisplayName("LinkedIn Updates")]
        public bool LinkedinHandler { get; set; }

        [JsonProperty(PropertyName = "emailupdates")]
        [DisplayName("Email Updates")]
        public bool EmailUpdates { get; set; }

        [JsonProperty(PropertyName = "bingsearchlupdates")]
        [DisplayName("Bing Search")]
        public bool BingSearchlUpdates { get; set; }
    }
}
