using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    public class Rectangle : Strategy {

        private static Rectangle instance;
        public static Rectangle Instance
        {
            get
            {
                if(instance == null) {
                    instance = new Rectangle();
                }
                return instance;
            }
            private set { }
        }

        private Rectangle() { }

        public void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false) {
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            if(Selected) {
                g.DrawRectangle(new Pen(Color.Black), new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
        }

    }
}
