using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using LOG.CapaNegocio;
using GEN.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmExtornoNotaSalida : frmBase
    {

        #region Variables Globales
        //Declarar variables globales
        private const string cTituloMsjes = "Extorno de salida de almacén";

        public DataTable dtOperacion = new DataTable();
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        clsCNKardexLogistica Kardex = new clsCNKardexLogistica();
        public int nNumOperacion, idNotaSalida = 0;

        #endregion

        #region Eventos
        //Colocar los eventos de los controles del formulario
        private void Form_Load(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 7;
            frmExtPen.pidTipOpe = "104";
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar > 0)
            {
                nudNroKardex.Value = nidKar;
                this.txtEstadoOpe.Text = frmExtPen.pcEstKardex;
                btnCancelar.Enabled = true;
            }
            else
            {
                nudNroKardex.Value = 0;
                this.txtEstadoOpe.Text = "";
                return;
            }

            clsCNAprobacion objApr = new clsCNAprobacion();
            DataTable dtDatExt = objApr.RetornaDatosOperacionExt(Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia,
                                                                clsVarGlobal.User.idUsuario, 7, "104");

            nNumOperacion = Convert.ToInt32(this.nudNroKardex.Value);
            dtOperacion = Kardex.BusKardexLog(nNumOperacion);//Obtener los datos propios del kardex

            if (dtDatExt.Rows.Count > 0 && dtOperacion.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(Convert.ToString(dtOperacion.Rows[0]["idDocumento"])))
                {
                    MessageBox.Show("El kardex no tiene numero de documento.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                idNotaSalida = Convert.ToInt32(dtOperacion.Rows[0]["idDocumento"].ToString());

                clsNotaSalida objNotaSalida = new clsCNNotaSalida().CNBuscarNotaSalidaById(idNotaSalida);

                ListarDetalleNotaSalida(objNotaSalida);

                txtFechaOpe.Text = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                //--Asignando Valores                

                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            btnExtorno.Enabled = false;
            DateTime dFecExtorno = clsVarGlobal.dFecSystem;
            int idUsuExtorno = clsVarGlobal.User.idUsuario;
            int idKardex = Convert.ToInt32(nudNroKardex.Value);

            clsDBResp objDbResp = new clsCNNotaSalida().CNExtornoNotaSalida(idKardex, dFecExtorno, idUsuExtorno);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExtorno.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnExtorno.Enabled = true;
                btnCancelar.Enabled = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            btnExtorno.Enabled = false;
        }

        #endregion

        #region Metodos

        public frmExtornoNotaSalida()
        {
            InitializeComponent();
        }

        private void ListarDetalleNotaSalida(clsNotaSalida objNotaSalida)
        {
            dtgDetNotaSalida.DataSource = objNotaSalida.LstDetNotSalida;
            FormatoGridDetNotaSalida();
        }    

        private void FormatoGridDetNotaSalida()
        {
            foreach (DataGridViewColumn column in dtgDetNotaSalida.Columns)
            {
                column.Visible = false;
            }

            dtgDetNotaSalida.Columns["idCatalogo"].Visible = true;
            dtgDetNotaSalida.Columns["cProducto"].Visible = true;
            dtgDetNotaSalida.Columns["cUnidMedida"].Visible = true;
            dtgDetNotaSalida.Columns["nCantidadAten"].Visible = true;

            dtgDetNotaSalida.Columns["idCatalogo"].HeaderText = "Cod. Producto";
            dtgDetNotaSalida.Columns["cProducto"].HeaderText = "Producto";
            dtgDetNotaSalida.Columns["cUnidMedida"].HeaderText = "Uni. Med.";
            dtgDetNotaSalida.Columns["nCantidadAten"].HeaderText = "Cantidad";

            dtgDetNotaSalida.Columns["idCatalogo"].DisplayIndex = 0;
            dtgDetNotaSalida.Columns["cProducto"].DisplayIndex = 1;
            dtgDetNotaSalida.Columns["cUnidMedida"].DisplayIndex = 2;
            dtgDetNotaSalida.Columns["nCantidadAten"].DisplayIndex = 3;

            dtgDetNotaSalida.Columns["idCatalogo"].FillWeight = 10;
            dtgDetNotaSalida.Columns["cProducto"].FillWeight = 50;
            dtgDetNotaSalida.Columns["cUnidMedida"].FillWeight = 20;
            dtgDetNotaSalida.Columns["nCantidadAten"].FillWeight = 20;

            dtgDetNotaSalida.Columns["nCantidadAten"].DefaultCellStyle.Format = "##,##0.00";
        }

        private bool Validar()
        {
            if (nudNroKardex.Value <= 0)
            {
                MessageBox.Show("Número de operación no válida.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = string.Empty;
            txtFechaOpe.Text = string.Empty;
            txtModulo.Text = string.Empty;
            cboTipoOperacion.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtMonOpe.Text = "0.00";
            dtgDetNotaSalida.DataSource = new List<clsDetNotaSalida>();
            FormatoGridDetNotaSalida();
        }
        
        #endregion 

    }
}
