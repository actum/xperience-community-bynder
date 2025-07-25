using System;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.FormAnnotations.Internal;

namespace XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector
{
    [MapProperties]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class BynderSelectorComponentAttribute : FormComponentAttribute
    {
        public string[] AllowedTypes { get; set; }

        public int MinimumAssets { get; set; }

        public int MaximumAssets { get; set; }
    }
}
