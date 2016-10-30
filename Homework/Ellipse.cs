using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    public class Ellipse : Strategy {

        private static Ellipse instance;
        public static Ellipse Instance
        {
            get
            {
                if(instance == null) {
                    instance = new Ellipse();
                }
                return instance;
            }
            private set { }
        }


        private Ellipse() {

        }
        
        public void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false) {
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            if(Selected) {
                g.DrawEllipse(new Pen(Color.Black), new System.Drawing.Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
        }

    }
}
