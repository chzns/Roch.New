using JGPHR.JobAssignment.Entities;
using System.Data;
using System.Threading.Tasks;
using JGPHR.JobAssignment.Repository;
using JGPHR.JobAssignment.Entity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace JGPHR.JobAssignment.Business
{
    public class ProcessCodeDataMgr
    {
        ProcessCodeDataRepo _ProcessCodeDataRepo;

        public ProcessCodeDataMgr(IOptions<AppSettings> appSettings)
        {
            _ProcessCodeDataRepo = new ProcessCodeDataRepo(appSettings);
        }
       
        #region CURD
        public async Task<string> InsProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.InsProcessCodeData(param);
        }

        public async Task<int> DelProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.DelProcessCodeData(param);
        }

        public async Task<ProcessCodeDataMainData> GetProcessCodeDataMain(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.GetProcessCodeDataMain(param);
        }

        public async Task<List<ProcessCodeData>> GetProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.GetProcessCodeData(param);
        }

        public async Task<int> UpdProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.UpdProcessCodeData(param);
        }

       public async Task<string> UnintTest(ProcessCodeDataParam param)
        {
            return await  _ProcessCodeDataRepo.UnintTest(param);
        }
       #endregion CURD


       #region Upload
        public async Task<bool> BulkProcessCodeData (DataTable dt)
        {
            return await _ProcessCodeDataRepo.BulkProcessCodeData(dt);
        }

        public async Task<bool> BulkDelProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.BulkDelProcessCodeData(param);
        }

        public async Task<int> BulkValidProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.BulkValidProcessCodeData(param);
        }

        public async Task<string> BulkConfirmProcessCodeData(ProcessCodeDataParam param)
        {
            return await _ProcessCodeDataRepo.BulkConfirmProcessCodeData(param);
        }
        #endregion
    }
}
