using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    class Rectangle {

        //Permanent variables used to initialise the shape
        private Point toCoords;
        private Point fromCoords;

        public Point ToCoords
        {
            get
            {
                return toCoords;
            }
            set
            {
                toCoords = value;
                ActualCoords = GetCoords();
                ActualSize = GetSize();
            }
        }

        public Point ActualCoords { get; set; }
        public Size ActualSize { get; set; }

        public Color BackgroundColor { get; set; } = Color.Black;

        public bool Selected = false;

        public Rectangle(Point start) {
            fromCoords = start;
            toCoords = start;
        }

        public void Draw(Graphics g) {
            SolidBrush brush = new SolidBrush(BackgroundColor);
            g.FillRectangle(brush, new System.Drawing.Rectangle(ActualCoords, ActualSize));
            if(Selected) {
                g.DrawRectangle(new Pen(Color.Black), new System.Drawing.Rectangle(ActualCoords, ActualSize));
            }
        }

        private Point GetCoords() {
            if(toCoords.X < fromCoords.X && toCoords.Y < fromCoords.Y) {
                return new Point(toCoords.X, toCoords.Y);
            } else if(toCoords.X > fromCoords.X && toCoords.Y > fromCoords.Y) {
                return new Point(fromCoords.X, fromCoords.Y);
            } else if(toCoords.X > fromCoords.X && toCoords.Y < fromCoords.Y) {
                return new Point(fromCoords.X, toCoords.Y);
            } else {
                return new Point(toCoords.X, fromCoords.Y);
            }
        }

        private Size GetSize() {
            if(toCoords.X < fromCoords.X && toCoords.Y < fromCoords.Y) {
                return new Size(fromCoords.X - toCoords.X, fromCoords.Y - toCoords.Y);
            } else if(toCoords.X > fromCoords.X && toCoords.Y > fromCoords.Y) {
                return new Size(toCoords.X - fromCoords.X, toCoords.Y - fromCoords.Y);
            } else if(toCoords.X > fromCoords.X && toCoords.Y < fromCoords.Y) {
                return new Size(toCoords.X - fromCoords.X, fromCoords.Y - toCoords.Y);
            } else {
                return new Size(fromCoords.X - toCoords.X, toCoords.Y - fromCoords.Y);
            }
        }

        public bool IsInBounds(Point coords) {
            if(ActualCoords.X <= coords.X && ActualCoords.Y <= coords.Y && ActualCoords.X + ActualSize.Width >= coords.X && ActualCoords.Y + ActualSize.Height >= coords.Y) return true;
            return false;
        }

    }
}
