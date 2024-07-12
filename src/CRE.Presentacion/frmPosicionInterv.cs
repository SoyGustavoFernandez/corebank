#region Referencias
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
using EntityLayer;
using GEN.PrintHelper;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.CapaNegocio;
#endregion

namespace CRE.Presentacion
{
    public partial class frmPosicionInterv : frmBase
    {
        #region Variables Globales

        DataTable dtLisInterv = new DataTable("dtLisIntervSol");
        clsCNBuscarCli cncliente = new clsCNBuscarCli();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        int idCli = 0;
        int idIndicador = 0;
        DataTable dtIntervi = new DataTable();
        #endregion   

        #region Eventos

        private void frmPosicionInterv_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            dtLisInterv.Columns.Add("cDocumentoID", typeof(string));
            dtLisInterv.Columns.Add("cNombre", typeof(string));
            dtLisInterv.Columns.Add("lCliente", typeof(bool));
            dtLisInterv.Columns.Add("idCli", typeof(int));
            dtLisInterv.Columns.Add("idTipoDocumento", typeof(int));

            dtgIntervinientes.DataSource = dtLisInterv.DefaultView;
            dtgIntervinientes.Columns["idCli"].Visible = false;
            dtgIntervinientes.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            dtgIntervinientes.Columns["cNombre"].HeaderText      = "Nombres/Razón Social";
            dtgIntervinientes.Columns["lCliente"].HeaderText = "Cliente";
            dtgIntervinientes.Columns["cDocumentoID"].Width = 80;
            dtgIntervinientes.Columns["lCliente"].Width = 55;
            dtgIntervinientes.Columns["idTipoDocumento"].Visible = false;
            
            foreach (DataGridViewColumn item in dtgIntervinientes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            txtCBNumDoc.Focus();
            if (idIndicador == 1)
            {
                agregarPersonaExterno(dtIntervi);
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                agregarPersona();
            }            
        }

        private void txtCBNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (validar())
                {
                    agregarPersona();
                }
            }
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgIntervinientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Validación eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Int32 nFilaActual = Convert.ToInt32(this.dtgIntervinientes.SelectedCells[0].RowIndex);
            dtgIntervinientes.Rows.RemoveAt(nFilaActual);

            if (dtgIntervinientes.Rows.Count == 0)
            {
                btnImprimir.Enabled = false;
            }
            txtCBNumDoc.Focus();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgIntervinientes.RowCount <= 0)
            {
                MessageBox.Show("Debe agregar al menos un Interviniente", "Imprimir posición de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dtgIntervinientes.Rows)
            {
                string cDocumentoID = Convert.ToString(row.Cells["cDocumentoID"].Value);
                string cNombre = Convert.ToString(row.Cells["cNombre"].Value);
                int idCli = Convert.ToInt32(row.Cells["idCli"].Value);
                int idTipoDocumento = Convert.ToInt32(row.Cells["idTipoDocumento"].Value);

                this.Cursor = Cursors.WaitCursor;
                MostrarReporte(cDocumentoID, cNombre, idCli, idTipoDocumento);
                this.Cursor = Cursors.Default;
            }
        }
      
        #endregion

        #region Metodos

        public frmPosicionInterv()
        {
            InitializeComponent();
        }

        public frmPosicionInterv(DataTable dt)
        {
            InitializeComponent();
            dtIntervi = dt;
            idIndicador = 1;
        }
  
        private void agregarPersona()
        {
            //string cCriterio = "";
            var cDocumento = this.txtCBNumDoc.Text.Trim();
            int idTipoDocumento = Convert.ToInt32(cboTipoDocumento1.SelectedValue);

            var dtCliente = cncliente.ListarClientesPosInt(idTipoDocumento, cDocumento);

            if (dtCliente.Rows.Count > 0)
            {
                dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = this.txtCBNumDoc.Text;
                dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = dtCliente.Rows[0]["cNombre"].ToString(); 
                dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = true;
                dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]);
            }

            else
            {
                var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBSPosInt(idTipoDocumento, cDocumento);
                var dtPersonaCampania = cninterviniente.CNValidaExistePersonaCampania(idTipoDocumento, cDocumento);

                if (dtPersonaSBS.Rows.Count > 0)
                {
                    dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = this.txtCBNumDoc.Text;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = dtPersonaSBS.Rows[0]["cNombre"].ToString(); 
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = false;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = -1;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = idTipoDocumento;
                }
                else if (dtPersonaCampania.Rows.Count > 0)
                {
                    MessageBox.Show("Documento ingresado no contiene registros históricos ni base de datos de RCC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = this.txtCBNumDoc.Text;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = dtPersonaCampania.Rows[0]["cNombre"].ToString(); ;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = false;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = -1;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = idTipoDocumento;
                }

                else
                {                    
                    MessageBox.Show("Documento ingresado no contiene registros históricos ni base de datos de RCC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = this.txtCBNumDoc.Text;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = "NO IDENTIFICADO";
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = false;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = -1;
                    dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = idTipoDocumento;
                }

                

            }

            limpiar();
            btnImprimir.Enabled = true;
        }
        public void agregarPersonaExterno(DataTable dtPersonas)
        {

            if (dtPersonas.Rows.Count > 0)
            {
                for (int i = 0; i < dtPersonas.Rows.Count; i++)
                {

                    string cCriterio = "";
                    var cDocumento = dtPersonas.Rows[i]["cDocumentoID"].ToString();// this.txtCBNumDoc.Text.Trim();
                    int idTipoDocumento = Convert.ToInt32(dtPersonas.Rows[i]["idTipoDocumento"].ToString());// Convert.ToInt32(cboTipoDocumento1.SelectedValue);

                    var dtCliente = cncliente.ListarClientesPosInt(idTipoDocumento, cDocumento);

                    if (dtCliente.Rows.Count > 0)
                    {
                        dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                        dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = Convert.ToString(cDocumento);// this.txtCBNumDoc.Text;
                        dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = dtCliente.Rows[0]["cNombre"].ToString();
                        dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = true;
                        dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                        dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]);
                    }

                    else
                    {
                        var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBSPosInt(idTipoDocumento, cDocumento);
                        if (dtPersonaSBS.Rows.Count > 0)
                        {
                            dtLisInterv.Rows.Add(dtLisInterv.NewRow());
                            dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cDocumentoID"] = Convert.ToString(cDocumento);//this.txtCBNumDoc.Text;
                            dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["cNombre"] = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                            dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["lCliente"] = false;
                            dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idCli"] = 0;
                            dtLisInterv.Rows[dtLisInterv.Rows.Count - 1]["idTipoDocumento"] = idTipoDocumento;
                        }
                        else
                        {
                            MessageBox.Show("Documento ingresado no contiene registros históricos ni base de datos de RCC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    limpiar();
                    btnImprimir.Enabled = true;
                }
            }
        }

               
        private void limpiar()
        {
            this.txtCBNumDoc.Text = "";
        }

        private bool validar()
        {
            bool lEstado = false;

            var cDocumento = this.txtCBNumDoc.Text.Trim().Replace(".","").Replace(",","");

            if (cDocumento == "")
            {
                MessageBox.Show("Debe de ingresar el número de documento", "Posición de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return lEstado;
            }

            if (cDocumento.Length < 8)
            {
                MessageBox.Show("Debe de ingresar el número de documento válido", "Posición de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return lEstado;
            }

            int nExiste = dtLisInterv.AsEnumerable().Where(x => x["cDocumentoID"].ToString() == cDocumento).Count();
            if (nExiste > 0)
            {
                MessageBox.Show("Ya agregó a una persona con el número de documento: " + cDocumento, "Validación agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lEstado;
            }

            //if (this.txtNombre.Text.ToString().Trim() == "")
            //{
            //    MessageBox.Show("Debe de ingresar el nombre del interviniente", "Posición de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return lEstado;
            //}

            lEstado = true;
            return lEstado;
        }
        public decimal minValorDatatable(DataTable dtSaldos, string cClave)
        {
            decimal nMinSaldo = 0;
            foreach (DataRow row in dtSaldos.Rows)
            {
                decimal nSaldo = Convert.ToDecimal(row[cClave]);

                if (nSaldo != 0)
                {
                    if (nMinSaldo == 0)
                    {
                        nMinSaldo = nSaldo;
                    }

                    if (nMinSaldo > nSaldo)
                    {
                        nMinSaldo = nSaldo;
                    }
                }
            }
            return nMinSaldo;
        }

        public decimal maxValorDatatable(DataTable dtSaldos, string cClave)
        {
            decimal nMaxSaldo = 0;
            foreach (DataRow row in dtSaldos.Rows)
            {
                decimal nSaldo = Convert.ToDecimal(row[cClave]);

                if (nSaldo != 0)
                {
                    if (nMaxSaldo == 0)
                    {
                        nMaxSaldo = nSaldo;
                    }

                    if (nMaxSaldo < nSaldo)
                    {
                        nMaxSaldo = nSaldo;
                    }
                }
            }
            return nMaxSaldo;
        }

        public void MostrarReporteAnonimo(string cDocumentoID, int idTipoDocumento)
        {
            DataTable dtCalfInterv = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, 1);
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("cDocumentoId", cDocumentoID, false));
            listPar.Add(new ReportParameter("cTipoDocumento", dtCalfInterv.Rows[0]["cTipoDocumento"].ToString(), false));

            string reportpath = "RptPosInterv1.rdlc";
            new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
        }

        public void nuevoReporte(int idTipoDocumento, string cDocumentoID)
        {
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("dFechaConsulta", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("idTipoDocumento", Convert.ToString(idTipoDocumento), false));
            listPar.Add(new ReportParameter("cNumDocumento", cDocumentoID, false));

            dtslist.Add(new ReportDataSource("dtsLisVinculadosaCli", cninterviniente.CNdtLisVinculadosaCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire", cninterviniente.CNdtLisCliCreMismaDire(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsRastreo", cninterviniente.CNdtLstRastreoInt(cDocumentoID, idTipoDocumento)));

            dtslist.Add(new ReportDataSource("dtCRE_PI2_CalifEntityRccSbs_SP", cninterviniente.dtCalifEntityRccSbs(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_saldosSbsTitCony_SP", cninterviniente.dtsaldosSbsTitCony(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisAvaladosRCCSBS_SP", cninterviniente.dtLisAvaladosRCCSBS(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCreCliFiSol_SP", cninterviniente.dtLisCreCliFiSol(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_ListaCartasFianzaCliente_SP", cninterviniente.dtListaCartasFianzaCliente(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_ClasifiInternaCaja_SP", cninterviniente.dtClasifiInternaCaja(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisPEPPosInterv_SP", cninterviniente.dtLisPEPPosInterv(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisBaseNegativa_SP", cninterviniente.dtLisBaseNegativa(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisLibBaseNegativa_SP", cninterviniente.dtLisLibBaseNegativa(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LstSolicitudesCli_sp", cninterviniente.dtLstSolicitudesCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCrexCli_SP", cninterviniente.dtLisCrexCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCredPreApro_SP", cninterviniente.dtLisCredPreApro(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisGarOtrUtixCli_SP", cninterviniente.dtLisGarOtrUtixCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisGarxCli_SP", cninterviniente.dtLisGarxCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCtaAhoxCli_SP", cninterviniente.dtLisCtaAhoxCli(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliCreMismaDire_SP", cninterviniente.dtLisCliCreMismaDire(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliRelaGrupoEcono_SP", cninterviniente.dtLisCliRelaGrupoEcono(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_CliPosiblesParientes_SP", cninterviniente.dtCliPosiblesParientes(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisCliMismaGar_SP", cninterviniente.dtLisCliMismaGar(idTipoDocumento, cDocumentoID)));
            dtslist.Add(new ReportDataSource("dtCRE_PI2_LisDirNumTelPar_SP", cninterviniente.dtLisDirNumTelPar(idTipoDocumento, cDocumentoID)));

            string reportpath = "RptPosInterv4.rdlc";
            frmReporteLocal objfrmReporteador = new frmReporteLocal(dtslist, reportpath, listPar);
            objfrmReporteador.rpvReporteLocal.ShowPrintButton = false;

            registrarRastreo(idCli, 0, "Consulta - Posición integral de intervinientes", this.btnImprimir, cDocumentoID);

            objfrmReporteador.ShowDialog();
        }

        public void MostrarReporte(string cDocumentoID, string cNombre, int idCli, int idTipoDocumento = 0)
        {
            // VALIDAR SI idTipodocumento = 0 obtener tipo documento
            DataTable dtCliente = new clsCNBuscarCli().ListarclixIdCli(idCli);
            if (idTipoDocumento == 0)
            {
                idTipoDocumento = Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]);
            }

            if (cNombre == "NO IDENTIFICADO" && idCli == -1)
            {
                /**
                 * 
                 * En caso no esta identificado
                 * 
                 */
                MostrarReporteAnonimo(cDocumentoID, idTipoDocumento);
                return;
            }
            else {
                this.nuevoReporte(idTipoDocumento, cDocumentoID);
                return;
            }

            // archivos para cargar el reporte
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            // parametros para el reporte
            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            // Extraer codsbs
            string cCodsbs = "-1";
            DataTable dtCalfInterv = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, 24);
            if (dtCalfInterv.Rows[0]["codsbs"].ToString() != "")
            {
                cCodsbs = dtCalfInterv.Rows[0]["codsbs"].ToString();
            }
            
            // -----------------------------------------------------------------
            // --------------- reunir parametros ---------------
            // -----------------------------------------------------------------
            listPar.Add(new ReportParameter("cNumDocuId", cDocumentoID, false));
            listPar.Add(new ReportParameter("idCli", Convert.ToString(idCli), false));
            listPar.Add(new ReportParameter("idTipDoc", Convert.ToString(idTipoDocumento), false));
            listPar.Add(new ReportParameter("codsbs", cCodsbs, false));

            // datos cliente
            string cTipocliente = " ";
            string cEstadoCivil = " ";
            int idEstadoCivil = -1;
            string cTipoDocumento = dtCalfInterv.Rows[0]["cTipoDocumento"].ToString();
            
            // --------------- edad del cliente ----------------
            DataTable dtEdadCliente = new DataTable();
            DateTime dFechaNacimiento = DateTime.Now;
            if (idCli != -1) // calcula la edad solo si es un cliente
            {
                if (dtCliente.Rows[0]["dFechaNacimiento"].ToString() != "")
                    dFechaNacimiento = DateTime.Parse(dtCliente.Rows[0]["dFechaNacimiento"].ToString());
            }
            if (dtCliente.Rows.Count != 0) 
            {
                cTipocliente = dtCliente.Rows[0]["cTipoCliente"].ToString();
                cEstadoCivil = dtCliente.Rows[0]["cEstadoCivil"].ToString();
                cTipoDocumento = dtCliente.Rows[0]["cTipoDocumento"].ToString();
                if(dtCliente.Rows[0]["idEstadoCivil"] != DBNull.Value)
                    idEstadoCivil = Convert.ToInt32(dtCliente.Rows[0]["idEstadoCivil"]);
                else
                    idEstadoCivil = -1;
            }
            dtEdadCliente = cninterviniente.CNEdadAniosDias(dFechaNacimiento);
            DataTable dtHistSaldosSBS_Titular = new DataTable();
            DataTable dtHistSaldosSBS_Conyuge = new DataTable();

            // --------------- generar el dtDatosTitular -------------------
            DataTable dtDatosTitular = new DataTable();
            dtDatosTitular.Columns.Add("cNombre");
            dtDatosTitular.Columns.Add("anios");
            dtDatosTitular.Columns.Add("dias");
            dtDatosTitular.Columns.Add("cEstadoCivil");
            dtDatosTitular.Columns.Add("cDocumentoId");
            dtDatosTitular.Columns.Add("cTipoCliente");
            dtDatosTitular.Columns.Add("idCliente");
            dtDatosTitular.Columns.Add("cTipoDocumento");
            dtDatosTitular.Columns.Add("idEstadoCivil");
            dtDatosTitular.Rows.Add(
                cNombre,
                dtEdadCliente.Rows[0]["nAnios"].ToString(),
                dtEdadCliente.Rows[0]["nDias"].ToString(),
                cEstadoCivil,
                cDocumentoID,
                cTipocliente,
                idCli.ToString(),
                cTipoDocumento,
                idEstadoCivil
            );

            dtslist.Add(new ReportDataSource("dtsPEP", cninterviniente.CNdtLisDatPEP(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisGarOtrUtixCli", cninterviniente.CNdtLisGarOtrUtixCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisGarxCli", cninterviniente.CNdtLisGarxCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCtaAhoxCli", cninterviniente.CNdtLisCtaAhoxCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire", cninterviniente.CNdtLisCliCreMismaDire(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisVinculadosaCli", cninterviniente.CNdtLisVinculadosaCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono", cninterviniente.CNdtLisCliRelaGrupoEcono(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliMismaGar", cninterviniente.CNdtLisCliMismaGar(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsRastreo", cninterviniente.CNdtLstRastreoInt(cDocumentoID, idTipoDocumento)));
            
            dtslist.Add(new ReportDataSource("BaseNegativa", cninterviniente.CNBaseNegativa(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("LibBaseNegativa", cninterviniente.CNLibBaseNegativa(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtDatosTitular", dtDatosTitular));
            dtslist.Add(new ReportDataSource("dtCalificacionSBS_Titular", dtCalfInterv));
            dtslist.Add(new ReportDataSource("dtLisSolCli_Titular", cninterviniente.CNLisSolCli(cDocumentoID, idTipoDocumento)));
            if (cCodsbs != "-1")
            {
                dtHistSaldosSBS_Titular = cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, 24, 1);
                dtslist.Add(new ReportDataSource("dtHistSaldosSbs_Titular", dtHistSaldosSBS_Titular)); // solo deudas directas
                dtslist.Add(new ReportDataSource("dtSaldosSbsDir_Titular", cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, 0, 1)));
                dtslist.Add(new ReportDataSource("dtSaldosSbsInd_Titular", cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, 0, 2)));
                dtslist.Add(new ReportDataSource("dtLisAvaladosRCCSBS_Titular", cninterviniente.CNAvaladosRCCSBS(cDocumentoID, idTipoDocumento)));
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtHistSaldosSbs_Titular", new DataTable()));
                dtslist.Add(new ReportDataSource("dtSaldosSbsDir_Titular", new DataTable()));
                dtslist.Add(new ReportDataSource("dtSaldosSbsInd_Titular", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisAvaladosRCCSBS_Titular", new DataTable()));
            }
            if (idCli != -1)
            {
                dtslist.Add(new ReportDataSource("LisCarFiaCli", cninterviniente.CNLisCarFiaCli(idCli)));
                dtslist.Add(new ReportDataSource("LisCreCliFiSol", cninterviniente.CNLisCreCliFiSol(idCli)));
                dtslist.Add(new ReportDataSource("dtClasifiInterna", cninterviniente.CNClasifiInterna(idCli, 24)));
                dtslist.Add(new ReportDataSource("dtLisCreCli_Titular", cninterviniente.CNlisCreCli_2(idCli)));
                dtslist.Add(new ReportDataSource("dtLisCrePreApro_Titular", cninterviniente.CNCrePreApro(idCli)));
            }
            else
            {
                dtslist.Add(new ReportDataSource("LisCarFiaCli", new DataTable()));
                dtslist.Add(new ReportDataSource("LisCreCliFiSol", new DataTable()));
                dtslist.Add(new ReportDataSource("dtClasifiInterna", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisCreCli_Titular", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisCrePreApro_Titular", new DataTable()));
            }
            string[] aApellidos = cNombre.Split(' ');
            dtslist.Add(new ReportDataSource("dtPosiParientes", cninterviniente.CNCliPosiblesParientes(idCli, aApellidos[0], aApellidos[1])));
            
            //dtslist.Add(new ReportDataSource("dtsLisCreGarxCli", cninterviniente.CNdtLisCreGarxCli(cDocumentoID, idTipoDocumento)));
            
            // ------------- construir datos conyuge ---------------
            DataTable dtDatosConyuge = new DataTable();
            dtDatosConyuge.Columns.Add("cNombre");
            dtDatosConyuge.Columns.Add("anios");
            dtDatosConyuge.Columns.Add("dias");
            dtDatosConyuge.Columns.Add("cEstadoCivil");
            dtDatosConyuge.Columns.Add("cDocumentoId");
            dtDatosConyuge.Columns.Add("cTipoCliente");
            dtDatosConyuge.Columns.Add("idCliente");
            dtDatosConyuge.Columns.Add("cTipoDocumento");
            dtDatosConyuge.Columns.Add("idEstadoCivil");

            // ------------- comprobar si tiene conyuge -----------------
            DataTable dtListCony = cninterviniente.CNdtVerificarRelacionCliente(cDocumentoID, idTipoDocumento);
            
            string cDocumentoCony = "null";
            int idCliCony = -1;
            string cCodSbsCony = "-1";
            int idTipoDocCony = 0;

            DataTable dtCalfCony = new DataTable();

            if (dtListCony.Rows.Count > 0) // si tiene conyuge
            {
                // -------------- parametros para conyuge ----------------
                idCliCony = Convert.ToInt32(dtListCony.Rows[0]["idCliVin"]);
                cDocumentoCony = dtListCony.Rows[0]["cDocumentoID"].ToString();
                idTipoDocCony = Convert.ToInt32(dtListCony.Rows[0]["idTipoDocumento"]);
                DataTable dtConyuge = new clsCNBuscarCli().ListarclixIdCli(idCliCony);

                // Extraer codsbs
                dtCalfCony = cninterviniente.CNdtListClienCalifSBS(cDocumentoCony, idTipoDocCony, 24);
                if (dtCalfCony.Rows[0]["codsbs"].ToString() != "")
                {
                    cCodSbsCony = dtCalfCony.Rows[0]["codsbs"].ToString();
                }

                // reunir parametros
                listPar.Add(new ReportParameter("cNumDocCony", cDocumentoCony, false));
                listPar.Add(new ReportParameter("idCliCony", Convert.ToString(idCliCony), false));
                listPar.Add(new ReportParameter("idTipDocCony", Convert.ToString(idTipoDocCony), false));
                listPar.Add(new ReportParameter("cCodSbsCony", cCodSbsCony, false));

                // datos conyuge
                string cTipoclienteCony = " ";
                string cEstadoCivilCony = " ";
                string cTipoDocumentoCony = dtCalfCony.Rows[0]["cTipoDocumento"].ToString();
                int idEstadoCivilCony = -1;

                // edad conyuge
                DataTable dtEdadCony = new DataTable();
                DateTime dFechaNacimientoCony = DateTime.Now;
                if (idCliCony != -1) // calcula la edad solo si es un cliente
                {
                    if (dtConyuge.Rows[0]["dFechaNacimiento"].ToString() != "")
                        dFechaNacimientoCony = DateTime.Parse(dtConyuge.Rows[0]["dFechaNacimiento"].ToString());
                }
                if (dtConyuge.Rows.Count != 0)
                {
                    cTipoclienteCony = dtConyuge.Rows[0]["cTipoCliente"].ToString();
                    cEstadoCivilCony = dtConyuge.Rows[0]["cEstadoCivil"].ToString();
                    cTipoDocumentoCony = dtConyuge.Rows[0]["cTipoDocumento"].ToString();
                    idEstadoCivilCony = Convert.ToInt32(dtConyuge.Rows[0]["idEstadoCivil"]);
                }
                dtEdadCony = cninterviniente.CNEdadAniosDias(dFechaNacimientoCony);

                // generar dtDatosConyuge
                dtDatosConyuge.Rows.Add(
                    dtConyuge.Rows[0]["cNombre"].ToString(),
                    dtEdadCony.Rows[0]["nAnios"].ToString(),
                    dtEdadCony.Rows[0]["nDias"].ToString(),
                    cEstadoCivilCony,
                    cDocumentoCony,
                    cTipoclienteCony,
                    idCliCony.ToString(),
                    cTipoDocumentoCony, 
                    idEstadoCivilCony
                );

                // data
                dtslist.Add(new ReportDataSource("lisCarFiaCony", cninterviniente.CNLisCarFiaCli(idCliCony)));
                dtslist.Add(new ReportDataSource("ListCreConyFiSol", cninterviniente.CNLisCreCliFiSol(idCliCony)));
                dtslist.Add(new ReportDataSource("dtCalificacionSBS_Conyuge", dtCalfCony));
                dtslist.Add(new ReportDataSource("dtClasifiInterna_conyuge", cninterviniente.CNClasifiInterna(idCliCony, 24)));
                dtslist.Add(new ReportDataSource("dtsPEP_Conyuge", cninterviniente.CNdtLisDatPEP(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("BaseNegativa_Conyuge", cninterviniente.CNBaseNegativa(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("LibBaseNegativa_Conyuge", cninterviniente.CNLibBaseNegativa(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("LibBaseNegativa_Conyuge", cninterviniente.CNLibBaseNegativa(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtLisCreCli_Conyuge", cninterviniente.CNlisCreCli_2(idCliCony)));
                dtslist.Add(new ReportDataSource("dtlisSolCli_Conyuge", cninterviniente.CNLisSolCli(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtLisGarOtrUtixCli_Conyuge", cninterviniente.CNdtLisGarOtrUtixCli(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtsLisGarxCli_Conyuge", cninterviniente.CNdtLisGarxCli(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtsLisCtaAhoxCli_Conyuge", cninterviniente.CNdtLisCtaAhoxCli(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire_Conyuge", cninterviniente.CNdtLisCliCreMismaDire(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono_Conyuge", cninterviniente.CNdtLisCliRelaGrupoEcono(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtsLisCliMismaGar_Conyuge", cninterviniente.CNdtLisCliMismaGar(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtLisAvaladosRCCSBS_Conyuge", cninterviniente.CNAvaladosRCCSBS(cDocumentoCony, idTipoDocCony)));
                dtslist.Add(new ReportDataSource("dtLisCrePreApro_Conyuge", cninterviniente.CNCrePreApro(idCliCony)));
                if (cCodSbsCony != "-1")
                {
                    dtHistSaldosSBS_Conyuge = cninterviniente.CNdtLisSaldosRCDSBS(cCodSbsCony, 24, 1);
                    dtslist.Add(new ReportDataSource("dtHistSaldosSbs_Conyuge", dtHistSaldosSBS_Conyuge));
                    dtslist.Add(new ReportDataSource("dtSaldosSbsDir_Conyuge", cninterviniente.CNdtLisSaldosRCDSBS(cCodSbsCony, 0, 1)));
                    dtslist.Add(new ReportDataSource("dtSaldosSbsInd_Conyuge", cninterviniente.CNdtLisSaldosRCDSBS(cCodSbsCony, 0, 2)));
                }
                else
                {
                    dtslist.Add(new ReportDataSource("dtHistSaldosSbs_Conyuge", new DataTable()));
                    dtslist.Add(new ReportDataSource("dtSaldosSbsDir_Conyuge", new DataTable()));
                    dtslist.Add(new ReportDataSource("dtSaldosSbsInd_Conyuge", new DataTable()));
                }
            }
            else
            {
                /**
                 * 
                 * En caso no tiene conyuge
                 * 
                 */
                dtDatosConyuge.Rows.Add(
                    " ",
                    " ",
                    " ",
                    " ",
                    "null",
                    " ",
                    "-1",
                    " ",
                    "-1"
                );
                listPar.Add(new ReportParameter("cNumDocCony", "null", false));
                listPar.Add(new ReportParameter("idCliCony", "-1", false));
                listPar.Add(new ReportParameter("idTipDocCony", "null", false));
                listPar.Add(new ReportParameter("cCodSbsCony", "-1", false));

                dtslist.Add(new ReportDataSource("lisCarFiaCony", new DataTable()));
                dtslist.Add(new ReportDataSource("ListCreConyFiSol", new DataTable()));

                dtslist.Add(new ReportDataSource("dtClasifiInterna_conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsPEP_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("BaseNegativa_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("LibBaseNegativa_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("LibBaseNegativa_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisCreCli_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtlisSolCli_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisGarOtrUtixCli_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsLisGarxCli_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsLisCtaAhoxCli_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtsLisCliMismaGar_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisAvaladosRCCSBS_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtLisCrePreApro_Conyuge", new DataTable()));

                dtslist.Add(new ReportDataSource("dtCalificacionSBS_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtHistSaldosSbs_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtSaldosSbsDir_Conyuge", new DataTable()));
                dtslist.Add(new ReportDataSource("dtSaldosSbsInd_Conyuge", new DataTable()));
            }

            dtslist.Add(new ReportDataSource("dtLisDirNumTelPar", cninterviniente.CNDirNumTelPar(idCli, idCliCony)));
            dtslist.Add(new ReportDataSource("dtDatosConyuge", dtDatosConyuge));

            DataTable dtCantEmpr = tCantidadEmpresas(dtCalfInterv, dtCalfCony);
            dtslist.Add(new ReportDataSource("dtCantEmpresas", dtCantEmpr));

            /**
             * 
             * Adds
             * 
             */
            DataTable dtAdds = new DataTable();
            dtAdds.Columns.Add("nMinHistTitular", typeof(decimal));
            dtAdds.Columns.Add("nMaxHistTitular", typeof(decimal));
            dtAdds.Columns.Add("nMinHistConyuge", typeof(decimal));
            dtAdds.Columns.Add("nMaxHistConyuge", typeof(decimal));

            dtAdds.Rows.Add(
                minValorDatatable(dtHistSaldosSBS_Titular, "saldo"),
                maxValorDatatable(dtHistSaldosSBS_Titular, "saldo"),
                minValorDatatable(dtHistSaldosSBS_Conyuge, "saldo"),
                maxValorDatatable(dtHistSaldosSBS_Conyuge, "saldo")
            );
            dtslist.Add(new ReportDataSource("dtAdds", dtAdds));

            string reportpath = "RptPosInterv2.rdlc";
            frmReporteLocal objfrmReporteador = new frmReporteLocal(dtslist, reportpath, listPar);
            objfrmReporteador.rpvReporteLocal.ShowPrintButton = false;
            objfrmReporteador.ShowDialog();
        }

        /**
         * 
         * Crear datatable de Cantidad de empresas SUM
         * 
         */
        public DataTable tCantidadEmpresas(DataTable dtCalfTitular, DataTable dtCalfConyuge)
        {
            DataTable dtResult = new DataTable();

            // configuracion de columnas
            dtResult.Columns.Add("dFecha", typeof(DateTime));
            dtResult.Columns.Add("nCantEmpreTitular");
            dtResult.Columns.Add("nCantEmpreConyuge");
            dtResult.Columns.Add("nCantEmpreSum");
            dtResult.Columns.Add("nOrden", typeof(int));

            for (int j = 0; j < dtCalfTitular.Rows.Count; j++)
            {
                int nCantEmpT = 0;
                int nCantEmpC = 0;
                string cDfecha = "";

                if (dtCalfTitular.Rows.Count > 0)
                {
                    nCantEmpT = Convert.ToInt32(dtCalfTitular.Rows[j]["cantEmpresas"]);
                    cDfecha = dtCalfTitular.Rows[j]["fecha"].ToString();
                }

                if (dtCalfConyuge.Rows.Count > 0) 
                {
                    nCantEmpC = Convert.ToInt32(dtCalfConyuge.Rows[j]["cantEmpresas"]);
                }
                dtResult.Rows.Add(
                    cDfecha,
                    nCantEmpT,
                    nCantEmpC,
                    nCantEmpT + nCantEmpC,
                    dtCalfTitular.Rows.Count - j
                );
            }

            return dtResult;
        }

        /**
         * 
         * Muestra el reporte de una persona juridica
         * 
         */
        public void MostrarReportePerJur(string cDocumentoID, string cNombre, int idCli,int nlastMonths,  int nEdadCliente, string cTipoCliente, int idMoneda = 1)
        {
            /**
             * PARAMETROS
             */

            // string cDocumentoID @param
            // string cNombre @param
            // int idCli @param
            // string nlastMonths @param
            // int idMoneda @param
            int idTipoDocumento = 4;
            string cCodsbs = " ";

            // report data
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            string reportpath = "RptPosInterv1.rdlc";

            // report parameters
            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            listPar.Add(new ReportParameter("cNomInterv", cNombre, false));
            listPar.Add(new ReportParameter("cNumDocuId", cDocumentoID, false));
            
            listPar.Add(new ReportParameter("idCli", Convert.ToString(idCli), false));
            listPar.Add(new ReportParameter("idTipDoc", Convert.ToString(idTipoDocumento), false));
            listPar.Add(new ReportParameter("nlastMonths", Convert.ToString(nlastMonths), false));
            listPar.Add(new ReportParameter("idMoneda", Convert.ToString(idMoneda), false));

            listPar.Add(new ReportParameter("nEdadCliente", Convert.ToString(nEdadCliente), false));
            listPar.Add(new ReportParameter("cTipoCliente", cTipoCliente, false));

            //listPar.Add(new ReportParameter("nEdadCliente", Convert.ToString(nEdadCliente), false));

            // datasets
            //============= bd RCC ==========================
            DataTable dtCalfInterv = cninterviniente.CNdtListClienCalifSBS(cDocumentoID, idTipoDocumento, nlastMonths);
            dtslist.Add(new ReportDataSource("dtCalfInterv", dtCalfInterv));
            if (dtCalfInterv.Rows.Count > 0)
            {
                cCodsbs = Convert.ToString(dtCalfInterv.Rows[0]["codsbs"]);
            }
            listPar.Add(new ReportParameter("codsbs", cCodsbs, false));
            //dtslist.Add(new ReportDataSource("dtListSaldosInterb", cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, nlastMonths, idMoneda)));
            //dtslist.Add(new ReportDataSource("dtListSaldosResumDir", cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, nlastMonths, 0, 1, 1)));
            //dtslist.Add(new ReportDataSource("dtListSaldosResumInDir", cninterviniente.CNdtLisSaldosRCDSBS(cCodsbs, nlastMonths, 0, 1, 2)));

            dtslist.Add(new ReportDataSource("LisCarFiaCli", cninterviniente.CNLisCarFiaCli(idCli)));
            dtslist.Add(new ReportDataSource("LisCreCliFiSol", cninterviniente.CNLisCreCliFiSol(idCli)));
            dtslist.Add(new ReportDataSource("BaseNegativa", cninterviniente.CNBaseNegativa(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("LibBaseNegativa", cninterviniente.CNLibBaseNegativa(cDocumentoID, idTipoDocumento)));

            dtslist.Add(new ReportDataSource("dtsPEP", cninterviniente.CNdtLisDatPEP(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCrexCli", cninterviniente.CNdtLisCrexCliInt(cDocumentoID, idTipoDocumento)));

            dtslist.Add(new ReportDataSource("dtsLisGarxCli", cninterviniente.CNdtLisGarxCli(cDocumentoID, idTipoDocumento)));

            dtslist.Add(new ReportDataSource("dtsLisGarOtrUtixCli", cninterviniente.CNdtLisGarOtrUtixCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCreGarxCli", cninterviniente.CNdtLisCreGarxCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCtaAhoxCli", cninterviniente.CNdtLisCtaAhoxCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliCreMismaDire", cninterviniente.CNdtLisCliCreMismaDire(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisVinculadosaCli", cninterviniente.CNdtLisVinculadosaCli(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono", cninterviniente.CNdtLisCliRelaGrupoEcono(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsLisCliMismaGar", cninterviniente.CNdtLisCliMismaGar(cDocumentoID, idTipoDocumento)));
            dtslist.Add(new ReportDataSource("dtsRastreo", cninterviniente.CNdtLstRastreoInt(cDocumentoID, idTipoDocumento)));

            //===============================================

            new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
        }

        #endregion
    }
}
