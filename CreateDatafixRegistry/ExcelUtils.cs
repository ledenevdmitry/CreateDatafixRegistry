using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreateDatafixRegistry
{
    class ExcelUtils
    {
        public static Application excApp;
        static Regex RegexFixpackChangeNumber = new Regex(@"C\d+");

        public static void CreateDFRegistry(DirectoryInfo dir, IEnumerable<FileInfo> excelFiles, out List<FileInfo> patternMismatchFiles, bool isDFRegistry)
        {
            if(excApp == null)
            {
                excApp = new Application();
            }

            patternMismatchFiles = new List<FileInfo>();

            FileInfo seedFile = new FileInfo(isDFRegistry ? "DF_SAMPLE.xlsx" : "PPF_SAMPLE.xlsx");

            Workbook registryWB = excApp.Workbooks.Open(seedFile.FullName);
            Worksheet registryWS = registryWB.Worksheets[isDFRegistry ? 2 : 1];

            foreach (FileInfo currExcelFile in dir.EnumerateFiles("*.xls*", SearchOption.AllDirectories))
            {
                if(excelFiles.Where(x => x.FullName.Equals(currExcelFile.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                {
                    Workbook currWB = excApp.Workbooks.Open(currExcelFile.FullName);
                    Worksheet currWS = currWB.Worksheets[isDFRegistry ? 2 : 1];

                    Range registryRange = registryWS.UsedRange;
                    Range currWSRange = currWS.UsedRange;

                    if(registryRange.Columns.Count != currWSRange.Columns.Count)
                    {
                        patternMismatchFiles.Add(currExcelFile);
                    }                    

                    //учитываем смещение, чтобы не копировать пустые строки
                    int offset = 0;

                    if (isDFRegistry)
                    {
                        for (int i = 2; i <= currWSRange.Rows.Count; ++i)
                        {
                            Range firstCell = currWS.Cells[i, 1];
                            if (firstCell == null || firstCell.Value2 == null || string.IsNullOrWhiteSpace(firstCell.Value2.ToString()))
                            {
                                offset--;
                            }
                            else
                            {
                                registryWS.Cells[i + registryRange.Rows.Count - 1 - offset, 1] = i + registryRange.Rows.Count - 2;
                                for (int j = 2; j <= registryRange.Columns.Count; ++j)
                                {
                                    registryWS.Cells[i + registryRange.Rows.Count - 1 - offset, j] = currWS.Cells[i, j];
                                }

                                registryWS.Cells[i + registryRange.Rows.Count - 1 - offset, 4] = RegexFixpackChangeNumber.Match(currExcelFile.FullName).Value + "." + (registryWS.Cells[i + registryRange.Rows.Count - 1 - offset, 4] as Range).Value2;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 2; i <= currWSRange.Rows.Count; ++i)
                        {
                            Range firstCell = currWS.Cells[i, 1];
                            if (firstCell == null || firstCell.Value2 == null || string.IsNullOrWhiteSpace(firstCell.Value2.ToString()))
                            {
                                offset--;
                            }
                            else
                            {
                                for (int j = 1; j <= registryRange.Columns.Count; ++j)
                                {
                                    registryWS.Cells[i + registryRange.Rows.Count - 1 - offset, j] = currWS.Cells[i, j];
                                }
                            }
                        }
                    }

                    currWB.Close();
                }
            }

            registryWB.SaveAs(Path.Combine(dir.FullName,  isDFRegistry ? "DF_CORE" : "PPF_CORE"));

            registryWB.Close();
        }
    }
}
