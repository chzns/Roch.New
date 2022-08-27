//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :BaseMapper
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

using Roch.DomainModel;
using System.Data.SqlClient;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using System.Data.OracleClient;
namespace Roch.Database
{
    /// <summary>
    /// 数据基类
    /// </summary>
    public abstract class BaseMapper
    {
        private string m_ServerName;
        private string m_UserName;
        private string m_Password;
        private bool m_IsConnection;
        private DatabaseType m_DatabaseType;
        private DbConnection m_Connection;

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName
        {
            get { return m_ServerName; }
            set { m_ServerName = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        /// <summary>
        /// 是否连通
        /// </summary>
        public bool IsConnection
        {
            get { return m_IsConnection; }
            set { m_IsConnection = value; }
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        protected DbConnection Connection
        {
            get { return m_Connection; }
            set { m_Connection = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType
        {
            get { return m_DatabaseType; }
            set { m_DatabaseType = value; }
        }

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        public void CreateConnection()
        {
            switch (DatabaseType)
            {
                case DatabaseType.SQLServer:
                    {
                        //Data Source = myServerAddress; Initial Catalog = myDataBase; User Id = myUsername; Password = myPassword;
                        //m_Connection = new SqlConnection(string.Format("server={0};database=master;uid={1};pwd={2}", m_ServerName, m_UserName, m_Password));

                        m_Connection = new SqlConnection(string.Format(" Data Source = {0}; Initial Catalog = master; Integrated Security = SSPI;", m_ServerName));
                     
                        break;
                    }
                case DatabaseType.Oracle:
                    {
                        m_Connection = new OracleConnection(string.Format("Data Source={0};User Id={1};Password={2};", m_ServerName, m_UserName, m_Password));
                        break;
                    }
                case DatabaseType.SQLServer2008:
                    {
                        m_Connection = new SqlConnection(string.Format("server={0};database=master;uid={1};pwd={2};Trusted_Connection = True;", m_ServerName, m_UserName, m_Password));
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            try
            {
                CreateConnection();
                m_Connection.Open();
                m_IsConnection = true;
            }
            catch (Exception e)
            {
                m_IsConnection = false;
            }
            finally
            {
                m_Connection.Close();
            }

            return IsConnection;
        }

        /// <summary>
        /// 生成DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecQueryTable(string sql)
        {
            CreateConnection();
            Connection.Open();
            DbDataAdapter dbDataAdapter = null;

            if (m_DatabaseType == DatabaseType.SQLServer)
            {
                dbDataAdapter = new SqlDataAdapter(sql, Connection as SqlConnection);
            }
            else if (m_DatabaseType == DatabaseType.Oracle)
            {
                dbDataAdapter = new OracleDataAdapter(sql, Connection as OracleConnection);
            }
            else if (m_DatabaseType == DatabaseType.SQLServer2008)
            {
                dbDataAdapter = new SqlDataAdapter(sql, Connection as SqlConnection);
            }

            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);

            Connection.Close();

            return ds.Tables[0];
        }
        
        #region 数据转换
        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetBoolean(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return false;
            }

            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetString(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return string.Empty;
            }

            return Convert.ToString(value).Trim();
        }

        /// <summary>
        /// 转换为数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetInt(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return 0;
            }

            int returnValue;

            int.TryParse(value.ToString(), out returnValue);

            return returnValue;
        }

        /// <summary>
        /// 转换为数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ulong GetULong(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return 0;
            }

            ulong returnValue;

            ulong.TryParse(value.ToString(), out returnValue);

            return returnValue;
        }
        #endregion
    }
}
