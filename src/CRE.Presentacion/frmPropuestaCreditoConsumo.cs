using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmPropuestaCreditoConsumo : frmBase
    {
        DataTable       Sol;
        clsCNEvaluacion Evalua  = new clsCNEvaluacion();
        int idTipoPeriodo       = 0;

        public frmPropuestaCreditoConsumo()
        {
            InitializeComponent();
            this.conBusCuentaCli.cTipoBusqueda  = "S";
            this.conBusCuentaCli.cEstado        = "[1,2]"; //SOLICITADO - APROBADO
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if (CodSol != 0)
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = false;
                conBusCuentaCli.btnBusCliente1.Enabled = false;
                BuscarSolicitud(CodSol);//Busacr solicitud de crédito consumo
                if (string.IsNullOrEmpty(txtMonSolicitado.Text)) return;
                BuscarPropuesta(CodSol);//Buscar propuesta de crédito Consumo

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
                MessageBox.Show("El Cliente no tiene una solicitud de Crédito vigente.", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("El Cliente no tiene una solicitud de Crédito vigente.", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarSolicitud(int idSol)
        {
            Sol = Evalua.CNConsPropuestaCreConsumo(idSol);

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
                if (idTipoPeriodo == 1)//Fecha Fija
                {
                    lblFrec.Text = "Día de Pago: ";
                }
                if (idTipoPeriodo == 2)//Periodo Fijo
                {
                    lblFrec.Text = "Frecuencia: ";
                    lblEnDias.Visible = true;
                }

                DataTable dtTasaGarantia = new clsCNGarantia().CNSaldoTasado(idSol);
                if (dtTasaGarantia.Rows.Count > 0)
                {
                    txtGarantia.Text = dtTasaGarantia.Rows[0]["nSaldo"].ToString();
                }

                //Cargar Datos del crédito Propuesto:
                txtMontProp.Text    = Sol.Rows[0]["nMonPropuesto"].ToString(); 
                txtNroCuotas.Text   = Sol.Rows[0]["nNumcuotas"].ToString(); 
                txtTEM.Text         = Sol.Rows[0]["nTEM"].ToString(); 
                txtCuotaAprox.Text  = Sol.Rows[0]["nCuotaAprox"].ToString(); 
            }
            else
            {
                MessageBox.Show("No se encontró la solicitud, verifique que:" + Environment.NewLine + "- La solicitud de crédito sea del tipo CONSUMO." + Environment.NewLine + "- La solicitud haya sido VINCULADA con su evaluación respectiva.", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarPropuesta(int idSol)
        {
            DataTable Prop = Evalua.CNConsPropuestaConsumo(idSol);
            if (Prop.Rows.Count > 0)
            {
                txtEntornoFamDomicil.Text= Prop.Rows[0]["cEntornoFam"].ToString();
                txtVerificLaboral.Text  = Prop.Rows[0]["cVerificLaboral"].ToString();
                txtOtrosIngrAcred.Text  = Prop.Rows[0]["cOtrosIngr"].ToString();

                txtAvalGarante.Text     = Prop.Rows[0]["cAvalGarante"].ToString();
                txtDescrPatrim.Text     = Prop.Rows[0]["cPatrimonio"].ToString();
                txtDestinoCre.Text      = Prop.Rows[0]["cDestinoCre"].ToString();             
                
                Habilitar(false);
            }
            else
            {
                Habilitar(true);
                txtEntornoFamDomicil.Focus();
            }
        }
        private void Habilitar(Boolean lActiva)
        {
            btnImprimir1.Enabled        = !lActiva;
            btnGrabar1.Enabled          = lActiva;
            btnEditar1.Enabled          = !lActiva;
            grbEvalCualitativa.Enabled  = lActiva;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                int idSolicitud     = conBusCuentaCli.nValBusqueda;
                decimal nGarantia   = 0;
                if (string.IsNullOrEmpty(txtGarantia.Text))
                {
                    nGarantia = 0;
                }
                else
                {
                    nGarantia = Convert.ToDecimal(txtGarantia.Text);
                }

                string cEntornoFamDomicil   = txtEntornoFamDomicil.Text;
                string cVerificLaboral      = txtVerificLaboral.Text;
                string cOtrosIngrAcred      = txtOtrosIngrAcred.Text;

                string cAvalGarante = txtAvalGarante.Text;
                string cDescrPatrim = txtDescrPatrim.Text;
                string cDestinoCre  = txtDestinoCre.Text;

                DataTable dtResultado = Evalua.CNInsUpdPropuestaCreConsumo(idSolicitud, nGarantia,
                                cEntornoFamDomicil, cVerificLaboral,cOtrosIngrAcred,
                                cAvalGarante, cDescrPatrim, cDestinoCre);
                if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 0)
                {
                    MessageBox.Show("Error en Grabación", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Habilitar(true);
                    return;
                }
                else
                {
                    MessageBox.Show("Datos Actualizados Correctamente", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(false);
                    return;
                }
            }
        }

        private Boolean Valida()
        {
            if (string.IsNullOrEmpty(txtEntornoFamDomicil.Text))
            {
                MessageBox.Show("Ingresar comentario sobre el ENTORNO FAMILIAR", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtVerificLaboral.Text))
            {
                MessageBox.Show("Ingresar comentario sobre la VERIFICACIÓN LABORAL", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtOtrosIngrAcred.Text))
            {
                MessageBox.Show("Ingresar comentario sobre OTROS INGRESOS ACREDITADOS", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtAvalGarante.Text))
            {
                MessageBox.Show("Ingresar comentario sobre el AVAL O GARANTE", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescrPatrim.Text))
            {
                MessageBox.Show("Ingresar comentario sobre DESCRIPCIÓN DEL PATRIMONIO", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDestinoCre.Text))
            {
                MessageBox.Show("Ingresar las conclusiones sobre el DESTINO DEL CRÉDITO", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            dtslist.Add(new ReportDataSource("dtsPropuestaCreConsumo", Evalua.CNConsPropuestaConsumo(idsolici)));
            dtslist.Add(new ReportDataSource("dtsDatoCredito", Sol));
            dtslist.Add(new ReportDataSource("dtsExcepciones", Evalua.CNConsExcepciones(idsolici)));

            string reportpath = "RptPropuestaCreditoConsum.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            //Limpiar campos
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

            txtEntornoFamDomicil.Clear();
            txtVerificLaboral.Clear();
            txtOtrosIngrAcred.Clear();
            txtAvalGarante.Clear();
            txtDescrPatrim.Clear();
            txtDestinoCre.Clear();            

            btnEditar1.Enabled = false;
            btnImprimir1.Enabled = false;
            btnGrabar1.Enabled = false;

            grbEvalCualitativa.Enabled = false;

            conBusCuentaCli.limpiarControles();
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;

            conBusCuentaCli.txtNroBusqueda.Focus();
        }
    }
}
