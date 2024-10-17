# XperienceCommunity.Bynder

[![CI: Build and Test](https://github.com/actum/xperience-community-bynder/actions/workflows/ci.yml/badge.svg)](https://github.com/actum/xperience-community-bynder/actions/workflows/ci.yml)

## Description

This plugin enhances Xperience by Kentico with a form control that allows users to select assets from the DAM Bynder.

## Screenshots

![Bynder assets](/images/bynder_component1.png)

![XbK Bynder selector items preview](/images/bynder_component2.png)

## Library Version Matrix

| Xperience Version | Library Version |
| ----------------- | --------------- |
| >= 29.2.0         | 1.0.0           |
| >= 29.2.0         | 1.1.0           |

### Dependencies

- [ASP.NET Core 6.0](https://dotnet.microsoft.com/en-us/download)
- [Xperience by Kentico](https://docs.kentico.com/changelog)
- [Bynder Compact View React Component](https://www.npmjs.com/package/@bynder/compact-view)

## Package Installation

Add the package to your application using the .NET CLI

```powershell
dotnet add package XperienceCommunity.Bynder
```

## Quick Start

### Widget properties

C# data type: **IEnumerable\<BynderAsset\>** \
Form component attribute: **BynderSelectorComponent**

Attribute configuration properties:

- **MinimumAssets** - sets the minimum number of selected assets, default value is 0
- **MaximumAssets** - sets the maximum number of selected assets, default value is 0 (unlimited)
- **AssetTypes** - Allows to limit allowed asset types, see the [AssetTypeConsts](#assettypeconsts)

Example:

```csharp
    public class BynderImageWidgetProperties : IWidgetProperties
    {
        [BynderSelectorComponent(AllowedTypes = new[] { AssetTypeConsts.Image }, MinimumAssets = 1, MaximumAssets = 3)]
        public IEnumerable<BynderAsset> BynderImage { get; set; }
    }

```

### Content type fields

Data type: **bynderassets** \
Form component: **Bynder selector form component**

Form component configuration:

- **MinimumAssets** - sets the minimum number of selected assets, default value is 0
- **MaximumAssets** - sets the maximum number of selected assets, default value is 0 (unlimited)
- **AssetType** - Allows to limit allowed asset types, supports single select only

![XbK Bynder selector for content type](/images/bynder_component_contenttype.png)

## Full Instructions

### C# data model

```csharp
    public class BynderAsset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string[] Extensions { get; set; }
        public string[] Tags { get; set; }
        public string DatabaseId { get; set; }
        public string Type { get; set; }
        public BynderAssetFiles Files { get; set; }
    }

    public class BynderAssetFiles : Dictionary<string, BynderAssetFile>
    {
        public BynderAssetFile Original => this["original"];
        public BynderAssetFile Thumbnail => this["thumbnail"];
        public BynderAssetFile Mini => this["mini"];
        public BynderAssetFile WebImage => this["webImage"];
    }

    public class BynderAssetFile
    {
        public string Url { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? FileSize { get; set; }
    }
```

### AssetTypeConsts

This static class contains constants with all possible values for limiting allowed asset types.

```csharp
    public static class AssetTypeConsts
    {
        public const string Image = "IMAGE";
        public const string Document = "DOCUMENT";
        public const string Video = "VIDEO";
        public const string Audio = "AUDIO";
    }
```

See more info on [Bynder Docs](https://developer-docs.bynder.com/ui-components#compact-view)

### DancingGoat widget example

See the Bynder image widget implemented in the DancingGoat site [BynderImageWidget](./examples/DancingGoat/Components/Widgets/BynderImageWidget/)

## Contributing

Feel free to submit issues or pull requests to the repository.

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.
