namespace Clusterizer
{
    partial class DendrogramForm
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
            this.dendogramControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dendogramControl)).BeginInit();
            this.SuspendLayout();
            // 
            // dendogramControl
            // 
            this.dendogramControl.BackColor = System.Drawing.SystemColors.Control;
            this.dendogramControl.Location = new System.Drawing.Point(0, 0);
            this.dendogramControl.Name = "dendogramControl";
            this.dendogramControl.Size = new System.Drawing.Size(872, 607);
            this.dendogramControl.TabIndex = 0;
            this.dendogramControl.TabStop = false;
            this.dendogramControl.Paint += new System.Windows.Forms.PaintEventHandler(this.dendogramControl_Paint);
            // 
            // DendrogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(888, 568);
            this.Controls.Add(this.dendogramControl);
            this.Name = "DendrogramForm";
            this.ShowIcon = false;
            this.Text = "Дендограмма";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DendrogramForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.DendrogramForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dendogramControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox dendogramControl;
    }
}