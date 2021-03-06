using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace firefox
{

    public class Util : Form
    {
        
        //Converts from degrees to radians.
        public double degToRad(double degrees)
        {
            return degrees * 3.14 / 180;
        }

        //Converts from radians to degrees.
        public double radToDeg(double radians)
        {
            return radians * 180 / 3.14;
        }
        public int FindClosestCorrection(double x, double y)
        {
            double distance = 99999;
            int index = 0;
            for (int z = 0; z < Globals.corrections.Count; z++)
            {
                if (pointDistance(Globals.corrections[z].X,
                    Globals.corrections[z].Y, x, y) < distance)
                {
                    distance = pointDistance(Globals.corrections[z].X,
                    Globals.corrections[z].Y, x, y);
                    index = z;
                }
            }
            return index;
        }

        //Distance between points
        public static double pointDistance(double x1, double y1, double x2, double y2)
        {
            double xDistSq = Math.Pow(x2 - x1, 2);
            double yDistSq = Math.Pow(y2 - y1, 2);
            return Math.Sqrt(xDistSq + yDistSq);
        }

        public void Waiter(int v1, int v2)
        {
            int index = 0;
            index = FindClosestCorrection(v1, v2);
            
                //390x365 - 955x480 = 1s
                double stat = pointDistance(Globals.corrections[index].X,
                    Globals.corrections[index].Y, 955, 480);
                double dyn = pointDistance(v1, v2, 955, 480);
                double coef = dyn / stat;
                Console.WriteLine(coef.ToString());
                //if (coef > 1) coef = 1;
                Thread.Sleep((int)Math.Round(coef * 400.0)); 
                return;
                
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);

        public Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }

        static Bitmap imagef = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
        //for not fill cache with trash
        static Graphics gfxf = Graphics.FromImage(imagef);
        public Bitmap CaptureScreenf(int x = 0, int y = 0)
        {
            Rectangle rectangle = new Rectangle(0, 0, 50, 51);
            gfxf.Dispose();
            imagef.Dispose();
            imagef = new Bitmap(41,
                                41,
                                PixelFormat.Format32bppArgb);
            gfxf = Graphics.FromImage(imagef);
            gfxf.CopyFromScreen(x,
                                y,
                                0, 0,
                                rectangle.Size, CopyPixelOperation.SourceCopy);
            return imagef;
        }
        static Rectangle rectangle = new Rectangle(0, 0, 50, 51);
        public Bitmap CaptureScreenfd()
        {
            gfxf.Dispose();
            imagef.Dispose();
            rectangle = new Rectangle(0, 0, 50, 51);
            imagef = new Bitmap(41,
                                41,
                                PixelFormat.Format32bppArgb);
            gfxf = Graphics.FromImage(imagef);
            gfxf.CopyFromScreen(Globals.d1x[Globals.i] - 15,
                                                   Globals.d1y[Globals.i] - 30,
                                0, 0,
                                rectangle.Size, CopyPixelOperation.SourceCopy);
            return imagef;
        }
        static Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
        //for not fill cache with trash
        static Graphics gfx = Graphics.FromImage(image);
        public Bitmap CaptureScreen()
        {
            gfx.Dispose();
            image.Dispose();
            image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            gfx = Graphics.FromImage(image);
            gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return image;
        }
        //send Point as System.Drawing.Point point = new System.Drawing.Point(x: 0, y: 0);
        //for not fill cache with trash
        static Point minLoc = new Point();
        static Point maxLoc = new Point();
        static Mat mat = new Mat();
        static double minV = 0;
        static double maxV = 0;
        static Image<Bgr, byte> templatex;
        static Image<Bgr, byte> imageinx;
        public Point LocateOnScreen(Bitmap template, double confidance)
        {
            try
            {
                mat = new Mat();
                templatex = CaptureScreen().ToImage<Bgr, byte>();
                imageinx = template.ToImage<Bgr, byte>();

                CvInvoke.MatchTemplate(imageinx, templatex, mat, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                CvInvoke.MinMaxLoc(mat, ref minV, ref maxV, ref minLoc, ref maxLoc);

                mat.Dispose();
                templatex.Dispose();
                imageinx.Dispose();
                //Console.WriteLine(maxV.ToString());
                if (confidance < 0.1)
                {
                    Globals.confidance = maxV - 0.05;
                }
                if (maxV > confidance)
                    return maxLoc;
                else
                {
                    return new Point(); ;
                }
            }
            catch
            {
                return new Point();
            }
            
        }
        

        public bool isOnImage(Bitmap source, Bitmap template, double confidance)
        {
            var templatex = source.ToImage<Bgr, byte>();
            var imageinx = template.ToImage<Bgr, byte>();
            Mat mat = new Mat();
            double minV = 0.0;
            double maxV = 0.0;
            Point minLoc = new Point();
            Point maxLoc = new Point();
            CvInvoke.MatchTemplate(imageinx, templatex, mat, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);
            CvInvoke.MinMaxLoc(mat, ref minV, ref maxV, ref minLoc, ref maxLoc);
            //Console.WriteLine(minV);
            templatex.Dispose();
            imageinx.Dispose();
            mat.Dispose();
            if (maxV > confidance)
                return true;
            else
            {
                maxLoc = new Point();
                return false;
            }
        }
    }
}