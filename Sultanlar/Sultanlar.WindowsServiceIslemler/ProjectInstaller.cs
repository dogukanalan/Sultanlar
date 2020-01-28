using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace Sultanlar.WindowsServiceIslemler
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.serviceInstaller1.ServiceName = "Sultanlar Windows Servis";
            this.serviceInstaller1.DisplayName = "Sultanlar Windows Servis";
            this.serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
        }
    }
}
