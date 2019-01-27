using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VectorExtensions;

namespace PhysicsControl
{
    class ParticleSystem
    {


       
        private const double gravity = 0.1;
        private const double thresholdSpeed= 0.2;
        private readonly Random rand;
        private Rect area;
        readonly DispatcherTimer timer = new DispatcherTimer();
        private Particle particle;
        private Shapes.Trajectory trajectory;
        private Vector min = new Vector(0, 0);
        private Vector max = new Vector(100, 100);



//        [Category("Ball"), Description("Set or get the update interval in Milliseconds"), Browsable(true)]
        public TimeSpan UpdateInterval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        //EventHandler evt;

        public ParticleSystem(Particle particle, Shapes.Trajectory trajectory)
        {

            rand = new Random(Environment.TickCount);
            timer = new DispatcherTimer(DispatcherPriority.Normal) { Interval = TimeSpan.FromMilliseconds(10), IsEnabled = true };
           // particle = new Particle();
            //timer.Tick += (sender, e) => { if (!particle.Move((sender as DispatcherTimer).Interval.TotalSeconds) ) return ; };
           // evt = main;
            this.particle = particle;
            this.trajectory = trajectory;
            var x = trajectory.Width * trajectory.Width + trajectory.Height * trajectory.Height;
            //System.Windows.Media.Geometry oo = trajectory.RenderedGeometry;
            var ty = trajectory.X1;



            // RunSimulation();

            RunSimulation2();

        }

        //void main(object sender, EventArgs e)
        //{

        //    if (!(particle as Particle).Move((sender as DispatcherTimer).Interval.TotalSeconds)) return;

        //}



        private bool Clamp(Particle particle)
        {
            Vector position = particle.Position;

            bool check = false;
            
            if (position.X < min.X)// > (area.Width - 15 - Width))
            {
                position.X = min.X;
                particle.Momentum = particle.Momentum.Reflect(new Vector(1, 0));
            }

            else if (position.X > max.X)
            {
                position.X =max.X;
                particle.Momentum = particle.Momentum.Reflect(new Vector(1, 0));
            }

            else if (position.Y < min.Y)//(area.Height - 30 - Height))
            {
                position.Y = min.Y;
                particle.Momentum = particle.Momentum.Reflect(new Vector(0, 1));
            }
            // VectorEx.Reflect(momentum, new Vector(-1, 0));
            else if (position.Y > max.Y)//(area.Height - 30 - Height))
            {
                if (Math.Abs(particle.Velocity.Y) <thresholdSpeed) check = true;
                position.Y = max.Y;
                particle.Momentum = particle.Momentum.Reflect(new Vector(0, 1));
            }
            particle.Position = position;
            return check;
        }


        public void RunSimulation()
        {

            //counter = 0;

            // CalcArea();

            // Avoid memory leak
            bool b = false;
            particle.Acceleration=new Vector(0,1);
            particle.Velocity = new Vector(0.0, 1);
            timer.Tick += 
            //timer.Start();
            //timer.Tick-= evt;
            delegate
            {
                timer.IsEnabled = false;
                double x = timer.Interval.TotalSeconds;
                if (Clamp(particle))
                    return;
                    
                (particle as Particle).Move(x);

                timer.IsEnabled = true;

           
            };

            

            //timer.Tick +=(sender,e)=>
            //{
            //    timer.IsEnabled = false;
            //    if (!Moving)
            //        return;
            //    Tick();
            //    // this properties determines ball's position in the element it occupies 


            //    // this is keep eyes informed of ball's movement
            //    //InvokeBallMoved(null);
            //    //  if (counter % 200 == 0)
            //    //      CalcArea();

            //    timer.IsEnabled = true;
            //};
        }

        public void RunSimulation2()
        {

            particle.Position = (Vector)trajectory.Start;


            // Avoid memory leak
            bool b = false;
            particle.Acceleration = new Vector(0, 0);
            particle.Velocity = trajectory.Direction;
            timer.Tick +=
            //timer.Start();
            //timer.Tick-= evt;
            delegate
            {
                timer.IsEnabled = false;
                double x = timer.Interval.TotalSeconds;
                if (Clamp(particle))
                    return;

                (particle as Particle).Move(x);

                timer.IsEnabled = true;


            };



       
        }


    }

}

