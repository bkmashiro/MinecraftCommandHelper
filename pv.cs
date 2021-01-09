using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinecraftCommandHelper
{
    public class pv
    {
        public static ViewMode CurrentView = ViewMode.RichTextView;
        public static RichTextBox cmd_RichTextView = null;
        /// <summary>
        /// 视图模式
        /// </summary>
        public enum ViewMode
        {
            RichTextView,//多彩文本
            ASTView,//语法树视图
            BuildingBlock,//积木视图
            PlainView,//基础文本
            WarpView,//换行分隔文本
        }

        public static Brush color_bool = Brushes.IndianRed;
        public static Brush color_int = Brushes.BlueViolet;
        public static Brush color_array = Brushes.OrangeRed;
        public static Brush color_string = Brushes.DeepSkyBlue;
        public static Brush color_byte = Brushes.DeepPink;
        public static Brush color_UUID = Brushes.Firebrick;
        public static Brush color_command = Brushes.Goldenrod;
        public static Brush color_selector = Brushes.Cyan;
        public static Brush color_odd = Brushes.Black;

        public static Size building_block_size = new Size(70,50);

        public static int Canvasindex = 1;



    }
}
