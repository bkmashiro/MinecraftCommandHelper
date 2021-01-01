using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MinecraftCommandHelper
{
    /// <summary>
    /// BBCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class BBCtrl : UserControl
    {
        public BBCtrl(string c1, string c2,string tb)
        {
            InitializeComponent();
            t1.Text = tb;

            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            p1.Data = (Geometry)converter.ConvertFrom(c1);
            p2.Data = GetReverse((Geometry)converter.ConvertFrom(c2));
            
            
        }
        public Geometry GetReverse(Geometry g)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));

            Geometry Mask = new RectangleGeometry(new Rect(0,0,24,24));
            CombinedGeometry combinedGeometry = new CombinedGeometry(g, Mask);
            combinedGeometry.GeometryCombineMode = GeometryCombineMode.Xor;

            return combinedGeometry;
        }
        bool MouseLeftDown = false;
        double x;
        double y;
        private void WrapPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftDown = true;
            x= e.GetPosition(this).X;
            y = e.GetPosition(this).Y;
        }

        private void WrapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseLeftDown&&e.LeftButton==MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(this);
                this.Margin = new Thickness(Margin.Left+p.X-x, (Margin.Top + p.Y - y)<0?0: (Margin.Top + p.Y - y), Margin.Right,Margin.Bottom);
                //Console.WriteLine(Margin.Top);
            }
            else
            {
                MouseLeftDown = false;
            }
        }

        private void WrapPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseLeftDown = false;

        }

        private void WrapPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            this.Margin = new Thickness(Margin.Left + p.X - x, (Margin.Top + p.Y - y) < 0 ? 0 : (Margin.Top + p.Y - y), Margin.Right, Margin.Bottom);
        }
    }
}
