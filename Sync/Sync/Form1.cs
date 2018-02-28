using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
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

namespace Sync
{
    public partial class FrmSync : Form
    {
        XmlDocument G_Xml;
        string G_XmlUrl;
        bool G_Complete = false;

        public FrmSync()
        {
            InitializeComponent();
            G_XmlUrl = Environment.CurrentDirectory + @"\cf.xml";
            G_Xml = new XmlDocument();
            G_Xml.Load(G_XmlUrl);
            foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
            {
                switch (xmlDoc.Name)
                {
                    case "SourcePath":
                        tbx_Source.Text = xmlDoc.InnerText; break;
                    case "DestinationPath":
                        tbx_Destination.Text = xmlDoc.InnerText; break;
                }
            }
            btn_Sync.Click += OnClick;

            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.BackColor = Color.FromArgb(0, 172, 193);
            label2.ForeColor = Color.FromArgb(255, 255, 255);
            label2.BackColor = Color.FromArgb(0, 172, 193);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label3.BackColor = Color.FromArgb(0, 172, 193);

            btn_Sync.ForeColor = Color.FromArgb(255, 255, 255);
            btn_Sync.BackColor = Color.FromArgb(121, 134, 203);
            btn_Sync.FlatAppearance.BorderColor = Color.FromArgb(121, 134, 203);
            btn_Sync.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 73, 171);
            btn_Sync.FlatAppearance.MouseDownBackColor = Color.FromArgb(57, 73, 171);

            rtx_Log.AppendText("请配置好源目录和目标目录后，点击开始同步进行同步...");
        }

        public void Sync()
        {
            print("同步中", true, true);
            G_Complete = false;
            new Thread(run1).Start();


            setBtnSyncEnable(false);
            string l_SourcePath = tbx_Source.Text;
            string l_DistinationPath = tbx_Destination.Text;
            string l_FilterTbx = tbx_Filter.Text;
            string[] l_FilterTypeArray;
            l_FilterTypeArray = l_FilterTbx.Split(',');
            if (string.IsNullOrWhiteSpace(l_SourcePath) || string.IsNullOrWhiteSpace(l_DistinationPath) ||
                !Directory.Exists(l_SourcePath) || !Directory.Exists(l_DistinationPath))
            {
                print("无效目录");
                setBtnSyncEnable(true);
                return;
            }

            try
            {
                FileSyncOptions l_Options = FileSyncOptions.ExplicitDetectChanges | FileSyncOptions.RecycleConflictLoserFiles |
                    FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates;
                FileSyncScopeFilter l_Filter = new FileSyncScopeFilter();

                foreach (string filterType in l_FilterTypeArray)
                {
                    if(!string.IsNullOrWhiteSpace(filterType.Trim()))
                    {
                        l_Filter.FileNameExcludes.Add(filterType.Trim());
                    }
                }
                SyncFileSystemReplicasOneWay1(l_SourcePath, l_DistinationPath, l_Filter, l_Options);
            }
            catch (Exception e)
            {
                //rtx_Log.AppendText("\nException from File Sync Provider:\n" + e.ToString());
                print("\nException from File Sync Provider:\n" + e.Message);
            }
        }

        public void SyncFileSystemReplicasOneWay1(string p_SourceReplicaRootPath, string p_DestinationReplicaRootPath, FileSyncScopeFilter p_Filter, FileSyncOptions p_Options)
        {
            FileSyncProvider l_SourceProvider = null;
            FileSyncProvider l_DestinationProvider = null;

            try
            {

                l_SourceProvider = new FileSyncProvider(p_SourceReplicaRootPath, p_Filter, p_Options);
                l_DestinationProvider = new FileSyncProvider(p_DestinationReplicaRootPath, p_Filter, p_Options);

                l_DestinationProvider.AppliedChange += OnAppliedChange;
                l_DestinationProvider.SkippedChange += OnSkippedChange;
                //l_DestinationProvider.DetectedChanges += OnDetectedChange;

                SyncCallbacks l_DestinationCallbacks = l_DestinationProvider.DestinationCallbacks;
                l_DestinationCallbacks.ItemConflicting += OnItemConflicting;
                l_DestinationCallbacks.ItemConstraint += OnItemConstraint;

                l_SourceProvider.DetectChanges();
                l_DestinationProvider.DetectChanges();

                SyncOrchestrator l_Agent = new SyncOrchestrator();
                l_Agent.LocalProvider = l_DestinationProvider;
                l_Agent.RemoteProvider = l_SourceProvider;
                l_Agent.Direction = SyncDirectionOrder.Download;

                //rtx_Log.AppendText("\r\n同步文件到：" + l_DestinationProvider.RootDirectoryPath + "");
                print("\r\n同步文件到：" + l_DestinationProvider.RootDirectoryPath);
                l_Agent.Synchronize();
            }
            finally
            {
                if (l_SourceProvider != null)
                    l_SourceProvider.Dispose();
                if (l_DestinationProvider != null)
                    l_DestinationProvider.Dispose();
                //btn_Sync.Enabled = true;
                setBtnSyncEnable(true);
                G_Complete = true;
            }
        }

        public void OnClick(object sender, EventArgs args)
        {
            foreach (XmlElement xmlDoc in G_Xml.DocumentElement)
            {
                switch (xmlDoc.Name)
                {
                    case "SourcePath":
                        xmlDoc.InnerText = tbx_Source.Text; break;
                    case "DestinationPath":
                        xmlDoc.InnerText = tbx_Destination.Text; break;
                }
            }
            G_Xml.Save(G_XmlUrl);
            print("\r\n--开始同步，请稍候...");
            Thread l_Thread = new Thread(Sync);
            l_Thread.Start();
        }

        public void OnAppliedChange(Object sender, AppliedChangeEventArgs args)
        {
            switch (args.ChangeType)
            {
                case ChangeType.Create:
                    print("\r\n--创建文件：" + args.NewFilePath);
                    break;
                case ChangeType.Delete:
                    print("\r\n--删除文件：" + args.OldFilePath);
                    break;
                case ChangeType.Update:
                    print("\r\n--更新文件：" + args.OldFilePath);
                    break;
                case ChangeType.Rename:
                    print("\r\n--重命名文件：" + args.OldFilePath + "修改为" + args.NewFilePath);
                    break;
            }
        }

        public void OnSkippedChange(object sender, SkippedChangeEventArgs args)
        {
            print("\r\n--发生错误：" + (!string.IsNullOrEmpty(args.CurrentFilePath) ? args.CurrentFilePath : args.NewFilePath) + "跳过文件" + args.ChangeType.ToString().ToUpper());
            if (args.Exception != null)
               rtx_Log.AppendText("[" + args.Exception.Message + "]");
        }

        public void OnItemConflicting(object sender, ItemConflictingEventArgs args)
        {
            args.SetResolutionAction(ConflictResolutionAction.SourceWins);
            print("\r\n--Concurrency conflict detected for item" + args.DestinationChange.ItemId.ToString());
        }

        public void OnItemConstraint(object sender, ItemConstraintEventArgs args)
        {
            args.SetResolutionAction(ConstraintConflictResolutionAction.SourceWins);
            print("\r\n--Contraint conflict detected for iem" + args.DestinationChange.ItemId.ToString());
        }
        public void OnDetectedChange(object sender, DetectedChangesEventArgs args)
        {
            rtx_Log.AppendText("\r\n--TotalDirectories" + args.TotalDirectoriesFound);
            rtx_Log.AppendText("\r\n--TotalFiles" + args.TotalFilesFound);
            rtx_Log.AppendText("\r\n--TotalFileSize" + args.TotalFileSize);
        }

        public void print(string p_message, bool p_Clear = false, bool p_FirstLine = false, bool p_Complete = false)
        {
            if(rtx_Log.InvokeRequired)
            {
                if(p_Clear)
                {
                    Action messageDelegate1 = () => { rtx_Log.Clear(); };
                    rtx_Log.Invoke(messageDelegate1);
                }
                if (p_FirstLine)
                {
                    Action<string> messageDelegate1 = (x) => 
                    {
                        int length = p_message.Length;
                        if(!p_Complete)
                        {
                            if (rtx_Log.Lines.Length > 0)
                            {
                                if (p_message.Length == 9)
                                {
                                    rtx_Log.Select(0, 9);
                                    rtx_Log.SelectedText = "同步中.";
                                }
                                else
                                {
                                    rtx_Log.Select(0, length);
                                    rtx_Log.SelectedText = p_message + ".";
                                }
                            }
                            else
                            {
                                rtx_Log.AppendText(x);
                            }
                        }
                        else
                        {
                            rtx_Log.Select(0, rtx_Log.Lines[0].Length);
                            rtx_Log.SelectedText = p_message;
                        }
                    };
                    rtx_Log.Invoke(messageDelegate1, p_message);
                }
                if(!p_FirstLine)
                {
                    Action<string> messageDelegate = (x) => { rtx_Log.AppendText(x); };
                    rtx_Log.Invoke(messageDelegate, p_message);
                }
            }
            else
            {
                rtx_Log.AppendText(p_message);
            }
        }

        public void setBtnSyncEnable(bool p_Value)
        {
            if(btn_Sync.InvokeRequired)
            {
                Action<bool> enableDelegate = (x) => 
                {
                    btn_Sync.Enabled = x;
                    if (p_Value)
                    {
                        btn_Sync.Text = "开始同步";
                    }
                    else
                    {
                        btn_Sync.Text = "同步中...";
                    }
                };
                btn_Sync.Invoke(enableDelegate, p_Value);
            }
            else
            {
                btn_Sync.Enabled = p_Value;
            }
        }

        private void run1()
        {
            while(!G_Complete)
            {
                Thread.Sleep(1000);
                string s = "";
                Action messageDelegate = () => { s = rtx_Log.Lines[0]; };
                rtx_Log.Invoke(messageDelegate);
                print(s, false, true);
            }
            print("--同步完成", false, true, true);
        }

        private void FrmSync_Load(object sender, EventArgs e)
        {

        }
    }
}

