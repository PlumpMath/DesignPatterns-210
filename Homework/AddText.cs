using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class AddText : Command {

        private Shape oldShape;
        private ShapeWithTitle shape;
        private Dictionary<TitleLocation, string> titles = new Dictionary<TitleLocation, string>();

        public AddText(Shape shape, Dictionary<TitleLocation, string> titles) {
            this.oldShape = shape;
            this.titles = titles;
            Execute();
        }

        public void Execute() {
            shape = new ShapeWithTitle(oldShape);
            ShapeSelector.currentShape = shape;
            shape.AddTitle(titles);
            Editor.shapes.Remove(oldShape);
            Editor.shapes.Add(shape);
        }

        public void Undo() {
            Editor.shapes.Add(oldShape);
            Editor.shapes.Remove(shape);
        }

    }
}
