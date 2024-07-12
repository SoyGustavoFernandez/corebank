using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
namespace CRE.Presentacion
{
    public partial class frmDenegacionAfectacionCOBs : frmBase
    {
        frmCobAfectacionIndividual frm;
        private string cTituloMsg;
        public frmDenegacionAfectacionCOBs()
        {
            InitializeComponent();
            cargarFrmAfectacion();
            this.cTituloMsg = "Denegación Afectación de COBs";
        }

        private void cargarFrmAfectacion()
        {
            frm = new frmCobAfectacionIndividual();
            frm.lLectura = true;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlFrmCobAfec.Controls.Add(frm);
            frm.Show();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            frm.limpiarCancelar();
        }

        private void btnDenegar2_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            clsGestionaNivelAprobacion oNivelAproba = new clsGestionaNivelAprobacion();
            DataTable dtRes = oNivelAproba.registrarDesicion(0, frm.idSolicitudAproba, clsVarGlobal.dFecSystem, EstadoAprobacion.Denegado, clsVarGlobal.User.idUsuario, txtSustento.Text, frm.idCuenta);

            if (dtRes.Rows.Count != 0)
            {
                if (Convert.ToInt32(dtRes.Rows[0]["nResultado"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Hubo un error en la conexion con la base de datos, consulte con sus", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Validar()
        {
            bool lValida = true;
            if (frm.idCuenta == 0)
            {
                MessageBox.Show("No hay ninguna cuenta de crédito seleccionada", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValida =  false;
            }

            if (frm.idGrupoAfectacion == 0)
            {
                MessageBox.Show("No hay ninguna Afectación para la cuenta ingresada", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValida = false;
            }

            return lValida;
        }

        private void frmDenegacionAfectacionCOBs_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.limpiarCancelar();
        }
    }
}
