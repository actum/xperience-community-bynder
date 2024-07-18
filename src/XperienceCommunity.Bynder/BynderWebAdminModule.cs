using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

using CMS.DataEngine;
using CMS.DataEngine.Internal;
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
        public BynderWebAdminModule()
            : base("Bynder.Web.Admin")
        {
        }

        protected override void OnPreInit()
        {
            base.OnPreInit();
            this.RegisterDataTypes();
        }

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("xperiencecommunity", "bynder");
        }

        private void RegisterDataTypes()
        {
            DataTypeManager.RegisterDataTypes(new DataType<IEnumerable<BynderAsset>>("nvarchar(max)", "bynderassets", "xs:string", JsonDataTypeConverter.ConvertToModels, JsonDataTypeConverter.ConvertToString, new DefaultDataTypeTextSerializer("bynderassets"))
            {
                TypeName = "Bynder assets",
                TypeAlias = "string",
                TypeGroup = "Assets",
                SqlValueFormat = "N'{0}'",
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "String.Empty",
                IsAvailableForDataClass = (DataClassInfo dataClassInfo) => !string.Equals(dataClassInfo.ClassContentTypeType, "Email", StringComparison.OrdinalIgnoreCase)
            });

            RegisterDefaultValueComponent("bynderassets", TextInputComponent.IDENTIFIER, ValidationHelper.GetValue<string>, (string value) => ValidationHelper.GetValue<string>(value));
        }
    }
}
