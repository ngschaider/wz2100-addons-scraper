using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AngleSharp;
using AngleSharp.Dom;
using RestSharp;
using System.Linq;

namespace Wz2100AddonsScraper {
    public class AddonInfo {

        public static string GetStringFromTable(IDocument document, AddonDetail key) {
            IHtmlCollection<IElement> rows = document.QuerySelectorAll("tr.addon_detail");
            IElement row = rows.FirstOrDefault(row => row.Children[0].TextContent == key.ToCompareString());

            return row?.Children[1].TextContent;
        }

        public static AddonInfo FromDocument(IDocument document) {
            AddonInfo addonInfo = new AddonInfo();

            // Author
            addonInfo.Author = GetStringFromTable(document, AddonDetail.Author);

            // AddonType
            string addonType = GetStringFromTable(document, AddonDetail.AddonType);
            if(!addonType.ToAddonType(out addonInfo.AddonType)) {
                ParseError("AddonType", addonType);
                return null;
            }

            // GameVersion
            string gameVersion = GetStringFromTable(document, AddonDetail.GameVersion);
            addonInfo.GameVersion = new Version(gameVersion);

            // Rating
            string rating = GetStringFromTable(document, AddonDetail.Rating);
            if(rating != null && !float.TryParse(rating, out addonInfo.Rating)) {
                ParseError("Rating", rating);
                return null;
            }

            // Created

            /*string created = document.QuerySelector(Selectors.Created).InnerHtml;
            if(!DateTime.TryParse(created, out addonInfo.Created)) {
                ParseError("Created", created);
                return null;
            }*/
            addonInfo.Created = GetStringFromTable(document, AddonDetail.Created);

            // OilAmount
            string oilAmount = GetStringFromTable(document, AddonDetail.OilAmount);
            if(oilAmount != null && !Enum.TryParse(oilAmount, out addonInfo.OilAmount)) {
                ParseError("OilAmount", oilAmount);
                return null;
            }

            // Players
            string players = GetStringFromTable(document, AddonDetail.Players);
            if(players != null && !uint.TryParse(players, out addonInfo.Players)) {
                ParseError("Players", players);
                return null;
            }

            // BasesType
            string basesType = GetStringFromTable(document, AddonDetail.BasesType);
            if(basesType != null && !basesType.ToBasesType(out addonInfo.BasesType)) {
                ParseError("BasesType", basesType);
                return null;
            }

            // Description
            addonInfo.Description = document.QuerySelector(Selectors.Description).InnerHtml;

            // FileName
            string downloadButtonText = document.QuerySelector(Selectors.DownloadButtonText).InnerHtml;
            addonInfo.FileName = downloadButtonText.Substring("Download ".Length);

            return addonInfo;
        }
        public void Download(string path) {
            Console.WriteLine("Downloading ID " + Id + " (" + FileName + ")");
            IRestRequest request = new RestRequest(Globals.BaseUrl + "download/" + Id);
            byte[] data = Globals.restClient.DownloadData(request);
            File.WriteAllBytes(path, data);
        }

        public static void ParseError(string name, string value) {
            Console.WriteLine("Could not parse " + name + " '" + value + "'");
        }

        public uint Id;
        public string Author;
        public AddonType AddonType;
        public Version GameVersion;
        public float Rating;
        //public DateTime Created;
        public string Created;
        public OilAmount OilAmount;
        public uint Players;
        public BasesType BasesType;
        public string Description;

        public string FileName;

    }
}
