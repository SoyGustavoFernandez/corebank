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
using CRE.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmTasas : frmBase
    {
        private clsCreditoProp objCreditoProp;

        public frmTasas()
        {
            InitializeComponent();
        }

        public frmTasas(clsCreditoProp obj)
        {
            InitializeComponent();
            this.objCreditoProp = obj;
        }

        #region Métodos Públicos

        public void ActualizarTasaCredito()
        {
            this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();

            DataTable dtTasa = (new clsCNTasaCredito()).ListaTasaEvalGrupoSol(
                                    this.objCreditoProp.nPlazoTotalDias,
                                    this.objCreditoProp.idSubProducto,
                                    this.objCreditoProp.nMontoMinimo,
                                    this.objCreditoProp.nMontoMaximo,
                                    this.objCreditoProp.idMoneda,
                                    this.objCreditoProp.idAgencia,
                                    this.objCreditoProp.idSolicitud,
                                    this.objCreditoProp.idClasificacionInterna);

            if (dtTasa.Rows.Count > 0)
            {

                cboTipoTasaCredito.DataSource = null;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                cboTipoTasaCredito.DataSource = dtTasa;

                cboTipoTasaCredito.SelectedIndex = -1;

                if (this.objCreditoProp != null && this.objCreditoProp.idTasa > 0)
                {
                    DataRow row = dtTasa.AsEnumerable().FirstOrDefault(x => x.Field<int>("idTasa") == this.objCreditoProp.idTasa);
                    if (row == null)
                    {
                        // --seteamos la opción default
                        cboTipoTasaCredito.SelectedIndex = 0;
                    }
                    else
                    {
                        // --Recuperamos la opcion anterior
                        cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
                    }
                }

                CalcularCuotaAprox();
            }
            else
            {
                this.objCreditoProp.idTasa = 0;
                txtTasCompensatoriaMin.Text = String.Empty;
                txtTasCompensatoriaMax.Text = String.Empty;
                txtTEA.Text = "0";
                txtTasaMora.Text = "0";

                if (cboTipoTasaCredito.DataSource != null)
                    ((DataTable)cboTipoTasaCredito.DataSource).Clear();

                this.objCreditoProp.nCuotaAprox = 0;
                this.objCreditoProp.nCuotaGraciaAprox = 0;
                this.objCreditoProp.dtCalendarioPagos = new DataTable();

                this.txtCuotaAprox.Text = this.objCreditoProp.nCuotaAprox.ToString("n2");
                this.txtCuotaGraciaAprox.Text = this.objCreditoProp.nCuotaGraciaAprox.ToString("n2");
            }

            
        }


        /// <summary>
        /// Retorna las cuotas de gracia del crédito
        /// </summary>
        /// <returns></returns>
        public int CuotasGracia()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nCuotasGracia.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nCuotasGracia);
        }

        /// <summary>
        /// Retorna el numero de cuotas del crédito
        /// </summary>
        /// <returns></returns>
        public int NroCuotas()
        {
            return this.objCreditoProp.nCuotas;
        }

        /// <summary>
        /// Retorna los días de gracia
        /// </summary>
        /// <returns></returns>
        public int DiasGracia()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nDiasGracia.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nDiasGracia);
        }

        /// <summary>
        /// Retorna el tipo de Periodo: Fecha Fija o Periodo Fijo
        /// </summary>
        /// <returns></returns>
        public int TipoPeriodo()
        {
            return Convert.ToInt32(this.objCreditoProp.idTipoPeriodo);
        }

        /// <summary>
        /// Retorna el PlazoCuota del crédito en número de días
        /// </summary>
        /// <returns></returns>
        public int PlazoCuota()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nPlazoCuota.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nPlazoCuota);
        }

        #endregion

        #region Métodos Privados

        private int ObtenerPlazoTotalDias()
        {
            int nPlazoTotalDias = ((new clsCNSolicitud()).ObtieneTotalDias(
                                            this.objCreditoProp.dFechaDesembolso,
                                            NroCuotas(),
                                            DiasGracia(),
                                            TipoPeriodo(),
                                            PlazoCuota()));

            return nPlazoTotalDias;
        }

        private void CalcularCuotaAprox()
        {
            DataTable dtCalendarioPagos = new DataTable();
            DataTable dtEmpty = new DataTable();
            decimal nCuotaConstante = 0;
            decimal nCuotaGraciaAprox = 0;

            dtCalendarioPagos = (new clsCNPlanPago()).CalculaPpgCuotasConstantes(
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    0,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.objCreditoProp.dFechaPrimeraCuota);

            if (CuotasGracia() > 0)
            {
                dtCalendarioPagos = (new clsCNPlanPago()).CalcularCuotasGracia(
                                    dtCalendarioPagos,
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(this.objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.objCreditoProp.dFechaPrimeraCuota,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nCuotasGracia);

                if (dtCalendarioPagos.Rows.Count > 0)
                {
                    var listCuotaConst = (from p in dtCalendarioPagos.AsEnumerable()
                                          where p.Field<decimal>("capital") > 0
                                          select new
                                          {
                                              nCapital = p.Field<decimal>("capital"),
                                              nInteres = p.Field<decimal>("interes"),
                                              nCuota = p.Field<decimal>("imp_cuota")
                                          }).ToList();

                    var listaCuotaPGracia = (from p in dtCalendarioPagos.AsEnumerable()
                                             where p.Field<decimal>("capital") == 0
                                             select new
                                             {
                                                 nCapital = p.Field<decimal>("capital"),
                                                 nInteres = p.Field<decimal>("interes"),
                                                 nCuota = p.Field<decimal>("imp_cuota")
                                             }).ToList();

                    nCuotaConstante = (listCuotaConst.Count > 0) ? listCuotaConst[0].nCuota : 0;
                    nCuotaGraciaAprox = (listaCuotaPGracia.Count > 0) ? listaCuotaPGracia[0].nCuota : 0;
                }
            }
            else
            {
                nCuotaConstante = (dtCalendarioPagos.Rows.Count > 0) ? Convert.ToDecimal(dtCalendarioPagos.Rows[0]["imp_cuota"]) : 0;
                nCuotaGraciaAprox = 0;
            }

            this.txtCuotaAprox.Text = nCuotaConstante.ToString("n2");
            this.txtCuotaGraciaAprox.Text = nCuotaGraciaAprox.ToString("n2");

            this.objCreditoProp.nCuotaAprox = nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = dtCalendarioPagos;
        }

        
        #endregion
    }
}
