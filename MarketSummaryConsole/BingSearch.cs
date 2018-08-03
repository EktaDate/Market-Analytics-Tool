using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketSummaryConsole
{
    public static class BingSearch
    {
        // Replace the accessKey string value with your valid access key.
        const string congnitiveaccessKey = "d542f011af7d4742acd9d355d09192d3";

        // Verify the endpoint URI.  At this writing, only one endpoint is used for Bing
        // search APIs.  In the future, regional endpoints may be available.  If you
        // encounter unexpected authorization errors, double-check this value against
        // the endpoint for your Bing Web search instance in your Azure dashboard.
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";


        /// <summary>
        /// Performs a Bing Web search and return the results as a SearchResult.
        /// </summary>
        public static SearchResult WebSearch(string searchQuery)
        {
            if (congnitiveaccessKey.Length == 32)
            {
                // Construct the URI of the search request
                var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);
                //var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery) + "&" + "promote=webpages,news&count=20";

                // Perform the Web request and get the response
                WebRequest request = HttpWebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = congnitiveaccessKey;
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                // Create result object for return
                var searchResult = new SearchResult()
                {
                    jsonResult = json,
                    relevantHeaders = new Dictionary<String, String>()
                };
                
                // Extract Bing HTTP headers
                foreach (String header in response.Headers)
                {
                    if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                        searchResult.relevantHeaders[header] = response.Headers[header];
                }

                File.WriteAllText(@"c:\searchdata.json", searchResult.jsonResult.ToString());

                return searchResult;
            }
            else
            {
                Console.WriteLine("Invalid Bing Search API subscription key!");
                Console.WriteLine("Please paste yours into the source code.");
            }

            return null;
        }
    }

}
