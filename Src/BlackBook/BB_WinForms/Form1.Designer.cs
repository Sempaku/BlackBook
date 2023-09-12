namespace BB_WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox_BooksOnMain = new System.Windows.Forms.ListBox();
            this.pdf_Reader = new AxAcroPDFLib.AxAcroPDF();
            this.tabPage_BookLibrary = new System.Windows.Forms.TabPage();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdf_Reader)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1210, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Main);
            this.tabControl.Controls.Add(this.tabPage_BookLibrary);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1210, 527);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.splitContainer1);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Main.Size = new System.Drawing.Size(1202, 501);
            this.tabPage_Main.TabIndex = 0;
            this.tabPage_Main.Text = "Main";
            this.tabPage_Main.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox_BooksOnMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pdf_Reader);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 495);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox_BooksOnMain
            // 
            this.listBox_BooksOnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_BooksOnMain.FormattingEnabled = true;
            this.listBox_BooksOnMain.Location = new System.Drawing.Point(0, 0);
            this.listBox_BooksOnMain.Name = "listBox_BooksOnMain";
            this.listBox_BooksOnMain.Size = new System.Drawing.Size(196, 495);
            this.listBox_BooksOnMain.TabIndex = 0;
            this.listBox_BooksOnMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_BooksOnMain_MouseDoubleClick);
            // 
            // pdf_Reader
            // 
            this.pdf_Reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdf_Reader.Enabled = true;
            this.pdf_Reader.Location = new System.Drawing.Point(0, 0);
            this.pdf_Reader.Name = "pdf_Reader";
            this.pdf_Reader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdf_Reader.OcxState")));
            this.pdf_Reader.Size = new System.Drawing.Size(996, 495);
            this.pdf_Reader.TabIndex = 0;
            // 
            // tabPage_BookLibrary
            // 
            this.tabPage_BookLibrary.Location = new System.Drawing.Point(4, 22);
            this.tabPage_BookLibrary.Name = "tabPage_BookLibrary";
            this.tabPage_BookLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BookLibrary.Size = new System.Drawing.Size(1202, 501);
            this.tabPage_BookLibrary.TabIndex = 1;
            this.tabPage_BookLibrary.Text = "Library";
            this.tabPage_BookLibrary.UseVisualStyleBackColor = true;
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.syncToolStripMenuItem.Text = "Sync";
            this.syncToolStripMenuItem.Click += new System.EventHandler(this.syncToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 551);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_Main.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdf_Reader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxAcroPDFLib.AxAcroPDF pdf_Reader;
        private System.Windows.Forms.TabPage tabPage_BookLibrary;
        private System.Windows.Forms.ListBox listBox_BooksOnMain;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
    }
}

