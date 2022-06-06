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

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для ProvidersWindow.xaml
    /// </summary>
    public partial class ProvidersWindow : Window
    {
        int selectedId = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public ProvidersWindow()
        {
            InitializeComponent();
            ProvidersGrid.ItemsSource = null;
            ProvidersGrid.Items.Refresh();
            var query = (from x in db.Providers
                         select new ProvidersView
                         {
                             id = x.Id,
                             Name = x.Name,
                             City = x.City,
                             Address = x.Address,
                             Phone = x.Phone,
                         }).ToArray();
            ProvidersGrid.ItemsSource = query.ToList();
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

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow windowClients = new ClientsWindow();
            this.Close();
            windowClients.ShowDialog();
        }

        private void SalesBtn_Click(object sender, RoutedEventArgs e)
        {
            SalesWindow windowSales = new SalesWindow();
            this.Close();
            windowSales.ShowDialog();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddProvidersBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProvidersWindow windowAdd = new AddProvidersWindow();
            windowAdd.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            ProvidersGrid.ItemsSource = null;
            ProvidersGrid.Items.Refresh();
            ProvidersGrid.ItemsSource = db.Providers.Select(x => new
            {
                id = x.Id,
                Name = x.Name,
                City = x.City,
                Address = x.Address,
                Phone = x.Phone,
            }).ToList();
            db.Dispose();
        }

        private void EditProvidersBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProvidersWindow windowEdit = new AddProvidersWindow(selectedId);
            windowEdit.ShowDialog();
            ProvidersGrid.ItemsSource = null;
            ProvidersGrid.Items.Refresh();
            JewerlyShopEntities db = new JewerlyShopEntities();
            ProvidersGrid.ItemsSource = db.Providers.Select(x => new
            {
                id = x.Id,
                Name = x.Name,
                City = x.City,
                Address = x.Address,
                Phone = x.Phone,
            }).ToList();
            db.Dispose();
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Поставщики";
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

                PdfPTable table = new PdfPTable(4);
                float[] widths = new float[] { 7f, 7f, 7f, 7f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Providers"));
                var items = db.Providers.ToList();

                table.AddCell(new Phrase("Название", font5));
                table.AddCell(new Phrase("Город", font5));
                table.AddCell(new Phrase("Адрес", font5));
                table.AddCell(new Phrase("Телефон", font5));

                foreach (var p in items)
                {
                    table.AddCell(new Phrase(p.Name.ToString(), font5));
                    table.AddCell(new Phrase(p.City.ToString(), font5));
                    table.AddCell(new Phrase(p.Address.ToString(), font5));
                    table.AddCell(new Phrase(p.Phone.ToString(), font5));
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
            worksheet.Name = "Поставщики";

            Excel.Range hRange = excelapp.get_Range("A2:D2");
            hRange.Merge(Type.Missing);
            hRange.Merge(Type.Missing);
            worksheet.Cells[1, 1] = "Поставщики";

            Excel.Range ThisRange = excelapp.get_Range("A3:D3");
            ThisRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            var items = db.Providers.ToList();


            worksheet.Cells[3, 1] = "Название";
            worksheet.Cells[3, 2] = "Город";
            worksheet.Cells[3, 3] = "Адрес";
            worksheet.Cells[3, 4] = "Телефон";


            Excel.Range TRange = excelapp.get_Range("A4:D8");
            TRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            int i = 4;
            foreach (var elem in items)
            {
                worksheet.Cells[i, 1] = elem.Name;
                worksheet.Cells[i, 2] = elem.City;
                worksheet.Cells[i, 3] = elem.Address;
                worksheet.Cells[i, 4] = elem.Phone;
                i++;
            }

            worksheet.Columns.AutoFit();
        }

        private void ProvidersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProvidersGrid.SelectedValue != null)
            {
                System.Type type = ProvidersGrid.SelectedValue.GetType();
                int ProductId = (int)type.GetProperty("id").GetValue(ProvidersGrid.SelectedValue, null);

                selectedId = ProductId;
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                JewerlyShopEntities dbremove = new JewerlyShopEntities();
                Providers pr = dbremove.Providers
               .Where(o => o.Id == selectedId)
               .FirstOrDefault();
                dbremove.Providers.Remove(pr);
                dbremove.SaveChanges();
                dbremove.Dispose();
                MessageBox.Show("Удаление прошло успешно", "Выполнено");
                selectedId = 0;
                JewerlyShopEntities db = new JewerlyShopEntities();
                ProvidersGrid.ItemsSource = db.Providers.Select(x => new
                {
                    id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Address = x.Address,
                    Phone = x.Phone,
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

            var query = db.Products.ToList();
            ProvidersGrid.ItemsSource = query;

            Providers[] providers = db.Providers
                .Where(x => x.Name.ToLower().StartsWith(text) || x.City.ToLower().StartsWith(text) || x.Phone.ToLower().StartsWith(text)).ToArray();

            ProvidersGrid.ItemsSource = providers
                .Select(a => new ProvidersView
                {
                    id = a.Id,
                    Name = a.Name,
                    City = a.City,
                    Address = a.Address,
                    Phone = a.Phone,
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
