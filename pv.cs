using System.Windows.Controls;

namespace MinecraftCommandHelper
{
    public class pv
    {
        public static ViewMode CurrentView = ViewMode.RichTextView;
        public RichTextBox cmd_RichTextView = null;

        public enum ViewMode
        {
            RichTextView,//多彩文本
            ASTView,//语法树视图
            BuildingBlock,//积木视图
            PlainView,//基础文本
            WarpView,//换行分隔文本
        }







    }
}
