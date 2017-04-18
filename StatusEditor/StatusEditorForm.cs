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
        public static bool bError;
        public static bool bDataGridError;
        public string FilePath;
        public TableFile tablefile;
        public List<string> tableNames;
        public bool bDisableUpdate;
        public string ImportPath;
        public FieldInfo[] structFieldInfo;
        public List<List<string>> structValues;
        public int previousSelectedIndex;
        public Type structViewType;
        public Type structViewEntryType;

        public StatusEditorForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);
            FilePath = String.Empty;
            bDisableUpdate = true;
            previousSelectedIndex = 0;
            bDataGridError = false;
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

        public void AddItems(Type structtype)
        {
            if (structViewType == structtype)
            {
                return;
            }
            //structView.Columns.Clear();
            structView.Rows.Clear();

            structFieldInfo = structtype.GetFields();
            structValues = new List<List<string>>();
            for (int i = 0; i < structFieldInfo.Length; i++)
            {
                structView.Rows.Add(structFieldInfo[i].Name);
                if (structFieldInfo[i].FieldType == typeof(float))
                {
                    structView.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                structView.Rows[i].Cells[1].ValueType = structFieldInfo[i].FieldType;
                //structValues.Add(new List<string>(2));
                //structValues[i].Add(structFieldInfo[i].Name);
                //structValues[i].Add(string.Empty);
                //AELogger.Log(structFieldInfo[i].Name.ToString());
            }
            //structView.DataSource = structValues;

            structViewEntryType = typeof(StructEntry<>).MakeGenericType(structtype);

            structViewType = structtype;
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
                openFile.Filter = "Supported Data (*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504)|*.ati;*.227A8048;*.chs;*.3C41466B;*.cba;*.3C6EA504|BaseAct Files (*.cba;*.3C6EA504)|*.cba;*.3C6EA504|AtkInfo Files (*.ati;*.227A8048)|*.ati;*.227A8048|CHS Files (*.chs;*.3C41466B)|*.chs;*.3C41466B|All files (*.*)|*.*";
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

        private void extendButton_Click(object sender, EventArgs e)
        {
            tablefile.Extend();
            RefreshData();
            if (animBox.TopIndex < animBox.Items.Count - 2)
            {
                animBox.TopIndex++;
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
            animBox.TopIndex = top;
            bDisableUpdate = false;
        }

        private void SaveOldData(int index)
        {
            //if (!(tablefile.table[index] is StatusEntry))
            Type entryType = tablefile.table[index].GetType();
            AELogger.Log(entryType.GenericTypeArguments[0].ToString() + " is the saveolddata");
            if (!(tablefile.table[index] is StructEntryBase) && entryType.GenericTypeArguments[0].Equals(structViewType))
            {
                MessageBox.Show("warning: there might be some kind error, attempted write of incorrect data, you probably should make backups and save and report this bug with the logfile");
                AELogger.Log("warning saving attempted of non correct data");
                return;
            }
            //Object entrydata = ((StructEntry)tablefile.table[index]).data; // turn it into a reference so SetValue works

            Object entrydata = ((StructEntryBase)tablefile.table[index]).GetDataObject(); // turn it into a reference so SetValue works
            for (int i = 0; i < structFieldInfo.Length; i++)
            {

                //structView.Rows[i].Cells[1].Value = structFieldInfo[i].GetValue(entry.data).ToString();

                // this part isnt needed anymore bc of magic with dataviewgrid
                /*
                if (structFieldInfo[i].FieldType.IsEnum)
                {// check if enum
                    structFieldInfo[i].SetValue(entrydata, Enum.Parse(structFieldInfo[i].FieldType, (string)structView.Rows[i].Cells[1].Value));
                }
                else
                */
                {
                    try
                    {
                        Convert.ChangeType(structView.Rows[i].Cells[1].Value, structFieldInfo[i].FieldType);
                        //AELogger.Log(structFieldInfo[i].ToString() + " IS " + structView.Rows[i].Cells[1].Value + " VS " + Convert.ChangeType(structView.Rows[i].Cells[1].Value, structFieldInfo[i].FieldType));
                        //AELogger.Log(structFieldInfo[i].GetValue(entrydata).ToString());
                        structFieldInfo[i].SetValue(entrydata, Convert.ChangeType(structView.Rows[i].Cells[1].Value, structFieldInfo[i].FieldType));
                        //AELogger.Log(structFieldInfo[i].GetValue(entrydata).ToString());
                    }
                    catch (Exception e)
                    {
                        AELogger.Log("failed type: val " + structFieldInfo[i].ToString() + " - value " + structView.Rows[i].Cells[1].Value);


                        AELogger.Log("Exception: " + e.Message);

                        AELogger.Log("Exception: " + e.StackTrace);
                    }
                }
            }

            ((StructEntryBase)tablefile.table[index]).SetDataObject(entrydata);
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
            if (
                animBox.SelectedIndex >= 0
                &&
                animBox.SelectedIndex < tablefile.table.Count
                &&
                tablefile.table[animBox.SelectedIndex].bHasData
                &&
                tablefile.table[animBox.SelectedIndex] is StructEntryBase
                )
            {
                structView.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                structView.Columns[1].DefaultCellStyle.ForeColor = Color.Black;
                Type entryType = tablefile.table[animBox.SelectedIndex].GetType();
                AELogger.Log(entryType.GenericTypeArguments[0].ToString() + " is the newly selected index");
                if (!entryType.GenericTypeArguments[0].Equals(structViewType))
                {
                    AddItems(entryType.GenericTypeArguments[0]);
                }

                //StructEntry<StatusChunk> entry = (StructEntry<StatusChunk>)tablefile.table[animBox.SelectedIndex];
                StructEntryBase entry = (StructEntryBase)tablefile.table[animBox.SelectedIndex];
                exportButton.Enabled = true;
                SetTextConcurrent(tablefile.table[animBox.SelectedIndex].GetData());
                //dataTextBox.Text = BitConverter.ToString(tablefile.table[animBox.SelectedIndex].data).Replace("-","");
                sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;

                object entrydataobject = entry.GetDataObject();
                for (int i = 0; i < structFieldInfo.Length; i++)
                {
                    object value = structFieldInfo[i].GetValue(entrydataobject);
                    structView.Rows[i].Cells[1].Value = value.ToString();
                    if (structFieldInfo[i].FieldType.IsEnum)
                    {
                        structView.Rows[i].Cells[2].Value = Enum.Format(structFieldInfo[i].FieldType, value, "X");
                    }
                    /*else
                    {
                        TypeCode code = Type.GetTypeCode(structFieldInfo[i].FieldType);
                        if (code >= TypeCode.SByte && code <= TypeCode.UInt64)
                        {
                            structView.Rows[i].Cells[2].Value = ((Int64)Convert.ChangeType(value, typeof(Int64))).ToString("X");
                        }
                        else if (code >= TypeCode.Single && code <= TypeCode.Decimal)
                        {
                            structView.Rows[i].Cells[2].Value = ((UInt64)Convert.ChangeType(value, typeof(UInt64))).ToString("X");
                        }
                        else
                        {
                            structView.Rows[i].Cells[2].Value = "";
                        }
                    }*/
                    //structValues[i] = structFieldInfo[i].GetValue(entry.data).ToString();
                }
                structView.Enabled = true;
                //structView.DataSource = structValues;
            }
            else
            {
                structView.Enabled = false;
                structView.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                structView.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                exportButton.Enabled = false;
                dataTextBox.Text = "";
                sizeLabel.Text = "size: N/A";
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
            sizeLabel.Text = "size: " + tablefile.table[animBox.SelectedIndex].size;

            int index = ev.RowIndex;
            object value = structFieldInfo[index].GetValue(((StructEntryBase)tablefile.table[animBox.SelectedIndex]).GetDataObject());
            if (structFieldInfo[index].FieldType.IsEnum)
            {
                structView.Rows[index].Cells[2].Value = Enum.Format(structFieldInfo[index].FieldType, value, "X");
            }
        }


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
                int oldSelectionStart = dataTextBox.SelectionStart;
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
                dataTextBox.SelectionStart = oldSelectionStart;
                //dataTextBox.Select(oldSelectionStart, 0);
                dataTextBox.ScrollToCaret();
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
    }
}
