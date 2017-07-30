using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Regediter
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            RegistryKey r = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Console\\TrueTypeFont");
            //RegistrySecurity rs = new RegistrySecurity();
            //rs.AddAccessRule(new RegistryAccessRule("Administrator", RegistryRights.FullControl,InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            //r.SetAccessControl(rs);
            //r = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", RegistryKeyPermissionCheck.ReadWriteSubTree,RegistryRights.FullControl);
            //rs.SetOwner(new NTAccount("Sathish Kumar Mrsk"));
            //r.SetAccessControl(rs);
            if (r == null)
            {

            }
            else
            {
                r.SetValue("000", s);
                //r.SetValue("AB", "a");
                MessageBox.Show("Success");
            }
        }
    }
}
