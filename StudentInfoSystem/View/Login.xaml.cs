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
using StudentInfoSystem.Model;
using StudentInfoSystem.StylePattern;
using StudentInfoSystem.ViewModel;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginVM loginVM = new LoginVM();
            Title = loginVM.Title;
        }

        public static void ShowActionErrorMessage(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtName.Text.Trim();
            string password = txtPass.Text.Trim();
            LoginValidation validation = new LoginValidation(username, password, ShowActionErrorMessage);
            User user = new User();
            if (validation.ValidateUserInput(ref user))
            {
                Student student = StudentValidation.GetStudentDataByUser(user);
                MainWindow mainWindow = new MainWindow(student);
                mainWindow.Show();
                Styles.ChosenStyle(this, mainWindow);
                Close();
            }
            else
            {
                ClearControls();
            }
        }

        private void ClearControls()
        {

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox && item != errMsg)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void styleOne_Click(object sender, RoutedEventArgs e)
        {
            Styles.DefaultStyle(this);
        }
        private void styleTwo_Click(object sender, RoutedEventArgs e)
        {
            Styles.GrayStyle(this);
        }
        private void styleThree_Click(object sender, RoutedEventArgs e)
        {
            Styles.DarkSlateStyle(this);
        }       
    }
}
