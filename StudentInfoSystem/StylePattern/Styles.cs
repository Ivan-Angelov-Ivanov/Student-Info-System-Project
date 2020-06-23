using StudentInfoSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem.StylePattern
{
    class Styles
    {
        static public void DefaultStyle(Login login)
        {
            login.MainGrid.Style = (Style)Application.Current.Resources["DefaultStyle"];
            login.GroupBox.Style = (Style)Application.Current.Resources["GroupBoxDefault"];
            login.loginBtn.Style = (Style)Application.Current.Resources["DefaultBtn"];
            foreach (Label l in login.SubGrid.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["BlackTextStyle"];
            }
            foreach (TextBox tb in login.SubGrid.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["DefaultTextBox"];
            }
        }

        static public void GrayStyle(Login login)
        {
            login.MainGrid.Style = (Style)Application.Current.Resources["GrayGridStyle"];
            login.GroupBox.Style = (Style)Application.Current.Resources["GroupBoxStyle"];
            login.loginBtn.Style = (Style)Application.Current.Resources["GrayBtn"];
            foreach (Label l in login.SubGrid.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (TextBox tb in login.SubGrid.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["GrayTextBox"];
            }
        }

        static public void DarkSlateStyle(Login login)
        {
            login.MainGrid.Style = (Style)Application.Current.Resources["DarkGridStyle"];
            login.GroupBox.Style = (Style)Application.Current.Resources["GroupBoxStyle"];
            login.loginBtn.Style = (Style)Application.Current.Resources["DarkBtn"];
            foreach (Label l in login.SubGrid.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (TextBox tb in login.SubGrid.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["DarkTextBox"];
            }
        }

        static public void MainWindowGrayStyle(MainWindow mainWindow)
        {
            mainWindow.MainGrid.Style = (Style)Application.Current.Resources["GrayGridStyle"];
            mainWindow.status.Style = (Style)Application.Current.Resources["GrayListBox"];
            foreach (Label l in mainWindow.Names.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (Label l in mainWindow.StudentInfo.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (TextBox tb in mainWindow.Names.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["GrayTextBox"];
            }
            foreach (TextBox tb in mainWindow.StudentInfo.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["GrayTextBox"];
            }
            foreach (GroupBox gb in mainWindow.MainGrid.Children.OfType<GroupBox>())
            {
                gb.Style = (Style)Application.Current.Resources["GroupBoxStyle"];
            }
            foreach (Button b in mainWindow.MainGrid.Children.OfType<Button>())
            {
                b.Style = (Style)Application.Current.Resources["GrayBtn"];
            }
        }

        static public void MainWindowDarkSlateStyle(MainWindow mainWindow)
        {
            mainWindow.MainGrid.Style = (Style)Application.Current.Resources["DarkGridStyle"];
            mainWindow.status.Style = (Style)Application.Current.Resources["DarkListBox"];
            foreach (Label l in mainWindow.Names.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (Label l in mainWindow.StudentInfo.Children.OfType<Label>())
            {
                l.Style = (Style)Application.Current.Resources["WhiteTextStyle"];
            }
            foreach (TextBox tb in mainWindow.Names.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["DarkTextBox"];
            }
            foreach (TextBox tb in mainWindow.StudentInfo.Children.OfType<TextBox>())
            {
                tb.Style = (Style)Application.Current.Resources["DarkTextBox"];
            }
            foreach (GroupBox gb in mainWindow.MainGrid.Children.OfType<GroupBox>())
            {
                gb.Style = (Style)Application.Current.Resources["GroupBoxStyle"];
            }
            foreach (Button b in mainWindow.MainGrid.Children.OfType<Button>())
            {
                b.Style = (Style)Application.Current.Resources["DarkBtn"];
            }
        }

        static public MainWindow ChosenStyle(Login login, MainWindow mainWindow)
        {
            if (login.MainGrid.Style == (Style)Application.Current.Resources["GrayGridStyle"])
            {
                MainWindowGrayStyle(mainWindow);
                return mainWindow;
            }
            else if (login.MainGrid.Style == (Style)Application.Current.Resources["DarkGridStyle"])
            {
                MainWindowDarkSlateStyle(mainWindow);
                return mainWindow;
            }
            else
            {
                return mainWindow;
            }
        }
    }
}
