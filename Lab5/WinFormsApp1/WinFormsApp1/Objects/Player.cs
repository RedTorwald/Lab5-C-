using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Objecrs
{
    internal class Player: BaseObject
    {
        float dx;
        float dy;
        public float vX, vY;
        public Player(float x, float y, float angle, float r) : base(x, y, angle)
        {
            this.R=r;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.SkyBlue), -15, -15, 30, 30);

            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);

            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
        
        public virtual bool Intersection(BaseObject obj)
        {
            this.dx=obj.X-this.X;    
            this.dy=obj.Y-this.Y; 

            float lenght=MathF.Sqrt(dx*dx+dy*dy);
            if (lenght<this.R + obj.R)
            {
                return true;
            }
            return false;
        }       
        
    }
}
