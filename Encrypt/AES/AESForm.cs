using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AES
{
    public partial class AESForm : Form
    {

        public AESForm()
        {
            InitializeComponent();
        }

        private void ClearKey_Click(object sender, EventArgs e)
        {
            KeyText.Clear();
        }

        private void ClearPlain_Click(object sender, EventArgs e)
        {
            PlainText.Clear();
        }

        private void ClearCipher_Click(object sender, EventArgs e)
        {
            CipherText.Clear();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EncryptionBtn_Click(object sender, EventArgs e)
        {
            byte KeyLengthChoiced = 16;
            if (radioBtn1.Checked == true)
            {
                KeyLengthChoiced = 16;
            }
            else if (radioBtn2.Checked == true)
            {
                KeyLengthChoiced = 24;
            }
            else if (radioBtn3.Checked == true)
            {
                KeyLengthChoiced = 32;
            }

            try
            {
                CipherText.Text = Operate.Encrypt(PlainText.Text, KeyText.Text, KeyLengthChoiced);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckFileExists = true;
            openfile.CheckPathExists = true;
            openfile.Filter="文本文件(*.txt)|*.txt";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream= new StreamReader(openfile.FileName, System.Text.Encoding.Default);
                PlainText.Text = stream.ReadToEnd();
                stream.Close();
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            KeyText.Clear();
            PlainText.Clear();
            CipherText.Clear();
        }

        private void DecryptionBtn_Click(object sender, EventArgs e)
        {
            byte KeyLengthChoiced = 16;
            if (radioBtn1.Checked == true)
            {
                KeyLengthChoiced = 16;
            }
            else if (radioBtn2.Checked == true)
            {
                KeyLengthChoiced = 24;
            }
            else if (radioBtn3.Checked == true)
            {
                KeyLengthChoiced = 32;
            }

            try
            {
                PlainText.Text = Operate.Decrypt(CipherText.Text, KeyText.Text, KeyLengthChoiced);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void radioBtn1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "密钥长度为16个字符或8个汉字";
        }

        private void radioBtn2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "密钥长度为24个字符或12个汉字";
        }

        private void radioBtn3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "密钥长度为32个字符或16个汉字";
        }
    }
}