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
using Microsoft.Win32;

namespace JewerlyShop
{
    /// <summary>
    /// Логика взаимодействия для AddProductsWindow.xaml
    /// </summary>
    public partial class AddProductsWindow : Window
    {
        int id = 0;
        private byte[] newByteImage;
        string pathImage;
        string PathImage
        {
            get
            {
                return pathImage;
            }
            set
            {
                pathImage = value;
            }
        }
        string sPathImage
        {
            get
            {
                return pathImage.Substring(1);
            }
        }
        JewerlyShopEntities db = new JewerlyShopEntities();
        public AddProductsWindow()
        {
            InitializeComponent();
            AddTypeProduct();
            AddMaterials();
            AddProviders();
            this.Title = "Добавление товара";
            SaveButton.Click += SaveButton_Click;
        }
        public AddProductsWindow(int id)
        {
            InitializeComponent();
            AddTypeProduct();
            AddMaterials();
            AddProviders();
            this.Title = "Редактирование товара";
            this.id = id;
            var Products = db.Products.Find(id);
            AddName.Text = Products.Name;
            AddType.SelectedValue = Products.IdTypeProducts;
            AddMaterial.SelectedValue = Products.IdMaterial;
            AddWeight.Text = Products.Weight.ToString();
            AddProba.Text = Products.Proba.ToString();
            AddSize.Text = Products.Size.ToString();
            AddPurchase.Text = Products.PurchasePrice.ToString();
            AddPrice.Text = Products.Price.ToString();
            AddProvider.SelectedValue = Products.IdProvider;
            AddVolume.Text = Products.Volume.ToString();
            SaveButton.Click += EditSaveButton_Click;
        }
        public void AddTypeProduct()
        {
            InitializeComponent();
            var result = from type in db.TypeProducts
                         select new
                         {
                             id = type.Id,
                             name = type.Name
                         };
            AddType.ItemsSource = result.ToList();
            AddType.SelectedValuePath = "id";
            AddType.DisplayMemberPath = "name";
        }
        public void AddMaterials()
        {
            InitializeComponent();
            var result = from type in db.Materials
                         select new
                         {
                             id = type.Id,
                             name = type.Name
                         };
            AddMaterial.ItemsSource = result.ToList();
            AddMaterial.SelectedValuePath = "id";
            AddMaterial.DisplayMemberPath = "name";
        }
        public void AddProviders()
        {
            InitializeComponent();
            var result = from type in db.Providers
                         select new
                         {
                             id = type.Id,
                             name = type.Name
                         };
            AddProvider.ItemsSource = result.ToList();
            AddProvider.SelectedValuePath = "id";
            AddProvider.DisplayMemberPath = "name";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Products x = new Products
            {
                Id = db.Products.ToList().Max(point => point.Id) + 1,
                Name = AddName.Text,
                IdTypeProducts = (int)AddType.SelectedValue,
                IdMaterial = (int)AddMaterial.SelectedValue,
                Weight = Convert.ToDecimal(AddWeight.Text),
                Proba = Convert.ToInt32(AddProba.Text),
                Size = Convert.ToDecimal(AddSize.Text),
                PurchasePrice = Convert.ToInt32(AddPurchase.Text),
                Price = Convert.ToInt32(AddPrice.Text),
                IdProvider = (int)AddProvider.SelectedValue,
                Volume = Convert.ToInt32(AddVolume.Text),
                ImageProduct = Convert.ToString(PhotoTextBox.Content),
            };

            db.Products.Add(x);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Добавление выполнено!");
            Close();
        }
        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var item = db.Products.Find(id);
            item.Name = AddName.Text;
            item.IdTypeProducts = (int)AddType.SelectedValue;
            item.IdMaterial = (int)AddMaterial.SelectedValue;
            item.Weight = Convert.ToDecimal(AddWeight.Text);
            item.Proba = Convert.ToInt32(AddProba.Text);
            item.Size = Convert.ToDecimal(AddSize.Text);
            item.PurchasePrice = Convert.ToInt32(AddPurchase.Text);
            item.Price = Convert.ToInt32(AddPrice.Text);
            item.IdProvider = (int)AddProvider.SelectedValue;
            item.Volume = Convert.ToInt32(AddVolume.Text);
            item.ImageProduct = Convert.ToString(PhotoTextBox.Content);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Редактирование выполнено!");
            Close();
        }
        private void ImageChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string[] extensions = { ".jpg", ".bmp", ".png", ".jpeg" };
            if (ofd.ShowDialog() == true)
            {

                if (extensions.Contains(System.IO.Path.GetExtension(ofd.FileName)))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        newByteImage = new byte[fs.Length];
                        fs.Read(newByteImage, 0, newByteImage.Length);
                    }

                    MemoryStream ms = new MemoryStream(newByteImage);

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.EndInit();

                    PhotoImageBox.Source = image;
                    PhotoTextBox.Content = ofd.FileName;

                    PathImage = "\\Products\\" + System.IO.Path.GetFileName(ofd.FileName);

                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    using (FileStream stream = new FileStream(PathImage.Substring(1), FileMode.Create)) encoder.Save(stream);
                }
                else
                {
                    MessageBox.Show("Выбранный файл не является изображением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }  
    }
}
