using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMatrix.net;

namespace BarcodeReader
{
    public partial class frmBarcodeReader : Form
    {
        public frmBarcodeReader()
        {
            InitializeComponent();
        }

        private string DecodeText(string sFileName)
        {
            DmtxImageDecoder decoder = new DmtxImageDecoder();
            System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(sFileName);
            List<string> oList = decoder.DecodeImage(oBitmap);

            StringBuilder sb = new StringBuilder();
            sb.Length = 0;
            foreach (string s in oList)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}
