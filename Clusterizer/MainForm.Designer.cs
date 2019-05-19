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
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportClusterTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportClusterOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportClusterDendogrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildDendrogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClusterOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.clusterizeTabPage = new System.Windows.Forms.TabPage();
            this.clusteringToolStrip = new System.Windows.Forms.ToolStrip();
            this.searchExpressionTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.clusterTreeView = new System.Windows.Forms.TreeView();
            this.clusterTableGridView = new System.Windows.Forms.DataGridView();
            this.OutputCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preprocessPage = new System.Windows.Forms.TabPage();
            this.dataTableGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.filterExpressionTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.operandSelectComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.filteredColumnSelectComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.filterButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortColumnSelectComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.sortByAZButton = new System.Windows.Forms.ToolStripButton();
            this.sortByZAButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.clusterizeTabPage.SuspendLayout();
            this.clusteringToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clusterTableGridView)).BeginInit();
            this.preprocessPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clusterizationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Меню";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator6,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
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
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Открыть...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_close_black_48dp1;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportClusterTableToolStripMenuItem,
            this.exportClusterOverviewToolStripMenuItem,
            this.exportClusterDendogrammToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Экспорт";
            // 
            // exportClusterTableToolStripMenuItem
            // 
            this.exportClusterTableToolStripMenuItem.Name = "exportClusterTableToolStripMenuItem";
            this.exportClusterTableToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exportClusterTableToolStripMenuItem.Text = "Таблица кластеров";
            this.exportClusterTableToolStripMenuItem.Click += new System.EventHandler(this.exportClusterTableToolStripMenuItem_Click);
            // 
            // exportClusterOverviewToolStripMenuItem
            // 
            this.exportClusterOverviewToolStripMenuItem.Name = "exportClusterOverviewToolStripMenuItem";
            this.exportClusterOverviewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exportClusterOverviewToolStripMenuItem.Text = "Статистика кластеров";
            this.exportClusterOverviewToolStripMenuItem.Click += new System.EventHandler(this.exportClusterOverviewToolStripMenuItem_Click);
            // 
            // exportClusterDendogrammToolStripMenuItem
            // 
            this.exportClusterDendogrammToolStripMenuItem.Name = "exportClusterDendogrammToolStripMenuItem";
            this.exportClusterDendogrammToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exportClusterDendogrammToolStripMenuItem.Text = "Дендограмма";
            this.exportClusterDendogrammToolStripMenuItem.Click += new System.EventHandler(this.exportClusterDendogrammToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_save_black_48dp1;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // clusterizationToolStripMenuItem
            // 
            this.clusterizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clusterizeToolStripMenuItem,
            this.buildDendrogramToolStripMenuItem,
            this.showClusterOverviewToolStripMenuItem});
            this.clusterizationToolStripMenuItem.Name = "clusterizationToolStripMenuItem";
            this.clusterizationToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.clusterizationToolStripMenuItem.Text = "Кластеризация";
            // 
            // clusterizeToolStripMenuItem
            // 
            this.clusterizeToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_group_work_black_48dp;
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
            // showClusterOverviewToolStripMenuItem
            // 
            this.showClusterOverviewToolStripMenuItem.Image = global::Clusterizer.Properties.Resources.baseline_insert_chart_black_48dp1;
            this.showClusterOverviewToolStripMenuItem.Name = "showClusterOverviewToolStripMenuItem";
            this.showClusterOverviewToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.showClusterOverviewToolStripMenuItem.Text = "Показать статисику класстера";
            this.showClusterOverviewToolStripMenuItem.Click += new System.EventHandler(this.showClusterOverviewToolStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 175);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.preprocessPage);
            this.tabControl.Controls.Add(this.clusterizeTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1264, 705);
            this.tabControl.TabIndex = 3;
            // 
            // clusterizeTabPage
            // 
            this.clusterizeTabPage.Controls.Add(this.splitContainer);
            this.clusterizeTabPage.Controls.Add(this.clusteringToolStrip);
            this.clusterizeTabPage.Location = new System.Drawing.Point(4, 22);
            this.clusterizeTabPage.Name = "clusterizeTabPage";
            this.clusterizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clusterizeTabPage.Size = new System.Drawing.Size(1256, 679);
            this.clusterizeTabPage.TabIndex = 1;
            this.clusterizeTabPage.Text = "Кластеризация";
            this.clusterizeTabPage.UseVisualStyleBackColor = true;
            // 
            // clusteringToolStrip
            // 
            this.clusteringToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchExpressionTextBox,
            this.searchButton,
            this.toolStripSeparator2});
            this.clusteringToolStrip.Location = new System.Drawing.Point(3, 3);
            this.clusteringToolStrip.Name = "clusteringToolStrip";
            this.clusteringToolStrip.Size = new System.Drawing.Size(1250, 25);
            this.clusteringToolStrip.TabIndex = 1;
            // 
            // searchExpressionTextBox
            // 
            this.searchExpressionTextBox.Name = "searchExpressionTextBox";
            this.searchExpressionTextBox.Size = new System.Drawing.Size(300, 25);
            this.searchExpressionTextBox.ToolTipText = "Введите значение поиска";
            // 
            // searchButton
            // 
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = global::Clusterizer.Properties.Resources.baseline_search_black_18dp;
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.Text = "toolStripButton1";
            this.searchButton.ToolTipText = "Поиск";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(3, 28);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.clusterTableGridView);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.clusterTreeView);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer.Size = new System.Drawing.Size(1250, 648);
            this.splitContainer.SplitterDistance = 662;
            this.splitContainer.TabIndex = 0;
            // 
            // clusterTreeView
            // 
            this.clusterTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clusterTreeView.Location = new System.Drawing.Point(20, 20);
            this.clusterTreeView.Name = "clusterTreeView";
            this.clusterTreeView.Size = new System.Drawing.Size(544, 608);
            this.clusterTreeView.TabIndex = 0;
            // 
            // clusterTableGridView
            // 
            this.clusterTableGridView.AllowUserToAddRows = false;
            this.clusterTableGridView.AllowUserToDeleteRows = false;
            this.clusterTableGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.clusterTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clusterTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.BaseCluster,
            this.OutputCluster});
            this.clusterTableGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clusterTableGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clusterTableGridView.Location = new System.Drawing.Point(20, 20);
            this.clusterTableGridView.Name = "clusterTableGridView";
            this.clusterTableGridView.ReadOnly = true;
            this.clusterTableGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.clusterTableGridView.Size = new System.Drawing.Size(622, 608);
            this.clusterTableGridView.TabIndex = 0;
            this.clusterTableGridView.DataSourceChanged += new System.EventHandler(this.clusterTableGridView_DataSourceChanged);
            this.clusterTableGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.clusterTableGridView_RowPostPaint);
            // 
            // OutputCluster
            // 
            this.OutputCluster.HeaderText = "Выходной кластер";
            this.OutputCluster.Name = "OutputCluster";
            this.OutputCluster.ReadOnly = true;
            this.OutputCluster.Width = 115;
            // 
            // BaseCluster
            // 
            this.BaseCluster.HeaderText = "Базовый кластер";
            this.BaseCluster.Name = "BaseCluster";
            this.BaseCluster.ReadOnly = true;
            this.BaseCluster.Width = 111;
            // 
            // Title
            // 
            this.Title.HeaderText = "Название вуза";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 99;
            // 
            // preprocessPage
            // 
            this.preprocessPage.Controls.Add(this.dataTableGridView);
            this.preprocessPage.Controls.Add(this.toolStrip);
            this.preprocessPage.Location = new System.Drawing.Point(4, 22);
            this.preprocessPage.Name = "preprocessPage";
            this.preprocessPage.Padding = new System.Windows.Forms.Padding(3);
            this.preprocessPage.Size = new System.Drawing.Size(1256, 679);
            this.preprocessPage.TabIndex = 0;
            this.preprocessPage.Text = "Обработка";
            this.preprocessPage.UseVisualStyleBackColor = true;
            // 
            // dataTableGridView
            // 
            this.dataTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataTableGridView.Location = new System.Drawing.Point(3, 28);
            this.dataTableGridView.Name = "dataTableGridView";
            this.dataTableGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTableGridView.Size = new System.Drawing.Size(1250, 648);
            this.dataTableGridView.TabIndex = 2;
            this.dataTableGridView.VirtualMode = true;
            this.dataTableGridView.DataSourceChanged += new System.EventHandler(this.dataTableGridView_DataSourceChanged);
            this.dataTableGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataTableGridView_DataError);
            this.dataTableGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataTableGridView_DefaultValuesNeeded);
            this.dataTableGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataTableGridView_RowPostPaint);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterExpressionTextBox,
            this.operandSelectComboBox,
            this.filteredColumnSelectComboBox,
            this.filterButton,
            this.toolStripSeparator3,
            this.sortColumnSelectComboBox,
            this.sortByAZButton,
            this.sortByZAButton,
            this.toolStripSeparator4,
            this.undoButton,
            this.redoButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1250, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Панель инструментов";
            // 
            // filterExpressionTextBox
            // 
            this.filterExpressionTextBox.Name = "filterExpressionTextBox";
            this.filterExpressionTextBox.Size = new System.Drawing.Size(200, 25);
            this.filterExpressionTextBox.ToolTipText = "Введите фильтруемое значение";
            // 
            // operandSelectComboBox
            // 
            this.operandSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operandSelectComboBox.Name = "operandSelectComboBox";
            this.operandSelectComboBox.Size = new System.Drawing.Size(75, 25);
            this.operandSelectComboBox.ToolTipText = "Выберите условие фильтрации";
            // 
            // filteredColumnSelectComboBox
            // 
            this.filteredColumnSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filteredColumnSelectComboBox.Name = "filteredColumnSelectComboBox";
            this.filteredColumnSelectComboBox.Size = new System.Drawing.Size(400, 25);
            this.filteredColumnSelectComboBox.ToolTipText = "Выберите стольбец фильтрации";
            this.filteredColumnSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.filteredColumnSelectComboBox_SelectedIndexChanged);
            // 
            // filterButton
            // 
            this.filterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filterButton.Image = global::Clusterizer.Properties.Resources.baseline_find_in_page_black_48dp1;
            this.filterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(23, 22);
            this.filterButton.Text = "toolStripButton4";
            this.filterButton.ToolTipText = "Фильтровать выбранный столбец";
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // sortColumnSelectComboBox
            // 
            this.sortColumnSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortColumnSelectComboBox.Name = "sortColumnSelectComboBox";
            this.sortColumnSelectComboBox.Size = new System.Drawing.Size(121, 25);
            this.sortColumnSelectComboBox.ToolTipText = "Выберите столбец сортировки";
            // 
            // sortByAZButton
            // 
            this.sortByAZButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortByAZButton.Image = global::Clusterizer.Properties.Resources.baseline_sort_by_alpha_black_48dp1;
            this.sortByAZButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortByAZButton.Name = "sortByAZButton";
            this.sortByAZButton.Size = new System.Drawing.Size(23, 22);
            this.sortByAZButton.Text = "toolStripButton5";
            this.sortByAZButton.ToolTipText = "Сортировать в алфавитном порядке по возрастанию";
            this.sortByAZButton.Click += new System.EventHandler(this.sortByAZButton_Click);
            // 
            // sortByZAButton
            // 
            this.sortByZAButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortByZAButton.Image = global::Clusterizer.Properties.Resources.baseline_sort_by_alpha_reverse_black_48dp;
            this.sortByZAButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortByZAButton.Name = "sortByZAButton";
            this.sortByZAButton.Size = new System.Drawing.Size(23, 22);
            this.sortByZAButton.Text = "toolStripButton1";
            this.sortByZAButton.ToolTipText = "Сортировать в алфавитном порядке по убыванию";
            this.sortByZAButton.Click += new System.EventHandler(this.sortByZAButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = global::Clusterizer.Properties.Resources.baseline_undo_black_48dp1;
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.ToolTipText = "Отмена последнего действия";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = global::Clusterizer.Properties.Resources.baseline_redo_black_48dp;
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.ToolTipText = "Повтор последнего действия";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.Text = "Clusterizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.clusterizeTabPage.ResumeLayout(false);
            this.clusterizeTabPage.PerformLayout();
            this.clusteringToolStrip.ResumeLayout(false);
            this.clusteringToolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clusterTableGridView)).EndInit();
            this.preprocessPage.ResumeLayout(false);
            this.preprocessPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportClusterTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportClusterOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportClusterDendogrammToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildDendrogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClusterOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage preprocessPage;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripTextBox filterExpressionTextBox;
        private System.Windows.Forms.ToolStripComboBox operandSelectComboBox;
        private System.Windows.Forms.ToolStripComboBox filteredColumnSelectComboBox;
        private System.Windows.Forms.ToolStripButton filterButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox sortColumnSelectComboBox;
        private System.Windows.Forms.ToolStripButton sortByAZButton;
        private System.Windows.Forms.ToolStripButton sortByZAButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.DataGridView dataTableGridView;
        private System.Windows.Forms.TabPage clusterizeTabPage;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView clusterTableGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputCluster;
        private System.Windows.Forms.TreeView clusterTreeView;
        private System.Windows.Forms.ToolStrip clusteringToolStrip;
        private System.Windows.Forms.ToolStripTextBox searchExpressionTextBox;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
    }
}

