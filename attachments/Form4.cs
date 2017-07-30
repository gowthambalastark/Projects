using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Regediter
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            RegistryKey r = Registry.CurrentUser.CreateSubKey("Control Panel\\Colors");
            if (r == null)
            {

            }
            else
            {
                r.SetValue("Background", s);
                MessageBox.Show("Successfully Updated");
            }
        }
    }
}
