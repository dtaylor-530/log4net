using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DemoApplication2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
       private Node node;
       public MainViewModel()
        {node = new Node(); }

        public Node Node
        {
            get
            {
                return node; ;
            }
            set
            {
                if (node != value)
                {
                    node = value;
                    OnChanged("Node");
                }
            }
        }


    }

    public class Node : ViewModelBase
    {
        public Node()
        { }

        private double y;

        public double Y
        {
            get
            {
                return y; ;
            }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnChanged("Y");
                }
            }
        }

        private double x;

        public double X
        {
            get
            {
                return x; ;
            }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnChanged("X");
                }
            }
        }

    }



    public class Connection : ViewModelBase
    {
        public Connection()
        { }


    }






    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Members and events
        private event PropertyChangedEventHandler _propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }
        #endregion

        protected void OnChanged(string notification)
        {
            PropertyChangedEventHandler handler = _propertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(notification));
            }
        }
    }
}
