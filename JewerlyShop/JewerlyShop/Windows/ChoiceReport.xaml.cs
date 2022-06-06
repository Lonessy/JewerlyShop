using JewerlyShop.ModelBase;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для ChoiceReport.xaml
    /// </summary>
    public partial class ChoiceReport : Window
    {
        JewerlyShopEntities db = new JewerlyShopEntities();
        public ChoiceReport()
        {
            InitializeComponent();
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Товары";
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "Text documents (.pdf)|*.pdf";


            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {

                string filename = dlg.FileName;

                JewerlyShopEntities db = new JewerlyShopEntities();
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                MessageBox.Show("Отчёт успешно сохранен", "Выполнено");
                document.Open();

                string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font5 = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(9);
                float[] widths = new float[] { 7f, 7f, 7f, 7f, 7f, 7f, 7f, 7f, 7f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Products"));
                var items = db.Products.ToList();

                table.AddCell(new Phrase("Название", font5));
                table.AddCell(new Phrase("Материал", font5));
                table.AddCell(new Phrase("Вес", font5));
                table.AddCell(new Phrase("Проба", font5));
                table.AddCell(new Phrase("Размер", font5));
                table.AddCell(new Phrase("Цена закупки", font5));
                table.AddCell(new Phrase("Цена продажи", font5));
                table.AddCell(new Phrase("Поставщик", font5));
                table.AddCell(new Phrase("Кол-во", font5));

                foreach (var p in items)
                {
                    table.AddCell(new Phrase(p.Name.ToString(), font5));
                    table.AddCell(new Phrase(p.Materials.Name.ToString(), font5));
                    table.AddCell(new Phrase(p.Weight.ToString(), font5));
                    table.AddCell(new Phrase(p.Proba.ToString(), font5));
                    table.AddCell(new Phrase(p.Size.ToString(), font5));
                    table.AddCell(new Phrase(p.PurchasePrice.ToString(), font5));
                    table.AddCell(new Phrase(p.Price.ToString(), font5));
                    table.AddCell(new Phrase(p.Providers.Name.ToString(), font5));
                    table.AddCell(new Phrase(p.Volume.ToString(), font5));
                }

                document.Add(table);
                document.Close();
            }
        }

        private void AddReportExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            excelapp.Visible = true;
            Excel._Workbook workbook = (Excel._Workbook)(excelapp.Workbooks.Add(Type.Missing));
            Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Товары";

            Excel.Range hRange = excelapp.get_Range("A2:I2");
            hRange.Merge(Type.Missing);
            hRange.Merge(Type.Missing);
            worksheet.Cells[1, 1] = "Товары";

            Excel.Range ThisRange = excelapp.get_Range("A3:I3");
            ThisRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            var items = db.Products.ToList();


            worksheet.Cells[3, 1] = "Название";
            worksheet.Cells[3, 2] = "Материал";
            worksheet.Cells[3, 3] = "Вес";
            worksheet.Cells[3, 4] = "Проба";
            worksheet.Cells[3, 5] = "Размер";
            worksheet.Cells[3, 6] = "Цена закупки";
            worksheet.Cells[3, 7] = "Цена продажи";
            worksheet.Cells[3, 8] = "Поставщик";
            worksheet.Cells[3, 9] = "Кол-во";


            Excel.Range TRange = excelapp.get_Range("A4:I8");
            TRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            int i = 4;
            foreach (var elem in items)
            {
                worksheet.Cells[i, 1] = elem.Name;
                worksheet.Cells[i, 2] = elem.Materials.Name;
                worksheet.Cells[i, 3] = elem.Weight;
                worksheet.Cells[i, 4] = elem.Proba;
                worksheet.Cells[i, 5] = elem.Size;
                worksheet.Cells[i, 6] = elem.PurchasePrice;
                worksheet.Cells[i, 7] = elem.Price;
                worksheet.Cells[i, 8] = elem.Providers.Name;
                worksheet.Cells[i, 9] = elem.Volume;
                i++;
            }

            worksheet.Columns.AutoFit();
        }
    }
}
