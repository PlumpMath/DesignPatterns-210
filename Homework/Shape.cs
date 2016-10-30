using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    public abstract class Shape {
        public int X { protected set; get; }
        public int Y { protected set; get; }
        public static int MaxID;
        public int ID { private set; get; }
        public ShapeType shape { protected set; get; }
        public bool Selected = false;

        public abstract void Draw(Graphics g, Point coords, Size size, bool selected = false);
        public abstract void Draw(Graphics g);
        public abstract bool IsInBounds(Point coords);
        public abstract void Move(Point coords);
        public abstract void MoveRelative(Point coords);
        public abstract void Resize(Size size);
        public abstract void Accept(Visitor v);

        public Shape(bool temp = false) {
             ID = MaxID++;
        }

    }
}
