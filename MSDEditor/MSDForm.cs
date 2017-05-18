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

namespace MSDEditor
{
    public partial class MSDForm : Form
    {
        public static bool bError = false;
        public MSDFile file;
        string FilePath;

        public MSDForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);
            FilePath = string.Empty;
            /*
            MSDFile file = MSDFile.LoadFile(@"C:\games\mvc3\arctool\liccmn_msg\ui\font\msg\msg_chrsel_assist_chrsel_en.5B55F5B1");
            file.WriteFile(@"C:\games\mvc3\arctool\liccmn_msg\ui\font\msg\msg_chrsel_assist_chrsel_en_2.5B55F5B1");
            */
        }

        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString();
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

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                //openFile.DefaultExt = "bcm";
                // The Filter property requires a search string after the pipe ( | )
                openFile.Filter = "MSD Files (*.msd;*.5B55F5B1)|*.msd;*.5B55F5B1|All files (*.*)|*.*";
                openFile.ShowDialog();
                if (openFile.FileNames.Length > 0)
                {
                    //TableFile newTable = TableFile.LoadFile(openFile.FileNames[0], typeof(StatusEntry));
                    file = MSDFile.LoadFile(openFile.FileNames[0]);

                    if (file == null)
                    {
                        throw new Exception("load failed for some reason?");
                    }

                    int count = file.data.Count;
                    if (count <= 0)
                    {
                        throw new Exception("empty table??");
                    }

                    SuspendLayout();
                    
                    saveButton.Enabled = true;
                    openButton.Enabled = false;
                    FilePath = openFile.FileNames[0];

                    Text += " :: " + openFile.FileNames[0];
                    filenameLabel.Text = openFile.FileNames[0];
                    for (int i = 0; i < count; i++)
                    {
                        stringView.Rows.Add(file.data[i]);
                    }
                    stringView.Enabled = true;
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

                        for (int i = 0; i < stringView.Rows.Count; i++)
                        {
                            file.data[i] = stringView.Rows[i].Cells[0].Value.ToString();
                        }

                        file.WriteFile(saveFileDialog1.FileNames[0]);
                    }
                }
            }
        }
    }
}
