using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MarvelData;

namespace AnmChrEdit
{
    public partial class AnmChrForm : Form
    {
        public static bool bError = false;
        public string filePath;
        public string ImportPath;
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;
        public bool bDisableSubUpdate;
        public bool bDisableSubSubUpdate;
        public AnmChrSubEntry subCopyInstance;
        public CmdSpAtkEntry spatkCopyInstance = new CmdSpAtkEntry();
        public byte[] subsubCopyInstance;
        
        public List<List<int>> selectedSubSubIndices;
        public List<int> selectedSubIndices;

        public BindingList<string> subDataSource;
        public BindingList<string> subsubDataSource;
        private int subEntryHoveredIndex = -1;
        private int dataTexBoxFormat;
        private ImageForm imageForm;

        public AnmChrForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            //AELogger.Log(Text);
            filePath = String.Empty;
            ImportPath = String.Empty;

            selectedSubIndices = new List<int>();
            selectedSubSubIndices = new List<List<int>>();
            AnmChrSubEntry.InitCmdNames();
        }

        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString("dd:MM:yyyy");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (bError) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
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

            int subS = subEntryBox.SelectedIndex;
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

            selectedSubSubIndices[s][subS] = subsubEntryBox.SelectedIndex;
        }

        public void RefreshSelectedIndices()
        {
            int s = animBox.SelectedIndex;

            if (!tablefile.table[s].bHasData)
            {
                return;
            }

            if (!bDisableSubUpdate && selectedSubIndices.Count > s)
            {
                int selectedSub = selectedSubIndices[s];
                if (selectedSub >= 0 && selectedSub < subEntryBox.Items.Count)
                {
                    subEntryBox.SelectedIndex = selectedSub;
                }
            }

            if (selectedSubSubIndices.Count > s)
            {
                int subS = subEntryBox.SelectedIndex;
                List<int> selectedList = selectedSubSubIndices[s];
                if (selectedList.Count > subS)
                {
                    int selectedSub = selectedList[subS];

                    if (selectedSub >= 0 && selectedSub < subsubEntryBox.Items.Count)
                    {
                        subsubEntryBox.SelectedIndex = selectedSub;
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
                        + Environment.NewLine + "All unsaved data will be lost!", "Warning", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            AELogger.Log("procedure canceled!");
                            return;
                        default:
                            Text = null;
                            filePath = null;
                            filenameLabel.Text = null;
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
                    tablefile.getSubSubEntryInfo(ref subEntries);
                    tablefile.matchAtiNames(filePath);
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
                openFile.DefaultExt = "mvc3data";
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
                openFile.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";

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
                saveFileDialog1.Title = "Export " + tablefile.table[animBox.SelectedIndex].GetFancyName();
                saveFileDialog1.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
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
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                saveFileDialog1.FileName = tablefile.table[animBox.SelectedIndex].GetFilename() + ".mvc3data";

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
            tablefile.Extend();
            RefreshData();
            if (animBox.TopIndex < animBox.Items.Count - 2)
            {
                animBox.TopIndex++;
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
                subEntryBox.DataSource = subDataSource;
                exportButton.Enabled = true;
                subCopyButton.Enabled = true;
                subDeleteButton.Enabled = entry.subEntries.Count > 1;
                subsubCopyButton.Enabled = true;
                subsubDeleteButton.Enabled = true;
                lengthTextBox.Enabled = true;
                lengthTextBox.Text = entry.animTime.ToString();
                subPasteButton.Enabled = subCopyInstance != null;
                subsubPasteButton.Enabled = subsubCopyInstance != null;
            }
            else
            {
                //subsubEntryBox.BeginUpdate();
                dataTextBox.Enabled = false;
                dataTextBox.Clear();
                lengthTextBox.Enabled = false;
                lengthTextBox.Clear();
                exportButton.Enabled = false;
                subEntryBox.DataSource = null;
                subDeleteButton.Enabled = false;
                subsubEntryBox.DataSource = null;
                subEntryBox.Items.Clear();
                subsubEntryBox.Items.Clear();
                subCopyButton.Enabled = false;
                subsubCopyButton.Enabled = false;
                subsubDeleteButton.Enabled = false;
                subsubPasteButton.Enabled = true;
                subPasteButton.Enabled = false;
                //subsubEntryBox.EndUpdate();
            }
            //subEntryBox.EndUpdate();
        }

        private void subEntryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableSubUpdate)
            {
                return;
            }
            AELogger.Log("selected subox " + subEntryBox.SelectedIndex);
            //SuspendLayout();
            //subsubEntryBox.BeginUpdate();
            bDisableSubUpdate = true;

            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                if (subEntryBox.SelectedIndex >= entry.subEntries.Count)
                {
                    subsubEntryBox.SelectedIndex = entry.subEntries.Count - 1;
                }

                if (bDisableSubSubUpdate)
                {
                    subsubDataSource = entry.subEntries[subEntryBox.SelectedIndex].GetCommandList();
                    subsubEntryBox.DataSource = subsubDataSource;
                }
                else
                {
                    bDisableSubSubUpdate = true;
                    subsubDataSource = entry.subEntries[subEntryBox.SelectedIndex].GetCommandList();
                    subsubEntryBox.DataSource = subsubDataSource;
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
                timeTextBox.Text = entry.subEntries[subEntryBox.SelectedIndex].tableindex.ToString();
                timeTextBox.Enabled = true;
            }
            else
            {
                timeTextBox.Enabled = false;
                subsubEntryBox.DataSource = null;
                subsubEntryBox.Items.Clear();
            }

            bDisableSubUpdate = false;
            //subsubEntryBox.EndUpdate();
            //ResumeLayout();
        }

        private void subsubEntryBox_SelectedIndexChanged(object sender, EventArgs ev)
        {
            if (bDisableSubSubUpdate)
            {
                return;
            }

            AELogger.Log("selected subsubox " + subsubEntryBox.SelectedIndex);

            bDisableSubSubUpdate = true;
            int s = animBox.SelectedIndex;
            if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                if (subEntryBox.SelectedIndex >= entry.subEntries.Count && subEntryBox.SelectedIndex >= 0)
                {
                    AELogger.Log("possible big error");

                    RefreshText();
                }
                else
                {
                    if (subsubEntryBox.SelectedIndex >= entry.subEntries[subEntryBox.SelectedIndex].subsubEntries.Count)
                    {
                        subsubEntryBox.SelectedIndex = entry.subEntries.Count - 1;
                    }

                    RefreshText();

                    SaveSelectedIndices();
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

                if (subEntryBox.SelectedIndex >= entry.subEntries.Count || subEntryBox.SelectedIndex < 0)
                {
                    dataTextBox.Enabled = false;
                    AELogger.Log("weird otherwise probably nonharmful data index error A");
                    dataTextBox.Text = "no data selected?";
                    return;
                }
                if (subsubEntryBox.SelectedIndex >= entry.subEntries[subEntryBox.SelectedIndex].subsubEntries.Count || subsubEntryBox.SelectedIndex < 0)
                {
                    AELogger.Log("weird otherwise probably nonharmful data index error B");
                    dataTextBox.Enabled = false;
                    dataTextBox.Text = "no data selected?";
                    return;
                }
                byte[] data = entry.subEntries[subEntryBox.SelectedIndex].subsubEntries[subsubEntryBox.SelectedIndex];
                dataTextBox.Enabled = true;
                dataTextBox.Text = BitConverter.ToString(data).Replace("-", "");
                dataTextBox.Text = splitAndBreakEveryNChars(dataTextBox.Text, GetDataTexBoxFormat());
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

                        entry.subEntries[subEntryBox.SelectedIndex].subsubEntries[subsubEntryBox.SelectedIndex] 
                            = StringToByteArray(dataTextBox.Text.Replace("\r\n", ""));

                        bDisableSubSubUpdate = true;
                        subsubDataSource[subsubEntryBox.SelectedIndex] = entry.subEntries[subEntryBox.SelectedIndex]
                            .GetSubSubName(subsubEntryBox.SelectedIndex);
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
        private void OnsubEntryBoxMouseMove(object sender, MouseEventArgs e)
        {
            // if still on the same row, do nothing
            if (!subEntryBox.IndexFromPoint(e.Location).Equals(subEntryHoveredIndex))
            {
                string strTip = "";
                int nIdx = subEntryBox.IndexFromPoint(e.Location);
                if ((nIdx >= 0) && (nIdx < subEntryBox.Items.Count))
                {
                    subEntryHoveredIndex = nIdx;
                    strTip = subEntryBox.Items[nIdx].ToString();
                    if (tablefile != null && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
                    {
                        AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                        if (entry.subEntries.Count > 0)
                        {
                        entry.subEntries[nIdx].GetCommandList().ToList().ForEach(n => strTip += " \r\n  " + n.ToString());
                        }
                    }
                }
                toolTip1.SetToolTip(subEntryBox, strTip);
            }
        }

        // Creates labels for the sub sub entries box
        private void OnsubsubEntryBoxMouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = subsubEntryBox.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < subsubEntryBox.Items.Count))
                strTip = subsubEntryBox.Items[nIdx].ToString();

            toolTip2.SetToolTip(subsubEntryBox, strTip);
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
                    entry.subEntries[subEntryBox.SelectedIndex].bEdited = true;
                    entry.subEntries[subEntryBox.SelectedIndex].tableindex = newTime;
                    entry.subEntries[subEntryBox.SelectedIndex].localindex = newTime;
                    timeTextBox.ForeColor = Color.White;
                    bDisableSubSubUpdate = true;
                    bDisableSubUpdate = true;
                    int s = subEntryBox.SelectedIndex;
                    subDataSource = entry.getSubEntryList();
                    subEntryBox.DataSource = subDataSource;
                    bool bDontSelect = true;
                    for (int i = 0; i < entry.subEntries.Count; i++)
                    {
                        if (entry.subEntries[i].bEdited)
                        {
                            entry.subEntries[i].bEdited = false;
                            subEntryBox.SelectedIndex = i;
                            bDontSelect = false;
                            break;
                        }
                    }

                    if (bDontSelect)
                    {
                        subEntryBox.SelectedIndex = s;
                    }

                    bDisableSubUpdate = false;
                    bDisableSubSubUpdate = false;
                }
                catch
                {
                    timeTextBox.ForeColor = Color.Red;
                }
            } else {
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

        private void subCopyButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AELogger.Log("copying sub " + animBox.SelectedIndex + "." + subEntryBox.SelectedIndex);
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];


                subCopyInstance = entry.subEntries[subEntryBox.SelectedIndex].Copy();
                
                subPasteButton.Enabled = true;
            }
        }

        private void subPasteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry
                && subCopyInstance != null)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("pasting sub to " + animBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;
                
                entry.subEntries.Add(subCopyInstance.Copy());
                subDataSource = entry.getSubEntryList();
                subEntryBox.DataSource = subDataSource;


                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;

                for (int i = 0; i < entry.subEntries.Count; i++)
                {
                    if (entry.subEntries[i].bEdited)
                    {
                        entry.subEntries[i].bEdited = false;
                        subEntryBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void subsubCopyButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("copying subsub " + animBox.SelectedIndex + "." + subEntryBox.SelectedIndex + "." + subsubEntryBox.SelectedIndex);
                byte[] source = entry.subEntries[subEntryBox.SelectedIndex].subsubEntries[subsubEntryBox.SelectedIndex];
                subsubCopyInstance = new byte[source.Length];
                source.CopyTo(subsubCopyInstance, 0);

                subsubPasteButton.Enabled = true;
            }
        }

        private void subsubPasteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry
                && subsubCopyInstance != null)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];
                AELogger.Log("pasting subsub to " + animBox.SelectedIndex + "." + subsubEntryBox.SelectedIndex);
                byte[] dest = new byte[subsubCopyInstance.Length];
                subsubCopyInstance.CopyTo(dest, 0);
                entry.subEntries[subEntryBox.SelectedIndex].subsubEntries.Add(dest);
                entry.subEntries[subEntryBox.SelectedIndex].subsubPointers.Add(uint.MaxValue);
                entry.subEntries[subEntryBox.SelectedIndex].subsubIndices.Add(0);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;
                subsubEntryBox.DataSource = null;
                subsubDataSource = entry.subEntries[subEntryBox.SelectedIndex].GetCommandList();
                subsubEntryBox.DataSource = subsubDataSource;

                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;
                subsubEntryBox.SelectedIndex = subsubEntryBox.Items.Count-1;
            }
        }

        private void subDeleteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];

                if (MessageBox.Show(this, "Deleting subentry w time " + entry.subEntries[subEntryBox.SelectedIndex].localindex.ToString() + ", You sure bout dat?", "FINAL DELETION", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                AELogger.Log("deleting sub " + animBox.SelectedIndex + "." + subEntryBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;

                entry.subEntries.RemoveAt(subEntryBox.SelectedIndex);
                subsubEntryBox.DataSource = null;
                subDataSource = entry.getSubEntryList();
                subEntryBox.DataSource = subDataSource;

                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;
                
                subEntryBox.SelectedIndex = 0;
                RefreshSelectedIndices();
                subsubDataSource = entry.subEntries[subEntryBox.SelectedIndex].GetCommandList();
                subsubEntryBox.DataSource = subsubDataSource;
                if (subsubDataSource.Count > 0)
                {
                    subsubEntryBox.SelectedIndex = 0;
                }
                else
                {
                    AELogger.Log("odd issue ???????");
                    dataTextBox.Enabled = false;
                }
                

                subDeleteButton.Enabled = entry.subEntries.Count > 1;
            }
        }

        private void subsubDeleteButton_Click(object sender, EventArgs e)
        {
            if (tablefile.table[animBox.SelectedIndex].bHasData
                && tablefile.table[animBox.SelectedIndex] is AnmChrEntry)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[animBox.SelectedIndex];

                if (entry.subEntries[subEntryBox.SelectedIndex].subsubPointers.Count <= 1)
                {
                    // FIXME THIS SUX
                    return;
                }

                if (MessageBox.Show(this, "Deleting subsubentry w time " + entry.subEntries[subEntryBox.SelectedIndex].localindex.ToString() + " and ptr " + entry.subEntries[subEntryBox.SelectedIndex].subsubPointers[subsubEntryBox.SelectedIndex] + ", You sure bout dat?", "FINAL DELETION", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                AELogger.Log("deleting subsub " + animBox.SelectedIndex + "." + subEntryBox.SelectedIndex + "." + subsubEntryBox.SelectedIndex);

                bDisableSubUpdate = true;
                bDisableSubSubUpdate = true;

                entry.subEntries[subEntryBox.SelectedIndex].subsubPointers.RemoveAt(subsubEntryBox.SelectedIndex);
                entry.subEntries[subEntryBox.SelectedIndex].subsubEntries.RemoveAt(subsubEntryBox.SelectedIndex);
                entry.subEntries[subEntryBox.SelectedIndex].subsubIndices.RemoveAt(subsubEntryBox.SelectedIndex);
                subsubEntryBox.DataSource = null;
                subDataSource = entry.getSubEntryList();
                subEntryBox.DataSource = subDataSource;

                bDisableSubSubUpdate = false;
                bDisableSubUpdate = false;

                subEntryBox.SelectedIndex = 0;
                RefreshSelectedIndices();
                subsubDataSource = entry.subEntries[subEntryBox.SelectedIndex].GetCommandList();
                subsubEntryBox.DataSource = subsubDataSource;
                subsubEntryBox.SelectedIndex = 0;

                subDeleteButton.Enabled = entry.subEntries.Count > 1;
            }
        }
        public int GetDataTexBoxFormat()
        {
            return dataTexBoxFormat;
        }

        public void SetDataTexBoxFormat(int value = 0)
        {
            dataTexBoxFormat = value;
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