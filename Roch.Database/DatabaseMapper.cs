//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :DatabaseMapper
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;

using Roch.DomainModel;

namespace Roch.Database
{
    /// <summary>
    /// 数据库映射
    /// </summary>
    public class DatabaseMapper : BaseMapper
    {
        #region Instance
        private static DatabaseMapper m_Instance;
        public static DatabaseMapper Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new DatabaseMapper();
                }

                return m_Instance;
            }
        }

        private DatabaseMapper()
        {

        }

        private DatabaseMapper(string serverName, string userName, string password, DatabaseType databaseType)
        {
            ServerName = serverName;
            UserName = userName;
            Password = password;
            DatabaseType = databaseType;
            CreateConnection();
        }

        public static bool CreateInstance(string serverName, string userName, string password, DatabaseType databaseType)
        {
            m_Instance = new DatabaseMapper(serverName, userName, password, databaseType);
            return m_Instance.TestConnection();
        }
        #endregion

        /// <summary>
        /// 获取所有的数据库
        /// </summary>
        /// <returns></returns>
        public List<DatabaseModel> FindAllDatabases(DatabaseType databaseType)
        {
            List<DatabaseModel> databaseModels = new List<DatabaseModel>();

            if (databaseType == DatabaseType.SQLServer)
            {
                DataTable dt = ExecQueryTable("select dbid,name from sysdatabases   order by dbid");

                foreach (DataRow row in dt.Rows)
                {
                    DatabaseModel database = new DatabaseModel();
                    database.ID = GetULong(row["dbid"]);
                    database.Name = GetString(row["name"]);

                    databaseModels.Add(database);
                }
            }
            else if (databaseType == DatabaseType.SQLServer2008)
            {
                DataTable dt = ExecQueryTable("select dbid,name from sys.sysdatabases  order by dbid");

                foreach (DataRow row in dt.Rows)
                {
                    DatabaseModel database = new DatabaseModel();
                    database.ID = GetULong(row["dbid"]);
                    database.Name = GetString(row["name"]);

                    databaseModels.Add(database);
                }
            }

            return databaseModels;
        }

        /// <summary>
        /// 根据类型获取所有数据库的元素信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DBObjectModel> FindAllDatabaseObjects(string dbName, string type)
        {
            List<DBObjectModel> dbObjectModels = new List<DBObjectModel>();

            if (DatabaseType == DatabaseType.SQLServer)
            {
                DataTable dt = ExecQueryTable(string.Format("select id,name from [{0}].dbo.sysobjects where type= '{1}' order by name", dbName, type));

                foreach (DataRow row in dt.Rows)
                {
                    DBObjectModel dbObject = new DBObjectModel();
                    dbObject.ID = GetULong(row["id"]);
                    dbObject.Name = GetString(row["name"]);

                    dbObjectModels.Add(dbObject);
                }
            }
            else if (DatabaseType == DatabaseType.Oracle)
            {
                DataTable dt = new DataTable();
                string sql = string.Empty;
                switch (type)
                {
                    case "U":
                        {
                            sql = string.Format("select Table_name from user_all_tables order by Table_name");
                            dt = ExecQueryTable(sql);

                            foreach (DataRow row in dt.Rows)
                            {
                                DBObjectModel dbObject = new DBObjectModel();
                                dbObject.ID = 0;
                                dbObject.Name = GetString(row["Table_name"]);

                                dbObjectModels.Add(dbObject);
                            }

                            break;
                        }
                    case "V":
                        sql = string.Format("select OBJECT_NAME,OBJECT_ID from dba_objects where object_type ='VIEW'  and owner='WIMS'");
                        dt = ExecQueryTable(sql);

                        foreach (DataRow row in dt.Rows)
                        {
                            DBObjectModel dbObject = new DBObjectModel();
                            dbObject.ID = GetULong(row["OBJECT_ID"]);
                            dbObject.Name = GetString(row["OBJECT_NAME"]);

                            dbObjectModels.Add(dbObject);
                        }

                        break;
                    case "P":
                        //dt = ExecQueryTable("");
                        break;
                    default: break;
                }
            }
            else if (DatabaseType == DatabaseType.SQLServer2008)
            {
                DataTable dt = ExecQueryTable(string.Format("select id,name from [{0}].sys.sysobjects where type= '{1}' order by name", dbName, type));

                foreach (DataRow row in dt.Rows)
                {
                    DBObjectModel dbObject = new DBObjectModel();
                    dbObject.ID = GetULong(row["id"]);
                    dbObject.Name = GetString(row["name"]);

                    dbObjectModels.Add(dbObject);
                }
            }

            return dbObjectModels;
        }

        /// <summary>
        /// 获取所有数据库中表的列信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public List<ColumnModel> FindAllColumns(string dbName, string tableName)
        {
            List<ColumnModel> columnModels = new List<ColumnModel>();

            if (DatabaseType == DatabaseType.SQLServer)
            {
                string sql = string.Format("select a.name,b.colid, rtrim(b.name) as colname,b.colorder,case when h.id is not null then 1 else 0 end as primarykey,type_name(b.xusertype) as type,b.colstat as isIdentity,b.length,b.xprec,b.xscale,case b.isnullable when 0 then 0 else 1 end as [isnull],isnull(e.text, ' ') as [default],isnull(c.value, ' ') as [description] from   [{0}].dbo.sysobjects a,[{0}].dbo.syscolumns b left outer join [{0}].dbo.sysproperties c on b.id = c.id and b.colid = c.smallid left outer join [{0}].dbo.syscomments e on b.cdefault = e.id left outer join (select g.id,g.colid from [{0}].dbo.sysindexes f,[{0}].dbo.sysindexkeys g where f.id = g.id and f.indid = g.indid and f.indid > 0 and f.indid < 255 and (f.status & 2048) <> 0) h on b.id = h.id and b.colid = h.colid where a.id = b.id  and a.name = '{1}' order by b.colorder", dbName, tableName);

                foreach (DataRow row in ExecQueryTable(sql).Rows)
                {
                    ColumnModel column = new ColumnModel();
                    column.ID = GetULong(row["colid"]);
                    column.ObjectName = GetString(row["name"]);
                    column.Name = GetString(row["colname"]);
                    column.ColumnOrder = GetInt(row["colorder"]);
                    column.IsPK = GetBoolean(row["primarykey"]);
                    column.TypeName = GetString(row["type"]);
                    column.IsIdentity = GetBoolean(row["isIdentity"]);
                    column.Length = GetInt(row["length"]);
                    column.Precision = GetInt(row["xprec"]);
                    column.Scale = GetInt(row["xscale"]);
                    column.IsNull = GetBoolean(row["isnull"]);
                    column.DefaultValue = GetString(row["default"]);
                    column.Description = GetString(row["description"]);

                    columnModels.Add(column);
                }
            }
            else if (DatabaseType == DatabaseType.Oracle)
            {
                string sql = string.Format("select a.owner, a.table_name, a.column_ID,a.column_name,decode((  select d.constraint_type from user_cons_columns c,user_constraints d where  c.constraint_name=d.constraint_name and  c.owner=a.owner and c.TABLE_name=a.table_name and  c.column_name=a.column_name  and d.CONSTRAINT_TYPE='P'),'P',1,0) primarykey,a.data_type, a.Data_Length,decode( a.data_precision,'',0,a.data_precision) as data_precision, decode( a.data_scale,'',0,a.data_scale) as data_scale ,decode( a.nullable,'N',0,'Y',1,1) as nullable,a.data_default,b.comments from all_tab_cols a,all_col_comments b where a.table_name=b.table_name and a.column_name=b.column_name and a.owner=b.owner and a.table_name=upper('{0}') and a.owner=upper('{1}') order by a.column_id asc", tableName, UserName);

                foreach (DataRow row in ExecQueryTable(sql).Rows)
                {
                    ColumnModel column = new ColumnModel();
                    column.ID = GetULong(row["COLUMN_ID"]);
                    column.ObjectName = GetString(row["TABLE_NAME"]);
                    column.Name = GetString(row["COLUMN_NAME"]);
                    column.ColumnOrder = GetInt(row["COLUMN_ID"]);
                    column.IsPK = GetBoolean(row["PRIMARYKEY"]);
                    column.TypeName = GetString(row["DATA_TYPE"]);
                    column.IsIdentity = false;
                    column.Length = GetInt(row["DATA_LENGTH"]);
                    column.Precision = GetInt(row["DATA_PRECISION"]);
                    column.Scale = GetInt(row["DATA_SCALE"]);
                    column.IsNull = GetBoolean(row["NULLABLE"]);
                    column.DefaultValue = GetString(row["DATA_DEFAULT"]);
                    column.Description = GetString(row["COMMENTS"]);

                    columnModels.Add(column);
                }
            }
            else if (DatabaseType == DatabaseType.SQLServer2008)
            {
                string sql = string.Format("select a.name,b.colid, rtrim(b.name) as colname,b.colorder,case when h.id is not null then 1 else 0 end as primarykey,type_name(b.xusertype) as type,b.colstat as isIdentity,b.length,b.xprec,b.xscale,case b.isnullable when 0 then 0 else 1 end as [isnull],isnull(e.text, ' ') as [default],isnull(c.value, ' ') as [description] from   [{0}].dbo.sysobjects a,[{0}].dbo.syscolumns b left outer join [{0}].sys.extended_properties c on b.id=c.major_id AND b.colid = c.minor_id left outer join [{0}].dbo.syscomments e on b.cdefault = e.id left outer join (select g.id,g.colid from [{0}].dbo.sysindexes f,[{0}].dbo.sysindexkeys g where f.id = g.id and f.indid = g.indid and f.indid > 0 and f.indid < 255 and (f.status & 2048) <> 0) h on b.id = h.id and b.colid = h.colid where a.id = b.id  and a.name = '{1}' order by b.colorder", dbName, tableName);

                foreach (DataRow row in ExecQueryTable(sql).Rows)
                {
                    ColumnModel column = new ColumnModel();
                    column.ID = GetULong(row["colid"]);
                    column.ObjectName = GetString(row["name"]);
                    column.Name = GetString(row["colname"]);
                    column.ColumnOrder = GetInt(row["colorder"]);
                    column.IsPK = GetBoolean(row["primarykey"]);
                    column.TypeName = GetString(row["type"]);
                    column.IsIdentity = GetBoolean(row["isIdentity"]);
                    column.Length = GetInt(row["length"]);
                    column.Precision = GetInt(row["xprec"]);
                    column.Scale = GetInt(row["xscale"]);
                    column.IsNull = GetBoolean(row["isnull"]);
                    column.DefaultValue = GetString(row["default"]);
                    column.Description = GetString(row["description"]);

                    columnModels.Add(column);
                }
            }

            return columnModels;
        }

        /// <summary>
        /// 获取找到数据库表中的数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable FindDataByTable(string dbName, string tableName)
        {
            string sql = string.Empty;
            if (DatabaseType == DatabaseType.SQLServer)
            {
                sql = string.Format("SELECT * FROM {0}.dbo.{1}", dbName, tableName);
            }
            else if (DatabaseType == DatabaseType.Oracle)
            {
                sql = string.Format("SELECT * FROM {0}", tableName);
            }
            else if (DatabaseType == DatabaseType.SQLServer2008)
            {
                sql = string.Format("SELECT * FROM {0}.dbo.{1}", dbName, tableName);
            }

            return ExecQueryTable(sql);
        }
    }
}
