namespace Clusterizer
{
    partial class ClusterizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.distanceSelectComboBox = new System.Windows.Forms.ComboBox();
            this.strategySelectComboBox = new System.Windows.Forms.ComboBox();
            this.doClusteringButton = new System.Windows.Forms.Button();
            this.pointsSelectTreeView = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.clusterCountTextBox = new System.Windows.Forms.TextBox();
            this.calculateClusterCountButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.normalizeMethodSelectComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мера расстояния: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стратегия обьеденения:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Выберите покозатели по которым нужно выполнить кластеризацию: ";
            // 
            // distanceSelectComboBox
            // 
            this.distanceSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distanceSelectComboBox.FormattingEnabled = true;
            this.distanceSelectComboBox.Items.AddRange(new object[] {
            "Евклидово расстояние\n",
            "Квадрат евклидова расстояния\n   ",
            "Расстояние городских кварталов (манхэттенское расстояние)\n",
            "Расстояние Чебышева"});
            this.distanceSelectComboBox.Location = new System.Drawing.Point(149, 12);
            this.distanceSelectComboBox.Name = "distanceSelectComboBox";
            this.distanceSelectComboBox.Size = new System.Drawing.Size(372, 21);
            this.distanceSelectComboBox.TabIndex = 3;
            // 
            // strategySelectComboBox
            // 
            this.strategySelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategySelectComboBox.FormattingEnabled = true;
            this.strategySelectComboBox.Items.AddRange(new object[] {
            "Одиночная связь (расстояния ближайшего соседа)",
            "Полная связь (расстояние наиболее удаленных соседей)",
            "Невзвешенное попарное среднее",
            "Взвешенное попарное среднее",
            "Метод Центроидов",
            "Метод Варда"});
            this.strategySelectComboBox.Location = new System.Drawing.Point(675, 12);
            this.strategySelectComboBox.Name = "strategySelectComboBox";
            this.strategySelectComboBox.Size = new System.Drawing.Size(577, 21);
            this.strategySelectComboBox.TabIndex = 4;
            // 
            // doClusteringButton
            // 
            this.doClusteringButton.Location = new System.Drawing.Point(12, 396);
            this.doClusteringButton.Name = "doClusteringButton";
            this.doClusteringButton.Size = new System.Drawing.Size(1240, 23);
            this.doClusteringButton.TabIndex = 6;
            this.doClusteringButton.Text = "Выполнить кластеризацию";
            this.doClusteringButton.UseVisualStyleBackColor = true;
            this.doClusteringButton.Click += new System.EventHandler(this.doClusteringButton_Click);
            // 
            // pointsSelectTreeView
            // 
            this.pointsSelectTreeView.Location = new System.Drawing.Point(12, 129);
            this.pointsSelectTreeView.Name = "pointsSelectTreeView";
            this.pointsSelectTreeView.Size = new System.Drawing.Size(1240, 261);
            this.pointsSelectTreeView.TabIndex = 7;
            this.pointsSelectTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.pointsSelectTreeView_AfterCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Число кластеров: ";
            // 
            // clusterCountTextBox
            // 
            this.clusterCountTextBox.Location = new System.Drawing.Point(675, 50);
            this.clusterCountTextBox.Name = "clusterCountTextBox";
            this.clusterCountTextBox.Size = new System.Drawing.Size(170, 20);
            this.clusterCountTextBox.TabIndex = 9;
            this.clusterCountTextBox.Text = "2";
            // 
            // calculateClusterCountButton
            // 
            this.calculateClusterCountButton.Location = new System.Drawing.Point(851, 48);
            this.calculateClusterCountButton.Name = "calculateClusterCountButton";
            this.calculateClusterCountButton.Size = new System.Drawing.Size(401, 23);
            this.calculateClusterCountButton.TabIndex = 10;
            this.calculateClusterCountButton.Text = "Рассчитать число рекомендуемое число класстеров";
            this.calculateClusterCountButton.UseVisualStyleBackColor = true;
            this.calculateClusterCountButton.Click += new System.EventHandler(this.calculateClusterCountButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Метод нормализации: ";
            // 
            // normalizeMethodSelectComboBox
            // 
            this.normalizeMethodSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.normalizeMethodSelectComboBox.FormattingEnabled = true;
            this.normalizeMethodSelectComboBox.Items.AddRange(new object[] {
            "Никакой",
            "Метод Min-Max",
            "Метод Z-Score"});
            this.normalizeMethodSelectComboBox.Location = new System.Drawing.Point(149, 50);
            this.normalizeMethodSelectComboBox.Name = "normalizeMethodSelectComboBox";
            this.normalizeMethodSelectComboBox.Size = new System.Drawing.Size(372, 21);
            this.normalizeMethodSelectComboBox.TabIndex = 12;
            // 
            // ClusterizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 431);
            this.Controls.Add(this.normalizeMethodSelectComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.calculateClusterCountButton);
            this.Controls.Add(this.clusterCountTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pointsSelectTreeView);
            this.Controls.Add(this.doClusteringButton);
            this.Controls.Add(this.strategySelectComboBox);
            this.Controls.Add(this.distanceSelectComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1280, 470);
            this.MinimumSize = new System.Drawing.Size(1280, 470);
            this.Name = "ClusterizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox distanceSelectComboBox;
        private System.Windows.Forms.ComboBox strategySelectComboBox;
        private System.Windows.Forms.Button doClusteringButton;
        private System.Windows.Forms.TreeView pointsSelectTreeView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clusterCountTextBox;
        private System.Windows.Forms.Button calculateClusterCountButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox normalizeMethodSelectComboBox;
    }
}