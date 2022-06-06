using JewerlyShop.ModelBase;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using JewerlyShop.AppData.Tools;

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для SalesWindow.xaml
    /// </summary>
    public partial class SalesWindow : Window
    {
        int selectedId = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public SalesWindow()
        {
            InitializeComponent();
            SaleGrid.ItemsSource = null;
            SaleGrid.Items.Refresh();
            var query = (from x in db.Sales
                         select new SalesView
                         {
                             id = x.Id,
                             Product = x.Products.Name,
                             Client = x.Clients.FIO,
                             Datetime = x.DateSale,
                             Price = x.Price,
                             Count = x.Count
                         }).ToArray();
            SaleGrid.ItemsSource = query.ToList();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowMain = new MainWindow();
            this.Close();
            windowMain.ShowDialog();
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow windowProducts = new ProductsWindow();
            this.Close();
            windowProducts.ShowDialog();
        }

        private void ProvidersBtn_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow windowProv = new ProvidersWindow();
            this.Close();
            windowProv.ShowDialog();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow windowClients = new ClientsWindow();
            this.Close();
            windowClients.ShowDialog();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void AddSalesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSalesWindow windowAdd = new AddSalesWindow();
            windowAdd.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            SaleGrid.ItemsSource = null;
            SaleGrid.Items.Refresh();
            SaleGrid.ItemsSource = db.Sales.Select(x => new
            {
                id = x.Id,
                Product = x.Products.Name,
                Client = x.Clients.FIO,
                Datetime = x.DateSale,
                Price = x.Price,
                Count = x.Count
            }).ToList();
            db.Dispose();
        }

        private void EditSalesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSalesWindow windowAdd = new AddSalesWindow(selectedId);
            windowAdd.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            SaleGrid.ItemsSource = null;
            SaleGrid.Items.Refresh();
            SaleGrid.ItemsSource = db.Sales.Select(x => new
            {
                id = x.Id,
                Product = x.Products.Name,
                Client = x.Clients.FIO,
                Datetime = x.DateSale,
                Price = x.Price,
                Count = x.Count
            }).ToList();
            db.Dispose();
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Продажи";
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

                PdfPTable table = new PdfPTable(5);
                float[] widths = new float[] { 7f, 7f, 7f, 7f, 7f};

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Sales"));
                var items = db.Sales.ToList();

                table.AddCell(new Phrase("Товар", font5));
                table.AddCell(new Phrase("Клиент", font5));
                table.AddCell(new Phrase("Дата и время", font5));
                table.AddCell(new Phrase("Цена", font5));
                table.AddCell(new Phrase("Кол-во", font5));

                foreach (var p in items)
                {
                    table.AddCell(new Phrase(p.Products.Name.ToString(), font5));
                    table.AddCell(new Phrase(p.Clients.FIO.ToString(), font5));
                    table.AddCell(new Phrase(p.DateSale.ToString(), font5));
                    table.AddCell(new Phrase(p.Price.ToString(), font5));
                    table.AddCell(new Phrase(p.Count.ToString(), font5));
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
            worksheet.Name = "Продажи";

            Excel.Range hRange = excelapp.get_Range("A2:E2");
            hRange.Merge(Type.Missing);
            hRange.Merge(Type.Missing);
            worksheet.Cells[1, 1] = "Продажи";

            Excel.Range ThisRange = excelapp.get_Range("A3:E3");
            ThisRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            var items = db.Sales.ToList();


            worksheet.Cells[3, 1] = "Товар";
            worksheet.Cells[3, 2] = "Клиент";
            worksheet.Cells[3, 3] = "Дата и время";
            worksheet.Cells[3, 4] = "Цена";
            worksheet.Cells[3, 5] = "Кол-во";


            Excel.Range TRange = excelapp.get_Range("A4:E8");
            TRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            int i = 4;
            foreach (var elem in items)
            {
                worksheet.Cells[i, 1] = elem.Products.Name;
                worksheet.Cells[i, 2] = elem.Clients.FIO;
                worksheet.Cells[i, 3] = elem.DateSale;
                worksheet.Cells[i, 4] = elem.Price;
                worksheet.Cells[i, 5] = elem.Count;
                i++;
            }

            worksheet.Columns.AutoFit();
        }
        private void SaleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SaleGrid.SelectedValue != null)
            {
                System.Type type = SaleGrid.SelectedValue.GetType();
                int ProductId = (int)type.GetProperty("id").GetValue(SaleGrid.SelectedValue, null);

                selectedId = ProductId;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                JewerlyShopEntities dbremove = new JewerlyShopEntities();
                Sales sl = dbremove.Sales
                   .Where(o => o.Id == selectedId)
                   .FirstOrDefault();

                var product = dbremove.Products.FirstOrDefault(a => a.Id == sl.IdProduct);
                product.Volume = product.Volume + sl.Count;

                dbremove.Sales.Remove(sl);
                dbremove.SaveChanges();
                dbremove.Dispose();

                MessageBox.Show("Удаление прошло успешно", "Выполнено");
                selectedId = 0;
                JewerlyShopEntities db = new JewerlyShopEntities();
                SaleGrid.ItemsSource = db.Sales.Select(x => new
                {
                    id = x.Id,
                    Product = x.Products.Name,
                    Client = x.Clients.FIO,
                    Datetime = x.DateSale,
                    Price = x.Price,
                    Count = x.Count
                }).ToList();
                db.Dispose();
            }
            else
            {
                MessageBox.Show("Выберите товар в списке", "Внимание");
            }
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            String text = SearchText.Text.ToLower();

            var query = db.Sales.ToList();
            SaleGrid.ItemsSource = query;

            Sales[] sales = db.Sales
                .Where(x => x.Products.Name.ToLower().StartsWith(text) || x.Clients.FIO.ToLower().StartsWith(text)).ToArray();

            SaleGrid.ItemsSource = sales
                .Select(a => new SalesView
                {
                    id = a.Id,
                    Product = a.Products.Name,
                    Client = a.Clients.FIO,
                    Datetime = a.DateSale,
                    Price = a.Price,
                    Count = a.Count
                });
        }

        private void SearchText_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchTextHolder.Visibility = Visibility.Collapsed;
        }

        private void SearchText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchText.Text == "")
            {
                SearchTextHolder.Visibility = Visibility.Visible;
            }
        }

        private void AddTicket_Click(object sender, RoutedEventArgs e)
        {
            SalesView sale = SaleGrid.SelectedItem as SalesView;
            if (sale == null)
            {
                MessageBox.Show("Выберите продажу");
                return;
            }

            MyPdfWriter.GetTicket(sale);
            SaleGrid.SelectedItem = null;
        }

        private void Reference_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"..\..\Resources\Справка.docx");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
