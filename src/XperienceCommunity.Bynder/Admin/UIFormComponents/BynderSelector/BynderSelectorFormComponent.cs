using System.Collections.Generic;
using System.Threading.Tasks;

using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

[assembly: RegisterFormComponent(
    identifier: BynderSelectorFormComponent.IDENTIFIER,
    componentType: typeof(BynderSelectorFormComponent),
    name: "Bynder Selector Form Component")]

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

[ComponentAttribute(typeof(BynderSelectorComponentAttribute))]
public class BynderSelectorFormComponent : FormComponent<BynderSelectorFormComponentProperties, BynderSelectorFormComponentClientProperties, IEnumerable<BynderAsset>>
{
    public const string IDENTIFIER = "Bynder-Selector-Form-Component";
    public override string ClientComponentName => "@xperiencecommunity/bynder/BynderSelector";

    private string[] allowedTypes;

    private int minimumAssets;

    private int maximumAssets;

    private readonly MinItemsValidationRule minItemsValidationRule;

    private readonly MaxItemsValidationRule maxItemsValidationRule;


    public BynderSelectorFormComponent(ILocalizationService localizationService)
    {
        minItemsValidationRule = new MinItemsValidationRule(() => GetValue(), localizationService);
        maxItemsValidationRule = new MaxItemsValidationRule(() => GetValue(), localizationService);

        if (Properties.MinimumAssets > 0)
        {
            AddValidationRule(minItemsValidationRule);
        }

        if (Properties.MaximumAssets > 0)
        {
            AddValidationRule(maxItemsValidationRule);
        }
    }

    protected override void ConfigureComponent()
    {
        allowedTypes = !string.IsNullOrEmpty(Properties.AllowedType) ? new string[] { Properties.AllowedType } : Properties.AllowedTypes;
        minimumAssets = Properties.MinimumAssets;
        maximumAssets = Properties.MaximumAssets;

        minItemsValidationRule.Properties.MinItems = Properties.MinimumAssets;
        maxItemsValidationRule.Properties.MaxItems = Properties.MaximumAssets;

        base.ConfigureComponent();
    }

    protected override async Task ConfigureClientProperties(BynderSelectorFormComponentClientProperties clientProperties)
    {
        clientProperties.AllowedTypes = allowedTypes;
        clientProperties.MinimumAssets = minimumAssets;
        clientProperties.MaximumAssets = maximumAssets;

        await base.ConfigureClientProperties(clientProperties);
    }
}
