using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    class ShapeIO {

        private List<string> GenerateString(Shape shape) {
            string type = shape.GetType().ToString().Substring(9);

            List<string> result = new List<string>();
            if(shape is AbstractShape) {
                AbstractShape sh = (AbstractShape) shape;
               result.Add(type + " " + shape.X + " " + shape.Y + " " + sh.Width + " " + sh.Height);
            } else if(shape is CompositeShape) {
               result.Add(type + " " + shape.X + " " + shape.Y);
                CompositeShape sh = (CompositeShape) shape;
                foreach(Shape shap in sh.shapes) {
                    foreach(string s in GenerateString(shap)) {
                        result.Add("\t" + s);
                    }
                }

            }
            return result;
        }

        public void GenerateSaveFile(List<Shape> shapes) {

            List<string> lines = new List<string>();

            foreach(Shape shape in shapes) {
                Console.WriteLine(shape.GetType());
                IOVisitor visitor = new IOVisitor();
                shape.Accept(visitor);
                lines.AddRange(visitor.tree);
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file|*.txt";
            dialog.Title = "Create your save file";
            dialog.ShowDialog();

            if(dialog.FileName != "") {

                File.WriteAllLines(dialog.FileName, lines);

            }

        }

    }
}
