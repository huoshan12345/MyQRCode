using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RSA
{
    public partial class RSAForm : Form
    {
        CspParameters cspPas = new CspParameters();

        public RSAForm()
        {
            InitializeComponent();
            cspPas.KeyContainerName = "MyRSA";
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
                txtPlain.Text = stream.ReadToEnd();
                stream.Close();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void plainClear_Click(object sender, EventArgs e)
        {
            txtPlain.Clear();
        }

        private void cipherClear_Click(object sender, EventArgs e)
        {
            txtCipher.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
//                 RSAGenerator rsa = new RSAGenerator();
                string source = txtPlain.Text;
//                 string PublicKey = rsa.GetPublicKey();
//                 string PrivateKey = rsa.GetPrivateKey();
                txtCipher.Text = (RSA.Operate.Encrypt(source, cspPas))[0];


                //txtPublicKey.Text = PublicKey;
                //txtPrivateKey.Text = PrivateKey;                
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
                string source = txtCipher.Text;
                txtPlain.Text = RSA.Operate.Decrypt(source, cspPas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}