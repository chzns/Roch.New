using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roch.CodeTool
{
    public static class ChartCodeTemplate
    {
        // 模板字符串，可以根据实际需求调整
        private const string DefaultTemplate = @"<?xml version=""1.0"" encoding=""utf-8""?>
<CodeSnippets xmlns=""http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet"">
  <CodeSnippet Format=""1.0.0"">
    <Header>
      <SnippetTypes>
        <SnippetType>Expansion</SnippetType>
      </SnippetTypes>
      <Title>#KeyName#</Title>
      <Author>
      </Author>
      <Description>
      </Description>
      <HelpUrl>
      </HelpUrl>
      <Shortcut>
      </Shortcut>
    </Header>
    <Snippet>
      <Code Language=""csharp"" Delimiter=""$""><![CDATA[
      
#CodeContent#

      ]]></Code>
    </Snippet>
  </CodeSnippet>
</CodeSnippets>";

        // 替换模板中的占位符
        public static string GenerateSnippet(string keyName, string codeContent, string template = null)
        {
            // 如果没有提供自定义模板，使用默认模板
            string currentTemplate = template ?? DefaultTemplate;

            // 使用正则表达式进行替换，确保替换时能够灵活匹配
            string result = Regex.Replace(currentTemplate, "#KeyName#", keyName);
            codeContent = ReplaceSpecialCharacters(codeContent);
            //result = Regex.Replace(result, "#CodeContent#", codeContent);
            result = result.Replace("#CodeContent#", codeContent);
            return result;
        }

        //public static string ReplaceSpecialCharacters(string input)
        //{
        //    // 定义需要替换的特殊字符列表
        //    string[] specialCharacters = { "$" };

        //    // 遍历每个特殊字符并进行替换
        //    foreach (string specialChar in specialCharacters)
        //    {
        //        // 使用双重字符替换，例如 $ -> $$
        //        input = Regex.Replace(input, Regex.Escape(specialChar), specialChar + specialChar);
        //    }

        //    return input;
        //}


        public static string ReplaceSpecialCharacters(string input)
        {
            return input.Replace("$", "$$");
            //return Regex.Replace(input, @"\$", "$$");
        }




    }
}
