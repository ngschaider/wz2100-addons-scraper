using RestSharp;
using System;
using System.Threading.Tasks;
using Wz2100AddonsScraper;

namespace Wz2100AddonsScraper {
    class Program {

        private static RestClient client = new RestClient();

        static void Main(string[] args) {

            for(uint i = 1; i < 2000; i++) {
                ProcessId(i);
            }

        }

        static async void ProcessId(uint id) {
            AddonInfo addonInfo = Scraper.GetInfo(id);
            if(addonInfo != null) {
                if(addonInfo.AddonType == AddonType.Map) {
                    addonInfo.Download("C:\\Wz2100Maps\\" + addonInfo.FileName);
                } else {
                    Console.WriteLine("Wrong Category ID " + id);
                }
            }
            await Task.Delay(500);
        }


    }
}
