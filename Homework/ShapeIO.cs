using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class ShapeIO {


        public void GenerateSaveFile(List<Shape> shapes) {

            foreach(Shape shape in shapes) {
                string type = shape.GetType().ToString().Equals("Homework.Rectangle") ? "rectangle" : "ellipse";
                Console.WriteLine(type + " " + shape.X + " " + shape.Y + " " + shape.Width + " " + shape.Height);
            }

        }

    }
}
