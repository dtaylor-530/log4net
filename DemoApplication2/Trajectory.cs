using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Shapes
{
    class Trajectory : LineEx
    {

        private VectorExtensions.VectorLine vline;

        public Trajectory()
        {

            X1 = 2;
            X2 = 3;
            Y1 = 100;
            Y2 = 100;
            vline = new VectorExtensions.VectorLine(X1, X2, Y1, Y2);
        }

        public Point Start { get { return vline.Start; } }
        public Point End { get { return vline.End; }}
        public Point InterpolatedPoint(double distance)
                        { return vline.PositionFromDistance(distance); }
        public Vector Direction { get { return vline.Direction; } }

        protected override Geometry DefiningGeometry
        {
            get
            {
                // Create a StreamGeometry for describing the shape
                LineGeometry geometry = new LineGeometry();
                geometry.StartPoint = Start;
                geometry.EndPoint = End;

                return geometry;
            }
        }




    }


    //class RectangleEx : LineEx
    //{

    //    private VectorExtensions.VectorLine vline;
    //    private Rect r;
    //    public Trajectory()
    //    {

    //        X1 = 2;
    //        X2 = 3;
    //        Y1 = 100;
    //        Y2 = 100;
    //        r = new Rect(new Point(X1, Y1), new Point(X2, Y2));
    //        vline = new VectorExtensions.VectorLine(X1, X2, Y1, Y2);
    //    }

    //    public Point Start { get { return vline.Start; } }
    //    public Point End { get { return vline.End; } }
       

    //    protected override Geometry DefiningGeometry
    //    {
    //        get
    //        {
    //            // Create a StreamGeometry for describing the shape
    //            LineGeometry geometry = new LineGeometry();
    //            geometry.StartPoint = Start;
    //            geometry.EndPoint = End;

    //            return geometry;
    //        }
    //    }




    




    /*WPF Arrow and Custom Shapes
    https://www.codeproject.com/Articles/23116/WPF-Arrow-and-Custom-Shapes
    Tomer Shamam, 27 Jan 2008
    */

    public sealed class Arrow : LineEx
    {

        #region Overrides

        protected override Geometry DefiningGeometry
        {
            get
            {
                // Create a StreamGeometry for describing the shape
                StreamGeometry geometry = new StreamGeometry();
                geometry.FillRule = FillRule.EvenOdd;

                using (StreamGeometryContext context = geometry.Open())
                {
                    InternalDrawArrowGeometry(context);
                }

                // Freeze the geometry for performance benefits
                geometry.Freeze();

                return geometry;
            }
        }

        #endregion

        #region Privates

        private void InternalDrawArrowGeometry(StreamGeometryContext context)
        {
            double theta = Math.Atan2(Y1 - Y2, X1 - X2);
            double sint = Math.Sin(theta);
            double cost = Math.Cos(theta);

            Point pt1 = new Point(X1, this.Y1);
            Point pt2 = new Point(X2, this.Y2);

            Point pt3 = new Point(
                X2 + (HeadWidth * cost - HeadHeight * sint),
                Y2 + (HeadWidth * sint + HeadHeight * cost));

            Point pt4 = new Point(
                X2 + (HeadWidth * cost + HeadHeight * sint),
                Y2 - (HeadHeight * cost - HeadWidth * sint));

            context.BeginFigure(pt1, true, false);
            context.LineTo(pt2, true, true);
            context.LineTo(pt3, true, true);
            context.LineTo(pt2, true, true);
            context.LineTo(pt4, true, true);
        }

        #endregion
    }


    public class LineEx : Shape
    {
        #region Dependency Properties

        public static readonly DependencyProperty X1Property = DependencyProperty.Register("X1", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty Y1Property = DependencyProperty.Register("Y1", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty X2Property = DependencyProperty.Register("X2", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty Y2Property = DependencyProperty.Register("Y2", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty HeadWidthProperty = DependencyProperty.Register("HeadWidth", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty HeadHeightProperty = DependencyProperty.Register("HeadHeight", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        #endregion



        [TypeConverter(typeof(LengthConverter))]
        public double X1
        {
            get { return (double)base.GetValue(X1Property); }
            set { base.SetValue(X1Property, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double Y1
        {
            get { return (double)base.GetValue(Y1Property); }
            set { base.SetValue(Y1Property, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double X2
        {
            get { return (double)base.GetValue(X2Property); }
            set { base.SetValue(X2Property, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double Y2
        {
            get { return (double)base.GetValue(Y2Property); }
            set { base.SetValue(Y2Property, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double HeadWidth
        {
            get { return (double)base.GetValue(HeadWidthProperty); }
            set { base.SetValue(HeadWidthProperty, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double HeadHeight
        {
            get { return (double)base.GetValue(HeadHeightProperty); }
            set { base.SetValue(HeadHeightProperty, value); }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                // Create a StreamGeometry for describing the shape
                LineGeometry geometry = new LineGeometry();
                geometry.StartPoint = new Point(X1,Y1);
                geometry.EndPoint = new Point(X2,Y2);

                return geometry;
            }
        }



    }

}