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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.clusteringButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Евклидово расстояние\n",
            "Квадрат евклидова расстояния\n   ",
            "Расстояние городских кварталов (манхэттенское расстояние)\n",
            "Расстояние Чебышева"});
            this.comboBox1.Location = new System.Drawing.Point(149, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(372, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Одиночная связь (расстояния ближайшего соседа)",
            "Полная связь (расстояние наиболее удаленных соседей)",
            "Невзвешенное попарное среднее",
            "Взвешенное попарное среднее",
            "Метод Центроидов",
            "Метод Варда"});
            this.comboBox2.Location = new System.Drawing.Point(675, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(577, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // clusteringButton
            // 
            this.clusteringButton.Location = new System.Drawing.Point(12, 396);
            this.clusteringButton.Name = "clusteringButton";
            this.clusteringButton.Size = new System.Drawing.Size(1240, 23);
            this.clusteringButton.TabIndex = 6;
            this.clusteringButton.Text = "Выполнить кластеризацию";
            this.clusteringButton.UseVisualStyleBackColor = true;
            this.clusteringButton.Click += new System.EventHandler(this.clusteringButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 129);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1240, 261);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Число кластеров: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "2";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(541, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Рассчитать число рекомендуемое число класстеров";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClusterizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 431);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.clusteringButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClusterizeForm";
            this.Text = "ClusterizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button clusteringButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}