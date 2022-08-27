
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Roch.DomainModel;

namespace Roch.Framework
{
    public class  ExcelToList
    {

        public static IList<T> GetList<T>(DataTable table)
        {
            IList<T> list = new List<T>(); //里氏替换原则
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>(); ////创建指定类型的实例
                propertypes = t.GetType().GetProperties(); //得到类的属性
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName.ToUpper()))
                    {
                        object value = row[tempName].ToString();
                        if (value is System.DBNull)
                        {
                            value = "";
                        }
                        pro.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }
        #region  ModelClass 魔板

        public static List<ModelClass> ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            var list = GetList<ModelClass>(ds.Tables[0]).ToList();
            return list;
        }

        public static DataTable modelClassDataTable(string path)
        {
            Workbook workbook = new Workbook();
            var temp_path = ConstConstants.Const_ModelClassTemp;
            LocalFileHelper.Copy(path, temp_path);
            workbook.Open(temp_path);
            Cells cells = workbook.Worksheets[0].Cells;
            //System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, true);//显示标题


            System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow+1, cells.MaxColumn,true);//noneTitle

            //System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow, cells.MaxColumn, true);//noneTitle

            //System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow+1, cells.MaxColumn, true);//noneTitle

            //System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, true);//noneTitle

            //System.Data.DataTable datatable1 = Cells.ExportDataTableAsString(iFirstRow, iFirstCol, rowNum + 1, colNum + 1, exportColumnName);
            return dataTable1;
        }

        public static List<ModelClass> ExcelToModelClassList(string path)
        {
            DataTable datable = modelClassDataTable(path);
            var list = GetList<ModelClass>(datable).ToList();
            return list;
        }
        
        #endregion


        #region MyRegion

        public  IList<Item_Model> Item_Model_ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            var list = GetList<Item_Model>(ds.Tables[0]).ToList();
            return list;
        
        }

        public  DataTable Item_Model_DataTable(string path)
        {
            Workbook workbook = new Workbook();
            var temp_path = ConstConstants.Item_Model_Path_Temp;
            LocalFileHelper.Copy(path, temp_path);
            workbook.Open(temp_path);
            Cells cells = workbook.Worksheets[0].Cells;
            System.Data.DataTable dataTable1 = cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, true);//noneTitle
            return dataTable1;
        }


        public static List<Item_Model> Item_Model_ExcelToModel(string path)
        {
            DataTable datable = modelClassDataTable(path);
            var list = GetList<Item_Model>(datable).ToList();
            return list;
        }


        #endregion


    }



}


