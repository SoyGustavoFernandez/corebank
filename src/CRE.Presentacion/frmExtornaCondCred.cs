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
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using CRE.CapaNegocio;
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExtornaCondCred : frmBase
    {
        #region Variables Globales

        int pidCuenta = 0;

        bool lbloqueo = false;
        public DataTable dtOperacion = new DataTable();
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        clsCNOperacion Operacion = new clsCNOperacion();
        clsCNCondonacion Condonacion = new clsCNCondonacion();
        public int nNumOperacion, nidUserBloqueo;
        string cUserBloqueo;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {        
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (!ValidarInicioOpe().Equals("A"))
            {
                this.Dispose();
                return;
            }
            cboTipoOperacion.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nudNroKardex.Value) > 0)
            {
                LiberarCuenta();
            }

            LimpiarControles();
            pidCuenta = 0;
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 1;
            frmExtPen.pidTipOpe = "7";
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
                                                                clsVarGlobal.User.idUsuario, 1, "7");

            nNumOperacion = Convert.ToInt32(this.nudNroKardex.Value);
            dtOperacion = Operacion.CNdtOperacion(nNumOperacion);//Obtener los datos propios del kardex

            if (dtDatExt.Rows.Count > 0 && dtOperacion.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtDatExt.Rows[0]["cProducto"].ToString()))
                {
                    MessageBox.Show("No Tiene Datos del Producto: VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pidCuenta = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                //--===============================================================================
                //--Validar Si Cuenta esta Siendo Usada
                //--===============================================================================
                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(pidCuenta);
                nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0]);
                if (nidUserBloqueo != 0)
                {
                    DataTable dtUsu = new DataTable();
                    dtUsu = RetornaNumCuenta.BusUsuBlo(nidUserBloqueo);
                    cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lbloqueo = false;
                    LimpiarControles();
                    return;
                }
                else
                {
                    RetornaNumCuenta.UpdEstCuenta(pidCuenta, clsVarGlobal.User.idUsuario);//Usando la cuenta
                    lbloqueo = true;
                }

                this.txtFechaOpe.Text = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                this.txtProducto.Text = dtDatExt.Rows[0]["cProducto"].ToString();
                this.txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                //--Asignando Valores                

                //Rellenar los datos del cobro a Extornar
                this.txtCapital.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoCapital"]));
                this.txtInteres.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoInteres"]));
                this.txtIntComp.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoIntComp"]));
                this.txtMora.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoMora"]));
                this.txtOtros.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoOtros"]));
                this.txtTotExtorno.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(dtOperacion.Rows[0]["nMontoOperacion"]));

                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = "";
            LimpiarControles();
            lbloqueo = true;
            LiberarCuenta();
            btnExtorno.Enabled = false;
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(0, nNumOperacion, "Inicio - Extorno de Cobranza", btnExtorno);
            if (!Validar())
            {
                return;
            }

            var Msg = MessageBox.Show("¿Esta Seguro de Extornar la Operación?", "Extornar Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int nKarAExtornar = Convert.ToInt32(this.nudNroKardex.Value);
            Int32 nIdUsuario = (Int32)clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = Condonacion.CNExtornaCondonacion(nKarAExtornar, clsVarGlobal.dFecSystem, nIdUsuario);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExtorno.Enabled = false;
                btnCancelar.Enabled = true;

                //revisar
                ImpresionVoucher(nIdKardex: objDbResp.idGenerado, idModulo: 1, idTipoOpe: 7, idEstadoKardex: 2,
                                nValRec: 0,
                                nValdev: 0,
                                idKardexAd: 0, idTipoImpresion: 1);
                btnExtorno.Enabled = false;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LiberarCuenta();
            

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(0, pidCuenta, "Extorno de Cobranza completado", btnExtorno);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO 
             ========================================================================================*/
            this.registrarRastreo(0, nNumOperacion, "Fin - Extorno de Cobranza", btnExtorno);
        }

        public void EmitirVoucherExtorno(DataTable dtDatosCobro, int idKardex, int idmodulo)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));
            paramlist.Add(new ReportParameter("x_idModulo", idmodulo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            string reportpath = "RptVouchersExtorno.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();

        }

        private void frmExtornaCondCred_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmExtornaCondCred()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Número de Kardex, esta Vacío, por favor Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.nudNroKardex.Value <= 0)
            {
                MessageBox.Show("El Número de Kardex no es Válido, por favor Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No puede realizar el Extorno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Int32 nUsusis = (Int32)clsVarGlobal.User.idUsuario;
            DateTime dfecsis = clsVarGlobal.dFecSystem;

            if (Convert.ToInt32(dtOperacion.Rows[0]["iduser"]) != nUsusis)
            {
                MessageBox.Show("El Usuario que hizo la operación no es el mismo que él del extorno", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToDateTime(dtOperacion.Rows[0]["dFechaOpe"]).ToShortDateString() != dfecsis.ToShortDateString())
            {
                MessageBox.Show("La Fecha en la que se hizo la operación no es el misma que la del extorno", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void LiberarCuenta()
        {
            if (lbloqueo)
            {
                new clsCNRetornaNumCuenta().UpdEstCuenta(pidCuenta, 0);
                lbloqueo = false;
            }
        }

        private void LimpiarControles()
        {
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
            txtProducto.Clear();
            this.cboTipoOperacion.SelectedIndex = -1;
            this.cboMoneda.SelectedIndex = -1;
            this.txtMonOpe.Text = "0.00";

            //Detalles Monto
            txtCapital.Text = String.Empty;
            txtInteres.Text = String.Empty;
            txtMora.Text = String.Empty;
            txtOtros.Text = String.Empty;
            txtTotExtorno.Text = String.Empty;
        }

        #endregion

    }
}
