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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = false;

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
            
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void fontSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void fontColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

    
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            RegistryKey r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Notepad");
            if (r == null)
            {
                
            }
            else
            {
                  r.SetValue("lfFaceName", s);
                  MessageBox.Show("Successfully Updated");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void wallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(textBox1.Text);
            //string myHex = s.ToString("X");
            RegistryKey r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Notepad");
            if (r == null)
            {

            }
            else
            {
                r.SetValue("iPointSize", s);
                MessageBox.Show("Point Set To" + s);
            }
        }

        private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();

        }

        private void changeOwnerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5= new Form5();
            f5.Show();
        }

        private void changePcNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
