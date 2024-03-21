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
    }
}
