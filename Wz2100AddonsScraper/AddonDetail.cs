using System;
using System.Collections.Generic;
using System.Text;

namespace Wz2100AddonsScraper {
    public enum AddonDetail {
        Author,
        AdditionalAuthors,
        AddonType,
        GameVersion,
        Rating,
        Created,
        PlayerMode,
        ModCategory,
        OilAmount,
        Players,
        BasesType,
    }

    public static class AddonDetailExtensions {
        public static string ToCompareString(this AddonDetail tableKey) {
            if(tableKey == AddonDetail.AdditionalAuthors) {
                return "Additional authors:";
            } else if(tableKey == AddonDetail.PlayerMode) {
                return "Player mode:";
            } else if(tableKey == AddonDetail.AddonType) {
                return "Addon type:";
            } else if(tableKey == AddonDetail.ModCategory) {
                return "Mod category:";
            } else if(tableKey == AddonDetail.GameVersion) {
                return "Game version:";
            } else if(tableKey == AddonDetail.OilAmount) {
                return "Oil:";
            } else if(tableKey == AddonDetail.BasesType) {
                return "Bases:";
            }

            return tableKey.ToString() + ":";
        }
    }
}
