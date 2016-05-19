using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DPIScaleTest
{
    public enum BoundsScale
    {
        None = 0,
        Width = 2,
        Height = 4,
    }

    class DPINew
    {       

        public static bool IsHighDPI(SizeF aScaleFactor)
        {
            return (aScaleFactor.Height != 1.0 && aScaleFactor.Width != 1.0);   //Normal is 1.0
        }

        public static int Scale(int i, SizeF aScaleFactor, BoundsScale aBounds) //simply scale the value by the DPI rate
        {
            if (aBounds == BoundsScale.Height)
            {
                return (int)Math.Round(i * aScaleFactor.Height, 0);
            }
            else
            {
                return (int)Math.Round(i * aScaleFactor.Width, 0);
            }
           
        }

        public static double Scale(double i, SizeF aScaleFactor, BoundsScale aBounds) //simply scale the value by the DPI rate
        {
            if (aBounds == BoundsScale.Height)
            {
                return i * aScaleFactor.Height;
            }
            else
            {
                return i * aScaleFactor.Width;
            }
            
        }

        public static Size Scale(Size s, SizeF aScaleFactor) //simply scale the value by the DPI rate
        {
            int x = (int)Math.Round(s.Width * aScaleFactor.Width, 0);
            int y = (int)Math.Round(s.Height * aScaleFactor.Height, 0);
            return new Size(x,y);
        }

        public static Point Scale(Point p, SizeF aScaleFactor) //simply scale the value by the DPI rate
        {
            int x = (int)Math.Round(p.X * aScaleFactor.Width, 0);
            int y = (int)Math.Round(p.Y * aScaleFactor.Height, 0);
            return new Point(x, y);
        }
    }
}
