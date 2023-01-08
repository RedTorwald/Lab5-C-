using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
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
        
        public void Update(Marker marker)
        {
            if (marker.exist==true)
            {
                float dx=marker.X-this.X;
                float dy=marker.Y-this.Y;
            
                float lenght = (float)MathF.Sqrt(dx*dx + dy*dy);
                dx/=lenght;
                dy/=lenght;

                this.X+= dx*2;
                this.Y+= dy*2;           
            
                this.vX += dx * 0.5f; 
                this.vY += dy * 0.5f;
                this.Angle = 90 - MathF.Atan2(this.vX, this.vY) * 180 / MathF.PI;
            }
            this.vX += -this.vX * 0.1f;
            this.vY += -this.vY * 0.1f;
            this.X += this.vX;
            this.Y += this.vY;
        }
        
    }
}
