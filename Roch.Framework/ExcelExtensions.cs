using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Resources;
using System.Drawing;
using Aspose.Cells;

namespace Roch.Framework
{
   public class ExcelExtensions
    {
        public static bool ExportExcelWithAspose(System.Data.DataTable dt, string path)
        {
            bool succeed = false;
            if (dt != null)
            {
                try
                {
                    Aspose.Cells.License li = new Aspose.Cells.License();
                  

                    StringBuilder _sb = new StringBuilder();
                    _sb.Append("<License>");
                    _sb.Append("<Data>");
                    _sb.Append("<SerialNumber>aed83727-21cc-4a91-bea4-2607bf991c21</SerialNumber>");
                    _sb.Append("<EditionType>Enterprise</EditionType>");
                    _sb.Append("<Products>");
                    _sb.Append("<Product>Aspose.Total</Product>");
                    _sb.Append("</Products>");
                    _sb.Append("</Data> <Signature>CxoBmxzcdRLLiQi1kzt5oSbz9GhuyHHOBgjTf5w/wJ1V+lzjBYi8o7PvqRwkdQo4tT4dk3PIJPbH9w5Lszei1SV/smkK8SCjR8kIWgLbOUFBvhD1Fn9KgDAQ8B11psxIWvepKidw8ZmDmbk9kdJbVBOkuAESXDdtDEDZMB/zL7Y=</Signature>");
                    _sb.Append("</License>");
                    _sb.ToString();
                    string lic = _sb.ToString();
                    Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(lic));
                    li.SetLicense(s);

                    Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                    Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];

                    cellSheet.Name = dt.TableName;

                    int rowIndex = 0;
                    int colIndex = 0;
                    int colCount = dt.Columns.Count;
                    int rowCount = dt.Rows.Count;

                    //样式 

                    Style style1 = workbook.Styles[workbook.Styles.Add()];//新增样式
                    //style1.HorizontalAlignment = TextAlignmentType.Center;//文字居中
                    //style1.Font.Name = "宋体";//文字字体
                    //style1.Font.Size = 12;//文字大小
                    //style1.IsLocked = false;//单元格解锁
                    //style1.Font.IsBold = true;//粗体
                    //style1.ForegroundColor = Color.FromArgb(0x99, 0xcc, 0xff);//设置背景色
                    //style1.Pattern = BackgroundType.Solid; //设置背景样式
                    //style1.IsTextWrapped = true;//单元格内容自动换行
                    //style1.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
                    //style1.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
                    //style1.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
                    //style1.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线                                                                   //设置单元格背景颜色
                    style1.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
                    style1.Pattern = BackgroundType.Solid;

           

                    //列名的处理
                    for (int i = 0; i < colCount; i++)
                    {
                        cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Columns[i].ColumnName);
                        cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
                        cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
                        colIndex++;
                  
                    }

                    Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];
                    style.Font.Name = "Arial";
                    style.Font.Size = 10;
                    Aspose.Cells.StyleFlag styleFlag = new Aspose.Cells.StyleFlag();
                    cellSheet.Cells.ApplyStyle(style, styleFlag);

                    rowIndex++;

                    for (int i = 0; i < rowCount; i++)
                    {
                        

                        colIndex = 0;
                        for (int j = 0; j < colCount; j++)
                        {
                            cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Rows[i][j].ToString());
                            colIndex++;
                            if (j >=-1&&j<=40)
                            {

                                cellSheet.Cells[rowIndex, colIndex].SetStyle(style1);//给单元格关联样式
                                //cellSheet.Cells[rowIndex, colIndex].Style(style1);


                            }
                        }
                        rowIndex++;
                    }
                    cellSheet.AutoFitColumns();

                    path = Path.GetFullPath(path);
                    workbook.Save(path);
                    succeed = true;
                }
                catch (Exception ex)
                {
                    succeed = false;
                }
            }

            return succeed;
        }

    }
}
