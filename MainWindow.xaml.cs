using System;
using System.Windows;

namespace MinecraftCommandHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainwindow_Loaded(object sender, RoutedEventArgs e)
        {
            cmd.Content = new RichTextView();



            Entities.Entities entities = new Entities.Entities();
            Entities.mobs mobs = new Entities.mobs();
            Entities.Feedable feedable = new Entities.Feedable();


        }
    }
}
