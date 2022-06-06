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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
