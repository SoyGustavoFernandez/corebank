using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;

namespace PhraseEncrypter
{
    public partial class frmPhraseEncrypter : Form
    {
        StringEncryptorDecryptor encryptor = new StringEncryptorDecryptor();

        const char cPASS = '\u25CF';
        const char cNONE = '\0';

        public frmPhraseEncrypter()
        {
            InitializeComponent();
            visible.Checked = false;
            contentText.PasswordChar = cPASS;
        }

        private void contentText_TextChanged(object sender, EventArgs e)
        {
            if (contentText.Text.Contains(' '))
            {
                contentText.Text = contentText.Text.Replace(" ", "");
                contentText.SelectionStart = contentText.Text.Length;
            }
            if (contentText.Text == "")
            {
                contentEncryptedText.Text = "";
            }
            else
            {
                contentEncryptedText.Text = encryptor.encryptString(contentText.Text);
            }
        }

        private void contentEncryptedText_Enter(object sender, EventArgs e)
        {
            contentEncryptedText.SelectAll();
            contentEncryptedText.Focus();
            contentEncryptedText.Copy();
        }

        private void visible_CheckedChanged(object sender, EventArgs e)
        {
            if (visible.Checked)
            {
                contentText.PasswordChar = cNONE;
            }
            else
            {
                contentText.PasswordChar = cPASS;
            }
        }

        private void contentText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
