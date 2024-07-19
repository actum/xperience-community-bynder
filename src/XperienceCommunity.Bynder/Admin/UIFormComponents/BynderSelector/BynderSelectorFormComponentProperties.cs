using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    public class BynderSelectorFormComponentProperties : FormComponentProperties
    {
        [NumberInputComponent(Label = "Minimum number of items", Order = 1)]
        public int MinimumAssets { get; set; }

        [NumberInputComponent(Label = "Maximum number of items", Order = 2)]
        public int MaximumAssets { get; set; }

        [DropDownComponent(Label = "Allowed type", Order = 3, Options = ";ALL\r\nIMAGE\r\nVIDEO\r\nAUDIO\r\nDOCUMENT")]
        public string AllowedType { get; set; }

        public string[] AllowedTypes { get; set; }
    }
}
