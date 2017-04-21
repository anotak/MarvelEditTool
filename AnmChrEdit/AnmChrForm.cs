using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnmChrEdit
{
    public partial class AnmChrForm : Form
    {
        public bool bError;

        public AnmChrForm()
        {
            bError = false;
            InitializeComponent();
        }
    }
}
