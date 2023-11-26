using CaseStudy_1_Naaptol.TestScripts;
using ExcelDataReader;
using System.Data;
using System.Text;

namespace CaseStudy_1_Naaptol.Utilities
{
    internal class ExcelUtils
    {
        public static List<ExcelData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<ExcelData> excelDataList = new List<ExcelData>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables["NaaptolSearch"]; // Use the provided sheetName

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ExcelData excelData = new ExcelData
                            {
                                SearchText = GetValueOrDefault(row, "searchtext"),
                                Id = GetValueOrDefault(row, "id"),
                                // Add more properties as needed
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
