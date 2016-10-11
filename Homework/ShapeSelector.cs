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

        private ShapeSelector() { }

        public static void Start(Shape shape, Point coords) {
            startCoords = coords;
            currentShape = shape;
        }

        public static void Start(Shape shape) {
            currentShape = shape;
        }

        public static void Update(Point coords) {
            currentCoords = coords;
            currentShape.Move(GetActualCoords());
            currentShape.Resize(GetActualSize());
        }

        public static Shape End(Point coords) {
            currentCoords = coords;
            currentShape.Move(GetActualCoords());
            currentShape.Resize(GetActualSize());
            return currentShape;
        }

        public static void Draw(Graphics g) {
            if(currentShape == null) return;
            currentShape.Draw(g, GetActualCoords(), GetActualSize());
        }

        public static void Move(Point coords) {
            currentShape.Move(coords);
        }
        
        public static void Resize(Size size) {
            currentShape.Resize(size);
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
