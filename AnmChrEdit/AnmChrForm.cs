﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarvelData;

namespace AnmChrEdit
{
    public partial class AnmChrForm : Form
    {
        public static bool bError = false;
        public string FilePath;
        public string ImportPath;
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;
        public bool bDisableSubUpdate;
        public bool bDisableSubSubUpdate;

        public AnmChrForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);
            FilePath = String.Empty;
            ImportPath = String.Empty;
        }

        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString();
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
                if (saveButton.Enabled)
                {
                    saveButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                if (openButton.Enabled)
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshData()
        {
            bDisableUpdate = true;
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            tableNames = tablefile.GetNames();
            animBox.DataSource = tableNames;
            animBox.SelectedIndex = s;
            animBox.TopIndex = top;
            bDisableUpdate = false;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (bError)
            {
                return;
            }

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                //openFile.DefaultExt = "bcm";
                // The Filter property requires a search string after the pipe ( | )
                openFile.Filter = "AnmChr Files (*.cac;*.5A7E5D8A)|*.cac;*.5A7E5D8A|All files (*.*)|*.*";
                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    //TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], typeof(StatusEntry));
                    TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], false, typeof(AnmChrEntry));
                    int count = newTable.table.Count;
                    if (newTable == null && count != 0)
                    {
                        AELogger.Log("load failed for some reason?");
                        return;
                    }
                    tablefile = newTable;

                    SuspendLayout();
                    saveButton.Enabled = true;
                    importButton.Enabled = false;
                    exportButton.Enabled = false;
                    openButton.Enabled = false;
                    animBox.Enabled = true;
                    extendButton.Enabled = true;
                    sizeLabel.Text = count + " entries loaded";
                    FilePath = openFile.FileNames[0];
                    RefreshData();
                    Text += " :: " + openFile.FileNames[0];
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
                if (FilePath != String.Empty)
                {
                    try
                    {
                        saveFileDialog1.InitialDirectory = Path.GetDirectoryName(FilePath);
                        saveFileDialog1.FileName = Path.GetFileName(FilePath);
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("some kind of exception setting save path from " + FilePath);
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
                        FilePath = saveFileDialog1.FileNames[0];
                        tablefile.WriteFile(saveFileDialog1.FileNames[0]);
                    }
                }
            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        private void extendButton_Click(object sender, EventArgs e)
        {

        }

        private void animBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableUpdate)
            {
                return;
            }
            //SuspendLayout();
            animBox.BeginUpdate();
            bDisableUpdate = true;
            importButton.Enabled = true;
            RefreshEditBox();
            //sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;

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
                subEntryBox.DataSource = entry.getSubEntryList();
            }
            else
            {
                //subsubEntryBox.BeginUpdate();
                subEntryBox.DataSource = null;
                subsubEntryBox.DataSource = null;
                subEntryBox.Items.Clear();
                subsubEntryBox.Items.Clear();
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

            //SuspendLayout();
            //subsubEntryBox.BeginUpdate();
            bDisableSubUpdate = true;

            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];
                subsubEntryBox.DataSource = entry.subEntries[subEntryBox.SelectedIndex].subsubPointers;
            }
            else
            {
                subsubEntryBox.DataSource = null;
                subsubEntryBox.Items.Clear();
            }

            bDisableSubUpdate = false;
            //subsubEntryBox.EndUpdate();
            //ResumeLayout();
        }

        private void subsubEntryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableSubSubUpdate)
            {
                return;
            }

            bDisableSubSubUpdate = true;
            int s = animBox.SelectedIndex;
            if (tablefile.table[s] is AnmChrEntry && tablefile.table[s].bHasData)
            {
                AnmChrEntry entry = (AnmChrEntry)tablefile.table[s];

                byte[] data = entry.subEntries[subEntryBox.SelectedIndex].subsubEntries[subsubEntryBox.SelectedIndex];

                dataTextBox.Text = BitConverter.ToString(data).Replace("-", "");
            }
            bDisableSubSubUpdate = false;
        }

        public static byte[] StringToByteArray(string input)
        {
            int length = input.Length / 2;
            byte[] outBytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                outBytes[i] = Convert.ToByte(input.Substring(i * 2, 2), 16); // base 16
            }
            return outBytes;
        }

        private void dataTextBox_TextChanged(object sender, EventArgs e)
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

                        entry.subEntries[subEntryBox.SelectedIndex].subsubEntries[subsubEntryBox.SelectedIndex] = StringToByteArray(dataTextBox.Text);
                    }
                    dataTextBox.ForeColor = Color.Black;
                }
                catch
                {
                    dataTextBox.ForeColor = Color.Red;
                }
            }
        }
    }
}