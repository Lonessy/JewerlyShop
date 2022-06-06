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
    /// Логика взаимодействия для AddProvidersWindow.xaml
    /// </summary>
    public partial class AddProvidersWindow : Window
    {
        int id = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public AddProvidersWindow()
        {
            InitializeComponent();
            this.Title = "Добавление поставщика";
            SaveButton.Click += SaveButton_Click;
        }
        public AddProvidersWindow(int id)
        {
            InitializeComponent();
            this.Title = "Редактирование поставщика";
            this.id = id;
            var Providers = db.Providers.Find(id);
            AddName.Text = Providers.Name;
            AddCity.Text = Providers.City;
            AddAdres.Text = Providers.Address;
            AddPhone.Text= Providers.Phone.ToString();

            SaveButton.Click += EditSaveButton_Click;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Providers prov = new Providers
            {
                Name = AddName.Text,
                City = AddCity.Text,
                Address = AddAdres.Text,
                Phone = AddPhone.Text
            };
            db.Providers.Add(prov);
            db.SaveChanges();
            MessageBox.Show("Выполнено!");
            this.Close();
        }

        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var item = db.Providers.Find(id);
            item.Name = AddName.Text;
            item.City = AddCity.Text;
            item.Address = AddAdres.Text;
            item.Phone = AddPhone.Text;
            db.SaveChanges();
            System.Windows.MessageBox.Show("Редактирование выполнено!");
            Close();
        }
    }
}
