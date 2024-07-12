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
using GEN.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmConsultaEstadoSolAprb : frmBase
    {
        private List<int> lstProductosPermitidos = new List<int>();
        private clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
        public frmConsultaEstadoSolAprb()
        {
            InitializeComponent();
            conBusCuentaCli.cTipoBusqueda = "S";
            conBusCuentaCli.cEstado = "[18,2,4]";
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string cProductos = Convert.ToString(clsVarApl.dicVarGen["cProductoModAprobAutomatico"]);
            lstProductosPermitidos = cProductos.Split(',').Select(Int32.Parse).ToList();
            int idSolicitud = conBusCuentaCli.nValBusqueda;

            DataTable dtSolicitud = objCNSolicitud.ConsultaSolicitud(idSolicitud);
            if(idSolicitud == 0)
            {
                return;
            }

            int idProducto = Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]);
            if (idSolicitud != 0 && !lstProductosPermitidos.Any(item => item == idProducto))
            {
                MessageBox.Show("No se permite el producto de la solicitud para la Consulta de Estado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Limpiar();
                HabilitarControlesFormulario(false);
                return;
            }

            if (idSolicitud == 0 )
            {
                Limpiar();
                HabilitarControlesFormulario(false);
                return;
            }

            DataTable dtRespuesta = objCNSolicitud.CNGuardarDecisionModeloScoring(idSolicitud);

            if(dtRespuesta.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtRespuesta.Rows[0]["nResultado"]) == 1)
                {
                    lblCodSolicitud.Text = Convert.ToString(idSolicitud);
                    lblEstadoSolicitud.Text = Convert.ToString(dtRespuesta.Rows[0]["cEstado"]);
                    lblFechaRegistro.Text = Convert.ToString(dtRespuesta.Rows[0]["dFechaRegistro"]);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtRespuesta.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Limpiar();
                    HabilitarControlesFormulario(false);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un error al intentar recuperar el Estado de la solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Limpiar();
                HabilitarControlesFormulario(false);
                return;
            }

            HabilitarControlesFormulario(true);

        }

        private void Limpiar()
        {
            lblCodSolicitud.Text = "-";
            lblFechaRegistro.Text = "-";
            lblEstadoSolicitud.Text = "-";
            conBusCuentaCli.limpiarControles();
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;

        }

        private void HabilitarControlesFormulario(bool lActivo)
        {
            conBusCuentaCli.Enabled = !lActivo;
            btnCancelar.Enabled = lActivo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControlesFormulario(false);
            Limpiar();
        }

        private void frmConsultaEstadoSolAprb_Load(object sender, EventArgs e)
        {
            HabilitarControlesFormulario(false);
        }
    }
}
