using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conEstadoResultados : UserControl
    {
        List<clsEstResEval> listEstResEval;
        
        int idProducto = 0;
        int idTipEvalCred = 12; // convenio

        public conEstadoResultados()
        {
            InitializeComponent();
        }

        public void AsignarDatos(List<clsEstResEval> _listEstResEval, int idProducto = 0, int idTipEvalCred = 12)
        {
            // --Estado de Resultados
            //this.listEstResEval = _listEstResEval;
            this.idTipEvalCred = idTipEvalCred;
            this.idProducto = idProducto;

            operandoEstadoResultados(ref _listEstResEval);

            this.bindingEERR.DataSource = _listEstResEval;
            this.dtgEstResEval.DataSource = this.bindingEERR;
            this.FormatearColumnasDataGridViewEERR();
        }

        public void limpiar()
        {
            if (this.listEstResEval != null)
            {
                this.listEstResEval.Clear();
            }

            this.bindingEERR.ResetBindings(false);
            if (this.dtgEstResEval.DataSource != null)
            {
                ((BindingSource)this.dtgEstResEval.DataSource).Clear();
            }
        }

        // public List<clsEstResEval> obtenerListaEstRes()
        // { 
        //     return 
        // }

        public void operandoEstadoResultados(ref List<clsEstResEval> _listEstResEval)
        {
            Decimal nAux = 0m,
                    nAuxTotal = 0m,
                    nPorcCuotaEndeuda = ObtenerPorcentajeMaximo();

            foreach (clsEstResEval item in _listEstResEval)
            {
                if (item.nTipoTrans == 1)
                {
                    nAux += item.nTotalMA;
                    nAuxTotal += item.nTotalMA;
                }
                else if (item.nTipoTrans == 2)
                {
                    nAux -= item.nTotalMA;
                    nAuxTotal -= item.nTotalMA;
                }
                else if (item.nTipoTrans == 3)
                {
                    item.nTotalMA = nAux;
                    //nAux = 0m;
                    if (item.idEEFF == EEFF.UtilidadDisponible)
                    {
                        item.nTotalMA = nAuxTotal;
                    }
                    else if (item.idEEFF == EEFF.IngresoDisponible)
                    {
                        item.nTotalMA = nAuxTotal;
                    }
                }
                else if (item.nTipoTrans == 4)
                {
                    item.nTotalMA = nAux;
                    //nAux = 0m;
                    if (item.idEEFF == EEFF.CuotaMaxEndeuda)
                    {
                        nAux = nAuxTotal = item.nTotalMA = nAuxTotal * (nPorcCuotaEndeuda);
                    }
                    else if (item.idEEFF == EEFF.CuotaMaxEndeudaConsumo)
                    {
                        nAux = nAuxTotal = item.nTotalMA = nAuxTotal * (nPorcCuotaEndeuda);
                    }
                }
            }
        }

        // --EERR
        private void FormatearColumnasDataGridViewEERR()
        {
            foreach (DataGridViewColumn column in this.dtgEstResEval.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEstResEval.Columns["cDescripcion"].DisplayIndex = 0;
            dtgEstResEval.Columns["nTotalMA"].DisplayIndex = 2;

            dtgEstResEval.Columns["cDescripcion"].Visible = true;
            dtgEstResEval.Columns["nTotalMA"].Visible = true;

            dtgEstResEval.Columns["cDescripcion"].HeaderText = "";

            dtgEstResEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgEstResEval.Columns["nTotalMA"].ToolTipText = "";

            dtgEstResEval.Columns["cDescripcion"].FillWeight = 80;
            dtgEstResEval.Columns["nTotalMA"].FillWeight = 45;

            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Format = "n2";

            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
            dtgEstResEval.Columns["nTotalMA"].ReadOnly = true;

        }

        private void pintarIguales()
        {
            foreach (DataGridViewRow item in dtgEstResEval.Rows)
            {
                if (Convert.ToInt32(item.Cells["nTipoTrans"].Value).In(3,4))
                {
                    item.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
                    item.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                }
            }
        }

        private void dtgEstResEval_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            this.pintarIguales();
        }

        public decimal obtenerItem(int idEEFF)
        {
            decimal nDecimal = 0;
            foreach (DataGridViewRow item in dtgEstResEval.Rows)
            {
                if (Convert.ToInt32(item.Cells["idEEFF"].Value) == idEEFF)
                {
                    nDecimal = Convert.ToDecimal(item.Cells["nTotalMA"].Value);
                }
            }
            return nDecimal;
        }

        public decimal ObtenerPorcentajeMaximo()
        {
            decimal nPorColaInt = Convert.ToDecimal(clsVarApl.dicVarGen["nPorConvColaboraCuotaMax"]);
            decimal nPorConv = Convert.ToDecimal(clsVarApl.dicVarGen["nPorConvCuotaMax"]);
            decimal nPorConsumo = Convert.ToDecimal(clsVarApl.dicVarGen["nPorCuotaMaxConsumo"]);

            string cIdsProductoConvInt = clsVarApl.dicVarGen["nIdProductoConvenioConIntitucion"];
            string[] cProdConvInt = cIdsProductoConvInt.Split(',');
            int[] nProdConvInt = Array.ConvertAll<string, int>(cProdConvInt, int.Parse);

            decimal nReturn = 0.00m;

            switch (this.idTipEvalCred)
            {
                case 12:
                        if (this.idProducto.In(nProdConvInt))
                        {
                            nReturn=  nPorColaInt;
                        }
                        else
                        {
                            nReturn =  nPorConv;
                        }
                    break;
                case 1:
                        nReturn =  nPorConsumo;
                    break;
            }

            return nReturn;
            
        }
    }
}
