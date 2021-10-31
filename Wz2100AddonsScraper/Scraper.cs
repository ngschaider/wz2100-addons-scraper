using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using RestSharp;

namespace Wz2100AddonsScraper {
    public static class Scraper {


        public static AddonInfo GetInfo(uint id) {
            string url = Globals.BaseUrl + id;
            IRestRequest request = new RestRequest(url);
            IRestResponse response = Globals.restClient.Get(request);

            if(response.Content.Contains("Page not found")) {
                Console.WriteLine("ID " + id + " does not exist.");
                return null;
            }

            IHtmlParser parser = new HtmlParser();
            IDocument document = parser.ParseDocument(response.Content);

            AddonInfo addonInfo = AddonInfo.FromDocument(document);
            if(addonInfo == null) {
                return null;
            }
            addonInfo.Id = id;

            return addonInfo;
        }



    }
}
