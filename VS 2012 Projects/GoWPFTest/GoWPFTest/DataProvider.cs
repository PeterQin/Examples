using Northwoods.GoXam;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GoWPFTest
{
    public class DataProvider
    {
        private static readonly DataProvider FInstance = new DataProvider();

        public static DataProvider Instance
        {
            get { return DataProvider.FInstance; }
        }

        private DataProvider() 
        { 
        }

        public static T Clone<T>(T item)
            where T:class
        {
            T result=default(T);
            if (item != null)
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone);
                bf.Serialize(ms,item);
                ms.Seek(0,SeekOrigin.Begin);
                result = bf.Deserialize(ms) as T;
            }
            return result;
        }


        //Sample data structure as following:
        /*
         * Select <--- Merge Join <-------- Clustered Index Scan
         *                           |
         *                           |
         *                           |----- Sort <----- Clustered Index Scan
         *                               
         * 
         */
        public ObservableCollection<SimpleData> GenerateSimpleNodes()
        {
            ObservableCollection<SimpleData> nodeSource = new ObservableCollection<SimpleData>();


            SimpleData node;

            //Select
            node = new SimpleData();
            node.Key = "Node1";
            node.Cost = "0.0 %";
            node.Operation = "SELECT";
            node.ImageSource = App.Current.FindResource("img_Select") as BitmapSource;
            node.ImageName = "img_Select";
            nodeSource.Add(node);

            //Merge Join
            node = new SimpleData();
            node.Key = "Node2";
            node.Cost = "0.0 %";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Rows = 144702;
            node.ImageSource = App.Current.FindResource("img_MergeJoin") as BitmapSource;
            node.ImageName = "img_MergeJoin";
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FFF1C606";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node3";
            node.Cost = "0.0 %";
            node.Operation = "Clustered Index Scan";
            node.OperationColor = "#FFFFFF96";
            node.OperationData = "[DEPARTMENT].[DEPARTMENT_PK]";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource("img_ClusteredIndexScan") as BitmapSource;
            node.ImageName = "img_ClusteredIndexScan";
            node.CanExpanded = false;
            nodeSource.Add(node);

            //Sort
            node = new SimpleData();
            node.Key = "Node4";
            node.Cost = "0.0 %";
            node.Operation = "Sort";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource("img_Sort") as BitmapSource;
            node.ImageName = "img_Sort";
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FF00E9F3";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node5";
            node.Cost = "99.9 %";
            node.CostColor = "#FFFF6C6C";
            node.Operation = "Clustered Index Scan";
            node.OperationColor = "#FFFFFF96";
            node.Rows = 599998;
            node.OperationData = "[EMPLOYEE.EMPLOYEE_PK]";
            node.ImageSource = App.Current.FindResource("img_ClusteredIndexScan") as BitmapSource;
            node.ImageName = "img_ClusteredIndexScan";
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FF276D70";
            node.CanExpanded = false;
            nodeSource.Add(node);

            return nodeSource;
        }

        public ObservableCollection<LinkData> GenerateSimpleLinks(ObservableCollection<SimpleData> nodes)
        {
            ObservableCollection<LinkData> linkSource = new ObservableCollection<LinkData>();
            LinkData link;

            //Select --> Merge Join
            link = new LinkData();
            link.From = nodes[0].Key;   //Node: Select
            link.To = nodes[1].Key; //Node: Merge Join
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            //Merge Join --> Clustered Index Scan
            link = new LinkData();
            link.From = nodes[1].Key;   //Node: Merge Join
            link.To = nodes[2].Key; //Node: Clustered Index Scan
            link.Text = nodes[2].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 2;
            link.LineSize = 1;
            linkSource.Add(link);

            //Merge Join --> Sort
            link = new LinkData();
            link.From = nodes[1].Key;   //Node: Merge Join
            link.To = nodes[3].Key; //Node: Sort
            link.Text = nodes[3].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 7;
            link.LineSize = 6;
            linkSource.Add(link);

            //Sort --> Clustered Index Scan
            link = new LinkData();
            link.From = nodes[3].Key;   //Node: Sort
            link.To = nodes[4].Key; //Node: Clustered Index Scan
            link.Text = nodes[4].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 7;
            link.LineSize = 6;
            linkSource.Add(link);

            return linkSource;
        }



        public ObservableCollection<SimpleData> GenerateNodes(int AddNumber=15)
        {
            ObservableCollection<SimpleData> nodeSource = new ObservableCollection<SimpleData>();

             
            SimpleData node;

            //Select
            node = new SimpleData();
            node.Key = "Node1";
            node.Cost = "0.0 %";
            node.Operation = "SELECT";
            node.ImageSource = App.Current.FindResource("img_Select") as BitmapSource;
            nodeSource.Add(node);

            //Merge Join
            node = new SimpleData();
            node.Key = "Node2";
            node.Cost = "0.0 %";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Rows = 144702;
            node.ImageSource = App.Current.FindResource("img_MergeJoin") as BitmapSource;
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FFF1C606";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node3";
            node.Cost = "0.0 %";
            node.Operation = "Clustered Index Scan";
            node.OperationColor = "#FFFFFF96";
            node.OperationData = "[DEPARTMENT].[DEPARTMENT_PK]";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource("img_ClusteredIndexScan") as BitmapSource;
            nodeSource.Add(node);

            //Sort
            node = new SimpleData();
            node.Key = "Node4";
            node.Cost = "0.0 %";
            node.Operation = "Sort";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource("img_Sort") as BitmapSource;
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FF00E9F3";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node5";
            node.Cost = "99.9 %";
            node.CostColor = "#FFFF6C6C";
            node.Operation = "Clustered Index Scan";
            node.OperationColor = "#FFFFFF96";
            node.Rows = 599998;
            node.OperationData = "[EMPLOYEE.EMPLOYEE_PK]";
            node.ImageSource = App.Current.FindResource("img_ClusteredIndexScan") as BitmapSource;
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            if (AddNumber > 0)
            {
                for (int i = 0; i < AddNumber; i++)
                {
                    node = new SimpleData();
                    node.Key = "Node" + i + 6;
                    node.Cost = "99.9 %";
                    node.CostColor = "#FFFF6C6C";
                    node.Operation = "Clustered Index Scan";
                    node.OperationColor = "#FFFFFF96";
                    node.Rows = 599998;
                    node.OperationData = "[EMPLOYEE.EMPLOYEE_PK]";
                    node.ImageSource = App.Current.FindResource("img_ClusteredIndexScan") as BitmapSource;
                    node.AllowImageBorder = true;
                    node.ImageBorderColor = "#FF276D70";
                    nodeSource.Add(node);
                }
            }

            return nodeSource;
        }

        public ObservableCollection<LinkData> GenerateLinks(ObservableCollection<SimpleData> nodes, string aToPort, string aFromPort)
        {
            ObservableCollection<LinkData> linkSource = new ObservableCollection<LinkData>();
            LinkData link;

            //ObservableCollection<int> fromKeyList = new ObservableCollection<int>();
            for (int i = 0; i < nodes.Count-1; i++)
            {
                link = new LinkData();
                int GenFromKey=-1;
                if(i==0)
                    GenFromKey=0;
                else
                    GenFromKey = new Random().Next(1, i);
                link.From = nodes[GenFromKey].Key;   //Node: Select
                link.To = nodes[i+1].Key; //Node: Merge Join
                link.Text = nodes[i+1].Rows.ToString("N0");
                link.FromPort = aFromPort;   //Connect to image on Node
                link.ToPort = aToPort;
                link.BorderSize = 7;
                link.LineSize = 6;
                linkSource.Add(link);
            }

            ////Select --> Merge Join
            //link = new LinkData();
            //link.From = nodes[0].Key;   //Node: Select
            //link.To = nodes[1].Key; //Node: Merge Join
            //link.Text = nodes[1].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 3;
            //link.LineSize = 2;
            //linkSource.Add(link);

            ////Merge Join --> Clustered Index Scan
            //link = new LinkData();
            //link.From = nodes[1].Key;   //Node: Merge Join
            //link.To = nodes[2].Key; //Node: Clustered Index Scan
            //link.Text = nodes[2].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 2;
            //link.LineSize = 1;
            //linkSource.Add(link);

            ////Merge Join --> Sort
            //link = new LinkData();
            //link.From = nodes[1].Key;   //Node: Merge Join
            //link.To = nodes[3].Key; //Node: Sort
            //link.Text = nodes[3].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            ////Sort --> Clustered Index Scan
            //link = new LinkData();
            //link.From = nodes[3].Key;   //Node: Sort
            //link.To = nodes[4].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            ////Sort --> Clustered Index Scan
            //link = new LinkData();
            //link.From = nodes[4].Key;   //Node: Sort
            //link.To = nodes[5].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);


            //link = new LinkData();
            //link.From = nodes[4].Key;   //Node: Sort
            //link.To = nodes[6].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);



            //link = new LinkData();
            //link.From = nodes[4].Key;   //Node: Sort
            //link.To = nodes[7].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[4].Key;   //Node: Sort
            //link.To = nodes[8].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[5].Key;   //Node: Sort
            //link.To = nodes[9].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[5].Key;   //Node: Sort
            //link.To = nodes[10].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[7].Key;   //Node: Sort
            //link.To = nodes[11].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);


            //link = new LinkData();
            //link.From = nodes[7].Key;   //Node: Sort
            //link.To = nodes[12].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);


            //link = new LinkData();
            //link.From = nodes[8].Key;   //Node: Sort
            //link.To = nodes[13].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[8].Key;   //Node: Sort
            //link.To = nodes[14].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);


            //link = new LinkData();
            //link.From = nodes[12].Key;   //Node: Sort
            //link.To = nodes[15].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[12].Key;   //Node: Sort
            //link.To = nodes[16].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[12].Key;   //Node: Sort
            //link.To = nodes[17].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[12].Key;   //Node: Sort
            //link.To = nodes[18].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            //link = new LinkData();
            //link.From = nodes[14].Key;   //Node: Sort
            //link.To = nodes[19].Key; //Node: Clustered Index Scan
            //link.Text = nodes[4].Rows.ToString("N0");
            //link.FromPort = aFromPort;   //Connect to image on Node
            //link.ToPort = aToPort;
            //link.BorderSize = 7;
            //link.LineSize = 6;
            //linkSource.Add(link);

            return linkSource;
        }

        public ObservableCollection<LinkData> GenerateLinks(ObservableCollection<SimpleData> nodes)
        {
            return GenerateLinks(nodes, "port_image", "port_image");
        }

        public ObservableCollection<SimpleData> GenerateNodes_More()
        {
            return GenerateNodes_More("S_");
        }

        /// <summary>
        /// It's structure look like Images/SimplePlan.jpg
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SimpleData> GenerateNodes_More(string aPrefIconName)
        {
            ObservableCollection<SimpleData> nodeSource = new ObservableCollection<SimpleData>();


            SimpleData node;

            //Select
            node = new SimpleData();
            node.Key = "Node1";
            node.Cost = "0.0 %";
            node.Operation = "SELECT";
            node.ImageSource = App.Current.FindResource(aPrefIconName + "Select") as BitmapSource;
            nodeSource.Add(node);

            //Nested Loops
            node = new SimpleData();
            node.Key = "Node2";
            node.Cost = "0.03 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Inner Join)";
            node.Rows = 144702;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "NestedLoop") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Nested Loops
            node = new SimpleData();
            node.Key = "Node3";
            node.Cost = "0.03 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Inner Join)";
            node.Rows = 144702;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "NestedLoop") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FFF1C606";
            nodeSource.Add(node);

            //Merge Join
            node = new SimpleData();
            node.Key = "Node4";
            node.Cost = "0.07 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Inner Join)";
            node.Rows = 144702;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "MergeJoin") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FFF1C606";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node5";
            node.Cost = "0.11 %";
            node.Operation = "Clustered Index Scan";
            //node.OperationColor = "#FFFFFF96";
            node.OperationData = "[DEPARTMENT].[DEPARTMENT_PK]";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "ClusteredIndexScan") as BitmapSource;
            nodeSource.Add(node);

            //RID Lookup
            node = new SimpleData();
            node.Key = "Node6";
            node.Cost = "23.60 %";
            node.CostColor = "#FFFFBCBC";
            node.Operation = "RID Lookup";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "RIDLookup") as BitmapSource;
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FF00E9F3";
            nodeSource.Add(node);

            //Index Seek
            node = new SimpleData();
            node.Key = "Node7";
            node.Cost = "23.30 %";
            //node.CostColor = "#FFFF6C6C";
            node.Operation = "Index Seek";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "IndexSeek") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Sort
            node = new SimpleData();
            node.Key = "Node8";
            node.Cost = "0.20 %";
            node.Operation = "Sort";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "Sort") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Nested Loops
            node = new SimpleData();
            node.Key = "Node9";
            node.Cost = "0.03 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Left semi-join)";
            node.Rows = 5;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "NestedLoop") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Nested Loops
            node = new SimpleData();
            node.Key = "Node10";
            node.Cost = "0.06 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Inner join)";
            node.Rows = 5;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "NestedLoop") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Clustered Index Scan
            node = new SimpleData();
            node.Key = "Node11";
            node.Cost = "0.02 %";
            node.Operation = "Clustered Index Scan";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "ClusteredIndexScan") as BitmapSource;
            nodeSource.Add(node);

            //Row Count Spool
            node = new SimpleData();
            node.Key = "Node12";
            node.Cost = "0.83 %";
            node.Operation = "Row Count Spool";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "RowCountSpool") as BitmapSource;
            nodeSource.Add(node);

            //Nested Loops
            node = new SimpleData();
            node.Key = "Node13";
            node.Cost = "0.07 %";
            node.Operation = "Nested Loops";
            node.OperationData = "(Inner join)";
            node.Rows = 5;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "NestedLoop") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Index Seek
            node = new SimpleData();
            node.Key = "Node14";
            node.Cost = "0.04 %";
            //node.CostColor = "#FFFF6C6C";
            node.Operation = "Index Seek";
            node.Rows = 599998;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "IndexSeek") as BitmapSource;
            node.AllowImageBorder = false;
            node.ImageBorderColor = "#FF276D70";
            nodeSource.Add(node);

            //Clustered Index Seek
            node = new SimpleData();
            node.Key = "Node15";
            node.Cost = "0.02 %";
            node.Operation = "Clustered Index Seek";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "ClusteredIndexSeek") as BitmapSource;
            nodeSource.Add(node);

            //Clustered Index Seek
            node = new SimpleData();
            node.Key = "Node16";
            node.Cost = "51.59 %";
            node.CostColor = "#FFFF6C6C";
            node.Operation = "Clustered Index Seek";
            node.Rows = 306;
            node.ImageSource = App.Current.FindResource(aPrefIconName + "ClusteredIndexSeek") as BitmapSource;
            node.AllowImageBorder = true;
            node.ImageBorderColor = "#FFFDBA2B";
            nodeSource.Add(node);

            return nodeSource;
        }

        public ObservableCollection<LinkData> GenerateLinks_More(ObservableCollection<SimpleData> nodes)
        {
            ObservableCollection<LinkData> linkSource = new ObservableCollection<LinkData>();
            LinkData link;

            link = new LinkData();
            link.From = nodes[0].Key;  
            link.To = nodes[1].Key; 
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[1].Key;
            link.To = nodes[2].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[2].Key;
            link.To = nodes[3].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[3].Key;
            link.To = nodes[4].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[1].Key;
            link.To = nodes[5].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[2].Key;
            link.To = nodes[6].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[3].Key;
            link.To = nodes[7].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[7].Key;
            link.To = nodes[8].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[8].Key;
            link.To = nodes[9].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[9].Key;
            link.To = nodes[10].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[8].Key;
            link.To = nodes[11].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[9].Key;
            link.To = nodes[12].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            link.LinkColor = "#FFF9B603";
            link.LinkBorderColor = "White";
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[12].Key;
            link.To = nodes[13].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[11].Key;
            link.To = nodes[14].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            linkSource.Add(link);

            link = new LinkData();
            link.From = nodes[12].Key;
            link.To = nodes[15].Key;
            link.Text = nodes[1].Rows.ToString("N0");
            link.FromPort = "port_image";   //Connect to image on Node
            link.ToPort = "port_image";
            link.BorderSize = 3;
            link.LineSize = 2;
            link.LinkColor = "#FFFF6C6C";
            link.LinkBorderColor = "White";
            link.Link1 = false;
            link.Link2 = true;
            linkSource.Add(link);

            return linkSource;
        }




        #region Create Group Nodes
        private Random FRand = new Random();

        public ObservableCollection<SimpleDataGroup> CreateDataGroupStyle3()
        {
            ObservableCollection<SimpleDataGroup> result = new ObservableCollection<SimpleDataGroup>();

            #region Create Nodes

            SimpleDataGroup node;

            node = new SimpleDataGroup();
            node.Key = "Node1";
            node.Operation = "Select";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Select") as BitmapSource;
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node2";
            node.Operation = "Parallelism";
            node.OperationData = "(Gather Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node1" };
            node.SubGraphKey = "Group0";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node3";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node2" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node4";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group1";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node5";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node4" };
            node.SubGraphKey = "Group1";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node6";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node5" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node7";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group2";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node8";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node7" };
            node.SubGraphKey = "Group2";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node9";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node8" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node10";
            node.Operation = "Bitmap";
            node.OperationData = "(Bitmap Create)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Bitmap") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node11";
            node.Operation = "Sort";
            node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node10" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node12";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node11" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node13";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node12" };
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Node14";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group4";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node15";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node14" };
            node.SubGraphKey = "Group4";
            result.Add(node);

            //node = new SimpleDataGroup();
            //node.Key = "Node16";
            //node.Operation = "Table Scan";
            //node.OperationData = "[GRADE]";
            //node.Columns = new List<Column>() 
            //    { 
            //        new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
            //    };
            //node.Cost = "0.0 %";
            //node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            ////node.FromKeys = new ObservableCollection<string>() { "Node15" };
            //result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node17";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group5";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node18";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node17" };
            node.SubGraphKey = "Group5";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node19";
            node.Operation = "Clustered Index Seek";
            node.OperationData = "[DEPARTMENT_PK]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.08 %";
            node.ImageSource = App.Current.FindResource("Q_ClusteredIndexSeek") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node18" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node20";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.7 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group6";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node21";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "58.8 %";
            node.CostColor = "#FFFF6C6C";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node20" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node103";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node2" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node104";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group101";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node105";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node4" };
            node.SubGraphKey = "Group101";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node106";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node5" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node107";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group102";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node108";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node7" };
            node.SubGraphKey = "Group102";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node109";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node8" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node110";
            node.Operation = "Bitmap";
            node.OperationData = "(Bitmap Create)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Bitmap") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group103";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node111";
            node.Operation = "Sort";
            node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node10" };
            node.SubGraphKey = "Group103";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node112";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node11" };
            node.SubGraphKey = "Group103";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node113";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node12" };
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Node114";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group104";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node115";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node14" };
            node.SubGraphKey = "Group104";
            result.Add(node);

            //node = new SimpleDataGroup();
            //node.Key = "Node116";
            //node.Operation = "Table Scan";
            //node.OperationData = "[GRADE]";
            //node.Columns = new List<Column>() 
            //    { 
            //        new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
            //        new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
            //    };
            //node.Cost = "0.0 %";
            //node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            ////node.FromKeys = new ObservableCollection<string>() { "Node15" };
            //result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node117";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group105";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node118";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node17" };
            node.SubGraphKey = "Group105";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node119";
            node.Operation = "Clustered Index Scan";
            node.OperationData = "[EMPLOYEE_PK]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.03 %";
            node.ImageSource = App.Current.FindResource("Q_ClusteredIndexScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node18" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node120";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.7 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group106";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node121";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "10 %";
            node.CostColor = "#FFFF6C6C";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node20" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1003";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node2" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1004";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group1001";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1005";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node4" };
            node.SubGraphKey = "Group1001";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1006";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node5" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1007";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group1002";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1008";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node7" };
            node.SubGraphKey = "Group1002";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1009";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node8" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1010";
            node.Operation = "Bitmap";
            node.OperationData = "(Bitmap Create)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Bitmap") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group1003";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1011";
            node.Operation = "Sort";
            node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node10" };
            node.SubGraphKey = "Group1003";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1012";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node11" };
            node.SubGraphKey = "Group1003";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1013";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node12" };
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Node1014";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group1004";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1015";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node14" };
            node.SubGraphKey = "Group1004";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1016";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node15" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1017";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group1005";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1018";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node17" };
            node.SubGraphKey = "Group1005";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1019";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node18" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1020";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.7 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group1006";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node1021";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "10 %";
            node.CostColor = "#FFFF6C6C";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node20" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group0";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Group2";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group3";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_Bitmap", "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group4";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group5";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group6";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "10 %";
            node.CostColor = "#FFFF6C6C";
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group101";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Group102";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group103";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_Bitmap", "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group104";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group105";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group106";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "10 %";
            node.CostColor = "#FFFF6C6C";
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1001";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Group1002";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1003";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_Bitmap", "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1004";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1005";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1006";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "98.8 %";
            node.CostColor = "#FFFF6C6C";
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            foreach (SimpleDataGroup item in result)
            {
                if (item.IsSubGraph)
                {
                    double d = 0.0;
                    foreach (SimpleDataGroup item2 in result)
                    {
                        if (item2.SubGraphKey == item.Key)
                        {
                            d += ParsePercent(item2.Cost);
                        }
                    }
                    item.Cost = d + " %";
                }
            }

            #endregion Create Nodes

            return result;
        }

        public ObservableCollection<LinkDataGroup> CreateLink3(ObservableCollection<SimpleDataGroup> aNodes)
        {
            ObservableCollection<LinkDataGroup> result = new ObservableCollection<LinkDataGroup>();

            LinkDataGroup link;

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 0, 12));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[2]);
            link.To = GroupKey(aNodes[13]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 13, 14));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[5]);
            link.To = GroupKey(aNodes[15]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 15, 17));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[8]);
            link.To = GroupKey(aNodes[18]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[18]);
            link.To = GroupKey(aNodes[19]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            //Level 2 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[14]);
            link.To = GroupKey(aNodes[20]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            //----------------------


            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 20, 30));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[20]);
            link.To = GroupKey(aNodes[31]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 31, 32));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[23]);
            link.To = GroupKey(aNodes[33]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 33, 35));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[26]);
            link.To = GroupKey(aNodes[36]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[36]);
            link.To = GroupKey(aNodes[37]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            //Level 3 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[32]);
            link.To = GroupKey(aNodes[38]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            //----------------------

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 38, 48));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[38]);
            link.To = GroupKey(aNodes[49]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 49, 51));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[41]);
            link.To = GroupKey(aNodes[52]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 52, 54));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[44]);
            link.To = GroupKey(aNodes[55]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[55]);
            link.To = GroupKey(aNodes[56]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].From.StartsWith("Group"))
                {
                    result[i].AllowArrow = false;
                }
            }

            foreach (LinkDataGroup item in result)
            {
                
                if (item.To == "Node21")
                {
                    item.LinkColor = "#FFFF6C6C";
                    item.ImageBorderAnimationSpeed = AnimationSpeedLevel.Three;
                    item.BorderSize = 6;
                    item.LineSize = 6;
                    item.RowSize = "Row Size: 160000";
                    item.DataSize = "Data Size: 89125634";
                }
                else if (item.To == "Node19" || item.To == "Node119" || item.To == "Node1019")
                {
                    item.LinkColor = "#FFF9B603";
                    item.ImageBorderAnimationSpeed = AnimationSpeedLevel.One;
                    item.BorderSize = 3;
                    item.LineSize = 3;
                    item.RowSize = "Row Size: 1213";
                    item.DataSize = "Data Size: 5634";
                }
                else if (item.To == "Node121" || item.To == "Node1021")
                {
                    item.LinkColor = "#FFEC5D0C";
                    item.ImageBorderAnimationSpeed = AnimationSpeedLevel.Two;
                    item.BorderSize = 4;
                    item.LineSize = 4;
                    item.RowSize = "Row Size: 204521";
                    item.DataSize = "Data Size: 2568728";
                }
            }

            return result;
        }


        /// <summary>
        /// Group nodes except the last one
        /// 
        /// Select <-- [.] <--- Merge Join <---
        /// 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SimpleDataGroup> CreateDataGroupStyle2()
        {
            ObservableCollection<SimpleDataGroup> result = new ObservableCollection<SimpleDataGroup>();

            #region Create Nodes

            SimpleDataGroup node;

            node = new SimpleDataGroup();
            node.Key = "Node1";
            node.Operation = "Select";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Select") as BitmapSource;
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node2";
            node.Operation = "Parallelism";
            node.OperationData = "(Gather Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node1" };
            node.SubGraphKey = "Group0";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node3";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node2" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node4";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group1";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node5";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node4" };
            node.SubGraphKey = "Group1";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node6";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node5" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node7";
            node.Operation = "Sort";
            //node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group2";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node8";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node7" };
            node.SubGraphKey = "Group2";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node9";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node8" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node10";
            node.Operation = "Bitmap";
            node.OperationData = "(Bitmap Create)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Bitmap") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node11";
            node.Operation = "Sort";
            node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node10" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node12";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node11" };
            node.SubGraphKey = "Group3";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node13";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node12" };
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Node14";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node3" };
            node.SubGraphKey = "Group4";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node15";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node14" };
            node.SubGraphKey = "Group4";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node16";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node15" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node17";
            node.Operation = "Sort";
            //node.OperationData = "(Distinct Sort)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_Sort") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node6" };
            node.SubGraphKey = "Group5";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node18";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node17" };
            node.SubGraphKey = "Group5";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node19";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node18" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node20";
            node.Operation = "Parallelism";
            node.OperationData = "(Repartition Streams)";
            node.Cost = "0.7 %";
            node.ImageSource = App.Current.FindResource("Q_PARALLELISM") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node9" };
            node.SubGraphKey = "Group6";
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Node21";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "98.8 %";
            node.CostColor = "#FFFF6C6C";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            //node.FromKeys = new ObservableCollection<string>() { "Node20" };
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group0";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group1";
            node.Operation = "Merge Join";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            node.ImageSource = App.Current.FindResource("Q_MergeJoin") as BitmapSource;
            node.IsSubGraph = true;
            result.Add(node);


            node = new SimpleDataGroup();
            node.Key = "Group2";
            node.Operation = "Hash Match";
            node.OperationData = "(Inner Join)";
            node.Cost = "0.4 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_HashMatch") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group3";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.ChildIconList = new List<string>() { "Q_Bitmap", "Q_Sort", "Q_PARALLELISM" };
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group4";
            node.Operation = "Table Scan";
            node.OperationData = "[GRADE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("GRD_ID", "numeric(6, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_DESC", "varchar(500)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MIN_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("GRD_MAX_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group5";
            node.Operation = "Table Scan";
            node.OperationData = "[DEPARTMENT]";
            node.Columns = new List<Column>() 
                { 
                    new Column("DPT_ID", "varchar(7)", true, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_MANAGER", "numeric(9, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("LOCATION_ID", "numeric(4, 0)", false, NodeFigure.Decision, "Yellow"),
                    new Column("DPT_AVG_SALARY", "numeric(8, 0)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "0.0 %";
            node.ChildIconList = new List<string>() { "Q_Sort", "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            node = new SimpleDataGroup();
            node.Key = "Group6";
            node.Operation = "Table Scan";
            node.OperationData = "[EMPLOYEE]";
            node.Columns = new List<Column>() 
                { 
                    new Column("EMP_ID", "numeric(9, 0)", true, NodeFigure.Decision, "Yellow"),
                    new Column("EMP_NAME", "varchar(120)", false, NodeFigure.Decision, "Yellow"),
                    new Column("EMAIL", "varchar(45)", false, NodeFigure.Decision, "Yellow"),
                    new Column("HIRE_DATE", "datetime", false, NodeFigure.Decision, "Yellow"),
                    new Column("JOB_ID", "varchar(10)", false, NodeFigure.Decision, "Yellow"),
                };
            node.Cost = "98.8 %";
            node.CostColor = "#FFFF6C6C";
            node.ChildIconList = new List<string>() { "Q_PARALLELISM" };
            node.ImageSource = App.Current.FindResource("Q_TableScan") as BitmapSource;
            node.IsSubGraph = true;
            node.Color = String.Format("#{0:X}{1:X}{2:X}", 80 + FRand.Next(100), 80 + FRand.Next(100), 80 + FRand.Next(100));
            result.Add(node);

            foreach (SimpleDataGroup item in result)
            {
                if (item.IsSubGraph)
                {
                    double d = 0.0;
                    foreach (SimpleDataGroup item2 in result)
                    {
                        if (item2.SubGraphKey == item.Key)
                        {
                            d += ParsePercent(item2.Cost);
                        }
                    }
                    item.Cost = d + " %";
                }
            }

            #endregion Create Nodes

            return result;
        }

        public double ParsePercent(string percent)
        {
            string d = percent.Replace(" %", "");
            return double.Parse(d);
        }

        public ObservableCollection<LinkDataGroup> CreateLink2(ObservableCollection<SimpleDataGroup> aNodes)
        {
            ObservableCollection<LinkDataGroup> result = new ObservableCollection<LinkDataGroup>();

            LinkDataGroup link;

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 0, 12));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[2]);
            link.To = GroupKey(aNodes[13]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 13, 15));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[5]);
            link.To = GroupKey(aNodes[16]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            result.AddRange<LinkDataGroup>(GroupChild2(aNodes, 16, 18));

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[8]);
            link.To = GroupKey(aNodes[19]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            link = new LinkDataGroup();
            link.From = GroupKey(aNodes[19]);
            link.To = GroupKey(aNodes[20]);
            if (ContainLink(result, link) == false)
            {
                result.Add(link);
            }

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].From.StartsWith("Group"))
                {
                    result[i].AllowArrow = false;
                }
            }

            foreach (LinkDataGroup item in result)
            {
                if (item.To== "Node21")
                {
                    item.LinkColor = "#FFFF6C6C";
                    item.ImageBorderAnimationSpeed = AnimationSpeedLevel.Three;
                }
                else if (item.To == "Node19")
                {
                    item.LinkColor = "#FFF9B603";
                    item.ImageBorderAnimationSpeed = AnimationSpeedLevel.One;
                }
            }

            return result;
        }

        private bool ContainLink(ObservableCollection<LinkDataGroup> aLinkList, LinkDataGroup aLink)
        {
            bool existsLink = false;
            foreach (LinkDataGroup link2 in aLinkList)
            {
                if (link2.From.Equals(aLink.From) && link2.To.Equals(aLink.To))
                {
                    existsLink = true;
                    break;
                }
            }
            return existsLink;
        }

        private ObservableCollection<LinkDataGroup> GroupChild2(ObservableCollection<SimpleDataGroup> aNodes, int aStartIndex, int EndIndex)
        {
            ObservableCollection<LinkDataGroup> result = new ObservableCollection<LinkDataGroup>();

            LinkDataGroup link;

            for (int i = aStartIndex; i < EndIndex; i++)
            {
                if (aNodes[i].IsSubGraph && aNodes[i + 1].IsSubGraph)
                {
                    continue;
                }
                link = new LinkDataGroup();
                link.From = GroupKey(aNodes[i]);
                link.To = GroupKey(aNodes[i + 1]);

                if (link.From.Equals(link.To))
                {
                    link.From = aNodes[i].Key;
                    link.To = aNodes[i + 1].Key;
                }

                bool existsLink = false;
                foreach (LinkDataGroup link2 in result)
                {
                    if (link2.From.Equals(link.From) && link2.To.Equals(link.To))
                    {
                        existsLink = true;
                        break;
                    }
                }
                if (existsLink == false)
                {
                    result.Add(link);
                }
            }

            return result;
        }

        private string GroupKey(SimpleDataGroup aNode)
        {
            return string.IsNullOrWhiteSpace(aNode.SubGraphKey) ? aNode.Key : aNode.SubGraphKey;
        }

        #endregion Create Group Nodes

    }
}
