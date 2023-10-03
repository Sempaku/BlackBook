namespace BB_WinForms.Forms
{
    partial class AddBookForm
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
            this.button_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_author = new System.Windows.Forms.TextBox();
            this.textBox_pages = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_add.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_add.Location = new System.Drawing.Point(498, 159);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(127, 38);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title:";
            // 
            // textBox_title
            // 
            this.textBox_title.Font = new System.Drawing.Font("Arial", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_title.Location = new System.Drawing.Point(137, 9);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(488, 40);
            this.textBox_title.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pages:";
            // 
            // textBox_author
            // 
            this.textBox_author.Font = new System.Drawing.Font("Arial", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_author.Location = new System.Drawing.Point(137, 59);
            this.textBox_author.Name = "textBox_author";
            this.textBox_author.Size = new System.Drawing.Size(488, 40);
            this.textBox_author.TabIndex = 6;
            // 
            // textBox_pages
            // 
            this.textBox_pages.Font = new System.Drawing.Font("Arial", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_pages.Location = new System.Drawing.Point(137, 110);
            this.textBox_pages.Name = "textBox_pages";
            this.textBox_pages.Size = new System.Drawing.Size(488, 40);
            this.textBox_pages.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(634, 202);
            this.Controls.Add(this.textBox_pages);
            this.Controls.Add(this.textBox_author);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_add);
            this.Name = "AddBookForm";
            this.Text = "AddBookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_author;
        private System.Windows.Forms.TextBox textBox_pages;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}