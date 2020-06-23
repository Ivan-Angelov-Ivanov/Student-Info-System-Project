using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.ViewModel
{
    public class LoginValidation
    {
        private String username;
        private String password;
        private String errorMsg;

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError action;

        public LoginValidation(String username, String password, ActionOnError action)
        {
            this.username = username;
            this.password = password;
            this.action = action;
        }
      
        static public UserRoles currentUserRole { get; private set; }
        static public String currentUserUsername { get; private set; }

        public bool ValidateUserInput(ref User user)
        {
            if (username.Length < 5 || password.Length < 5)
            {
                errorMsg = "Потребитеслкото име или парола са твърде къси.";
                action(errorMsg);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserUsername = user.username;
                currentUserRole = (UserRoles)user.role;
                Logger.LogActivity("Успешен Login");
                
                Logger.CountLatestLogins(user.username);
                return true;
            }

            errorMsg = "Потребителят не съществува.";
            currentUserRole = UserRoles.ANONYMOUS;

            action(errorMsg);
            Console.WriteLine(currentUserRole);

            return false;
        }
    }
}
