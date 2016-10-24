using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework {
    class AddEllipse : Command {

        private int X;
        private int Y;
        private int Width;
        private int Height;
        private AbstractShape shape;

        public AddEllipse(Point coords, Size size) {
            this.X = coords.X;
            this.Y = coords.Y;
            this.Width = size.Width;
            this.Height = size.Height;
            Execute();
        }

        public AddEllipse(int X, int Y, int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            Execute();
        }

        public void Execute() {
            shape = new Ellipse(X, Y, Width, Height, Color.Red);
            Editor.shapes.Add(shape);
        }

        public void Undo() {
            Editor.shapes.Remove(shape);
        }

    }
}
