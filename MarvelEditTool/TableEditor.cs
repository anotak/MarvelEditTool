using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarvelData;

namespace MarvelEditTool
{
    public partial class TableEditor : Form
    {
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;

        public static bool bError;

        public TableEditor()
        {
            InitializeComponent();
            Text += ", build " + SSFIVAEDataTools.GetCompileDate();
            AELogger.Log(Text);
            bDisableUpdate = true;
        }

        public void SaferExit()
        {
            AELogger.WriteLog();
            Application.Exit();
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (bError)
            {
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.DefaultExt = "bcm";
            // The Filter property requires a search string after the pipe ( | )
            //openFile.Filter = "BCM Files (*.bcm)|*.bcm|All files (*.*)|*.*";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                TableFile newTable = TableFile.LoadFile(openFile.FileNames[0]);
                int count = newTable.table.Count;
                if (newTable == null && count != 0)
                {
                    AELogger.Log("load failed for some reason?");
                    return;
                }
                tablefile = newTable;
                
                saveButton.Enabled = true;
                importButton.Enabled = false;
                exportButton.Enabled = false;
                openButton.Enabled = false;
                animBox.Enabled = true;
                extendButton.Enabled = true;
                sizeLabel.Text = count + " entries loaded";
                RefreshData();
            }
            else
            {
                AELogger.Log("nothing selected!");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (bError)
            {
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "BCM files (*.bcm)|*.bcm|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileNames.Length > 0)
                {
                    tablefile.WriteFile(saveFileDialog1.FileNames[0]);
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count)
            {
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            
            saveFileDialog1.FileName = tablefile.table[animBox.SelectedIndex].GetFilename() + ".mvc3data";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileNames.Length > 0)
                {
                    tablefile.table[animBox.SelectedIndex].Export(saveFileDialog1.FileNames[0]);
                }
            }
        }

        private void animBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bDisableUpdate)
            {
                return;
            }

            bDisableUpdate = true;
            importButton.Enabled = true;

            if (
                animBox.SelectedIndex >= 0
                &&
                animBox.SelectedIndex < tablefile.table.Count
                &&
                tablefile.table[animBox.SelectedIndex].bHasData
                )
            {
                textBox1.Text = tablefile.table[animBox.SelectedIndex].name;
                textBox1.Enabled = true;
                exportButton.Enabled = true;
                dataTextBox.Text = BitConverter.ToString(tablefile.table[animBox.SelectedIndex].data).Replace("-","");
                sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;
            }
            else
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                exportButton.Enabled = false;
                dataTextBox.Text = "";
                sizeLabel.Text = "size: N/A";
            }
            

            bDisableUpdate = false;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count)
            {
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "mvc3data";
            // The Filter property requires a search string after the pipe ( | )
            openFile.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                tablefile.table[animBox.SelectedIndex].Import(openFile.FileNames[0]);
                RefreshData();
                dataTextBox.Text = BitConverter.ToString(tablefile.table[animBox.SelectedIndex].data).Replace("-", "");
                sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;
            }
            else
            {
                AELogger.Log("nothing selected!");
            }
        }

        private void RefreshData()
        {
            bDisableUpdate = true;
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            tableNames = tablefile.GetNames();
            animBox.DataSource = tableNames;
            animBox.SelectedIndex = s;
            animBox.TopIndex = top + 1;
            bDisableUpdate = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(bDisableUpdate)
            {
                return;
            }

            tablefile.table[animBox.SelectedIndex].name = textBox1.Text;
            RefreshData();
        }

        private void extendButton_Click(object sender, EventArgs e)
        {
            tablefile.Extend();
            RefreshData();
        }
    }
}
