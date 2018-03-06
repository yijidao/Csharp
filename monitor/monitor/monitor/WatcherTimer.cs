using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace monitor
{
    /// <summary>
    /// Description : 定时类，用于解决触发多次事件的问题
    /// Creator     : wengzp (2018/3/5 11:00:46)
    /// Modefier    :
    /// </summary>
    class WatcherTimer
    {
        private int TimeoutMillis = 2000;

        System.IO.FileSystemWatcher fsw = new System.IO.FileSystemWatcher();
        System.Threading.Timer m_timer = null;
        List<String> files = new List<string>();
        FileSystemEventHandler fswHandler = null;

        public WatcherTimer(FileSystemEventHandler watchHandler)
        {
            m_timer = new System.Threading.Timer(new TimerCallback(OnTimer), null, Timeout.Infinite, Timeout.Infinite);
            fswHandler = watchHandler;
        }

        public WatcherTimer(FileSystemEventHandler watchHandler, int timerInterval)
        {
            m_timer = new System.Threading.Timer(new TimerCallback(OnTimer), null, Timeout.Infinite, Timeout.Infinite);
            TimeoutMillis = timerInterval;
            fswHandler = watchHandler;
        }

        public void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (Directory.Exists(e.FullPath))
            {
                return;
            }

            Mutex mutex = new Mutex(false, "FSW");
            mutex.WaitOne();
            string directory = e.FullPath.Substring(Form1.dirLength);
            if (!files.Contains(directory))
            {
                files.Add(directory);
            }
            mutex.ReleaseMutex();

            m_timer.Change(TimeoutMillis, Timeout.Infinite);
        }

        private void OnTimer(object state)
        {
            List<String> backup = new List<string>();

            Mutex mutex = new Mutex(false, "FSW");
            mutex.WaitOne();
            backup.AddRange(files);
            files.Clear();
            mutex.ReleaseMutex();

            foreach (string file in backup)
            {
                int index = file.LastIndexOf(@"\");
                string directory = file.Substring(0, index);
                string fileName = file.Substring(index+1);
                fswHandler(this, new FileSystemEventArgs(WatcherChangeTypes.Changed, directory, fileName));
            }
        }
    }
}
