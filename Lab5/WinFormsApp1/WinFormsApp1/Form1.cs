using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Objecrs;
using WinFormsApp1.Objects;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new List<BaseObject>();

        Player player;
        Marker marker;
        int counter=0; 
        public Form1()
        {
            InitializeComponent();
            player = new Player(pb.Width/2, pb.Height/2, 0, 0); 

            player.Intersec += (p, obj) =>
            {
                log.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + log.Text;
            };


            marker = new Marker (pb.Width/2+1, pb.Height/2+1,0, 20);
        
            objects.Add(new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30));
            objects.Add(new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30));
            objects.Add(new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30));
        
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;            
            g.Clear(Color.White);  

            for (int i = 0; i < objects.Count; i++)
            { 
                 if (player.Intersection(objects[i]))
                 {
                    counter+=1;
                    objects[i] = new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30);                   
                    player.Intersections(objects[i]); 
                    objects[i].Intersections(player);
                    goals.Text=$"Oчки: {counter}";
                   
                 }
                
                 objects[i].timer-=0.4f;

                 if (objects[i].timer < 0)
                 {
                     objects[i] = new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30);
                 }

                 objects[i].R-=0.215f;
                 if (objects[i].R < 0)
                 {
                    objects[i] = new Circle(new Random().Next(15, pb.Width-15), new Random().Next(15, pb.Height-15), 0, 30);
                 }
                 

                 g.Transform =objects[i].GetTransform();
                 objects[i].Render(g); 
            }
            
            g.Transform = player.GetTransform();
            player.Render(g);

            if (player.Intersection(marker))
            {
                marker.exist=false;               
            }
            
            if (marker.exist==true)
            {
                g.Transform = marker.GetTransform();
                marker.Render(g);
            }           
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (marker.exist==true)
            {
                float dx=marker.X-player.X;
                float dy=marker.Y-player.Y;
            
                float lenght = (float)MathF.Sqrt(dx*dx + dy*dy);
                dx/=lenght;
                dy/=lenght;

                player.X+= dx*2;
                player.Y+= dy*2;           
            
                player.vX += dx * 0.5f; 
                player.vY += dy * 0.5f;
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            
            player.X += player.vX;
            player.Y += player.vY;

            pb.Invalidate();
        }


        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            marker.exist=true;
            marker.X=e.X;
            marker.Y=e.Y;           
        }
    }
}