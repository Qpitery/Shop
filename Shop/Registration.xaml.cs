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
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        user06Context db = new user06Context(); 
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Text.Trim();
            int role;
            Autorisation user = db.Autorisation.Include(s => s.Role).FirstOrDefault(s => s.Login == login && s.Password == password && s.RoleId == 2);
            Autorisation admin = db.Autorisation.Include(s => s.Role).FirstOrDefault(s => s.Login == login && s.Password == password && s.RoleId == 1);
            if (user != null && user.RoleId == 2)
            {
                role = 2;
                MainWindow mainWindow = new MainWindow(role);
                mainWindow.Show();
               
                Close();
            }
            else if (admin != null && admin.RoleId == 1)
            {
                role = 1;
                MainWindow mainWindow = new MainWindow(role);
                mainWindow.Show();
              
                Close();
                

            }
            else
            {
                MessageBox.Show("Ты ошибся");
            }
        }
    }
}
