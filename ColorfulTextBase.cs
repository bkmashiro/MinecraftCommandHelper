using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace MinecraftCommandHelper
{
    /// <summary>
    /// 提供彩色文本的生成服务
    /// </summary>
    class ColorfulTextBase
    {

        public Run GetRun(Brush brush,string content)
        {
            Run run = new Run(content);
            run.Foreground = Brushes.Aqua;
            return run;

        }
    }
}
