using System.Collections.Generic;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    public class BynderAssetFiles : Dictionary<string, BynderAssetFile>
    {
        public BynderAssetFile Original => this["original"];

        public BynderAssetFile Thumbnail => this["thumbnail"];

        public BynderAssetFile Mini => this["mini"];

        public BynderAssetFile WebImage => this["webImage"];
    }
}
