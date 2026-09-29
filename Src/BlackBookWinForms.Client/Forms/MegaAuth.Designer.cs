namespace BlackBookWinForms.Client.Forms
{
    partial class MegaAuth
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
            label1 = new Label();
            label2 = new Label();
            tb_Password = new TextBox();
            tb_Email = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "E-mail:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // tb_Password
            // 
            tb_Password.Location = new Point(12, 80);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '*';
            tb_Password.PlaceholderText = "Пароль";
            tb_Password.Size = new Size(291, 23);
            tb_Password.TabIndex = 3;
            // 
            // tb_Email
            // 
            tb_Email.Location = new Point(12, 27);
            tb_Email.Name = "tb_Email";
            tb_Email.PlaceholderText = "Email";
            tb_Email.Size = new Size(291, 23);
            tb_Email.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 120);
            button1.Name = "button1";
            button1.Size = new Size(291, 38);
            button1.TabIndex = 5;
            button1.Text = "CONNECT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MegaAuth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 170);
            Controls.Add(button1);
            Controls.Add(tb_Email);
            Controls.Add(tb_Password);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MegaAuth";
            Text = "Connection to MEGA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_Password;
        private TextBox tb_Email;
        private Button button1;
    }
}