//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :CodeMain
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Roch.DomainModel;
using Roch.Database;
using Roch.Framework;
using System.Linq;

namespace Roch.CodeTool
{
    /// <summary>
    /// 主界面树层控件事件
    /// </summary> 
    public partial class CodeMain
    {
        /// <summary>
        /// 树形选择控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvServer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode currentNode = e.Node;
            string databaseName = string.Empty;
            string objectName = string.Empty;
            string type = string.Empty;
            m_CurrentColumnModels.Clear();

            #region 判断
            if (currentNode == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(currentNode.Text))
            {
                return;
            }

            if (currentNode.Tag == null)
            {
                if (currentNode.Nodes.Count > 0)
                {
                    return;
                }

                databaseName = currentNode.Parent.Parent.Text;
                objectName = currentNode.Text;

                DisplayObjectInfo(databaseName, objectName);

                return;
            }
            #endregion

            databaseName = currentNode.Parent.Text;
            type = currentNode.Tag.ToString();
            currentNode.Nodes.Clear();

            foreach (DBObjectModel dbObject in DatabaseMapper.Instance.FindAllDatabaseObjects(databaseName, type))
            {
                TreeNode objectNode = new TreeNode(dbObject.Name);

                currentNode.Nodes.Add(objectNode);
            }

            currentNode.Expand();
        }



        public void DisplayObjectInfo(string databaseName, string objectName)
        {
            m_CurrentColumnModels = DatabaseMapper.Instance.FindAllColumns(databaseName, objectName);
            //dataGrid.DataSource = m_CurrentColumnModels;

            ColumnModel columnModel = m_CurrentColumnModels.Find(c => c.IsPK);

            //txtClassName.Text = objectName;
            //txtPK.Text = columnModel == null ? string.Empty : columnModel.Name;


            //列名字
            var columns = string.Empty;

            var typeStr = string.Empty;

            ConstConstants.mainModelList = m_CurrentColumnModels;

            foreach (var item in m_CurrentColumnModels)
            {
                columns = columns + item.Name+"|"+item.TypeName + ",";
                //typeStr = typeStr + item.TypeName.ToString() + ",";
  
            }
            if (columns!=string.Empty)
            {
                columns = columns.Substring(0, columns.Length - 1);
            
            }
            
            //txtColumns.Text = columns;
            GenerateModel(columns, objectName);
            m_ConfigInfo.DatabaseName = databaseName;
            m_ConfigInfo.TableName = objectName;
            if (DatabaseMapper.Instance.DatabaseType == DatabaseType.SQLServer)
            {
                m_ConfigInfo.PKType = columnModel == null ? "string" : DBTypeUtilily.DBTypeToCS(columnModel.TypeName);
            }
            else if (DatabaseMapper.Instance.DatabaseType == DatabaseType.Oracle)
            {
                m_ConfigInfo.PKType = columnModel == null ? "string" : DBTypeUtilily.OracleDBTypeToCS(columnModel.TypeName, columnModel.Length, columnModel.Precision, columnModel.Scale);
            }

            m_ConfigInfo.PKLength = columnModel == null ? 0 : columnModel.Length;
        }


        public void GenerateModel(string modelstr,string objectName)
        {
            var modellist = modelstr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(string .Format("public class {0} ",objectName));
            sb.Insert(0,"");
            sb.Append("\n");
            sb.Append("{");
            sb.Append("\n");
            foreach (var item in modellist)
            {
                var child = item.ToString().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                var name = child[0].ToString();
                var type = string.Empty;
                switch (child[1].ToString().ToLower())
                {
                    default:
                        type = "string";
                        break;
                    case "nvarchar":
                    case "varchar":
                        type = "string";
                        break;
                    case "uniqueidentifier":
                        type = "Guid";
                        break;
                    case "date":
                    case "datetime":
                        type = "DateTime";
                        break;
                    case"int":
                        type = "Int";
                        break;
                }

                sb.Append(string.Format(" public {0} {1}", type, name) + " { get; set; }");
                sb.Append("\n");
            }
            sb.Append("\n");
            sb.Append("}");
            //txtOld.Text = sb.ToString();
        
        }


    }
}
