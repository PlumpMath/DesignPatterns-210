using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    public class CompositeShape : Shape {

        public override int Width {
            protected set { }
            get {
                int maxX = shapes[0].X;
                int minX = shapes[0].X;
                foreach(Shape sh in shapes) {
                    if(sh.X + sh.Width > maxX) maxX = sh.X + sh.Width;
                    if(sh.X < minX) minX = sh.X;
                }
                Console.WriteLine("Width: " + (maxX - minX));
                return maxX - minX;
            }
        }

        public override int Height {
            protected set { }
            get {
                int maxY = shapes[0].Y;
                int minY = shapes[0].Y;
                foreach(Shape sh in shapes) {
                    if(sh.Y + sh.Height > maxY) maxY = sh.Y + sh.Height;
                    if(sh.Y < minY) minY = sh.Y;
                }
                return maxY - minY;
            }
        }

        public override int X {
            protected set { }
            get {
                int minX = shapes[0].X;
                foreach(Shape sh in shapes) {
                    if(sh.X < minX) minX = sh.X;
                }
                return minX;
            }
        }

        public override int Y {
            protected set { }
            get {
                int minY = shapes[0].Y;
                foreach(Shape sh in shapes) {
                    if(sh.Y < minY) minY = sh.Y;
                }
                return minY;
            }
        }

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
            //MoveRelative(coords);
            //foreach(Shape s in shapes) {
            //    s.MoveRelative(coords);
            //}
        }

        public override void Resize(Size size) {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g, Point coords, Size size, bool selected = false) {
            Draw(g);
        }

        public override void MoveRelative(Point coords) {
            //foreach(Shape s in shapes) {
            //    s.MoveRelative(coords);
            //}
        }

        public override void Accept(Visitor v) {
            v.Visit(this);
            foreach(Shape sh in shapes) {
                sh.Accept(v);
            }
        }
    }
}
