using Dapper;
using System;
using System.Linq;
using JGPHR.JobAssignment.Entities;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using JGPHR.JobAssignment.Entity;
using JGPHR.JobAssignment.Repository.Common;

namespace JGPHR.JobAssignment.Repository
{
    public class ProcessCodeDataRepo : BaseRepo
    {

        IOptions<AppSettings> _appSetting;

         public ProcessCodeDataRepo(IOptions<AppSettings> appSettings) : base(appSettings)
        {
            _appSetting = appSettings;
        }

        #region CURD

        public async Task<string> InsProcessCodeData(ProcessCodeDataParam param)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                 
                sParam.Add("@ProcessCodeData_UID", param.ProcessCodeData_UID);
                sParam.Add("@SizingWeek", param.SizingWeek);
                sParam.Add("@PersonnelArea", param.PersonnelArea);
                sParam.Add("@CreatedBy", param.CreatedBy);
                sParam.Add("@CreatedName", param.CreatedName);
                sParam.Add("@CreatedTime", param.CreatedTime);
                sParam.Add("@Building", param.Building);
                sParam.Add("@SiteProcess", param.SiteProcess);
                sParam.Add("@SingleMultiple", param.SingleMultiple);
                sParam.Add("@Line", param.Line);
                sParam.Add("@Department", param.Department);
                sParam.Add("@Workstation", param.Workstation);
                sParam.Add("@ProcessDescription", param.ProcessDescription);
                sParam.Add("@StandardHeadcount", param.StandardHeadcount);

                var db = conn;
                return await db.ExecuteAsync(
                    "JA_InsProcessCodeDataP",
                    sParam,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelProcessCodeData(ProcessCodeDataParam param)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("ProcessCodeData_UID", param.ProcessCodeData_UID);
                /*
                 
                sParam.Add("@ProcessCodeData_UID", param.ProcessCodeData_UID);
                sParam.Add("@SizingWeek", param.SizingWeek);
                sParam.Add("@PersonnelArea", param.PersonnelArea);
                sParam.Add("@CreatedBy", param.CreatedBy);
                sParam.Add("@CreatedName", param.CreatedName);
                sParam.Add("@CreatedTime", param.CreatedTime);
                sParam.Add("@Building", param.Building);
                sParam.Add("@SiteProcess", param.SiteProcess);
                sParam.Add("@SingleMultiple", param.SingleMultiple);
                sParam.Add("@Line", param.Line);
                sParam.Add("@Department", param.Department);
                sParam.Add("@Workstation", param.Workstation);
                sParam.Add("@ProcessDescription", param.ProcessDescription);
                sParam.Add("@StandardHeadcount", param.StandardHeadcount);

                */
                var db = conn;
                return await db.ExecuteAsync(
                    "JA_DelProcessCodeDataP",
                    sParam,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<ProcessCodeDataMainData> GetProcessCodeDataMain(ProcessCodeDataParam param)
        {
            try
            {
                ProcessCodeDataMainData vm = new ProcessCodeDataMainData();
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("pageSize", param.pageSize);
                sParam.Add("PageNo", param.PageNo);
                sParam.Add("Employee_ID", param.EmployeeId);
                sParam.Add("SearchType", param.SearchType);
                /*
                 
                sParam.Add("@ProcessCodeData_UID", param.ProcessCodeData_UID);
                sParam.Add("@SizingWeek", param.SizingWeek);
                sParam.Add("@PersonnelArea", param.PersonnelArea);
                sParam.Add("@CreatedBy", param.CreatedBy);
                sParam.Add("@CreatedName", param.CreatedName);
                sParam.Add("@CreatedTime", param.CreatedTime);
                sParam.Add("@Building", param.Building);
                sParam.Add("@SiteProcess", param.SiteProcess);
                sParam.Add("@SingleMultiple", param.SingleMultiple);
                sParam.Add("@Line", param.Line);
                sParam.Add("@Department", param.Department);
                sParam.Add("@Workstation", param.Workstation);
                sParam.Add("@ProcessDescription", param.ProcessDescription);
                sParam.Add("@StandardHeadcount", param.StandardHeadcount);

                 */
                
                var db = conn;
                using (var multi = await db.QueryMultipleAsync($"JA_GetProcessCodeDataP", sParam, commandTimeout: 0, commandType: CommandType.StoredProcedure))
                 {
              
                    vm.total = multi.ReadFirst<int>();
                    vm.data = multi.Read<ProcessCodeData>().ToList();
                    return vm;
                 }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       public async Task<List<ProcessCodeData>> GetProcessCodeData(ProcessCodeDataParam request)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("EmployeeId", request.CreatedBy);
                sParam.Add("Search_Type", request.SearchType);
                #region XML查询
                var UIDXML = "";
                var UIDs = request.UIDs;
                if (UIDs != null && UIDs.Count > 0)
                {
                    UIDXML = XMLHelper.Serialize(UIDs, "UID");
                }
                sParam.Add("UIDXML", UIDXML); 
                #endregion
                var db = conn;
                using (var multi = await db.QueryMultipleAsync($"JA_GetProcessCodeDataP", sParam, commandType: CommandType.StoredProcedure))
                {
                    return multi.Read<ProcessCodeData>().ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdProcessCodeData(ProcessCodeDataParam param)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                 
                sParam.Add("@ProcessCodeData_UID", param.ProcessCodeData_UID);
                sParam.Add("@SizingWeek", param.SizingWeek);
                sParam.Add("@PersonnelArea", param.PersonnelArea);
                sParam.Add("@CreatedBy", param.CreatedBy);
                sParam.Add("@CreatedName", param.CreatedName);
                sParam.Add("@CreatedTime", param.CreatedTime);
                sParam.Add("@Building", param.Building);
                sParam.Add("@SiteProcess", param.SiteProcess);
                sParam.Add("@SingleMultiple", param.SingleMultiple);
                sParam.Add("@Line", param.Line);
                sParam.Add("@Department", param.Department);
                sParam.Add("@Workstation", param.Workstation);
                sParam.Add("@ProcessDescription", param.ProcessDescription);
                sParam.Add("@StandardHeadcount", param.StandardHeadcount);

                var db = conn;
                return await db.ExecuteAsync(
                    "JA_UpdProcessCodeDataP",
                    sParam,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> UnintTest(ProcessCodeDataParam param)
        { 
           return  DateTime.Now.ToString();
        }
    
        #endregion CURD

       #region Upload

        public async Task<bool> BulkDelProcessCodeData(ProcessCodeDataParam param)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("@CreatedBy", param.CreatedBy);
                var db = conn;
                await db.ExecuteAsync(
                    "JA_BulkDelProcessCodeDataP",
                    sParam,
                    commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<bool> BulkProcessCodeData (DataTable dt)
        {
            var db = conn;
            bool result = false;
            string tableName = "[dbo].[JA_TM_ProcessCodeData_T]";
            using (var localConnection = new SqlConnection(db.ConnectionString))
            {
                localConnection.Open();
                using (var tran = localConnection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var bulkCopy = new SqlBulkCopy(localConnection, SqlBulkCopyOptions.Default, tran))
                    {
                        bulkCopy.DestinationTableName = tableName;
                         
                        bulkCopy.ColumnMappings.Add("ProcessCodeData_UID", "ProcessCodeData_UID");
                        bulkCopy.ColumnMappings.Add("SizingWeek", "SizingWeek");
                        bulkCopy.ColumnMappings.Add("PersonnelArea", "PersonnelArea");
                        bulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
                        bulkCopy.ColumnMappings.Add("CreatedName", "CreatedName");
                        bulkCopy.ColumnMappings.Add("CreatedTime", "CreatedTime");
                        bulkCopy.ColumnMappings.Add("Building", "Building");
                        bulkCopy.ColumnMappings.Add("SiteProcess", "SiteProcess");
                        bulkCopy.ColumnMappings.Add("SingleMultiple", "SingleMultiple");
                        bulkCopy.ColumnMappings.Add("Line", "Line");
                        bulkCopy.ColumnMappings.Add("Department", "Department");
                        bulkCopy.ColumnMappings.Add("Workstation", "Workstation");
                        bulkCopy.ColumnMappings.Add("ProcessDescription", "ProcessDescription");
                        bulkCopy.ColumnMappings.Add("StandardHeadcount", "StandardHeadcount");

                        bulkCopy.BatchSize = 5000;
                        try
                        {
                            await bulkCopy.WriteToServerAsync(dt);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            tran.Commit();
                            result = true;
                        }
                    }
                }
                localConnection.Close();
                return result;
            }
        }
        public async Task<int> BulkValidProcessCodeData(ProcessCodeDataParam param)
        {
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("@CreatedBy", param.CreatedBy);
                var db = conn;
                using (var multi = await db.QueryMultipleAsync($"JA_BulkValidateProcessCodeDataP", sParam, commandTimeout: 0, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<string> BulkConfirmProcessCodeData(ProcessCodeDataParam param)
        {
            string re = string.Empty;
            try
            {
                DynamicParameters sParam = new DynamicParameters();
                sParam.Add("@CreatedBy", param.CreatedBy);
                var db = conn;
                var result = await db.QueryAsync<string>(
                     "JA_BulkConfirmProcessCodeDataP",
                     sParam,
                     commandType: CommandType.StoredProcedure);
                if (result.ToList().Count > 0)
                {
                    re = result.ToList().FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return re;
        }
        #endregion Upload
    }
}
