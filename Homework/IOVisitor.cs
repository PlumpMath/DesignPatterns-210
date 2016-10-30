using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class IOVisitor : Visitor {

        public List<string> tree = new List<string>();

        public void Visit(AbstractShape s) {
            string type = s.GetType().ToString().Substring(9);
            tree.Add(type + " " + s.X + " " + s.Y + " " + s.Width + " " + s.Height);
        }

        public void Visit(CompositeShape cs) {
            string type = cs.GetType().ToString().Substring(9);
            tree.Add(type + " " + cs.shapes.Count());
        }
    }
}
