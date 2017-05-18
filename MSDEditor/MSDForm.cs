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

namespace MSDEditor
{
    public partial class MSDForm : Form
    {
        public static bool bError = false;

        public MSDForm()
        {
            InitializeComponent();
            Text += ", build " + GetCompileDate();
            AELogger.Log(Text);

            MSDFile file = MSDFile.LoadFile(@"C:\games\mvc3\arctool\liccmn_msg\ui\font\msg\msg_chrsel_assist_chrsel_en.5B55F5B1");
            file.WriteFile(@"C:\games\mvc3\arctool\liccmn_msg\ui\font\msg\msg_chrsel_assist_chrsel_en_2.5B55F5B1");
        }

        public static string GetCompileDate()
        {
            System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2).ToString();
        }
    }
}
