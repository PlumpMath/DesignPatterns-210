using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class IOVisitor : Visitor {

        public List<string> tree = new List<string>();
        int depth = 0;
        int idx;
        int maxidx;

        public void Visit(AbstractShape s) {
            tree.Add(new String('\t', depth) + " " + s.shape + " " + s.X + " " + s.Y + " " + s.Width + " " + s.Height);
            idx++;
            if(idx == maxidx) {
                idx = 0;
                depth--;
            }
        }

        public void Visit(CompositeShape cs) {
            tree.Add(new String('\t', depth) + " " + "group " + cs.shapes.Count());
            maxidx = cs.shapes.Count();
            
            depth++;


        }

        public void Visit(ShapeWithTitle s) {
            string result = new String('\t', depth) + " " + "ornament ";
            foreach(TitleLocation loc in s.titles.Keys) {
                tree.Add(result + loc + " " + s.titles[loc]);
            }
        }

    }
}
