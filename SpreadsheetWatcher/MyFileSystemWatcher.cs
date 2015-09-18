using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SpreadsheetWatcher
{
    public class MyFileSystemWatcher : FileSystemWatcher
    {

        public MyFileSystemWatcher()
        {
            Init();
        }

        public MyFileSystemWatcher(String inDirectoryPath)
            : base(inDirectoryPath)
        {
            Init();
        }

        public MyFileSystemWatcher(String inDirectoryPath, string inFilter)
            : base(inDirectoryPath, inFilter)
        {
            Init();
        }

        private void Init()
        {
            IncludeSubdirectories = true;
            // Eliminate duplicates when timestamp doesn't change
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.
                LastAccess | NotifyFilters.LastWrite;
            //this.Filter = "*.xls|*.xlsx";

            EnableRaisingEvents = true;
            Created += Watcher_Created;
            Changed += Watcher_Changed;
            Deleted += Watcher_Deleted;
            Renamed += Watcher_Renamed;
            Log.WriteLine("Done initializing file watcher service");
        }

        public void Watcher_Created(object source, FileSystemEventArgs inArgs)
        {
            //ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\Bianca\Documents\GitHubVisualStudio\dtools-report-parser\ExcelParser\ExcelParser\bin\Debug\ExcelParser.exe");
            //Process.Start("ExcelParser.exe", inArgs.FullPath);
            Log.WriteLine("File created or added: " + inArgs.FullPath);
        }   

        public void Watcher_Changed(object sender, FileSystemEventArgs inArgs)
        {

            Process process = new Process();
            process.StartInfo.FileName = "C:\\Users\\Bianca\\Documents\\GitHubVisualStudio\\dtools-report-parser\\ExcelParser\\ExcelParser\\bin\\Debug\\ExcelParser.exe";
            process.StartInfo.Arguments = inArgs.FullPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            string stdout = process.StandardError.ReadToEnd();
            Log.WriteLine(stdout);
            
            Log.WriteLine("File changed: " + inArgs.FullPath);
        }

        public void Watcher_Deleted(object sender, FileSystemEventArgs inArgs)
        {
            Log.WriteLine("File deleted: " + inArgs.FullPath);
        }

        public void Watcher_Renamed(object sender, RenamedEventArgs inArgs)
        {
            Log.WriteLine("File renamed: " + inArgs.OldFullPath + ", New name: " + inArgs.FullPath);
        }
    }
}