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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColumnDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                maximizeImg.Source = new BitmapImage(new Uri("\\View\\Images\\Head\\Normalize.png", UriKind.Relative));
            }
            else
            {
                maximizeImg.Source = new BitmapImage(new Uri("\\View\\Images\\Head\\Maximize.png", UriKind.Relative));
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is RadioButton btn && btn.Content is string content)
            {
                if(content == "Главная")
                {
                    Main.Visibility = Visibility.Visible;
                    AddProduct.Visibility = Visibility.Hidden;
                    About.Visibility = Visibility.Hidden;
                    RedactProduct.Visibility = Visibility.Hidden;
                }
                else if(content == "Добавить")
                {
                    AddProduct.Visibility = Visibility.Visible;
                    About.Visibility = Visibility.Hidden;
                    Main.Visibility = Visibility.Hidden;
                    RedactProduct.Visibility = Visibility.Hidden;
                }
                else if(content == "Сведения")
                {
                    About.Visibility = Visibility.Visible;
                    AddProduct.Visibility = Visibility.Hidden;
                    Main.Visibility = Visibility.Hidden;
                    RedactProduct.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(baseViewModel.SelectedProduct != null)
            {
                About.Visibility = Visibility.Hidden;
                AddProduct.Visibility = Visibility.Hidden;
                Main.Visibility = Visibility.Hidden;

                RedactProduct.Visibility = Visibility.Visible;

                rBtnMain.IsChecked = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            RedactProduct.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            RedactProduct.Visibility = Visibility.Hidden;
        }
    }
}
