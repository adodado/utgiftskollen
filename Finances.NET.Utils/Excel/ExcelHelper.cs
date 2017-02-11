using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Finances.NET.Core.Operations;

namespace Finances.NET.Utils.Excel
{
    /// <summary>
    /// Class ExcelHelper, reads/writes excel files.
    /// </summary>
    public static class ExcelHelper
    {
        #region Create Excel Document

        /// <summary>
        /// Creates the spreadsheet workbook.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="listOfOperations">List containing all the operations.</param>
        public static void CreateSpreadsheetWorkbook(string filePath, List<Operation> listOfOperations)
        {
            var dt = ToDataTable(listOfOperations);
            // Create a spreadsheet document
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            var f = new FileInfo(filePath);
            if (f.Exists)
                f.Delete();

            var spreadsheetDocument = SpreadsheetDocument.Create(filePath,
                SpreadsheetDocumentType.Workbook);
            var workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            
            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            var sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Transactions"
            };
            sheets.Append(sheet);

            var stylesPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = GenerateStyleSheet();
            stylesPart.Stylesheet.Save();

            uint row = 2;
            foreach (DataRow dr in dt.Rows)
            {
                for (var idx = 0; idx < dt.Columns.Count; idx++)
                {
                    var cl = "";
                    if (idx >= 26)
                        cl = "A" + Convert.ToString(Convert.ToChar(65 + idx - 26));
                    else
                        cl = Convert.ToString(Convert.ToChar(65 + idx));
                    var shareStringPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any() ? spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First() : spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                    Cell cell;
                    int index;

                    if (row == 2)
                    {
                        index = InsertSharedStringItem(dt.Columns[idx].ColumnName, shareStringPart);
                        cell = InsertCellInWorksheet(cl, row - 1, worksheetPart);
                        cell.CellValue = new CellValue(index.ToString(CultureInfo.InvariantCulture));
                        cell.StyleIndex = 7;
                        cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                    }

                    index = InsertSharedStringItem(Convert.ToString(dr[idx]), shareStringPart);
                    cell = InsertCellInWorksheet(cl, row, worksheetPart);
                    cell.CellValue = new CellValue(index.ToString(CultureInfo.InvariantCulture));
                    cell.StyleIndex = 8;
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
                row++;
            }

            for (var idx = 0; idx < dt.Columns.Count; idx++)
            {
                SetColumnWidth(worksheetPart.Worksheet, (uint)idx+1, 26);
            }

            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();
        }

        /// <summary>
        /// Inserts the shared string item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="shareStringPart">The share string part.</param>
        /// <returns>System.Int32.</returns>
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            var i = 0;

            foreach (var item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            shareStringPart.SharedStringTable.AppendChild(
                new SharedStringItem(new Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }


        /// <summary>
        /// Inserts the cell in worksheet.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="worksheetPart">The worksheet part.</param>
        /// <returns>Cell.</returns>
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            var worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var cellReference = columnName + rowIndex;

            Row row;
            if (sheetData.Elements<Row>().Count(r => r.RowIndex == rowIndex) != 0)
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row() {RowIndex = rowIndex};
                sheetData.Append(row);
            }

            if (row.Elements<Cell>().Any(c => c.CellReference.Value == columnName + rowIndex))
            {
                return row.Elements<Cell>().First(c => c.CellReference.Value == cellReference);
            }
            else
            {
                 Cell refCell = null;
                var newCell = new Cell() {CellReference = cellReference};
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }

        #endregion

        #region Read Excel Document

        /// <summary>
        /// Reads the excel file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataTable.</returns>
        public static DataTable ReadExcelFile(string filePath)
        {
            try
            {
                var dt = new DataTable();
                using (var spreadSheetDocument = SpreadsheetDocument.Open(filePath, false))
                {
                    var workbookPart = spreadSheetDocument.WorkbookPart;
                    var sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    var relationshipId = sheets.First().Id.Value;
                    var worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                    var workSheet = worksheetPart.Worksheet;
                    var sheetData = workSheet.GetFirstChild<SheetData>();
                    var rows = sheetData.Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                    }
                    foreach (var row in rows)
                    {
                        var tempRow = dt.NewRow();
                        for (var i = 0; i < row.Descendants<Cell>().Count(); i++)
                        {
                            tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                        }
                        dt.Rows.Add(tempRow);
                    }
                }
                return dt;
            }
            catch
            {
                //TODO: Logging!!
            }
            return null;
        }

        /// <summary>
        /// Gets the cell value.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="cell">The cell.</param>
        /// <returns>System.String.</returns>
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            var stringTablePart = document.WorkbookPart.SharedStringTablePart;
            
            if (cell.CellValue == null)
            {
                return "";
            }
            
            var value = cell.CellValue.InnerXml;
            
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        #endregion

        #region Stylesheet methods
        static void SetColumnWidth(Worksheet worksheet, uint Index, DoubleValue dwidth)
        {
            if (Index == 3 | Index==4)
                dwidth = 18;

            var cs = worksheet.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Columns>();
            if (cs != null)
            {
                var ic = cs.Elements<DocumentFormat.OpenXml.Spreadsheet.Column>().Where(r => r.Min == Index).Where(r => r.Max == Index);
                if (ic.Count() > 0)
                {
                    var c = ic.First();
                    c.Width = dwidth;
                }
                else
                {
                    var c = new DocumentFormat.OpenXml.Spreadsheet.Column() { Min = Index, Max = Index, Width = dwidth, CustomWidth = true };
                    cs.Append(c);
                }
            }
            else
            {
                cs = new DocumentFormat.OpenXml.Spreadsheet.Columns();
                var c = new DocumentFormat.OpenXml.Spreadsheet.Column() { Min = Index, Max = Index, Width = dwidth, CustomWidth = true };
                cs.Append(c);
                worksheet.InsertAfter(cs, worksheet.GetFirstChild<SheetFormatProperties>());
            }
        }

        /// <summary>
        /// Generates the style sheet.
        /// </summary>
        /// <returns>Stylesheet.</returns>
        private static Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 - The default font.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 1 - The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 - The Italic font.
                        new Italic(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 - The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 - The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 - The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 - The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF00" } }
                        ) { PatternType = PatternValues.Solid }),
                        new Fill(                                                           // Index 3 - The lightblue fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "66CCFF" } }
                        ) { PatternType = PatternValues.Solid }),
                           new Fill(                                                           // Index 4 - The lightgray fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "CCCCCC" } }
                        ) { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 - The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder()),
                        new Border(                                                         // Index 2 - Applies a Right border to a cell
                        new RightBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin })
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 - The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 - Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 - Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 - Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 - Yellow Fill
                    new CellFormat(                                                                   // Index 5 - Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    ) { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },      // Index 6 - Border
                    new CellFormat() { FontId = 1, FillId = 3, BorderId = 1, ApplyBorder = true},       // Index 7 Light blue column headers
                   new CellFormat() { FontId = 2, FillId = 4, BorderId = 2, ApplyBorder = true }        // Index 8 standard cells, cursive,light grey pattern fill, border on right side of cell
                    )
            );
        }

        #endregion
  
        #region Conversion methods

        /// <summary>
        /// To the data table.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>DataTable.</returns>
        private static DataTable ToDataTable<TSource>(this IList<TSource> data)
        {
            var dataTable = new DataTable(typeof(TSource).Name);
            var props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            dataTable.Columns.RemoveAt(0);
            return dataTable;
        }

        /// <summary>
        /// Converts the DataTable to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns>List{``0}.</returns>
        public static List<Operation> DataTableToList(DataTable dt)
        {
            var operationsList = new List<Operation>();
            dt.Rows.RemoveAt(0);
            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row["ID"].ToString()))
                {
                    var op = new Operation(row["ID"].ToString())
                    {
                        Budget = row["Budget"].ToString(),
                        Commentary = row["Commentary"].ToString(),
                        Credit = Convert.ToDecimal(row["Credit"].ToString()),
                        Debit = Convert.ToDecimal(row["Debit"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        Type = row["Type"].ToString(),
                        Monthly = Convert.ToBoolean(row["Monthly"].ToString())
                    };
                    operationsList.Add(op);
                }
                else
                {
                    var op = new Operation()
                    {
                        Budget = row["Budget"].ToString(),
                        Commentary = row["Commentary"].ToString(),
                        Credit = Convert.ToDecimal(row["Credit"].ToString()),
                        Debit = Convert.ToDecimal(row["Debit"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        Type = row["Type"].ToString(),
                        Monthly = Convert.ToBoolean(row["Monthly"].ToString())
                    };
                    operationsList.Add(op);
                }
            }
            return operationsList;
        }

        #endregion
    }
}
