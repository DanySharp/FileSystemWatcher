using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ServiceProcess;
using System.Text;


namespace FileWatcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            

#if DEBUG
            Service1 s1= new Service1();
            s1.ondebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
