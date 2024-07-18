using System.Collections.Generic;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

using XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

namespace DancingGoat.Widgets
{
    public class BynderImageWidgetProperties : IWidgetProperties
    {
        [BynderSelectorComponent(AllowedType = AssetTypeConsts.Image, MinimumAssets = 1, MaximumAssets = 3)]
        [RequiredValidationRule]
        public IEnumerable<BynderAsset> BynderImage { get; set; }
    }
}
