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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmHistorialTasacion : frmBase
    {
        #region Variable Globales

        public int idGarantia { get; set; }
        clsCNGarantia cngarantia = new clsCNGarantia();

        #endregion

        public frmHistorialTasacion()
        {
            InitializeComponent();
        }
        public frmHistorialTasacion(int _idGarantia)
        {
            InitializeComponent();
            idGarantia = _idGarantia;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            limpiar();
            dtgHistorico.Enabled = true;
            var dtTasacion = cngarantia.CNHistoricoValorizacion(idGarantia, 0);
            if (dtTasacion.Rows.Count > 0)
            {
                dtgHistorico.DataSource = dtTasacion;
                formatoGrid();
            }
            dtgHistorico.ClearSelection();
        }


        #endregion

        #region Métodos

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgHistorico.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgHistorico.Columns["dFecUltVal"].Visible = true;
            dtgHistorico.Columns["dFecVenVal"].Visible = true;
            dtgHistorico.Columns["cTasador"].Visible = true;
            dtgHistorico.Columns["cCondiInmueble"].Visible = true;
            dtgHistorico.Columns["cEstadoConservacion"].Visible = true;
            dtgHistorico.Columns["cMatPared"].Visible = true;
            dtgHistorico.Columns["cMatTecho"].Visible = true;
            dtgHistorico.Columns["cMatVenPuer"].Visible = true;
            dtgHistorico.Columns["nNumPisos"].Visible = true;
            dtgHistorico.Columns["nAreaTerreno"].Visible = true;
            dtgHistorico.Columns["nAreaContru"].Visible = true;
            dtgHistorico.Columns["dFecRegistro"].Visible = true;
            dtgHistorico.Columns["cWinUser"].Visible = true;

            dtgHistorico.Columns["nValorEdifica"].Visible = true;
            dtgHistorico.Columns["nValorComercial"].Visible = true;
            dtgHistorico.Columns["nValorMercado"].Visible = true;
            dtgHistorico.Columns["nValorNuevo"].Visible = true;
            dtgHistorico.Columns["nValorVenta"].Visible = true;

            dtgHistorico.Columns["dFecUltVal"].HeaderText = "Ult. Valoriza";
            dtgHistorico.Columns["dFecVenVal"].HeaderText = "Vence. Valoriza";
            dtgHistorico.Columns["cTasador"].HeaderText = "Tasador";
            dtgHistorico.Columns["cCondiInmueble"].HeaderText = "Condición";
            dtgHistorico.Columns["cEstadoConservacion"].HeaderText = "Conservación";
            dtgHistorico.Columns["cMatPared"].HeaderText = "Pared";
            dtgHistorico.Columns["cMatTecho"].HeaderText = "Techo";
            dtgHistorico.Columns["cMatVenPuer"].HeaderText = "Ventana/Puerta";
            dtgHistorico.Columns["nNumPisos"].HeaderText = "Nro.Pisos";
            dtgHistorico.Columns["nAreaTerreno"].HeaderText = "Terreno m2";
            dtgHistorico.Columns["nAreaContru"].HeaderText = "Construido m2";
            dtgHistorico.Columns["dFecRegistro"].HeaderText = "Registro";
            dtgHistorico.Columns["cWinUser"].HeaderText = "Usuario";

            dtgHistorico.Columns["nValorEdifica"].HeaderText = "Val.Edifica";
            dtgHistorico.Columns["nValorComercial"].HeaderText = "Val.Comercial";
            dtgHistorico.Columns["nValorMercado"].HeaderText = "Val.Mercado";
            dtgHistorico.Columns["nValorNuevo"].HeaderText = "Val.Nuevo";
            dtgHistorico.Columns["nValorVenta"].HeaderText = "Val.Venta";

            dtgHistorico.Columns["nValorEdifica"].DefaultCellStyle.Format = "N2";
            dtgHistorico.Columns["nValorComercial"].DefaultCellStyle.Format = "N2";
            dtgHistorico.Columns["nValorMercado"].DefaultCellStyle.Format = "N2";
            dtgHistorico.Columns["nValorNuevo"].DefaultCellStyle.Format = "N2";
            dtgHistorico.Columns["nValorVenta"].DefaultCellStyle.Format = "N2";

            dtgHistorico.Columns["nValorEdifica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistorico.Columns["nValorComercial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistorico.Columns["nValorMercado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistorico.Columns["nValorNuevo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistorico.Columns["nValorVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void limpiar()
        {
            dtgHistorico.DataSource = null;
        }

        #endregion
    }
}
