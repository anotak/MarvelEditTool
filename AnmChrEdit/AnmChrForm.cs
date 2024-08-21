using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using MarvelData;
using static System.Windows.Forms.LinkLabel;
using Microsoft.VisualBasic;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace AnmChrEdit
{
    public partial class ACE : Form
    {
        public static bool bError = false;
        public string filePath;
        public string ImportPath;
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;
        public bool bDisableSubUpdate;
        public bool bDisableSubSubUpdate;
        public bool isMultiSelection;
        public AnmChrSubEntry commandBlockCopyInstance;
        public CmdSpAtkEntry spatkCopyInstance = new CmdSpAtkEntry();
        public byte[] commandCopyInstance;
        
        public List<List<int>> selectedSubSubIndices;
        public List<int> selectedSubIndices;

        public BindingList<string> subDataSource;
        public BindingList<string> subsubDataSource;
        private int subEntryHoveredIndex = -1;
        private int dataTextBoxFormat;
        private ImageForm imageForm;
        private bool isChecked;
        private bool isBreak;
        public bool isDeleting = false;
        public int reselectID = -1;

        public ACE()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            //AELogger.Log(Text);
            filePath = String.Empty;
            ImportPath = String.Empty;
            selectedSubIndices = new List<int>();
            selectedSubSubIndices = new List<List<int>>();
            AnmChrSubEntry.InitCmdNames();
            commandBlocksBox.DrawItem += commandBlocksBox_DrawItem;
            commandBlocksBox.DrawMode = DrawMode.OwnerDrawFixed;
            
    }

        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString("MMM.dd.yyyy");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (bError) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?" + Environment.NewLine + "All unsaved data will be lost!", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    AELogger.WriteLog();
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (saveAsToolStripMenuItem.Enabled || saveToolStripMenuItem.Enabled)
                {
                    saveButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                if (openToolStripMenuItem.Enabled)
                {
                    openButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.T))
            {
                if (extendButton.Enabled)
                {
                    extendButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                if (exportButton.Enabled)
                {
                    exportButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.R))
            {
                if (importButton.Enabled)
                {
                    importButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad0) || keyData == (Keys.Control | Keys.D0))
            {
                if (formatUnsetButton.Enabled)
                {
                    formatUnsetButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad1) || keyData == (Keys.Control | Keys.D1))
            {
                if (format8HexButton.Enabled)
                {
                    format8HexButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad2) || keyData == (Keys.Control | Keys.D2))
            {
                if (format16HexButton.Enabled)
                {
                    format16HexButton_Click(null, null);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshData()
        {
            bDisableUpdate = true;
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            tableNames = tablefile.GetNames();
            animBox.DataSource = tableNames;
            if (s >= animBox.Items.Count)
            {
                s = animBox.Items.Count -1;
            }
            animBox.SelectedIndex = s;
            animBox.TopIndex = top;
            bDisableUpdate = false;
        }

        public void SaveSelectedIndices()
        {
            //AELogger.Log("HAHA");
            int s = animBox.SelectedIndex;
            for (int i = selectedSubIndices.Count; i <= s; i++)
            {
                //AELogger.Log("a" + i);
                selectedSubIndices.Add(-1);
            }

            int subS = commandBlocksBox.SelectedIndex;
            selectedSubIndices[s] = subS;
            
            for (int i = selectedSubSubIndices.Count; i <= s; i++)
            {
                //AELogger.Log("b" + i);
                selectedSubSubIndices.Add(new List<int>());
            }

            for (int i = selectedSubSubIndices[s].Count; i <= subS; i++)
            {
                //AELogger.Log("c" + i);
                selectedSubSubIndices[s].Add(-1);
            }

            selectedSubSubIndices[s][subS] = commandsBox.SelectedIndex;
        }

        public void RefreshSelectedIndices()
        {
            int s = animBox.SelectedIndex;

            if (!tablefile.table[s].bHasData || commandBlocksBox.Items.Count == 0)
            {
                EmptyCommandsTextBox();
                return;
            }

            if (!bDisableSubUpdate && selectedSubIndices.Count > s)
            {
                int selectedSub = selectedSubIndices[s];
                if (selectedSub >= 0 && selectedSub < commandBlocksBox.Items.Count)
                {
                    commandBlocksBox.SelectedIndex = selectedSub;
                    
                    // un-selects top-most multi select entry if relevant
                    if (commandBlocksBox.SelectedItems.Count > 1)
                    {
                        commandBlocksBox.SelectedItems.Remove(commandBlocksBox.SelectedItems[0]);
                    }
                }
                else if (selectedSub >= 0 && selectedSub <= commandBlocksBox.Items.Count)
                {
                    commandBlocksBox.SelectedIndex = selectedSub -1;

                    // un-selects top-most multi select entry if relevant
                    if (commandBlocksBox.SelectedItems.Count > 1)
                    {
                        commandBlocksBox.SelectedItems.Remove(commandBlocksBox.SelectedItems[0]);
                    }
                }
            }

            if (selectedSubSubIndices.Count > s)
            {
                int subS = commandBlocksBox.SelectedIndex;
                List<int> selectedList = selectedSubSubIndices[s];
                if (selectedList.Count > subS && subS >= 0)
                {
                    int selectedSub = selectedList[subS];

                    if (selectedSub >= 0 && selectedSub < commandsBox.Items.Count)
                    {
                        commandsBox.SelectedIndex = selectedSub;
                    }
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (bError)
            {
                return;
            }

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (tablefile != null)
                {
                    // Confirm user wants to open a new instance
                    switch (MessageBox.Show(this, "Are you sure you want to open a new instance?" 
                        + Environment.NewLine + "All unsaved data will be lost!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            AELogger.Log("procedure canceled!");
                            return;
                        default:
                            Text = "AnmChrEditor, build " + GetCompileDate();
                            filenameLabel.Text = String.Empty;
                            dataTextBox.Clear();
                            filePath = String.Empty;
                            SetDataTexBoxFormat(0);
                            AELogger.WriteLog();
                            break;
                    }
                }
                //openFile.DefaultExt = "bcm";
                // The Filter property requires a search string after the pipe ( | )
                openFile.Filter = "AnmChr Files (*.cac;*.5A7E5D8A; *.anm)|*.cac;*.5A7E5D8A;*.anm|All files (*.*)|*.*";
                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    //TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], true, typeof(StructEntry<ATKInfoChunk>), 848, true);
                    TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], false, typeof(AnmChrEntry), -1, true);
                    int count = newTable.table.Count;
                    if (newTable == null && count != 0)
                    {
                        AELogger.Log("load failed for some reason?");
                        return;
                    }

                    tablefile = newTable;
                    filePath = openFile.FileNames[0];
#if DEBUG
                    tablefile.AnalyzeAnmChr();
#endif
                    // start naming missing labels
                    List<AnmChrSubEntry> subEntries = new List<AnmChrSubEntry>();
                    tablefile.GetSubSubEntryInfo(ref subEntries);
                    tablefile.MatchAtiNames(filePath);
                    // end naming missing labels


                    SuspendLayout();
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                    importButton.Enabled = false;
                    exportButton.Enabled = false;
                    animBox.Enabled = true;
                    extendButton.Enabled = true;
                    formatUnsetButton.Enabled = false;
                    format8HexButton.Enabled = true;
                    format16HexButton.Enabled = true;
                    unsetToolStripMenuItem.Enabled = true;
                    hex8ToolStripMenuItem.Enabled = true;
                    hex16ToolStripMenuItem.Enabled = true;


                    sizeLabel.Text = count + " entries loaded";
                    RefreshData();

                    for (int i = 0; i < animBox.Items.Count; i++)
                    {
                        selectedSubSubIndices.Add(new List<int>());
                    }

                    //Text += " :: " + openFile.FileNames[0];
                    
                    filenameLabel.Text = openFile.FileNames[0];
                    animBox.SelectedIndex = 0;
                    ResumeLayout();
                    animBox_SelectedIndexChanged(null, null);
                }
                else
                {
                    AELogger.Log("nothing selected!");
                }
            }
        }


        private void saveButton_Click(object sender, EventArgs ev)
        {
            if (bError)
            {
                return;
            }

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                //saveFileDialog1.Filter = "BCM files (*.bcm)|*.bcm|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                if (filePath != String.Empty)
                {
                    try
                    {
                        saveFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);
                        saveFileDialog1.FileName = Path.GetFileName(filePath);
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("some kind of exception setting save path from " + filePath);
                        AELogger.Log("Exception: " + e.Message);

                        AELogger.Log("Exception: " + e.StackTrace);

                        int i = 1;
                        while (e.InnerException != null)
                        {
                            e = e.InnerException;
                            AELogger.Log("InnerException " + i + ": " + e.Message);

                            AELogger.Log("InnerException " + i + ": " + e.StackTrace);
                            i++;
                        }
                    }
                }
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileNames.Length > 0)
                    {
                        filePath = saveFileDialog1.FileNames[0];
                        tablefile.WriteFile(saveFileDialog1.FileNames[0]);
                    }
                }
            }

        }

        private void closeButton_Click(object sender, EventArgs ev)
        {
            Application.Exit();
        }

        private void importButton_Click(object sender, EventArgs ev)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count)
            {
                return;
            }

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.DefaultExt = "mvc3anm";
                if (ImportPath != String.Empty)
                {
                    try
                    {
                        openFile.InitialDirectory = Path.GetDirectoryName(filePath);
                        openFile.FileName = Path.GetFileName(filePath);
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("some kind of exception setting save path from " + filePath);
                        AELogger.Log("Exception: " + e.Message);

                        AELogger.Log("Exception: " + e.StackTrace);

                        int i = 1;
                        while (e.InnerException != null)
                        {
                            e = e.InnerException;
                            AELogger.Log("InnerException " + i + ": " + e.Message);

                            AELogger.Log("InnerException " + i + ": " + e.StackTrace);
                            i++;
                        }
                    }
                }
                openFile.Title = "Import " + tablefile.table[animBox.SelectedIndex].GetFancyName();
                // The Filter property requires a search string after the pipe ( | )
                openFile.Filter = "UMVC3 Anmchr Entry (*.mvc3anm)|*.mvc3anm|UMVC3 Loose Data (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";

                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    tablefile.table[animBox.SelectedIndex].Import(openFile.FileNames[0]);
                    RefreshData();
                    bDisableUpdate = true;
                    RefreshEditBox();
                    bDisableUpdate = false;
                    sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;
                    ImportPath = openFile.FileNames[0];
                }
                else
                {
                    AELogger.Log("nothing selected!");
                }
            }
        }
        
        private void exportButton_Click(object sender, EventArgs ev)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count)
            {
                return;
            }

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {

                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                saveFileDialog1.Title = "Export " + tablefile.table[animBox.SelectedIndex].GetFancyName();
                if (tablefile.fileExtension == "CAC")
                {
                  saveFileDialog1.Filter = "All files (*.*)|*.*|UMVC3 Loose Data (*.mvc3data)|*.mvc3data|UMVC3 Character Script File (*.mvc3anm;*.mvc3data)|*.mvc3anm;*.mvc3data";
                }
                else
                {
                    saveFileDialog1.Filter = "All files (*.*)|*.*|UMVC3 Loose Data(*.mvc3data)|*.mvc3data";
                }

                if (filePath != String.Empty)
                {
                    try
                    {
                        saveFileDialog1.InitialDirectory = Path.GetDirectoryName(ImportPath);
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("some kind of exception setting save path from " + ImportPath);
                        AELogger.Log("Exception: " + e.Message);

                        AELogger.Log("Exception: " + e.StackTrace);

                        int i = 1;
                        while (e.InnerException != null)
                        {
                            e = e.InnerException;
                            AELogger.Log("InnerException " + i + ": " + e.Message);

                            AELogger.Log("InnerException " + i + ": " + e.StackTrace);
                            i++;
                        }
                    }
                }
                saveFileDialog1.FilterIndex = 3;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = rgx.Replace(tablefile.table[animBox.SelectedIndex].GetFilename(), "");
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileNames.Length > 0)
                    {
                        ImportPath = saveFileDialog1.FileNames[0];
                        tablefile.table[animBox.SelectedIndex].Export(saveFileDialog1.FileNames[0]);
                    }
                }
            }
        }

        private void extendButton_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Do you want to extend list?" + Environment.NewLine + "This action cannot be undone!", "Extend List", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    break;
                default:
                    tablefile.Extend();
                    
                    RefreshData();
                    if (animBox.TopIndex < animBox.Items.Count - 2)
                    {
                        animBox.TopIndex++;
                    }
                    break;
            }
        }

        private void formatUnsetButton_Click(object sender, EventArgs e)
        {
            SetDataTexBoxFormat(0);
            formatUnsetButton.Enabled = false;
            format8HexButton.Enabled = true;
            format16HexButton.Enabled = true;
            RefreshText();
            RefreshData();
        }

        private void format8HexButton_Click(object sender, EventArgs e)
        {
            SetDataTexBoxFormat(8);
            formatUnsetButton.Enabled = true;
            format8HexButton.Enabled = false;
            format16HexButton.Enabled = true;
            RefreshText();
            RefreshData();
        }

        private void format16HexButton_Click(object sender, EventArgs e)
        {
            SetDataTexBoxFormat(16);
            formatUnsetButton.Enabled = true;
            format8HexButton.Enabled = true;
            format16HexButton.Enabled = false;
            RefreshText();
            RefreshData();
        }

        private void testImgButton_Click(object sender, EventArgs e)
        {
            imageForm = new ImageForm();
            imageForm.Show();
        }

        private void animBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableUpdate)
            {
                return;
            }
            //SuspendLayout();
            animBox.BeginUpdate();
            AELogger.Log("selected animbox " + animBox.SelectedIndex);
            bDisableUpdate = true;
            importButton.Enabled = true;
            RefreshEditBox();
            RefreshSelectedIndices();
            //sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;
            subEntryHoveredIndex = -1;
            bDisableUpdate = false;
            animBox.EndUpdate();
            //ResumeLayout();
        }

        public void RefreshEditBox() // disableupdate is true here
        {
            if (!bDisableUpdate)
            {
                AELogger.Log("ENABLED WHILE REFRESHEDITBOX WARNING");
                return;
            }
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            //subEntryBox.BeginUpdate();
            if (tablefile.table[s].bHasData && tablefile.table[s] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];
                dataTextBox.Enabled = true;
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource;
                // total time elements
                lengthTextBox.Enabled = true;
                lengthTextBox.Text = entry.animTime.ToString();
                exportButton.Enabled = true;
                // commandBlocks button>menuOptions>contextMenu
                commandBlockCopyButton.Enabled = true;
                copyCommandBlockToolStripMenuItem1.Enabled = true;
                copyCommandBlockToolStripMenuItem.Enabled = true;
                commandBlockPasteButton.Enabled = commandBlockCopyInstance != null;
                pasteCommandBlockToolStripMenuItem1.Enabled = commandBlockCopyInstance != null && !isMultiSelection; ;
                pasteCommandBlockToolStripMenuItem.Enabled = commandBlockCopyInstance != null && !isMultiSelection; ;
                // commands button>menuOptions>contextMenu
                commandsCopyButton.Enabled = true;
                copyCommandsToolStripMenuItem.Enabled = true;
                copyCommandToolStripMenuItem.Enabled = true;
                commandsPasteButton.Enabled = commandCopyInstance != null;
                pasteCommandsToolStripMenuItem.Enabled = commandCopyInstance != null && !isMultiSelection; ;
                pasteCommandToolStripMenuItem.Enabled = commandCopyInstance != null && !isMultiSelection; ;
                validateDeleteButtons(entry);
            }
            else
            {
                //subsubEntryBox.BeginUpdate();
                dataTextBox.Enabled = false;
                dataTextBox.Clear();
                exportButton.Enabled = false;
                // total time elements
                lengthTextBox.Enabled = false;
                lengthTextBox.Clear();
                // commandBlocks button>menuOptions>contextMenu
                commandBlocksBox.DataSource = null;
                commandBlocksBox.Items.Clear();
                commandBlockDeleteButton.Enabled = false;
                commandBlockDisableButton.Enabled = false;
                commandBlockCopyButton.Enabled = false;
                copyCommandBlockToolStripMenuItem1.Enabled = false;
                copyCommandBlockToolStripMenuItem.Enabled = false;
                commandBlockPasteButton.Enabled = commandBlockCopyInstance != null;
                pasteCommandBlockToolStripMenuItem1.Enabled = commandBlockCopyInstance != null;
                pasteCommandBlockToolStripMenuItem.Enabled = commandBlockCopyInstance != null;
                // commands button>menuOptions>contextMenu
                commandsBox.Items.Clear();
                commandsBox.DataSource = null;
                commandsDeleteButton.Enabled = false;
                commandsCopyButton.Enabled = false;
                copyCommandsToolStripMenuItem.Enabled = false;
                copyCommandToolStripMenuItem.Enabled = false;
                commandsPasteButton.Enabled = commandCopyInstance != null;
                pasteCommandsToolStripMenuItem.Enabled = commandCopyInstance != null;
                pasteCommandToolStripMenuItem.Enabled = commandCopyInstance != null;
                //subsubEntryBox.EndUpdate();
            }
            //subEntryBox.EndUpdate();
        }

        private void commandBlocksBox_RightMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var commandBlockIndex = commandBlocksBox.IndexFromPoint(e.Location);
                if (commandBlockIndex >= 0)
                {
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.None)
                    {
                        commandBlocksBox.ClearSelected();
                    }
                    commandBlocksBox.SelectedIndex = commandBlockIndex;
                    //subEntryBox.Controls.;
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    commandBlockContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void commandBlocksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableSubUpdate)
            {
                return;
            }

            bDisableSubUpdate = true;
            if (commandBlocksBox.SelectedItems.Count > 1 && isDeleting)
            {
                commandBlocksBox.SelectedItems.Remove(commandBlocksBox.SelectedItems[0]);
            } //multiselect fix
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            if (tablefile.table[s] is AnmChrEntry && (tablefile.table[s].bHasData && tablefile.table[s].size > 0))
            {
                if (commandBlocksBox.SelectedIndices.Count == 1)
                {
                    isMultiSelection = false;
                    AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                    if (commandBlocksBox.SelectedIndex >= entry.subEntries.Count)
                    {
                        commandsBox.SelectedIndex = entry.subEntries.Count - 1;
                    }

                    if (bDisableSubSubUpdate)
                    {
                        subsubDataSource = entry.subEntries[commandBlocksBox.SelectedIndex].GetCommandList();
                        commandsBox.DataSource = subsubDataSource;
                    }
                    else
                    {
                        bDisableSubSubUpdate = true;
                        subsubDataSource = entry.subEntries[commandBlocksBox.SelectedIndex].GetCommandList();
                        commandsBox.DataSource = subsubDataSource;
                        bDisableSubSubUpdate = false;
                    }
                    if (bDisableUpdate)
                    {
                        RefreshSelectedIndices();
                    }
                    else
                    {
                        SaveSelectedIndices();
                    }
                    RefreshText();
                    timeTextBox.Text = entry.subEntries[commandBlocksBox.SelectedIndex].isDisabled ? "" : 
                    entry.subEntries[commandBlocksBox.SelectedIndex].tableindex.ToString();
                    timeTextBox.Enabled = true;
                    validateDeleteButtons(entry);
                } else if (commandBlocksBox.SelectedIndices.Count > 1)
                {
                    isMultiSelection = true;
                    EmptyCommandsTextBox();
                    validateDeleteButtons(null);
                }
                else
                {
                    isMultiSelection = false;
                    EmptyCommandsTextBox();
                    validateDeleteButtons(null);
                }
            }
            else
            {
                EmptyCommandsTextBox();
            }

            bDisableSubUpdate = false;
            //subsubEntryBox.EndUpdate();
            //ResumeLayout();
        }

        private void EmptyCommandsTextBox()
        {
            timeTextBox.Enabled = false;
            commandsBox.DataSource = null;
            commandsBox.Items.Clear();
        }

        // Sets the given # frames to the selected command block(s)
        private void SetCommandBlockFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputframes = Interaction.InputBox("Set #Frames", "Command Block number of frames", "");
            int frames;

            if (int.TryParse(inputframes, out frames))
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                isChecked = false;
                isBreak = false;
                foreach (var index in commandBlocksBox.SelectedIndices)
                {
                    if (CheckNewFrameValue(entry, frames) && !isBreak)
                    {
                        entry.subEntries[(int)index].localindex = frames < 0 ? -1 : frames > entry.animTime ? entry.animTime : frames;
                        entry.subEntries[(int)index].tableindex = entry.subEntries[(int)index].localindex;
                    }
                }
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource; ;
            }
            else if (!String.IsNullOrEmpty(inputframes))
            {
                MessageBox.Show(this, "Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Adds the given offset to the frames of the selected command block(s)
        private void OffsetToolStripMenu_Click(object sender, EventArgs e)
        {
            var inputOffset = Interaction.InputBox("Set offset", "Command Block Offset", "");
            int offset;

            if (int.TryParse(inputOffset, out offset))
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                isChecked = false;
                isBreak = false;
                foreach (var index in commandBlocksBox.SelectedIndices)
                {
                    if (CheckNewFrameValue(entry, entry.subEntries[(int)index].localindex + offset) && !isBreak)
                    {
                        /*entry.subEntries[(int)index].localindex =
                            entry.subEntries[(int)index].localindex + offset < 0 ? -1 :
                            entry.subEntries[(int)index].localindex + offset > entry.animTime ? entry.animTime :
                            entry.subEntries[(int)index].localindex + offset;*/
                        entry.subEntries[(int)index].localindex = entry.subEntries[(int)index].localindex + offset;
                        entry.subEntries[(int)index].tableindex = entry.subEntries[(int)index].localindex;
                    }
                }
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource; ;
            }
            else if (!String.IsNullOrEmpty(inputOffset))
            {
                MessageBox.Show(this, "Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Verifies new frame value giving a warning when it reaches negative values or the max frames
        private bool CheckNewFrameValue(AnmChrEntry entry, int newValue)
        {
            if ((newValue >= entry.animTime || newValue < 0) && !isChecked) 
            {
                switch (MessageBox.Show(this, "One or more of your new values will reach or exceed the " +
                    (newValue < 0 ? "minimum " : newValue > entry.animTime ? "maximum " : "minimum/maximum ") + "threshold. These values may not be read properly."
                    + Environment.NewLine + "Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                        isChecked = true;
                        isBreak = true;
                        return false;
                    default:
                        isChecked = true;
                        isBreak = false;
                        return true;
                }
            }
            return true;
        }

        private void CommandsBox_RightMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var commandIndex = commandsBox.IndexFromPoint(e.Location);
                if (commandIndex >= 0)
                {
                    commandsBox.SelectedIndex = commandIndex;
                    //subEntryBox.Controls.;
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    commandContextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void commandsBox_SelectedIndexChanged(object sender, EventArgs ev)
        {
            if (bDisableSubSubUpdate)
            {
                return;
            }

            AELogger.Log("selected subsub box " + commandsBox.SelectedIndex);

            bDisableSubSubUpdate = true;
            int s = animBox.SelectedIndex;
            if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                if (commandBlocksBox.SelectedIndex >= entry.subEntries.Count && commandBlocksBox.SelectedIndex >= 0)
                {
                    AELogger.Log("possible big error");

                    RefreshText();
                }
                else if (entry.subEntries.Count > 0 && commandBlocksBox.SelectedIndex > 0)
                {
                    if (commandsBox.SelectedIndex >= entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries.Count)
                    {
                        commandsBox.SelectedIndex = entry.subEntries.Count - 1;
                    }

                    RefreshText();

                    SaveSelectedIndices();
                }
                else
                {
                    RefreshText();
                }
            }
            bDisableSubSubUpdate = false;
        }

        private void RefreshText()
        {
            int s = animBox.SelectedIndex;
            if (tablefile.table[s] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                if (commandBlocksBox.SelectedIndex >= entry.subEntries.Count || commandBlocksBox.SelectedIndex < 0)
                {
                    dataTextBox.Enabled = false;
                    AELogger.Log("weird otherwise probably nonharmful data index error A");
                    dataTextBox.Text = "no data selected?";
                    return;
                }
                if (commandsBox.SelectedIndex >= entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries.Count || commandsBox.SelectedIndex < 0)
                {
                    AELogger.Log("weird otherwise probably nonharmful data index error B");
                    dataTextBox.Enabled = false;
                    dataTextBox.Text = "no data selected?";
                    return;
                }
                byte[] data = entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries[commandsBox.SelectedIndex];
                dataTextBox.Enabled = true;
                dataTextBox.Text = BitConverter.ToString(data).Replace("-", "");
                dataTextBox.Text = splitAndBreakEveryNChars(dataTextBox.Text, GetDataTextBoxFormat());
                dataTextBox.ForeColor = Color.White;
            }
            else
            {
                dataTextBox.Enabled = false;
                dataTextBox.Clear();
            }
        }

        private string splitAndBreakEveryNChars(string text2Break, int breakAfterNChars)
        {
            if (breakAfterNChars <= 0)
            {
                return (text2Break);
            }

            return (String.Join("\r\n", text2Break.SplitInParts(breakAfterNChars)));
        }

        public static byte[] StringToByteArray(string input)
        {
            input = input.Replace("  ", "");
            input = input.Replace(" ", "");
            int length = input.Length / 2;
            byte[] outBytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                outBytes[i] = Convert.ToByte(input.Substring(i * 2, 2), 16); // base 16
            }
            return outBytes;
        }

        // Validates the contents of the hex in data text box
        private void dataTextBox_TextChanged(object sender, EventArgs ev)
        {
            if (bDisableUpdate || bDisableSubUpdate || bDisableSubSubUpdate)
            {
                return;
            }
            int s = animBox.SelectedIndex;
            if (dataTextBox.Text.Length % 2 == 1)
            {
                dataTextBox.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
                    {
                        
                        AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                        entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries[commandsBox.SelectedIndex] 
                            = StringToByteArray(dataTextBox.Text.Replace("\r\n", ""));

                        bDisableSubSubUpdate = true;
                        subsubDataSource[commandsBox.SelectedIndex] = entry.subEntries[commandBlocksBox.SelectedIndex]
                            .GetSubSubName(commandsBox.SelectedIndex);
                        bDisableSubSubUpdate = false;
                    }
                    dataTextBox.ForeColor = Color.White;
                }
                catch(Exception e)
                {
                    AELogger.Log("Exception: " + e.Message);

                    AELogger.Log("Exception: " + e.StackTrace);

                    int i = 1;
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                        AELogger.Log("InnerException " + i + ": " + e.Message);

                        AELogger.Log("InnerException " + i + ": " + e.StackTrace);
                        i++;
                    }
                    dataTextBox.ForeColor = Color.Red;
                }
            }
        }

        // Creates labels for the sub entries box
        private void commandBlocksBoxMouseMove(object sender, MouseEventArgs e)
        {
            // if still on the same row, do nothing
            if (!commandBlocksBox.IndexFromPoint(e.Location).Equals(subEntryHoveredIndex))
            {
                string strTip = "";
                int nIdx = commandBlocksBox.IndexFromPoint(e.Location);
                if ((nIdx >= 0) && (nIdx < commandBlocksBox.Items.Count))
                {
                    subEntryHoveredIndex = nIdx;
                    strTip = commandBlocksBox.Items[nIdx].ToString();
                    if (tablefile != null && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
                    {
                        AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                        if (entry.subEntries.Count > 0)
                        {
                        entry.subEntries[nIdx].GetCommandList().ToList().ForEach(n => strTip += " \r\n  " + n.ToString());
                        }
                    }
                }
                toolTip1.SetToolTip(commandBlocksBox, strTip);
            }
        }

        // Creates labels for the sub sub entries box
        private void OnCommandsBoxMouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = commandsBox.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < commandsBox.Items.Count))
                strTip = commandsBox.Items[nIdx].ToString();

            toolTip2.SetToolTip(commandsBox, strTip);
        }

        // Creates labels for the entries (anim) box
        private void OnAnimBoxMouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = animBox.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < animBox.Items.Count))
                strTip = animBox.Items[nIdx].ToString();

            toolTip3.SetToolTip(animBox, strTip);
        }

        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!bDisableUpdate && !bDisableSubUpdate && !bDisableSubSubUpdate
                && tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                try
                {
                    int newTime = int.Parse(timeTextBox.Text);
                    //if (newTime > entry.animTime)
                    //{
                    //    throw new OutOfTimeException();
                    //}
                    entry.subEntries[commandBlocksBox.SelectedIndex].isDisabled = false;
                    entry.subEntries[commandBlocksBox.SelectedIndex].isEdited = true;
                    entry.subEntries[commandBlocksBox.SelectedIndex].tableindex = newTime;
                    entry.subEntries[commandBlocksBox.SelectedIndex].localindex = newTime;
                    /*if (newTime > entry.animTime)
                    {
                        timeTextBox.ForeColor = Color.Gray;
                    }
                    else
                    {*/
                        timeTextBox.ForeColor = Color.White;
                    //}
                    lengthTextBox.ForeColor = Color.White;
                    bDisableSubSubUpdate = true;
                    bDisableSubUpdate = true;
                    int s = commandBlocksBox.SelectedIndex;
                    subDataSource = entry.getSubEntryList();
                    commandBlocksBox.DataSource = subDataSource;
                    bool bDontSelect = true;
                    for (int i = 0; i < entry.subEntries.Count; i++)
                    {
                        if (entry.subEntries[i].isEdited)
                        {
                            entry.subEntries[i].isEdited = false;
                            commandBlocksBox.ClearSelected();
                            commandBlocksBox.SelectedIndex = i;
                            bDontSelect = false;
                            break;
                        }
                    }

                    if (bDontSelect)
                    {
                        commandBlocksBox.SelectedIndex = s;
                    }

                    bDisableSubUpdate = false;
                    bDisableSubSubUpdate = false;
                }
                catch (OutOfTimeException err)
                {
                    lengthTextBox.ForeColor = Color.Red;
                    timeTextBox.ForeColor = Color.Red;
                }
                catch
                {
                    timeTextBox.ForeColor = Color.Red;
                }
            }
            else {
                lengthTextBox.ForeColor = Color.White;
                timeTextBox.ForeColor = Color.White;
            }
        }

        private void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!bDisableUpdate && !bDisableSubUpdate && !bDisableSubSubUpdate
                && tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                try
                {
                    int newTime = int.Parse(lengthTextBox.Text);
                    entry.animTime = newTime;
                    lengthTextBox.Text = lengthTextBox.Text;
                    lengthTextBox.ForeColor = Color.White;
                }
                catch
                {
                    lengthTextBox.ForeColor = Color.Red;
                }
            }
            else
            {
                lengthTextBox.ForeColor = Color.White;
            }
        }

        private void commandBlockCopyButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AELogger.Log("copying sub " + animBox.SelectedIndex + "." + commandBlocksBox.SelectedIndex);
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];


                commandBlockCopyInstance = entry.subEntries[commandBlocksBox.SelectedIndex].Copy();
                
                commandBlockPasteButton.Enabled = true;
                pasteCommandBlockToolStripMenuItem1.Enabled = true;
                pasteCommandBlockToolStripMenuItem.Enabled = true;
            }
        }

        private void commandBlockPasteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry
                && commandBlockCopyInstance != null)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("pasting sub to " + animBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;
                
                entry.subEntries.Add(commandBlockCopyInstance.Copy());
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource;

                timeTextBox.Enabled = true;
                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;

                for (int i = 0; i < entry.subEntries.Count; i++)
                {
                    if (entry.subEntries[i].isEdited)
                    {
                        entry.subEntries[i].isEdited = false;
                        commandBlocksBox.SelectedIndex = i;
                        break;
                    }
                }
                if (commandBlocksBox.SelectedItems.Count > 1) // catches multi select after pasting a time
                {
                    commandBlocksBox.SelectedItems.Remove(commandBlocksBox.SelectedItems[0]);
                }
                commandBlocksBox_SelectedIndexChanged(null, null);
            }
        }

        private void commandsCopyButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("copying subsub " + animBox.SelectedIndex + "." + commandBlocksBox.SelectedIndex + "." + commandsBox.SelectedIndex);
                byte[] source = entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries[commandsBox.SelectedIndex];
                commandCopyInstance = new byte[source.Length];
                source.CopyTo(commandCopyInstance, 0);

                commandsPasteButton.Enabled = true;
                pasteCommandsToolStripMenuItem.Enabled = true;
                pasteCommandToolStripMenuItem.Enabled = true;
            }
        }

        private void commandsPasteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry
                && commandCopyInstance != null)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("pasting subsub to " + animBox.SelectedIndex + "." + commandsBox.SelectedIndex);
                byte[] dest = new byte[commandCopyInstance.Length];
                commandCopyInstance.CopyTo(dest, 0);
                entry.subEntries[commandBlocksBox.SelectedIndex].subsubEntries.Add(dest);
                entry.subEntries[commandBlocksBox.SelectedIndex].subsubPointers.Add(uint.MaxValue);
                entry.subEntries[commandBlocksBox.SelectedIndex].subsubIndices.Add(0);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;
                commandsBox.DataSource = null;
                subsubDataSource = entry.subEntries[commandBlocksBox.SelectedIndex].GetCommandList();
                commandsBox.DataSource = subsubDataSource;

                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;
                commandsBox.SelectedIndex = commandsBox.Items.Count-1;
            }
        }

        private void commandBlockDeleteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AnmChrSubEntry commandBlockEntry = entry.subEntries[commandBlocksBox.SelectedIndex];

                if (MessageBox.Show(this, "Deleting command block with " + commandBlockEntry.subsubPointers.Count 
                    + " commands and " + (commandBlockEntry.isDisabled ? "that is disabled" : 
                    ("with timestamp " + commandBlockEntry.localindex.ToString())) + ". Are you sure?" 
                    + Environment.NewLine + "This action is irreversible." + Environment.NewLine, "PERMANENT DELETION", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                AELogger.Log("deleting sub " + animBox.SelectedIndex + "." + commandBlocksBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;
                isDeleting = true;
                reselectID = commandBlocksBox.SelectedIndex;
                entry.subEntries.RemoveAt(commandBlocksBox.SelectedIndex);
                commandsBox.DataSource = null; //empties command list
                subDataSource = entry.getSubEntryList(); //grabs subchunk list
                commandBlocksBox.DataSource = subDataSource; //applies new subchunk list
                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;
                if (subDataSource.Count > 0)
                {
                    commandBlocksBox.SelectedIndex = 0;
                    RefreshSelectedIndices();
                    subsubDataSource = commandBlockEntry.GetCommandList();
                    if (reselectID == 0 && commandBlocksBox.Items.Count > 0)
                    {
                        commandBlocksBox_SelectedIndexChanged(null, null);
                    }
                    //commandsBox.DataSource = subsubDataSource; //this caused the commands to be reloaded improperly? need to reload the subchunk
                    //if (commandsBox.SelectedIndex < 0)
                    //{
                    //    commandsBox.SelectedIndex = 0;
                    //}
                }
                else
                {
                    AELogger.Log("odd issue ???????");
                    dataTextBox.Enabled = false;
                }

                
                isDeleting = false;
                validateDeleteButtons(entry);
            }
        }

        private void disableCommandBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bDisableUpdate && !bDisableSubUpdate && !bDisableSubSubUpdate 
    && tablefile.table[animBox.SelectedIndex].bHasData
    && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];

                int newTime = 21012;
                entry.subEntries[commandBlocksBox.SelectedIndex].isEdited = true;
                entry.subEntries[commandBlocksBox.SelectedIndex].isDisabled = true;
                entry.subEntries[commandBlocksBox.SelectedIndex].tableindex = entry.subEntries[commandBlocksBox.SelectedIndex].tableindex + newTime;
                entry.subEntries[commandBlocksBox.SelectedIndex].localindex = entry.subEntries[commandBlocksBox.SelectedIndex].localindex + newTime;
                timeTextBox.Clear();

                bDisableSubSubUpdate = true;
                bDisableSubUpdate = true;
                int s = commandBlocksBox.SelectedIndex;
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource;
                bool bDontSelect = true;
                for (int i = 0; i < entry.subEntries.Count; i++)
                {
                    if (entry.subEntries[i].isEdited)
                    {
                        entry.subEntries[i].isEdited = false;
                        commandBlocksBox.SelectedIndex = i;
                        bDontSelect = false;
                        break;
                    }
                }
                if (commandBlocksBox.SelectedItems.Count > 1) // catches multi select after pasting a time
                {
                    commandBlocksBox.SelectedItems.Remove(commandBlocksBox.SelectedItems[0]);
                }
                if (bDontSelect)
                {
                    commandBlocksBox.SelectedIndex = s;
                }

                bDisableSubUpdate = false;
                bDisableSubSubUpdate = false;

            }
            else
            {
                return;
            }
        }

        private void commandsDeleteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AnmChrSubEntry commandBlockEntry = entry.subEntries[commandBlocksBox.SelectedIndex];

                if (entry.subEntries[commandBlocksBox.SelectedIndex].subsubPointers.Count <= 0)
                {
                    MessageBox.Show(this, "There is nothing to delete!"
                    + Environment.NewLine, "INVALID ACTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show(this, "Deleting command [" + (commandsBox.SelectedItem.ToString().Length <= 4 ?
                    commandsBox.SelectedItem.ToString() : commandsBox.SelectedItem.ToString().Substring(0, commandsBox.SelectedItem.ToString()
                    .IndexOf(" "))) + (commandBlockEntry.isDisabled ? "] that belongs to a disabled block" :
                    ("] with timestamp " + commandBlockEntry.localindex.ToString())) + ". Are you sure?"
                    + Environment.NewLine + "This action is irreversible." + Environment.NewLine, "PERMANENT DELETION", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }

                AELogger.Log("deleting subsub " + animBox.SelectedIndex + "." + commandBlocksBox.SelectedIndex + "." + commandsBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;

                commandBlockEntry.subsubPointers.RemoveAt(commandsBox.SelectedIndex);
                commandBlockEntry.subsubEntries.RemoveAt(commandsBox.SelectedIndex);
                commandBlockEntry.subsubIndices.RemoveAt(commandsBox.SelectedIndex);
                commandsBox.DataSource = null;
                subDataSource = entry.getSubEntryList();
                commandBlocksBox.DataSource = subDataSource;

                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;

                commandBlocksBox.SelectedIndex = 0;
                RefreshSelectedIndices();
                subsubDataSource = commandBlockEntry.GetCommandList();
                commandsBox.DataSource = subsubDataSource;
                if (commandsBox.Items.Count > 0)
                {
                    commandsBox.SelectedIndex = 0;
                }
                validateDeleteButtons(entry);
            }
        }

        // Validates if the command related buttons ought to be enabled or not
        private void validateDeleteButtons(AnmChrEntry entry)
        {
            bool isSubEntries = entry?.subEntries.Count > 0;
            bool isDisabled;
            if (commandBlocksBox.SelectedIndex > -1)
            {
                isDisabled = (entry?.subEntries[commandBlocksBox.SelectedIndex].isDisabled).Equals(true);
            }
            else
            {
                isDisabled = false;
            }
            commandBlockDeleteButton.Enabled = isSubEntries && !isMultiSelection;
            deleteCommandBlockToolStripMenuItem1.Enabled = isSubEntries && !isMultiSelection;
            deleteCommandBlockToolStripMenuItem.Enabled = isSubEntries && !isMultiSelection;
            commandBlockCopyButton.Enabled = isSubEntries && !isMultiSelection;
            copyCommandBlockToolStripMenuItem1.Enabled = isSubEntries && !isMultiSelection;
            copyCommandBlockToolStripMenuItem.Enabled = isSubEntries && !isMultiSelection;
            commandBlockDisableButton.Enabled = isSubEntries && !isMultiSelection && !isDisabled;
            disableCommandBlockToolStripMenuItem1.Enabled = isSubEntries && !isMultiSelection && !isDisabled;
            disableCommandBlockToolStripMenuItem.Enabled = isSubEntries && !isMultiSelection && !isDisabled;

            timeTextBox.Text = isSubEntries ? timeTextBox.Text : null;
            timeTextBox.Enabled = isSubEntries;
            dataTextBox.Text = isMultiSelection ? "multi selection mode" : isSubEntries ? dataTextBox.Text : "no data selected?";
            if (isSubEntries)
            {
                bool isSubSubEntries = entry.subEntries[commandBlocksBox.SelectedIndex].subsubPointers.Count > 0;
                dataTextBox.Text = isSubSubEntries ? dataTextBox.Text : "no data selected?";
                commandsDeleteButton.Enabled = isSubSubEntries;
                deleteCommandsToolStripMenuItem.Enabled = isSubSubEntries;
                commandsCopyButton.Enabled = isSubSubEntries;
                copyCommandsToolStripMenuItem.Enabled = isSubSubEntries;
            }else
            {
                commandsCopyButton.Enabled = false;
                copyCommandsToolStripMenuItem.Enabled = false;
                commandsDeleteButton.Enabled = false;
                deleteCommandsToolStripMenuItem.Enabled = false;
            }
        }

        public int GetDataTextBoxFormat()
        {
            return dataTextBoxFormat;
        }

        public void SetDataTexBoxFormat(int value = 0)
        {
            dataTextBoxFormat = value;
        }

    } // class

    static class StringExtensions
    {
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
} // ns