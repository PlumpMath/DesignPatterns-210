using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    public abstract class Shape : Command {

        public int X { private set; get; }
        public int Y { private set; get; }
        public int Width { private set; get; }
        public int Height { private set; get; }
        public ShapeType shape { private set; get; }
        public Color BackgroundColor;
        public bool Selected = false;
        public static Stack<Command> history = new Stack<Command>();

        public Shape(int X, int Y, int Width, int Height, Color color) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.BackgroundColor = color;
            Shape.history.Push(this);
            Console.WriteLine(Shape.history.Count);
        }

        public void Execute(Graphics g) {
            Draw(g);
        }

        public void Undo(Graphics g) {
            Command cmd = Shape.history.Pop();
            cmd.Execute(g);
        }

        public void Move(Point coords) {
            this.X = coords.X;
            this.Y = coords.Y;
        }

        public void Resize(Size size) {
            this.Width = size.Width;
            this.Height = size.Height;
        }
        
        public void Draw(Graphics g) {
            Draw(g, X, Y, Width, Height, Selected);
        }

        public void Draw(Graphics g, Point location, Size size, bool Selected = false) {
            Draw(g, location.X, location.Y, size.Width, size.Height, Selected);
        }
    
        public abstract void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false);

        public bool IsInBounds(Point coords) {
            if (X <= coords.X && Y <= coords.Y && X + Width >= coords.X && Y + Height >= coords.Y) return true;
            return false;
        }

    }
}
