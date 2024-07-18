using System.Collections.Generic;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

using XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

namespace DancingGoat.Widgets
{
    public class BynderImageWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Page where the button points to.
        /// </summary>
        [UrlSelectorComponent(Label = "Link URL", Order = 1)]
        public string LinkUrl { get; set; }

        [BynderSelectorComponent(AllowedType = "IMAGE", MaximumAssets = 2)]
        public IEnumerable<BynderAsset> BynderImage { get; set; }
    }
}
