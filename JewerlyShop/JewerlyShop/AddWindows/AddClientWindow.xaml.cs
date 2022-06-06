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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        int id = 0;
        JewerlyShopEntities db = new JewerlyShopEntities();
        public AddClientWindow()
        {
            InitializeComponent();
            this.Title = "Добавление клиента";
            SaveButton.Click += SaveButton_Click;
        }

        public AddClientWindow(int id)
        {
            InitializeComponent();
            this.Title = "Редактирование клиента";
            this.id = id;
            var Providers = db.Clients.Find(id);
            AddName.Text = Providers.FIO;
            AddPhone.Text = Providers.Phone.ToString();

            SaveButton.Click += EditSaveButton_Click;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Clients client = new Clients
            {
                FIO = AddName.Text,
                Phone = AddPhone.Text
            };
            db.Clients.Add(client);
            db.SaveChanges();
            MessageBox.Show("Выполнено!");
            this.Close();
        }

        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var item = db.Clients.Find(id);
            item.FIO = AddName.Text;
            item.Phone = AddPhone.Text;
            db.SaveChanges();
            System.Windows.MessageBox.Show("Редактирование выполнено!");
            Close();
        }
    }
}
