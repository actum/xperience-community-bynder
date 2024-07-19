using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    public class BynderSelectorComponentAttribute : FormComponentAttribute
    {
        public string[] AllowedTypes { get; set; }

        public int MinimumAssets { get; set; }

        public int MaximumAssets { get; set; }
    }
}
