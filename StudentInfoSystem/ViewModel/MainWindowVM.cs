using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using StudentInfoSystem.Model;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Student _student;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return "Студентска информационна система"; }
        }
        public List<string> StudStatusChoices { get; set; }
        public Student CurrentStudent
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged("CurrentStudent");
                    FillStudStatusChoices();
                }
            }
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            StudentInfoContext context = new StudentInfoContext();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
