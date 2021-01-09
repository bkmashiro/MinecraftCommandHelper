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

namespace MinecraftCommandHelper
{
    /// <summary>
    /// BuildingBlockView.xaml 的交互逻辑
    /// </summary>
    public partial class BuildingBlockView : Page
    {
        public BuildingBlockView()
        {
            InitializeComponent();

        }
        BuildingBlockHostService buildingBlockHostService ;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            buildingBlockHostService = new BuildingBlockHostService(BlockHolder);
            BuildingBlockGroup buildingBlockGroup = new BuildingBlockGroup(buildingBlockHostService);
            BuildingBlock buildingBlock = new BuildingBlock(buildingBlockGroup, BBShapes.poop, BBShapes.poop);
            buildingBlockGroup.DemoAllBlocks();



        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            buildingBlockHostService = new BuildingBlockHostService(BlockHolder);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Entities.Feedable feedable = new Entities.Feedable();
            BuildingBlockGroup buildingBlockGroup = new BuildingBlockGroup(buildingBlockHostService);
            BuildingBlock buildingBlock = new BuildingBlock(buildingBlockGroup, BBShapes.poop, BBShapes.poop,feedable);
            buildingBlock.Show();
        }
    }
}
