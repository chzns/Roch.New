using Roch.DomainModel;
using Roch.Framework;
using Roch.Testing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roch.Testing
{
    class Program
    {
        public static void Job()
        {
            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "Col1,Col2",
            //    table_name = "JobAssignmentMain",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job\"
            //    //output_root_dir = @"C:\Job\"

            //};


            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "Id, PeriodName, BU, TM1ProfitCenter, Program, CoCd, PlantSection, Process, LaborType, D01, D02, D03, D04, D05, D06, D07, D08, D09, D10, D11, D12, D13, D14, D15, D16, D17, D18, D19, D20, D21, D22, D23, D24, D25, D26, D27, D28, D29, D30, D31, D32, D33, D34, D35, D36, D37, D38, D39, D40, D41, D42, D43, D44, D45, D46, D47, D48, D49, D50, D51, D52, D53, D54, D55, D56, D57, D58, D59, D60, D61, D62, D63, D64, D65, D66, D67, D68, D69, D70, D71, D72, D73, D74, D75, D76, D77, D78, D79, D80, D81, D82, D83, D84, D85, D86, D87, D88, D89, D90, D91, Remark, OverallTrackingStatus, Demand, RMTNPI_UID",
            //    table_name = "RMTnpi",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job\"
            //};


            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "SiteConfiguration_UID, PersonnelArea, SizingWeek, PlantSection, CreatedBy, CreatedTime, Remark, RMTNPI_UID, log_UID, Action",
            //    table_name = "SiteConfiguration",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job1\"

            //};

            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "SiteConfiguration_UID, PersonnelArea, SizingWeek, PlantSection, CreatedBy, CreatedTime, Remark, RMTNPI_UID, log_UID, Action, Demand, CreatedName",
            //    table_name = "SiteConfigurationLog",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job1\"

            //};

            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "Data_UID,DataType,DataValue,DataLabel,CreatedBy,CreatedTime,Remark",
            //    table_name = "SetUpData",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job1\"

            //};

            InputData inputData = new InputData()
            {
                input_template_dir = @"C:\Code\Code\Roch.Testing\template",
                project_name = "JGPHR.JobAssignment",
                table_colunms = "ProcessCodeData_UID, SizingWeek, PersonnelArea, CreatedBy, CreatedName, CreatedTime, Building, SiteProcess, SingleMultiple, Line, Department, Workstation, ProcessDescription, StandardHeadcount, log_UID, Action",
                table_name = "ProcessCodeData",
                component_name= "uploadProcessCodeData",
                table_prefix = "JA",
                function_name= "ProcessCodeData",
                // output_root_dir = @"C:\JGP Division IT\Projects\JGPHR.JobAssignment\"
                output_root_dir = @"C:\Users\chenh60\Desktop\Job3\"
            };

            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "ProcessCodeSetUp_UID, Data_UID, SizingWeek, PersonnelArea, CreatedBy, CreatedTime, CreatedName, OrderIndex, log_UID, Action",
            //    table_name = "ProcessCodeSetUpLog",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job1\"

            //};

            //InputData inputData = new InputData()
            //{
            //    input_template_dir = @"C:\Code\Code\Roch.Testing\template",
            //    project_name = "JGPHR.JobAssignment",
            //    table_colunms = "ProcessCodeData_UID,SizingWeek,PersonnelArea,CreatedBy,CreatedName,CreatedTime,Building,SiteProcess,SingleMultiple,Line,Department,Workstation,ProcessDescription,StandardHeadcount",
            //    table_name = "ProcessCodeData",
            //    table_prefix = "JA",
            //    output_root_dir = @"C:\Users\chenh60\Desktop\Job1\"
            //};
            //inputData.output_root_dir = @"C:\Code\Code\Roch.Testing\output\";

            // 1.template_Repository_File
            inputData.input_template_filename = "template_Repository_File.txt";
            inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Repository\";
            inputData.output_template_filename = $"{inputData.table_name}" + @"\" + $"{inputData.table_name}Repo.cs";
            ReplaceTemplate(inputData);

            //2.template_Entities_File
            inputData.input_template_filename = "template_Entities_File.txt";
            inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Entity\";
            inputData.output_template_filename = $"{inputData.table_name}" + @"\" + $"{inputData.table_name}.cs";
            ReplaceTemplate(inputData);

            //3.template_Business_File
            inputData.input_template_filename = "template_Business_File.txt";
            inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Business\";
            inputData.output_template_filename = $"{inputData.table_name}" + @"\" + $"{inputData.table_name}.cs";
            ReplaceTemplate(inputData);

            //4.template_API_File
            inputData.input_template_filename = "template_API_File.txt";
            inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.API\";
            inputData.output_template_filename = $"{inputData.table_name}" + @"\" + $"{inputData.table_name}.cs";
            ReplaceTemplate(inputData);

            //6.Demo
            inputData.input_template_filename = "template_blank.txt";
            //inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Entity\Release Script\";
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename = $"Demo{inputData.table_name}.txt";
            ReplaceTemplate(inputData);

            //7.VUE.API.js
            inputData.input_template_filename = "template_VUE_API.txt";
            inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment\src\api\app\";
            inputData.output_template_filename = $"{inputData.table_name}Api.js";
            ReplaceTemplate(inputData);

            //

            //5. SQL
            inputData.input_template_filename = "template_blank.txt";
            //inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Entity\Release Script\";
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename = $"創建脚本{inputData.table_name}.sql";
            ReplaceSQL(inputData);



            //6.SingleFunction
            inputData.input_template_filename = "template_SingleFunction.txt";
            //inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Entity\Release Script\";
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename = $"普通函數{inputData.table_name}_SingleFunction.txt";
            ReplaceTemplate(inputData);


            //7.Vue Log文件
            inputData.input_template_filename = "template_log.txt";
            //inputData.output_template_dir = inputData.output_root_dir + @"JGPHR.JobAssignment.Entity\Release Script\";
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename = $"日志log{inputData.table_name}.txt";
            ReplaceTemplate(inputData);

            //8. Sigle get FunctionName
            inputData.input_template_filename = "template_GetFunction.txt";
            inputData.function_name = inputData.function_name;
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename = "通用Get" + inputData.function_name+ $".txt";
            ReplaceTemplate(inputData);

            //9. Download Function
            inputData.input_template_filename = "template_Download.txt";
            inputData.function_name = inputData.function_name;
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.output_template_filename ="下載Download"+ inputData.function_name + $".txt";
            ReplaceTemplate(inputData);

            //10 Upload Excel Function
            inputData.input_template_filename = "template_UploadVUE.txt";
            inputData.output_template_dir = @"C:\Users\chenh60\Desktop\";
            inputData.component_name = inputData.component_name;
            inputData.output_template_filename = "批量上传EXCEL文件Upload.txt";
            ReplaceTemplate(inputData);



        }
        public static void ReplaceTemplate(InputData inputData)
        {
            //inputData.table_colunms_list = inputData.table_colunms.Split(',').ToList();
            var temp = inputData.table_colunms.Split(',').ToList();
            inputData.table_colunms_list = temp.Select(m => m.ToString().TrimEnd().TrimStart()).ToList();
            //1.创建输出目录
            if (!string.IsNullOrEmpty(inputData.output_template_dir))
            {
                LocalFileHelper.CreateDirectory(inputData.output_template_dir + @"\" + inputData.table_name);
            }
            if (!string.IsNullOrEmpty(inputData.output_template_dir))
            {
                LocalFileHelper.CreateDirectory(inputData.output_template_dir + @"\" + inputData.table_name);
            }
            //2.创建输出文件
            if (!string.IsNullOrEmpty(inputData.output_template_dir) && !string.IsNullOrEmpty(inputData.output_template_filename))
            {
                LocalFileHelper.CreateFile(inputData.output_template_dir + @"\" + inputData.output_template_filename);
            }
            //3.读取模板
            var Template_File = LocalFileHelper.FileToString(inputData.input_template_dir + @"\" + inputData.input_template_filename, Encoding.UTF8);
            Template_File = Template_File.Replace("$table_name$", inputData.table_name);
            Template_File = Template_File.Replace("$project_name$", inputData.project_name);
            Template_File = Template_File.Replace("$getModel$", getModel(inputData.table_colunms_list));
            Template_File = Template_File.Replace("$table_prefix$", inputData.table_prefix);
            Template_File = Template_File.Replace("$table_name$", inputData.table_name);
            Template_File = Template_File.Replace("$GetParam$", GetParam(inputData.table_colunms_list));
            Template_File = Template_File.Replace("$GetBulkParam$", GetBulkParam(inputData.table_colunms_list));
            Template_File = Template_File.Replace("$TestListData$", TestListData(inputData.table_colunms_list, inputData.table_name));
            Template_File = Template_File.Replace("$TMBulk$", $"{inputData.table_prefix}_TM_{inputData.table_name}T");
            Template_File = Template_File.Replace("$InsProce$", $"{inputData.table_prefix}_Ins{inputData.table_name}P");
            Template_File = Template_File.Replace("$DelProce$", $"{inputData.table_prefix}_Del{inputData.table_name}P");
            Template_File = Template_File.Replace("$GetProce$", $"{inputData.table_prefix}_Get{inputData.table_name}P");
            Template_File = Template_File.Replace("$UpdProce$", $"{inputData.table_prefix}_Upd{inputData.table_name}P");
            Template_File = Template_File.Replace("$BulkProce$", $"{inputData.table_prefix}_Bulk{inputData.table_name}P");
            Template_File = Template_File.Replace("$BulkDelProce$", $"{inputData.table_prefix}_BulkDel{inputData.table_name}P");
            Template_File = Template_File.Replace("$BulkValidateProce$", $"{inputData.table_prefix}_BulkValidate{inputData.table_name}P");
            Template_File = Template_File.Replace("$BulkConfirmProce$", $"{inputData.table_prefix}_BulkConfirm{inputData.table_name}P");
            Template_File = Template_File.Replace("$Gettable_column$", Gettable_column(inputData.table_colunms_list));
            Template_File = Template_File.Replace("$get_dialog$", get_dialog(inputData.table_colunms_list));
            Template_File = Template_File.Replace("$Key$", inputData.table_colunms_list[0]);
            Template_File = Template_File.Replace("$getGridHeader$", getGridHeader(inputData.table_colunms_list, inputData.table_name));
            Template_File = Template_File.Replace("$zh_Json$", zh_Json(inputData.table_colunms_list, inputData.table_name));
            Template_File = Template_File.Replace("$dailog_addform$", dailog_addform(inputData.table_colunms_list, inputData.table_name));
            Template_File = Template_File.Replace("$function_name$", inputData.function_name);
            Template_File = Template_File.Replace("$component_name$", inputData.component_name);
            //4.保存文件
            LocalFileHelper.WriteText(inputData.output_template_dir + @"\" + inputData.output_template_filename, Template_File);
        }


        public static string dailog_addform(List<string> col_List, string tablename)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in col_List)
            {

                var Item = element.ToString().Trim();
                sb.AppendLine($"<el-col :span=\"12\">");
                sb.AppendLine($"              <el-form-item :label=\" $t('{tablename}Form.{Item}')\"");
                sb.AppendLine($"                            required");
                sb.AppendLine($"                            label-width=\"");
                sb.AppendLine($"                            180px\">");
                sb.AppendLine($"                <el-input v-model=\"{tablename}Form.{Item}\"");
                sb.AppendLine($"                          maxlength=\"50\"></el-input>");
                sb.AppendLine($"              </el-form-item>");
                sb.AppendLine($"  </el-col>");
            }
            return sb.ToString();
        }

        public static string zh_Json(List<string> col_List, string tablename)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{tablename}_Form:" + " {");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"    {Item}: '{Item}',");
            }
            sb.AppendLine("  },");
            return sb.ToString();

        }
        public static void ReplaceSQL(InputData inputData)
        {
            // 5.生成 SQL文件
            StringBuilder sb_sql = new StringBuilder();
            sb_sql.AppendLine(SQL_Create(inputData.table_colunms_list, inputData.table_name, inputData.table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Ins(inputData.table_colunms_list, inputData.table_name, inputData.table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Upd(inputData.table_colunms_list, inputData.table_name, inputData.table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Get(inputData.table_colunms_list, inputData.table_name, inputData.table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Del(inputData.table_colunms_list, inputData.table_name, inputData.table_prefix));
            LocalFileHelper.CreateDirectory(inputData.output_template_dir);
            LocalFileHelper.WriteText(inputData.output_template_dir + @"\" + $"{inputData.table_name}.sql", sb_sql.ToString());
        }

        public static List<ReplaceData> getReplaceDataList()
        {
            List<ReplaceData> replaceData = new List<ReplaceData>();
            replaceData.Add(new ReplaceData { before_data = "", after_data = "" });
            replaceData.Add(new ReplaceData { before_data = "", after_data = "" });
            replaceData.Add(new ReplaceData { before_data = "", after_data = "" });
            return replaceData;
        }

        static void Main()
        {
            Job();

        }
        public static void SmartReplace()
        {


        }

        public static string GetConfigureServices(string table_name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("请在Web中,增加一个Startup.cs");
            sb.AppendLine($"services.AddTransient<I{table_name}Mgr,{table_name}Mgr>();");
            sb.AppendLine($"services.AddTransient<I{table_name}Repo,{table_name}Repo>();");
            return sb.ToString();

        }
        // 范例
        public static string Method(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
            }
            return sb.ToString();
        }

        public static string SQL_Get(List<string> col_List, string table_name, string table_prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");



            sb.AppendLine($"Create PROCEDURE [dbo].[{table_prefix}_Get{table_name}P]");
            sb.AppendLine("	@page	INT = 1,");
            sb.AppendLine("	@limit	INT = 20,");
            sb.AppendLine("	@CreatedBy nvarchar(50) = null,");
            sb.AppendLine("	@SearchType nvarchar(50) = null");
            sb.AppendLine($"--@{table_name}Name	NVARCHAR(200) = NULL");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");

            sb.AppendLine($"if (@SearchType ='')");
            sb.AppendLine($"   begin");

            sb.AppendLine("	DECLARE @RecCount	INT = 0");
            sb.AppendLine("	SELECT COUNT(*) AS [Count]");
            sb.AppendLine($"	FROM {table_prefix}_{table_name}T");
            sb.AppendLine($"	--WHERE (@{table_name}Name IS NULL OR {table_name}Name LIKE '%' + @{table_name}Name + '%')");
            sb.AppendLine("	;");
            sb.AppendLine("	WITH cte (");
            sb.AppendLine("		[index],");
            sb.AppendLine(where4(col_List));
            sb.AppendLine("	)");
            sb.AppendLine("	AS (");
            sb.AppendLine("		SELECT ROW_NUMBER() OVER(ORDER BY getdate()) AS [index],");
            sb.AppendLine(where4(col_List));
            sb.AppendLine($"		FROM {table_prefix}_{table_name}T");
            sb.AppendLine($"		--WHERE (@{table_name}Name IS NULL OR {table_name}Name LIKE '%' + @{table_name}Name + '%')");
            sb.AppendLine("	) ");
            sb.AppendLine("	SELECT [index],");
            sb.AppendLine(where4(col_List));
            sb.AppendLine("	FROM cte");
            sb.AppendLine($"	ORDER BY GETDATE()");
            sb.AppendLine("	OFFSET @limit * (@page - 1) ROWS");
            sb.AppendLine("	FETCH NEXT @limit ROWS ONLY OPTION (RECOMPILE);");
            sb.AppendLine($"	end");

            sb.AppendLine($"	if (@SearchType ='log')");
            sb.AppendLine($"	begin");
            sb.AppendLine($"	   SELECT top 200 ROW_NUMBER() OVER(ORDER BY getdate()) AS [index] ,* from JA_SiteConfigurationLogT * from {table_prefix}_{table_name}T order by CreatedTime desc");
            sb.AppendLine($"	end");

            sb.AppendLine("END");
            return sb.ToString();
        }

        public static string TestListData(List<string> col_List, string table_name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                int count = 2;");
            sb.AppendLine($"               {table_name} model1 = new {table_name}();");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"                model1.{Item} = \"1\";");
            }

            sb.AppendLine($"                {table_name} model2 = new {table_name}();");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"                model2.{Item} = \"2\";");
            }
            sb.AppendLine($"                List<{table_name}> list = new List<{table_name}>();");
            sb.AppendLine("                list.Add(model1);");
            sb.AppendLine("                list.Add(model2);");
            sb.AppendLine($"                return new PaginatedResult<{table_name}>(list, count, param.Page, param.Limit);");
            return sb.ToString();
        }

        public static string get_dialog(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"<el-form-item :label=\"$t('app.{Item}')\" prop=\"{Item}\">");
                sb.AppendLine($"          <el-input v-model=\"temp.{Item}\"></el-input>");
                sb.AppendLine("        </el-form-item>");

            }
            return sb.ToString();
        }

        public static string Gettable_column(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"<el-table-column prop=\"{Item}\" :label=\"$t('{Item}')\" width=\"100\"></el-table-column>");
            }
            return sb.ToString();
        }

        public static string getModel(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();

                switch (Item)
                {
                    case "CreatedTime":
                        sb.AppendLine("[JsonConverter(typeof(SPPDateTimeConverter))]");
                        sb.AppendLine($"        public DateTime {Item}" + " { get; set; }");
                        break;
                    default:
                        sb.AppendLine($"        public string {Item}" + " { get; set; }");
                        break;
                }
            }
            return sb.ToString();

        }

        public static string GetParam(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"                sParam.Add(\"@{Item}\", param.{Item});");
            }


            return sb.ToString();
        }
        public static string GetBulkParam(List<string> col_List)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine($"                        bulkCopy.ColumnMappings.Add(\"{Item}\", \"{Item}\");");
            }
            return sb.ToString();
        }
        public static string SQL_Ins(List<string> col_List, string table_name, string table_prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Create PROCEDURE [dbo].[{table_prefix}_Ins{table_name}P]");

            sb.AppendLine(where6(col_List));
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("	--SET NOCOUNT ON;");
            sb.AppendLine($"	IF NOT EXISTS(SELECT TOP 1 1 FROM {table_prefix}_{table_name}T WHERE {where2(col_List)})");

            sb.AppendLine($"		INSERT INTO {table_prefix}_{table_name}T ({where4(col_List)})");
            sb.AppendLine($"		VALUES ({where3(col_List)})");
            //
            sb.AppendLine("	ELSE");
            sb.AppendLine("		RAISERROR('The mapping data already exist in the system',16,1)");
            sb.AppendLine("END");

            return sb.ToString();
        }
        public static string SQL_Update(List<string> col_List, string table_name, string table_prefix)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
        public static string SQL_Del(List<string> col_List, string table_name, string table_prefix)
        {
            var key = col_List[0].ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Create PROCEDURE [dbo].[{table_prefix}_Del{table_name}P]");
            sb.AppendLine($"	@{key} varchar(50)");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine($"	DELETE FROM {table_prefix}_{table_name}T ");
            sb.AppendLine($" where	{where8(col_List)}");
            sb.AppendLine("END");
            return sb.ToString();
        }
        public static string SQL_Upd(List<string> col_List, string table_name, string table_prefix)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Create PROCEDURE [dbo].[{table_prefix}_Upd{table_name}P]");
            sb.AppendLine(where6(col_List));
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("	--SET NOCOUNT ON;");
            sb.AppendLine($"	IF NOT EXISTS(SELECT TOP 1 1 FROM [{table_prefix}_{table_name}T] WHERE {where2(col_List)})");
            sb.AppendLine($"		UPDATE [{table_prefix}_{table_name}T]");
            sb.AppendLine("			SET ");
            sb.AppendLine($"				 {where7(col_List)}");
            sb.AppendLine($"		WHERE {where8(col_List)};");
            sb.AppendLine("	ELSE");
            sb.AppendLine("		RAISERROR('The mapping data already exist in the system',16,1)");
            sb.AppendLine("END");
            return sb.ToString();
        }
        public static string SQL_Create(List<string> col_List, string table_name, string table_prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE TABLE [dbo].[{table_prefix}_{table_name}T](");
            sb.AppendLine(where1(col_List));
            sb.AppendLine(") ON [PRIMARY]");
            return sb.ToString();
        }
        public static string where8(List<string> col_List)
        {
            //XXX_UID = @XXX_UID
            StringBuilder where = new StringBuilder();
            var Item_1 = col_List[0].ToString();
            where.Append($"	{Item_1} = @{Item_1}");
            return where.ToString();

        }
        public static string where7(List<string> col_List)
        {
            //XXX_UID = @XXX_UID AND  XXX_EN = @XXX_EN AND  XXX_ZH = @XXX_ZH AND  Hard_Block = @Hard_Block AND  Approval = @Approval AND  CreatedBy = @CreatedBy AND  CreatedTime = @CreatedTime AND  Remark = @Remark 
            StringBuilder where = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    where.Append($"	{Item_1} = @{Item_1},");
                }
                if (i == col_List.Count - 1)
                {
                    where.Append($"	{Item_1} = @{Item_1} ");
                }
            }
            return where.ToString();
        }
        public static string where6(List<string> col_List)
        {
            //@Col NVARCHAR(10) = NULL,

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    sb.AppendLine($"@{Item_1} [nvarchar](50)= NULL,");
                }
                if (i == col_List.Count - 1)
                {
                    sb.AppendLine($"@{Item_1} [nvarchar](50)=NULL");
                }
            }

            return sb.ToString();
        }
        public static string where1(List<string> col_List)
        {
            //@Id	INT,
            //@EmployeeId INT,
            //@PriorityName	VARCHAR(50),
            //@Seq INT,
            //@Type VARCHAR(50)
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    sb.AppendLine($"	[{Item_1}] [nvarchar](50) NULL,");
                }
                if (i == col_List.Count - 1)
                {
                    sb.AppendLine($"	[{Item_1}] [nvarchar](50) NULL");
                }
            }

            return sb.ToString();
        }
        public static string where2(List<string> col_List)
        {
            //XXX_UID = @XXX_UID AND  XXX_EN = @XXX_EN AND  XXX_ZH = @XXX_ZH AND  Hard_Block = @Hard_Block AND  Approval = @Approval AND  CreatedBy = @CreatedBy AND  CreatedTime = @CreatedTime AND  Remark = @Remark 
            StringBuilder where = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    where.Append($"	{Item_1} = @{Item_1} AND");
                }
                if (i == col_List.Count - 1)
                {
                    where.Append($"	{Item_1} = @{Item_1} ");
                }
            }
            return where.ToString();
        }
        public static string where3(List<string> col_List)
        {
            StringBuilder where = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    where.Append($"	@{Item_1},");
                }
                if (i == col_List.Count - 1)
                {
                    where.Append($"	@{Item_1}");
                }
            }
            return where.ToString();
        }
        public static string where4(List<string> col_List)
        {
            StringBuilder where = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    where.Append($"	{Item_1},");
                }
                if (i == col_List.Count - 1)
                {
                    where.Append($"	{Item_1}");
                }
            }
            return where.ToString();
        }
        public static string where5(List<string> col_List)
        {
            StringBuilder where = new StringBuilder();
            for (int i = 0; i < col_List.Count; i++)
            {
                var Item_1 = col_List[i].ToString();
                if (i < col_List.Count - 1)
                {
                    where.Append($"[{Item_1}]  [nvarchar](50) NULL,");
                }
                if (i == col_List.Count - 1)
                {
                    where.Append($"[{Item_1}]  [nvarchar](50) NULL");
                }
            }
            return where.ToString();
        }
        public static string getGridHeader(List<string> col_List, string tableName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"        var columns = [");
            sb.AppendLine("         { headerName: '', checkboxSelection: true, headerCheckboxSelection: true, width: 30, 'pinned': 'left' },");
            sb.AppendLine("{");
            sb.AppendLine($"            headerName: this.$t('Index'),");
            sb.AppendLine($"            field: 'index'");
            sb.AppendLine("          },");
            foreach (var element in col_List)
            {
                var Item = element.ToString().Trim();
                sb.AppendLine("          {");
                sb.AppendLine($"            headerName: this.$t('{tableName}_Form.{Item}'),");
                sb.AppendLine($"            field: '{Item}'");
                sb.AppendLine("          },");
            }
            sb.AppendLine($"        ]");
            return sb.ToString();
        }
        static void Main1()
        {

            //必填选项
            List<string> require_list = new List<string>();
            List<string> col_List = new List<string>();
            string project_name = "";//项目名
            string table_prefix = "";//表名前缀
            string table_name = "";//表名
            string test_data1 = "";//字段列
            string MainKey = "";//主键
            string AddForm = "";//Form表单
            string List = "";//List数据参数
            string ID = "";//序号
            string file_name = "";//二级文件名
            bool Is_show_text = false;
            bool Is_Copyto_prod = false;
            //数据源1

            if (true)
            {
                project_name = "JGPHR.JobAssignment";
                file_name = "Ceshi";
                table_prefix = "JA";
                table_name = "Ceshi";
                test_data1 = "JobAsignment_UID,PersonnelArea,CreatedBy,CreatedTime,Remark";
                MainKey = "Id"; //主键
                AddForm = "JobAsignment_AddForm";  //Form表单
                List = "JobAsignment_List";//List数据参数
                ID = "Id";//序号
                          //require_list.Add("XXX_EN");//必填放呆1
                          //require_list.Add("XXX_ZH");//必填放呆2
            }

            //
            col_List = test_data1.Split(',').ToList();

            // 1.創建模板位置路徑
            var template_dir = @"C:\Users\chenh60\mytemplate\Vue\CodeTemplate\JobAsignment\";
            var template_VUE_File = template_dir + @"\" + "template_VUE_File.txt";
            var template_Web_File = template_dir + @"\" + "template_Web_File.txt";
            var template_Entities_File = template_dir + @"\" + "template_Entities_File.txt";
            var template_API_File = template_dir + @"\" + "template_API_File.txt";
            var template_Business_File = template_dir + @"\" + "template_Business_File.txt";
            var template_Repository_File = template_dir + @"\" + "template_Repository_File.txt";
            var template_Upload_File = template_dir + @"\" + "template_Upload_File.txt";
            var template_GridHearder = template_dir + @"\" + "template_GridHeader.txt";


            // 2.生成文件位置
            var dir = @"C:\Job2\";
            //var dir = @"C:\Users\chenh60\Desktop\Job2\";
            LocalFileHelper.CreateDirectory(dir);

            //2级目录 
            var VUE = dir + $@"\{project_name}.Web\src\views\app\Administration";
            var WEB = dir + $@"\{project_name}.Web\src\api\app";
            var Entities = dir + $@"\{project_name}.Entity\{file_name}";
            var API = dir + $@"\{project_name}.API\Controllers\{file_name}";
            var Business = dir + $@"\{project_name}.Business\{file_name}";
            var Repository = dir + $@"\{project_name}.Repository\{file_name}";
            var Settings = dir + "\\Settings"; //自定义的文件夹
            var SqlFiles = dir + $@"\{project_name}.Entity\" + @"\Release Script";



            //3.創建目錄
            LocalFileHelper.CreateDirectory(VUE);
            LocalFileHelper.CreateDirectory(WEB);
            LocalFileHelper.CreateDirectory(Entities);
            LocalFileHelper.CreateDirectory(API);
            LocalFileHelper.CreateDirectory(Business);
            LocalFileHelper.CreateDirectory(Repository);
            LocalFileHelper.CreateDirectory(Settings); //
            LocalFileHelper.CreateDirectory(SqlFiles); //



            //3项目级子文件
            var VUE_File = VUE + @"\" + $"{table_name}.vue";
            var Web_File = WEB + @"\" + $"{table_name}Api.js";
            var Entities_File = Entities + @"\" + $"{table_name}.cs";
            var API_File = API + @"\" + $"{table_name}Controller.cs";
            var Business_File = Business + @"\" + $"{table_name}Mgr.cs";
            var Repository_File = Repository + @"\" + $"{table_name}Repo.cs";
            //4.自定义子文件  
            var Upload_File = SqlFiles + @"\" + "Upload_File.txt";
            var SQL_File = SqlFiles + @"\" + $"{table_name}.sql";
            var GridHearder_File = SqlFiles + @"\" + "getGridHeader.txt";



            //创建项目文件
            LocalFileHelper.CreateFile(Web_File);
            LocalFileHelper.CreateFile(Entities_File);
            LocalFileHelper.CreateFile(API_File);
            LocalFileHelper.CreateFile(Business_File);
            LocalFileHelper.CreateFile(Repository_File);
            //創建自定義文件
            LocalFileHelper.CreateFile(Upload_File);
            LocalFileHelper.CreateFile(SQL_File);
            LocalFileHelper.CreateFile(GridHearder_File);

            //替換模板
            var Content_Entities_File = LocalFileHelper.FileToString(template_Entities_File, Encoding.UTF8);
            Content_Entities_File = Content_Entities_File.Replace("$table_name$", table_name);
            Content_Entities_File = Content_Entities_File.Replace("$project_name$", project_name);
            Content_Entities_File = Content_Entities_File.Replace("$getModel$", getModel(col_List));
            LocalFileHelper.WriteText(Entities_File, Content_Entities_File);


            var Content_Repository_File = LocalFileHelper.FileToString(template_Repository_File, Encoding.UTF8);
            Content_Repository_File = Content_Repository_File.Replace("$table_prefix$", table_prefix);
            Content_Repository_File = Content_Repository_File.Replace("$project_name$", project_name);
            Content_Repository_File = Content_Repository_File.Replace("$table_name$", table_name);
            Content_Repository_File = Content_Repository_File.Replace("$GetParam$", GetParam(col_List));
            Content_Repository_File = Content_Repository_File.Replace("$GetBulkParam$", GetBulkParam(col_List));
            Content_Repository_File = Content_Repository_File.Replace("$TestListData$", TestListData(col_List, table_name));
            Content_Repository_File = Content_Repository_File.Replace("$TMBulk$", $"{table_prefix}_TM_{table_name}_T");
            Content_Repository_File = Content_Repository_File.Replace("$InsProce$", $"{table_prefix}_Ins{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$DelProce$", $"{table_prefix}_Del{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$GetProce$", $"{table_prefix}_Get{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$UpdProce$", $"{table_prefix}_Upd{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$BulkProce$", $"{table_prefix}_Bulk{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$BulkDelProce$", $"{table_prefix}_BulkDel{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$BulkValidateProce$", $"{table_prefix}_BulkValidate{table_name}P");
            Content_Repository_File = Content_Repository_File.Replace("$BulkConfirmProce$", $"{table_prefix}_BulkConfirm{table_name}P");


            Content_Repository_File = Content_Repository_File.Replace("$Key$", col_List[0]);
            LocalFileHelper.WriteText(Repository_File, Content_Repository_File);



            var Conent_Business_File = LocalFileHelper.FileToString(template_Business_File, Encoding.UTF8);
            Conent_Business_File = Conent_Business_File.Replace("$project_name$", project_name);
            Conent_Business_File = Conent_Business_File.Replace("$table_name$", table_name);
            LocalFileHelper.WriteText(Business_File, Conent_Business_File);


            var Content_API_File = LocalFileHelper.FileToString(template_API_File, Encoding.UTF8);
            Content_API_File = Content_API_File.Replace("$project_name$", project_name);
            Content_API_File = Content_API_File.Replace("$table_name$", table_name);
            LocalFileHelper.WriteText(API_File, Content_API_File);


            var Content_Web_File = LocalFileHelper.FileToString(template_Web_File, Encoding.UTF8);
            Content_Web_File = Content_Web_File.Replace("$project_name$", project_name);
            Content_Web_File = Content_Web_File.Replace("$table_name$", table_name);
            LocalFileHelper.WriteText(Web_File, Content_Web_File);

            var Content_VUE_File = LocalFileHelper.FileToString(template_VUE_File, Encoding.UTF8);
            Content_VUE_File = Content_VUE_File.Replace("$project_name$", project_name);
            Content_VUE_File = Content_VUE_File.Replace("$table_name$", table_name);
            Content_VUE_File = Content_VUE_File.Replace("$Gettable_column$", Gettable_column(col_List));
            Content_VUE_File = Content_VUE_File.Replace("$get_dialog$", get_dialog(col_List));
            LocalFileHelper.WriteText(VUE_File, Content_VUE_File);

            var Content_Upload_File = LocalFileHelper.FileToString(template_Upload_File, Encoding.UTF8);
            LocalFileHelper.WriteText(Upload_File, Content_Upload_File);

            //生成 SQL 文件
            StringBuilder sb_sql = new StringBuilder();
            sb_sql.AppendLine(SQL_Create(col_List, table_name, table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Ins(col_List, table_name, table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Upd(col_List, table_name, table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Get(col_List, table_name, table_prefix));
            sb_sql.AppendLine("go");
            sb_sql.AppendLine(SQL_Del(col_List, table_name, table_prefix));
            LocalFileHelper.WriteText(SQL_File, sb_sql.ToString());

            // 單一替換
            var template_SearchEmployeee = template_dir + @"\" + "template_SearchEmployeee.txt"; // 1.快速增加一个自定义模板
            var SearchEmployeee = Settings + @"\" + "SearchEmployeee.txt"; //保存路徑
            var wiriteFile = LocalFileHelper.FileToString(template_SearchEmployeee, Encoding.UTF8);


            var model_main = "BlackList_AddForm";
            var model_id = "Site_HRM_Invalid";
            var model_email = "Site_HRM_Invalid_Email";

            var compent = model_id + "_search";
            var change_Method = "on" + compent + "Changed";
            wiriteFile = wiriteFile.Replace("$model_main$", model_main);
            wiriteFile = wiriteFile.Replace("$compent$", compent);
            wiriteFile = wiriteFile.Replace("$change_Method$", change_Method);
            wiriteFile = wiriteFile.Replace("$model_id$", model_id);
            wiriteFile = wiriteFile.Replace("$model_email$", model_email);




            // 循環替換
            //var col_str ="HRMorFM, HRMorFM_Email, OPM, OPM_Email, FunctionalVP, FunctionalVP_Email, TA_Director, TA_Director_Email, Site_HRM_Invalid, Site_HRM_Invalid_Email, Comment";
            //		var col_str ="HiringType_UID,Probation_UID,JobProfileID,JobGrade";
            //	col_str =col_str.Replace(" ","");
            //	var for_List =col_str.Split(',').ToList();
            //	foreach (var element in for_List)
            //   {
            //  var Item=element.ToString().Trim();
            //  $" @{Item} nvarchar(50) NULL,".Dump();
            //  }
            ////  
            ////  "----".Dump();
            //		foreach (var element in for_List)
            //   {
            //  var Item=element.ToString().Trim();
            // $"sParam.Add(\"{Item}\", request.{Item});".Dump();
            //  }
            ////    "----".Dump();
            //  		foreach (var element in for_List)
            //   {
            //  var Item=element.ToString().Trim();
            // $"update #tempSingle set {Item} =@{Item}".Dump();
            //  }
            //	


            //	  		foreach (var element in for_List)
            //   {
            //  var Item=element.ToString().Trim();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"if (this.$refs.{element}_search !== undefined) " +"{");
            //sb.AppendLine($"            this.$refs.{element}_search.employeeSelected = this.BlackList_AddForm.{element}");
            //sb.AppendLine("          }");
            //sb.ToString().Dump();
            //  }

            // ConfigureServices Start Up 新增方法
            //GetConfigureServices(table_name).Dump();
            //SQL_Create(col_List,table_name,table_prefix).Dump();
            //"go".Dump();
            //SQL_Ins(col_List,table_name,table_prefix).Dump();
            //"go".Dump();
            //SQL_Upd(col_List,table_name,table_prefix).Dump();
            //"go".Dump();
            //SQL_Get(col_List,table_name,table_prefix).Dump();
            //"go".Dump();
            //SQL_Del(col_List,table_name,table_prefix).Dump();

        }

























        //LocalFileHelper
        public static class LocalFileHelper
        {

            #region 检测指定目录是否存在
            /// <summary>  
            /// 检测指定目录是否存在  
            /// </summary>  
            /// <param name="directoryPath">目录的绝对路径</param>          
            public static bool IsExistDirectory(string directoryPath)
            {
                return Directory.Exists(directoryPath);
            }
            #endregion

            #region 检测指定文件是否存在
            /// <summary>  
            /// 检测指定文件是否存在,如果存在则返回true。  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static bool IsExistFile(string filePath)
            {
                return File.Exists(filePath);
            }
            #endregion

            #region 检测指定目录是否为空
            /// <summary>  
            /// 检测指定目录是否为空  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>          
            public static bool IsEmptyDirectory(string directoryPath)
            {
                try
                {
                    //判断是否存在文件  
                    string[] fileNames = GetFileNames(directoryPath);
                    if (fileNames.Length > 0)
                    {
                        return false;
                    }

                    //判断是否存在文件夹  
                    string[] directoryNames = GetDirectories(directoryPath);
                    return directoryNames.Length <= 0;
                }
                catch
                {
                    return false;
                }
            }
            #endregion

            #region 检测指定目录中是否存在指定的文件
            /// <summary>  
            /// 检测指定目录中是否存在指定的文件,若要搜索子目录请使用重载方法.  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
            /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>          
            public static bool Contains(string directoryPath, string searchPattern)
            {
                try
                {
                    //获取指定的文件列表  
                    string[] fileNames = GetFileNames(directoryPath, searchPattern, false);

                    //判断指定文件是否存在  
                    return fileNames.Length != 0;
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>  
            /// 检测指定目录中是否存在指定的文件  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
            /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>   
            /// <param name="isSearchChild">是否搜索子目录</param>  
            public static bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
            {
                try
                {
                    //获取指定的文件列表  
                    string[] fileNames = GetFileNames(directoryPath, searchPattern, true);

                    //判断指定文件是否存在  
                    return fileNames.Length != 0;
                }
                catch
                {
                    return false;
                }
            }
            #endregion

            #region 创建一个目录
            /// <summary>  
            /// 创建一个目录  
            /// </summary>  
            /// <param name="directoryPath">目录的绝对路径</param>  
            public static void CreateDirectory(string directoryPath)
            {
                //如果目录不存在则创建该目录  
                if (!IsExistDirectory(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            #endregion

            #region 创建一个文件
            /// <summary>  
            /// 创建一个文件。  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            public static bool CreateFile(string filePath)
            {
                try
                {
                    //如果文件不存在则创建该文件  
                    if (!IsExistFile(filePath))
                    {
                        //创建一个FileInfo对象  
                        FileInfo file = new FileInfo(filePath);
                        //创建文件  
                        FileStream fs = file.Create();
                        //关闭文件流  
                        fs.Close();
                    }
                }
                catch
                {
                    return false;
                }

                return true;
            }

            /// <summary>  
            /// 创建一个文件,并将字节流写入文件。  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            /// <param name="buffer">二进制流数据</param>  
            public static bool CreateFile(string filePath, byte[] buffer)
            {
                try
                {
                    //如果文件不存在则创建该文件  
                    if (!IsExistFile(filePath))
                    {
                        //创建一个FileInfo对象  
                        FileInfo file = new FileInfo(filePath);

                        //创建文件  
                        FileStream fs = file.Create();

                        //写入二进制流  
                        fs.Write(buffer, 0, buffer.Length);

                        //关闭文件流  
                        fs.Close();
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }
            #endregion

            #region 获取文本文件的行数
            /// <summary>  
            /// 获取文本文件的行数  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static int GetLineCount(string filePath)
            {
                //将文本文件的各行读到一个字符串数组中  
                string[] rows = File.ReadAllLines(filePath);

                //返回行数  
                return rows.Length;
            }
            #endregion

            #region 获取一个文件的长度
            /// <summary>  
            /// 获取一个文件的长度,单位为Byte  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static int GetFileSize(string filePath)
            {
                //创建一个文件对象  
                FileInfo fi = new FileInfo(filePath);

                //获取文件的大小  
                return (int)fi.Length;
            }

            /// <summary>  
            /// 获取一个文件的长度,单位为KB  
            /// </summary>  
            /// <param name="filePath">文件的路径</param>          
            public static double GetFileSizeByKB(string filePath)
            {
                //创建一个文件对象  
                FileInfo fi = new FileInfo(filePath);
                long size = fi.Length / 1024;
                //获取文件的大小  
                return double.Parse(size.ToString());
            }

            /// <summary>  
            /// 获取一个文件的长度,单位为MB  
            /// </summary>  
            /// <param name="filePath">文件的路径</param>          
            public static double GetFileSizeByMB(string filePath)
            {
                //创建一个文件对象  
                FileInfo fi = new FileInfo(filePath);
                long size = fi.Length / 1024 / 1024;
                //获取文件的大小  
                return double.Parse(size.ToString());
            }
            #endregion

            #region 获取指定目录中的文件列表
            /// <summary>  
            /// 获取指定目录中所有文件列表  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>          
            public static string[] GetFileNames(string directoryPath)
            {
                //如果目录不存在，则抛出异常  
                if (!IsExistDirectory(directoryPath))
                {
                    throw new FileNotFoundException();
                }

                //获取文件列表  
                return Directory.GetFiles(directoryPath);
            }

            /// <summary>  
            /// 获取指定目录及子目录中所有文件列表  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
            /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
            /// <param name="isSearchChild">是否搜索子目录</param>  
            public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
            {
                //如果目录不存在，则抛出异常  
                if (!IsExistDirectory(directoryPath))
                {
                    throw new FileNotFoundException();
                }

                try
                {
                    return Directory.GetFiles(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                }
                catch
                {
                    return null;
                }
            }
            #endregion

            #region 获取指定目录中的子目录列表
            /// <summary>  
            /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>          
            public static string[] GetDirectories(string directoryPath)
            {
                try
                {
                    return Directory.GetDirectories(directoryPath);
                }
                catch
                {
                    return null;
                }
            }

            /// <summary>  
            /// 获取指定目录及子目录中所有子目录列表  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
            /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
            /// <param name="isSearchChild">是否搜索子目录</param>  
            public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
            {
                try
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                }
                catch
                {
                    throw null;
                }
            }
            #endregion

            #region 向文本文件写入内容
            /// <summary>  
            /// 向文本文件中写入内容  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            /// <param name="content">写入的内容</param>          
            public static void WriteText(string filePath, string content)
            {
                //向文件写入内容  
                File.WriteAllText(filePath, content);
            }
            #endregion

            #region 向文本文件的尾部追加内容
            /// <summary>  
            /// 向文本文件的尾部追加内容  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            /// <param name="content">写入的内容</param>  
            public static void AppendText(string filePath, string content)
            {
                File.AppendAllText(filePath, content);
            }
            #endregion

            #region 将现有文件的内容复制到新文件中
            /// <summary>  
            /// 将源文件的内容复制到目标文件中  
            /// </summary>  
            /// <param name="sourceFilePath">源文件的绝对路径</param>  
            /// <param name="destFilePath">目标文件的绝对路径</param>  
            public static void Copy(string sourceFilePath, string destFilePath)
            {
                File.Copy(sourceFilePath, destFilePath, true);
            }
            #endregion

            #region 将文件移动到指定目录
            /// <summary>  
            /// 将文件移动到指定目录  
            /// </summary>  
            /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>  
            /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>  
            public static bool Move(string sourceFilePath, string descDirectoryPath)
            {

                bool bo = false;
                //获取源文件的名称  
                string sourceFileName = GetFileName(sourceFilePath);

                if (IsExistDirectory(descDirectoryPath))
                {
                    //如果目标中存在同名文件,则删除  
                    if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                    {
                        DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                    }
                    //将文件移动到指定目录  
                    File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
                    bo = true;
                }
                return bo;
            }
            #endregion

            #region 将流读取到缓冲区中
            /// <summary>  
            /// 将流读取到缓冲区中  
            /// </summary>  
            /// <param name="stream">原始流</param>  
            public static byte[] StreamToBytes(Stream stream)
            {
                try
                {
                    //创建缓冲区  
                    byte[] buffer = new byte[stream.Length];

                    //读取流  
                    stream.Read(buffer, 0, int.Parse(stream.Length.ToString()));

                    //返回流  
                    return buffer;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    //关闭流  
                    stream.Close();
                }
            }
            #endregion

            #region 将文件读取到缓冲区中
            /// <summary>  
            /// 将文件读取到缓冲区中  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            public static byte[] FileToBytes(string filePath)
            {
                //获取文件的大小   
                int fileSize = GetFileSize(filePath);

                //创建一个临时缓冲区  
                byte[] buffer = new byte[fileSize];

                //创建一个文件流  
                FileInfo fi = new FileInfo(filePath);
                FileStream fs = fi.Open(FileMode.Open);

                try
                {
                    //将文件流读入缓冲区  
                    fs.Read(buffer, 0, fileSize);

                    return buffer;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    //关闭文件流  
                    fs.Close();
                }
            }
            #endregion

            #region 将文件读取到字符串中
            /// <summary>  
            /// 将文件读取到字符串中  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            public static string FileToString(string filePath)
            {
                return FileToString(filePath, Encoding.Default);
            }
            /// <summary>  
            /// 将文件读取到字符串中  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            /// <param name="encoding">字符编码</param>  
            public static string FileToString(string filePath, Encoding encoding)
            {
                //创建流读取器  
                StreamReader reader = new StreamReader(filePath, encoding);
                try
                {
                    //读取流  
                    return reader.ReadToEnd();
                }
                catch
                {
                    return string.Empty;
                }
                finally
                {
                    //关闭流读取器  
                    reader.Close();
                }
            }
            #endregion

            #region 从文件的绝对路径中获取文件名( 包含扩展名 )
            /// <summary>  
            /// 从文件的绝对路径中获取文件名( 包含扩展名 )  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static string GetFileName(string filePath)
            {
                //获取文件的名称  
                FileInfo fi = new FileInfo(filePath);
                return fi.Name;
            }
            #endregion

            #region 从文件的绝对路径中获取文件名( 不包含扩展名 )
            /// <summary>  
            /// 从文件的绝对路径中获取文件名( 不包含扩展名 )  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static string GetFileNameNoExtension(string filePath)
            {
                //获取文件的名称  
                FileInfo fi = new FileInfo(filePath);
                return fi.Name.Split('.')[0];
            }
            #endregion

            #region 从文件的绝对路径中获取扩展名
            /// <summary>  
            /// 从文件的绝对路径中获取扩展名  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>          
            public static string GetExtension(string filePath)
            {
                //获取文件的名称  
                FileInfo fi = new FileInfo(filePath);
                return fi.Extension;
            }
            #endregion

            #region 清空指定目录
            /// <summary>  
            /// 清空指定目录下所有文件及子目录,但该目录依然保存.  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            public static void ClearDirectory(string directoryPath)
            {
                if (IsExistDirectory(directoryPath))
                {
                    //删除目录中所有的文件  
                    string[] fileNames = GetFileNames(directoryPath);
                    foreach (string t in fileNames)
                    {
                        DeleteFile(t);
                    }

                    //删除目录中所有的子目录  
                    string[] directoryNames = GetDirectories(directoryPath);
                    foreach (string t in directoryNames)
                    {
                        DeleteDirectory(t);
                    }
                }
            }
            #endregion

            #region 清空文件内容
            /// <summary>  
            /// 清空文件内容  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            public static void ClearFile(string filePath)
            {
                //删除文件  
                File.Delete(filePath);

                //重新创建该文件  
                CreateFile(filePath);
            }
            #endregion

            #region 删除指定文件
            /// <summary>  
            /// 删除指定文件  
            /// </summary>  
            /// <param name="filePath">文件的绝对路径</param>  
            public static bool DeleteFile(string filePath)
            {
                bool bo = true;
                if (IsExistFile(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch
                    {

                        bo = false;
                    }

                }
                return bo;
            }
            #endregion

            #region 删除指定目录
            /// <summary>  
            /// 删除指定目录及其所有子目录  
            /// </summary>  
            /// <param name="directoryPath">指定目录的绝对路径</param>  
            public static void DeleteDirectory(string directoryPath)
            {
                if (IsExistDirectory(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
            }
            #endregion

            #region 记录错误日志到文件方法
            /// <summary>  
            /// 记录错误日志到文件方法  
            /// </summary>  
            /// <param name="exMessage"></param>  
            /// <param name="exMethod"></param>  
            /// <param name="userID"></param>  
            //public static void ErrorLog(string exMessage, string exMethod, int userID)
            //{
            //    try
            //    {
            //        string errVir = "/Log/Error/" + DateTime.Now.ToShortDateString() + ".txt";
            //        string errPath = System.Web.HttpContext.Current.Server.MapPath(errVir);
            //        File.AppendAllText(errPath,
            //                           "{userID:" + userID + ",exMedthod:" + exMethod + ",exMessage:" + exMessage + "}");
            //    }
            //    catch
            //    {

            //    }
            //}
            #endregion

            #region 输出调试日志
            /// <summary>  
            /// 输出调试日志  
            /// </summary>  
            /// <param name="factValue">实际值</param>   
            /// <param name="expectValue">预期值</param>  
            //public static void OutDebugLog(object factValue, object expectValue = null)
            //{
            //    string errPath = System.Web.HttpContext.Current.Server.MapPath(string.Format("/Log/Debug/{0}.html", DateTime.Now.ToShortDateString()));
            //    if (!Equals(expectValue, null))
            //        File.AppendAllLines(errPath,
            //                           new[]{string.Format(  
            //                               "【{0}】[{3}] 实际值:<span style='color:blue;'>{1}</span> 预期值: <span style='color:gray;'>{2}</span><br/>",  
            //                               DateTime.Now.ToShortTimeString()  
            //                               , factValue, expectValue, Equals(expectValue, factValue)  
            //                                   ? "<span style='color:green;'>成功</span>"  
            //                                   : "<span style='color:red;'>失败</span>")});
            //    else
            //        File.AppendAllLines(errPath, new[]{  
            //                       string.Format(  
            //                           "【{0}】[{3}] 实际值:<span style='color:blue;'>{1}</span> 预期值: <span style='color:gray;'>{2}</span><br/>",  
            //                           DateTime.Now.ToShortTimeString()  
            //                           , factValue, "空", "<span style='color:green;'>成功</span>")});
            //}
            #endregion

            #region First Character To Upper
            public static string FirstCharToUpper(string input)
            {
                if (String.IsNullOrEmpty(input))
                    throw new ArgumentException("ARGH!");
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            #endregion

            public static void WriteSuccess_Log(string message)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Success_Log.txt";
                CreateFile(path);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + message);
                }

            }

            public static void WriteError_Log(string message)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Fail_Log.txt";
                CreateFile(path);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + message);
                }
            }
        }



    }


}
