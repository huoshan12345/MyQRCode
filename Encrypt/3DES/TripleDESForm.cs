using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TripleDES
{
    public partial class TripleDESForm : Form
    {   
        public TripleDESForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] key = { textBoxKey1.Text, textBoxKey2.Text, textBoxKey3.Text };
            try
            {
                textBox_C.Text = Operate.Encrypt(textBox_M.Text, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string[] key = { textBoxKey1.Text, textBoxKey2.Text, textBoxKey3.Text };
            try
            {
                textBox_M.Text = Operate.Decrypt(textBox_C.Text, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Filter = "文本文件(*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFile.FileName, System.Text.Encoding.Default);
                textBox_M.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }        
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_M.Clear();
            textBox_C.Clear();
            textBoxKey1.Clear();
        }

        private void clearPlainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_M.Clear();
        }

        private void clearCipherTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_C.Clear();
        }

        private void clearKeyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxKey1.Clear();
        }

        private void textBoxKey1_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.Default.GetBytes(textBoxKey1.Text).Length == 8)
            {
                textBoxKey2.Focus();
            }
        }

        private void textBoxKey2_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.Default.GetBytes(textBoxKey2.Text).Length == 8)
            {
                textBoxKey3.Focus();
            }
        }
        
        private void textBoxKey3_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.Default.GetBytes(textBoxKey3.Text).Length == 8)
            {
                textBox_M.Focus();
            }
        }    

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxKey1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_M.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_C.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxKey1.Clear();
            textBoxKey2.Clear();
            textBoxKey3.Clear();
        }

            
        
    }
}