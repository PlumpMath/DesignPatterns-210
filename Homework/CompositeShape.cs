using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class CompositeShape : Shape {

        public List<Shape> shapes = new List<Shape>();

        public CompositeShape() {
            this.shape = ShapeType.Group;
        }

        public void Add(Shape shape) {
            this.shapes.Add(shape);
        }

        public void Remove(Shape shape) {
            this.shapes.Remove(shape);
        }

        public override void Draw(Graphics g) {
            foreach(Shape shap in shapes) {
                shap.Draw(g);
            }
        }

        public void AddRange(List<Shape> selected) {
            shapes.AddRange(selected);
        }

        public override bool IsInBounds(Point coords) {
            bool found = false;
            foreach(Shape s in shapes) {
                if(s.IsInBounds(coords)) {
                    found = true;
                    break;
                }
            }
            foreach(Shape s in shapes) {
                s.Selected = found;
            }
            return found;
        }

        public override void Move(Point coords) {
            foreach(Shape s in shapes) {
                s.MoveRelative(coords);
            }
        }

        public override void Resize(Size size) {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g, Point coords, Size size, bool selected = false) {
            Draw(g);
        }

        public override void MoveRelative(Point coords) {
            throw new NotImplementedException();
        }
    }
}
