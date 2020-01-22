using System;
using System.Windows.Forms;
using CryptoTools.Helpers;
using NETCore.Encrypt;

namespace CryptoTools
{
    public partial class TextEncryptor : Form
    {
        public TextEncryptor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
//            var aesKey = EncryptProvider.CreateAesKey();
//            var key = aesKey.Key;
//            var iv = aesKey.IV;
            CryptographyHelper.AesKey = "MhJMpckQWBMVZdkkRgMQPslZPSpIYfCY";
            CryptographyHelper.AesIv = "xApR40xu823N1DFs";
        }

        private void txtRes_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkEncrypt.Checked)
            {
                txtRes.Text = CryptographyHelper.AesEncrypt(txtInputStr.Text);
            }
            else
            {
                txtRes.Text = CryptographyHelper.AesDecrypt(txtInputStr.Text);
            }
        }
    }
}