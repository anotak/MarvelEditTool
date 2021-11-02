using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnmChrEdit
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently there are no more images");
        }
    }
}
