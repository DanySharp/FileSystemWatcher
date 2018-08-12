using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace FileWatcher
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
          
        }
        public void  ondebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            FileWatcher few = new FileWatcher();
        }

        protected override void OnStop()
        {
        }
    }
}
