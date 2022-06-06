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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        int selectedId = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public ClientsWindow()
        {
            InitializeComponent();
            СlientGrid.ItemsSource = null;
            СlientGrid.Items.Refresh();
            var query = (from x in db.Clients
                         select new ClientsView
                         {
                             id = x.Id,
                             FIO = x.FIO,
                             Phone = x.Phone,
                         }).ToArray();
            СlientGrid.ItemsSource = query.ToList();
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

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow windowAdd = new AddClientWindow();
            windowAdd.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            СlientGrid.ItemsSource = null;
            СlientGrid.Items.Refresh();
            СlientGrid.ItemsSource = db.Clients.Select(x => new
            {
                id = x.Id,
                FIO = x.FIO,
                Phone = x.Phone,
            }).ToList();
            db.Dispose();
        }

        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow windowAdd = new AddClientWindow(selectedId);
            windowAdd.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            СlientGrid.ItemsSource = null;
            СlientGrid.Items.Refresh();
            СlientGrid.ItemsSource = db.Clients.Select(x => new
            {
                id = x.Id,
                FIO = x.FIO,
                Phone = x.Phone,
            }).ToList();
            db.Dispose();
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Клиенты";
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "Текстовый документ (.pdf)|*.pdf";


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

                PdfPTable table = new PdfPTable(2);
                float[] widths = new float[] { 7f, 7f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Clients"));
                var items = db.Clients.ToList();

                table.AddCell(new Phrase("ФИО", font5));
                table.AddCell(new Phrase("Телефон", font5));

                foreach (var p in items)
                {
                    table.AddCell(new Phrase(p.FIO.ToString(), font5));
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
            worksheet.Name = "Клиенты";

            Excel.Range hRange = excelapp.get_Range("A2:B2");
            hRange.Merge(Type.Missing);
            hRange.Merge(Type.Missing);
            worksheet.Cells[1, 1] = "Клиенты";

            Excel.Range ThisRange = excelapp.get_Range("A3:B3");
            ThisRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            var items = db.Clients.ToList();


            worksheet.Cells[3, 1] = "ФИО";
            worksheet.Cells[3, 2] = "Телефон";


            Excel.Range TRange = excelapp.get_Range("A4:B8");
            TRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            int i = 4;
            foreach (var elem in items)
            {
                worksheet.Cells[i, 1] = elem.FIO;
                worksheet.Cells[i, 2] = elem.Phone;
                i++;
            }

            worksheet.Columns.AutoFit();
        }
    
        private void СlientGrid_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (СlientGrid.SelectedValue != null)
            {
                System.Type type = СlientGrid.SelectedValue.GetType();
                int ClientId = (int)type.GetProperty("id").GetValue(СlientGrid.SelectedValue, null);

                selectedId = ClientId;
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                JewerlyShopEntities dbremove = new JewerlyShopEntities();
                Clients cl = dbremove.Clients
               .Where(o => o.Id == selectedId)
               .FirstOrDefault();
                dbremove.Clients.Remove(cl);
                dbremove.SaveChanges();
                dbremove.Dispose();
                MessageBox.Show("Удаление прошло успешно", "Выполнено");
                selectedId = 0;
                JewerlyShopEntities db = new JewerlyShopEntities();
                СlientGrid.ItemsSource = db.Clients.Select(x => new
                {
                    id = x.Id,
                    FIO = x.FIO,
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

            var query = db.Clients.ToList();
            СlientGrid.ItemsSource = query;

            Clients[] clients = db.Clients
                .Where(x => x.FIO.ToLower().StartsWith(text) || x.Phone.ToLower().StartsWith(text)).ToArray();

            СlientGrid.ItemsSource = clients
                .Select(a => new ClientsView
                {
                    id = a.Id,
                    FIO = a.FIO,
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
