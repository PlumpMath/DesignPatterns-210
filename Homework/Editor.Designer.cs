namespace Homework {
    partial class Editor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.screenBox = new System.Windows.Forms.PictureBox();
            this.shapePicker = new System.Windows.Forms.ListBox();
            this.actionPicker = new System.Windows.Forms.ListBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.shapeBox = new System.Windows.Forms.ListView();
            this.groupButton = new System.Windows.Forms.Button();
            this.textTop = new System.Windows.Forms.TextBox();
            this.textBottom = new System.Windows.Forms.TextBox();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelBottom = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // screenBox
            // 
            this.screenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screenBox.Location = new System.Drawing.Point(205, 82);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(1063, 626);
            this.screenBox.TabIndex = 0;
            this.screenBox.TabStop = false;
            this.screenBox.Paint += new System.Windows.Forms.PaintEventHandler(this.screenBox_Paint);
            this.screenBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screenBox_MouseClick);
            this.screenBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenBox_MouseDown);
            this.screenBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenBox_MouseMove);
            this.screenBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenBox_MouseUp);
            // 
            // shapePicker
            // 
            this.shapePicker.FormattingEnabled = true;
            this.shapePicker.ItemHeight = 16;
            this.shapePicker.Items.AddRange(new object[] {
            "Rectangle",
            "Ellipse"});
            this.shapePicker.Location = new System.Drawing.Point(12, 12);
            this.shapePicker.Name = "shapePicker";
            this.shapePicker.Size = new System.Drawing.Size(136, 68);
            this.shapePicker.TabIndex = 3;
            // 
            // actionPicker
            // 
            this.actionPicker.FormattingEnabled = true;
            this.actionPicker.ItemHeight = 16;
            this.actionPicker.Items.AddRange(new object[] {
            "Draw",
            "Move",
            "Select"});
            this.actionPicker.Location = new System.Drawing.Point(163, 12);
            this.actionPicker.Name = "actionPicker";
            this.actionPicker.Size = new System.Drawing.Size(136, 68);
            this.actionPicker.TabIndex = 4;
            this.actionPicker.SelectedIndexChanged += new System.EventHandler(this.actionPicker_SelectedIndexChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(305, 22);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(57, 17);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Height: ";
            // 
            // heightUpDown
            // 
            this.heightUpDown.Location = new System.Drawing.Point(358, 20);
            this.heightUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.heightUpDown.Name = "heightUpDown";
            this.heightUpDown.Size = new System.Drawing.Size(120, 22);
            this.heightUpDown.TabIndex = 6;
            this.heightUpDown.ValueChanged += new System.EventHandler(this.heightUpDown_ValueChanged);
            // 
            // widthUpDown
            // 
            this.widthUpDown.Location = new System.Drawing.Point(358, 53);
            this.widthUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(120, 22);
            this.widthUpDown.TabIndex = 8;
            this.widthUpDown.ValueChanged += new System.EventHandler(this.widthUpDown_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(305, 55);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(48, 17);
            this.widthLabel.TabIndex = 7;
            this.widthLabel.Text = "Width:";
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(496, 20);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 9;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(496, 49);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(75, 23);
            this.redoButton.TabIndex = 10;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1193, 22);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // shapeBox
            // 
            this.shapeBox.Location = new System.Drawing.Point(12, 82);
            this.shapeBox.Name = "shapeBox";
            this.shapeBox.Size = new System.Drawing.Size(187, 516);
            this.shapeBox.TabIndex = 12;
            this.shapeBox.UseCompatibleStateImageBehavior = false;
            // 
            // groupButton
            // 
            this.groupButton.Location = new System.Drawing.Point(12, 604);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(187, 33);
            this.groupButton.TabIndex = 13;
            this.groupButton.Text = "Group";
            this.groupButton.UseVisualStyleBackColor = true;
            this.groupButton.Click += new System.EventHandler(this.groupButton_Click);
            // 
            // textTop
            // 
            this.textTop.Location = new System.Drawing.Point(792, 23);
            this.textTop.Name = "textTop";
            this.textTop.Size = new System.Drawing.Size(100, 22);
            this.textTop.TabIndex = 14;
            // 
            // textBottom
            // 
            this.textBottom.Location = new System.Drawing.Point(792, 49);
            this.textBottom.Name = "textBottom";
            this.textBottom.Size = new System.Drawing.Size(100, 22);
            this.textBottom.TabIndex = 15;
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.Location = new System.Drawing.Point(730, 22);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(37, 17);
            this.labelTop.TabIndex = 16;
            this.labelTop.Text = "Top:";
            // 
            // labelBottom
            // 
            this.labelBottom.AutoSize = true;
            this.labelBottom.Location = new System.Drawing.Point(730, 49);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(56, 17);
            this.labelBottom.TabIndex = 17;
            this.labelBottom.Text = "Bottom:";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(899, 22);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 49);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.labelBottom);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.textBottom);
            this.Controls.Add(this.textTop);
            this.Controls.Add(this.groupButton);
            this.Controls.Add(this.shapeBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightUpDown);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.actionPicker);
            this.Controls.Add(this.shapePicker);
            this.Controls.Add(this.screenBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Editor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Editor_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screenBox;
        private System.Windows.Forms.ListBox shapePicker;
        private System.Windows.Forms.ListBox actionPicker;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown heightUpDown;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListView shapeBox;
        private System.Windows.Forms.Button groupButton;
        private System.Windows.Forms.TextBox textTop;
        private System.Windows.Forms.TextBox textBottom;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.Button applyButton;
    }
}

