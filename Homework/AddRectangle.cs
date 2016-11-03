using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class AddRectangle : Command {

        private int X;
        private int Y;
        private int Width;
        private int Height;
        AbstractShape shape;

        public AddRectangle(Point coords, Size size) {
            this.X = coords.X;
            this.Y = coords.Y;
            this.Width = size.Width;
            this.Height = size.Height;
            shape = new AbstractShape(X, Y, Width, Height, Color.Red, ShapeType.Rectangle, Rectangle.Instance);
            Editor.history.Push(this);
            Editor.future.Clear();
            Console.WriteLine("History count: " + Editor.history.Count);
            Execute();
        }

        public AddRectangle(int X, int Y, int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            shape = new AbstractShape(X, Y, Width, Height, Color.Red, ShapeType.Rectangle, Rectangle.Instance);
            Editor.history.Push(this);
            Editor.future.Clear();
            Console.WriteLine("History count: " + Editor.history.Count);
            Execute();
        }

        public void Execute() {
            Editor.shapes.Add(shape);
        }

        public void Undo() {
            Editor.shapes.Remove(shape);
        }
    }
}
