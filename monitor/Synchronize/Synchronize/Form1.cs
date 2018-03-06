using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Synchronize
{
    public partial class Form1 : Form
    {
        XmlDocument G_Xml;
        string G_XmlUrl;
        bool G_Complete = false;
        string G_TargetPath;
        string G_LocalPath;
        string G_SyncTime;

        public Form1()
        {
            InitializeComponent();
            initStyle();
            G_XmlUrl = Environment.CurrentDirectory + @"\config.xml";
            G_Xml = new XmlDocument();
            G_Xml.Load(G_XmlUrl);
            LoadXml();

            btn_All.Click += btnAllClick;
            btn_Part.Click += btnPartClick;
        }

        private void btnAllClick(object sender, EventArgs e)
        {
            G_TargetPath = tbx_Target.Text;
            G_LocalPath = tbx_Local.Text;
            if (!Directory.Exists(G_TargetPath))
            {
                return;
            }
            SaveXml();
            Thread t1 = new Thread(SyncAll);
            t1.Start();
        }

        private void btnPartClick(object sender, EventArgs e)
        {
            G_TargetPath = tbx_Target.Text;
            G_LocalPath = tbx_Local.Text;
            if (!Directory.Exists(G_TargetPath))
            {
                return;
            }
            SaveXml();
            Thread t1 = new Thread(SyncByDateTime);
            t1.Start();

        }
        private void SyncAll(string targetPath, string localPath, bool copyFile = true)
        {
            DirectoryInfo targetDirectory = new DirectoryInfo(targetPath);
            foreach (DirectoryInfo dir in targetDirectory.GetDirectories())
            {
                string t1 = Path.Combine(localPath, dir.Name);
                CopyDir(dir.FullName, t1);
                SyncAll(dir.FullName, t1, copyFile);
            }
            if (copyFile)
            {
                foreach (FileInfo file in targetDirectory.GetFiles())
                {
                    string t1 = Path.Combine(localPath, file.Name);
                    CopyFile(file.FullName, t1);
                }
            }
        }

        private void SyncAll()
        {
            btnEnable(btn_All, false);
            print("同步中", true, true);
            G_Complete = false;
            new Thread(run1).Start();
            //Thread.Sleep(5000);
            G_SyncTime = DateTime.Now.ToString();
            SaveXml();
            SyncAll(G_TargetPath, G_LocalPath);
            G_Complete = true;
            btnEnable(btn_All, true);
        }

        private void SyncByDateTime()
        {
            btnEnable(btn_Part, false);
            print("同步中", true, true);
            G_Complete = false;
            new Thread(run1).Start();
            //Thread.Sleep(5000);
            string logPath = Path.Combine(G_TargetPath, "log.txt");
            FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader log = new StreamReader(fs, UnicodeEncoding.UTF8);
            string line;
            List<string> list = new List<string>();
            DateTime targetTime;
            DateTime localTime;
            if (string.IsNullOrWhiteSpace(G_SyncTime))
            {
                localTime = DateTime.Now;
            }
            else
            {
                localTime = DateTime.Parse(G_SyncTime);
            }
            G_SyncTime = DateTime.Now.ToString();
            SaveXml();
            SyncAll(G_TargetPath, G_LocalPath, false);
            
            try
            {
                while ((line = log.ReadLine()) != null)
                {
                    int i1 = line.IndexOf(",");
                    string t1 = line.Substring(0, i1);
                    targetTime = DateTime.Parse(t1);
                    if (targetTime >= localTime)
                    {
                        list.Add(line.Substring(i1 + 1));
                    }
                }
                foreach (string s in list)
                {
                    string remotePath = G_TargetPath + s;
                    string localPath = G_LocalPath + s;
                    CopyFile(remotePath, localPath);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (log != null)
                    log.Close();
                G_Complete = true;
                btnEnable(btn_Part, true);
            }
        }

        private void CopyDir(string remote, string local)
        {
            if(Directory.Exists(remote) && !Directory.Exists(local))
            {
                Directory.CreateDirectory(local);
            }
        }

        private void CopyFile(string remote, string local)
        {
            if (File.Exists(remote))
            {
                File.Copy(remote, local, true);
                print("\r\n--同步文件：" + local);
            }
        }

        private void SaveXml()
        {
            foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
            {
                switch (xmlDoc.Name)
                {
                    case "target":
                        xmlDoc.InnerText = tbx_Target.Text;
                        G_TargetPath = tbx_Target.Text;
                        break;
                    case "local":
                        xmlDoc.InnerText = tbx_Local.Text;
                        G_LocalPath = tbx_Local.Text;
                        break;
                    case "time":
                        xmlDoc.InnerText = G_SyncTime;
                        break;
                }
            }
            G_Xml.Save(G_XmlUrl);
        }

        private void LoadXml()
        {
            foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
            {
                switch (xmlDoc.Name)
                {
                    case "target":
                        tbx_Target.Text = xmlDoc.InnerText;
                        G_TargetPath = xmlDoc.InnerText;
                        break;
                    case "local":
                        tbx_Local.Text = xmlDoc.InnerText;
                        G_LocalPath = xmlDoc.InnerText;
                        break;
                    case "time":
                        G_SyncTime = xmlDoc.InnerText;
                        break;
                }
            }
        }

        private void btnEnable(Button button, bool enable)
        {
            Action d = () =>
            {
                if (button.Name == "btn_All" && enable)
                {
                    btn_All.Text = "全部同步";
                    btn_All.Enabled = enable;
                    btn_Part.Enabled = enable;
                }
                if (button.Name == "btn_All" && !enable)
                {
                    btn_All.Text = "同步中...";
                    btn_All.Enabled = enable;
                    btn_Part.Enabled = enable;
                }
                if (button.Name == "btn_Part" && enable)
                {
                    btn_Part.Text = "部分同步";
                    btn_Part.Enabled = enable;
                    btn_All.Enabled = enable;
                }
                if (button.Name == "btn_Part" && !enable)
                {
                    btn_Part.Text = "同步中...";
                    btn_Part.Enabled = enable;
                    btn_All.Enabled = enable;
                }
                tbx_Target.Enabled = enable;
                tbx_Local.Enabled = enable;
                tbx_Filter.Enabled = enable;
            };
            button.Invoke(d);
        }

        public void print(string p_message, bool p_Clear = false, bool p_FirstLine = false, bool p_Complete = false)
        {
            if (rtb_log.InvokeRequired)
            {
                if (p_Clear)
                {
                    Action messageDelegate1 = () => { rtb_log.Clear(); };
                    rtb_log.Invoke(messageDelegate1);
                }
                if (p_FirstLine)
                {
                    Action<string> messageDelegate1 = (x) =>
                    {
                        int length = p_message.Length;
                        if (!p_Complete)
                        {
                            if (rtb_log.Lines.Length > 0)
                            {
                                if (p_message.Length == 9)
                                {
                                    rtb_log.Select(0, 9);
                                    rtb_log.SelectedText = "同步中.";
                                }
                                else
                                {
                                    rtb_log.Select(0, length);
                                    rtb_log.SelectedText = p_message + ".";
                                }
                            }
                            else
                            {
                                rtb_log.AppendText(x);
                            }
                        }
                        else
                        {
                            rtb_log.Select(0, rtb_log.Lines[0].Length);
                            rtb_log.SelectedText = p_message;
                        }
                    };
                    rtb_log.Invoke(messageDelegate1, p_message);
                }
                if (!p_FirstLine)
                {
                    Action<string> messageDelegate = (x) => { rtb_log.AppendText(x); };
                    rtb_log.Invoke(messageDelegate, p_message);
                }
            }
            else
            {
                rtb_log.AppendText(p_message);
            }
        }

        private void run1()
        {
            while (!G_Complete)
            {
                Thread.Sleep(1000);
                string s = "";
                Action messageDelegate = () => { s = rtb_log.Lines[0]; };
                rtb_log.Invoke(messageDelegate);
                print(s, false, true);
            }
            print("--同步完成", false, true, true);
        }

        private void initStyle()
        {
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.BackColor = Color.FromArgb(0, 172, 193);
            label2.ForeColor = Color.FromArgb(255, 255, 255);
            label2.BackColor = Color.FromArgb(0, 172, 193);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label3.BackColor = Color.FromArgb(0, 172, 193);

            btn_All.ForeColor = Color.FromArgb(255, 255, 255);
            btn_All.BackColor = Color.FromArgb(121, 134, 203);
            btn_All.FlatAppearance.BorderColor = Color.FromArgb(121, 134, 203);
            btn_All.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 73, 171);
            btn_All.FlatAppearance.MouseDownBackColor = Color.FromArgb(57, 73, 171);
            btn_Part.ForeColor = Color.FromArgb(255, 255, 255);
            btn_Part.BackColor = Color.FromArgb(121, 134, 203);
            btn_Part.FlatAppearance.BorderColor = Color.FromArgb(121, 134, 203);
            btn_Part.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 73, 171);
            btn_Part.FlatAppearance.MouseDownBackColor = Color.FromArgb(57, 73, 171);
        }
    }
}
