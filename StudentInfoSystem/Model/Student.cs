using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    public class Student
    {
        /*public String name;
        public String surname;
        public String lastName;
        public String faculty;
        public String specialityiality;
        public String degree;
        public String status;
        public String fakNum;
        public String course;
        public int studFlow;
        public int group;*/

        public int StudentId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastName { get; set; }
        public string faculty { get; set; }
        public string speciality { get; set; }
        public string degree { get; set; }
        public string status { get; set; }
        public string fakNum { get; set; }
        public string course { get; set; }
        public int studFlow { get; set; }
        public int group { get; set; }

        public Student() { }
        public Student(string name, string surname, string lastName, string faculty, string speciality, string degree, string status, string fakNum, string course, int studFlow, int group)
        {
            this.name = name;
            this.surname = surname;
            this.lastName = lastName;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.status = status;
            this.fakNum = fakNum;
            this.course = course;
            this.studFlow = studFlow;
            this.group = group;
        }
    }
}
