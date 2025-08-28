using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using CMS.Core;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.FormEngine;
using CMS.Helpers;

using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.Bynder;
using XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector;

[assembly: CMS.RegisterModule(typeof(BynderWebAdminModule))]

namespace XperienceCommunity.Bynder
{
    internal class BynderWebAdminModule : AdminModule
    {
        public const string DataTypeName = "bynderassets";

        public BynderWebAdminModule()
            : base("Bynder.Web.Admin")
        {
        }

        protected override void OnPreInit(ModulePreInitParameters parameters)
        {
            base.OnPreInit(parameters);
            Debugger.Launch();
            RegisterDataTypes();
            RegisterCodeGenerator();
        }

        protected override void OnInit(ModuleInitParameters parameters)
        {
            base.OnInit(parameters);

            // Makes the module accessible to the admin UI
            RegisterClientModule("xperiencecommunity", "bynder");
        }

        private void RegisterDataTypes()
        {
            DataTypeManager.RegisterDataTypes(new DataType<IEnumerable<BynderAsset>>("nvarchar(max)", DataTypeName, "xs:string", JsonDataTypeConverter.ConvertToModels, JsonDataTypeConverter.ConvertToString, new DefaultDataTypeTextSerializer("bynderassets"))
            {
                TypeName = "Bynder assets",
                TypeAlias = "string",
                //TypeGroup = "Assets",
                SqlValueFormat = "N'{0}'",
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "String.Empty",
                IsAvailableForDataClass = (DataClassInfo dataClassInfo) => !string.Equals(dataClassInfo.ClassContentTypeType, "Email", StringComparison.OrdinalIgnoreCase)
            });

            RegisterDefaultValueComponent(DataTypeName, TextInputComponent.IDENTIFIER, ValidationHelper.GetValue<string>, (string value) => ValidationHelper.GetValue<string>(value));
        }

        private static void RegisterCodeGenerator()
        {
            var generator = new DataTypeCodeGenerator(
                    field => "IEnumerable<BynderAsset>",
                    field => nameof(ValidationHelper.GetString),
                    field => "[]",
                    field => ["System.Collections.Generic", "XperienceCommunity.Bynder.Admin.UIFormComponents.BynderSelector"],
                    field => ""
                );

            DataTypeCodeGenerationManager.RegisterDataTypeCodeGenerator(DataTypeName, () => generator);
        }
    }
}
