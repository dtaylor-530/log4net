using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VectorExtensions
{

    public class VectorShape
    {

        public VectorShape(double X1, double Y1, double X2, double Y2)
        {

            Start = new Point(X1, Y1);
            End = new Point(X2, Y2);
            OppositePoints = new Point[2] { new Point(Start.X,End.Y), new Point(End.X,Start.Y)};

        }

        public VectorShape(Point s, Point e)
        {
            Start = s;
            End = e;
            OppositePoints = new Point[2] { new Point(Start.X, End.Y), new Point(End.X, Start.Y) };
        }

        public Point Start { get; }
        public Point End { get; }
        private Point[] OppositePoints;


        private Vector AB { get { return OppositePoints[0] - Start; } }
        private Vector BC { get { return End-OppositePoints[0] ; } }
        private double dotABAB { get { return AB.DotProduct(AB); } }
        private double dotBCBC { get { return BC.DotProduct(BC); } }


        ///  Eric Bainville answered May 4 '10 at 6:57
        ///https://stackoverflow.com/questions/2752725/finding-whether-a-point-lies-inside-a-rectangle-or-not
        ///
        //   0 <= dot(AB, AM) <= dot(AB, AB) &&
        //  0 <= dot(BC, BM) <= dot(BC, BC)
        //  AB is vector AB, with coordinates(Bx-Ax, By-Ay),
        //  example: A(5,0) B(0,2) C(1,5) and D(6,3). 
        //  From the point coordinates: AB=(-5,2), BC=(1,3), dot(AB,AB)=29, dot(BC,BC)=10.
        //  For query point P(6,1): AP=(1,1), BP=(6,-1), dot(AB, AP)=-3, dot(BC, BP)=3. 
        //  => P is not inside the rectangle, because its projection on side AB is not inside segment AB.

        public bool BoundedCheck(Point point)
        {
            Vector AP = point - Start;
            Vector BP = point - OppositePoints[0];
            double dotABAP = AB.DotProduct(AP);
            double dotBCBP = BC.DotProduct(BP);

            return 0 <= dotABAP && dotABAP <= dotABAB && 0 <= dotBCBP  && dotBCBP <= dotBCBC;
        }






    }

    public class VectorLine
    {

        public VectorLine(double X1, double Y1, double X2, double Y2)
        {

            Start = new Point(X1, Y1);
            End = new Point(X2, Y2);
        }

        public VectorLine(Point s, Point e)
        {
            Start = s;
            End= e;
        }

        public Point Start { get; set; }
        public Point End { get; set; }

        /// <summary>
        /// Normalized direction of line
        /// </summary>
        public Vector Direction
        {
            get
            {
                var x = (End - Start);
                x.Normalize();
                return x;
            }
        }

        /// <summary>
        /// Get the point a specified distance from the start point 
        /// within the bounds of the Start and End points
        /// </summary>
        public Point PositionFromDistance(double distance)
        {
            if (distance < 0)
                return Start;
            else
            {
                Point x = Start + distance * Direction;
                if ((End - Start).Length < (x - Start).Length)
                    return x;
                else
                    return End;
            }

        }
    }

    public static class VectorEx
    {
        /// <summary>
        /// checks if vectors have same direction as unit vector, unitV.
        /// unitV nust be unit vector
        /// </summary>
        /// <param name="V"></param>
        /// <param name="V2"></param>
        /// <returns></returns>
        public static bool SameDirection(this Vector unitV, Vector V2)
        {
            V2.Normalize();
            return unitV == V2;
        }


        /// <summary>
        /// returns normalized version of vector
        /// </summary>
        /// <param name="V"></param>
        /// <returns></returns>
        public static Vector GetNormalized(this Vector V)
        {
            V.Normalize();
            return V;

        }


        /// <summary>
        /// checks the dotproduct = 0 (which amounts to the same thing)
        /// </summary>
        /// <param name="V"></param>
        /// <param name="V2"></param>
        /// <returns></returns>
        public static bool IsPerpindicular(this Vector V, Vector V2)
        {
            return V.DotProduct(V2) == 0;
        }
        /// <summary>
        /// the dotproduct of two vectors (=v1.X*V2.X+v1.Y*V2.Y)
        /// </summary>
        /// <param name="V"></param>
        /// <param name="V2"></param>
        /// <returns></returns>
        public static double DotProduct(this Vector V1, Vector V2)
        {
            return V1.X * V2.X + V1.Y * V2.Y;
        }

        /// <summary>
        /// The angle made by a combined/magnitude vector with the horizontal axis
        /// </summary>
        /// <param name="v"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double CombinedAngle(this Vector v, Vector v2)
        {
            Vector vector = Vector.Add(v, v2);
            Vector horizontalunitVector = new Vector();
            // double length = v2.Length;
            //double ab = Vector.AngleBetween(v, v2);
            return Vector.AngleBetween(vector, horizontalunitVector);
        }

        /// <summary>
        /// gets the resulting momentum from a collision between a particle
        /// with momentum (@arg vector) and a wall (@arg normal)
        ///  e.g particle (10,2) & vertical-wall(1,0) => particle (-10,2)
        /// answered Feb 10 '12 at 20:44        David Gouveia
        /// https://gamedev.stackexchange.com/questions/23672/determine-resulting-angle-of-wall-collision
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector Reflect(this Vector vector, Vector normal)
        {

            return vector - 2 * DotProduct(vector, normal) * normal;
        }

    }
}

