// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows;
using System.Windows.Shapes;

namespace DemoApplication2
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModels.MainViewModel mvm;
        private PhysicsControl.ParticleSystem ParticleSystem;

        public MainWindow()
        {
            InitializeComponent();
            //mvm = new ViewModels.MainViewModel();
            //this.DataContext = mvm;
            //mvm.Node.X = 10;
            //mvm.Node.Y = 100;
            //myNode.DataContext = mvm.Node;

            ParticleSystem = new PhysicsControl.ParticleSystem(ball1, Trajectory1);


           Log4NetWPF.Log.Write(Log4NetWPF.LogLevel.Info, "dfggfgfd");

            // ParticleSystem.RunSimulation();


        }

        private void WindowLoaded(object sender, EventArgs e)
        {


        }
        Polyline myPolyline;
        private void CreatePolyLine()
        {


            myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            //myPolyline.FillRule = FillRule.EvenOdd;
            System.Windows.Point Point4 = new System.Windows.Point(1, 50);
            System.Windows.Point Point5 = new System.Windows.Point(10, 80);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            System.Windows.Media.PointCollection myPointCollection2 = new System.Windows.Media.PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            Canvas1.Children.Add(myPolyline);
        }

    }

}