using ComClassLib.core;
using Project2C.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2C.UI {
    public partial class Form1 : Form {
        byte[] img;
        public Form1(byte[] _img) {
            InitializeComponent();
            img = _img;

        }

        private void button1_Click(object sender, EventArgs e) {
            imgView.Image= JpegCompress.Decompress(img,(uint)img.Length);
            imgView.Refresh();
        }
    }
}
