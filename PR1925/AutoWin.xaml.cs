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
using System.Windows.Threading;

namespace PR1925
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsersEntities usersEntities = new UsersEntities();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            CheckData();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.ShowDialog();
        }

        public void CheckData()
        {

            var check= usersEntities.users.FirstOrDefault(x => x.login == loginTextBox.Text && x.password == passwordTextBox.Password);
            if (check == null)
            {
                MessageBox.Show("Неверно введен логин или пароль");
            }
            else
            {
                UsersWindow usersWindow = new UsersWindow(check);
                usersWindow.Show();
               this.Close();
            }
        }
    }
}
