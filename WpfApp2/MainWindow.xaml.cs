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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, KeyValuePair<string, double>> work_list;
        Button[,] buttons;

        private void Border()
        {
            for (int _i = 0; _i < 4; _i++)
                for (int _j = 0; _j < 4; _j++)
                {
                    var B1 = new Border();
                    B1.BorderBrush = Brushes.DimGray;
                    B1.BorderThickness = new Thickness(1);
                    user_grid.Children.Add(B1);
                    Grid.SetRow(B1, _i);
                    Grid.SetColumn(B1, _j);
                }
        }

        private void Button()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (buttons[i, j] != null)
                    {
                        user_grid.Children.Add(buttons[i, j]);
                        Grid.SetRow(buttons[i, j], i);
                        Grid.SetColumn(buttons[i, j], j);
                    }
                }
        }

        private void Create()
        {
            var rand = new Random();
            int i = rand.Next(0, 3);
            int j = rand.Next(0, 3);
            int tmp = rand.Next(100);

            while (buttons[i, j] != null)
            {
                i = rand.Next(0, 3);
                j = rand.Next(0, 3);
            }

            buttons[i, j] = new Button();
            buttons[i, j].Name = $"Button{i + j}";
            if (tmp >= 90)
                buttons[i, j].Content = "4";
            else
                buttons[i, j].Content = "2";
        }

        public MainWindow()
        {
            InitializeComponent();
            Border();
            buttons = new Button[4, 4];
            Create();
            Button();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                bool tmp = true;
                while (tmp)
                {
                    int k = 0;
                    for(int i = 0; i < 4; i++)
                        for(int j = 0; j < 3; j++)
                        {
                            if (buttons[i, j] != null && buttons[i, j + 1] == null)
                            {
                                buttons[i, j + 1] = buttons[i, j];
                                buttons[i, j] = null;
                            }
                            else if (buttons[i, j] != null && buttons[i, j + 1] != null)
                                if (buttons[i, j].Content == buttons[i, j + 1].Content)
                                {
                                    buttons[i, j].Content = Convert.ToString(Convert.ToInt32(buttons[i, j].Content) * 2);
                                    buttons[i, j + 1] = null;
                                    k++;
                                }
                        }

                    if (k == 0)
                        tmp = false;
                }
            }
            else if (e.Key == Key.Left)
            {
                bool tmp = true;
                while (tmp)
                {
                    int k = 0;
                    for (int i = 0; i < 4; i++)
                        for (int j = 3; j > 0; j--)
                        {
                            if (buttons[i, j] != null && buttons[i, j - 1] == null)
                            {
                                buttons[i, j - 1] = buttons[i, j];
                                buttons[i, j] = null;
                            }
                            else if (buttons[i, j] != null && buttons[i, j + 1] != null)
                                if (buttons[i, j].Content == buttons[i, j - 1].Content)
                                {
                                    buttons[i, j].Content = Convert.ToString(Convert.ToInt32(buttons[i, j].Content) * 2);
                                    buttons[i, j - 1] = null;
                                    k++;
                                }
                        }

                    if (k == 0)
                        tmp = false;
                }
            }
            else if (e.Key == Key.Down)
            {
                bool tmp = true;
                while (tmp)
                {
                    int k = 0;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 4; j++)
                        {
                            if (buttons[i, j] != null && buttons[i + 1, j] == null)
                            {
                                buttons[i + 1, j] = buttons[i, j];
                                buttons[i, j] = null;
                            }
                            else if (buttons[i, j] != null && buttons[i + 1, j] != null)
                                if (buttons[i, j].Content == buttons[i + 1, j].Content)
                                {
                                    buttons[i, j].Content = Convert.ToString(Convert.ToInt32(buttons[i, j].Content) * 2);
                                    buttons[i + 1, j] = null;
                                    k++;
                                }
                        }

                    if (k == 0)
                        tmp = false;
                }
            }
            else if (e.Key == Key.Up)
            {
                bool tmp = true;
                while (tmp)
                {
                    int k = 0;
                    for (int i = 3; i > 0; i--)
                        for (int j = 0; j < 4; j++)
                        {
                            if (buttons[i, j] != null && buttons[i - 1, j] == null)
                            {
                                buttons[i - 1, j] = buttons[i, j];
                                buttons[i, j] = null;
                            }
                            else if (buttons[i, j] != null && buttons[i - 1, j] != null)
                                if (buttons[i, j].Content == buttons[i - 1, j].Content)
                                {
                                    buttons[i, j].Content = Convert.ToString(Convert.ToInt32(buttons[i, j].Content) * 2);
                                    buttons[i - 1, j] = null;
                                    k++;
                                }
                        }

                    if (k == 0)
                        tmp = false;
                }
            }

            Create();
            user_grid.Children.Clear();
            Border();
            Button();
        }
    }
}
