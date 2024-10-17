using System.Collections.Generic;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    public class BynderAssetFiles : Dictionary<string, BynderAssetFile>
    {
        public BynderAssetFile Original => this.GetValueOrDefault("Original");

        public BynderAssetFile Thumbnail => this.GetValueOrDefault("Thumbnail");

        public BynderAssetFile Mini => this.GetValueOrDefault("Mini");

        public BynderAssetFile WebImage => this.GetValueOrDefault("WebImage");
    }
}
