using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RCP.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmComisionRecuperacion : frmBase
    {
        #region Variables Globales
        private clsCNRecuperacionComision objCNRecuperacionComision;
        private clsRecuperacionComisionDetalle objRecuperacionComision;

        private List<clsRecuperacionComision> lstRecuperacionComision;
        private List<clsRecuperacionComisionDetalle> lstRecuperacionComisionDetalle;
        private BindingSource bsRecuperacionComision;

        private List<clsGrabadoRecupComision> lstGrabadoRecupComision;
        private BindingSource bsGrabadoRecupComision;

        private int idRecuperacionComisionTipo;
        private DateTime dFecha;
        private decimal nMontoComisionTotal;
        private int idEstado;
        #endregion
        public frmComisionRecuperacion()
        {
            InitializeComponent();

            this.inicializarDatos();
        }

        #region Metodos
        private void inicializarDatos()
        {
            this.objCNRecuperacionComision = new clsCNRecuperacionComision();

            this.objRecuperacionComision = new clsRecuperacionComisionDetalle();
            this.lstRecuperacionComision = new List<clsRecuperacionComision>();
            this.lstRecuperacionComisionDetalle = new List<clsRecuperacionComisionDetalle>();
            this.bsRecuperacionComision = new BindingSource();
            this.lstGrabadoRecupComision = new List<clsGrabadoRecupComision>();
            this.bsGrabadoRecupComision = new BindingSource();

            this.bsRecuperacionComision.DataSource = this.lstRecuperacionComisionDetalle;
            this.dtgRecuperacionComision.DataSource = this.bsRecuperacionComision;

            this.bsGrabadoRecupComision.DataSource = this.lstGrabadoRecupComision;
            this.dtgGrabRecupComision.DataSource = this.bsGrabadoRecupComision;

            this.idRecuperacionComisionTipo = 0;
            this.dFecha = clsVarGlobal.dFecSystem;
            this.nMontoComisionTotal = decimal.Zero;
            this.idEstado = 0;

            this.formatearRecuperacionComision();
            this.formatearGrabRecupComision();

            this.habilitarControles(clsAcciones.NUEVO);
        }
        private void formatearRecuperacionComision()
        {
            this.dtgRecuperacionComision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecuperacionComision.ReadOnly = true;
            if (this.idRecuperacionComisionTipo == (int)RecuperacionComisionTipo.JefeRecuperacion)
            {
                this.dtgRecuperacionComision.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.dtgRecuperacionComision.ReadOnly = false;
            }
            foreach (DataGridViewColumn dgvColumn in dtgRecuperacionComision.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvColumn.ReadOnly = true;
            }

            if (this.lstRecuperacionComisionDetalle.Count > 0)
            {
                if(this.idRecuperacionComisionTipo == (int)RecuperacionComisionTipo.SupervisorRecuperacion)
                dtgRecuperacionComision.Columns["cZona"].Visible = true;
                else if (this.idRecuperacionComisionTipo == (int)RecuperacionComisionTipo.GestorRecuperacion)
                dtgRecuperacionComision.Columns["cEstablecimiento"].Visible = true;
            }
            if (this.idRecuperacionComisionTipo == (int)RecuperacionComisionTipo.JefeRecuperacion)
            {
                dtgRecuperacionComision.Columns["nMontoComision"].ReadOnly = false;
            }
            dtgRecuperacionComision.Columns["cNombre"].Visible = true;
            dtgRecuperacionComision.Columns["nMoraContIniAct"].Visible = true;
            dtgRecuperacionComision.Columns["nMoraContActual"].Visible = true;
            dtgRecuperacionComision.Columns["nMoraContDiferencia"].Visible = true;
            dtgRecuperacionComision.Columns["nSaldoCARIni"].Visible = true;
            dtgRecuperacionComision.Columns["nSaldoCARAct"].Visible = true;
            dtgRecuperacionComision.Columns["nSaldoCARDiferencia"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentMoraContIniAct"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentMoraContActual"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentMoraContDiferencia"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentSaldoCARIni"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentSaldoCARAct"].Visible = true;
            dtgRecuperacionComision.Columns["nPcentSaldoCARDiferencia"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoMeta"].Visible = true;
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nLimiteCondonacion"].Visible = true;
            dtgRecuperacionComision.Columns["nCondonaciones"].Visible = true;
            dtgRecuperacionComision.Columns["nFactor"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoComisionBase"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoAfectacion"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoBonificacion"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoComision"].Visible = true;

            dtgRecuperacionComision.Columns["cZona"].HeaderText = "Zona";
            dtgRecuperacionComision.Columns["cEstablecimiento"].HeaderText = "Establecimiento";
            dtgRecuperacionComision.Columns["cNombre"].HeaderText = "Gestor de recuperaciones";
            dtgRecuperacionComision.Columns["nMoraContIniAct"].HeaderText = "Mora Inicial RV";
            dtgRecuperacionComision.Columns["nMoraContActual"].HeaderText = "Mora Final RV";
            dtgRecuperacionComision.Columns["nMoraContDiferencia"].HeaderText = "Diferencia Mora";
            dtgRecuperacionComision.Columns["nSaldoCARIni"].HeaderText = "C.A.R Inicial RV";
            dtgRecuperacionComision.Columns["nSaldoCARAct"].HeaderText = "C.A.R Final RV";
            dtgRecuperacionComision.Columns["nSaldoCARDiferencia"].HeaderText = "Diferencia C.A.R";
            dtgRecuperacionComision.Columns["nPcentMoraContIniAct"].HeaderText = "%Mora Incial";
            dtgRecuperacionComision.Columns["nPcentMoraContActual"].HeaderText = "%Mora Final";
            dtgRecuperacionComision.Columns["nPcentMoraContDiferencia"].HeaderText = "%Diferencia Mora";
            dtgRecuperacionComision.Columns["nPcentSaldoCARIni"].HeaderText = "%C.A.R Inicial";
            dtgRecuperacionComision.Columns["nPcentSaldoCARAct"].HeaderText = "%C.A.R Final";
            dtgRecuperacionComision.Columns["nPcentSaldoCARDiferencia"].HeaderText = "%Diferencia C.A.R";
            dtgRecuperacionComision.Columns["nMontoLogrado"].HeaderText = "Monto Logrado";
            dtgRecuperacionComision.Columns["nMontoMeta"].HeaderText = "Meta Reduc.";
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].HeaderText = "%Meta Logrado";
            dtgRecuperacionComision.Columns["nLimiteCondonacion"].HeaderText = "Lim.Cond";
            dtgRecuperacionComision.Columns["nCondonaciones"].HeaderText = "Num.Cond";
            dtgRecuperacionComision.Columns["nFactor"].HeaderText = "Factor";
            dtgRecuperacionComision.Columns["nMontoComisionBase"].HeaderText = "Comisión Base";
            dtgRecuperacionComision.Columns["nMontoAfectacion"].HeaderText = "Afectación";
            dtgRecuperacionComision.Columns["nMontoBonificacion"].HeaderText = "Bonificación";
            dtgRecuperacionComision.Columns["nMontoComision"].HeaderText = "Comision Final";

            int i = 0;
            dtgRecuperacionComision.Columns["cZona"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["cEstablecimiento"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["cNombre"].DisplayIndex = i++;

            dtgRecuperacionComision.Columns["nPcentMoraContIniAct"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nPcentMoraContActual"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nPcentMoraContDiferencia"].DisplayIndex = i++;

            dtgRecuperacionComision.Columns["nMoraContIniAct"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMoraContActual"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMoraContDiferencia"].DisplayIndex = i++;

            dtgRecuperacionComision.Columns["nSaldoCARIni"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nSaldoCARAct"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nSaldoCARDiferencia"].DisplayIndex = i++;
            
            dtgRecuperacionComision.Columns["nPcentSaldoCARIni"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nPcentSaldoCARAct"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nPcentSaldoCARDiferencia"].DisplayIndex = i++;

            dtgRecuperacionComision.Columns["nMontoLogrado"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMontoMeta"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nLimiteCondonacion"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nCondonaciones"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nFactor"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMontoComisionBase"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMontoAfectacion"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMontoBonificacion"].DisplayIndex = i++;
            dtgRecuperacionComision.Columns["nMontoComision"].DisplayIndex = i++;

            dtgRecuperacionComision.Columns["nMoraContIniAct"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMoraContActual"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMoraContDiferencia"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nSaldoCARIni"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nSaldoCARAct"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nSaldoCARDiferencia"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nPcentMoraContIniAct"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nPcentMoraContActual"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nPcentMoraContDiferencia"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nPcentSaldoCARIni"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nPcentSaldoCARAct"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nPcentSaldoCARDiferencia"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nFactor"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nMontoComisionBase"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nMontoAfectacion"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nMontoBonificacion"].DefaultCellStyle.Format = "###,###,##0.00";
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Format = "###,###,##0.00";

            dtgRecuperacionComision.Columns["nMoraContIniAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMoraContActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMoraContDiferencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nSaldoCARIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nSaldoCARAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nSaldoCARDiferencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentMoraContIniAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentMoraContActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentMoraContDiferencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentSaldoCARIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentSaldoCARAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcentSaldoCARDiferencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nFactor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoComisionBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoAfectacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoBonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 

        }
        private void formatearRecuperacionComisionBasico()
        {
            this.dtgRecuperacionComision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecuperacionComision.ReadOnly = true;
            foreach (DataGridViewColumn dgvColumn in dtgRecuperacionComision.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dtgRecuperacionComision.Columns["cNombre"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoMeta"].Visible = true;
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoComision"].Visible = true;

            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Format = "###,###,##0.00";

            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void formatearRecuperacionComisionEditable()
        {
            this.dtgRecuperacionComision.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dtgRecuperacionComision.ReadOnly = false;
            foreach (DataGridViewColumn dgvColumn in dtgRecuperacionComision.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dtgRecuperacionComision.Columns["cNombre"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoMeta"].Visible = true;
            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].Visible = true;
            dtgRecuperacionComision.Columns["nMontoComision"].Visible = true;

            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].DefaultCellStyle.Format = "0.00##";
            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Format = "###,###,##0";
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Format = "###,###,##0.00";


            dtgRecuperacionComision.Columns["nPcgMetaLogrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoLogrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoMeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRecuperacionComision.Columns["nMontoComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void formatearGrabRecupComision()
        {
            foreach (DataGridViewColumn dtgColumn in this.dtgGrabRecupComision.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            dtgGrabRecupComision.Columns["cRecuperacionComisionTipo"].Visible = true;
            dtgGrabRecupComision.Columns["lRegistrado"].Visible = true;

            dtgGrabRecupComision.Columns["cRecuperacionComisionTipo"].HeaderText = "Tipo Comisión";
            dtgGrabRecupComision.Columns["lRegistrado"].HeaderText = "Reg?";

            dtgGrabRecupComision.Columns["cRecuperacionComisionTipo"].Width = 190;
            dtgGrabRecupComision.Columns["lRegistrado"].Width = 32;
        }

        private void formatearSegunTipo(RecuperacionComisionTipo idRecuperacionComisionTipo)
        {
            switch (idRecuperacionComisionTipo)
            {
                case RecuperacionComisionTipo.CarteraCastigada:
                    this.formatearRecuperacionComisionBasico();
                    break;
                case RecuperacionComisionTipo.SupervisorJudicial:
                    this.formatearRecuperacionComisionBasico();
                    break;
                case RecuperacionComisionTipo.CallCenter:
                    this.formatearRecuperacionComisionEditable();
                    break;
                default:
                    this.formatearRecuperacionComision();
                    break;
            }
        }
        private void listarRecuperacionComision()
        {
            this.dFecha = this.dtpFecha.Value;

            this.lstRecuperacionComisionDetalle.Clear();
            this.lstRecuperacionComisionDetalle.AddRange(this.objCNRecuperacionComision.listarRecuperacionComision(this.idRecuperacionComisionTipo, this.dFecha));            
            this.bsRecuperacionComision.ResetBindings(false);
            this.dtgRecuperacionComision.Refresh();
            if (this.lstRecuperacionComisionDetalle.Count == 0)
            {
                MessageBox.Show("No existen suficientes datos para generar la comisión.\n* Revise que las METAS DE RECUPERACION DE SALDOS y LIMITES DE CONDONACION ESTEN CARGADAS","NO EXISTEN DATOS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (this.lstRecuperacionComisionDetalle.Count > 0)
            {
                this.revisarGrabadoRecuperacionComision();
                if (this.idEstado != (int)EstadoEvalCred.APROBADO && this.idEstado != (int)EstadoEvalCred.ENVIADO && this.idEstado != (int)EstadoEvalCred.DENEGADO)
                {
                    this.habilitarControles(clsAcciones.BUSCAR);
                }
                this.dtpFechaCalculo.Value = this.lstRecuperacionComisionDetalle[0].dFechaActualizacion;
                this.formatearSegunTipo((RecuperacionComisionTipo)this.idRecuperacionComisionTipo);
            }
        }
        private void grabarRecuperacionComision()
        {
            this.generarRecuperacionComision();
            DataTable dtResultado = this.objCNRecuperacionComision.grabarRecuperacionComision(this.idRecuperacionComisionTipo, this.dFecha, this.lstRecuperacionComision);
            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                this.habilitarControles(clsAcciones.GRABAR);
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.revisarGrabadoRecuperacionComision();
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Error de Grabado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void revisarGrabadoRecuperacionComision()
        {
            this.lstGrabadoRecupComision.Clear();
            this.lstGrabadoRecupComision.AddRange(this.objCNRecuperacionComision.revisarGrabadoRecuperacionComision(this.dFecha));
            this.bsGrabadoRecupComision.ResetBindings(false);
            this.dtgGrabRecupComision.Refresh();

            if (this.lstGrabadoRecupComision.Count > 0)
            {
                this.nMontoComisionTotal = this.lstGrabadoRecupComision.Sum(x => x.nMontoComision);
                this.txtMontoComisionTotal.Text = this.nMontoComisionTotal.ToString();
                this.lblEstado.Text = this.lstGrabadoRecupComision[0].cEstado;
                this.idEstado = this.lstGrabadoRecupComision[0].idEstado;

                this.habilitarControlesEstado((EstadoEvalCred)this.idEstado);
            }
        }

        private void grabarAproSolicitudRecComision()
        {
            DataTable dtResultado = this.objCNRecuperacionComision.grabarAproSolicitudRecComision(this.dFecha, this.nMontoComisionTotal);
            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                this.habilitarControles(clsAcciones.ENVIAR);
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.revisarGrabadoRecuperacionComision();
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Error de Grabado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarRecuperacionComision()
        {
            this.lstRecuperacionComision.Clear();

            foreach (clsRecuperacionComisionDetalle objReComisionDet in this.lstRecuperacionComisionDetalle)
            {
                this.lstRecuperacionComision.Add(
                    new clsRecuperacionComision {
                        idRecuperacionComisionTipo = this.idRecuperacionComisionTipo,
                        idUsuario = objReComisionDet.idUsuario,
                        idZona = objReComisionDet.idZona,
                        idEstablecimiento = objReComisionDet.idEstablecimiento,
                        nMontoComisionBase = objReComisionDet.nMontoComisionBase,
                        nMontoAfectacion = objReComisionDet.nMontoAfectacion,
                        nMontoBonificacion = objReComisionDet.nMontoBonificacion,
                        nMontoComision = objReComisionDet.nMontoComision,
                        dFecha = this.dFecha
                    }
               );
            }
        }
        private void imprimirSIGReporte()
        {
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cNombreDataSetRpt = "dsRpt";
            DataTable dtRpt;
            dtRpt = (new clsRPTCNCredito()).CNRpt001Hist(this.dtpFecha.Value, false, 0);


            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource(cNombreDataSetRpt, dtRpt));
                paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("dFechaSel", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));


                string reportPath = "rptSIGSaldoMoraCliente.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).Show();
            }
            else
            {
                MessageBox.Show("No hay datos para esta propuesta", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void habilitarControlesEstado(EstadoEvalCred eEstado)
        {
            switch(eEstado)
            {
                case EstadoEvalCred.ENVIADO:
                    this.habilitarControles(clsAcciones.ENVIAR);                    
                    break;
                case EstadoEvalCred.APROBADO:
                    this.habilitarControles(clsAcciones.RESOLVER);
                    break;
                case EstadoEvalCred.DENEGADO:
                    this.habilitarControles(clsAcciones.DENEGAR);
                    break;
                default :
                    this.btnEnviar.Enabled = (this.lstGrabadoRecupComision.Count >= 6);
                    break;
            }
            
        }
        private void habilitarControles(int nAccion)
        {
            switch (nAccion)
            {
                case clsAcciones.NUEVO:
                    this.dtpFecha.Enabled = true;
                    this.cboRecuperacionComisionTipo.Enabled = true;
                    this.btnReporteSIG.Enabled = false;
                    this.btnContinuar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEnviar.Enabled = false;

                    this.lstRecuperacionComisionDetalle.Clear();
                    this.bsRecuperacionComision.ResetBindings(false);
                    this.dtgRecuperacionComision.Refresh();
                    break;
                case clsAcciones.GRABAR:
                    this.btnCancelar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEnviar.Enabled = true;
                    this.btnReporteSIG.Enabled = false;
                    this.btnContinuar.Enabled = true;
                    break;
                case clsAcciones.CANCELAR:
                    this.dtpFecha.Enabled = true;
                    this.cboRecuperacionComisionTipo.Enabled = true;
                    this.btnContinuar.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnReporteSIG.Enabled = false;

                    this.lstRecuperacionComisionDetalle.Clear();
                    this.bsRecuperacionComision.ResetBindings(false);
                    this.dtgRecuperacionComision.Refresh();
                    
                    break;
                case clsAcciones.BUSCAR:
                    this.dtpFecha.Enabled = false;
                    this.cboRecuperacionComisionTipo.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnGrabar.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnReporteSIG.Enabled = true;
                    this.btnContinuar.Enabled = true;
                    break;
                case clsAcciones.ENVIAR:
                    this.btnCancelar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEnviar.Enabled = false;
                    this.btnReporteSIG.Enabled = false;
                    this.btnContinuar.Enabled = false;
                    break;
                case clsAcciones.RESOLVER:
                    this.dtpFecha.Enabled = false;
                    this.cboRecuperacionComisionTipo.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEnviar.Enabled = false;
                    this.btnReporteSIG.Enabled = false;
                    this.btnContinuar.Enabled = false;
                    break;
                case clsAcciones.DENEGAR:
                    this.dtpFecha.Enabled = false;
                    this.cboRecuperacionComisionTipo.Enabled = true;
                    this.btnGenerar.Enabled = true;
                    this.btnContinuar.Enabled = true;
                    this.btnGrabar.Enabled = true;
                    this.btnEnviar.Enabled = true;
                    this.btnReporteSIG.Enabled = true;
                    break;
            }
        }
        #endregion

        #region Eventos
        private void frmComisionRecuperacion_Shown(object sender, EventArgs e)
        {
            this.dtpFecha.Value = this.dFecha;
            this.cboRecuperacionComisionTipo.SelectedValue = (int)RecuperacionComisionTipo.GestorRecuperacion;
            this.idRecuperacionComisionTipo = Convert.ToInt32(this.cboRecuperacionComisionTipo.SelectedValue);
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(clsVarGlobal.dFecSystem, this.dtpFecha.Value) < 0)
            {
                MessageBox.Show("Seleccione una fecha menor o igual a la fecha del sistema: "+ clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"),
                    "FECHA INCORRECTA",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpFecha.Value = clsVarGlobal.dFecSystem;
                return;
            }
            this.dFecha = dtpFecha.Value;
            this.dFecha = new DateTime(this.dFecha.Year, this.dFecha.Month,
                                    DateTime.DaysInMonth(this.dFecha.Year, this.dFecha.Month));
        }
        private void dtgRecuperacionComision_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nIndice = e.ColumnIndex;
            int nIndiceFila = e.RowIndex;
            if (nIndice < 0 || nIndiceFila < 0) return;
            DataGridView dgv = (DataGridView)sender;
            string columnName = dgv.Columns[nIndice].Name;
            if (columnName.Equals("nMontoLogrado") || columnName.Equals("nMontoMeta"))
            {
                this.lstRecuperacionComisionDetalle[nIndiceFila].nPcgMetaLogrado =
                    (this.lstRecuperacionComisionDetalle[nIndiceFila].nMontoMeta == decimal.Zero) ? decimal.Zero :
                    Math.Round((this.lstRecuperacionComisionDetalle[nIndiceFila].nMontoLogrado / this.lstRecuperacionComisionDetalle[nIndiceFila].nMontoMeta) * 100.00M,2);

                this.bsRecuperacionComision.ResetBindings(false);
                this.dtgRecuperacionComision.Refresh();
            }
        }
        private void cboRecuperacionComisionTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboRecuperacionComisionTipo.SelectedIndex < 0) return;
            this.idRecuperacionComisionTipo = Convert.ToInt32(this.cboRecuperacionComisionTipo.SelectedValue);
            if (this.idRecuperacionComisionTipo == (int)RecuperacionComisionTipo.CallCenter)
            {
                this.dtgRecuperacionComision.CellValueChanged += new
                DataGridViewCellEventHandler(dtgRecuperacionComision_CellValueChanged);
            }
            else
            {
                this.dtgRecuperacionComision.CellValueChanged -= new
                DataGridViewCellEventHandler(dtgRecuperacionComision_CellValueChanged);
            }
            
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.grabarRecuperacionComision();
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!this.lstGrabadoRecupComision.Exists(x => x.lRegistrado == false))
            {
                this.grabarAproSolicitudRecComision();
            }
            else
            {
                MessageBox.Show("Algunos de los tipos de comisión aún no han sido grabados.","Grabado Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitarControles(clsAcciones.CANCELAR);
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.habilitarControles(clsAcciones.NUEVO);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.listarRecuperacionComision();
        }
        private void btnReporteSIG_Click(object sender, EventArgs e)
        {
            this.imprimirSIGReporte();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
