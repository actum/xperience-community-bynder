using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
	public class BynderSelectorFormComponentProperties : FormComponentProperties
	{
        [NumberInputComponent(Label = "Minimum number of items")]
        public int MinimumAssets { get; set; } = 0;

        [NumberInputComponent(Label = "Maximum number of items")]
		public int MaximumAssets { get; set; } = 1;

		public string AllowedType { get; set; }
	}
}
