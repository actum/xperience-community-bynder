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

    private string allowedType;

    private int minimumAssets;

    private int maximumAssets;

    private readonly MinItemsValidationRule minItemsValidationRule;

    private readonly MaxItemsValidationRule maxItemsValidationRule;


    public BynderSelectorFormComponent(ILocalizationService localizationService)
    {
        minItemsValidationRule = new MinItemsValidationRule(() => GetValue(), localizationService);
        maxItemsValidationRule = new MaxItemsValidationRule(() => GetValue(), localizationService);

        AddValidationRule(minItemsValidationRule);
        AddValidationRule(maxItemsValidationRule);
    }

    protected override void ConfigureComponent()
    {
        allowedType = base.Properties.AllowedType;
        minimumAssets = base.Properties.MinimumAssets;
        maximumAssets = base.Properties.MaximumAssets;

        minItemsValidationRule.Properties.MinItems = base.Properties.MinimumAssets;
        maxItemsValidationRule.Properties.MaxItems = base.Properties.MaximumAssets;

        base.ConfigureComponent();
    }

    protected override async Task ConfigureClientProperties(BynderSelectorFormComponentClientProperties clientProperties)
    {
        clientProperties.AllowedType = allowedType;
        clientProperties.MinimumAssets = minimumAssets;
        clientProperties.MaximumAssets = maximumAssets;

        await base.ConfigureClientProperties(clientProperties);
    }
}
