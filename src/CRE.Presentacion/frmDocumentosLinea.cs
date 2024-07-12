using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDocumentosLinea : frmBase
    {

        #region Variables Globales
        int nIdCliente = 0, idCuenta = 0, idEvalCred = 0, idSolicitud = 0, idTipEvalCred = 0;
        string cIdSolicitud="";
        DataTable dtCreditos;
        int idSolicitudCredGrupoSol = 0, idGS=0, idEvalCredGS=0;
       

        #endregion

        #region Eventos
        public frmDocumentosLinea()
        {
            InitializeComponent();
            this.conBusGrupoSol1.txtIdGrupoSolidario.Enabled = true;
            this.conBusGrupoSol1.txtNombreGrupo.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
                InitializeComponent();
                this.conBusGrupoSol1.txtIdGrupoSolidario.Enabled = true;
                this.conBusGrupoSol1.txtNombreGrupo.Enabled = true;
                idSolicitudCredGrupoSol = 0;
                idGS = 0;
                nIdCliente = 0; idCuenta = 0; idEvalCred = 0; idSolicitud = 0; idTipEvalCred=0;
                cIdSolicitud = "";
                idSolicitudCredGrupoSol = 0; idGS = 0; idEvalCredGS = 0;
           
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (String.IsNullOrEmpty(conBusCli1.txtCodCli.Text.Trim()))
                {
                    MessageBox.Show("No hay datos para buscar \n", "Documentos en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                asignarVariable();

                clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(nIdCliente, "T", "[]");

                if (dtDatosCuentaSolCliente.Rows.Count == 0)
                {
                    MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    MessageBox.Show("A continuación seleccione el crédito.", "Selección de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                    frmBusCuenCli.CargarDatos(nIdCliente, "T", "[]");
                    frmBusCuenCli.ShowDialog();
                    
                    idSolicitud = Convert.ToInt32(frmBusCuenCli.idSolicitud);
                    DataTable dtRetornaCuentaXSolicitud = RetornaCuentaSolCliente.RetornaCuentaXSolicitud(idSolicitud);
                    
                    idCuenta = Convert.ToInt32(dtRetornaCuentaXSolicitud.Rows[0]["idCuenta"].ToString());

                    cIdSolicitud = frmBusCuenCli.idSolicitud;
                    if (idCuenta == 0 && idSolicitud == 0)
                    {
                        MessageBox.Show("No seleccionó una cuenta de crédito \n", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                cargarCuentasVinculadasASolicitud(-1);
                if(idSolicitud!=0)
                    agregarCreditos(idCuenta);
                buscarEvalCred();
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                //if (Convert.ToInt32(conBusGrupoSol1.txtIdGrupoSolidario.Text.ToString()) == 0)
                //{
                //    MessageBox.Show("No hay datos para buscar \n", "Documentos en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                if (String.IsNullOrEmpty(conBusGrupoSol1.txtIdGrupoSolidario.Text.Trim()))
                {
                    MessageBox.Show("No hay datos para buscar \n", "Documentos en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                idGS = Convert.ToInt32(conBusGrupoSol1.txtIdGrupoSolidario.Text.ToString());
                //cargarSolicitudesGrupoSol(idGS);
                clsCNSolicitud nListSoli = new clsCNSolicitud();
                //dtCreditosGrup = nListCreditosAmp.CNRetCuentasAmpliadas(idGrupo);//Aplica para ampliación y refinanciación
                DataTable dtResultado = nListSoli.CNBuscaSolicitudesGS(idGS);
                dtgBase1.Enabled = true;
                dtgBase1.DataSource = dtResultado;
                cargarSolicitudesGrupoSol();


            }

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (idSolicitud == 0)
                {
                    MessageBox.Show("No selecciono alguna solicitud \n", "Documentos en Linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (idSolicitud != 0)
                {
                    DataTable dtResul = new clsRPTCNCredito().DatosAprobador(idSolicitud);
                    int idUsuApro = Convert.ToInt32(dtResul.Rows[0]["idUsuApro"]);

                    frmExpEval frmExpEval = new frmExpEval(idEvalCred, idSolicitud, idTipEvalCred, 1);
                    frmExpEval.ShowDialog();

                }
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {

                if (idGS == 0 || idEvalCredGS == 0)
                {
                    MessageBox.Show("No selecciono alguna solicitud \n", "Documentos en Linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (idGS != 0 && idEvalCredGS != 0)
                {
                                                       //grupo,solicitud,idEvalCredGrupoSol,2
                    frmExpEval frmExpEval = new frmExpEval(idGS, idSolicitudCredGrupoSol, idEvalCredGS, 2);
                    frmExpEval.ShowDialog();
                }
            }


        }
        
        #endregion
        
        #region Metodos
        private void asignarVariable()
        {
            nIdCliente = conBusCli1.idCli;
        
        }


        private void agregarCreditos(int idCuentaCre)
        {
            CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
            clsCredito entCredito = credito.retornaDatosCredito(idCuentaCre);

            DataRow drCredito = dtCreditos.NewRow();
            drCredito["idSolicitud"] = "0";
            drCredito["nCapitalDesembolso"] = entCredito.nCapitalDesembolso;
            drCredito["idCuenta"] = entCredito.idCuenta;
            drCredito["nTotal"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado) +
                                    (entCredito.nInteresDia - entCredito.nInteresPagado) +
                                    (entCredito.nMoraGenerado - entCredito.nMoraPagada) +
                                    (entCredito.nOtrosGenerado - entCredito.nOtrosPagado) +
                                    (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["nSalCapital"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado);
            drCredito["nSalInteres"] = (entCredito.nInteresDia - entCredito.nInteresPagado);
            drCredito["nSalMora"] = (entCredito.nMoraGenerado - entCredito.nMoraPagada);
            drCredito["nSalOtros"] = (entCredito.nOtrosGenerado - entCredito.nOtrosPagado);
            drCredito["nSalIntComp"] = (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["lPermQuitar"] = 1;
            drCredito["nTasaCompensatoria"] = entCredito.nTasaCompensatoria;
            drCredito["nTasaMoratoria"] = entCredito.nTasaMoratoria;


            dtCreditos.Rows.Add(drCredito);

            //txtBase1.Text = dtCreditos.Compute("Sum(nTotal)", "").ToString();
            txtBase1.Text = entCredito.nCapitalDesembolso.ToString();
            txtBase2.Text = entCredito.idCuenta.ToString();
            cIdSolicitud = idSolicitud.ToString();//entCredito.idSolicitud.ToString();
            
        }


        private void cargarCuentasVinculadasASolicitud(int idSolicitud)
        {
            clsCNSolicitud nListCreditosAmp = new clsCNSolicitud();
            dtCreditos = nListCreditosAmp.CNRetCuentasAmpliadas(idSolicitud);//Aplica para ampliación y refinanciación

            dtgCuentaCreditoVinculado.DataSource = dtCreditos;
            dtgCuentaCreditoVinculado.Columns["idCuenta"].DisplayIndex = 0;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].DisplayIndex = 1;
            dtgCuentaCreditoVinculado.Columns["idSolicitud"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["lPermQuitar"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaCompensatoria"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaMoratoria"].Visible = false;
            //dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["idCuenta"].HeaderText = "CUENTA";
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].HeaderText = "DESEMBOLSO";
            dtgCuentaCreditoVinculado.Columns["nTotal"].HeaderText = "SALDO CREDITO";
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].HeaderText = "SALDO CAPITAL";
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].HeaderText = "SALDO INTERES";
            dtgCuentaCreditoVinculado.Columns["nSalMora"].HeaderText = "SALDO MORA";
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].HeaderText = "SALDO OTROS";
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].HeaderText = "SALDO INT. COMPENSATORIO";
            
            dtgCuentaCreditoVinculado.Columns["idCuenta"].Width = 80;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nTotal"].Width = 108;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].Width = 180;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].Width = 100;

            dtgCuentaCreditoVinculado.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //txtBase1.Text = dtCreditos.Compute("Sum(nTotal)", "").ToString();
            dtgCuentaCreditoVinculado.ClearSelection();

        }

        private void buscarEvalCred()
        { 
            idSolicitud = Convert.ToInt32(cIdSolicitud);
            CRE.CapaNegocio.clsCNCredito credi = new CRE.CapaNegocio.clsCNCredito();
            DataTable dtResultado = credi.CNBuscarDatosDocumentacion(idSolicitud);

            idEvalCred = Convert.ToInt32(dtResultado.Rows[0]["idEvalCred"]);
            idTipEvalCred = Convert.ToInt32(dtResultado.Rows[0]["idTipEval"]);
            txtBase3.Text = Convert.ToString(idSolicitud);
            txtBase4.Text = Convert.ToString(idEvalCred);
            txtBase5.Text = Convert.ToString(dtResultado.Rows[0]["cTipEvalCred"]);
            txtBase6.Text = Convert.ToString(dtResultado.Rows[0]["cProducto"]);

        }
        #endregion

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol1.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", "Documentación en Línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // LimpiarControles();
                return;
            }

            //this.InsertarDatos(this.conBusGrupoSol1.dtGrupo, this.conBusGrupoSol1.dtIntegrantes);
        }
        private void hola()
        {
            if (this.tabControl1.SelectedIndex==0)
            {
                MessageBox.Show("1 individuales");
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                MessageBox.Show("2 grupales");
            }
        
        }
        private void cargarSolicitudesGrupoSol()
        {

            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dtgBase1.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgBase1.Columns["cEstado"].Visible = true;
            dtgBase1.Columns["cNombreAge"].Visible = true;
            dtgBase1.Columns["cOperacion"].Visible = true;
            dtgBase1.Columns["nMontoSolicitado"].Visible = true;
            dtgBase1.Columns["nMontoAprobado"].Visible = true;
            dtgBase1.Columns["nCuotas"].Visible = true;
            //dtgBase1.Columns["nPlazoCuota"].Visible = true;


            dtgBase1.Columns["idSolicitudCredGrupoSol"].HeaderText = "N°Solicitud";
            dtgBase1.Columns["cEstado"].HeaderText = "Estado";
            dtgBase1.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgBase1.Columns["cOperacion"].HeaderText = "Operacion";
            dtgBase1.Columns["nMontoSolicitado"].HeaderText = "Monto Solic.";
            dtgBase1.Columns["nMontoAprobado"].HeaderText = "Monto Aprob.";
            dtgBase1.Columns["nCuotas"].HeaderText = "Cuotas";
           // dtgBase1.Columns["nPlazoCuota"].HeaderText = "Plazo Cuota";

            dtgBase1.Columns["idSolicitudCredGrupoSol"].Width = 30;
            dtgBase1.Columns["cEstado"].Width = 50;
            dtgBase1.Columns["cNombreAge"].Width = 50;
            dtgBase1.Columns["cOperacion"].Width = 50;
            dtgBase1.Columns["nMontoSolicitado"].Width = 50;
            dtgBase1.Columns["nMontoAprobado"].Width = 50;
            dtgBase1.Columns["nCuotas"].Width = 50;
            //dtgBase1.Columns["nPlazoCuota"].Width = 50;

            dtgBase1.Columns["idSolicitudCredGrupoSol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["cEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["cNombreAge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["cOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nMontoSolicitado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nMontoAprobado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nCuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          //  dtgBase1.Columns["nPlazoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void dtgBase1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idSolicitudCredGrupoSol = Convert.ToInt32(dtgBase1.Rows[dtgBase1.SelectedCells[0].RowIndex].Cells["idSolicitudCredGrupoSol"].Value.ToString());
            idEvalCredGS=Convert.ToInt32(dtgBase1.Rows[dtgBase1.SelectedCells[0].RowIndex].Cells["idEvalCredGrupoSol"].Value.ToString());
            this.txtBase7.Text = Convert.ToString(idSolicitudCredGrupoSol);
            this.txtBase8.Text=Convert.ToString(idEvalCredGS);

        }







    }
}
