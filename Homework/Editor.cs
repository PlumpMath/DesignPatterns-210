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

    public partial class Editor : Form {

        private bool mouseDown = false;
        List<Rectangle> rectangles;
        List<Ellipse> ellipses;

        private ShapeType currentShape;
        private Rectangle currentRectangle;
        private Ellipse currentEllipse;

        private ActionType currentAction;

        public Editor() {
            InitializeComponent();
            shapePicker.SelectedIndex = 0;
            actionPicker.SelectedIndex = 0;

            rectangles = new List<Rectangle>();
            ellipses = new List<Ellipse>();
        }

        private void ScreenBox_MouseDown(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                mouseDown = true;
                if(shapePicker.SelectedItem.ToString() == "Rectangle") {
                    currentShape = ShapeType.Rectangle;
                    currentRectangle = new Rectangle(e.Location);
                    currentRectangle.BackgroundColor = Color.Red;
                    rectangles.Add(currentRectangle);

                } else if(shapePicker.SelectedItem.ToString() == "Ellipse") {
                    currentShape = ShapeType.Ellipse;
                    currentEllipse = new Ellipse(e.Location);
                    currentEllipse.BackgroundColor = Color.Red;
                    ellipses.Add(currentEllipse);
                }
                screenBox.Invalidate();
            } else if(currentAction == ActionType.Move) {
                mouseDown = true;
            }


        }

        private void ScreenBox_MouseMove(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                if(mouseDown) {
                    if(currentShape == ShapeType.Rectangle) {
                        currentRectangle.ToCoords = e.Location;
                    } else if (currentShape == ShapeType.Ellipse) {
                        currentEllipse.ToCoords = e.Location;
                    }
                    screenBox.Invalidate();
                }

            } else if(currentAction == ActionType.Move) {
                if(mouseDown) {
                    if(currentShape == ShapeType.Rectangle) {
                        currentRectangle.ActualCoords = e.Location;
                    } else if (currentShape == ShapeType.Ellipse) {
                        currentEllipse.ActualCoords = e.Location;
                    }
                    screenBox.Invalidate();
                }

            }


        }

        private void ScreenBox_MouseUp(object sender, MouseEventArgs e) {
            if(currentAction == ActionType.Draw) {
                mouseDown = false;
                screenBox.Invalidate();
            } else if(currentAction == ActionType.Move) {
                mouseDown = false;
                if(currentShape == ShapeType.Rectangle) {
                    currentRectangle.Selected = false;
                } else if (currentShape == ShapeType.Ellipse) {
                    currentEllipse.Selected = false;
                }
                screenBox.Invalidate();
            }


        }

        private void screenBox_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            foreach(Rectangle rect in rectangles) {
                rect.Draw(g);
            }

            foreach(Ellipse ell in ellipses) {
                ell.Draw(g);
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
                foreach(Rectangle rect in rectangles) {
                    if(rect.IsInBounds(e.Location) && !found) {
                        rect.Selected = true;
                        found = true;
                        currentRectangle = rect;
                    } else {
                        rect.Selected = false;
                    }
                }
                screenBox.Invalidate();

            }

        }
    }
}
