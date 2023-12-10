using System.Drawing;
using System.Windows.Forms;
using MarvelData;

namespace AnmChrEdit
{
    partial class ACE
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


        // Custom text color for ListBox items
        private void commandBlocksBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            //this.commandBlocksBox.DrawItem += commandBlocksBox_DrawItem;
            if (e.Index >= 0)
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;
                e.Graphics.DrawString(commandBlocksBox.Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();


                if (commandBlocksBox.Items[e.Index].ToString().Contains("Disabled"))
                {
                    myBrush = Brushes.Gray;
                    e.Graphics.DrawString(commandBlocksBox.Items[e.Index].ToString(),
                        e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                    e.DrawFocusRectangle();
                }
                /*          This crashes because the index cap doesnt update until after its drawn, fix later, vV
                 
                if (commandBlocksBox.Items[e.Index].ToString().Contains("Disabled") || ((AnmChrEntry)tablefile.table[animBox.SelectedIndex]).animTime < ((AnmChrEntry)tablefile.table[animBox.SelectedIndex]).subEntries[e.Index].localindex)
                {
                    myBrush = Brushes.Gray;
                    e.Graphics.DrawString(commandBlocksBox.Items[e.Index].ToString(),
                        e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                    e.DrawFocusRectangle();
                }*/
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACE));
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
            this.commandBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCommandBlockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandBlockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCommandBlockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCommandBlockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hex8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hex16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.animBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.commandBlocksBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.commandsDeleteButton = new System.Windows.Forms.Button();
            this.commandsPasteButton = new System.Windows.Forms.Button();
            this.commandsCopyButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.commandBlockDisableButton = new System.Windows.Forms.Button();
            this.commandBlockDeleteButton = new System.Windows.Forms.Button();
            this.commandBlockPasteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.commandBlockCopyButton = new System.Windows.Forms.Button();
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
            this.commandBlockContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCommandBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCommandBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCommandBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.offSetToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.setCommandBlockFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.commandBlockContextMenuStrip.SuspendLayout();
            this.commandContextMenuStrip1.SuspendLayout();
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandBlockToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.formatDisplayToolStripMenuItem,
            this.tutorialFilesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // commandBlockToolStripMenuItem
            // 
            this.commandBlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCommandBlockToolStripMenuItem1,
            this.deleteCommandBlockToolStripMenuItem1,
            this.disableCommandBlockToolStripMenuItem1,
            this.pasteCommandBlockToolStripMenuItem1});
            this.commandBlockToolStripMenuItem.Name = "commandBlockToolStripMenuItem";
            this.commandBlockToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.commandBlockToolStripMenuItem.Text = "Command Block";
            // 
            // copyCommandBlockToolStripMenuItem1
            // 
            this.copyCommandBlockToolStripMenuItem1.Enabled = false;
            this.copyCommandBlockToolStripMenuItem1.Name = "copyCommandBlockToolStripMenuItem1";
            this.copyCommandBlockToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.copyCommandBlockToolStripMenuItem1.Text = "Copy";
            this.copyCommandBlockToolStripMenuItem1.Click += new System.EventHandler(this.commandBlockCopyButton_Click);
            // 
            // deleteCommandBlockToolStripMenuItem1
            // 
            this.deleteCommandBlockToolStripMenuItem1.Enabled = false;
            this.deleteCommandBlockToolStripMenuItem1.Name = "deleteCommandBlockToolStripMenuItem1";
            this.deleteCommandBlockToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.deleteCommandBlockToolStripMenuItem1.Text = "Delete";
            this.deleteCommandBlockToolStripMenuItem1.Click += new System.EventHandler(this.commandBlockDeleteButton_Click);
            // 
            // disableCommandBlockToolStripMenuItem1
            // 
            this.disableCommandBlockToolStripMenuItem1.Enabled = false;
            this.disableCommandBlockToolStripMenuItem1.Name = "disableCommandBlockToolStripMenuItem1";
            this.disableCommandBlockToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.disableCommandBlockToolStripMenuItem1.Text = "Disable";
            this.disableCommandBlockToolStripMenuItem1.Click += new System.EventHandler(this.disableCommandBlockToolStripMenuItem_Click);
            // 
            // pasteCommandBlockToolStripMenuItem1
            // 
            this.pasteCommandBlockToolStripMenuItem1.Enabled = false;
            this.pasteCommandBlockToolStripMenuItem1.Name = "pasteCommandBlockToolStripMenuItem1";
            this.pasteCommandBlockToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.pasteCommandBlockToolStripMenuItem1.Text = "Paste";
            this.pasteCommandBlockToolStripMenuItem1.Click += new System.EventHandler(this.commandBlockPasteButton_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCommandsToolStripMenuItem,
            this.deleteCommandsToolStripMenuItem,
            this.pasteCommandsToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.commandsToolStripMenuItem.Text = "Command";
            // 
            // copyCommandsToolStripMenuItem
            // 
            this.copyCommandsToolStripMenuItem.Enabled = false;
            this.copyCommandsToolStripMenuItem.Name = "copyCommandsToolStripMenuItem";
            this.copyCommandsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyCommandsToolStripMenuItem.Text = "Copy";
            this.copyCommandsToolStripMenuItem.Click += new System.EventHandler(this.commandsCopyButton_Click);
            // 
            // deleteCommandsToolStripMenuItem
            // 
            this.deleteCommandsToolStripMenuItem.Enabled = false;
            this.deleteCommandsToolStripMenuItem.Name = "deleteCommandsToolStripMenuItem";
            this.deleteCommandsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteCommandsToolStripMenuItem.Text = "Delete";
            this.deleteCommandsToolStripMenuItem.Click += new System.EventHandler(this.commandsDeleteButton_Click);
            // 
            // pasteCommandsToolStripMenuItem
            // 
            this.pasteCommandsToolStripMenuItem.Enabled = false;
            this.pasteCommandsToolStripMenuItem.Name = "pasteCommandsToolStripMenuItem";
            this.pasteCommandsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pasteCommandsToolStripMenuItem.Text = "Paste";
            this.pasteCommandsToolStripMenuItem.Click += new System.EventHandler(this.commandsPasteButton_Click);
            // 
            // formatDisplayToolStripMenuItem
            // 
            this.formatDisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unsetToolStripMenuItem,
            this.hex8ToolStripMenuItem,
            this.hex16ToolStripMenuItem});
            this.formatDisplayToolStripMenuItem.Name = "formatDisplayToolStripMenuItem";
            this.formatDisplayToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.formatDisplayToolStripMenuItem.Text = "Format Display";
            // 
            // unsetToolStripMenuItem
            // 
            this.unsetToolStripMenuItem.Enabled = false;
            this.unsetToolStripMenuItem.Name = "unsetToolStripMenuItem";
            this.unsetToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.unsetToolStripMenuItem.Text = "Unset";
            this.unsetToolStripMenuItem.Click += new System.EventHandler(this.formatUnsetButton_Click);
            // 
            // hex8ToolStripMenuItem
            // 
            this.hex8ToolStripMenuItem.Enabled = false;
            this.hex8ToolStripMenuItem.Name = "hex8ToolStripMenuItem";
            this.hex8ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hex8ToolStripMenuItem.Text = "8 Hex";
            this.hex8ToolStripMenuItem.Click += new System.EventHandler(this.format8HexButton_Click);
            // 
            // hex16ToolStripMenuItem
            // 
            this.hex16ToolStripMenuItem.Enabled = false;
            this.hex16ToolStripMenuItem.Name = "hex16ToolStripMenuItem";
            this.hex16ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hex16ToolStripMenuItem.Text = "16 Hex";
            this.hex16ToolStripMenuItem.Click += new System.EventHandler(this.format16HexButton_Click);
            // 
            // tutorialFilesToolStripMenuItem
            // 
            this.tutorialFilesToolStripMenuItem.Name = "tutorialFilesToolStripMenuItem";
            this.tutorialFilesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
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
            this.tableLayoutPanel3.Controls.Add(this.commandsBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.commandBlocksBox, 0, 0);
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
            // commandsBox
            // 
            this.commandsBox.BackColor = System.Drawing.Color.Black;
            this.commandsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsBox.ForeColor = System.Drawing.Color.White;
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.ItemHeight = 19;
            this.commandsBox.Location = new System.Drawing.Point(3, 251);
            this.commandsBox.Margin = new System.Windows.Forms.Padding(2);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.ScrollAlwaysVisible = true;
            this.commandsBox.Size = new System.Drawing.Size(397, 127);
            this.commandsBox.TabIndex = 0;
            this.commandsBox.SelectedIndexChanged += new System.EventHandler(this.commandsBox_SelectedIndexChanged);
            this.commandsBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnCommandsBoxMouseMove);
            this.commandsBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CommandsBox_RightMouseClick);
            // 
            // commandBlocksBox
            // 
            this.commandBlocksBox.BackColor = System.Drawing.Color.Black;
            this.commandBlocksBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandBlocksBox.ForeColor = System.Drawing.Color.White;
            this.commandBlocksBox.FormattingEnabled = true;
            this.commandBlocksBox.ItemHeight = 19;
            this.commandBlocksBox.Location = new System.Drawing.Point(3, 3);
            this.commandBlocksBox.Margin = new System.Windows.Forms.Padding(2);
            this.commandBlocksBox.Name = "commandBlocksBox";
            this.commandBlocksBox.ScrollAlwaysVisible = true;
            this.commandBlocksBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.commandBlocksBox.Size = new System.Drawing.Size(397, 243);
            this.commandBlocksBox.TabIndex = 0;
            this.commandBlocksBox.SelectedIndexChanged += new System.EventHandler(this.commandBlocksBox_SelectedIndexChanged);
            this.commandBlocksBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.commandBlocksBoxMouseMove);
            this.commandBlocksBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.commandBlocksBox_RightMouseClick);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.commandsDeleteButton, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.commandsPasteButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.commandsCopyButton, 0, 0);
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
            // commandsDeleteButton
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.commandsDeleteButton, 2);
            this.commandsDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsDeleteButton.Enabled = false;
            this.commandsDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandsDeleteButton.Location = new System.Drawing.Point(2, 86);
            this.commandsDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandsDeleteButton.Name = "commandsDeleteButton";
            this.commandsDeleteButton.Size = new System.Drawing.Size(210, 39);
            this.commandsDeleteButton.TabIndex = 2;
            this.commandsDeleteButton.Text = "delete";
            this.commandsDeleteButton.UseVisualStyleBackColor = true;
            this.commandsDeleteButton.Click += new System.EventHandler(this.commandsDeleteButton_Click);
            // 
            // commandsPasteButton
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.commandsPasteButton, 2);
            this.commandsPasteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsPasteButton.Enabled = false;
            this.commandsPasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandsPasteButton.Location = new System.Drawing.Point(2, 44);
            this.commandsPasteButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandsPasteButton.Name = "commandsPasteButton";
            this.commandsPasteButton.Size = new System.Drawing.Size(210, 38);
            this.commandsPasteButton.TabIndex = 1;
            this.commandsPasteButton.Text = "paste";
            this.commandsPasteButton.UseVisualStyleBackColor = true;
            this.commandsPasteButton.Click += new System.EventHandler(this.commandsPasteButton_Click);
            // 
            // commandsCopyButton
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.commandsCopyButton, 2);
            this.commandsCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsCopyButton.Enabled = false;
            this.commandsCopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandsCopyButton.Location = new System.Drawing.Point(2, 2);
            this.commandsCopyButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandsCopyButton.Name = "commandsCopyButton";
            this.commandsCopyButton.Size = new System.Drawing.Size(210, 38);
            this.commandsCopyButton.TabIndex = 0;
            this.commandsCopyButton.Text = "copy";
            this.commandsCopyButton.UseVisualStyleBackColor = true;
            this.commandsCopyButton.Click += new System.EventHandler(this.commandsCopyButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel2.Controls.Add(this.commandBlockDisableButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.commandBlockDeleteButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.commandBlockPasteButton, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.commandBlockCopyButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.timeTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lengthTextBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(405, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.40329F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.641975F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.34568F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.80659F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.33745F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(214, 243);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // commandBlockDisableButton
            // 
            this.commandBlockDisableButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandBlockDisableButton.Enabled = false;
            this.commandBlockDisableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandBlockDisableButton.Location = new System.Drawing.Point(3, 180);
            this.commandBlockDisableButton.Name = "commandBlockDisableButton";
            this.commandBlockDisableButton.Size = new System.Drawing.Size(99, 60);
            this.commandBlockDisableButton.TabIndex = 0;
            this.commandBlockDisableButton.Text = "Disable";
            this.commandBlockDisableButton.Click += new System.EventHandler(this.disableCommandBlockToolStripMenuItem_Click);
            // 
            // commandBlockDeleteButton
            // 
            this.commandBlockDeleteButton.AutoSize = true;
            this.commandBlockDeleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commandBlockDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandBlockDeleteButton.Enabled = false;
            this.commandBlockDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandBlockDeleteButton.Location = new System.Drawing.Point(107, 179);
            this.commandBlockDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandBlockDeleteButton.Name = "commandBlockDeleteButton";
            this.commandBlockDeleteButton.Size = new System.Drawing.Size(105, 62);
            this.commandBlockDeleteButton.TabIndex = 4;
            this.commandBlockDeleteButton.Text = "Delete";
            this.commandBlockDeleteButton.UseVisualStyleBackColor = true;
            this.commandBlockDeleteButton.Click += new System.EventHandler(this.commandBlockDeleteButton_Click);
            // 
            // commandBlockPasteButton
            // 
            this.commandBlockPasteButton.AutoSize = true;
            this.commandBlockPasteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commandBlockPasteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandBlockPasteButton.Enabled = false;
            this.commandBlockPasteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandBlockPasteButton.Location = new System.Drawing.Point(107, 111);
            this.commandBlockPasteButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandBlockPasteButton.Name = "commandBlockPasteButton";
            this.commandBlockPasteButton.Size = new System.Drawing.Size(105, 64);
            this.commandBlockPasteButton.TabIndex = 3;
            this.commandBlockPasteButton.Text = "Paste";
            this.commandBlockPasteButton.UseVisualStyleBackColor = true;
            this.commandBlockPasteButton.Click += new System.EventHandler(this.commandBlockPasteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "↑ total frames:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commandBlockCopyButton
            // 
            this.commandBlockCopyButton.AutoSize = true;
            this.commandBlockCopyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commandBlockCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandBlockCopyButton.Enabled = false;
            this.commandBlockCopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.commandBlockCopyButton.Location = new System.Drawing.Point(2, 111);
            this.commandBlockCopyButton.Margin = new System.Windows.Forms.Padding(2);
            this.commandBlockCopyButton.Name = "commandBlockCopyButton";
            this.commandBlockCopyButton.Size = new System.Drawing.Size(101, 64);
            this.commandBlockCopyButton.TabIndex = 2;
            this.commandBlockCopyButton.Text = "Copy";
            this.commandBlockCopyButton.UseVisualStyleBackColor = true;
            this.commandBlockCopyButton.Click += new System.EventHandler(this.commandBlockCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "command block frames:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTextBox
            // 
            this.timeTextBox.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.SetColumnSpan(this.timeTextBox, 2);
            this.timeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTextBox.Enabled = false;
            this.timeTextBox.ForeColor = System.Drawing.Color.White;
            this.timeTextBox.Location = new System.Drawing.Point(2, 82);
            this.timeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(210, 26);
            this.timeTextBox.TabIndex = 1;
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.SetColumnSpan(this.lengthTextBox, 2);
            this.lengthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lengthTextBox.Enabled = false;
            this.lengthTextBox.ForeColor = System.Drawing.Color.White;
            this.lengthTextBox.Location = new System.Drawing.Point(2, 28);
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
            // commandBlockContextMenuStrip
            // 
            this.commandBlockContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCommandBlockToolStripMenuItem,
            this.deleteCommandBlockToolStripMenuItem,
            this.disableCommandBlockToolStripMenuItem,
            this.pasteCommandBlockToolStripMenuItem,
            this.toolStripSeparator1,
            this.offSetToolStripMenu,
            this.setCommandBlockFramesToolStripMenuItem});
            this.commandBlockContextMenuStrip.Name = "contextMenuStrip1";
            this.commandBlockContextMenuStrip.Size = new System.Drawing.Size(224, 142);
            // 
            // copyCommandBlockToolStripMenuItem
            // 
            this.copyCommandBlockToolStripMenuItem.Name = "copyCommandBlockToolStripMenuItem";
            this.copyCommandBlockToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.copyCommandBlockToolStripMenuItem.Text = "Copy Command Block";
            this.copyCommandBlockToolStripMenuItem.Click += new System.EventHandler(this.commandBlockCopyButton_Click);
            // 
            // deleteCommandBlockToolStripMenuItem
            // 
            this.deleteCommandBlockToolStripMenuItem.Name = "deleteCommandBlockToolStripMenuItem";
            this.deleteCommandBlockToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.deleteCommandBlockToolStripMenuItem.Text = "Delete Command Block";
            this.deleteCommandBlockToolStripMenuItem.Click += new System.EventHandler(this.commandBlockDeleteButton_Click);
            // 
            // disableCommandBlockToolStripMenuItem
            // 
            this.disableCommandBlockToolStripMenuItem.Name = "disableCommandBlockToolStripMenuItem";
            this.disableCommandBlockToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.disableCommandBlockToolStripMenuItem.Text = "Disable Command Block";
            this.disableCommandBlockToolStripMenuItem.Click += new System.EventHandler(this.disableCommandBlockToolStripMenuItem_Click);
            // 
            // pasteCommandBlockToolStripMenuItem
            // 
            this.pasteCommandBlockToolStripMenuItem.Name = "pasteCommandBlockToolStripMenuItem";
            this.pasteCommandBlockToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.pasteCommandBlockToolStripMenuItem.Text = "Paste Command Block";
            this.pasteCommandBlockToolStripMenuItem.Click += new System.EventHandler(this.commandBlockPasteButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // offSetToolStripMenu
            // 
            this.offSetToolStripMenu.Name = "offSetToolStripMenu";
            this.offSetToolStripMenu.Size = new System.Drawing.Size(223, 22);
            this.offSetToolStripMenu.Text = "Add Frames Offset";
            this.offSetToolStripMenu.Click += new System.EventHandler(this.OffsetToolStripMenu_Click);
            // 
            // setCommandBlockFramesToolStripMenuItem
            // 
            this.setCommandBlockFramesToolStripMenuItem.Name = "setCommandBlockFramesToolStripMenuItem";
            this.setCommandBlockFramesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.setCommandBlockFramesToolStripMenuItem.Text = "Set Command Block Frames";
            this.setCommandBlockFramesToolStripMenuItem.Click += new System.EventHandler(this.SetCommandBlockFramesToolStripMenuItem_Click);
            // 
            // commandContextMenuStrip1
            // 
            this.commandContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCommandToolStripMenuItem,
            this.deleteCommandToolStripMenuItem,
            this.pasteCommandToolStripMenuItem});
            this.commandContextMenuStrip1.Name = "commandContextMenuStrip1";
            this.commandContextMenuStrip1.Size = new System.Drawing.Size(168, 70);
            // 
            // copyCommandToolStripMenuItem
            // 
            this.copyCommandToolStripMenuItem.Name = "copyCommandToolStripMenuItem";
            this.copyCommandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.copyCommandToolStripMenuItem.Text = "Copy Command";
            this.copyCommandToolStripMenuItem.Click += new System.EventHandler(this.commandsCopyButton_Click);
            // 
            // deleteCommandToolStripMenuItem
            // 
            this.deleteCommandToolStripMenuItem.Name = "deleteCommandToolStripMenuItem";
            this.deleteCommandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteCommandToolStripMenuItem.Text = "Delete Command";
            this.deleteCommandToolStripMenuItem.Click += new System.EventHandler(this.commandsDeleteButton_Click);
            // 
            // pasteCommandToolStripMenuItem
            // 
            this.pasteCommandToolStripMenuItem.Name = "pasteCommandToolStripMenuItem";
            this.pasteCommandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.pasteCommandToolStripMenuItem.Text = "Paste Command";
            this.pasteCommandToolStripMenuItem.Click += new System.EventHandler(this.commandsPasteButton_Click);
            // 
            // ACE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 559);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ACE";
            this.Text = "ACE - AnmChrEditor";
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
            this.commandBlockContextMenuStrip.ResumeLayout(false);
            this.commandContextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox commandsBox;
        private System.Windows.Forms.ListBox commandBlocksBox;
        private System.Windows.Forms.Button commandBlockCopyButton;
        private System.Windows.Forms.Button commandBlockPasteButton;
        private System.Windows.Forms.Button commandBlockDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button commandsPasteButton;
        private System.Windows.Forms.Button commandsCopyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Button commandsDeleteButton;
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
        private System.Windows.Forms.ToolStripMenuItem hex8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hex16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialFilesToolStripMenuItem;
        private System.Windows.Forms.Label lblCurrentFile;
        private ContextMenuStrip commandBlockContextMenuStrip;
        private ToolStripMenuItem disableCommandBlockToolStripMenuItem;
        private ToolStripMenuItem copyCommandBlockToolStripMenuItem;
        private ToolStripMenuItem deleteCommandBlockToolStripMenuItem;
        private ToolStripMenuItem pasteCommandBlockToolStripMenuItem;
        private ContextMenuStrip commandContextMenuStrip1;
        private ToolStripMenuItem copyCommandToolStripMenuItem;
        private ToolStripMenuItem deleteCommandToolStripMenuItem;
        private ToolStripMenuItem pasteCommandToolStripMenuItem;
        private Button commandBlockDisableButton;
        private ToolStripMenuItem commandBlockToolStripMenuItem;
        private ToolStripMenuItem copyCommandBlockToolStripMenuItem1;
        private ToolStripMenuItem deleteCommandBlockToolStripMenuItem1;
        private ToolStripMenuItem disableCommandBlockToolStripMenuItem1;
        private ToolStripMenuItem pasteCommandBlockToolStripMenuItem1;
        private ToolStripMenuItem commandsToolStripMenuItem;
        private ToolStripMenuItem copyCommandsToolStripMenuItem;
        private ToolStripMenuItem deleteCommandsToolStripMenuItem;
        private ToolStripMenuItem pasteCommandsToolStripMenuItem;
        private ToolStripMenuItem offSetToolStripMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem setCommandBlockFramesToolStripMenuItem;
    }

}

