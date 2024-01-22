using Microsoft.EntityFrameworkCore;
using Shop.DB;
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

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        user06Context db = new user06Context();

        public int piska;
        public MainWindow(int role2)

        {

            InitializeComponent();
            piska = role2;
            Update();
            
            if (role2 == 1) 
            {
                MessageBox.Show("ты admin");
                FilterPanel.Visibility = Visibility.Hidden;
            }
           if(role2 == 2)
            {
                MessageBox.Show("ты user");
            
            }
 
        }

        private void select1(object sender, SelectionChangedEventArgs e)
        {
            Category categoryFilter = FilterCategory.SelectedItem as Category;
            Manufacture manufactureFilter = FilterManufacture.SelectedItem as Manufacture;
            
            if (manufactureFilter == null)
            {
                MainList.ItemsSource = db.Product.Include(s => s.Category).Where(s => s.Category == categoryFilter).Include(s => s.Manufacture).ToList();
            }
            else
            {
                MainList.ItemsSource = db.Product.Include(s => s.Category).Include(s => s.Manufacture).Where(s => s.Category == categoryFilter && s.Manufacture == manufactureFilter).ToList();
            }
        }

        private void select2(object sender, SelectionChangedEventArgs e)
        {
            Manufacture manufactureFilter = FilterManufacture.SelectedItem as Manufacture;
            Category categoryFilter = FilterCategory.SelectedItem as Category;
            if (categoryFilter == null)
            {
                MainList.ItemsSource = db.Product.Include(s => s.Category).Where(s => s.Manufacture == manufactureFilter).Include(s => s.Manufacture).ToList();
            }
            else
            {
                MainList.ItemsSource = db.Product.Include(s => s.Category).Include(s => s.Manufacture).Where(s => s.Category == categoryFilter && s.Manufacture == manufactureFilter).ToList();
            }
        }

        private void ButtonFilterClear(object sender, RoutedEventArgs e)
        {

            FilterCategory.ItemsSource = null;
            FilterManufacture.ItemsSource = null;
            Update();
        }

        protected void Update()
        {
            MainList.ItemsSource = db.Product.Include(s => s.Category).Include(s => s.Manufacture).ToList();
            FilterCategory.ItemsSource = db.Category.ToList();
            FilterManufacture.ItemsSource = db.Manufacture.ToList();
           
          
        }

        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
