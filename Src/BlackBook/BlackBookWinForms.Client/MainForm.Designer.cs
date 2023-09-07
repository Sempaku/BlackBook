namespace BlackBookWinForms.Client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            MainWindow = new TabPage();
            BookLibrary = new TabPage();
            splitContainer1 = new SplitContainer();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            MainWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(53, 20);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(MainWindow);
            tabControl1.Controls.Add(BookLibrary);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(22, 21);
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1184, 737);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 2;
            tabControl1.TabStop = false;
            // 
            // MainWindow
            // 
            MainWindow.Controls.Add(splitContainer1);
            MainWindow.Location = new Point(4, 25);
            MainWindow.Name = "MainWindow";
            MainWindow.Padding = new Padding(3);
            MainWindow.Size = new Size(1176, 708);
            MainWindow.TabIndex = 0;
            MainWindow.Text = "Reader";
            MainWindow.UseVisualStyleBackColor = true;
            // 
            // BookLibrary
            // 
            BookLibrary.Location = new Point(4, 25);
            BookLibrary.Name = "BookLibrary";
            BookLibrary.Padding = new Padding(3);
            BookLibrary.Size = new Size(792, 397);
            BookLibrary.TabIndex = 1;
            BookLibrary.Text = "Library";
            BookLibrary.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(1170, 702);
            splitContainer1.SplitterDistance = 210;
            splitContainer1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1184, 761);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            MainWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage MainWindow;
        private TabPage BookLibrary;
        private SplitContainer splitContainer1;
    }
}
