﻿using Microsoft.CodeAnalysis.CSharp;
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
using System.IO;

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
         public string FormatCSharpCode(string code)
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

    public class FileSaver
    {
        public static void SaveStringToSnappetFile(string content, string fileName,string fileEx)
        {
            // 获取桌面路径
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 构建完整的文件路径，添加 .snappet 扩展名
            string filePath = Path.Combine(desktopPath, fileName + fileEx);

            try
            {
                // 将字符串写入文件
                File.WriteAllText(filePath, content);
                Console.WriteLine("文件已成功保存到: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存文件时出错: " + ex.Message);
            }
        }

        public static void SaveStringToSnappetFile(string content, string fileName, string fileEx, string customPath = null)
        {
            // 如果路径为空，则使用桌面路径
            string savePath = string.IsNullOrEmpty(customPath) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : customPath;

            // 构建完整的文件路径，添加文件扩展名
            string filePath = Path.Combine(savePath, fileName + fileEx);

            try
            {
                // 将字符串写入文件
                File.WriteAllText(filePath, content);
                Console.WriteLine("文件已成功保存到: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存文件时出错: " + ex.Message);
            }
        }

        public static string CreateFileInFolderOnDesktop(string folderName, string fileName, string extension, string content)
        {
            // 获取桌面路径
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 组合桌面路径和文件夹名称，生成文件夹路径
            string folderPath = Path.Combine(desktopPath, folderName);

            // 检查文件夹是否存在，如果不存在则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 动态生成完整文件名，包含时间戳
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fullFileName = $"{fileName}_{timeStamp}.{extension}";

            // 组合文件夹路径和文件名，生成完整文件路径
            string filePath = Path.Combine(folderPath, fullFileName);

            // 将内容写入文件
            File.WriteAllText(filePath, content, Encoding.UTF8);

            // 返回文件的完整路径
            return filePath;
        }

    }

}
