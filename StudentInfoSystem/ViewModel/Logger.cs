using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.ViewModel
{
    static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now.ToString("dd.MM.yyyy") + "\n" + LoginValidation.currentUserUsername + "\n" + LoginValidation.currentUserRole + "\n" + activity + "\n\n";
            currentSessionActivities.Add(activityLine);
            if (File.Exists("C:/Users/Ivan/Desktop/PS_39_Ivan/UserLogin/log.txt") == true)
            {
                File.AppendAllText("C:/Users/Ivan/Desktop/PS_39_Ivan/UserLogin/log.txt", activityLine);
            }
        }

        static public String GetCurrentSessionActivities()
        {
            UserContext context = new UserContext();
            foreach(string activity in currentSessionActivities)
            {
                Logs currentLog = new Logs(activity);
                context.UserLogs.Add(currentLog);
            }
            context.SaveChanges();
            return currentSessionActivities[currentSessionActivities.Count -1];
        }

        static public void CountLatestLogins(String name)
        {
            int loginCount = 0;
            List<string> allLines = File.ReadAllLines("C:/Users/Ivan/Desktop/PS_39_Ivan/UserLogin/log.txt").ToList();
            for(var i=0; i < allLines.Count-1; i++)
            {
                Match match = Regex.Match(allLines[i], @"\d{2}\/\d{2}\/\d{4}");
                string date = match.Value;
                if(allLines[i].Contains(date) && allLines[i+1].Contains(name) && allLines[i+3].Contains("Успешен Login"))
                {                    
                    DateTime dateTime = DateTime.ParseExact(allLines[i], "dd.MM.yyyy", CultureInfo.CurrentCulture);
                    if (dateTime.Year == DateTime.Now.Year && dateTime.Month == DateTime.Now.Month && dateTime > DateTime.Now.AddDays(-2))
                    {
                        loginCount++;
                    }
                }
            }
            
           Console.WriteLine("Брой посещения за последните два дена: " + loginCount);

        }
    }
}
