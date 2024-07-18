using System.Threading.Tasks;

using DancingGoat;
using DancingGoat.Components.Widgets.BynderImageWidget;
using DancingGoat.Widgets;

using Kentico.PageBuilder.Web.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.BYNDER_IMAGE_WIDGET, typeof(BynderImageWidgetViewComponent), "Bynder image", typeof(BynderImageWidgetProperties), Description = "Bynder image example", IconClass = "icon-rectangle-a")]

namespace DancingGoat.Components.Widgets.BynderImageWidget
{
    public class BynderImageWidgetViewComponent : ViewComponent
    {
        public async Task<ViewViewComponentResult> InvokeAsync(BynderImageWidgetProperties properties)
        {
            return View("~/Components/Widgets/BynderImageWidget/_BynderImageWidget.cshtml", properties);
        }
    }
}
