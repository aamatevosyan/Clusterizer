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
            this.drawingArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.SystemColors.Control;
            this.drawingArea.Location = new System.Drawing.Point(0, 0);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(872, 607);
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            this.drawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingArea_Paint);
            // 
            // DendrogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(888, 568);
            this.Controls.Add(this.drawingArea);
            this.Name = "DendrogramForm";
            this.Text = "AggloCluster Dendrogram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.DendrogramFrm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DendrogramForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
    }
}