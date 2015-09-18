using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.ServiceProcess;

namespace SpreadsheetWatcher
{
    public partial class DirectoryMonitoringService //: ServiceBase
    {
        protected FileSystemWatcher watcher;

        // Directory must already exist unless you want to add your own code to create it.
        string PathToFolder = @"C:\Users\Bianca\Desktop\monitor";

        public DirectoryMonitoringService()
        {
            Log.Instance.LogPath = @"C:\Users\Bianca\Desktop\monitorLog";
            Log.Instance.LogFileName = "DirectoryMonitoring";
            watcher = new MyFileSystemWatcher(PathToFolder);

            //watcher.Filter = "*.xls|*.xlsx";

            Log.WriteLine("Excel Parser has been triggered.");
        }

        //protected override void OnStart(string[] args){}

        //protected override void OnStop(){}
    }
}
