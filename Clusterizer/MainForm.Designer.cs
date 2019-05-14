namespace Clusterizer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildDendrogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.filterToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.filterToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.filterStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.sortToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.preprocessPage = new System.Windows.Forms.TabPage();
            this.clusterizeTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeView = new System.Windows.Forms.TreeView();
            this.показатьСтатисикуКласстераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.preprocessPage.SuspendLayout();
            this.clusterizeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clusterizationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1241, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Меню";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_folder_open_black_48dp1;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Открыть...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_close_black_48dp1;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importToolStripMenuItem.Text = "Импорт";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportToolStripMenuItem.Text = "Экспорт";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_save_black_48dp1;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(159, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // clusterizationToolStripMenuItem
            // 
            this.clusterizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clusterizeToolStripMenuItem,
            this.buildDendrogramToolStripMenuItem,
            this.показатьСтатисикуКласстераToolStripMenuItem});
            this.clusterizationToolStripMenuItem.Name = "clusterizationToolStripMenuItem";
            this.clusterizationToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.clusterizationToolStripMenuItem.Text = "Кластеризация";
            // 
            // clusterizeToolStripMenuItem
            // 
            this.clusterizeToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_insert_chart_black_48dp1;
            this.clusterizeToolStripMenuItem.Name = "clusterizeToolStripMenuItem";
            this.clusterizeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.clusterizeToolStripMenuItem.Text = "Выполнить кластеризацию";
            this.clusterizeToolStripMenuItem.Click += new System.EventHandler(this.clusterizeToolStripMenuItem_Click);
            // 
            // buildDendrogramToolStripMenuItem
            // 
            this.buildDendrogramToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_filter_black_48dp1;
            this.buildDendrogramToolStripMenuItem.Name = "buildDendrogramToolStripMenuItem";
            this.buildDendrogramToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.buildDendrogramToolStripMenuItem.Text = "Построить дендограмму";
            this.buildDendrogramToolStripMenuItem.Click += new System.EventHandler(this.buildDendrogramToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_info_black_48dp1;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripTextBox,
            this.filterToolStripComboBox,
            this.filterStripButton,
            this.toolStripSeparator3,
            this.sortToolStripComboBox,
            this.sortToolStripButton,
            this.toolStripSeparator4,
            this.undoToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1227, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Панель инструментов";
            // 
            // filterToolStripTextBox
            // 
            this.filterToolStripTextBox.Name = "filterToolStripTextBox";
            this.filterToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // filterToolStripComboBox
            // 
            this.filterToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterToolStripComboBox.Name = "filterToolStripComboBox";
            this.filterToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // filterStripButton
            // 
            this.filterStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filterStripButton.Image = global::Clusterizer.Properties.Resources.baseline_find_in_page_black_48dp1;
            this.filterStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterStripButton.Name = "filterStripButton";
            this.filterStripButton.Size = new System.Drawing.Size(23, 22);
            this.filterStripButton.Text = "toolStripButton4";
            this.filterStripButton.Click += new System.EventHandler(this.filterStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // sortToolStripComboBox
            // 
            this.sortToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortToolStripComboBox.Name = "sortToolStripComboBox";
            this.sortToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // sortToolStripButton
            // 
            this.sortToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortToolStripButton.Image = global::Clusterizer.Properties.Resources.baseline_sort_by_alpha_black_48dp1;
            this.sortToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortToolStripButton.Name = "sortToolStripButton";
            this.sortToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.sortToolStripButton.Text = "toolStripButton5";
            this.sortToolStripButton.Click += new System.EventHandler(this.sortToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // undoToolStripButton
            // 
            this.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripButton.Image = global::Clusterizer.Properties.Resources.baseline_undo_black_48dp1;
            this.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripButton.Name = "undoToolStripButton";
            this.undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoToolStripButton.Text = "toolStripButton6";
            this.undoToolStripButton.Click += new System.EventHandler(this.undoToolStripButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView.Location = new System.Drawing.Point(3, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1227, 680);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.VirtualMode = true;
            this.dataGridView.DataSourceChanged += new System.EventHandler(this.dataGridView_DataSourceChanged);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_DefaultValuesNeeded);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.preprocessPage);
            this.tabControl.Controls.Add(this.clusterizeTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1241, 737);
            this.tabControl.TabIndex = 3;
            // 
            // preprocessPage
            // 
            this.preprocessPage.Controls.Add(this.dataGridView);
            this.preprocessPage.Controls.Add(this.toolStrip);
            this.preprocessPage.Location = new System.Drawing.Point(4, 22);
            this.preprocessPage.Name = "preprocessPage";
            this.preprocessPage.Padding = new System.Windows.Forms.Padding(3);
            this.preprocessPage.Size = new System.Drawing.Size(1233, 711);
            this.preprocessPage.TabIndex = 0;
            this.preprocessPage.Text = "Обработка";
            this.preprocessPage.UseVisualStyleBackColor = true;
            // 
            // clusterizeTabPage
            // 
            this.clusterizeTabPage.Controls.Add(this.splitContainer1);
            this.clusterizeTabPage.Location = new System.Drawing.Point(4, 22);
            this.clusterizeTabPage.Name = "clusterizeTabPage";
            this.clusterizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clusterizeTabPage.Size = new System.Drawing.Size(1233, 711);
            this.clusterizeTabPage.TabIndex = 1;
            this.clusterizeTabPage.Text = "Кластеризация";
            this.clusterizeTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resultGridView);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer1.Size = new System.Drawing.Size(1227, 705);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
            // 
            // resultGridView
            // 
            this.resultGridView.AllowUserToAddRows = false;
            this.resultGridView.AllowUserToDeleteRows = false;
            this.resultGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.BaseCluster,
            this.OutputCluster});
            this.resultGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.resultGridView.Location = new System.Drawing.Point(20, 20);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.ReadOnly = true;
            this.resultGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.resultGridView.Size = new System.Drawing.Size(560, 665);
            this.resultGridView.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.HeaderText = "Название вуза";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 99;
            // 
            // BaseCluster
            // 
            this.BaseCluster.HeaderText = "Базовый кластер";
            this.BaseCluster.Name = "BaseCluster";
            this.BaseCluster.ReadOnly = true;
            this.BaseCluster.Width = 111;
            // 
            // OutputCluster
            // 
            this.OutputCluster.HeaderText = "Выходной кластер";
            this.OutputCluster.Name = "OutputCluster";
            this.OutputCluster.ReadOnly = true;
            this.OutputCluster.Width = 115;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(20, 20);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(583, 665);
            this.treeView.TabIndex = 0;
            // 
            // показатьСтатисикуКласстераToolStripMenuItem
            // 
            this.показатьСтатисикуКласстераToolStripMenuItem.Name = "показатьСтатисикуКласстераToolStripMenuItem";
            this.показатьСтатисикуКласстераToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.показатьСтатисикуКласстераToolStripMenuItem.Text = "Показать статисику класстера";
            this.показатьСтатисикуКласстераToolStripMenuItem.Click += new System.EventHandler(this.показатьСтатисикуКласстераToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 761);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.Text = "Clusterizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.preprocessPage.ResumeLayout(false);
            this.preprocessPage.PerformLayout();
            this.clusterizeTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem clusterizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildDendrogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox filterToolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox filterToolStripComboBox;
        private System.Windows.Forms.ToolStripButton filterStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox sortToolStripComboBox;
        private System.Windows.Forms.ToolStripButton sortToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton undoToolStripButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage preprocessPage;
        private System.Windows.Forms.TabPage clusterizeTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView resultGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputCluster;
        private System.Windows.Forms.ToolStripMenuItem показатьСтатисикуКласстераToolStripMenuItem;
    }
}

