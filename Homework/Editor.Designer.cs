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
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).BeginInit();
            this.SuspendLayout();
            // 
            // screenBox
            // 
            this.screenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screenBox.Location = new System.Drawing.Point(12, 82);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(1256, 626);
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
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.actionPicker);
            this.Controls.Add(this.shapePicker);
            this.Controls.Add(this.screenBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Editor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Editor_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox screenBox;
        private System.Windows.Forms.ListBox shapePicker;
        private System.Windows.Forms.ListBox actionPicker;
    }
}

