using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Management;
using System.Threading.Tasks;
using System.IO;

namespace FileWatcher
{
    class FileWatcher
    {


    private FileSystemWatcher FileWat;

        public FileWatcher()
        {
            

            string[] drives = Environment.GetLogicalDrives();
            if (!File.Exists("logFile.txt"))
            {
                File.Create("logFile.txt");
                
            }

            foreach (string strDrive in drives)
            {
                DriveInfo df = new DriveInfo(strDrive);

                if (!df.IsReady)

                    continue;
                FileWat = new FileSystemWatcher();
                FileWat.IncludeSubdirectories = true;
                FileWat.Filter = "*.*";
                FileWat.Path = strDrive;
                 FileWat.EnableRaisingEvents = true;
                FileWat.Created += new FileSystemEventHandler(FilewatCreated);
                FileWat.Deleted += new FileSystemEventHandler(FileDeleted);
                FileWat.Changed += new FileSystemEventHandler(FileChanged);
               
                FileWat.Renamed+= new RenamedEventHandler(FileRenamed);
               
                FileWat.IncludeSubdirectories = false;
            }
           
        }
        //private string pathloc()
        //{
        //    string value=string.Empty;
        //    try
        //    {
        //        value = ConfigurationManager.AppSettings["location"];

        //    }
        //    catch 
        //    {


        //    }
        //    return value;
        //}
      
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            
       
        
        public void FilewatCreated(object sender, FileSystemEventArgs e)
        {
            string year = pc.GetYear(System.DateTime.Now).ToString() + "/";
            string mont = pc.GetMonth(DateTime.Now).ToString() + "/";
            string day = pc.GetDayOfMonth(DateTime.Now).ToString()+"--"+DateTime.Now.ToShortTimeString();
            LoggerClass.log(string.Format("File Created= Path:{0} Name:{1}  Date:{2}{3}{4}", e.FullPath,e.Name,year,mont,day));
        }
        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            string year = pc.GetYear(System.DateTime.Now).ToString() + "/";
            string mont = pc.GetMonth(DateTime.Now).ToString() + "/";
            string day = pc.GetDayOfMonth(DateTime.Now).ToString() + "--" + DateTime.Now.ToShortTimeString();
            LoggerClass.log(string.Format("File Deleted= Path:{0} Name:{1}   Date:{2}{3}{4}", e.FullPath, e.Name, year, mont, day));
        }
        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            string year = pc.GetYear(System.DateTime.Now).ToString() + "/";
            string mont = pc.GetMonth(DateTime.Now).ToString() + "/";
            string day = pc.GetDayOfMonth(DateTime.Now).ToString() + "--" + DateTime.Now.ToShortTimeString();
            LoggerClass.log(string.Format("File Changed= Path:{0} Name:{1}  Type:{2} Date:{3}{4}{5}", e.FullPath, e.Name,e.ChangeType, year, mont, day));
        }
        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            string year = pc.GetYear(System.DateTime.Now).ToString() + "/";
            string mont = pc.GetMonth(DateTime.Now).ToString() + "/";
             string day = pc.GetDayOfMonth(DateTime.Now).ToString() + "--" + DateTime.Now.ToShortTimeString();
            LoggerClass.log(string.Format("File Renamed= OldName:{0} New Name:{1}    Date:{2}{3}{4}", e.OldName, e.Name, year, mont, day));
        }
       
    }
}
