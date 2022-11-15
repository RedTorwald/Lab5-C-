using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Objecrs
{
    internal class Marker: BaseObject
    {
        public bool exist;
        public Marker(float x, float y, float angle, float r) : base(x, y, angle)
        {
            this.R=r;
            this.exist=false;
        }        

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red),  -(R/20)*3, -(R/20)*3, (R/20)*6, (R/20)*6);
            g.DrawEllipse(new Pen(Color.Red, 2), -(R/20)*6, -(R/20)*6, (R/20)*12, (R/20)*12);           
            g.DrawEllipse(new Pen(Color.Black, 2),  -R/2,-R/2, R, R);
        }
        
    }
}
