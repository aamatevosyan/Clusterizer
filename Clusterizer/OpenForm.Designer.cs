namespace Clusterizer
{
    partial class OpenForm
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
            this.filePathtextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filePathtextBox
            // 
            this.filePathtextBox.Enabled = false;
            this.filePathtextBox.Location = new System.Drawing.Point(12, 12);
            this.filePathtextBox.Name = "filePathtextBox";
            this.filePathtextBox.Size = new System.Drawing.Size(506, 20);
            this.filePathtextBox.TabIndex = 0;
            this.filePathtextBox.Text = "Для выбора файла нажмите на ...";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(524, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(30, 20);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(12, 76);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(542, 274);
            this.checkedListBox.TabIndex = 2;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 356);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(542, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 45);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(254, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Выберите из списка столбцы с покозательями: ";
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 391);
            this.Controls.Add(this.label);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filePathtextBox);
            this.Name = "OpenForm";
            this.ShowIcon = false;
            this.Text = "Открыть файл";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathtextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label;
    }
}