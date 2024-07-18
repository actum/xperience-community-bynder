using System.Collections.Generic;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

using XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

namespace DancingGoat.Widgets
{
    public class BynderImageWidgetProperties : IWidgetProperties
    {
        [BynderSelectorComponent(AllowedType = AssetTypeConsts.Image, MaximumAssets = 1, MinimumAssets = 1)]
        [RequiredValidationRule]
        public IEnumerable<BynderAsset> BynderImage { get; set; }
    }
}
