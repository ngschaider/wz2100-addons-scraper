using System;
using System.Collections.Generic;
using System.Text;

namespace Wz2100AddonsScraper {
    public static class Selectors {

        public static readonly string Author = "tr.addon_detail:nth-child(2) > td:nth-child(2)";
        public static readonly string AddonType = "tr.addon_detail:nth-child(3) > td:nth-child(2)";
        public static readonly string GameVersion = "tr.addon_detail:nth-child(4) > td:nth-child(2)";
        public static readonly string Rating = "tr.addon_detail:nth-child(5) > td:nth-child(2)";
        public static readonly string Created = "tr.addon_detail:nth-child(6) > td:nth-child(2)";
        public static readonly string OilAmount = "tr.addon_detail:nth-child(7) > td:nth-child(2)";
        public static readonly string Players = "tr.addon_detail:nth-child(8) > td:nth-child(2)";
        public static readonly string BasesType = "tr.addon_detail:nth-child(9) > td:nth-child(2)";

        public static readonly string ForumLink = ".addon-info > tbody:nth-child(1) > tr:nth-child(10) > td:nth-child(2) > a:nth-child(1)";
        public static readonly string Description = "div.block > div:nth-child(8)";

        public static readonly string DownloadButtonText = ".download > div:nth-child(1)";

        public static readonly string PageNotFound = "#content > h1:nth-child(1)";

    }
}
