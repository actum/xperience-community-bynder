namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    public class BynderAsset
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string[] Extensions { get; set; }

        public string[] Tags { get; set; }

        public string DatabaseId { get; set; }

        public string Type { get; set; }

        public BynderAssetFiles Files { get; set; }
    }
}
