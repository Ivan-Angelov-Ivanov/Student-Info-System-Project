using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    class StudentData
    {
        static private List<Student> _testStudents;
        static public List<Student> TestStudents
        {
            get 
            {
                ResetTestStudentData(); 
                return _testStudents;
            }
            private set => _testStudents = value; 
        }
        static private void ResetTestStudentData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>();
                _testStudents.Add(new Student("Иван", "Ангелов", "Иванов", "ФКСТ", "КСИ", "Бакалавър", "Заверил", "121217003", "Tрети", 9, 39));

            }

        }
    }
}
