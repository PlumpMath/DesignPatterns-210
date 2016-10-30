using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {

    public interface Strategy {
        void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false);
    }

    public class AbstractShape : Shape {

        public Color BackgroundColor;

        Strategy strategy;

        public AbstractShape(int X, int Y, int Width, int Height, Color color, Strategy strat) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.BackgroundColor = color;
            this.strategy = strat;

            // Snap niet waarom je delegate moet gebruiken, en waarom er staat dat de delegate 
            // een singleton object kan zijn aangezien een delegate een pointer naar een functie is?
        }   

        public override void Move(Point coords) {
            this.X += coords.X;
            this.Y += coords.Y;
        }

        public override void MoveRelative(Point coords) {
            this.X += coords.X;
            this.Y += coords.Y;
        }

        public override void Resize(Size size) {
            this.Width = size.Width;
            this.Height = size.Height;
        }
        
        public override void Draw(Graphics g) {
            Draw(g, X, Y, Width, Height, Selected);
        }

        public override void Draw(Graphics g, Point location, Size size, bool Selected = false) {
            Draw(g, location.X, location.Y, size.Width, size.Height, Selected);
        }
    
        public void Draw(Graphics g, int X, int Y, int Width, int Height, bool Selected = false) {
            strategy.Draw(g, X, Y, Width, Height, Selected);
        }

        public override bool IsInBounds(Point coords) {
            if (X <= coords.X && Y <= coords.Y && X + Width >= coords.X && Y + Height >= coords.Y) return true;
            return false;
        }

        public override void Accept(Visitor v) {
            v.Visit(this);
        }

    }
}
