using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework {
    class MoveVisitor : Visitor {

        private int X, Y;

        public MoveVisitor(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }


        public void Visit(AbstractShape s) {
            s.Move(new System.Drawing.Point(X, Y));
        }

        public void Visit(CompositeShape cs) {
            cs.Move(new System.Drawing.Point(X, Y));
        }

    }
}
