using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
	public class BynderSelectorFormComponentProperties : FormComponentProperties
	{
        [NumberInputComponent(Label = "{$base.forms.assetselector.minimumassets.label$}")]
        public int MinimumAssets { get; set; } = 0;

        [NumberInputComponent(Label = "{$base.forms.assetselector.maximumassets.label$}")]
		public int MaximumAssets { get; set; } = 1;

		public string AllowedType { get; set; }
	}
}
