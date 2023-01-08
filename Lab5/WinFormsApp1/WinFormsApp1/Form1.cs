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
        List<Circle> objects = new List<Circle>();

        Player player;
        Marker marker;
        static public int counter = 0;
        
        public Form1()
        {
            InitializeComponent();                                                            //инициализация основных объектов
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
                g.Transform = objects[i].GetTransform();
                objects[i].Update(player, goals, pb);
                objects[i].Render(g); 
            }

            
            g.Transform = player.GetTransform();
			player.Update(marker);
			player.Render(g);

            if (marker.exist==true)
            {
                g.Transform = marker.GetTransform();
				marker.Update(player);
				marker.Render(g);
            }           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pb.Invalidate();
        }

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            marker.SetPosition(e.X, e.Y);      
        }
    }
}