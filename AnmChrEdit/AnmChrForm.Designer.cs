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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.animBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.subsubEntryBox = new System.Windows.Forms.ListBox();
            this.subEntryBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.subsubDeleteButton = new System.Windows.Forms.Button();
            this.subsubPasteButton = new System.Windows.Forms.Button();
            this.subsubCopyButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.subDeleteButton = new System.Windows.Forms.Button();
            this.subPasteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.subCopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.extendButton = new System.Windows.Forms.Button();
            this.formatUnsetButton = new System.Windows.Forms.Button();
            this.format8HexButton = new System.Windows.Forms.Button();
            this.format16HexButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.filenameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.lblCurrentFile);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1MinSize = 15;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(918, 559);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.filenameLabel.Location = new System.Drawing.Point(397, 5);
            this.filenameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(31, 13);
            this.filenameLabel.TabIndex = 2;
            this.filenameLabel.Text = "none";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.Location = new System.Drawing.Point(303, 3);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(98, 17);
            this.lblCurrentFile.TabIndex = 2;
            this.lblCurrentFile.Text = "Current File:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(918, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatDisplayToolStripMenuItem,
            this.tutorialFilesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // formatDisplayToolStripMenuItem
            // 
            this.formatDisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unsetToolStripMenuItem,
            this.hexToolStripMenuItem,
            this.hexToolStripMenuItem1});
            this.formatDisplayToolStripMenuItem.Name = "formatDisplayToolStripMenuItem";
            this.formatDisplayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formatDisplayToolStripMenuItem.Text = "Format Display";
            // 
            // unsetToolStripMenuItem
            // 
            this.unsetToolStripMenuItem.Name = "unsetToolStripMenuItem";
            this.unsetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unsetToolStripMenuItem.Text = "Unset";
            this.unsetToolStripMenuItem.Click += new System.EventHandler(this.formatUnsetButton_Click);
            // 
            // hexToolStripMenuItem
            // 
            this.hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            this.hexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hexToolStripMenuItem.Text = "8 Hex";
            this.hexToolStripMenuItem.Click += new System.EventHandler(this.format8HexButton_Click);
            // 
            // hexToolStripMenuItem1
            // 
            this.hexToolStripMenuItem1.Name = "hexToolStripMenuItem1";
            this.hexToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.hexToolStripMenuItem1.Text = "16 Hex";
            this.hexToolStripMenuItem1.Click += new System.EventHandler(this.format16HexButton_Click);
            // 
            // tutorialFilesToolStripMenuItem
            // 
            this.tutorialFilesToolStripMenuItem.Name = "tutorialFilesToolStripMenuItem";
            this.tutorialFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tutorialFilesToolStripMenuItem.Text = "Tutorial Files";
            this.tutorialFilesToolStripMenuItem.Click += new System.EventHandler(this.testImgButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(918, 531);
            this.splitContainer2.SplitterDistance = 624;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Font = new System.Drawing.Font("Consolas", 12F);
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
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
            this.splitContainer4.Size = new System.Drawing.Size(622, 529);
            this.splitContainer4.SplitterDistance = 145;
            this.splitContainer4.SplitterWidth = 3;
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
            this.animBox.ItemHeight = 19;
            this.animBox.Location = new System.Drawing.Point(0, 0);
            this.animBox.Margin = new System.Windows.Forms.Padding(2);
            this.animBox.Name = "animBox";
            this.animBox.ScrollAlwaysVisible = true;
            this.animBox.Size = new System.Drawing.Size(622, 145);
            this.animBox.TabIndex = 0;
            this.animBox.SelectedIndexChanged += new System.EventHandler(this.animBox_SelectedIndexChanged);
            this.animBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnAnimBoxMouseMove);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.92374F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.07625F));
            this.tableLayoutPanel3.Controls.Add(this.subsubEntryBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.subEntryBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.49865F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.50135F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(622, 381);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // subsubEntryBox
            // 
            this.subsubEntryBox.BackColor = System.Drawing.Color.Black;
            this.subsubEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubEntryBox.ForeColor = System.Drawing.Color.White;
            this.subsubEntryBox.FormattingEnabled = true;
            this.subsubEntryBox.ItemHeight = 19;
            this.subsubEntryBox.Location = new System.Drawing.Point(3, 251);
            this.subsubEntryBox.Margin = new System.Windows.Forms.Padding(2);
            this.subsubEntryBox.Name = "subsubEntryBox";
            this.subsubEntryBox.ScrollAlwaysVisible = true;
            this.subsubEntryBox.Size = new System.Drawing.Size(397, 127);
            this.subsubEntryBox.TabIndex = 0;
            this.subsubEntryBox.SelectedIndexChanged += new System.EventHandler(this.subsubEntryBox_SelectedIndexChanged);
            this.subsubEntryBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnsubsubEntryBoxMouseMove);
            // 
            // subEntryBox
            // 
            this.subEntryBox.BackColor = System.Drawing.Color.Black;
            this.subEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subEntryBox.ForeColor = System.Drawing.Color.White;
            this.subEntryBox.FormattingEnabled = true;
            this.subEntryBox.ItemHeight = 19;
            this.subEntryBox.Location = new System.Drawing.Point(3, 3);
            this.subEntryBox.Margin = new System.Windows.Forms.Padding(2);
            this.subEntryBox.Name = "subEntryBox";
            this.subEntryBox.ScrollAlwaysVisible = true;
            this.subEntryBox.Size = new System.Drawing.Size(397, 243);
            this.subEntryBox.TabIndex = 0;
            this.subEntryBox.SelectedIndexChanged += new System.EventHandler(this.subEntryBox_SelectedIndexChanged);
            this.subEntryBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnsubEntryBoxMouseMove);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.subsubDeleteButton, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.subsubPasteButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.subsubCopyButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(405, 251);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(214, 127);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // subsubDeleteButton
            // 
            this.subsubDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subsubDeleteButton.Enabled = false;
            this.subsubDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subsubDeleteButton.Location = new System.Drawing.Point(2, 86);
            this.subsubDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.subsubDeleteButton.Name = "subsubDeleteButton";
            this.subsubDeleteButton.Size = new System.Drawing.Size(210, 39);
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
            this.subsubPasteButton.Location = new System.Drawing.Point(2, 44);
            this.subsubPasteButton.Margin = new System.Windows.Forms.Padding(2);
            this.subsubPasteButton.Name = "subsubPasteButton";
            this.subsubPasteButton.Size = new System.Drawing.Size(210, 38);
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
            this.subsubCopyButton.Location = new System.Drawing.Point(2, 2);
            this.subsubCopyButton.Margin = new System.Windows.Forms.Padding(2);
            this.subsubCopyButton.Name = "subsubCopyButton";
            this.subsubCopyButton.Size = new System.Drawing.Size(210, 38);
            this.subsubCopyButton.TabIndex = 0;
            this.subsubCopyButton.Text = "copy";
            this.subsubCopyButton.UseVisualStyleBackColor = true;
            this.subsubCopyButton.Click += new System.EventHandler(this.subsubCopyButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.subDeleteButton, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.subPasteButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.subCopyButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.timeTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lengthTextBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(405, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.93416F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.04938F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641975F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.46091F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.46091F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.22634F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2857F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(214, 243);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // subDeleteButton
            // 
            this.subDeleteButton.AutoSize = true;
            this.subDeleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subDeleteButton.Enabled = false;
            this.subDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subDeleteButton.Location = new System.Drawing.Point(2, 208);
            this.subDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.subDeleteButton.Name = "subDeleteButton";
            this.subDeleteButton.Size = new System.Drawing.Size(210, 33);
            this.subDeleteButton.TabIndex = 4;
            this.subDeleteButton.Text = "Delete";
            this.subDeleteButton.UseVisualStyleBackColor = true;
            this.subDeleteButton.Click += new System.EventHandler(this.subDeleteButton_Click);
            // 
            // subPasteButton
            // 
            this.subPasteButton.AutoSize = true;
            this.subPasteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subPasteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPasteButton.Enabled = false;
            this.subPasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subPasteButton.Location = new System.Drawing.Point(2, 171);
            this.subPasteButton.Margin = new System.Windows.Forms.Padding(2);
            this.subPasteButton.Name = "subPasteButton";
            this.subPasteButton.Size = new System.Drawing.Size(210, 33);
            this.subPasteButton.TabIndex = 3;
            this.subPasteButton.Text = "Paste";
            this.subPasteButton.UseVisualStyleBackColor = true;
            this.subPasteButton.Click += new System.EventHandler(this.subPasteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "↑ total time:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subCopyButton
            // 
            this.subCopyButton.AutoSize = true;
            this.subCopyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subCopyButton.Enabled = false;
            this.subCopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.subCopyButton.Location = new System.Drawing.Point(2, 131);
            this.subCopyButton.Margin = new System.Windows.Forms.Padding(2);
            this.subCopyButton.Name = "subCopyButton";
            this.subCopyButton.Size = new System.Drawing.Size(210, 36);
            this.subCopyButton.TabIndex = 2;
            this.subCopyButton.Text = "Copy";
            this.subCopyButton.UseVisualStyleBackColor = true;
            this.subCopyButton.Click += new System.EventHandler(this.subCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 21);
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
            this.timeTextBox.Location = new System.Drawing.Point(2, 91);
            this.timeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(210, 26);
            this.timeTextBox.TabIndex = 1;
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.BackColor = System.Drawing.Color.Black;
            this.lengthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lengthTextBox.Enabled = false;
            this.lengthTextBox.ForeColor = System.Drawing.Color.White;
            this.lengthTextBox.Location = new System.Drawing.Point(2, 31);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(210, 26);
            this.lengthTextBox.TabIndex = 6;
            this.lengthTextBox.TextChanged += new System.EventHandler(this.lengthTextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tableLayoutPanel1.Controls.Add(this.dataTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.importButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exportButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.extendButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.formatUnsetButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.format8HexButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.format16HexButton, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(289, 529);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dataTextBox
            // 
            this.dataTextBox.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.dataTextBox, 3);
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.dataTextBox.ForeColor = System.Drawing.Color.White;
            this.dataTextBox.Location = new System.Drawing.Point(2, 123);
            this.dataTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(285, 410);
            this.dataTextBox.TabIndex = 0;
            this.dataTextBox.TextChanged += new System.EventHandler(this.dataTextBox_TextChanged);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.AutoSize = true;
            this.importButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.importButton, 3);
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(2, 2);
            this.importButton.Margin = new System.Windows.Forms.Padding(2);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(285, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "&Import";
            this.importButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.importButton, "Ctrl + R");
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.AutoSize = true;
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.exportButton, 3);
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(2, 29);
            this.exportButton.Margin = new System.Windows.Forms.Padding(2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(285, 23);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "&Export";
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.exportButton, "Ctrl + E");
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // extendButton
            // 
            this.extendButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extendButton.AutoSize = true;
            this.extendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.extendButton, 3);
            this.extendButton.Enabled = false;
            this.extendButton.Location = new System.Drawing.Point(2, 56);
            this.extendButton.Margin = new System.Windows.Forms.Padding(2);
            this.extendButton.Name = "extendButton";
            this.extendButton.Size = new System.Drawing.Size(285, 23);
            this.extendButton.TabIndex = 3;
            this.extendButton.Text = "+ Ex&tend List";
            this.extendButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.extendButton, "Ctrl + T");
            this.extendButton.UseVisualStyleBackColor = true;
            this.extendButton.Click += new System.EventHandler(this.extendButton_Click);
            // 
            // formatUnsetButton
            // 
            this.formatUnsetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatUnsetButton.AutoSize = true;
            this.formatUnsetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formatUnsetButton.Enabled = false;
            this.formatUnsetButton.Location = new System.Drawing.Point(2, 83);
            this.formatUnsetButton.Margin = new System.Windows.Forms.Padding(2);
            this.formatUnsetButton.Name = "formatUnsetButton";
            this.formatUnsetButton.Size = new System.Drawing.Size(92, 23);
            this.formatUnsetButton.TabIndex = 3;
            this.formatUnsetButton.Text = "Unset";
            this.formatUnsetButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.formatUnsetButton, "Ctrl + 0");
            this.formatUnsetButton.UseVisualStyleBackColor = true;
            this.formatUnsetButton.Click += new System.EventHandler(this.formatUnsetButton_Click);
            // 
            // format8HexButton
            // 
            this.format8HexButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.format8HexButton.AutoSize = true;
            this.format8HexButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.format8HexButton.Enabled = false;
            this.format8HexButton.Location = new System.Drawing.Point(98, 83);
            this.format8HexButton.Margin = new System.Windows.Forms.Padding(2);
            this.format8HexButton.Name = "format8HexButton";
            this.format8HexButton.Size = new System.Drawing.Size(92, 23);
            this.format8HexButton.TabIndex = 3;
            this.format8HexButton.Text = "8Hex";
            this.format8HexButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.format8HexButton, "Ctrl + 1");
            this.format8HexButton.UseVisualStyleBackColor = true;
            this.format8HexButton.Click += new System.EventHandler(this.format8HexButton_Click);
            // 
            // format16HexButton
            // 
            this.format16HexButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.format16HexButton.AutoSize = true;
            this.format16HexButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.format16HexButton.Enabled = false;
            this.format16HexButton.Location = new System.Drawing.Point(194, 83);
            this.format16HexButton.Margin = new System.Windows.Forms.Padding(2);
            this.format16HexButton.Name = "format16HexButton";
            this.format16HexButton.Size = new System.Drawing.Size(93, 23);
            this.format16HexButton.TabIndex = 3;
            this.format16HexButton.Text = "16Hex";
            this.format16HexButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.format16HexButton, "Ctrl + 2");
            this.format16HexButton.UseVisualStyleBackColor = true;
            this.format16HexButton.Click += new System.EventHandler(this.format16HexButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.sizeLabel, 3);
            this.sizeLabel.Location = new System.Drawing.Point(2, 108);
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(33, 13);
            this.sizeLabel.TabIndex = 4;
            this.sizeLabel.Text = "ready";
            // 
            // AnmChrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 559);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AnmChrForm";
            this.Text = "AnmChrEditor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox animBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button extendButton;
        private System.Windows.Forms.Button formatUnsetButton;
        private System.Windows.Forms.Button format8HexButton;
        private System.Windows.Forms.Button format16HexButton;
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
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tutorialFilesToolStripMenuItem;
        private System.Windows.Forms.Label lblCurrentFile;
    }
}

