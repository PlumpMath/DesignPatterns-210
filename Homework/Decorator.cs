using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    abstract class Decorator : Shape {

        protected Shape shapeObj;

        public Decorator(Shape shape) {
            this.shapeObj = shape;
            this.X = shape.X;
            this.Y = shape.Y;
            this.Width = shape.Width;
            this.Height = shape.Height;
            this.shape = shape.shape;
            this.Selected = shape.Selected;
        }

        public override void Accept(Visitor v) {
            shapeObj.Accept(v);
        }

        public override void Draw(Graphics g) {
            shapeObj.Draw(g);
        }

        public override void Draw(Graphics g, Point coords, Size size, bool selected = false) {
            shapeObj.Draw(g, coords, size, selected);
        }

        public override bool IsInBounds(Point coords) {
            return shapeObj.IsInBounds(coords);
        }

        public override void Move(Point coords) {
            shapeObj.Move(coords);
        }

        public override void MoveRelative(Point coords) {
            shapeObj.MoveRelative(coords);
        }

        public override void Resize(Size size) {
            shapeObj.Resize(size);
        }
    }
}
