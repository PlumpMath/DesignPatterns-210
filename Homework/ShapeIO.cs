using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    class ShapeIO {


        public void GenerateSaveFile(List<Shape> shapes) {

            string[] lines = new string[shapes.Count];
            int idx = 0;
            foreach(AbstractShape shape in shapes) {
                string type = shape.GetType().ToString().Equals("Homework.Rectangle") ? "rectangle" : "ellipse";
                lines[idx++] = type + " " + shape.X + " " + shape.Y + " " + shape.Width + " " + shape.Height;
                Console.WriteLine(type + " " + shape.X + " " + shape.Y + " " + shape.Width + " " + shape.Height);
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
