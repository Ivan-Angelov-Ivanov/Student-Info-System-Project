using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Model;

namespace StudentInfoSystem
{
    static public class StudentValidation
    {
        static public Student GetStudentDataByUser(User user)
        {
            if(user.fakNum == null)
            {
                Console.WriteLine("Не сте въвели фак. номер!");
                return null;
            }
            foreach (Student testStudent in StudentData.TestStudents)
            {
                if(user.fakNum != testStudent.fakNum)
                {
                    Console.WriteLine("Студент с такъв факултетен номер не съществува!");
                } 
                else
                {
                    return testStudent;
                }
            }

            return null;
        }
    }
}
