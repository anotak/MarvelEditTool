namespace AnmChrEdit
{
    partial class AnmChrForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.animBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.subDeleteButton = new System.Windows.Forms.Button();
            this.subPasteButton = new System.Windows.Forms.Button();
            this.subCopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.subsubEntryBox = new System.Windows.Forms.ListBox();
            this.subEntryBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.subsubDeleteButton = new System.Windows.Forms.Button();
            this.subsubPasteButton = new System.Windows.Forms.Button();
            this.subsubCopyButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.extendButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.filenameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.saveButton);
            this.splitContainer1.Panel1.Controls.Add(this.openButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(843, 568);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 0;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(301, 4);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(93, 17);
            this.filenameLabel.TabIndex = 2;
            this.filenameLabel.Text = "no file loaded";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(140, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(155, 31);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "&Save (Ctrl+S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.openButton.Location = new System.Drawing.Point(4, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(129, 31);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "&Open (Ctrl+O)";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(843, 526);
            this.splitContainer2.SplitterDistance = 395;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Font = new System.Drawing.Font("Consolas", 12F);
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.animBox);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer4.Size = new System.Drawing.Size(393, 524);
            this.splitContainer4.SplitterDistance = 111;
            this.splitContainer4.TabIndex = 1;
            // 
            // animBox
            // 
            this.animBox.BackColor = System.Drawing.Color.Black;
            this.animBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animBox.Enabled = false;
            this.animBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animBox.ForeColor = System.Drawing.Color.White;
            this.animBox.FormattingEnabled = true;
            this.animBox.ItemHeight = 23;
            this.animBox.Location = new System.Drawing.Point(0, 0);
            this.animBox.Name = "animBox";
            this.animBox.ScrollAlwaysVisible = true;
            this.animBox.Size = new System.Drawing.Size(393, 111);
            this.animBox.TabIndex = 0;
            this.animBox.SelectedIndexChanged += new System.EventHandler(this.animBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.92978F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.07022F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.subsubEntryBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.subEntryBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(393, 409);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lengthTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.subDeleteButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.subPasteButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.subCopyButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.timeTextBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(133, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 156);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "↑ total time:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.BackColor = System.Drawing.Color.Black;
            this.lengthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lengthTextBox.Enabled = false;
            this.lengthTextBox.ForeColor = System.Drawing.Color.White;
            this.lengthTextBox.Location = new System.Drawing.Point(195, 3);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(208, 31);
            this.lengthTextBox.TabIndex = 6;
            this.lengthTextBox.TextChanged += new System.EventHandler(this.lengthTextBox_TextChanged);
            // 
            // subDeleteButton
            // 
            this.subDeleteButton.Enabled = false;
            this.subDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subDeleteButton.Location = new System.Drawing.Point(195, 79);
            this.subDeleteButton.Name = "subDeleteButton";
            this.subDeleteButton.Size = new System.Drawing.Size(208, 33);
            this.subDeleteButton.TabIndex = 4;
            this.subDeleteButton.Text = "Delete";
            this.subDeleteButton.UseVisualStyleBackColor = true;
            this.subDeleteButton.Click += new System.EventHandler(this.subDeleteButton_Click);
            // 
            // subPasteButton
            // 
            this.subPasteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPasteButton.Enabled = false;
            this.subPasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subPasteButton.Location = new System.Drawing.Point(3, 118);
            this.subPasteButton.Name = "subPasteButton";
            this.subPasteButton.Size = new System.Drawing.Size(186, 35);
            this.subPasteButton.TabIndex = 3;
            this.subPasteButton.Text = "Paste";
            this.subPasteButton.UseVisualStyleBackColor = true;
            this.subPasteButton.Click += new System.EventHandler(this.subPasteButton_Click);
            // 
            // subCopyButton
            // 
            this.subCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subCopyButton.Enabled = false;
            this.subCopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subCopyButton.Location = new System.Drawing.Point(3, 79);
            this.subCopyButton.Name = "subCopyButton";
            this.subCopyButton.Size = new System.Drawing.Size(186, 33);
            this.subCopyButton.TabIndex = 2;
            this.subCopyButton.Text = "Copy";
            this.subCopyButton.UseVisualStyleBackColor = true;
            this.subCopyButton.Click += new System.EventHandler(this.subCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "← subchunk time:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTextBox
            // 
            this.timeTextBox.BackColor = System.Drawing.Color.Black;
            this.timeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTextBox.Enabled = false;
            this.timeTextBox.ForeColor = System.Drawing.Color.White;
            this.timeTextBox.Location = new System.Drawing.Point(195, 40);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(208, 31);
            this.timeTextBox.TabIndex = 1;
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            // 
            // subsubEntryBox
            // 
            this.subsubEntryBox.BackColor = System.Drawing.Color.Black;
            this.subsubEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubEntryBox.ForeColor = System.Drawing.Color.White;
            this.subsubEntryBox.FormattingEnabled = true;
            this.subsubEntryBox.ItemHeight = 23;
            this.subsubEntryBox.Location = new System.Drawing.Point(4, 208);
            this.subsubEntryBox.Name = "subsubEntryBox";
            this.subsubEntryBox.ScrollAlwaysVisible = true;
            this.subsubEntryBox.Size = new System.Drawing.Size(122, 197);
            this.subsubEntryBox.TabIndex = 0;
            this.subsubEntryBox.SelectedIndexChanged += new System.EventHandler(this.subsubEntryBox_SelectedIndexChanged);
            // 
            // subEntryBox
            // 
            this.subEntryBox.BackColor = System.Drawing.Color.Black;
            this.subEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subEntryBox.ForeColor = System.Drawing.Color.White;
            this.subEntryBox.FormattingEnabled = true;
            this.subEntryBox.ItemHeight = 23;
            this.subEntryBox.Location = new System.Drawing.Point(4, 4);
            this.subEntryBox.Name = "subEntryBox";
            this.subEntryBox.ScrollAlwaysVisible = true;
            this.subEntryBox.Size = new System.Drawing.Size(122, 197);
            this.subEntryBox.TabIndex = 0;
            this.subEntryBox.SelectedIndexChanged += new System.EventHandler(this.subEntryBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.subsubDeleteButton, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.subsubPasteButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.subsubCopyButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(133, 208);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(256, 197);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // subsubDeleteButton
            // 
            this.subsubDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubDeleteButton.Enabled = false;
            this.subsubDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subsubDeleteButton.Location = new System.Drawing.Point(3, 133);
            this.subsubDeleteButton.Name = "subsubDeleteButton";
            this.subsubDeleteButton.Size = new System.Drawing.Size(250, 61);
            this.subsubDeleteButton.TabIndex = 2;
            this.subsubDeleteButton.Text = "delete";
            this.subsubDeleteButton.UseVisualStyleBackColor = true;
            this.subsubDeleteButton.Click += new System.EventHandler(this.subsubDeleteButton_Click);
            // 
            // subsubPasteButton
            // 
            this.subsubPasteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubPasteButton.Enabled = false;
            this.subsubPasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subsubPasteButton.Location = new System.Drawing.Point(3, 68);
            this.subsubPasteButton.Name = "subsubPasteButton";
            this.subsubPasteButton.Size = new System.Drawing.Size(250, 59);
            this.subsubPasteButton.TabIndex = 1;
            this.subsubPasteButton.Text = "paste";
            this.subsubPasteButton.UseVisualStyleBackColor = true;
            this.subsubPasteButton.Click += new System.EventHandler(this.subsubPasteButton_Click);
            // 
            // subsubCopyButton
            // 
            this.subsubCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubCopyButton.Enabled = false;
            this.subsubCopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subsubCopyButton.Location = new System.Drawing.Point(3, 3);
            this.subsubCopyButton.Name = "subsubCopyButton";
            this.subsubCopyButton.Size = new System.Drawing.Size(250, 59);
            this.subsubCopyButton.TabIndex = 0;
            this.subsubCopyButton.Text = "copy";
            this.subsubCopyButton.UseVisualStyleBackColor = true;
            this.subsubCopyButton.Click += new System.EventHandler(this.subsubCopyButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.importButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exportButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.extendButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(442, 524);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dataTextBox
            // 
            this.dataTextBox.BackColor = System.Drawing.Color.Black;
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.dataTextBox.ForeColor = System.Drawing.Color.White;
            this.dataTextBox.Location = new System.Drawing.Point(3, 119);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(436, 402);
            this.dataTextBox.TabIndex = 0;
            this.dataTextBox.TextChanged += new System.EventHandler(this.dataTextBox_TextChanged);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.AutoSize = true;
            this.importButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(3, 3);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(436, 27);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "&Import (Ctrl+R)";
            this.importButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.AutoSize = true;
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(3, 36);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(436, 27);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "&Export (Ctrl+E)";
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // extendButton
            // 
            this.extendButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extendButton.AutoSize = true;
            this.extendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendButton.Enabled = false;
            this.extendButton.Location = new System.Drawing.Point(3, 69);
            this.extendButton.Name = "extendButton";
            this.extendButton.Size = new System.Drawing.Size(436, 27);
            this.extendButton.TabIndex = 3;
            this.extendButton.Text = "+ Ex&tend List  (Ctrl+T)";
            this.extendButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.extendButton.UseVisualStyleBackColor = true;
            this.extendButton.Click += new System.EventHandler(this.extendButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(3, 99);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(44, 17);
            this.sizeLabel.TabIndex = 4;
            this.sizeLabel.Text = "ready";
            // 
            // AnmChrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 568);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnmChrForm";
            this.Text = "AnmChrEditor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox animBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button extendButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.ListBox subsubEntryBox;
        private System.Windows.Forms.ListBox subEntryBox;
        private System.Windows.Forms.Button subCopyButton;
        private System.Windows.Forms.Button subPasteButton;
        private System.Windows.Forms.Button subDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button subsubPasteButton;
        private System.Windows.Forms.Button subsubCopyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Button subsubDeleteButton;
    }
}

