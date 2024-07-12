using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conRcc : UserControl
    {
        public decimal nTipoCambio { get; set; }
        public decimal n2TipoCambio { get; set; }
        public decimal n3TipoCambio { get; set; }
        public int idTipoEval = 0;
        public decimal nCuotaAprox = 0M;
        public decimal nCuotaMaxDisp = 0M;

        Boolean lExpuestoRcc;

        decimal pPrimerEsce=0M;
        decimal pSegundoEsce = 0M;
        decimal pTerceroEsce = 0M;

        decimal nTopeNoExpuestoRCC = 0M;
 
        DataTable dtPlantilla;
        public DataTable dtIngresos {get; set;} 
        public DataTable dtEgresos  {get; set;}
        public decimal nMontoEgresosIndirectos { get; set; }   //monto En soles
        public decimal nMontoCuotasOtrosPrestamos { get; set; } //monto En soles
        public decimal nMontoCuota { get; set; } 
        public int idMonedaCredito { get; set; }

        public event DataGridViewCellEventHandler eCambioValorCelda;
        public conRcc()
        {
            InitializeComponent();
            //formatoIngresosEgresos();
            if ( clsVarApl.dicVarGen.Count > 0)
            {
                pPrimerEsce = clsVarApl.dicVarGen["nPorcRCCPrimerEscenario"];
                pSegundoEsce = clsVarApl.dicVarGen["nPorcRCCSegundoEscenario"];
                pTerceroEsce = clsVarApl.dicVarGen["nPorcRCCTerceroEscenario"];
                nTopeNoExpuestoRCC = clsVarApl.dicVarGen["nPorTopeNoExpuestoRcc"];
            }

            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowHeadersVisible = false;
        }

        
        #region Métodos

        public void limpiar()
        {
            nTipoCambio = 0m;
            n2TipoCambio = 0m;
            n3TipoCambio = 0m;
            lExpuestoRcc = false;
            nMontoEgresosIndirectos = 0m;
            nMontoCuotasOtrosPrestamos = 0m;
            nMontoCuota = 0m;
            idMonedaCredito = 0;
            if (dtPlantilla != null)
                dtPlantilla.Clear();

            if (dtIngresos != null)
                dtIngresos.Clear();

            if (dtEgresos != null)
                dtEgresos.Clear();
        }

        /// <summary>
        /// Cargar parametros para el control de RCC (Riesgo Cambiario crediticio)
        /// </summary>
        /// <param name="dtIng">Ingresos en su moneda original</param>
        /// <param name="dtEgr">Egresos en su moneda original</param>
        /// <param name="nTipCam">Tipo de cambio usado para calcular los demas escenarios</param>
        /// <param name="nMonCuoOtrosCred">Monto de cuota de otros créditos expresado en soles</param>
        /// <param name="nMonCuo">Monto de cuoda de la propuesta del crédito</param>
        /// <param name="idMoneda">Moneda del la propuesta del crédito</param>
        public void cargarParametros(DataTable dtIng, DataTable dtEgr, Decimal nTipCam, Decimal nMonCuoOtrosCred, Decimal nMonCuo, int idMoneda)
        {
            dtIngresos = dtIng;
            dtEgresos = dtEgr;
            nTipoCambio = nTipCam;
            nMontoCuotasOtrosPrestamos = nMonCuoOtrosCred;
            nMontoCuota = nMonCuo;
            idMonedaCredito = idMoneda;

            nTipoCambio = nTipoCambio + (nTipoCambio * pPrimerEsce);
            n2TipoCambio = nTipoCambio + (nTipoCambio * pSegundoEsce);
            n3TipoCambio = nTipoCambio + (nTipoCambio * pTerceroEsce);

            cargarPlantilla();
            procesar();

        }

        public void cargarTipoCambio()
        {
            
            nTipoCambio = nTipoCambio + (nTipoCambio * pPrimerEsce);
            n2TipoCambio = nTipoCambio + (nTipoCambio * pSegundoEsce);
            n3TipoCambio = nTipoCambio + (nTipoCambio * pTerceroEsce);

            cargarPlantilla();
        }

        private void cargarPlantilla() 
        {
            if (dtPlantilla != null)
            {
                dtPlantilla.Clear();
            }
            else
            {
                dtPlantilla = new DataTable("Rcc");
                dtPlantilla.Columns.Add("idOpe", typeof(int));
                dtPlantilla.Columns.Add("idEvalCre", typeof(int));
                dtPlantilla.Columns.Add("idMoneda", typeof(int));
                dtPlantilla.Columns.Add("cDescripcion", typeof(string));
                dtPlantilla.Columns.Add("nPrimer", typeof(string));
                dtPlantilla.Columns.Add("nSegundo", typeof(string));
                dtPlantilla.Columns.Add("nTercero", typeof(string));
                dtPlantilla.Columns.Add("nTipDato", typeof(int));
                dtPlantilla.Columns.Add("nOrden", typeof(int));
                dtPlantilla.Columns.Add("nMontoMonOrig", typeof(decimal));
            }
           

            DataRow dr = dtPlantilla.NewRow();
            dr["idOpe"] = 1; // ingresos
            dr["idMoneda"] = 1; //Soles
            dr["cDescripcion"] = "Ingresos S/."; //Soles
            dr["nPrimer"] = "0";
            dr["nSegundo"] = "0";
            dr["nTercero"] = "0";
            dr["nTipDato"] = 1;
            dr["nOrden"] = 1;
            dr["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr);

            DataRow dr2 = dtPlantilla.NewRow();
            dr2["idOpe"] = 1; // ingresos
            dr2["idMoneda"] = 2; //dolares
            dr2["cDescripcion"] = "Ingresos $/.";
            dr2["nPrimer"] = "0";
            dr2["nSegundo"] = "0";
            dr2["nTercero"] = "0";
            dr2["nTipDato"] = 1;
            dr2["nOrden"] = 2;
            dr2["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr2);

            DataRow dr3 = dtPlantilla.NewRow();
            dr3["idOpe"] = 2; // egresos
            dr3["idMoneda"] = 1; //Soles
            dr3["cDescripcion"] = "Egresos S/."; 
            dr3["nPrimer"] = "0";
            dr3["nSegundo"] = "0";
            dr3["nTercero"] = "0";
            dr3["nTipDato"] = 1;
            dr3["nOrden"] = 3;
            dr3["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr3);

            DataRow dr4 = dtPlantilla.NewRow();
            dr4["idOpe"] = 2; // egresos
            dr4["idMoneda"] = 2; //DOLARES
            dr4["cDescripcion"] = "Egresos $/."; 
            dr4["nPrimer"] = "0";
            dr4["nSegundo"] = "0";
            dr4["nTercero"] = "0";
            dr4["nTipDato"] = 1;
            dr4["nOrden"] = 4;
            dr4["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr4);

            DataRow dr5 = dtPlantilla.NewRow();
            dr5["idOpe"] = 3; 
            dr5["idMoneda"] = 0; 
            dr5["cDescripcion"] = "Diferencia"; 
            dr5["nPrimer"] = "0";
            dr5["nSegundo"] = "0";
            dr5["nTercero"] = "0";
            dr5["nTipDato"] = 1;
            dr5["nOrden"] = 5;
            dr5["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr5);

            DataRow dr6 = dtPlantilla.NewRow();
            dr6["idOpe"] = 4; 
            dr6["idMoneda"] = 0; 
            dr6["cDescripcion"] = "% Capacidad de Pago";
            dr6["nPrimer"] = "0";
            dr6["nSegundo"] = "0";
            dr6["nTercero"] = "0";
            dr6["nTipDato"] = 2;
            dr6["nOrden"] = 6;
            dr6["nMontoMonOrig"] = 0;

            dtPlantilla.Rows.Add(dr6);

            // dtgRcc.DataSource = dtPlantilla;
            dataGridView1.DataSource = dtPlantilla;
            formatoGrid();
        }

        
        public void procesar()
        {
            DataTable dtTemp = dtPlantilla.Copy();

            if (dtIngresos.Rows.Count == 0)
            {
                return;
            }

            if (dtEgresos.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow item in dtIngresos.Rows)
            {
                foreach (DataRow item2 in dtPlantilla.Rows)
                {
                    if (Convert.ToInt32(item2["idOpe"]) == 1 ) 
                    {
                        if(Convert.ToInt32(item2["idMoneda"]) == Convert.ToInt32(item["idMoneda"]))
                        {
                            item2["nPrimer"] = (Convert.ToDecimal(item2["nPrimer"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : nTipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nSegundo"] = (Convert.ToDecimal(item2["nSegundo"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n2TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nTercero"] = (Convert.ToDecimal(item2["nTercero"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n3TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nMontoMonOrig"] = (Convert.ToDecimal(item2["nMontoMonOrig"]) + Convert.ToDecimal(item["nMonto"])).ToString("N0", new CultureInfo("es-PE"));
                        }                        
                    }

                    if (Convert.ToInt32(item2["idOpe"]) == 3) 
                    {
                        item2["nPrimer"] = (Convert.ToDecimal(item2["nPrimer"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : nTipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                        item2["nSegundo"] = (Convert.ToDecimal(item2["nSegundo"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n2TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                        item2["nTercero"] = (Convert.ToDecimal(item2["nTercero"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n3TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                    } 

                }
            }

            foreach (DataRow item in dtEgresos.Rows)
            {
                foreach (DataRow item2 in dtPlantilla.Rows)
                {
                    if (Convert.ToInt32(item2["idOpe"]) == 2)
                    {
                        if (Convert.ToInt32(item2["idMoneda"]) == Convert.ToInt32(item["idMoneda"]))
                        {
                            item2["nPrimer"] = (Convert.ToDecimal(item2["nPrimer"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : nTipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nSegundo"] = (Convert.ToDecimal(item2["nSegundo"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n2TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nTercero"] = (Convert.ToDecimal(item2["nTercero"]) + Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n3TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                            item2["nMontoMonOrig"] = (Convert.ToDecimal(item2["nMontoMonOrig"]) + Convert.ToDecimal(item["nMonto"])).ToString("N0", new CultureInfo("es-PE"));
                        }
                    }

                    if (Convert.ToInt32(item2["idOpe"]) == 3)
                    {
                        item2["nPrimer"] = (Convert.ToDecimal(item2["nPrimer"]) - Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : nTipoCambio)).ToString("N0", new CultureInfo("es-PE")); ;
                        item2["nSegundo"] = (Convert.ToDecimal(item2["nSegundo"]) - Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n2TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                        item2["nTercero"] = (Convert.ToDecimal(item2["nTercero"]) - Convert.ToDecimal(item["nMonto"]) * ((Convert.ToInt32(item["idMoneda"]) == 1) ? 1 : n3TipoCambio)).ToString("N0", new CultureInfo("es-PE"));
                    } 
                }
            }

            
            int idDiferencia = 4;
            dtPlantilla.Rows[idDiferencia]["nPrimer"] = (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia]["nPrimer"])).ToString("N0", new CultureInfo("es-PE"));
            dtPlantilla.Rows[idDiferencia]["nSegundo"] = (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia]["nSegundo"])).ToString("N0", new CultureInfo("es-PE"));
            dtPlantilla.Rows[idDiferencia]["nTercero"] = (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia]["nTercero"])).ToString("N0", new CultureInfo("es-PE"));
            
            idDiferencia = 5;

            
            if (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nPrimer"]) + nMontoCuotasOtrosPrestamos > 0)
            {
                if (idTipoEval == 1)
                {
                    dtPlantilla.Rows[idDiferencia]["nPrimer"] = (nCuotaMaxDisp == 0M) ? "0" : (idMonedaCredito == 1) ?
                                                                (nCuotaAprox/ nCuotaMaxDisp).ToString("P2")
                                                                : ((nCuotaAprox * nTipoCambio )/ nCuotaMaxDisp).ToString("P2");
                }
                else
                {
                    dtPlantilla.Rows[idDiferencia]["nPrimer"] = (idMonedaCredito == 1) ?
                                                                ((nMontoCuota + nMontoCuotasOtrosPrestamos)
                                                                / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nPrimer"]) + nMontoCuotasOtrosPrestamos)).ToString("P2")
                                                                : ((nMontoCuota * nTipoCambio + nMontoCuotasOtrosPrestamos)
                                                                / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nPrimer"]) + nMontoCuotasOtrosPrestamos)).ToString("P2");
                }
            }


            if ((Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nSegundo"]) + nMontoCuotasOtrosPrestamos) > 0)
            {
                if (idTipoEval == 1)
                {
                    dtPlantilla.Rows[idDiferencia]["nSegundo"] = (nCuotaMaxDisp == 0M) ? "0" : (idMonedaCredito == 1) ?
                                                                (nCuotaAprox/ nCuotaMaxDisp).ToString("P2")
                                                                : ((nCuotaAprox * n2TipoCambio)/ nCuotaMaxDisp).ToString("P2");
                }
                else
                {
                    dtPlantilla.Rows[idDiferencia]["nSegundo"] = (idMonedaCredito == 1) ?
                                                                    ((nMontoCuota + nMontoCuotasOtrosPrestamos)
                                                                    / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nSegundo"]) + nMontoCuotasOtrosPrestamos)).ToString("P2")
                                                                    : ((nMontoCuota * n2TipoCambio + nMontoCuotasOtrosPrestamos)
                                                                        / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nSegundo"]) + nMontoCuotasOtrosPrestamos)).ToString("P2");
                }
            }

            if ((Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nTercero"]) + nMontoCuotasOtrosPrestamos) > 0)
            {
                if (idTipoEval == 1)
                {
                    dtPlantilla.Rows[idDiferencia]["nTercero"] = (nCuotaMaxDisp == 0M) ? "0" : (idMonedaCredito == 1) ?
                                                                (nCuotaAprox/ nCuotaMaxDisp).ToString("P2")
                                                                : ((nCuotaAprox * n3TipoCambio)/ nCuotaMaxDisp).ToString("P2");
                }
                else
                {
                    dtPlantilla.Rows[idDiferencia]["nTercero"] = (idMonedaCredito == 1) ?
                                                                ((nMontoCuota + nMontoCuotasOtrosPrestamos)
                                                                    / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nTercero"]) + nMontoCuotasOtrosPrestamos)).ToString("P2")
                                                                : ((nMontoCuota * n3TipoCambio + nMontoCuotasOtrosPrestamos)
                                                                / (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia - 1]["nTercero"]) + nMontoCuotasOtrosPrestamos)).ToString("P2");
                }
            }

            if (Convert.ToDecimal(dtPlantilla.Rows[idDiferencia]["nTercero"].ToString().Split(new Char[] { '%' })[0]) > Convert.ToDecimal(nTopeNoExpuestoRCC*100))
            {
                toolStripTextBox1.Clear();
                toolStripTextBox1.Text = "EXPUESTO AL RCC";
                toolStripTextBox1.ForeColor = Color.Red;
                lExpuestoRcc = true;
            }
            else
	        {
                toolStripTextBox1.Clear();
                toolStripTextBox1.Text = "NO EXPUESTO AL RCC";
                toolStripTextBox1.ForeColor = Color.Navy;
                lExpuestoRcc = false;
	        }

            formatoGrid();
        }

        private void formatoIngresosEgresos()
        {
            dtIngresos = new DataTable();
            dtIngresos.Columns.Add("idMoneda", typeof(int));
            // dtPlantilla.Columns.Add("idTipoOpe", typeof(int));
            dtIngresos.Columns.Add("nMonto", typeof(decimal));

            dtEgresos = dtIngresos.Clone();
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }

            dataGridView1.Columns["cDescripcion"].Width = 128;
            dataGridView1.Columns["nPrimer"].Width = 60;
            dataGridView1.Columns["nSegundo"].Width = 60;
            dataGridView1.Columns["nTercero"].Width = 60;

            dataGridView1.Columns["cDescripcion"].Visible = true;
            dataGridView1.Columns["nPrimer"].Visible = true;
            dataGridView1.Columns["nSegundo"].Visible = true;
            dataGridView1.Columns["nTercero"].Visible = true;
            
            dataGridView1.Columns["nPrimer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["nSegundo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["nTercero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridView1.Columns["cDescripcion"].HeaderText = "Expresado en S/.";
            dataGridView1.Columns["nPrimer"].HeaderText = pPrimerEsce.ToString("P0") + " (" + nTipoCambio.ToString("N4", new CultureInfo("es-PE")) + ")";
            dataGridView1.Columns["nSegundo"].HeaderText = pSegundoEsce.ToString("P0") + " (" + n2TipoCambio.ToString("N4", new CultureInfo("es-PE")) + ")";
            dataGridView1.Columns["nTercero"].HeaderText = pTerceroEsce.ToString("P0") + " (" + n3TipoCambio.ToString("N4", new CultureInfo("es-PE")) + ")";
        }

        public DataTable obtenerRCC(int idEvalCre) 
        {
            DataTable dtReturn = dtPlantilla.Clone();

            foreach (DataRow item in dtPlantilla.Rows)
            {
                if(Convert.ToInt32(item["idOpe"]) == 4)
                {
                    item["nPrimer"] = item["nPrimer"].ToString().Split(new Char[] { '%' })[0];
                    item["nSegundo"] = item["nSegundo"].ToString().Split(new Char[] { '%' })[0];
                    item["nTercero"] = item["nTercero"].ToString().Split(new Char[] { '%' })[0];
                }
                item["idEvalCre"] = idEvalCre;
                dtReturn.ImportRow(item);
            }

            return dtReturn;
        }

        public Decimal obtenerCapacidadPago()
        {
            Decimal nCapaPago = 0;
            foreach (DataRow item in dtPlantilla.Rows)
            {
                if (Convert.ToInt32(item["idOpe"]) == 4)
                {
                    nCapaPago = Convert.ToDecimal(item["nPrimer"].ToString().Split(new Char[] { '%' })[0]);
                    
                }
            }

            return nCapaPago/100;
        }

        public Boolean expuestoRcc()
        {
            return lExpuestoRcc;
        }

        #endregion

        #region Eventos
        
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtPlantilla.Rows.Count == 0)
                return;

            if (eCambioValorCelda != null)
            {
                eCambioValorCelda(sender, e);
            }
        }

        #endregion

        




    }
}
