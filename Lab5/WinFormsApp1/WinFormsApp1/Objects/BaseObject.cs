using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Objecrs
{
    internal class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
        public float R;

        public float timer=60;

        public Action<BaseObject, BaseObject> Intersec;
        public BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
            
        }

        public Matrix GetTransform()
        {
            var matrix=new Matrix();           
            matrix.Translate(X, Y); 
            matrix.Rotate(Angle);
            
            return matrix;
        }

        public virtual void Intersections(BaseObject obj)  //абстрактный метод
        {
            if (this.Intersec != null)
            {
                this.Intersec(this, obj);
            }
        }

        public virtual void Render(Graphics g)  //абстрактный метод
        {
            
        }


    }
}
