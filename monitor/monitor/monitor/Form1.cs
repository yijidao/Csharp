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

namespace monitor
{
    public partial class Form1 : Form
    {
        bool G_Enable = false;
        string G_XmlPath;
        XmlDocument G_Xml;
        FileSystemWatcher G_Fs = new FileSystemWatcher();
        WatcherTimer watcher;
        public static int dirLength;

        public Form1()
        {
            InitializeComponent();
            initStyle();
            watcher = new WatcherTimer(OnChanged);
            btn_Start.Click += btnStartClick;
            G_XmlPath = Environment.CurrentDirectory + @"\config.xml";
            G_Xml = new XmlDocument();
            G_Xml.Load(G_XmlPath);
            foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
            {
                switch (xmlDoc.Name)
                {
                    case "monitor":
                        tbx_Monitor.Text = xmlDoc.InnerText; break;
                }
            }
        }

        private void btnStartClick(object sender, EventArgs e)
        {
            if (!G_Enable)
            {
                foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
                {
                    switch (xmlDoc.Name)
                    {
                        case "monitor":
                            xmlDoc.InnerText = tbx_Monitor.Text; break;
                    }
                }
                G_Xml.Save(G_XmlPath);
                dirLength = tbx_Monitor.Text.Length;
                monitor(tbx_Monitor.Text, tbx_Filter.Text);
            } else
            {

            }
        }

        private void monitor(string monitorPath, string filter)
        {
            try
            {
                tbx_Monitor.Enabled = false;
                tbx_Filter.Enabled = false;
                btn_Start.Text = "监控中...";
                btn_Start.Enabled = false;
                G_Fs.Path = monitorPath;
                G_Fs.Filter = filter;
                G_Fs.EnableRaisingEvents = true;
                G_Fs.IncludeSubdirectories = true;
                G_Fs.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.CreationTime
                    | NotifyFilters.LastWrite;
                //G_Fs.NotifyFilter = NotifyFilters.LastWrite;

                //G_Fs.Created += new FileSystemEventHandler(OnProcess);
                //G_Fs.Changed += new FileSystemEventHandler(OnProcess);
                //G_Fs.Deleted += new FileSystemEventHandler(OnProcess);
                //G_Fs.Renamed += new RenamedEventHandler(OnChanged);
                G_Fs.Changed += watcher.OnFileChanged;
                G_Fs.Created += watcher.OnFileChanged;

            }
            finally
            {

            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if(e.FullPath != @"\log.txt")
            {
                string l_Text = "null";

                l_Text = string.Format(@"{0},{1}", DateTime.Now, e.FullPath);
                print(l_Text + "\r\n");
                Write(tbx_Monitor.Text, l_Text);
            }
        }

        private void Write(string logPath, string message)
        {
            logPath = logPath + @"\log.txt";
            FileStream l_Fs = new FileStream(logPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //if (File.Exists(logPath))
            //{
            //    FileInfo f = new FileInfo(logPath);
            //    if(f.Attributes != FileAttributes.Hidden)
            //        File.SetAttributes(logPath, FileAttributes.Hidden);
            //}
            StreamWriter l_Sw = new StreamWriter(l_Fs);
            try
            {
                l_Sw.WriteLine(message);
            }
            finally
            {
                l_Sw.Flush();
                l_Fs.Flush();
                l_Sw.Close();
                l_Fs.Close();
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
            label2.ForeColor = Color.FromArgb(255, 255, 255);
            label2.BackColor = Color.FromArgb(0, 172, 193);

            btn_Start.ForeColor = Color.FromArgb(255, 255, 255);
            btn_Start.BackColor = Color.FromArgb(121, 134, 203);
            btn_Start.FlatAppearance.BorderColor = Color.FromArgb(121, 134, 203);
            btn_Start.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 73, 171);
            btn_Start.FlatAppearance.MouseDownBackColor = Color.FromArgb(57, 73, 171);
        }
    }
}
