using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework {

    public enum ShapeType {
        Rectangle,
        Ellipse
    }

    public enum ActionType {
        Move,
        Select,
        Draw
    }

    public interface Command {
        void Execute();
        void Undo();
    }

    public partial class Editor : Form {

        private bool mouseDown = false;
        private ActionType currentAction;
        private ShapeIO io;
        public static PictureBox screen;
        public static Stack<Command> history = new Stack<Command>();


        public Editor() {
            InitializeComponent();
            screen = screenBox;
            shapePicker.SelectedIndex = 0;
            actionPicker.SelectedIndex = 0;
            io = new ShapeIO();
        }

        private void ScreenBox_MouseDown(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                mouseDown = true;
                ShapeType shapeType = shapePicker.SelectedItem.ToString() == "Rectangle" ? ShapeType.Rectangle : ShapeType.Ellipse;
                ShapeSelector.Start(shapeType, e.Location);
                screenBox.Invalidate();
            } else if(currentAction == ActionType.Move) {
                mouseDown = true;
            }


        }

        private void ScreenBox_MouseMove(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                if(mouseDown) {
                    ShapeSelector.Update(e.Location);
                    Size actualSize = ShapeSelector.GetActualSize();
                    widthUpDown.Value = actualSize.Width;
                    heightUpDown.Value = actualSize.Height;
                    screenBox.Invalidate();
                }
            } else if(currentAction == ActionType.Move) {
                if(mouseDown) {
                    ShapeSelector.Move(e.Location);
                    screenBox.Invalidate();
                }

            }


        }

        private void ScreenBox_MouseUp(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                mouseDown = false;
                ShapeSelector.End(e.Location);
                screenBox.Invalidate();
            } else if(currentAction == ActionType.Move) {
                mouseDown = false;
                ShapeSelector.Move(e.Location);
                screenBox.Invalidate();
            }


        }

        private void screenBox_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            ShapeSelector.Draw(e.Graphics);
            foreach(Shape shape in Shape.shapes) {
                shape.Draw(g);
            }

        }

        private void Editor_Paint(object sender, PaintEventArgs e) {
        }

        private void actionPicker_SelectedIndexChanged(object sender, EventArgs e) {
            if(actionPicker.SelectedIndex == 0) {
                currentAction = ActionType.Draw;
            } else if(actionPicker.SelectedIndex == 1) {
                currentAction = ActionType.Move;
            } else if(actionPicker.SelectedIndex == 2) {
                currentAction = ActionType.Select;
            }
        }

        private void screenBox_MouseClick(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Select) {
                bool found = false;
                foreach(Shape shape in Shape.shapes) {
                    if(shape.IsInBounds(e.Location) && !found) {
                        ShapeSelector.Start(shape);
                        shape.Selected = true;
                    } else {
                        shape.Selected = false;
                    }
                }
                screenBox.Invalidate();

            }

        }

        private void widthUpDown_ValueChanged(object sender, EventArgs e) {
            if(mouseDown) return;
            ShapeSelector.Resize(new Size((int) widthUpDown.Value, (int) heightUpDown.Value));
            screenBox.Invalidate();
        }

        private void heightUpDown_ValueChanged(object sender, EventArgs e) {
            if(mouseDown) return;
            ShapeSelector.Resize(new Size((int) widthUpDown.Value, (int) heightUpDown.Value));
            screenBox.Invalidate();
        }

        private void undoButton_Click(object sender, EventArgs e) {
            Command cmd = history.Pop();
            cmd.Undo();
            Editor.screen.Invalidate();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            io.GenerateSaveFile(Shape.shapes);
        }
    }
}
