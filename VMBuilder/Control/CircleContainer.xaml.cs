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

namespace VMBuilder.Control
{
    /// <summary>
    /// Interaction logic for CircleContainer.xaml
    /// </summary>
    public partial class CircleContainer : UserControl
    {
        public CircleContainer()
        {
            InitializeComponent();
        }

        public ImageSource img
        {
            set { this.Image.Source = value; }
            get { return this.Image.Source; }
        }


        public Brush InitialColor
        {

            set { this.Resources["InitColor"] = value; }
            get { return (Brush)this.Resources["InitColor"]; }
        }

        public Brush MouseOverColor
        {

            set { this.Resources["MouseOverColor"] = value; } // will have to look into how to databind this.
            get { return (Brush)this.Resources["MouseOverColor"]; }
        }

        public double ImgSize
        {
            get { return Image.Height; }
            set
            {
                Image.Height = value;
                Image.Width = value;
            }
        }


    }
}
