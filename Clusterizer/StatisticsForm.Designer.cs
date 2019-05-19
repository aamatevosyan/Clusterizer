namespace Clusterizer
{
    partial class StatisticsForm
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
            this.clustersOverviewGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.clustersOverviewGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // clustersOverviewGridView
            // 
            this.clustersOverviewGridView.AllowUserToAddRows = false;
            this.clustersOverviewGridView.AllowUserToDeleteRows = false;
            this.clustersOverviewGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clustersOverviewGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clustersOverviewGridView.Location = new System.Drawing.Point(0, 0);
            this.clustersOverviewGridView.Name = "clustersOverviewGridView";
            this.clustersOverviewGridView.ReadOnly = true;
            this.clustersOverviewGridView.Size = new System.Drawing.Size(800, 450);
            this.clustersOverviewGridView.TabIndex = 0;
            this.clustersOverviewGridView.DataSourceChanged += new System.EventHandler(this.clustersOverviewGridView_DataSourceChanged);
            this.clustersOverviewGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.clustersOverviewGridView_RowPostPaint);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clustersOverviewGridView);
            this.Name = "StatisticsForm";
            this.ShowIcon = false;
            this.Text = "Статистика кластеров";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsForm_FormClosing);
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clustersOverviewGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView clustersOverviewGridView;
    }
}