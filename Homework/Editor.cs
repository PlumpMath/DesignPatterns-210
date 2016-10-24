﻿using System;
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
        Ellipse,
        Group
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
        public static List<Shape> shapes = new List<Shape>();


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
                Console.WriteLine(shapeType);
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
            shapeBox.Items.Clear();
            shapeBox.Groups.Clear();
            foreach(Shape shape in shapes) {
                shape.Draw(g);
                if(shape.shape == ShapeType.Group) {
                    ListViewGroup membersGroup = new ListViewGroup(shape.shape + "_" + shape.ID, HorizontalAlignment.Left);
                    shapeBox.Groups.Add(membersGroup);
                    foreach(Shape s in ((CompositeShape)shape).shapes) {
                        shapeBox.Items.Add(new ListViewItem() { Text = s.shape + "_" + s.ID, Group = membersGroup });
                    }
                } else {
                    shapeBox.Items.Add(shape.shape + "_" + shape.ID);
                }
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
                foreach(Shape shape in shapes) {
                    if(shape.IsInBounds(e.Location) && !found) {
                        ShapeSelector.Start(shape, e.Location);
                        //Size actualSize = ShapeSelector.GetActualSize();
                        //widthUpDown.Value = actualSize.Width;
                        //heightUpDown.Value = actualSize.Height;
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
            io.GenerateSaveFile(shapes);
        }

        private void groupButton_Click(object sender, EventArgs e) {
            List<Shape> selected = new List<Shape>();
            foreach(ListViewItem txt in shapeBox.SelectedItems) {
                int id = int.Parse(txt.Text.Split('_')[1]);
                selected.Add(GetShape(id));
            }
            CompositeShape comp = new CompositeShape();
            foreach(Shape s in selected) {
                shapes.Remove(s);
            }
            comp.AddRange(selected);
            shapes.Add(comp);

            screenBox.Invalidate();

        }

        private Shape GetShape(int ID) {
            foreach(Shape sh in shapes) {
                if(sh.ID == ID) return sh;
            }
            return null;
        }
    }
}
