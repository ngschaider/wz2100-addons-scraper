using System;
using System.Collections.Generic;
using System.Text;

namespace Wz2100AddonsScraper {
    public static class Extensions {

        public static bool ToBasesType(this string basesTypeString, out BasesType basesType) {
            if(basesTypeString == "Normal bases") {
                basesType = BasesType.NormalBases;
                return true;
            } else if(basesTypeString == "Advanced Bases") {
                basesType = BasesType.AdvancedBases;
                return true;
            } else if(basesTypeString == "No bases") {
                basesType = BasesType.NoBases;
                return true;
            }

            return Enum.TryParse(basesTypeString, out basesType);
        }

        public static bool ToAddonType(this string addonTypeString, out AddonType addonType) {
            if(addonTypeString == "Map-Mod") {
                addonType = AddonType.MapMod;
                return true;
            }

            return Enum.TryParse(addonTypeString, out addonType);
        }

    }
}
