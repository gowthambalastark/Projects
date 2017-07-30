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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rk;

            rk = Registry.CurrentUser.OpenSubKey("temp", true);
            if (rk == null)
            {
                rk = Registry.CurrentUser.CreateSubKey("temp");
                rk.SetValue("Uname", "admin");
                rk.SetValue("pwrd", "root");

            }

            string s1 = (string) rk.GetValue("Uname");
            string s2= (string)rk.GetValue("pwrd");
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if (user == s1 && pass == s2)
            {
                Form1 f2 = new Form1();
                f2.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Invalid User");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

        