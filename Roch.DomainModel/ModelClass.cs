using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roch.DomainModel
{

    public class ModelClass
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnUI_DisplayName { get; set; }
        public string DataType { get; set; }
        public string Is_Identity { get; set; }
        public string ColumnRemarks { get; set; }
        public string ColumnType { get; set; }
        public string ColumnDefaultValue { get; set; }
        public string ColumnUI_ID { get; set; }
        public string ColumnUI_Type { get; set; }
   

        public string JasonDefaultValue { get; set; }
        public string Is_Null { get; set; }

    }

    public class SettingVM
    {
        public List<ModelClass> list { get; set; }
        public string TableName { get; set; }
        public string TableNameToLower { get; set; }
        public string PKUID { get; set; }

    }

    public class ModelStr
    {
        public string ColumnStr { get; set; }
        public string ModelName { get; set; }

    }

}
