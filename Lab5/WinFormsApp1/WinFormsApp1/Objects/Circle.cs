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
        public float originR;		

        public Circle(float x, float y, float angle, float r) : base(x, y, angle)
        {
             this.R=r;
			 originR=r;
        }

        public void Update(Player player, Label goals, PictureBox pb) {
			if (player.Intersection(this)) {
				Form1.counter += 1;
				
				Respawn(pb);

				player.Intersections(this);
				this.Intersections(player);
				goals.Text = $"Oчки: {Form1.counter}";

			}

			this.timer -= 0.4f;

			if (this.timer < 0) {
				Respawn(pb);
			}

			this.R -= 0.215f;
			if (this.R < 0) {
				Respawn(pb);
			}
		}

		public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -R/2, -R/2, R, R);
            g.DrawEllipse(new Pen(Color.Green),  -R/2,-R/2, R, R);
            g.DrawString( ((int)(timer)).ToString(), new Font("Arial", 8), 
            new SolidBrush(Color.Green), R/3, R/3);
        }

		public void Respawn(PictureBox pb)
		{
			this.X=new Random().Next(15, pb.Width - 15);
			this.Y=new Random().Next(15, pb.Height - 15);
		    this.Angle=0;
			this.R=originR;
			this.timer=60;
		} 		
       
    }
}