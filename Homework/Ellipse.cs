using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    class Ellipse : AbstractShape {
        
        public Ellipse(Point coords, Size size, Color color) : base(coords.X, coords.Y, size.Width, size.Height, color) {
        }

        public Ellipse(int X, int Y, int Width, int Height, Color color) : base(X, Y, Width, Height, color) {
        }
        
        public override void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false) {
            SolidBrush brush = new SolidBrush(BackgroundColor);
            g.FillEllipse(brush, new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            if(Selected) {
                g.DrawEllipse(new Pen(Color.Black), new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
        }

    }
}
