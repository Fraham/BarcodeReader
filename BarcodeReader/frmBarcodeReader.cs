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
                Console.WriteLine(s);
            }

            return sb.ToString();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();

                openDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" +
                    "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    lblBarcodeText.Text = DecodeText(openDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}
