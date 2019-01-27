using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using VectorExtensions;
using System.Windows.Threading;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace PhysicsControl
{
    /// <summary>
    /// The Particle Class
    /// </summary>
    /// <remarks>
    /// Credits to ]Metty[ for the majority of this control.
    /// To see the original goto: 
    /// http://www.codeproject.com/KB/cs/Bouncing_Ball.aspx
    /// This control is re-created for WPF by Niel M. Thomas in 2010.
    /// This control is covered by the CPOL license.
    /// </remarks>
    /// 

    // For use by the the toolbox to identify control
    // See  // [https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-provide-a-toolbox-bitmap-for-a-control]
    //[ToolboxBitmap(typeof(Ball))]

    public class Particle : Control
    {
        #region -- Members --
        //private double moveX;
        //private double moveY;
        //private double x;
        //private double y;
  
        //private const double gravity = 0.1;
        //private readonly Random rand;
        private Rect area;
        //readonly DispatcherTimer timer = new DispatcherTimer();
        //private int counter;
        //#endregion

        //#region -- Events --
        /// <summary>
        /// Occurs when [ball moved].
        /// </summary>
        //public event EventHandler BallMoved;
        #endregion

        #region -- Properties --

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Particle"/> is moving.
        /// </summary>
        /// <remarks>
        /// Is not visible in the designer, we do not want the ball to bounce around in the designer...
        /// </remarks>
        /// <value><c>true</c> if moving; otherwise, <c>false</c>.</value>
        //[Category("Ball"), Description("Set or get if the Ball is moving."), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        ////public bool Moving { get; set; }



        #endregion

        private Vector position=new Vector(30,30);
        private Vector velocity =new Vector(0,1);
        private Vector acceleration =new Vector(0,1);
        private double mass =2;
        private Vector momentum;
        private Vector displacement;
        private Boolean min;
        public Vector Momentum {
            get {return velocity * mass; }
            set { Velocity = 0.75*value / mass; }
             }
        //set { velocity =0.9* value / mass; }

        public Vector Position { get { return position; }
            set { position = value; } }
        public Vector Acceleration { get { return acceleration; } set { acceleration = value; } }
        public Vector Velocity { get { return velocity; } set { velocity = value; } }



        public Boolean Move(double interval)
        {
            //double interval;

            //if (interval2 == null)
            //    return true;
            //else
            //    interval =interval2.TotalSeconds;
            displacement = velocity * interval;
            velocity += acceleration *interval;
            position += velocity;


                //VectorEx.Reflect(momentum, new Vector(1, 0));
                //velocity = new Vector(-1,- 1);
                // velocity =0.9* momentum / mass;
               // position += velocity;

                var ty = this.Center();
                this.Margin = new Thickness(position.X, position.Y, 0, 0);


            if (min==true)
                return false;
            else
                return true;


            //moveY += gravity;

            //x += moveX;
            //y += moveY;
            //var parentWindow = Window.GetWindow(this);
            //if (parentWindow != null)
            //    area = new Rect(new Point(0, 0), new Size(parentWindow.ActualWidth, parentWindow.ActualHeight));
            //else
            //    area = new Rect();

            ////Check Collision
            //if (x < 0)
            //{
            //    x = 0;
            //    moveX = -moveX;
            //    moveX *= 0.75;
            //    moveY *= 0.95;
            //}
            //if (x > (area.Width - 15 - Width))
            //{
            //    x = area.Width - 15 - Width;
            //    moveX = -moveX;
            //    moveX *= 0.75;
            //    moveY *= 0.95;
            //}

            //if (y < 0)
            //{
            //    y = 0;
            //    moveY = -moveY;
            //    moveY *= 0.75;
            //    moveX *= 0.95;
            //}
            //if (y > (area.Height - 30 - Height))
            //{
            //    y = area.Height - 30 - Height;
            //    moveY = -moveY;
            //    moveY *= 0.8;
            //    moveX *= 0.95;
            //}

            //if (Math.Abs(moveX) < 0.1 && Math.Abs(moveY) < 0.5 &&
            //  DateTime.Now.Second % 3 == 0 && y > area.Height - 1 - Height - 40)
            //{

            //    Bounce();
            //}
        }









        #region  Constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="Particle"/> class.
        /// </summary>
        public Particle()
        {
            Width = 20;
            Height = 20;

        }

        ///// <summary>
        ///// Initializes the <see cref="Particle"/> class.
        ///// </summary>
        //static Particle()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(Particle), new FrameworkPropertyMetadata(typeof(Particle)));
        //}
       
        #endregion



        #region -- Public Methods --

        #region Center
        /// <summary>
        /// Return the center of the ball
        /// </summary>
        /// <returns></returns>
        public Point Center()
        {
            try
            {
                Point center = PointToScreen(new Point(0, 0));
                center.Offset(Width / 2, Height / 2);
                return center;
            }
            catch (InvalidOperationException)
            {
                return new Point(0, 0);
            }

        }
        #endregion

        #region Bounce
        /// <summary>
        /// Bounces this instance.
        /// </summary>
        //public void Bounce()
        //{
        //    moveX = (rand.NextDouble() + rand.NextDouble()) - 1;
        //    moveY = -(rand.NextDouble());
        //    moveX *= 50;
        //    moveY *= 50;
        //    x += moveX;
        //    y += moveY;
        //}
        //#endregion

        //#region Tick
        ///// <summary>
        ///// Ticks this instance.
        ///// </summary>
        //public void Tick()
        //{
        //    moveY += gravity;

        //    x += moveX;
        //    y += moveY;
        //    var parentWindow = Window.GetWindow(this);
        //    if (parentWindow != null)
        //        area = new Rect(new Point(0, 0), new Size(parentWindow.ActualWidth, parentWindow.ActualHeight));
        //    else
        //        area = new Rect();

        //    //Check Collision
        //    if (x < 0)
        //    {
        //        x = 0;
        //        moveX = -moveX;
        //        moveX *= 0.75;
        //        moveY *= 0.95;
        //    }
        //    if (x > (area.Width - 15 - Width))
        //    {
        //        x = area.Width - 15 - Width;
        //        moveX = -moveX;
        //        moveX *= 0.75;
        //        moveY *= 0.95;
        //    }

        //    if (y < 0)
        //    {
        //        y = 0;
        //        moveY = -moveY;
        //        moveY *= 0.75;
        //        moveX *= 0.95;
        //    }
        //    if (y > (area.Height - 30 - Height))
        //    {
        //        y = area.Height - 30 - Height;
        //        moveY = -moveY;
        //        moveY *= 0.8;
        //        moveX *= 0.95;
        //    }

        //    if (Math.Abs(moveX) < 0.1 && Math.Abs(moveY) < 0.5 &&
        //      DateTime.Now.Second % 3 == 0 && y > area.Height - 1 - Height - 40)
        //    {

        //        Bounce();
        //    }
        //}
        #endregion



        //#region -- InvokeBallMoved --
        //public void InvokeBallMoved(EventArgs e)
        //{
        //    EventHandler handler = BallMoved;
        //    if (handler != null) handler(this, e);
        //}
        //#endregion

        //#endregion

        //#region -- Private Methods --

        //private void CalcArea()
        //{
        //    var parentWindow = Window.GetWindow(this);
        //    if (parentWindow != null)
        //        area = new Rect(new Point(0, 0), new Size(parentWindow.ActualWidth, parentWindow.ActualHeight));
        //    else
        //        area = new Rect();

        //}
        #endregion
    }
}
