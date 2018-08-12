using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileWatcher
{
  public static class LoggerClass
    {

        public static void log(string message)
        {

            

            try
            {
                string msg = string.Format("{0}{1}",message,Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory+ "logFile.txt", msg);
            }
            catch 
            {

                
            }

        }
    }
}
