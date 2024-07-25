using MarvelData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatusEditor
{
    public partial class StatusEditorForm : Form
    {
        public static bool bError = false;
        public static bool bDataGridError = false;
        public string FilePath;
        public string ImportPath;
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;
        public Dictionary<Type, FieldInfo[]> structFieldInfo;
        public int previousSelectedIndex;
        public Type structViewType;
        public Type structViewEntryType;

        private int dataTextBoxFormat;
        private bool isSameFile;
        private System.Windows.Forms.DataGridViewEditingControlShowingEventArgs dgvE;
        private System.Windows.Forms.DataGridView dgvSender;

        public StatusEditorForm()
        {
            InitializeComponent();
            isSameFile = true;
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);
            FilePath = String.Empty;
            ImportPath = String.Empty;
            bDisableUpdate = true;
            textBox1.Visible = false;
            previousSelectedIndex = 0;
            tagsDataGridView.Rows.Clear();
            structView.Rows.Clear();
            AddItems(typeof(StatusChunk));

            structView.DataError += structView_DataError;
            structView.CellEndEdit += structView_CellEndEdit;
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
            switch (MessageBox.Show(this, "Are you sure you want to close?" + Environment.NewLine +
                    "All unsaved data will be lost!", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    AELogger.WriteLog();
                    break;
            }
        }

        public void ClearItems()
        {
            structView.Rows.Clear();
            structFieldInfo = null;
        }

        public void AddItems(Type structtype, int structIndex = 0)
        {
            if (structFieldInfo == null)
            {
                structFieldInfo = new Dictionary<Type, FieldInfo[]>();
            }

            //string temp = Tools.GetDescription(structtype);

            FieldInfo[] fieldList = GetFieldInfo(structtype);
            int offset = structView.Rows.Count;
            for (int i = 0; i < fieldList.Length; i++)
            {
                structView.Rows.Add(structIndex.ToString());
                //structView.Rows.Add(fieldList[i].Name);
                structView.Rows[i + offset].Cells[1].Value = fieldList[i].Name;
                if (fieldList[i].FieldType == typeof(float))
                {
                    structView.Rows[i + offset].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else if (fieldList[i].FieldType.IsEnum)
                {
                    structView.Rows[i + offset].DefaultCellStyle.BackColor = Color.Linen;
                }
                if (fieldList[i].Name == "subChunkType" || fieldList[i].Name == "objectReferenceId")
                {
                    structView.Rows[i + offset].DefaultCellStyle.BackColor = Color.LightGray;
                }
                structView.Rows[i + offset].Cells[2].ValueType = fieldList[i].FieldType;
                //AELogger.Log(structFieldInfo[i].Name.ToString());
            }

            structViewEntryType = typeof(StructEntry<>).MakeGenericType(structtype);

            structViewType = structtype;
        }

        public class TypeViewModel
        {
            public string hex { get; set; }
            public string dec { get; set; }
            public string name { get; set; }
        }

        private void AddTags(Type type, Boolean isHex)
        {
            IEnumerable<TypeViewModel> typeList = getEnumValuesList(type, isHex);
            TypeViewModel[] tempList = typeList.ToArray();
            tagsDataGridView.DataSource = null;
            if (isHex) {
                for (int i=0; i < tempList.Length; i++)
                {
                    tempList[i].dec = (int.Parse(tempList[i].hex, System.Globalization.NumberStyles.HexNumber)).ToString();
                }
            }
            tagsDataGridView.DataSource = tempList;
            if (!isHex)
            {
                tagsDataGridView.Columns.RemoveAt(1);
            }
            tagsDataGridView.RowHeadersVisible = false;
        }

        private static IEnumerable<TypeViewModel> getEnumValuesList(Type type, bool isHex)
        {
            return Enum.GetValues(type)
               .Cast<Object>()
               .Select(t => new TypeViewModel
               {
                   hex = isHex ? ((uint)t).ToString("X8") : ((int)t).ToString(),
                   name = t.ToString()
               });
        }

        private static IEnumerable<TypeViewModel> getEnumValuesList(Type type)
        {
            return Enum.GetValues(type)
               .Cast<Object>()
               .Select(t => new TypeViewModel
               {
                   name = t.ToString()
               });
        }

        private FieldInfo[] GetFieldInfo(Type structtype)
        {
            FieldInfo[] fieldList;
            if (structFieldInfo.ContainsKey(structtype))
            {
                fieldList = structFieldInfo[structtype];
            }
            else
            {
                structFieldInfo.Add(structtype, structtype.GetFields());
                fieldList = structFieldInfo[structtype];
            }

            return fieldList;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (saveAsToolStripMenuItem.Enabled)
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
            else if (keyData == (Keys.Control | Keys.B))
            {
                if (addSubChunkButton.Enabled)
                {
                    addSubChunkButton_Click(null, null);
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
            else if (keyData == (Keys.Control | Keys.D))
            {
                if (duplicateButton.Enabled)
                {
                    duplicateButton_Click(null, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad0) || keyData == (Keys.Control | Keys.D0))
            {
                {
                    ToolStripMenuItem dummyButton = new ToolStripMenuItem();
                    dummyButton.Tag = "0";
                    formatButton_Click(dummyButton, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad1) || keyData == (Keys.Control | Keys.D1))
            {
                {
                    ToolStripMenuItem dummyButton = new ToolStripMenuItem();
                    dummyButton.Tag = "8";
                    formatButton_Click(dummyButton, null);
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.NumPad2) || keyData == (Keys.Control | Keys.D2))
            {
                {
                    ToolStripMenuItem dummyButton = new ToolStripMenuItem();
                    dummyButton.Tag = "16";
                    formatButton_Click(dummyButton, null);
                }
                return true;
            }
            else if (keyData == (Keys.Decimal)) //110
            {
                if (dgvSender != null)
                {
                    isCommaInput = true;
                    StructView_EditingControlShowing(dgvSender, dgvE);
                }
            }
            else if (keyData == (Keys.Oemcomma)) //110
            {
                if (dgvSender != null)
                {
                    isCommaInput = true;
                    StructView_EditingControlShowing(dgvSender, dgvE);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
                    // Confirm user wants to open a new instance
                    switch (MessageBox.Show(this, "Are you sure you want to open a new instance?" + Environment.NewLine +
                        "All unsaved data will be lost!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            AELogger.Log("procedure canceled!");
                            return;
                        default:
                            Text = "StatusEditor, build " + GetCompileDate();
                            /*isOpeningNewFile = true;
                            filenameLabel.Text = String.Empty;
                            FilePath = String.Empty;
                            ImportPath = String.Empty;
                            tablefile = null;
                            SetDataTexBoxFormat(0);*/
                            AELogger.WriteLog();
                            break;
                    }
                //openFile.DefaultExt = "bcm";
                // The Filter property requires a search string after the pipe ( | )
                setFilter(openFile, (string)((ToolStripMenuItem)sender).Text);
                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    isOpeningNewFile = true;
                    filenameLabel.Text = String.Empty;
                    FilePath = String.Empty;
                    ImportPath = String.Empty;
                    tablefile = null;
                    SetDataTexBoxFormat(0);
                    //TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], typeof(StatusEntry));
                    TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], true, null, 848, false);
                    int count = newTable.table.Count;
                    if (newTable == null && count != 0)
                    {
                        AELogger.Log("load failed for some reason?");
                        return;
                    }
                    tablefile = newTable;
                    ResetLayout(openFile, count);
                    animBox_SelectedIndexChanged(null, null);
                }
                else
                {
                    AELogger.Log("nothing selected!");
                }
                isOpeningNewFile = false;
            }
        }

        private static void setFilter(OpenFileDialog openFile, string chosenFileType)
        {
            if (chosenFileType.Contains("ATI"))
            {
                openFile.Filter = "AtkInfo Files (*.ati;*.227A8048)|*.ati;*.227A8048";
            }
            else if (chosenFileType.Contains("CBA"))
            {
                openFile.Filter = "BaseAct Files (*.cba;*.3C6EA504)|*.cba;*.3C6EA504";
            }
            else if (chosenFileType.Contains("CCM"))
            {
                openFile.Filter = "Cmdcombo Files (*.ccm;*.28DD8317)|*.ccm;*.28DD8317";
            }
            else if (chosenFileType.Contains("CSP"))
            {
                openFile.Filter = "Cmdspatk Files (*.csp;*.52A8DBF6)|*.csp;*.52A8DBF6";
            }
            else if (chosenFileType.Contains("CHS"))
            {
                openFile.Filter = "Status Files (*.chs;*.3C41466B)|*.chs;*.3C41466B";
            }
            else if (chosenFileType.Contains("CLI"))
            {
                openFile.Filter = "Collision Files (*.cli;*.5B486CCE)|*.cli;*.5B486CCE";
            }
            else if (chosenFileType.Contains("SHT"))
            {
                openFile.Filter = "Shot Files (*.sht;*.10BE43D4)|*.sht;*.10BE43D4";
            }
            else
                openFile.Filter = "Supported Data (" +
                    "*.ccm;*.28DD8317;*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504;*.csp;*.52A8DBF6;*.cli;*.5B486CCE;*.sht;*.10BE43D4)|" +
                    "*.ccm;*.28DD8317;*.csp;*.52A8DBF6;*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504;*.cli;*.5B486CCE;*.sht;*.10BE43D4|" +
                    "AtkInfo Files (*.ati;*.227A8048)|*.ati;*.227A8048|BaseAct Files (*.cba;*.3C6EA504)|*.cba;*.3C6EA504|" +
                    "Cmdcombo Files (*.ccm;*.28DD8317)|*.ccm;*.28DD8317|Cmdspatk Files (*.csp;*.52A8DBF6)|*.csp;*.52A8DBF6|" +
                    "Status Files (*.chs;*.3C41466B)|*.chs;*.3C41466B|Collision Files (*.cli;*.5B486CCE)|.cli;*.5B486CCE|" +
                    "Shot Files (*.sht;*.10BE43D4)|*.sht;*.10BE43D4|" +
                    "All files (*.*)|*.*";
        }

        private void closeButton_Click(object sender, EventArgs ev)
        {
            Application.Exit();
        }

        void dropDownItemSelectEvent(object subChunkType, EventArgs e)
        {
            MultiStructEntry entry = (MultiStructEntry)tablefile.table[animBox.SelectedIndex];
            SaveOldData(animBox.SelectedIndex);
            entry.AddSubChunk(subChunkType.ToString());
            animBox_SelectedIndexChanged(null, null);

            // increase tag [size] by 1
            if (structView.Rows[1].Cells[1].Value.ToString().Equals("size"))
            {
                structView.Rows[1].Cells[2].Value = Int32.Parse((string)structView.Rows[1].Cells[2].Value) + 1;
            }
        }

        private void ResetLayout(OpenFileDialog openFile, int count)
        {
            SuspendLayout();
            bool isShtFile = tablefile.fileExtension.Contains("SHT");
            textBox1.Visible = isShtFile;
            extendButton.Visible = !isShtFile;
            duplicateButton.Visible = !isShtFile;
            upButton.Visible = !isShtFile;
            downButton.Visible = !isShtFile;
            addSubChunkButton.Visible = !isShtFile;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            importButton.Enabled = false;
            duplicateButton.Enabled = false;
            upButton.Enabled = false;
            downButton.Enabled = false;
            exportButton.Enabled = false;
            addSubChunkButton.Enabled = false;
            animBox.Enabled = true;
            extendButton.Enabled = extendButton.Visible;
            sizeLabel.Text = count + " entries loaded";
            FilePath = openFile.FileNames[0];
            RefreshData();
            Text += " :: " + openFile.FileNames[0];
            filenameLabel.Text = openFile.FileNames[0];
            animBox.SelectedIndex = 0;
            structView.Focus();
            ResumeLayout();
        }

        private void saveButton_Click(object sender, EventArgs ev)
        {
            if (bError || tablefile.fileExtension.Contains("SHT") ? !ValidateName() : false)
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
                        if (structView.Enabled)
                        {
                            SaveOldData(animBox.SelectedIndex);
                        }

                        FilePath = saveFileDialog1.FileNames[0];
                        tablefile.WriteFile(saveFileDialog1.FileNames[0]);
                    }
                }
            }
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
                        openFile.InitialDirectory = Path.GetDirectoryName(FilePath);
                        openFile.FileName = Path.GetFileName(FilePath);
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
                openFile.Title = "Import" + tablefile.table[animBox.SelectedIndex].GetFancyName();
                // The Filter property requires a search string after the pipe ( | )
                if (tablefile.fileExtension == "CAC")
                {
                    openFile.Filter = "|UMVC3 Character Script File (*.mvc3anm;*.mvc3data)|*.mvc3anm;*.mvc3data|UMVC3 Loose Data (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CSP")
                {
                    openFile.Filter = "MVC3 Special Input Command File (*.mvc3csp;*.mvc3data)|*.mvc3csp;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CBA")
                {
                    openFile.Filter = "MVC3 Basic Input Action File (*.mvc3cba;*.mvc3data)|*.mvc3cba;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CCM")
                {
                    openFile.Filter = "MVC3 Extra Cancel Input File (*.mvc3ccm;*.mvc3data)|*.mvc3ccm;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "ATI")
                {
                    openFile.Filter = "MVC3 Attack Data File (*.mvc3data;*.mvc3ati)|*.mvc3ati;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CLI")
                {
                    openFile.Filter = "MVC3 Collision File (*.mvc3cli;*.mvc3data)|*.mvc3cli;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CHS")
                {
                    openFile.Filter = "MVC3 Character Status File (*.mvc3chs;*.mvc3data)|*.mvc3chs;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CPI")
                {
                    openFile.Filter = "MVC3 Character Status File (*.mvc3chs;*.mvc3data)|*.mvc3chs;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "SHT")
                {
                    openFile.Filter = "UMVC3 Projectile File (*.mvc3sht;*.mvc3data)|*.mvc3sht;*.mvc3data|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else
                {
                    openFile.Filter = "All files (*.*)|*.*|UMVC3 Loose Data(*.mvc3data)|*.mvc3data";
                }

                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    tablefile.table[animBox.SelectedIndex].Import(openFile.FileNames[0]);
                    RefreshData();
                    RefreshEditBox();
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
                if (tablefile.fileExtension == "CSP")
                {
                    saveFileDialog1.Filter = "MVC3 Special Input Command File (*.mvc3csp)|*.mvc3csp|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CBA")
                {
                    saveFileDialog1.Filter = "MVC3 Basic Input Action File (*.mvc3cba)|*.mvc3cba|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CCM")
                {
                    saveFileDialog1.Filter = "MVC3 Extra Cancel Input File (*.mvc3ccm)|*.mvc3ccm|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "ATI")
                {
                    saveFileDialog1.Filter = "MVC3 Attack Data File (*.mvc3ati|*.mvc3ati|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CLI")
                {
                    saveFileDialog1.Filter = "MVC3 Collision File (*.mvc3cli)|*.mvc3cli|UMVC3 Loose Data (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
                }
                else if (tablefile.fileExtension == "CHS")
                {
                    saveFileDialog1.Filter = "MVC3 Character Status File (*.mvc3chs)|*.mvc3chs|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else if (tablefile.fileExtension == "SHT")
                {
                    saveFileDialog1.Filter = "UMVC3 Projectile File (*.mvc3sht)|*.mvc3sht|UMVC3 Loose Data(*.mvc3data)|*.mvc3data|All files(*.*)|*.*";
                }
                else
                {
                    saveFileDialog1.Filter = "All files (*.*)|*.*|UMVC3 Loose Data(*.mvc3data)|*.mvc3data";
                }
                if (FilePath != String.Empty)
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
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                saveFileDialog1.FileName = tablefile.table[animBox.SelectedIndex].GetFilename();

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileNames.Length > 0)
                    {
                        if (structView.Enabled)
                        {
                            SaveOldData(animBox.SelectedIndex);
                        }
                        ImportPath = saveFileDialog1.FileNames[0];
                        tablefile.table[animBox.SelectedIndex].Export(saveFileDialog1.FileNames[0]);
                    }
                }
            }
        }

        private void duplicateButton_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Do you want to duplicate this entry?" + Environment.NewLine + "This action cannot be undone!", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    break;
                default:
                    if (cantAddSubChunk())
                        return;

                    tablefile.Duplicate(animBox.SelectedIndex);
                    RefreshDataAlt();
                    if (animBox.TopIndex < animBox.Items.Count - 2)
                    {
                        animBox.TopIndex++;
                    }
                    break;
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

        private void addSubChunkButton_Click(object sender, EventArgs e)
        {
            if (cantAddSubChunk())
                return;

            MultiStructEntry entry = (MultiStructEntry)tablefile.table[animBox.SelectedIndex];
            SaveOldData(animBox.SelectedIndex);
            entry.AddSubChunk();
            animBox_SelectedIndexChanged(null, null);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            /*
            if (cantAddSubChunk())
                return;

            Point screenPoint = downButton.PointToScreen(new Point(downButton.Left, downButton.Bottom));


            //IEnumerable<TypeViewModel> enumValues = getEnumValuesList(typeof(SubChunkType));
            //List<TypeViewModel>list = enumValues.ToList();
            //list.ForEach(i => contextMenuStrip1.Items.Add(i.name, null, dropDownItemSelectEvent));

            contextMenuStrip1.Items.Clear();
            MVC3DataStructures.SubChunkTypeList.Sort();
            MVC3DataStructures.SubChunkTypeList.ForEach(i => contextMenuStrip1.Items.Add(i, null, dropDownItemSelectEvent));

            if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStrip1.Show(downButton, new Point(0, -contextMenuStrip1.Size.Height));
            }
            else
            {
                contextMenuStrip1.Show(downButton, new Point(0, downButton.Height));
            }*/
        }

        // checks if a subchunk can be added
        private bool cantAddSubChunk()
        {
            if (!(animBox.SelectedIndex < 0 || animBox.SelectedIndex >= tablefile.table.Count
                || !tablefile.table[animBox.SelectedIndex].bHasData))
            {
                if ((tablefile.table[animBox.SelectedIndex] is StructEntry<ATKInfoChunk>))
                {
                    return !(tablefile.table[animBox.SelectedIndex] is StructEntry<ATKInfoChunk>);
                }
                else
                {
                    return !(tablefile.table[animBox.SelectedIndex] is MultiStructEntry);
                }
            }
            return true;
        } 

        private void formatButton_Click(object sender, EventArgs e)
        {
            SetDataTexBoxFormat(Int32.Parse(((ToolStripMenuItem)sender).Tag.ToString()));
            RefreshEditBox();
        }

        // this data refers to the items being open
        private void RefreshData()
        {
            bDisableUpdate = true;
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            tableNames = tablefile.GetNames();
            animBox.DataSource = tableNames;
            if (s >= tableNames.Count)
            { 
                s = 0; 
            } //fixes outofbounds when loading new file
            animBox.SelectedIndex = s;
            animBox.TopIndex = top;
            bDisableUpdate = false;
        }

        // Ugly solution... every second duplicate clears the first copied entry
        private void RefreshDataAlt()
        {
            bDisableUpdate = true;
            int s = animBox.SelectedIndex;
            int top = animBox.TopIndex;
            string copiedName = "0" + (tablefile.table.Count - 1).ToString("x") + "h: " + tablefile.table[tablefile.table.Count - 1].name;
            tableNames = tablefile.GetNames();
            tableNames[tableNames.Count - 1] = copiedName;
            animBox.DataSource = tableNames;
            if (s > tableNames.Count) s = 0; //fixes outofbounds when loading new file
            animBox.SelectedIndex = s;
            animBox.TopIndex = top;
            bDisableUpdate = false;
        }

        private void SaveOldData(int index)
        {
            if (!isOpeningNewFile)
            {
                Type entryType = tablefile.table[index].GetType();
                if (tablefile.table[index] is StructEntryBase)
                {
                    Type generic = entryType.GetGenericArguments()[0];
                    AELogger.Log(generic.ToString() + " is the saveolddata");
                    if (generic.Equals(structViewType))
                    {
                        SaveOldData((StructEntryBase)tablefile.table[index], entryType, 0);
                    }
                    else if (isSameFile)
                    {
                        MessageBox.Show("Warning: the temporary saving process aborted due to having a different file.",
                            "Non-critical error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        AELogger.Log("warning saving attempted of non correct data");
                        return;
                    }
                }
                else if (tablefile.table[index] is MultiStructEntry)
                {
                    MultiStructEntry multientry = (MultiStructEntry)tablefile.table[index];
                    int offset = 0;
                    for (int i = 0; i < multientry.subEntries.Count; i++)
                    {
                        entryType = multientry.subEntries[i].GetType();

                        offset += SaveOldData((StructEntryBase)multientry.subEntries[i], entryType, offset);
                    }
                }
            }
        }

        private int SaveOldData(StructEntryBase entry, Type entryType, int offset)
        {
            //if (!(tablefile.table[index] is StatusEntry))

            //Object entrydata = ((StructEntry)tablefile.table[index]).data; // turn it into a reference so SetValue works

            Object entrydata = entry.GetDataObject(); // turn it into a reference so SetValue works
            FieldInfo[] fieldList = GetFieldInfo(entryType.GetGenericArguments()[0]);
            int numFields = fieldList.Length;
            int numRows = structView.Rows.Count;
            for (int i = 0; i < numFields && i + offset < numRows; i++)
            {

                //structView.Rows[i].cells[2].Value = structFieldInfo[i].GetValue(entry.data).ToString();

                // this part isnt needed anymore bc of magic with dataviewgrid
                /*
                if (structFieldInfo[i].FieldType.IsEnum)
                {// check if enum
                    structFieldInfo[i].SetValue(entrydata, Enum.Parse(structFieldInfo[i].FieldType, (string)structView.Rows[i].cells[2].Value));
                }
                else
                */
                {
                    try
                    {
                        Convert.ChangeType(structView.Rows[i + offset].Cells[2].Value, fieldList[i].FieldType);
                        //AELogger.Log(structFieldInfo[i].ToString() + " IS " + structView.Rows[i].cells[2].Value + " VS " + Convert.ChangeType(structView.Rows[i].cells[2].Value, structFieldInfo[i].FieldType));
                        //AELogger.Log(structFieldInfo[i].GetValue(entrydata).ToString());
                        fieldList[i].SetValue(entrydata, Convert.ChangeType(structView.Rows[i + offset].Cells[2].Value, fieldList[i].FieldType));
                        //AELogger.Log(structFieldInfo[i].GetValue(entrydata).ToString());
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("failed type: val " + fieldList[i].ToString() + " - value " + structView.Rows[i + offset].Cells[2].Value);


                        AELogger.Log("Exception: " + e.Message);

                        AELogger.Log("Exception: " + e.StackTrace);
                    }
                }
            }

            entry.SetDataObject(entrydata);
            return numFields;
        }

        private void animBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bDisableUpdate)
            {
                return;
            }
            if (structView.Enabled)
            {
                SaveOldData(previousSelectedIndex);
            }
            previousSelectedIndex = animBox.SelectedIndex;
            RefreshAnimBox();
        }

        //this creates the drop down list for enums and other integers
        private void structView_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tag = "";

            if (((System.Windows.Forms.DataGridViewCellEventArgs)e).RowIndex >= 0 &&
            ((System.Windows.Forms.DataGridViewCellEventArgs)e).RowIndex <= structView.Rows.Count)
                tag = (string)structView?.Rows[((System.Windows.Forms.DataGridViewCellEventArgs)e).RowIndex]?.Cells[1]?.Value ?? "";

            if (tag.Equals("AttackLevel"))
                AddTags(typeof(AttackLevel), false);
            else if (tag.Equals("GuardType"))
                AddTags(typeof(GuardType), false);
            else if (tag.Equals("atkflags3"))
                AddTags(typeof(AtkFlagsC), true);
            else if (tag.Equals("atkflags2"))
                AddTags(typeof(AtkFlagsB), true);
            else if (tag.Equals("atkflags"))
                AddTags(typeof(AtkFlagsA), true);
            else if (tag.Equals("statusFlags"))
                AddTags(typeof(StatusFlags), true);
            else if (tag.Contains("OppHitAnim"))
                AddTags(typeof(OppHitAnim), false);
            else if (tag.Contains("OnHitEffectOnEnemy") || tag.Contains("OnBlockEffectOnEnemy"))
                AddTags(typeof(HitEffectOnEnemy), false);
            else if (tag.Contains("state"))
                AddTags(typeof(BaseActState), false);
            else if (tag.Contains("positionState"))
                AddTags(typeof(PositionState), false);
            else if (tag.Contains("comboState"))
                AddTags(typeof(ComboState), false);
            else if (tag.Contains("inputCode"))
                AddTags(typeof(InputCode), true);
            else if (tag.Contains("subChunkType"))
                AddTags(typeof(SubChunkType), true);
            else if (tag.Contains("boneReferenceId"))
                AddTags(typeof(BoneReferenceId), true);
            else if (tag.Contains("ShtFlagsA"))
                AddTags(typeof(ShtFlagsA), true);
            else if (tag.Contains("ShtFlagsB"))
                AddTags(typeof(ShtFlagsB), true);
            else if (tag.Contains("ShtFlagsC"))
                AddTags(typeof(ShtFlagsC), true);
            else if (tag.Contains("disabled"))
                AddTags(typeof(CmdDisabled), false);
            else if (tag.Contains("disable"))
                AddTags(typeof(SpatkDisabled), false);
            else if (tag.Contains("flags"))
                AddTags(typeof(cmdFlags), true);
            else if (tag.Contains("trapTransition"))
                AddTags(typeof(TrapTransition), true);
            else
            {
                tagsDataGridView.DataSource = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (bDisableUpdate)
            {
                return;
            }
            tablefile.table[animBox.SelectedIndex].name = textBox1.Text;
            RefreshData();
        }

        public static String[] GetEnumListB()
        {
            return Enum.GetNames(typeof(AtkFlagsB));
        }

        public static List<String> GetEnumListA()
        {
            return Enum.GetNames(typeof(AtkFlagsA)).ToList();
        }
        public static List<String> GetEnumListC()
        {
            return Enum.GetNames(typeof(AtkFlagsC)).ToList();
        }

        //TODO: check if this code works / is relevant at all
        private void StructView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvSender = (DataGridView)sender;
            dgvE = e;

            int column = this.structView.CurrentCell.ColumnIndex;
            string columnName = this.structView.SelectedCells[0].ValueType.Name;
            String[] enumList = GetEnumListB();

            var txtBox = e.Control as TextBox;
            String txtBoxTxt = txtBox.Text;
            List<String> txtBoxList = txtBoxTxt.Split(',').ToList();


            //contrast enumList with txtBox value => if it is there, remove everything, add again at the end
            if (enumList.Contains(txtBoxTxt))
            {
                txtBox.Text = "";
                this.structView.CurrentCell.Value = txtBoxTxt + ", ";
            }
            if (column.Equals(valueColumn.Index) && (columnName == "AtkFlagsB"))
            {
                AutoCompleteStringCollection kode = new AutoCompleteStringCollection();
                kode.AddRange(enumList);
                if (txtBox != null)
                {

                    txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    txtBox.AutoCompleteCustomSource = kode;

                    txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }

            }
            if (enumList.Contains(txtBoxTxt))
            {
                txtBox.Text = txtBoxTxt + txtBox.Text;
            }
        }

        private void RefreshAnimBox()
        {
            SuspendLayout();
            animBox.BeginUpdate();
            bDisableUpdate = true;
            importButton.Enabled = true;

            RefreshEditBox();
            bDisableUpdate = false;
            animBox.EndUpdate();
            ResumeLayout();
        }

        private void RefreshEditBox()
        {
            SuspendLayout();
            if (
                animBox.SelectedIndex >= 0
                &&
                animBox.SelectedIndex < tablefile.table.Count
                &&
                tablefile.table[animBox.SelectedIndex].bHasData
                )
            {
                structView.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                structView.Columns[1].DefaultCellStyle.ForeColor = Color.Black;

                exportButton.Enabled = true;
                addSubChunkButton.Enabled = false;
                duplicateButton.Enabled = duplicateButton.Visible;
                upButton.Enabled = false; //up button test toggle is here
                downButton.Enabled = false;
                textBox1.Text = tablefile.table[animBox.SelectedIndex].name;
                textBox1.Enabled = true;
                SetTextConcurrent(tablefile.table[animBox.SelectedIndex].GetData());
                dataTextBox.Text = BitConverter.ToString(tablefile.table[animBox.SelectedIndex].GetData()).Replace("-", "");
                dataTextBox.Text = splitAndBreakEveryNChars(dataTextBox.Text, GetDataTextBoxFormat());
                dataTextBox.WordWrap = true;
                sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;

                Type entryType = tablefile.table[animBox.SelectedIndex].GetType();


                if (tablefile.table[animBox.SelectedIndex] is StructEntryBase)
                {
                    AELogger.Log(entryType.GetGenericArguments()[0].ToString() + " is the newly selected index");
                    /*
                    if (!entryType.GenericTypeArguments[0].Equals(structViewType))
                    {
                        ClearItems();
                        AddItems(entryType.GenericTypeArguments[0]);
                    }
                    */

                    //StructEntry<StatusChunk> entry = (StructEntry<StatusChunk>)tablefile.table[animBox.SelectedIndex];


                    StructEntryBase entry = (StructEntryBase)tablefile.table[animBox.SelectedIndex];


                    ClearItems();
                    UpdateStructEntry(entryType, entry, 0);
                    structView.Enabled = true;
                }
                else if (tablefile.table[animBox.SelectedIndex] is MultiStructEntry)
                {
                    addSubChunkButton.Enabled = true;
                    ClearItems();
                    MultiStructEntry multi = (MultiStructEntry)tablefile.table[animBox.SelectedIndex];
                    int offset = 0;
                    for (int i = 0; i < multi.subEntries.Count; i++)
                    {
                        StructEntryBase entry = multi.subEntries[i];
                        offset += UpdateStructEntry(entry.GetType(), entry, offset, i);
                    }
                    structView.Enabled = true;
                }
                else
                {
                    structView.Enabled = false;
                    structView.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                    structView.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                }

                //structView.DataSource = structValues;
            }
            else
            {
                structView.Enabled = false;
                structView.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                structView.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                exportButton.Enabled = false;
                duplicateButton.Enabled = false;
                upButton.Enabled = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
                dataTextBox.Text = "";
                sizeLabel.Text = "size: N/A";
            }
            tagsDataGridView.Enabled = tagsDataGridView.Visible;

            ResumeLayout();
        }

        private string splitAndBreakEveryNChars(string text2Break, int breakAfterNChars)
        {
            if (breakAfterNChars <= 0)
            {
                return (text2Break);
            }

            return (String.Join("\r\n", text2Break.SplitInParts(breakAfterNChars)));
        }

        private int UpdateStructEntry(Type entryType, StructEntryBase entry, int offset, int structIndex = 0)
        {
            Type generic = entryType.GetGenericArguments()[0];
            AddItems(entryType.GetGenericArguments()[0], structIndex);
            object entrydataobject = entry.GetDataObject();
            FieldInfo[] fieldList = GetFieldInfo(entryType.GetGenericArguments()[0]);
            int numFields = fieldList.Length;
            string temp = null;
            for (int i = 0; i < numFields; i++)
            {
                
                object value = fieldList[i].GetValue(entrydataobject);
                //if (i == 0)
                //{
                //    temp = Tools.GetDescription(Tools.GetEnumValue<SubChunkType>(value.ToString())); //attempt at reading enums descriptions //too slow
                //}
                //structView.Rows[i + offset].Cells[2].Value = ((temp == null) ? temp : value.ToString());
                structView.Rows[i + offset].Cells[2].Value = value.ToString();
                DoHex(fieldList[i].FieldType, i + offset, value);
                //structValues[i] = structFieldInfo[i].GetValue(entry.data).ToString();
            }

            return numFields;
        }

        private void DoHex(Type type, int index, object value)
        {
            if (type.IsEnum)
            {
                structView.Rows[index].Cells[3].Value = Enum.Format(type, value, "X");
            }
            else
            {
                TypeCode code = Type.GetTypeCode(type);
                if (code == TypeCode.Int32)
                {
                    structView.Rows[index].Cells[3].Value = ((Int32)value).ToString("X8");
                }
                else if (code == TypeCode.UInt32)
                {
                    structView.Rows[index].Cells[3].Value = ((UInt32)value).ToString("X8");
                }
                else if (code == TypeCode.Single)
                {
                    structView.Rows[index].Cells[3].Value = BitConverter.ToUInt32(BitConverter.GetBytes((float)value), 0).ToString("X8");
                }
                else
                {
                    structView.Rows[index].Cells[3].Value = "";
                }
            }
        }

        private void structView_DataError(object sender, DataGridViewDataErrorEventArgs ev)
        {
            bDataGridError = true;
            structView.Rows[structView.SelectedCells[0].RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            sizeLabel.Text = "invalid data for " + structView.SelectedCells[0].ValueType.Name;
        }

        private void structView_CellEndEdit(object sender, DataGridViewCellEventArgs ev)
        {
            SaveOldData(animBox.SelectedIndex);
            SetTextConcurrent(tablefile.table[animBox.SelectedIndex].GetData());

            structView.Rows[structView.SelectedCells[0].RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            structView.Rows[structView.SelectedCells[0].RowIndex].Cells[3].Value = "";
            sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;

            int index = ev.RowIndex;
            // FIXME
            /*
            object value = structFieldInfo[index].GetValue(((StructEntryBase)tablefile.table[animBox.SelectedIndex]).GetDataObject());
            if (structFieldInfo[index].FieldType.IsEnum)
            {
                structView.Rows[index].cells[3].Value = Enum.Format(structFieldInfo[index].FieldType, value, "X");
            }
            */
        }

        #region DATATEXTBOX
        // datatextbox stuff
        // YES I KNOW THIS IS EXCESSIVE BUT LOOK I WANTED TO DO IT OKAY
        public Task TextTask;
        public byte[] newText;
        public bool bTextNeedsToBeDone;
        private string formerValue;
        private bool isAdded;
        private int SelectionStart;
        private Control kodeTxt;
        private bool isCommaInput = false;
        private bool isOpeningNewFile;

        public void SetTextConcurrent(byte[] text)
        {
            bTextNeedsToBeDone = true;
            newText = text;
            if (TextTask == null)
            {
                TextTask = new Task(SetText);
                TextTask.Start();
            }
            else if (TextTask.IsCompleted)
            {
                TextTask.Dispose();
                TextTask = new Task(SetText);
                TextTask.Start();
            }
        }

        public void SetText()
        {
            try
            {
                //int oldSelectionStart = dataTextBox.SelectionStart;
                int textSize = 8;

                if (dataTextBox.Width > 1140)
                {
                    textSize = 64;
                }
                else if (dataTextBox.Width > 570)
                {
                    textSize = 32;
                }
                else if (dataTextBox.Width > 285)
                {
                    textSize = 16;
                }
                while (bTextNeedsToBeDone)
                {
                    bTextNeedsToBeDone = false;
                    dataTextBox.Clear();

                    int newTextLength;
                    string[] newLines;
                    lock (newText)
                    {
                        newTextLength = newText.Length;
                        int lineCount = newTextLength / textSize;
                        if (newTextLength % textSize > 0)
                        {
                            lineCount++;
                        }
                        newLines = new string[lineCount];
                    }
                    for (int i = 0; i <= newTextLength / textSize; i++)
                    {
                        lock (newText)
                        {
                            if (bTextNeedsToBeDone)
                            {
                                break;
                            }
                            if (i == newTextLength / textSize)
                            {
                                if (newTextLength % textSize > 0)
                                {
                                    newLines[i] = BitConverter.ToString(newText, i * textSize, newTextLength % textSize).Replace("-", "");
                                }
                            }
                            else
                            {
                                newLines[i] = BitConverter.ToString(newText, i * textSize, textSize).Replace("-", "");
                            }
                        }
                    }

                    if (!bTextNeedsToBeDone)
                    {
                        dataTextBox.Lines = newLines;
                    }
                }
                //dataTextBox.SelectionStart = oldSelectionStart;
                //dataTextBox.Select(oldSelectionStart, 0);
                //dataTextBox.ScrollToCaret();
            }
            catch (Exception e)
            {
                bTextNeedsToBeDone = false;
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
        // end datatextbox stuff
        #endregion  
        // disabled until i find a good way to fix the move up button
        private void upButton_Click(object sender, EventArgs e)
        {
            if (animBox.SelectedIndex <= 0
                   ||
                   animBox.SelectedIndex >= tablefile.table.Count
                   ||
                   !tablefile.table[animBox.SelectedIndex].bHasData)
               {
                   return;
               }
            //
            //int newindex = tablefile.Move(animBox.SelectedIndex, 1);
            int newindex = animBox.SelectedIndex;
            tablefile.Move(newindex,1);
            //(animBox.DataSource(newindex), animBox.Items(oldindex)) = (animBox.Items(oldindex), animBox.Items(newindex));
            RefreshData();
               if (newindex < animBox.Items.Count && newindex >= 0)
               {
                  animBox.SelectedIndex = newindex;
               }
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateName();
        }

        private bool ValidateName()
        {
            bool bStatus = true;
            if (textBox1.Text.Contains(" "))
            {
                string errorText = "text cannot contain empty spaces";
                MessageBox.Show(this, errorText, "SHT Text Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.BackColor = Color.PaleVioletRed;
                textBox1.Focus();
                bStatus = false;
            } else
            {
                textBox1.BackColor = Color.White;
            }
            return bStatus;
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
