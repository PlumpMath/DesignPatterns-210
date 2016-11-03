using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class SelectVisitor : Visitor {

        private bool selected;

        public SelectVisitor(bool selected) {
            this.selected = selected;
        }

        public void Visit(ShapeWithTitle s) {
            s.SetSelected(selected);
        }

        public void Visit(AbstractShape s) {
            s.SetSelected(selected);
        }

        public void Visit(CompositeShape s) {
            s.SetSelected(selected);
        }
    }
}
