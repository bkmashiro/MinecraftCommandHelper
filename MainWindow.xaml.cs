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
            cmd.Content = null;
            cmd.Content = new RichTextView();


            Entities.Entities entities = new Entities.Entities();
            Entities.mobs mobs = new Entities.mobs();
            wp.Content = null;
            wp.Content = new BuildingBlockView();


        }
        Entities.Feedable feedable = new Entities.Feedable();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            feedable.Age = 1;
            feedable.Air = 10;
            feedable.CustomName = "Test Feedable";
            feedable.CustomNameVisible = true;
            feedable.Dimension = 0;
            feedable.FallDistance = 10;
            feedable.Fire = 100;
            feedable.ForcedAge = 20;
            feedable.Glowing = true;
            feedable.Health = 30;
            feedable.id = "minecraft:chicken";
            feedable.InLove = true;
            feedable.Invulnerable = true;
            feedable.Motion = new double?[] { 0, 0, 0 };
            feedable.OnGround = true;
            feedable.Owner = "baka_mashiro";
            feedable.OwnerUUID = 1;
            feedable.PortalCooldown = 1;
            feedable.Silent = false;
            feedable.Tags.Add("666");


            pv.cmd_RichTextView.Document.Blocks.Add(feedable.GetColorNBT());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
