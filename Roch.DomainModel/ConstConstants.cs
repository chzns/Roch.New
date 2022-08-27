using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Roch.DomainModel;
namespace Roch.DomainModel
{
    public static class ConstConstants
    {
        public static string Const_ModelClass = AppDomain.CurrentDomain.BaseDirectory + "/ModelClass.xls";

        public static string Const_ModelClassTemp = AppDomain.CurrentDomain.BaseDirectory + "/ModelClass_Temp.xls";

        public static List<ModelClass> modelClassList = null;

        public static DataTable modelClassDataTable = null;

        public static List<ColumnModel> mainModelList = null;

        public static string Words_Item_Path = AppDomain.CurrentDomain.BaseDirectory + "/List.xls";

        public static string Words_Item_Temp_Path = AppDomain.CurrentDomain.BaseDirectory + "/List_Temp.xls";


        public static string Item_Model_Path = AppDomain.CurrentDomain.BaseDirectory + "/Item_Model.xls";

        public static string Item_Model_Path_Temp = AppDomain.CurrentDomain.BaseDirectory + "/Item_Model_Temp.xls";

    }

    public static class ConstColumnUI_Type
    {
        public static string ui_input = "input";
        public static string ui_select = "select";

    }
    public static class ConstColumnUI_TypeValue
    {
        public static string ui_input = "js_input_";
        public static string ui_select = "js_s_select_";
    }
}
