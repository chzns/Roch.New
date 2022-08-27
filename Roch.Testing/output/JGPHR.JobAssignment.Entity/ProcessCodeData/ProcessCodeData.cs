using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JGPHR.JobAssignment.Entities
{
    public class ProcessCodeDataParam: Page
    {
        [FromHeader(Name = "Pagination-Page")]
        public string PaginationPage { get; set; }

        [FromHeader(Name = "Pagination-Limit")]
        public string PaginationLimit { get; set; }
        [FromHeader(Name = "EmployeeId")]
        public string EmployeeId
        {
            get;
            set;
        }

        public int Page
        {
            get
            {
                int.TryParse(PaginationPage, out var result);
                return result;
            }
        }

        public int Limit
        {
            get
            {
                int.TryParse(PaginationLimit, out var result);
                return result;
            }
        }

        
        public string ProcessCodeData_UID { get; set; }
        public string SizingWeek { get; set; }
        public string PersonnelArea { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string CreatedTime { get; set; }
        public string Building { get; set; }
        public string SiteProcess { get; set; }
        public string SingleMultiple { get; set; }
        public string Line { get; set; }
        public string Department { get; set; }
        public string Workstation { get; set; }
        public string ProcessDescription { get; set; }
        public string StandardHeadcount { get; set; }

       public List<string> UploadProcessCodeData  { get; set; }
    }
    public class ProcessCodeData
    {
        public int index{ get;set;}
         
        public string ProcessCodeData_UID { get; set; }
        public string SizingWeek { get; set; }
        public string PersonnelArea { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string CreatedTime { get; set; }
        public string Building { get; set; }
        public string SiteProcess { get; set; }
        public string SingleMultiple { get; set; }
        public string Line { get; set; }
        public string Department { get; set; }
        public string Workstation { get; set; }
        public string ProcessDescription { get; set; }
        public string StandardHeadcount { get; set; }

    }

     public class ProcessCodeDataMainData
    {
        public int total { get; set; }
        public List<ProcessCodeData> data { get; set; }
    }

    public class UploadProcessCodeData
    {
        public string TM_UID { get; set; }
         
        public string ProcessCodeData_UID { get; set; }
        public string SizingWeek { get; set; }
        public string PersonnelArea { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string CreatedTime { get; set; }
        public string Building { get; set; }
        public string SiteProcess { get; set; }
        public string SingleMultiple { get; set; }
        public string Line { get; set; }
        public string Department { get; set; }
        public string Workstation { get; set; }
        public string ProcessDescription { get; set; }
        public string StandardHeadcount { get; set; }

    }
}
