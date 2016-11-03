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

            Console.WriteLine("Old shape: " + (oldShape.GetType() == typeof(ShapeWithTitle)));
            if(oldShape.GetType() == typeof(ShapeWithTitle)) {
                this.shape = (ShapeWithTitle)oldShape;
            } else {
                this.shape = new ShapeWithTitle(oldShape);
            }
            this.shape.AddTitle(titles);
            Editor.history.Push(this);

            Editor.future.Clear();
            Console.WriteLine("History count: " + Editor.history.Count);
            Execute();
        }

        public void Execute() {
            ShapeSelector.currentShape = shape;
            Editor.shapes.Remove(oldShape);
            Editor.shapes.Add(shape);
        }

        public void Undo() {
            Editor.shapes.Add(oldShape);
            Editor.shapes.Remove(shape);
        }

    }
}
