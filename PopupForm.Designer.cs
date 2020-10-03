namespace KeyboardMixer
{
    partial class PopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBoxBg = new System.Windows.Forms.Label();
            this.labelAppName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelBoxSlider = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBoxBg
            // 
            this.labelBoxBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.labelBoxBg.ForeColor = System.Drawing.Color.White;
            this.labelBoxBg.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelBoxBg.Location = new System.Drawing.Point(2, 3);
            this.labelBoxBg.Margin = new System.Windows.Forms.Padding(0);
            this.labelBoxBg.Name = "labelBoxBg";
            this.labelBoxBg.Size = new System.Drawing.Size(72, 249);
            this.labelBoxBg.TabIndex = 1;
            this.labelBoxBg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAppName
            // 
            this.labelAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.labelAppName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.Color.White;
            this.labelAppName.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelAppName.Location = new System.Drawing.Point(5, 230);
            this.labelAppName.Margin = new System.Windows.Forms.Padding(0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(69, 21);
            this.labelAppName.TabIndex = 2;
            this.labelAppName.Text = "AppName";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pictureBox.Location = new System.Drawing.Point(22, 198);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // labelBoxSlider
            // 
            this.labelBoxSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.labelBoxSlider.ForeColor = System.Drawing.Color.White;
            this.labelBoxSlider.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelBoxSlider.Location = new System.Drawing.Point(31, 13);
            this.labelBoxSlider.Margin = new System.Windows.Forms.Padding(0);
            this.labelBoxSlider.Name = "labelBoxSlider";
            this.labelBoxSlider.Size = new System.Drawing.Size(14, 177);
            this.labelBoxSlider.TabIndex = 4;
            this.labelBoxSlider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBoxSlider.Paint += new System.Windows.Forms.PaintEventHandler(this.labelBoxSlider_Paint);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(76, 255);
            this.ControlBox = false;
            this.Controls.Add(this.labelBoxSlider);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.labelBoxBg);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.PopupForm_Load);
            this.VisibleChanged += new System.EventHandler(this.PopupForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelBoxBg;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelBoxSlider;
    }
}