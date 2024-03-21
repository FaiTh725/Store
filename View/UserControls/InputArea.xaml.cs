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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store.View.UserControls
{
    /// <summary>
    /// Interaction logic for InputArea.xaml
    /// </summary>
    public partial class InputArea : UserControl
    {
        public InputArea()
        {
            InitializeComponent();
        }

        public string Description
        {
            get => Txt.Text; set => Txt.Text = value;
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.
            Register("Value", typeof(string), typeof(InputArea), new FrameworkPropertyMetadata());

        public string Value
        {
            get { return (string)GetValue(ValueProperty);}
            set { SetValue(ValueProperty, value); }
        }
    }
}
