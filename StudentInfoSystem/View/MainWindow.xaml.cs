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
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel;
using StudentInfoSystem.Model;
using StudentInfoSystem.ViewModel;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login window = new Login();
        //public List<string> StudStatusChoices { get; set; }
        public Student currStud {get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //FillStudStatusChoices();
        }


        public MainWindow(object data) : this()
        {
            MainWindowVM mainWindowVM = new MainWindowVM();
            mainWindowVM.CurrentStudent = (Student)data;
            Title = mainWindowVM.Title;
            this.DataContext = mainWindowVM;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {

            foreach (Control ctl in Names.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).Text = String.Empty;
                }
            }
            foreach (Control ctl in StudentInfo.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).Text = String.Empty;
                }
            }
        }

        private void disable_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in Names.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).IsEnabled = false;
                }
            }
            foreach (Control ctl in StudentInfo.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).IsEnabled = false;
                }
            }
        }

        private void enable_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in Names.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).IsEnabled = true;
                }
            }
            foreach (Control ctl in StudentInfo.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).IsEnabled = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            window.Owner = this;
        }        
        
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.Students.FirstOrDefault();
            context.SaveChanges();
        }
        public void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (User testUser in UserData.TestUsers)
            {
                context.Users.Add(testUser);
            }
            context.SaveChanges();
        }
        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(TestStudentsIfEmpty());
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
            if (TestUsersIfEmpty())
            {
                CopyTestUsers();
            }
        }
    }
}
