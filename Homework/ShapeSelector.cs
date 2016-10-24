using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class ShapeSelector {

        private static Point startCoords;
        private static Point currentCoords;
        public static Shape currentShape;
        private static ShapeType shapeType;
        private static bool Started = false;

        private ShapeSelector() { }

        public static void Start(ShapeType shapeType, Point coords) {
            startCoords = coords;
            currentCoords = coords;
            ShapeSelector.shapeType = shapeType;
            Started = true;
        }

        public static void Start(Shape shape, Point coords) {
            currentShape = shape;
            startCoords = coords;
            currentCoords = coords;
            Started = true;
        }

        public static void Update(Point coords) {
            currentCoords = coords;
        }

        public static void End(Point coords) {
            currentCoords = coords;
            if(shapeType == ShapeType.Rectangle) {
                Editor.history.Push(new AddRectangle(GetActualCoords(), GetActualSize()));

            } else if(shapeType == ShapeType.Ellipse) {
                Editor.history.Push(new AddEllipse(GetActualCoords(), GetActualSize()));

            }
            Started = false;
            Editor.screen.Invalidate();
        }

        public static void Move(Point coords) {
            if(currentShape == null) return;
            currentShape.Move(coords);
            //TODO: make shapeselector work better and not draw the old one when there's a new one
        }
        
        public static void Resize(Size size) {
            if(currentShape == null) return;
            currentShape.Resize(size);
        }

        public static void Draw(Graphics g) {
            if(!Started) return;
            if(currentShape != null) {
                currentShape.Draw(g, GetActualCoords(), GetActualSize());
                return;
            }
            if(shapeType == ShapeType.Rectangle) {
                SolidBrush brush = new SolidBrush(Color.Red);
                g.FillRectangle(brush, new System.Drawing.Rectangle(GetActualCoords(), GetActualSize()));
            } else if(shapeType == ShapeType.Ellipse) {
                SolidBrush brush = new SolidBrush(Color.Red);
                g.FillEllipse(brush, new System.Drawing.Rectangle(GetActualCoords(), GetActualSize()));
            }
        }

        public static Point GetActualCoords() {
            if(startCoords.X < currentCoords.X && startCoords.Y < currentCoords.Y) {
                return new Point(startCoords.X, startCoords.Y);
            } else if(startCoords.X > currentCoords.X && startCoords.Y > currentCoords.Y) {
                return new Point(currentCoords.X, currentCoords.Y);
            } else if(startCoords.X > currentCoords.X && startCoords.Y < currentCoords.Y) {
                return new Point(currentCoords.X, startCoords.Y);
            } else {
                return new Point(startCoords.X, currentCoords.Y);
            }
        }

        public static Size GetActualSize() {
            if(startCoords.X < currentCoords.X && startCoords.Y < currentCoords.Y) {
                return new Size(currentCoords.X - startCoords.X, currentCoords.Y - startCoords.Y);
            } else if(startCoords.X > currentCoords.X && startCoords.Y > currentCoords.Y) {
                return new Size(startCoords.X - currentCoords.X, startCoords.Y - currentCoords.Y);
            } else if(startCoords.X > currentCoords.X && startCoords.Y < currentCoords.Y) {
                return new Size(startCoords.X - currentCoords.X, currentCoords.Y - startCoords.Y);
            } else {
                return new Size(currentCoords.X - startCoords.X, startCoords.Y - currentCoords.Y);
            }
        }
    }
}
