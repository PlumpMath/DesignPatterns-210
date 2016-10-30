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

    class ShapeWithTitle : Decorator {

        private Dictionary<TitleLocation, string> titles = new Dictionary<TitleLocation, string>();

        private Shape sh;
        private Font font;

        public ShapeWithTitle(Shape shape) : base(shape) {
            this.sh = shape;
            font = new Font(new FontFamily("Times New Roman"), 32, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public void AddTitle(Dictionary<TitleLocation, string> titles) {
            this.titles = titles;
        }

        public void DisplayTitle(Graphics g) {
            Console.WriteLine("displaying: " + titles.Count);
            foreach(TitleLocation loc in titles.Keys) {
                Console.WriteLine(loc);
                if(loc == TitleLocation.TOP) {
                    int width = (int) g.MeasureString(titles[TitleLocation.TOP], font).Width;
                    g.DrawString(titles[TitleLocation.TOP], font, Brushes.Black, X + Width/2 - width/2, Y);
                } else if(loc == TitleLocation.BOTTOM) {
                    int width = (int) g.MeasureString(titles[TitleLocation.BOTTOM], font).Width;
                    g.DrawString(titles[TitleLocation.BOTTOM], font, Brushes.Black, X + Width/2 - width/2, Y + Height - g.MeasureString(titles[TitleLocation.BOTTOM], font).Height);
                }
            }
        }

    }
}
