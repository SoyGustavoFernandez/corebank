using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmPropuestaCredito : frmBase
    {
        DataTable Sol;
        clsCNEvaluacion Evalua = new clsCNEvaluacion();

        int idTipoPeriodo = 0;
        
        public frmPropuestaCredito()
        {
            InitializeComponent();
            this.conBusCuentaCli.cTipoBusqueda  = "S";
            this.conBusCuentaCli.cEstado        = "[1,2]"; //SOLICITADO - APROBADO
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if (CodSol!=0)
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = false;
                conBusCuentaCli.btnBusCliente1.Enabled = false;
                BuscarSolicitud(CodSol);//Buscar solictud de crédito
                if (string.IsNullOrEmpty(txtMonSolicitado.Text)) return;
                BuscarPropuesta(CodSol);//Buscar Propuesta de crédito Empresarial
                if (conBusCuentaCli.txtEstado.Text.Equals("SOLICITADO"))
                {
                    btnEditar1.Visible = true;
                    btnGrabar1.Visible = true;
                }
                if (conBusCuentaCli.txtEstado.Text.Equals("APROBADO"))
                {
                    btnEditar1.Visible = false;
                    btnGrabar1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("El Cliente no tiene una solicitud de Crédito vigente.", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);      
            }
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if (CodSol != 0)
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = false;
                conBusCuentaCli.btnBusCliente1.Enabled = false;
                BuscarSolicitud(CodSol);
                if (string.IsNullOrEmpty(txtMonSolicitado.Text)) return;
                BuscarPropuesta(CodSol);

                if (conBusCuentaCli.txtEstado.Text.Equals("SOLICITADO"))
                {
                    btnEditar1.Visible = true;
                    btnGrabar1.Visible = true;
                }
                if (conBusCuentaCli.txtEstado.Text.Equals("APROBADO"))
                {
                    btnEditar1.Visible = false;
                    btnGrabar1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("El Cliente no tiene una solicitud de Crédito vigente.", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarSolicitud(int idSol)
        {
            Sol = Evalua.CNConsPropuestaCre(idSol);

            if (Sol.Rows.Count > 0)
            {
                txtMonSolicitado.Text   = Sol.Rows[0]["nCapitalSolicitado"].ToString();
                txtMoneda.Text          = Sol.Rows[0]["cMoneda"].ToString();
                txtTipoCredito.Text     = Sol.Rows[0]["cTipCredito"].ToString();
                txtProducto.Text        = Sol.Rows[0]["cProducto"].ToString();
                txtNumCuotas.Text       = Sol.Rows[0]["nCuotas"].ToString();
                txtFrecuencia.Text      = Sol.Rows[0]["nPlazoCuota"].ToString();
                txtTasaInteres.Text     = Sol.Rows[0]["nTasaCompensatoria"].ToString();
                txtDiaGracia.Text       = Sol.Rows[0]["nDiasGracia"].ToString();
                txtActividad.Text       = Sol.Rows[0]["cActividad"].ToString();
                txtDestino.Text         = Sol.Rows[0]["cDestino"].ToString();
                
                idTipoPeriodo       = Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                txtTipoPeriodo.Text = Sol.Rows[0]["cDescripTipoPeriodo"].ToString();

                lblEnDias.Visible = false;
                if (idTipoPeriodo==1)//Fecha Fija
                {
                    lblFrec.Text = "Día de Pago: ";
                }
                if (idTipoPeriodo==2)//Periodo Fijo
                {
                    lblFrec.Text = "Frecuencia: ";
                    lblEnDias.Visible = true;
                }

                DataTable dtTasaGarantia = new clsCNGarantia().CNSaldoTasado(idSol);
                if (dtTasaGarantia.Rows.Count > 0)
                {
                    txtGarantia.Text = dtTasaGarantia.Rows[0]["nSaldo"].ToString();
                }

                //--------------- Cargar Datos del crédito Propuesto: ---------------->
                txtMontProp.Text    = Sol.Rows[0]["nMonPropuesto"].ToString();
                txtNroCuotas.Text   = Sol.Rows[0]["nNumcuotas"].ToString();
                txtTEM.Text         = Sol.Rows[0]["nTEM"].ToString();
                txtCuotaAprox.Text  = Sol.Rows[0]["nCuotaAprox"].ToString(); 
                //------------------------------------------------------------------->
            }
            else
            {
                MessageBox.Show("No se encontró la solicitud, verifique que:" + Environment.NewLine + "- La solicitud de crédito sea del tipo EMPRESARIAL." + Environment.NewLine + "- La solicitud haya sido VINCULADA con su evaluación respectiva.", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarPropuesta(int idSol)
        {
            DataTable Prop = Evalua.CNConsPropuesta(idSol);
            if (Prop.Rows.Count>0)
            {
                txtDetNegocio.Text      = Prop.Rows[0]["cNegocio"].ToString();
                txtDetDestino.Text      = Prop.Rows[0]["cExpCrediticia"].ToString();
                txtDetExperiencia.Text  = Prop.Rows[0]["cDestinoCredito"].ToString();
                txtDetEntorno.Text      = Prop.Rows[0]["cEntornoFamiliar"].ToString();
                txtDetEvaluacion.Text   = Prop.Rows[0]["cEvaluacion"].ToString();
                txtDetGarantia.Text     = Prop.Rows[0]["cGarantia"].ToString();
                txtConclusiones.Text    = Prop.Rows[0]["cConclusiones"].ToString();
                Habilitar(false);
            }
            else
            {
                Habilitar(true);
                txtDetNegocio.Focus();
            }
        }
        private void Habilitar(Boolean lActiva)
        {
            btnImprimir1.Enabled    = !lActiva;
            btnGrabar1.Enabled      = lActiva;
            btnEditar1.Enabled      = !lActiva;

            grbEvalCualitativa.Enabled  = lActiva;
            grbRatios.Enabled           = lActiva;
            grbGarantias.Enabled        = lActiva;
            grbConclusiones.Enabled     = lActiva;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                int idSolicitud = conBusCuentaCli.nValBusqueda;
                decimal nGarantia = 0;
                if (string.IsNullOrEmpty(txtGarantia.Text))
                {
                    nGarantia = 0;
                }
                else
                {
                    nGarantia = Convert.ToDecimal(txtGarantia.Text);
                }

                string cNegocio     = txtDetNegocio.Text;
                string cDestino     = txtDetDestino.Text;
                string cExperiencia = txtDetExperiencia.Text;
                string cEntorno     = txtDetEntorno.Text;
                string cEvalua      = txtDetEvaluacion.Text;
                string cGarantia    = txtDetGarantia.Text;
                string cConclusion  = txtConclusiones.Text;

                DataTable dtResultado = Evalua.CNInsUpdPropuesta(idSolicitud, nGarantia, cNegocio, cExperiencia,
                        cDestino, cEntorno, cEvalua, cGarantia, cConclusion);

                if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 0)
                {
                    MessageBox.Show("Error en Grabación", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Habilitar(true);
                    return;
                }
                else
                {
                    MessageBox.Show("Datos Actualizados Correctamente", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(false);
                    return;
                }
            }
        }

        private Boolean Valida()
        {
            if (string.IsNullOrEmpty(txtDetNegocio.Text))
            {
                MessageBox.Show("Ingresar comentario sobre el negocio", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDetDestino.Text))
            {
                MessageBox.Show("Ingresar comentario sobre el Destino del Crédito", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDetExperiencia.Text))
            {
                MessageBox.Show("Ingresar comentario sobre experiencia crediticia del cliente", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDetEntorno.Text))
            {
                MessageBox.Show("Ingresar comentario sobre entorno familiar del cliente", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDetEvaluacion.Text))
            {
                MessageBox.Show("Ingresar comentario sobre la evaluación", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDetGarantia.Text))
            {
                MessageBox.Show("Ingresar comentario sobre las garantías", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtConclusiones.Text))
            {
                MessageBox.Show("Ingresar las conclusiones de la evaluación", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            Habilitar(true);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idsolici = conBusCuentaCli.nValBusqueda;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("x_idSolicitud", idsolici.ToString(), false));  

            DataTable dtRutaLogo = new clsRPTCNAgencia().CNRutaLogo();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", dtRutaLogo));
            dtslist.Add(new ReportDataSource("dtsComentarios", Evalua.CNConsPropuesta(idsolici)));
            dtslist.Add(new ReportDataSource("dtsDatoCredito", Sol));
            dtslist.Add(new ReportDataSource("dtsExcepciones", Evalua.CNConsExcepciones(idsolici)));

            string reportpath = "RptPropuestaCredito.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            //Limpiar campos
            //------------- Combo búsqueda ------------------------>
            txtMonSolicitado.Clear();
            txtMoneda.Clear();
            txtTipoCredito.Clear();
            txtProducto.Clear();
            txtGarantia.Clear();
            txtNumCuotas.Clear();
            txtFrecuencia.Clear();
            txtTasaInteres.Clear();
            txtActividad.Clear();
            txtDestino.Clear();
            txtTipoPeriodo.Clear();
            txtDiaGracia.Clear();

            txtMontProp.Clear();
            txtTEM.Clear();
            txtNroCuotas.Clear();
            txtCuotaAprox.Clear();
            //---------------------------------------------------->

            txtDetNegocio.Clear();
            txtDetDestino.Clear();
            txtDetExperiencia.Clear();
            txtDetEntorno.Clear();

            txtDetEvaluacion.Clear();
            txtDetGarantia.Clear();
            txtConclusiones.Clear();

            btnEditar1.Enabled  = false;
            btnImprimir1.Enabled= false;
            btnGrabar1.Enabled  = false;

            grbEvalCualitativa.Enabled  = false;
            grbRatios.Enabled           = false;
            grbGarantias.Enabled        = false;
            grbConclusiones.Enabled     = false;

            conBusCuentaCli.limpiarControles();
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;

            conBusCuentaCli.txtNroBusqueda.Focus();
        }
    }
}
