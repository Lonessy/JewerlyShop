using iTextSharp.text;
using iTextSharp.text.pdf;
using JewerlyShop.ModelBase;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        int selectedId = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public ProductsWindow()
        {
            InitializeComponent();
            GetProductViews(db.Products.ToArray());
            List<TypeProducts> typeProducts = db.TypeProducts.ToList();
            TypeProducts allTypes = new TypeProducts { Id = -1, Name = "Все типы" };
            typeProducts = typeProducts.Prepend(allTypes).ToList();
            FilterComboBox.ItemsSource = typeProducts;
            FilterComboBox.SelectedIndex = 0;
        }
        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowMain = new MainWindow();
            this.Close();
            windowMain.ShowDialog();
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

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            String text = SearchText.Text.ToLower();

            var query = db.Products.ToList();
            mainData.ItemsSource = query;

            Products[] products = db.Products
                .Where(x => x.Name.ToLower().StartsWith(text) || x.TypeProducts.Name.ToLower().StartsWith(text) || x.Providers.Name.ToLower().StartsWith(text) || x.Materials.Name.ToLower().StartsWith(text)).ToArray();

            GetProductViews(products);
        }
        public void GetProductViews(Products[] products)
        {
            mainData.ItemsSource = null;
            mainData.Items.Refresh();
            var query = (from x in products
                         select new ProductView
                         {
                             id = x.Id,
                             Provider = x.Providers.Name,
                             TypeProducts = x.TypeProducts.Name,
                             Material = x.Materials.Name,
                             Weight = x.Weight,
                             Proba = x.Proba,
                             PurchasePrice = x.PurchasePrice,
                             Price = x.Price,
                             Name = x.Name,
                             Size = x.Size,
                             Volume = x.Volume,
                             ImageProduct = x.ImageProduct
                         }).ToArray();
            mainData.ItemsSource = query.ToList();
        }
        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductsWindow window = new AddProductsWindow();
            window.ShowDialog();
            JewerlyShopEntities db = new JewerlyShopEntities();
            GetProductViews(db.Products.ToArray());
        }
        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                AddProductsWindow window = new AddProductsWindow(selectedId);
                window.ShowDialog();
                mainData.ItemsSource = null;
                mainData.Items.Refresh();
                JewerlyShopEntities db = new JewerlyShopEntities();
                GetProductViews(db.Products.ToArray());
            }
            else
            {
                MessageBox.Show("Выберите товар в списке", "Внимание");
            }
        }
        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filter(FilterComboBox.SelectedItem as TypeProducts);
        }
        void filter(TypeProducts value)
        {
            if (value.Id == -1)
            {
                GetProductViews(db.Products.ToArray());
            }
            else
            {
                var query = (from x in db.Products.Where(a => a.TypeProducts.Id == value.Id)
                             select new ProductView
                             {
                                 id = x.Id,
                                 Provider = x.Providers.Name,
                                 TypeProducts = x.TypeProducts.Name,
                                 Material = x.Materials.Name,
                                 Weight = x.Weight,
                                 Proba = x.Proba,
                                 PurchasePrice = x.PurchasePrice,
                                 Price = x.Price,
                                 Name = x.Name,
                                 Size = x.Size,
                                 Volume = x.Volume,
                                 ImageProduct = x.ImageProduct
                             }).ToList();
                
                mainData.ItemsSource = query;
            }
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

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            ChoiceReport window = new ChoiceReport();
            window.ShowDialog();
        }
        

        private void mainData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainData.SelectedValue != null)
            {
                System.Type type = mainData.SelectedValue.GetType();
                int ProductId = (int)type.GetProperty("id").GetValue(mainData.SelectedValue, null);

                selectedId = ProductId;
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                JewerlyShopEntities dbremove = new JewerlyShopEntities();
                Products pr = dbremove.Products
               .Where(o => o.Id == selectedId)
               .FirstOrDefault();
                dbremove.Products.Remove(pr);
                dbremove.SaveChanges();
                dbremove.Dispose();
                MessageBox.Show("Удаление прошло успешно", "Выполнено");
                selectedId = 0;
                JewerlyShopEntities db = new JewerlyShopEntities();
                GetProductViews(db.Products.ToArray());
            }
            else
            {
                MessageBox.Show("Выберите товар в списке", "Внимание");
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
