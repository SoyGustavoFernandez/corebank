using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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

namespace CNT.Presentacion
{
    public partial class frmCargaNotaEEFF : frmBase
    {
        public byte[] vArchivo;

        private int idNotasEEFF ;
        private DateTime dPerContable ;	
        private string cNomArchivo;
        private string cExtension ;
        private DateTime dFecha;

        public frmCargaNotaEEFF()
        {
            InitializeComponent();
            dtpPerContable.Value = clsVarGlobal.dFecSystem;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtNombreArch.Clear();
            txtCodigo.Clear();
            dtpPerContable.Enabled = true;
            txtDescripcion.Enabled = true;
            txtNombreArch.Enabled  = true;
            btnMiniBusq1.Enabled = true;
            btnVistaPrevia.Enabled = true;
            
            vArchivo = null;
            
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar1.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int nMesContable = clsVarApl.dicVarGen["nMesCNT"];
            int nAnioContable = clsVarApl.dicVarGen["nAnioCNT"];
            if (dtpPerContable.Value.Month == nMesContable && dtpPerContable.Value.Year == nAnioContable)
            {

                if (txtCodigo.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Para editar debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dtpPerContable.Enabled = true;
                txtDescripcion.Enabled = true;
                txtNombreArch.Enabled = true;
                btnMiniBusq1.Enabled = true;
                btnVistaPrevia.Enabled = true;
                btnBusqueda.Enabled = false;

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe ser del mismo periodo contable","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
         
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int nMesContable = clsVarApl.dicVarGen["nMesCNT"];
            int nAnioContable = clsVarApl.dicVarGen["nAnioCNT"];
            if (dtpPerContable.Value.Month == nMesContable && dtpPerContable.Value.Year == nAnioContable)
            {
                if (txtNombreArch.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe elegir el archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dPerContable = dtpPerContable.Value.Date;
                if (txtCodigo.Text.Trim().Equals(""))
                {
                    idNotasEEFF = 0;
                }
                else
                {
                    idNotasEEFF = Convert.ToInt32(txtCodigo.Text);
                }
                dFecha = clsVarGlobal.dFecSystem;
                dPerContable = dtpPerContable.Value.Date;
                string cDescripcion = txtDescripcion.Text;
                DataTable objDbResp = new clsCNProcesosAsientos().CNCargarNotaEEFF(idNotasEEFF, dPerContable, cNomArchivo, cExtension, vArchivo, dFecha, 1, cDescripcion);
                if (objDbResp.Rows[0][0].ToString() == "0")
                {
                    MessageBox.Show(objDbResp.Rows[0][1].ToString(), "Registro de notas de estados financieros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Text = objDbResp.Rows[0][2].ToString();
                    dtpPerContable.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtNombreArch.Enabled = false;
                    txtCodigo.Enabled = false;
                    btnMiniBusq1.Enabled = false;

                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar1.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Error al grabar", "Registro de notas de estados financieros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe ser del mismo periodo contable", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtNombreArch.Clear();
            txtCodigo.Clear();
            dtpPerContable.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombreArch.Enabled = false;
            txtCodigo.Enabled = false;
            btnMiniBusq1.Enabled = false;
            btnVistaPrevia.Enabled = false;
            btnBusqueda.Enabled = true;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar1.Enabled = false;
        }

        private void frmCargaNotaEEFF_Load(object sender, EventArgs e)
        {
            dtpPerContable.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombreArch.Enabled = false;
            txtCodigo.Enabled = false;
            btnMiniBusq1.Enabled = false;
            btnVistaPrevia.Enabled = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar1.Enabled = false;

        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opPDF = new OpenFileDialog();
            opPDF.Title = "Abrir archivo";
            opPDF.Filter = "PDF(*.pdf)|*.pdf";
            DialogResult opPDFResul = opPDF.ShowDialog();
            opPDF.OpenFile();
            if (opPDFResul!=DialogResult.OK)
            {
                return;
                
            }
            string path = opPDF.FileName;
            txtNombreArch.Text=path.ToString();
            FileInfo fInfo = new FileInfo(path);
            vArchivo = File.ReadAllBytes(path);
            cNomArchivo = fInfo.Name;
            cExtension = fInfo.Extension;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBuscarNotasEEFF frmBuscaNta = new frmBuscarNotasEEFF();
            frmBuscaNta.ShowDialog();
            if ( frmBuscaNta.idNotasEEFF=="0")
            {
                return;
            }
            vArchivo= frmBuscaNta.vArchivo;
            txtCodigo.Text=frmBuscaNta.idNotasEEFF;
            dtpPerContable.Value=frmBuscaNta.dFecPerContable;
            txtNombreArch.Text=frmBuscaNta.cNomArchivo;
            cNomArchivo = frmBuscaNta.cNomArchivo; 
            cExtension =frmBuscaNta.cExtension;
            txtDescripcion.Text = frmBuscaNta.cDescripcion;
            btnVistaPrevia.Enabled = true;
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (vArchivo ==null)
            {
                return;
            }
            frmVistaPreviaNotasEEFF vtaPrevia = new frmVistaPreviaNotasEEFF(vArchivo, cNomArchivo, cExtension);
            vtaPrevia.ShowDialog();
        }
    }
}
