using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Formatting;

namespace Roch.CodeTool
{
   public class Common
    {
        public static string FirstCharToLower(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            else if (input.Length == 1)
            {
                return input.ToLower();
            }
            else
            {
                return input.Substring(0, 1).ToLower() + input.Substring(1);
            }
        }


    }

    public static class StringBuilderExtensions
    {
        // 扩展方法，用于追加指定数量的空白行
        public static StringBuilder AppendLines(this StringBuilder sb, int numberOfLines)
        {
            if (sb == null)
            {
                throw new ArgumentNullException(nameof(sb));
            }

            for (int i = 0; i < numberOfLines; i++)
            {
                sb.AppendLine();
            }

            return sb;
        }
    }

    public class CodeFormatter
    {
        public  string FormatCSharpCode(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            SyntaxNode root = syntaxTree.GetRoot();

            var workspace = new AdhocWorkspace();
            var options = workspace.Options
                .WithChangedOption(FormattingOptions.NewLine, LanguageNames.CSharp, Environment.NewLine)
                .WithChangedOption(FormattingOptions.UseTabs, LanguageNames.CSharp, false)  // Use spaces instead of tabs
                .WithChangedOption(FormattingOptions.IndentationSize, LanguageNames.CSharp, 4)  // Indentation size
                .WithChangedOption(FormattingOptions.TabSize, LanguageNames.CSharp, 4)  // Tab size
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true)  // New line for braces in methods
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, true)  // New line for braces in properties
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInControlBlocks, true);  // New line for braces in control blocks

            var formattedNode = Microsoft.CodeAnalysis.Formatting.Formatter.Format(root, workspace, options);
            return formattedNode.ToFullString();

        }
    }
}
