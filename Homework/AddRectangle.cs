﻿using System;
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
        Shape shape;

        public AddRectangle(Point coords, Size size) {
            this.X = coords.X;
            this.Y = coords.Y;
            this.Width = size.Width;
            this.Height = size.Height;
            Execute();
        }

        public AddRectangle(int X, int Y, int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            Execute();
        }

        public void Execute() {
            shape = new Rectangle(X, Y, Width, Height, Color.Red);
            Shape.shapes.Add(shape);
        }

        public void Undo() {
            Console.WriteLine("Removing: " + X + " " + Y);
            Shape.shapes.Remove(shape);
        }
    }
}