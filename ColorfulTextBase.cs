using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MinecraftCommandHelper
{
    /// <summary>
    /// 提供彩色文本的生成服务
    /// </summary>
   public class ColorfulTextBase
    {
        

        public Run GetRun(string content, Brush foreground)
        {
            Run run = new Run(content);
            run.Foreground = foreground;
            return run;
        }

        public Run GetRun(string content, Brush foreground, Brush background)
        {
            Run run = new Run(content);
            run.Foreground = foreground;
            run.Background=background;
            return run;
        }



        public void PushRunTo(RichTextBox b,Run run)
        {
            Paragraph para = new Paragraph();
            para.Inlines.Add(run);
            b.Document.Blocks.Add(para);
        }




        public void AutoPush(object statement)
        {

        }








    }
}
