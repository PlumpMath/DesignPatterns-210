using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {


    class Rectangle : Shape {

        public Rectangle(Point coords, Size size, Color color) : base(coords.X, coords.Y, size.Width, size.Height, color) {
        }

        public Rectangle(int X, int Y, int Width, int Height, Color color) : base(X, Y, Width, Height, color) {
        }
        
        public override void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false) {
            SolidBrush brush = new SolidBrush(BackgroundColor);
            g.FillRectangle(brush, new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            if(Selected) {
                g.DrawRectangle(new Pen(Color.Black), new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
        }


    }
}
