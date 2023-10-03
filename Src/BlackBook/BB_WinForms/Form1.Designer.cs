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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox_BooksOnMain = new System.Windows.Forms.ListBox();
            this.pdf_Reader = new AxAcroPDFLib.AxAcroPDF();
            this.tabPage_BookLibrary = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLLTABLESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLL_TABLES = new BB_WinForms.ALL_TABLES();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdf_Reader)).BeginInit();
            this.tabPage_BookLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLLTABLESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLL_TABLES)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.bookToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 24);
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
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.syncToolStripMenuItem.Text = "Sync";
            this.syncToolStripMenuItem.Click += new System.EventHandler(this.syncToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Main);
            this.tabControl.Controls.Add(this.tabPage_BookLibrary);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1081, 503);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.splitContainer1);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Main.Size = new System.Drawing.Size(1073, 477);
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
            this.splitContainer1.Size = new System.Drawing.Size(1067, 471);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox_BooksOnMain
            // 
            this.listBox_BooksOnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_BooksOnMain.FormattingEnabled = true;
            this.listBox_BooksOnMain.Location = new System.Drawing.Point(0, 0);
            this.listBox_BooksOnMain.Name = "listBox_BooksOnMain";
            this.listBox_BooksOnMain.Size = new System.Drawing.Size(174, 471);
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
            this.pdf_Reader.Size = new System.Drawing.Size(889, 471);
            this.pdf_Reader.TabIndex = 0;
            // 
            // tabPage_BookLibrary
            // 
            this.tabPage_BookLibrary.Controls.Add(this.dataGridView1);
            this.tabPage_BookLibrary.Location = new System.Drawing.Point(4, 22);
            this.tabPage_BookLibrary.Name = "tabPage_BookLibrary";
            this.tabPage_BookLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_BookLibrary.Size = new System.Drawing.Size(1073, 477);
            this.tabPage_BookLibrary.TabIndex = 1;
            this.tabPage_BookLibrary.Text = "Library";
            this.tabPage_BookLibrary.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.pagesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.booksBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 471);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.Frozen = true;
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 2;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.Frozen = true;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Название книги";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 105;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.Frozen = true;
            this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.ReadOnly = true;
            this.authorDataGridViewTextBoxColumn.Width = 63;
            // 
            // pagesDataGridViewTextBoxColumn
            // 
            this.pagesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pagesDataGridViewTextBoxColumn.DataPropertyName = "Pages";
            this.pagesDataGridViewTextBoxColumn.Frozen = true;
            this.pagesDataGridViewTextBoxColumn.HeaderText = "Pages";
            this.pagesDataGridViewTextBoxColumn.Name = "pagesDataGridViewTextBoxColumn";
            this.pagesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pagesDataGridViewTextBoxColumn.Width = 62;
            // 
            // booksBindingSource
            // 
            this.booksBindingSource.DataMember = "Books";
            this.booksBindingSource.DataSource = this.aLLTABLESBindingSource;
            // 
            // aLLTABLESBindingSource
            // 
            this.aLLTABLESBindingSource.DataSource = this.aLL_TABLES;
            this.aLLTABLESBindingSource.Position = 0;
            // 
            // aLL_TABLES
            // 
            this.aLL_TABLES.DataSetName = "ALL_TABLES";
            this.aLL_TABLES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookToolStripMenuItem});
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.bookToolStripMenuItem.Text = "Book";
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBookToolStripMenuItem.Text = "Add book";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 527);
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
            this.tabPage_BookLibrary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLLTABLESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLL_TABLES)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource aLLTABLESBindingSource;
        private ALL_TABLES aLL_TABLES;
        private System.Windows.Forms.BindingSource booksBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagesDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

