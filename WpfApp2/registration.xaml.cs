using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Dictionary<string, string> users = new Dictionary<string, string>();
        private string[] Init()
        {
            string[] tmp = new string[2];
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("users.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                
                int i = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        tmp[i] = reader.Value;
                        i++;
                    }
                }
                return tmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return tmp;
        }

        private void Create_user()
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("users.xml", System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Users");
                writer.WriteStartElement($"User");
                writer.WriteElementString("User_name", login.Text);
                writer.WriteElementString("Password", password.Password);
                writer.WriteElementString($"Highscore-{login.Text}", "0");
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

        }

        public Window1()
        {
            InitializeComponent();
            Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] tmp = Init();
            if (tmp[0] == login.Text.ToString() && tmp[1] == password.Password.ToString())
            {
               if(remember.IsChecked.Value)
                    using (StreamWriter writer = new StreamWriter($"set.ini", false, Encoding.UTF8))
                    {
                        writer.WriteLine("true");
                        writer.WriteLine($"{login.Text}");
                        writer.WriteLine("0");
                    }
               else
                    using (StreamWriter writer = new StreamWriter($"set.ini", false, Encoding.UTF8))
                    {
                        writer.WriteLine("false");
                        writer.WriteLine($"{login.Text}");
                        writer.WriteLine("0");
                    }
                Window temp = this.OwnedWindows[0];
                temp.Show();
                temp.Owner = null;
                this.Close();
            }
            else
                Create_user();
        }
    }
}
