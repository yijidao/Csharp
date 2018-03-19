using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ghostscript.NET.Rasterizer;
using Ghostscript.NET.Processor;
using System.IO;
using System.Drawing.Imaging;
using ZXing;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string G_DirPath;

        public Form1()
        {
            InitializeComponent();
            initStyle();
            btn_Todo.Click += TodoClick;
        }

        private void TodoClick(object sender, EventArgs e)
        {
            G_DirPath = tb_Path.Text;
            btn_Todo.Enabled = false;
            tb_Path.Enabled = false;
            btn_Todo.Text = "报工中";
            Thread t = new Thread(CreatePicture);
            t.Start();
        }

        private void CreatePicture()
        {
            while (true)
            {
                //string picPath = Environment.CurrentDirectory + @"\picture";
                while (Directory.GetFiles(G_DirPath).Length > 0)
                {
                    string dir = Directory.GetFiles(G_DirPath)[0];
                    FileStream fs = new FileStream(dir, FileMode.Open);
                    using (GhostscriptRasterizer r = new GhostscriptRasterizer())
                    {
                        r.Open(fs);
                        for (int i = 0; i < r.PageCount; i++)
                        {
                            Image image = r.GetPage(200, 200, i + 1);
                            Bitmap bitmap = new Bitmap(image);
                            BarcodeReader reader = new BarcodeReader();
                            Result result = reader.Decode(bitmap);
                            if(result != null)
                            {
                                print("\r\n--" + result.Text + ",page: " + (i + 1));
                            }
                        }
                    }
                    fs.Close();
                    File.Delete(dir);
                }
            }
        }

        private void print(string message)
        {
            if (rtb_Log.InvokeRequired)
            {
                Action<string> d1 = (x) => { rtb_Log.AppendText(x); };
                rtb_Log.Invoke(d1, message);
            }
        }

        private void initStyle()
        {
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.BackColor = Color.FromArgb(0, 172, 193);

            btn_Todo.ForeColor = Color.FromArgb(255, 255, 255);
            btn_Todo.BackColor = Color.FromArgb(121, 134, 203);
            btn_Todo.FlatAppearance.BorderColor = Color.FromArgb(121, 134, 203);
            btn_Todo.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 73, 171);
            btn_Todo.FlatAppearance.MouseDownBackColor = Color.FromArgb(57, 73, 171);
        }
    }
}
