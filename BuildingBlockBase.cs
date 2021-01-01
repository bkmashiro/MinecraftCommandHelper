﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MinecraftCommandHelper
{
    interface IBuildingBlock
    {
        string GetCommand();
    }

    enum BBTypes
    {
        parameter,//参数
        moudle,//模块
        moudle_group,//模块组
    }
    enum BBShapes
    {
        Any,//任意
        None,//无
        Missing,//错误的
        Triangle,//三角形
        rectangle,//四边形
        DoubleTriangle,//双重三角形
        poop,//shit
    }
    /// <summary>
    /// 提供对于BlockGroup的管理服务
    /// </summary>
    class BuildingBlockHostService
    {
        public BuildingBlockHostService(Grid grid) { Holder = grid; }
        public Grid Holder = null;

        List<BuildingBlockGroup> BBGroups = new List<BuildingBlockGroup>();
        public void RemoveGroup(BuildingBlockGroup b) => BBGroups.Remove(b);
        public void DemoGroups()
        {
            foreach (var group in BBGroups)
            {
                group.DemoAllBlocks();
            }
        }
        public void ClearGroups()
        {

        }
    }
    /// <summary>
    /// 提供对BuildingBlock群组的服务
    /// </summary>
    class BuildingBlockGroup
    {
        public Point Position = new Point(0, 0);
        public Grid Holder = null;

        public BuildingBlockGroup(BuildingBlockHostService service) { Holder = service.Holder; }
        public List<BuildingBlock> buildingBlocks = new List<BuildingBlock>();

        public void AddBlockToTail(BBTypes bTypes, BBShapes Head, BBShapes tail)
        {
            BuildingBlock buildingBlock = new BuildingBlock(this, Head, tail);
            buildingBlock.Init();
            buildingBlocks.Add(buildingBlock);
        }
        public void DemoAllBlocks()
        {
            foreach (var block in buildingBlocks)
            {
                block.Show();
            }
        }
        public void ClearAllBlocks()
        {
            foreach (var block in buildingBlocks)
            {
                block.Clear();
            }
        }
    }
    class BuildingBlock
    {
        public BuildingBlock()
        {

        }
        public BuildingBlock(BuildingBlockGroup buildingBlocks, BBShapes Head, BBShapes tail)
        {
            Position = buildingBlocks.Position;
            //TODO 改
            size = pv.building_block_size;
            Father_Node = (buildingBlocks.buildingBlocks.Count >= 1 ? buildingBlocks.buildingBlocks[buildingBlocks.buildingBlocks.Count - 1] : null);
            Child_Node = null;
            depth = buildingBlocks.buildingBlocks.Count;
            if (depth == 1)
            {
                IsHead = true;
            }
            else
            {
                IsHead = false;
            }
            BuildingBlockGroup = buildingBlocks;
            HeadShape = Head;
            TailShape = tail;
            g = buildingBlocks.Holder;
            buildingBlocks.buildingBlocks.Add(this);
        }
        Point Position = new Point(0, 0);
        Size size = pv.building_block_size;
        BuildingBlock Father_Node = null;
        BuildingBlock Child_Node = null;
        int depth = -1;
        bool IsHead = false;
        BuildingBlockGroup BuildingBlockGroup = null;
        BBShapes HeadShape = BBShapes.None;
        BBShapes TailShape = BBShapes.None;
        bool AutoSorption = true;
        bool SorptionSuccess = false;
        BuildingBlock SorptionTarget;
        string Hints = string.Empty;

        Grid g = new Grid();


        public Run GetCommand(string content, Brush foreground)
        {
            Run run = new Run(content);
            run.Foreground = foreground;
            return run;
        }
        public void Init()
        {

        }

        public void Show()
        {
            //lab.Margin=new Thickness(vb1.ActualWidth, lab.Margin.Top, lab.Margin.Right,lab.Margin.Bottom);


            BBCtrl bBCtrl = new BBCtrl(GetsData(HeadShape),GetsData(TailShape) , "命令参数");

            g.Children.Add(bBCtrl);
            g.UpdateLayout();
            //return Block;
        }

        public void Clear()
        {
        }

        private TextBlock GetTextBlock(string s)
        {
            TextBlock b = new TextBlock();
            b.Text = s;
            return b;
        }
        Dictionary<BBShapes, string> ShapeData = new System.Collections.Generic.Dictionary<BBShapes, string>
        {
            {BBShapes.Missing,"M15.07,11.25L14.17,12.17C13.45,12.89 13,13.5 13,15H11V14.5C11,13.39 11.45,12.39 12.17,11.67L13.41,10.41C13.78,10.05 14,9.55 14,9C14,7.89 13.1,7 12,7A2,2 0 0,0 10,9H8A4,4 0 0,1 12,5A4,4 0 0,1 16,9C16,9.88 15.64,10.67 15.07,11.25M13,19H11V17H13M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12C22,6.47 17.5,2 12,2Z" },
            {BBShapes.DoubleTriangle,"M 0,10 10,0 10,40 0,30 10,20 Z" },
            {BBShapes.Any,"M12.08,4.08L20,12L12.08,19.92L10.67,18.5L16.17,13H2V11H16.17L10.67,5.5L12.08,4.08M20,12V22H22V2H20V12Z" },
            {BBShapes.None,"Z" },
            {BBShapes.rectangle,"M 8,8 24,8 24,16 8,16 Z" },
            {BBShapes.Triangle,"M 24,0 24,24 0,12 Z" },
            {BBShapes.poop,"M11.36,2C11.15,2 10.87,2.12 10.57,2.32C10,2.7 8.85,3.9 8.4,5.1C8.06,6 8.05,6.82 8.19,7.43C7.63,7.53 7.22,7.71 7.06,7.78C6.55,8 5.47,8.96 5.37,10.45C5.34,10.97 5.41,11.5 5.57,12C4.91,12.19 4.53,12.43 4.5,12.44C4.18,12.56 3.65,12.93 3.5,13.13C3.15,13.53 2.92,14 2.79,14.5C2.5,15.59 2.6,16.83 3.13,17.83C3.42,18.39 3.82,19 4.26,19.43C5.7,20.91 8.18,21.47 10.14,21.79C12.53,22.19 15.03,22.05 17.26,21.13C20.61,19.74 21.5,17.5 21.64,16.89C21.93,15.5 21.57,14.19 21.42,13.87C21.2,13.41 20.84,12.94 20.25,12.64C19.85,12.39 19.5,12.26 19.24,12.2C19.5,11.25 19.13,10.5 18.62,9.94C17.85,9.12 17.06,9 17.06,9V9C17.32,8.5 17.42,7.9 17.28,7.32C17.12,6.61 16.73,6.16 16.22,5.86C15.7,5.55 15.06,5.4 14.4,5.28C14.08,5.22 12.75,5.03 12.2,4.27C11.75,3.65 11.74,2.53 11.62,2.2C11.57,2.07 11.5,2 11.36,2M16,9.61C16.07,9.61 16.13,9.62 16.19,9.62C17.62,9.78 18.64,11.16 18.47,12.69C18.3,14.22 17,15.34 15.57,15.18V15.18C14.14,15 13.12,13.65 13.29,12.11C13.45,10.66 14.64,9.56 16,9.61M8.62,9.61C9.95,9.65 11.06,10.78 11.16,12.21C11.28,13.75 10.21,15.08 8.78,15.19H8.77C7.34,15.3 6.08,14.14 5.96,12.6V12.6C5.85,11.06 6.92,9.73 8.35,9.62V9.62C8.44,9.61 8.53,9.61 8.62,9.61M8.64,11.31C8.6,11.31 8.57,11.31 8.53,11.32C7.97,11.39 7.57,11.9 7.64,12.45C7.7,13 8.21,13.39 8.77,13.32C9.33,13.25 9.73,12.74 9.67,12.19C9.61,11.67 9.15,11.3 8.64,11.31M15.94,11.33C15.42,11.35 15,11.75 14.96,12.28C14.92,12.83 15.35,13.31 15.91,13.34C16.5,13.38 16.96,12.95 17,12.4C17.04,11.84 16.61,11.36 16.05,11.33C16,11.33 16,11.33 15.94,11.33M8.71,16.15C9,16.14 9.26,16.23 9.5,16.28C10.68,16.5 11.7,16.53 12.19,16.53C12.68,16.53 13.69,16.5 14.86,16.28C15.27,16.2 15.74,16.03 16.11,16.28C16.59,16.6 16.24,17.75 15.5,18.53C15.04,19 13.97,19.91 12.19,19.91C10.41,19.91 9.33,19 8.88,18.53C8.14,17.75 7.79,16.6 8.26,16.28C8.4,16.19 8.55,16.15 8.71,16.15Z" }
        };

        Dictionary<BBShapes, Brush> ShapeColor = new Dictionary<BBShapes, Brush>
        {
            {BBShapes.Missing,Brushes.MediumPurple },
            {BBShapes.DoubleTriangle,Brushes.Orange },
            {BBShapes.Any,Brushes.AliceBlue },
            {BBShapes.None,Brushes.AntiqueWhite },
            {BBShapes.rectangle,Brushes.Green },
            {BBShapes.Triangle,Brushes.Blue},
            {BBShapes.poop,Brushes.Yellow }

        };



        private string GetsData(BBShapes shape)
        {
            string sData = "M15.07,11.25L14.17,12.17C13.45,12.89 13,13.5 13,15H11V14.5C11,13.39 11.45,12.39 12.17,11.67L13.41,10.41C13.78,10.05 14,9.55 14,9C14,7.89 13.1,7 12,7A2,2 0 0,0 10,9H8A4,4 0 0,1 12,5A4,4 0 0,1 16,9C16,9.88 15.64,10.67 15.07,11.25M13,19H11V17H13M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12C22,6.47 17.5,2 12,2Z";
            if (ShapeData.ContainsKey(shape))
            {
                ShapeData.TryGetValue(shape, out sData);
            }
            return sData;
        }

        private Brush GetsColor(BBShapes shape)
        {
            Brush sData = Brushes.White;
            if (ShapeColor.ContainsKey(shape))
            {
                ShapeColor.TryGetValue(shape, out sData);
            }
            return sData;
        }
    }

    class Note : BuildingBlock
    {

    }
}
