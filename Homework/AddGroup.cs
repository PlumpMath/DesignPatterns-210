using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {
    class AddGroup : Command {

        private CompositeShape newshape;
        private List<Shape> selected;

        public AddGroup(List<Shape> selected) {
            this.selected = selected;
            newshape = new CompositeShape();
            newshape.AddRange(selected);
            Editor.history.Push(this);
            Editor.future.Clear();
            Console.WriteLine("History count: " + Editor.history.Count);
            Execute();
        }

        public void Execute() {
            foreach(Shape s in selected) {
                Editor.shapes.Remove(s);
            }
            Editor.shapes.Add(newshape);
        }

        public void Undo() {
            foreach(Shape s in selected) {
                Editor.shapes.Add(s);
            }
            Editor.shapes.Remove(newshape);
        }

    }
}
