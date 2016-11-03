using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {

    public enum TitleLocation {
        TOP,
        BOTTOM,
        //RIGHT,
        //LEFT
    }

    public class ShapeWithTitle : Shape {

        public Dictionary<TitleLocation, string> titles = new Dictionary<TitleLocation, string>();

        public Shape tempShape { private set; get; }
        public override int Width { protected set { } get { return tempShape.Width; } }
        public override int Height { protected set { } get { return tempShape.Width; } }
        public override int X { protected set { } get { return tempShape.X; } }
        public override int Y { protected set { } get { return tempShape.Y; } }

        private Font font;

        public ShapeWithTitle(Shape shape) {
            this.tempShape = shape;
            font = new Font(new FontFamily("Times New Roman"), 32, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public void AddTitle(Dictionary<TitleLocation, string> titles) {
            this.titles = titles;
        }

        public void DisplayTitle(Graphics g) {
            foreach(TitleLocation loc in titles.Keys) {
                if(loc == TitleLocation.TOP) {
                    int width = (int) g.MeasureString(titles[TitleLocation.TOP], font).Width;
                    g.DrawString(titles[TitleLocation.TOP], font, Brushes.Black, tempShape.X + tempShape.Width/2 - width/2, tempShape.Y);
                } else if(loc == TitleLocation.BOTTOM) {
                    int width = (int) g.MeasureString(titles[TitleLocation.BOTTOM], font).Width;
                    g.DrawString(titles[TitleLocation.BOTTOM], font, Brushes.Black, tempShape.X + tempShape.Width/2 - width/2, tempShape.Y + tempShape.Height - g.MeasureString(titles[TitleLocation.BOTTOM], font).Height);
                }
            }
        }

        public override void Accept(Visitor v) {
            v.Visit(this);
            tempShape.Accept(v);
        }

        public override void Draw(Graphics g) {
            tempShape.Draw(g);
            DisplayTitle(g);
        }

        public override void Draw(Graphics g, Point coords, Size size, bool selected = false) {
            tempShape.Draw(g, coords, size, selected);
            DisplayTitle(g);
        }

        public override bool IsInBounds(Point coords) {
            return tempShape.IsInBounds(coords);
        }

        public override void Move(Point coords) {
            tempShape.Move(coords);
        }

        public override void MoveRelative(Point coords) {
            tempShape.MoveRelative(coords);
        }

        public override void Resize(Size size) {
            tempShape.Resize(size);
        }

        public override void SetSelected(bool selected) {
            tempShape.SetSelected(selected);
        }

    }
}
