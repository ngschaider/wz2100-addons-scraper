using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wz2100AddonsScraper {
    class Globals {

        public static RestClient restClient = new RestClient();
        public static readonly string BaseUrl = "https://addons.wz2100.net/";

    }
}
