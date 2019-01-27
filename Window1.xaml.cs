
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace log4netSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            Program.Sample();
        }
    }


    class Program
    {

        public static void Sample()
        {
            //log4netSample.ViewModel.LogwriterViewModel l = new log4netSample.ViewModel.LogwriterViewModel();

            Logging.Log.Write(Logging.LogLevel.Info, "dfggfgfd");

            //l.Message = "First Message";
            //l.UpdateLogCommand.Execute(null);

        }
    }


}
