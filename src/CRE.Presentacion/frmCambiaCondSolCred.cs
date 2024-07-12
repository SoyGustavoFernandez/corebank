using System;
using System.Data;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCambiaCondSolCred : frmBase
    {

        #region Variables Globales

        private decimal nMontoSolicitado = 0;
        public clsCreditoProp ObjCreditoProp;
        public bool lAceptar = false;
        public int idTipoOpe = 55;

        #endregion

        #region Eventos

        private void frmCambiaCondSolCred_Load(object sender, EventArgs e)
        {
            dtgExcepciones.AutoGenerateColumns = false;
            dtgHistoricoPropuesta.AutoGenerateColumns = false;
            if (ObjCreditoProp != null)
            {
                conCreditoTasa.AsignarDatos(ObjCreditoProp);
                conCreditoTasa.MontoEnabled = ObjCreditoProp.idOperacion.In(1, 4, 5);
                conCreditoTasa.CuotasEnabled = ObjCreditoProp.idOperacion.In(1, 2, 4);
                conCreditoTasa.DiasGraciaEnabled = ObjCreditoProp.idOperacion.In(1, 2, 4);
                conCreditoTasa.FechaDesembolsoEnabled = ObjCreditoProp.idOperacion.In(1, 2, 4);
                conCreditoTasa.PlazoCuotaEnabled = ObjCreditoProp.idOperacion.In(1, 4);
                //conCreditoTasa.TEAEnabled = ObjCreditoProp.idOperacion.In(1, 4);
                conCreditoTasa.TipoPeriodoEnabled = ObjCreditoProp.idOperacion.In(1, 2, 4);
                conCreditoTasa.TipoTasaCreditoEnabled = ObjCreditoProp.idOperacion.In(1, 2, 4);

                conCreditoTasa.NivelesProductoEnabled = false;
                conCreditoTasa.MonedaEnabled = false;
                LlenarControles();
                Habilitar(true);

                DataTable dtExcepciones = new clsCNComiteCreditos().CNListExcepcionesSolCre(ObjCreditoProp.idSolicitud, idTipoOpe);
                dtgExcepciones.DataSource = dtExcepciones;

                DataTable dtHistoricoProp = new clsCNSolCre().GetHistoricoPropuesta(ObjCreditoProp.idSolicitud);
                dtgHistoricoPropuesta.DataSource = dtHistoricoProp;
            }
            else
            {
                LimpiarControles();
                Habilitar(false);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!Validar()) return;

            clsCreditoProp _objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();

            if (_objCreditoProp == null)
                return;

            _objCreditoProp.cComentarios = txtComentAproba.Text;
            _objCreditoProp.lVerificacion = chcVerificacion.Checked;

            ObjCreditoProp = _objCreditoProp;

            lAceptar = true;

            this.Dispose();
        }

        #endregion

        #region Metodos

        public frmCambiaCondSolCred()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtComentAproba.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el sustento por el cambio de datos de la solicitud.", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (conCreditoTasa.MontoPropuesto > nMontoSolicitado)
            {
                MessageBox.Show("El monto propuesto no puede aumentar.", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            clsMsjError objError = conCreditoTasa.Validar();
            if (objError.HasErrors)
            {
                MessageBox.Show("La propuesto contiene errores.", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true ;
        }

        private void LlenarControles()
        {
            nMontoSolicitado = ObjCreditoProp.nMonto;
            cboOperacionCre.SelectedValue = ObjCreditoProp.idOperacion;
            cboAsesor.SelectedValue = ObjCreditoProp.idAsesor;
            txtNumEva.Text = ObjCreditoProp.idEvalCred.ToString();
            txtComentAproba.Text = ObjCreditoProp.cComentarios;
        }

        private void Habilitar(bool lHab)
        {
            conCreditoTasa.Enabled = lHab;
            txtComentAproba.Enabled = lHab;
            btnAceptar.Enabled = lHab;
        }

        private void LimpiarControles()
        {
            cboAsesor.SelectedIndex = -1;
            cboOperacionCre.SelectedIndex = -1;
            txtNumEva.Text = String.Empty;
            txtComentAproba.Text = String.Empty;
        }

        #endregion

    }
}
