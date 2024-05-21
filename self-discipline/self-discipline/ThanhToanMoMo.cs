using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;
using System.Drawing.Drawing2D;

namespace self_discipline
{
    public partial class ThanhToanMoMo : Form
    {
        public ThanhToanMoMo()
        {
            InitializeComponent();
    
        }
        public ThanhToanMoMo(string value, string valuex)
        {
            InitializeComponent();
            this.Tien = value;
            this.TienGiam = valuex;
            
        }

        public string Tien {  get; set; }
         public string TienGiam { get; set; }

        private void btnCreateQR_Click(object sender, EventArgs e)
        {
            //string sotien = "";
            //if (Convert.ToDouble(TienGiam) > 0)
            //{
            //    sotien = (Convert.ToDouble(Tien) - ( Convert.ToDouble(TienGiam))*Convert.ToDouble(Tien)).ToString();
            //}
            //else
            //{
            //    sotien = Tien;
            //}
            string sotien = "100000";
            string name = "Trần Thị Ngọc Cẩn";
        
            var qr_code_text = $"2|99|{name}|0|0|{sotien}";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 310, Height = 250, Margin = 0, PureBarcode = false };
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qr_code_text);
            Bitmap logo =  resizeImage(Properties.Resources.momo ,100,100) as Bitmap;
            Graphics g = Graphics.FromImage(logo);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Width - logo.Height) / 2));
            picAnh.Image = bitmap;
        }
         public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width , new_height);
            Graphics g = Graphics.FromImage ((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}
