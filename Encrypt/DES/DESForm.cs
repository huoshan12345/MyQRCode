using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DES
{
    public partial class DESForm : Form
    {
        public DESForm()
        {
            InitializeComponent();
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Filter = "文本文件(*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(openFile.FileName, System.Text.Encoding.Default);
                plainText.Text = stream.ReadToEnd();
                stream.Close();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearKey_Click(object sender, EventArgs e)
        {
            cipherKeyText.Clear();
        }

        private void plainClear_Click(object sender, EventArgs e)
        {
            plainText.Clear();
        }

        private void cipherClear_Click(object sender, EventArgs e)
        {
            cipherText.Clear();
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            cipherKeyText.Clear();
            plainText.Clear();
            cipherText.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                cipherText.Text = Operate.Encrypt(plainText.Text, cipherKeyText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                plainText.Text = Operate.Decrypt(cipherText.Text, cipherKeyText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}