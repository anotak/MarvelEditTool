﻿namespace StatusEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
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
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.extendButton = new System.Windows.Forms.Button();
            this.duplicateButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.addSubChunkButton = new System.Windows.Forms.Button();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.upButton = new System.Windows.Forms.Button();
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
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(843, 526);
            this.splitContainer2.SplitterDistance = 424;
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
            this.splitContainer4.Panel2.Controls.Add(this.structView);
            this.splitContainer4.Size = new System.Drawing.Size(424, 526);
            this.splitContainer4.SplitterDistance = 75;
            this.splitContainer4.TabIndex = 1;
            // 
            // animBox
            // 
            this.animBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animBox.Enabled = false;
            this.animBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animBox.FormattingEnabled = true;
            this.animBox.ItemHeight = 23;
            this.animBox.Location = new System.Drawing.Point(0, 0);
            this.animBox.Name = "animBox";
            this.animBox.ScrollAlwaysVisible = true;
            this.animBox.Size = new System.Drawing.Size(424, 75);
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
            this.structView.Name = "structView";
            this.structView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.structView.RowHeadersVisible = false;
            this.structView.RowTemplate.Height = 24;
            this.structView.Size = new System.Drawing.Size(424, 447);
            this.structView.TabIndex = 1;
            // 
            // SubChunkColumn
            // 
            this.SubChunkColumn.FillWeight = 4F;
            this.SubChunkColumn.HeaderText = "subchunk";
            this.SubChunkColumn.Name = "SubChunkColumn";
            this.SubChunkColumn.ReadOnly = true;
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
            this.splitContainer3.Size = new System.Drawing.Size(415, 526);
            this.splitContainer3.SplitterDistance = 237;
            this.splitContainer3.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.importButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exportButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.extendButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.duplicateButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.addSubChunkButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.sizeLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.upButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 237);
            this.tableLayoutPanel1.TabIndex = 4;
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
            this.importButton.Size = new System.Drawing.Size(409, 27);
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
            this.exportButton.Size = new System.Drawing.Size(409, 27);
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
            this.extendButton.Size = new System.Drawing.Size(409, 27);
            this.extendButton.TabIndex = 3;
            this.extendButton.Text = "+ Ex&tend List  (Ctrl+T)";
            this.extendButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.duplicateButton.Location = new System.Drawing.Point(3, 102);
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(409, 27);
            this.duplicateButton.TabIndex = 5;
            this.duplicateButton.Text = "Duplicate";
            this.duplicateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duplicateButton.UseVisualStyleBackColor = true;
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(3, 198);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(44, 17);
            this.sizeLabel.TabIndex = 4;
            this.sizeLabel.Text = "ready";
            // 
            // addSubChunkButton
            // 
            this.addSubChunkButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addSubChunkButton.AutoSize = true;
            this.addSubChunkButton.Enabled = false;
            this.addSubChunkButton.Location = new System.Drawing.Point(3, 135);
            this.addSubChunkButton.Name = "addSubChunkButton";
            this.addSubChunkButton.Size = new System.Drawing.Size(409, 27);
            this.addSubChunkButton.TabIndex = 6;
            this.addSubChunkButton.Text = "Add SubChunk";
            this.addSubChunkButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addSubChunkButton.UseVisualStyleBackColor = true;
            this.addSubChunkButton.Click += new System.EventHandler(this.addSubChunkButton_Click);
            // 
            // dataTextBox
            // 
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.dataTextBox.Location = new System.Drawing.Point(0, 0);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(415, 285);
            this.dataTextBox.TabIndex = 0;
            this.dataTextBox.WordWrap = false;
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.AutoSize = true;
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(3, 168);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(409, 27);
            this.upButton.TabIndex = 7;
            this.upButton.Text = "Move Up";
            this.upButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // StatusEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 568);
            this.Controls.Add(this.splitContainer1);
            this.Name = "StatusEditorForm";
            this.Text = "StatusEditor";
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
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView structView;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubChunkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hexColumn;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Button duplicateButton;
        private System.Windows.Forms.Button addSubChunkButton;
        private System.Windows.Forms.Button upButton;
    }
}

