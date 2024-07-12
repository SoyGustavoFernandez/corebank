using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class FrmAddDocRevCred : frmBase
    {
        private const string cTituloMsjes = "Agregar documento";
        public clsDetRevisionDocCre ObjDocRevCred { get; set; }

        public FrmAddDocRevCred()
        {
            InitializeComponent();
            ObjDocRevCred = null;
        }

        private void AddDocRevCred_Load(object sender, EventArgs e)
        {
            cboTipDocRevCred.SelectedIndex = -1;
            txtDocumento.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            if(!Validar())
                return;

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.Filter = "Documentos Word(*.doc, *.docx)|*.docx;*.doc|Imagenes(*.png, *jpg)|*.png;*.jpg|PDF(*.pdf)|*.pdf";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;


            DialogResult result = fDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            string cPathArchivo = fDialog.FileName;
            FileInfo fInfo = new FileInfo(cPathArchivo);

            ObjDocRevCred = new clsDetRevisionDocCre();

            txtDocumento.Text = cPathArchivo;
            ObjDocRevCred.idTipDocRevCred = Convert.ToInt32(cboTipDocRevCred.SelectedValue);
            ObjDocRevCred.cNomArchivo = fInfo.Name;
            ObjDocRevCred.cExtension = fInfo.Extension;
            ObjDocRevCred.vArchivo = File.ReadAllBytes(cPathArchivo);
            ObjDocRevCred.lVigente = true;
        }

        private bool Validar()
        {
            if (cboTipDocRevCred.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de documento.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ObjDocRevCred == null)
            {
                MessageBox.Show("No se seleccionó ningun documento.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dispose();
        }



    }
}
