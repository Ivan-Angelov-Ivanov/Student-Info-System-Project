using StudentInfoSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    static public class UserData
    {

        static private List<User> _testUsers;

        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);


                _testUsers.Add(new User 
                { 
                    username = "Pesho",
                    password = "parola",
                    fakNum = "121217003",
                    role = 1,
                    created = DateTime.Now,
                    isActive = DateTime.MaxValue 
                });
                _testUsers.Add(new User
                { 
                    username = "Georgi", 
                    password = "parola", 
                    fakNum = "121217492",
                    role = 4, 
                    created = DateTime.Now, 
                    isActive = DateTime.MaxValue
                });
                _testUsers.Add(new User 
                { 
                    username = "Konstantin",
                    password = "parola", 
                    fakNum = "121217553",
                    role = 4, 
                    created = DateTime.Now,
                    isActive = DateTime.MaxValue 
                });

            }

        }

        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set
            {

            }
        }

        static public User IsUserPassCorrect(String username, String password)
        {
            UserContext context = new UserContext();
            foreach (User testUser in context.Users)
            {
                if (username == testUser.username && password == testUser.password)
                {
                    return testUser;
                }
            }
            return null;
        }

        static public void SetUserActiveTo (String username, DateTime newDate)
        {
            UserContext context = new UserContext();
            foreach (User testUser in context.Users)
            {
                if(username == testUser.username)
                {
                    testUser.isActive = newDate;
                    Logger.LogActivity("Промяна на активност на " + username);
                }
            }
        }

        static public void AssignUserRole (String username, UserRoles newRole)
        {
            UserContext context = new UserContext();
            foreach (User testUser in context.Users)
            {
                if (username == testUser.username)
                {
                    testUser.role = (int)newRole;
                    Logger.LogActivity("Промяна на роля на " + username);
                }
            }
        }
        
    }
}
