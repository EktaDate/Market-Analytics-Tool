using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketSummaryConsole
{
    public static class ProcessData
    {

        public static async Task ProcessBingSearchData()
        {
         
            IEnumerable<ProspectSearchCriteria> searchdata = await CosmosRepository<ProspectSearchCriteria>.GetAllProspectsAsyncForBingSearch();
            foreach (var item in searchdata)
            {
                SearchResult result = BingSearch.WebSearch(item.ProspectName + " + " + item.SearchCriteria);

                //Insert data of bing search
                InsertBingDataAsync(result, item).Wait();
            }
            //Bing web search call
          
        }

        public static async Task InsertBingDataAsync(SearchResult result, ProspectSearchCriteria prospectSearchCriteria)
        {

            var datavalues = JObject.Parse(result.jsonResult);

            // var companies = datavalues.Value<JObject>("webPages").Properties();

            var list = datavalues["webPages"]["value"].ToString();

            SearchData bingData = new SearchData
            {
                ProspectName = prospectSearchCriteria.ProspectName,
                Results = list,
                AllResultData = result.jsonResult,
                SearchCriteria = prospectSearchCriteria.ProspectName + " + " + prospectSearchCriteria.SearchCriteria
                
            };

            await CosmosRepository<SearchData>.CreateSearchDataAsync(bingData);


        }
    }
}
