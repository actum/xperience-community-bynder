using System;
using System.Collections.Generic;
using System.Data;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using Kentico.Xperience.Admin.Base;

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
            DataTypeManager.RegisterDataTypes(new DataType<IEnumerable<BynderAsset>>("nvarchar(max)", "assets", "xs:string", JsonDataTypeConverter.ConvertToModels, JsonDataTypeConverter.ConvertToString, new DefaultDataTypeTextSerializer("assets"))
            {
                TypeAlias = "string",
                TypeGroup = "Assets",
                SqlValueFormat = "N'{0}'",
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "String.Empty",
                IsAvailableForDataClass = (DataClassInfo dataClassInfo) => !string.Equals(dataClassInfo.ClassContentTypeType, "Email", StringComparison.OrdinalIgnoreCase)
            });
        }
    }
}
