
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

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для AddSalesWindow.xaml
    /// </summary>
    public partial class AddSalesWindow : Window
    {
        int id = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public AddSalesWindow()
        {
            InitializeComponent();
            AddProducts();
            AddClients();
            this.Title = "Добавление продажи";
            SaveButton.Click += SaveButton_Click;
        }
        public AddSalesWindow(int id)
        {
            InitializeComponent();
            AddProducts();
            AddClients();
            this.Title = "Редактирование продажи";
            this.id = id;
            var Sales = db.Sales.Find(id);
            AddProduct.SelectedValue = Sales.IdProduct;
            AddClient.SelectedValue = Sales.IdClient;
            AddDateTime.Text = Sales.DateSale.ToString();
            AddPrice.Text = Sales.Price.ToString();
            AddCount.Text = Sales.Count.ToString();

            SaveButton.Click += EditSaveButton_Click;
        }
        public void AddProducts()
        {
            InitializeComponent();
            var result = from prod in db.Products
                         select new
                         {
                             id = prod.Id,
                             name = prod.Name
                         };
            AddProduct.ItemsSource = result.ToList();
            AddProduct.SelectedValuePath = "id";
            AddProduct.DisplayMemberPath = "name";
        }
        public void AddClients()
        {
            InitializeComponent();
            var result = from client in db.Clients
                         select new
                         {
                             id = client.Id,
                             name = client.FIO
                         };
            AddClient.ItemsSource = result.ToList();
            AddClient.SelectedValuePath = "id";
            AddClient.DisplayMemberPath = "name";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Sales x = new Sales
            {
               IdProduct  = (int)AddProduct.SelectedValue,
               IdClient = (int)AddClient.SelectedValue,
               DateSale = Convert.ToDateTime(AddDateTime.Text),
               Price = Convert.ToInt32(AddPrice.Text),
               Count = Convert.ToInt32(AddCount.Text)
            };
            var product = db.Products.FirstOrDefault(a => a.Id == x.IdProduct);
            product.Volume = product.Volume - x.Count;
            db.Sales.Add(x);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Выполнено!");
            this.Hide();
        }
        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var item = db.Sales.Find(id);
            var product = db.Products.FirstOrDefault(a => a.Id == item.IdProduct);
            product.Volume = product.Volume + item.Count;
            item.IdProduct = (int)AddProduct.SelectedValue;
            item.IdClient = (int)AddClient.SelectedValue;
            item.DateSale = Convert.ToDateTime(AddDateTime.Text);
            item.Price = Convert.ToInt32(AddPrice.Text);
            item.Count = Convert.ToInt32(AddCount.Text);
            product.Volume = product.Volume - item.Count;
            db.SaveChanges();
            System.Windows.MessageBox.Show("Редактирование выполнено!");
            Close();
        }
    }
}
