using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Objecrs;

namespace WinFormsApp1.Objects
{
    internal class Circle: BaseObject
    {
        
        public Circle(float x, float y, float angle, float r) : base(x, y, angle)
        {
             this.R=r;
        }

       
        
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -R/2, -R/2, R, R);
            g.DrawEllipse(new Pen(Color.Green),  -R/2,-R/2, R, R);
            g.DrawString( ((int)(timer)).ToString(), new Font("Arial", 8), 
            new SolidBrush(Color.Green), R/3, R/3);
        }
       
    }
}
