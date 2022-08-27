using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roch.DomainModel
{
   public class InputData
    {

        public string input_template_dir { get; set; }
        public string input_template_filename { get; set; }

        public string output_root_dir { get; set; }
        public string output_template_dir { get; set; }
        public string output_template_filename { get; set; }
        public string project_name { get; set; }
        //public string file_name { get; set; }
        public string table_prefix { get; set; }
        public string table_name { get; set; }
        public string table_colunms { get; set; }

        public string function_name { get; set; }
        public List<string> table_colunms_list { get; set; }

        public string component_name { get; set; }
    }

    public class ReplaceData
    {
        public string before_data { get; set; }

        public string after_data { get; set; }
    }
}
