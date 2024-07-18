using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
	public class BynderSelectorComponentAttribute : FormComponentAttribute
	{
		public string AllowedType { get; set; }

        public int MinimumAssets { get; set; }

        public int MaximumAssets { get; set; }
	}
}
