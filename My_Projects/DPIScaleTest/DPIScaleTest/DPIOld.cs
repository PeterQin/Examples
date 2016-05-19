using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DPIScaleTest
{
    public class DPIOld
    {
        const double TRADITIONAL_DPI = 96.0; //96DPI is the usual setting, i.e. the 100% DPI
        private static double? FDPIRatio;

        public static bool IsHighAPI()
        {
            return GetRatio() != 1.0;
        }

        public static double GetRatio() //get the scale rate, e.g. 125% DPI return 1.25
        {
            if (FDPIRatio.HasValue)
            {
                return FDPIRatio.Value;
            }
            else
            {

                using (System.Drawing.Graphics g = frmXtraForm1.Form.CreateGraphics())
                {
                    double ratio = g.DpiX / TRADITIONAL_DPI;
                    FDPIRatio = ratio;
                    return ratio;
                }

            }
        }

        public static int Scale(int i) //simply scale the value by the DPI rate
        {
            return (int)(i * GetRatio());
        }

        public static double Scale(double i) //simply scale the value by the DPI rate
        {
            return i * GetRatio();
        }

        public static Size Scale(Size s) //simply scale the value by the DPI rate
        {
            double ratio = GetRatio();
            return new Size((int)(s.Width * ratio), (int)(s.Height * ratio));
        }

        public static Point Scale(Point p) //simply scale the value by the DPI rate
        {
            double ratio = GetRatio();
            return new Point((int)(p.X * ratio), (int)(p.Y * ratio));
        }
    }
}
