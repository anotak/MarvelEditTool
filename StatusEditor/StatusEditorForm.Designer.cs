using System.Windows.Forms;

namespace StatusEditor
{
    partial class StatusEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusEditorForm));
            this.filenameLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.animBox = new System.Windows.Forms.ListBox();
            this.structView = new System.Windows.Forms.DataGridView();
            this.SubChunkColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.extendButton = new System.Windows.Forms.Button();
            this.duplicateButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.addSubChunkButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.option1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openATIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBABaseActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHSStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLICollisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSPCommandSpecialAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sHTShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.structView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(108, 26);
            this.filenameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(31, 13);
            this.filenameLabel.TabIndex = 2;
            this.filenameLabel.Text = "none";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCurrentFile);
            this.splitContainer1.Panel1.Controls.Add(this.filenameLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(671, 454);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.Location = new System.Drawing.Point(12, 24);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(98, 17);
            this.lblCurrentFile.TabIndex = 3;
            this.lblCurrentFile.Text = "Current File:";
            // 
            // splitContainer2
            // 
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
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(671, 408);
            this.splitContainer2.SplitterDistance = 416;
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
            this.splitContainer4.Panel2.Controls.Add(this.structView);
            this.splitContainer4.Size = new System.Drawing.Size(416, 408);
            this.splitContainer4.SplitterDistance = 122;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 1;
            // 
            // animBox
            // 
            this.animBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animBox.Enabled = false;
            this.animBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animBox.FormattingEnabled = true;
            this.animBox.ItemHeight = 19;
            this.animBox.Location = new System.Drawing.Point(0, 0);
            this.animBox.Margin = new System.Windows.Forms.Padding(2);
            this.animBox.Name = "animBox";
            this.animBox.ScrollAlwaysVisible = true;
            this.animBox.Size = new System.Drawing.Size(416, 122);
            this.animBox.TabIndex = 0;
            this.animBox.SelectedIndexChanged += new System.EventHandler(this.animBox_SelectedIndexChanged);
            // 
            // structView
            // 
            this.structView.AllowUserToAddRows = false;
            this.structView.AllowUserToDeleteRows = false;
            this.structView.AllowUserToResizeRows = false;
            this.structView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.structView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.structView.ColumnHeadersVisible = false;
            this.structView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubChunkColumn,
            this.varColumn,
            this.valueColumn,
            this.hexColumn});
            this.structView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structView.Enabled = false;
            this.structView.Location = new System.Drawing.Point(0, 0);
            this.structView.Margin = new System.Windows.Forms.Padding(2);
            this.structView.Name = "structView";
            this.structView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.structView.RowHeadersVisible = false;
            this.structView.RowTemplate.Height = 24;
            this.structView.Size = new System.Drawing.Size(416, 283);
            this.structView.TabIndex = 1;
            this.structView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.structView_SelectedIndexChanged);
            // 
            // SubChunkColumn
            // 
            this.SubChunkColumn.FillWeight = 4F;
            this.SubChunkColumn.HeaderText = "subchunk";
            this.SubChunkColumn.Name = "SubChunkColumn";
            this.SubChunkColumn.ReadOnly = true;
            this.SubChunkColumn.Visible = false;
            // 
            // varColumn
            // 
            this.varColumn.FillWeight = 50F;
            this.varColumn.HeaderText = "var";
            this.varColumn.Name = "varColumn";
            this.varColumn.ReadOnly = true;
            // 
            // valueColumn
            // 
            this.valueColumn.FillWeight = 66.04459F;
            this.valueColumn.HeaderText = "value";
            this.valueColumn.Name = "valueColumn";
            // 
            // hexColumn
            // 
            this.hexColumn.FillWeight = 45F;
            this.hexColumn.HeaderText = "hex";
            this.hexColumn.MinimumWidth = 70;
            this.hexColumn.Name = "hexColumn";
            this.hexColumn.ReadOnly = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataTextBox);
            this.splitContainer3.Size = new System.Drawing.Size(252, 408);
            this.splitContainer3.SplitterDistance = 243;
            this.splitContainer3.SplitterWidth = 2;
            this.splitContainer3.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.importButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exportButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.extendButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.duplicateButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.upButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.downButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.addSubChunkButton, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 243);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(2, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 68;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.AutoSize = true;
            this.importButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(2, 26);
            this.importButton.Margin = new System.Windows.Forms.Padding(2);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(248, 23);
            this.importButton.TabIndex = 1;
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
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(2, 53);
            this.exportButton.Margin = new System.Windows.Forms.Padding(2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(248, 23);
            this.exportButton.TabIndex = 2;
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
            this.extendButton.Enabled = false;
            this.extendButton.Location = new System.Drawing.Point(2, 80);
            this.extendButton.Margin = new System.Windows.Forms.Padding(2);
            this.extendButton.Name = "extendButton";
            this.extendButton.Size = new System.Drawing.Size(248, 23);
            this.extendButton.TabIndex = 3;
            this.extendButton.Text = "&Ex&tend List";
            this.extendButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.extendButton, "Ctrl + T");
            this.extendButton.UseVisualStyleBackColor = true;
            this.extendButton.Click += new System.EventHandler(this.extendButton_Click);
            // 
            // duplicateButton
            // 
            this.duplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateButton.AutoSize = true;
            this.duplicateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.duplicateButton.Enabled = false;
            this.duplicateButton.Location = new System.Drawing.Point(2, 107);
            this.duplicateButton.Margin = new System.Windows.Forms.Padding(2);
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(248, 23);
            this.duplicateButton.TabIndex = 4;
            this.duplicateButton.Text = "Duplicate";
            this.duplicateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duplicateButton.UseVisualStyleBackColor = true;
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.AutoSize = true;
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(2, 134);
            this.upButton.Margin = new System.Windows.Forms.Padding(2);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(248, 23);
            this.upButton.TabIndex = 5;
            this.upButton.Text = "Move Up (Disabled)";
            this.upButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // addSubChunkButton
            // 
            this.addSubChunkButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addSubChunkButton.AutoSize = true;
            this.addSubChunkButton.Enabled = false;
            this.addSubChunkButton.Location = new System.Drawing.Point(2, 188);
            this.addSubChunkButton.Margin = new System.Windows.Forms.Padding(2);
            this.addSubChunkButton.Name = "addSubChunkButton";
            this.addSubChunkButton.Size = new System.Drawing.Size(248, 23);
            this.addSubChunkButton.TabIndex = 6;
            this.addSubChunkButton.Text = "Add SubChunk";
            this.addSubChunkButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addSubChunkButton.UseVisualStyleBackColor = true;
            this.addSubChunkButton.Click += new System.EventHandler(this.addSubChunkButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.AutoSize = true;
            this.downButton.Enabled = false;
            this.downButton.Location = new System.Drawing.Point(2, 161);
            this.downButton.Margin = new System.Windows.Forms.Padding(2);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(248, 23);
            this.downButton.TabIndex = 7;
            this.downButton.Text = "Move Down (Disabled)";
            this.downButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(2, 214);
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(33, 13);
            this.sizeLabel.TabIndex = 8;
            this.sizeLabel.Text = "ready";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.dataTextBox.Location = new System.Drawing.Point(0, 0);
            this.dataTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(252, 163);
            this.dataTextBox.TabIndex = 9;
            this.dataTextBox.WordWrap = false;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tagsDataGridView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(671, 102);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 454);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(671, 102);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // tagsDataGridView
            // 
            this.tagsDataGridView.AllowUserToAddRows = false;
            this.tagsDataGridView.AllowUserToDeleteRows = false;
            this.tagsDataGridView.AllowUserToResizeRows = false;
            this.tagsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tagsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.tagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsDataGridView.ColumnHeadersVisible = false;
            this.tagsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsDataGridView.Enabled = false;
            this.tagsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tagsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.ReadOnly = true;
            this.tagsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tagsDataGridView.RowHeadersVisible = false;
            this.tagsDataGridView.RowTemplate.Height = 24;
            this.tagsDataGridView.Size = new System.Drawing.Size(671, 102);
            this.tagsDataGridView.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // option1ToolStripMenuItem
            // 
            this.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            this.option1ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.option1ToolStripMenuItem.Text = "option 1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFileTypeToolStripMenuItem,
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openFileTypeToolStripMenuItem
            // 
            this.openFileTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openATIToolStripMenuItem,
            this.cBABaseActionToolStripMenuItem,
            this.oToolStripMenuItem,
            this.cHSStatusToolStripMenuItem,
            this.cLICollisionToolStripMenuItem,
            this.cSPCommandSpecialAttackToolStripMenuItem,
            this.sHTShotToolStripMenuItem});
            this.openFileTypeToolStripMenuItem.Name = "openFileTypeToolStripMenuItem";
            this.openFileTypeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openFileTypeToolStripMenuItem.Text = "Open File Type";
            // 
            // openATIToolStripMenuItem
            // 
            this.openATIToolStripMenuItem.Name = "openATIToolStripMenuItem";
            this.openATIToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.openATIToolStripMenuItem.Text = "ATI - Attack Info";
            this.openATIToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // cBABaseActionToolStripMenuItem
            // 
            this.cBABaseActionToolStripMenuItem.Name = "cBABaseActionToolStripMenuItem";
            this.cBABaseActionToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.cBABaseActionToolStripMenuItem.Text = "CBA - Command Base Actions";
            this.cBABaseActionToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.oToolStripMenuItem.Text = "CCM - Command Combo Actions";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // cHSStatusToolStripMenuItem
            // 
            this.cHSStatusToolStripMenuItem.Name = "cHSStatusToolStripMenuItem";
            this.cHSStatusToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.cHSStatusToolStripMenuItem.Text = "CHS - Character Status";
            this.cHSStatusToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // cLICollisionToolStripMenuItem
            // 
            this.cLICollisionToolStripMenuItem.Name = "cLICollisionToolStripMenuItem";
            this.cLICollisionToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.cLICollisionToolStripMenuItem.Text = "CLI - Collision";
            this.cLICollisionToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // cSPCommandSpecialAttackToolStripMenuItem
            // 
            this.cSPCommandSpecialAttackToolStripMenuItem.Name = "cSPCommandSpecialAttackToolStripMenuItem";
            this.cSPCommandSpecialAttackToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.cSPCommandSpecialAttackToolStripMenuItem.Text = "CSP - Command Special Actions";
            this.cSPCommandSpecialAttackToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // sHTShotToolStripMenuItem
            // 
            this.sHTShotToolStripMenuItem.Name = "sHTShotToolStripMenuItem";
            this.sHTShotToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.sHTShotToolStripMenuItem.Text = "SHT - Shot";
            this.sHTShotToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
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
            this.formatDisplayToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.formatDisplayToolStripMenuItem.Text = "Format Display";
            // 
            // unsetToolStripMenuItem
            // 
            this.unsetToolStripMenuItem.Name = "unsetToolStripMenuItem";
            this.unsetToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.unsetToolStripMenuItem.Tag = "0";
            this.unsetToolStripMenuItem.Text = "Unset";
            this.unsetToolStripMenuItem.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // hexToolStripMenuItem
            // 
            this.hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            this.hexToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hexToolStripMenuItem.Tag = "8";
            this.hexToolStripMenuItem.Text = "8 Hex";
            this.hexToolStripMenuItem.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // hexToolStripMenuItem1
            // 
            this.hexToolStripMenuItem1.Name = "hexToolStripMenuItem1";
            this.hexToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.hexToolStripMenuItem1.Tag = "16";
            this.hexToolStripMenuItem1.Text = "16 Hex";
            this.hexToolStripMenuItem1.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // tutorialFilesToolStripMenuItem
            // 
            this.tutorialFilesToolStripMenuItem.Name = "tutorialFilesToolStripMenuItem";
            this.tutorialFilesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tutorialFilesToolStripMenuItem.Text = "Tutorial Files";
            // 
            // StatusEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 556);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StatusEditorForm";
            this.Text = "SE - Standard Editor";
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
            ((System.ComponentModel.ISupportInitialize)(this.structView)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ListBox animBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button extendButton;
        private Button importButton;
        private Button exportButton;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private DataGridView structView;
        private TextBox dataTextBox;
        private Button duplicateButton;
        private Button addSubChunkButton;
        private Button upButton;
        private ToolTip toolTip;
        private DataGridView tagsDataGridView;
        private DataGridViewTextBoxColumn SubChunkColumn;
        private DataGridViewTextBoxColumn varColumn;
        private DataGridViewTextBoxColumn valueColumn;
        private DataGridViewTextBoxColumn hexColumn;
        private ToolStripContainer toolStripContainer1;
        private Label sizeLabel;
        private Button downButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem option1ToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem formatDisplayToolStripMenuItem;
        private ToolStripMenuItem unsetToolStripMenuItem;
        private ToolStripMenuItem hexToolStripMenuItem;
        private ToolStripMenuItem hexToolStripMenuItem1;
        private ToolStripMenuItem tutorialFilesToolStripMenuItem;
        private Label lblCurrentFile;
        private Label filenameLabel;
        private TextBox textBox1;
        private ToolStripMenuItem openFileTypeToolStripMenuItem;
        private ToolStripMenuItem openATIToolStripMenuItem;
        private ToolStripMenuItem cLICollisionToolStripMenuItem;
        private ToolStripMenuItem oToolStripMenuItem;
        private ToolStripMenuItem cSPCommandSpecialAttackToolStripMenuItem;
        private ToolStripMenuItem cHSStatusToolStripMenuItem;
        private ToolStripMenuItem sHTShotToolStripMenuItem;
        private ToolStripMenuItem cBABaseActionToolStripMenuItem;
    }
}

