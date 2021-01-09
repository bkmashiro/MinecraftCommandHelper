using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MinecraftCommandHelper
{
    /// <summary>
    /// BBCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class BBCtrl : UserControl
    {
        public BBCtrl(string c1, string c2, string tb, BuildingBlock b)
        {

            InitializeComponent();
            t1.Text = tb;

            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            p1.Data = (Geometry)converter.ConvertFrom(c1);
            p2.Data = GetReverse((Geometry)converter.ConvertFrom(c2));
            bb = b;


            Panel.SetZIndex(this, 1);

        }
        public BBCtrl(string c1, string c2, string tb, BuildingBlock b, NBT Nbt)
        {

            InitializeComponent();
            t1.Text = tb;

            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            p1.Data = (Geometry)converter.ConvertFrom(c1);
            p2.Data = GetReverse((Geometry)converter.ConvertFrom(c2));
            bb = b;
            Panel.SetZIndex(this, 1);
        }


        BuildingBlock bb = null;
        /// <summary>
        /// 获取g的反向图形
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public Geometry GetReverse(Geometry g)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));

            Geometry Mask = new RectangleGeometry(new Rect(0, 0, 24, 24));
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

            x = e.GetPosition(this).X;
            y = e.GetPosition(this).Y;

            Panel.SetZIndex(this, pv.Canvasindex + 100);



        }

        private void WrapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseLeftDown && e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(this);
                Panel.SetZIndex(this, 100);
                if (this.bb.Father_Node != null)
                {
                    //断开父级对子级的链接
                    this.bb.Father_Node.bBCtrl.v2.Visibility = Visibility.Visible;
                    this.bb.Father_Node.Child_Node = null;
                    //断开子级对父级的链接
                    this.bb.Father_Node = null;
                    this.v1.Visibility = Visibility.Visible;
                }
                if (this.bb.Child_Node != null)
                {
                    //断开子级与当前的链接
                    this.bb.Child_Node.bBCtrl.v1.Visibility = Visibility.Visible;
                    this.bb.Child_Node.Father_Node = null;
                    //断开当前与子级的链接
                    this.bb.Child_Node = null;
                    this.v2.Visibility = Visibility.Visible;
                }
                this.Margin = new Thickness((Margin.Left + p.X - x < 0) ? 0 : Margin.Left + p.X - x, (Margin.Top + p.Y - y) < 0 ? 0 : Margin.Top + p.Y - y, Margin.Right, Margin.Bottom);

                //Console.WriteLine(Margin.Top);
                //Console.WriteLine(this.Margin.Left.ToString()+"--"+this.Margin.Top.ToString());
                // bb.BuildingBlockGroup.Holder.

            }
            else
            {
                MouseLeftDown = false;
            }
        }

        private bool IsNear(BBCtrl b)
        {
            double d = Math.Abs(b.Margin.Top - this.Margin.Top) + Math.Abs(b.Margin.Left + b.ActualWidth - 48 - this.Margin.Left);
            //Console.WriteLine(d);
            if (d < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //private bool IsNear2(BBCtrl b)
        //{
        //    double d = Math.Abs(b.Margin.Top - this.Margin.Top) + Math.Abs(this.Margin.Left+this.ActualWidth-b.Margin.Left+48);
        //    Console.WriteLine(d);
        //    if (d < 50)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void WrapPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseLeftDown = false;
            Panel.SetZIndex(this, 1);
            foreach (var group in bb.BuildingBlockGroup._service.BBGroups)
            {
                foreach (var block in group.buildingBlocks)
                {
                    if (block.bBCtrl != this && IsNear(block.bBCtrl))
                    {
                        if (block.TailShape == this.bb.HeadShape && block.Child_Node == null)
                        {

                            this.v1.Visibility = Visibility.Collapsed;
                            block.bBCtrl.v2.Visibility = Visibility.Collapsed;
                            this.Margin = new Thickness(block.bBCtrl.Margin.Left + block.bBCtrl.ActualWidth - 48 * 2, block.bBCtrl.Margin.Top, block.bBCtrl.Margin.Right, block.bBCtrl.Margin.Bottom);
                            this.bb.Father_Node = block;
                            block.Child_Node = bb;
                            return;
                        }
                    }

                    //if (block.bBCtrl != this && IsNear2(block.bBCtrl))
                    //{
                    //    if (block.HeadShape == this.bb.TailShape)
                    //    {
                    //        this.v2.Visibility = Visibility.Collapsed;
                    //        block.bBCtrl.v1.Visibility = Visibility.Collapsed;
                    //        this.Margin = new Thickness(block.bBCtrl.Margin.Left + block.bBCtrl.ActualWidth + 48 * 2, block.bBCtrl.Margin.Top, block.bBCtrl.Margin.Right, block.bBCtrl.Margin.Bottom);
                    //        return;
                    //    }
                    //}
                }
            }
        }

        private void WrapPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            this.Margin = new Thickness(Margin.Left + p.X - x, Margin.Top + p.Y - y, Margin.Right, Margin.Bottom);
        }

        private void WrapPanel_Loaded(object sender, RoutedEventArgs e)
        {
            g.Width = v1.ActualWidth + v2.ActualWidth + t1.ActualWidth;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            v2.Margin = new Thickness(v1.ActualWidth + t1.ActualWidth, v2.Margin.Top, v2.Margin.Right, v2.Margin.Bottom);
            g.Width = v1.Width + v2.Width + t1.Width;
            this.Width = v1.Width + v2.Width + t1.Width;
        }





    }
}
