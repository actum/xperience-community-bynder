using System.Collections.Generic;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
	public class BynderSelectorFormComponentClientProperties : FormComponentClientProperties<IEnumerable<BynderAsset>>
	{
		public int MinimumAssets { get; set; }
        
        public int MaximumAssets { get; set; }

		public string AllowedType { get; set; }
	}
}
