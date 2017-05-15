using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MarvelData;
using System.Reflection;

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

        public StatusEditorForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);
            FilePath = String.Empty;
            ImportPath = String.Empty;
            bDisableUpdate = true;
            previousSelectedIndex = 0;
            structView.Rows.Clear();
            AddItems(typeof(StatusChunk));

            structView.DataError += structView_DataError;
            structView.CellEndEdit += structView_CellEndEdit;
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
                else if (fieldList[i].Name == "subChunkType")
                {
                    structView.Rows[i + offset].DefaultCellStyle.BackColor = Color.LightGray;
                }
                structView.Rows[i + offset].Cells[2].ValueType = fieldList[i].FieldType;
                //AELogger.Log(structFieldInfo[i].Name.ToString());
            }

            structViewEntryType = typeof(StructEntry<>).MakeGenericType(structtype);

            structViewType = structtype;
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
            else if (keyData == (Keys.Control | Keys.A))
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
                //openFile.DefaultExt = "bcm";
                // The Filter property requires a search string after the pipe ( | )
                openFile.Filter = "Supported Data (*.ccm;*.28DD8317;*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504;*.csp;*.52A8DBF6)|*.ccm;*.28DD8317;*.csp;*.52A8DBF6;*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504|Cmdcombo Files (*.ccm;*.28DD8317)|*.ccm;*.28DD8317|Cmdspatk Files (*.csp;*.52A8DBF6)|*.csp;*.52A8DBF6|BaseAct Files (*.cba;*.3C6EA504)|*.cba;*.3C6EA504|AtkInfo Files (*.ati;*.227A8048)|*.ati;*.227A8048|Status Files (*.chs;*.3C41466B)|*.chs;*.3C41466B|All files (*.*)|*.*";
                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    //TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], typeof(StatusEntry));
                    TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], true, typeof(StructEntry<StatusChunk>), 848);
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
                    duplicateButton.Enabled = false;
                    upButton.Enabled = false;
                    exportButton.Enabled = false;
                    addSubChunkButton.Enabled = false;
                    openButton.Enabled = false;
                    animBox.Enabled = true;
                    extendButton.Enabled = true;
                    sizeLabel.Text = count + " entries loaded";
                    FilePath = openFile.FileNames[0];
                    RefreshData();
                    Text += " :: " + openFile.FileNames[0];
                    filenameLabel.Text = openFile.FileNames[0];
                    animBox.SelectedIndex = 0;
                    structView.Focus();
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
                openFile.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";

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
                saveFileDialog1.Filter = "mvc3 table data files (*.mvc3data)|*.mvc3data|All files (*.*)|*.*";
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
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                saveFileDialog1.FileName = tablefile.table[animBox.SelectedIndex].GetFilename() + ".mvc3data";

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
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count
                ||
                !tablefile.table[animBox.SelectedIndex].bHasData)
            {
                return;
            }
            tablefile.Duplicate(animBox.SelectedIndex);
            RefreshData();
            if (animBox.TopIndex < animBox.Items.Count - 2)
            {
                animBox.TopIndex++;
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


        private void addSubChunkButton_Click(object sender, EventArgs e)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count
                ||
                !tablefile.table[animBox.SelectedIndex].bHasData
                ||
                !(tablefile.table[animBox.SelectedIndex] is MultiStructEntry))
            {
                return;
            }

            MultiStructEntry entry = (MultiStructEntry)tablefile.table[animBox.SelectedIndex];
            SaveOldData(animBox.SelectedIndex);
            entry.AddSubChunk();
            animBox_SelectedIndexChanged(null, null);
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

        private void SaveOldData(int index)
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
                else
                {
                    MessageBox.Show("warning: there might be some kind error, attempted write of incorrect data, you probably should make backups and save and report this bug with the logfile");
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
                duplicateButton.Enabled = true;
                upButton.Enabled = true;
                SetTextConcurrent(tablefile.table[animBox.SelectedIndex].GetData());
                //dataTextBox.Text = BitConverter.ToString(tablefile.table[animBox.SelectedIndex].data).Replace("-","");
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
                dataTextBox.Text = "";
                sizeLabel.Text = "size: N/A";
            }
            ResumeLayout();
        }

        private int UpdateStructEntry(Type entryType, StructEntryBase entry, int offset, int structIndex = 0)
        {
            Type generic = entryType.GetGenericArguments()[0];
            AddItems(entryType.GetGenericArguments()[0], structIndex);
            object entrydataobject = entry.GetDataObject();
            FieldInfo[] fieldList = GetFieldInfo(entryType.GetGenericArguments()[0]);
            int numFields = fieldList.Length;
            for (int i = 0; i < numFields; i++)
            {
                object value = fieldList[i].GetValue(entrydataobject);
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

        private void upButton_Click(object sender, EventArgs e)
        {
            if (animBox.SelectedIndex < 0
                ||
                animBox.SelectedIndex >= tablefile.table.Count
                ||
                !tablefile.table[animBox.SelectedIndex].bHasData)
            {
                return;
            }
            int newindex = tablefile.Move(animBox.SelectedIndex,1);
            RefreshData();
            if (newindex < animBox.Items.Count && newindex >= 0)
            {
                animBox.SelectedIndex = newindex;
            }
        }
    }
}
