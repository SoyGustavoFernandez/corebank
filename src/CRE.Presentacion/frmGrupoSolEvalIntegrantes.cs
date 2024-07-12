using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmGrupoSolEvalIntegrantes : frmBase
    {
        #region Variables
        private int idEvalCredGrupoSol;
        //private decimal nCuotaAprox;
        private List<clsEvalCredIDs> listEvalCredIDs;

        private List<clsEstResEval> listEstResEvalDB;
        private List<clsEstResEvalGrupoSol> listEstResEvalGrupoSol;
        private List<clsIndicadorEval> listIndiFinancDB;
        private List<clsIndicadorEvalGrupoSol> listIndiFinancGrupoSol;

        private List<clsEvalCredIntegGrupoSol> lstEvalCredIntegGrupoSol;

        private const string TITULO_FORM = "Grupo Solidario - Evaluación de Integrantes";

        public bool lGuardado;
        public List<clsEvalCredIntegGrupoSol> lstEvalCredIntegGrupoSolidario;
        public int nCuotas;
        #endregion

        #region Constructores
        public frmGrupoSolEvalIntegrantes()
        {
            InitializeComponent();
        }

        //public frmGrupoSolEvalIntegrantes(int _idEvalCredGrupoSol, decimal _nCuotaAprox)
        public frmGrupoSolEvalIntegrantes(int _idEvalCredGrupoSol, List<clsEvalCredIntegGrupoSol> _lstEvalCredIntegGrupoSol)
        {
            this.idEvalCredGrupoSol = _idEvalCredGrupoSol;
            this.listEstResEvalGrupoSol = new List<clsEstResEvalGrupoSol>();
            this.listIndiFinancGrupoSol = new List<clsIndicadorEvalGrupoSol>();
            this.lstEvalCredIntegGrupoSol = _lstEvalCredIntegGrupoSol;
            //this.nCuotaAprox = _nCuotaAprox;
            this.lGuardado = false;

            InitializeComponent();

            //this.txtCuotaAprox.Text = this.nCuotaAprox.ToString("n2");

            HabilitarFormulario(EventoFormulario.CANCELAR);
        }
        #endregion

        #region Métodos Privados
        private void RecuperarDatos()
        {
            this.dtgEstResEval.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellLeave);
            this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEstResEval_DataError);
            this.dtgEstResEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);

            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);

            DataSet ds = (new CRE.CapaNegocio.clsCNGrupoSolidario()).ObtenerEvalIntegrantesGrupoSol(this.idEvalCredGrupoSol);

            this.listEvalCredIDs = DataTableToList.ConvertTo<clsEvalCredIDs>(ds.Tables[0]) as List<clsEvalCredIDs>;
            this.listEstResEvalDB = DataTableToList.ConvertTo<clsEstResEval>(ds.Tables[1]) as List<clsEstResEval>;
            this.listIndiFinancDB = DataTableToList.ConvertTo<clsIndicadorEval>(ds.Tables[2]) as List<clsIndicadorEval>;

            // Convertir datos EstRes individual a Grupal
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.VentasNetas));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.CostoVentas));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.UtilidadBruta));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.GastosNegocio));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.UtilidadOperativa));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.GastosFinancieros));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.UtilidadNeta));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.OtrosIngresos));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.OtrosEgresos));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.GastosFamiliares));
            this.listEstResEvalGrupoSol.Add(TransponerEstResEval(this.listEvalCredIDs, this.listEstResEvalDB, EEFF.UtilidadDisponible));

            // Convertir datos IndicadorFinanciero individual a Grupal
            this.listIndiFinancGrupoSol.Add(TransponerIndicadorEval(this.listEvalCredIDs, this.listIndiFinancDB, IFN.CapacidadPago));

            // Asignar a los datagridview las listas
            this.dtgEstResEval.DataSource = this.listEstResEvalGrupoSol;
            FormatearDataGridViewEstRes();
            StyleCellDataGridViewEERR();
            CalcularEERR();

            this.dtgIndiFinanc.DataSource = this.listIndiFinancGrupoSol;
            FormatearDataGridViewIndiFinan();
            ActualizarIndicadorFinanciero();

            this.dtgEstResEval.ClearSelection();
            this.dtgIndiFinanc.ClearSelection();

            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);

            this.dtgEstResEval.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellLeave);
            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEstResEval_DataError);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);

            this.dtgIntegrantes.DataSource = this.lstEvalCredIntegGrupoSolidario;
            FormatearDataGridIntegrantes();
            this.dtgIntegrantes.ClearSelection();
        }

        #region Métodos Privados Estado de Resultados
        private void FormatearDataGridIntegrantes()
        {
            foreach (DataGridViewColumn column in this.dtgIntegrantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dtgIntegrantes.Columns.Count > 0)
            {
                dtgIntegrantes.Columns["nNro"].DisplayIndex = 0;
                dtgIntegrantes.Columns["idSolicitud"].DisplayIndex = 1;
                dtgIntegrantes.Columns["cNombre"].DisplayIndex = 2;
                dtgIntegrantes.Columns["nMonto"].DisplayIndex = 3;
                dtgIntegrantes.Columns["nTEA"].DisplayIndex = 4;
                dtgIntegrantes.Columns["nTIM"].DisplayIndex = 5;
                dtgIntegrantes.Columns["nCuotaAprox"].DisplayIndex = 6;
                dtgIntegrantes.Columns["nCuotaGraciaAprox"].DisplayIndex = 7;
                dtgIntegrantes.Columns["cActividadInterna"].DisplayIndex = 8;

                dtgIntegrantes.Columns["nNro"].Visible = true;
                dtgIntegrantes.Columns["cNombre"].Visible = true;

                dtgIntegrantes.Columns["nNro"].HeaderText = "N.";
                dtgIntegrantes.Columns["cNombre"].HeaderText = "Cliente";

                dtgIntegrantes.Columns["nNro"].FillWeight = 10;
                dtgIntegrantes.Columns["cNombre"].FillWeight = 55;

                dtgIntegrantes.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void FormatearDataGridViewEstRes()
        {
            int i = 0;
            foreach (DataGridViewColumn column in this.dtgEstResEval.Columns)
            {
                column.Visible = false;
                column.Width = 70;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.ReadOnly = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                for (i = 0; i < listEvalCredIDs.Count; i++)
                {
                    if (column.DataPropertyName == ("nIntegrante" + (i + 1).ToString().PadLeft(2, '0')))
                    {
                        column.HeaderText = (i + 1).ToString();
                        column.Visible = true;
                        column.DefaultCellStyle.Format = "#,###,##0.#";
                        column.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                        break;
                    }
                }
            }

            dtgEstResEval.Columns["idEEFF"].Visible = false;

            dtgEstResEval.Columns["cDescripcion"].Visible = true;
            dtgEstResEval.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgEstResEval.Columns["cDescripcion"].Width = 140;
            dtgEstResEval.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
        }

        private clsEstResEvalGrupoSol TransponerEstResEval(List<clsEvalCredIDs> _listEvalCredGrupoIDs, List<clsEstResEval> _listEstResEval, int _idEEFF)
        {
            clsEstResEvalGrupoSol objEstResGrupoSol = new clsEstResEvalGrupoSol();

            int i = 1;
            foreach (var q in _listEvalCredGrupoIDs)
            {
                var list = from p in _listEstResEval
                           where p.idEvalCred == q.idEvalCred && p.idEEFF == _idEEFF
                           select p;

                objEstResGrupoSol.cDescripcion = list.First().cDescripcion;
                objEstResGrupoSol.idEEFF = _idEEFF;

                switch (i)
                {
                    case 1: objEstResGrupoSol.nIntegrante01 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred01 = q.idEvalCred; break;
                    case 2: objEstResGrupoSol.nIntegrante02 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred02 = q.idEvalCred; break;
                    case 3: objEstResGrupoSol.nIntegrante03 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred03 = q.idEvalCred; break;
                    case 4: objEstResGrupoSol.nIntegrante04 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred04 = q.idEvalCred; break;
                    case 5: objEstResGrupoSol.nIntegrante05 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred05 = q.idEvalCred; break;
                    case 6: objEstResGrupoSol.nIntegrante06 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred06 = q.idEvalCred; break;
                    case 7: objEstResGrupoSol.nIntegrante07 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred07 = q.idEvalCred; break;
                    case 8: objEstResGrupoSol.nIntegrante08 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred08 = q.idEvalCred; break;
                    case 9: objEstResGrupoSol.nIntegrante09 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred09 = q.idEvalCred; break;
                    case 10: objEstResGrupoSol.nIntegrante10 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred10 = q.idEvalCred; break;
                    case 11: objEstResGrupoSol.nIntegrante11 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred11 = q.idEvalCred; break;
                    case 12: objEstResGrupoSol.nIntegrante12 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred12 = q.idEvalCred; break;
                    case 13: objEstResGrupoSol.nIntegrante13 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred13 = q.idEvalCred; break;
                    case 14: objEstResGrupoSol.nIntegrante14 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred14 = q.idEvalCred; break;
                    case 15: objEstResGrupoSol.nIntegrante15 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred15 = q.idEvalCred; break;
                    case 16: objEstResGrupoSol.nIntegrante16 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred16 = q.idEvalCred; break;
                    case 17: objEstResGrupoSol.nIntegrante17 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred17 = q.idEvalCred; break;
                    case 18: objEstResGrupoSol.nIntegrante18 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred18 = q.idEvalCred; break;
                    case 19: objEstResGrupoSol.nIntegrante19 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred19 = q.idEvalCred; break;
                    case 20: objEstResGrupoSol.nIntegrante20 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred20 = q.idEvalCred; break;
                    case 21: objEstResGrupoSol.nIntegrante21 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred21 = q.idEvalCred; break;
                    case 22: objEstResGrupoSol.nIntegrante22 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred22 = q.idEvalCred; break;
                    case 23: objEstResGrupoSol.nIntegrante23 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred23 = q.idEvalCred; break;
                    case 24: objEstResGrupoSol.nIntegrante24 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred24 = q.idEvalCred; break;
                    case 25: objEstResGrupoSol.nIntegrante25 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred25 = q.idEvalCred; break;
                    case 26: objEstResGrupoSol.nIntegrante26 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred26 = q.idEvalCred; break;
                    case 27: objEstResGrupoSol.nIntegrante27 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred27 = q.idEvalCred; break;
                    case 28: objEstResGrupoSol.nIntegrante28 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred28 = q.idEvalCred; break;
                    case 29: objEstResGrupoSol.nIntegrante29 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred29 = q.idEvalCred; break;
                    case 30: objEstResGrupoSol.nIntegrante30 = list.First().nTotalMA; objEstResGrupoSol.idEvalCred30 = q.idEvalCred; break;
                }

                i++;
            }

            return objEstResGrupoSol;
        }

        private void AsignarObjetoEstResEval(int _idEvalCred, decimal _nMonto, int _idEEFF)
        {
            if (_idEvalCred > 0)
            {
                clsEstResEval obj = (from q in this.listEstResEvalDB
                                     where q.idEvalCred == _idEvalCred && q.idEEFF == _idEEFF
                                     select q).FirstOrDefault();

                obj.nTotalMA = _nMonto;
            }
        }

        private void AsignarObjetoEstResPorIntegrantes(clsEstResEvalGrupoSol _oEstResEvalGrupoSolint, int _idEEFF)
        {
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred01, _oEstResEvalGrupoSolint.nIntegrante01, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred02, _oEstResEvalGrupoSolint.nIntegrante02, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred03, _oEstResEvalGrupoSolint.nIntegrante03, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred04, _oEstResEvalGrupoSolint.nIntegrante04, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred05, _oEstResEvalGrupoSolint.nIntegrante05, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred06, _oEstResEvalGrupoSolint.nIntegrante06, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred07, _oEstResEvalGrupoSolint.nIntegrante07, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred08, _oEstResEvalGrupoSolint.nIntegrante08, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred09, _oEstResEvalGrupoSolint.nIntegrante09, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred10, _oEstResEvalGrupoSolint.nIntegrante10, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred11, _oEstResEvalGrupoSolint.nIntegrante11, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred12, _oEstResEvalGrupoSolint.nIntegrante12, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred13, _oEstResEvalGrupoSolint.nIntegrante13, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred14, _oEstResEvalGrupoSolint.nIntegrante14, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred15, _oEstResEvalGrupoSolint.nIntegrante15, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred16, _oEstResEvalGrupoSolint.nIntegrante16, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred17, _oEstResEvalGrupoSolint.nIntegrante17, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred18, _oEstResEvalGrupoSolint.nIntegrante18, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred19, _oEstResEvalGrupoSolint.nIntegrante19, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred20, _oEstResEvalGrupoSolint.nIntegrante20, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred21, _oEstResEvalGrupoSolint.nIntegrante21, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred22, _oEstResEvalGrupoSolint.nIntegrante22, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred23, _oEstResEvalGrupoSolint.nIntegrante23, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred24, _oEstResEvalGrupoSolint.nIntegrante24, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred25, _oEstResEvalGrupoSolint.nIntegrante25, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred26, _oEstResEvalGrupoSolint.nIntegrante26, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred27, _oEstResEvalGrupoSolint.nIntegrante27, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred28, _oEstResEvalGrupoSolint.nIntegrante28, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred29, _oEstResEvalGrupoSolint.nIntegrante29, _idEEFF);
            AsignarObjetoEstResEval(_oEstResEvalGrupoSolint.idEvalCred30, _oEstResEvalGrupoSolint.nIntegrante30, _idEEFF);
        }

        private void StyleCellDataGridViewEERR()
        {
            int idEEFF = 0;
            foreach (DataGridViewRow row in this.dtgEstResEval.Rows)
            {
                idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);

                if (idEEFF == EEFF.UtilidadBruta || idEEFF == EEFF.UtilidadOperativa ||
                    idEEFF == EEFF.UtilidadNeta || idEEFF == EEFF.UtilidadDisponible)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
                    row.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                }
            }
        }

        private decimal ObtenerValorEstResEval(clsEstResEvalGrupoSol _oEstResEvalGrupoSol, int _idEvalCred)
        {
            decimal nTotal = 0;

            if (_oEstResEvalGrupoSol.idEvalCred01 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante01;
            else if (_oEstResEvalGrupoSol.idEvalCred02 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante02;
            else if (_oEstResEvalGrupoSol.idEvalCred03 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante03;
            else if (_oEstResEvalGrupoSol.idEvalCred04 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante04;
            else if (_oEstResEvalGrupoSol.idEvalCred05 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante05;
            else if (_oEstResEvalGrupoSol.idEvalCred06 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante06;
            else if (_oEstResEvalGrupoSol.idEvalCred07 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante07;
            else if (_oEstResEvalGrupoSol.idEvalCred08 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante08;
            else if (_oEstResEvalGrupoSol.idEvalCred09 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante09;
            else if (_oEstResEvalGrupoSol.idEvalCred10 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante10;
            else if (_oEstResEvalGrupoSol.idEvalCred11 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante11;
            else if (_oEstResEvalGrupoSol.idEvalCred12 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante12;
            else if (_oEstResEvalGrupoSol.idEvalCred13 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante13;
            else if (_oEstResEvalGrupoSol.idEvalCred14 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante14;
            else if (_oEstResEvalGrupoSol.idEvalCred15 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante15;
            else if (_oEstResEvalGrupoSol.idEvalCred16 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante16;
            else if (_oEstResEvalGrupoSol.idEvalCred17 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante17;
            else if (_oEstResEvalGrupoSol.idEvalCred18 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante18;
            else if (_oEstResEvalGrupoSol.idEvalCred19 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante19;
            else if (_oEstResEvalGrupoSol.idEvalCred20 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante20;
            else if (_oEstResEvalGrupoSol.idEvalCred21 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante21;
            else if (_oEstResEvalGrupoSol.idEvalCred22 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante22;
            else if (_oEstResEvalGrupoSol.idEvalCred23 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante23;
            else if (_oEstResEvalGrupoSol.idEvalCred24 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante24;
            else if (_oEstResEvalGrupoSol.idEvalCred25 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante25;
            else if (_oEstResEvalGrupoSol.idEvalCred26 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante26;
            else if (_oEstResEvalGrupoSol.idEvalCred27 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante27;
            else if (_oEstResEvalGrupoSol.idEvalCred28 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante28;
            else if (_oEstResEvalGrupoSol.idEvalCred29 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante29;
            else if (_oEstResEvalGrupoSol.idEvalCred30 == _idEvalCred) nTotal = _oEstResEvalGrupoSol.nIntegrante30;

            return nTotal;
        }

        private void AsignarValorEstResEval(clsEstResEvalGrupoSol _oEstResEvalGrupoSol, int _idEvalCred, decimal _nTotal)
        {
            if (_oEstResEvalGrupoSol.idEvalCred01 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante01 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred02 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante02 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred03 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante03 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred04 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante04 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred05 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante05 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred06 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante06 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred07 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante07 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred08 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante08 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred09 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante09 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred10 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante10 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred11 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante11 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred12 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante12 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred13 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante13 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred14 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante14 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred15 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante15 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred16 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante16 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred17 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante17 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred18 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante18 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred19 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante19 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred20 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante20 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred21 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante21 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred22 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante22 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred23 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante23 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred24 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante24 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred25 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante25 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred26 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante26 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred27 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante27 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred28 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante28 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred29 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante29 = _nTotal;
            else if (_oEstResEvalGrupoSol.idEvalCred30 == _idEvalCred) _oEstResEvalGrupoSol.nIntegrante30 = _nTotal;
        }

        private void CalcularEERR()
        {
            decimal nVentasNetas = 0m,
                    nCostoVentas = 0m,
                    nUBruta = 0m,
                    nGastoNegocio = 0m,
                    nUOperativa = 0m,
                    nGastosFinancieros = 0m,
                    nUNeta = 0m,
                    nOtrosIngresos = 0m,
                    nOtrosEgresos = 0m,
                    nGastosFamiliares = 0m,
                    nUDisponible = 0m;

            foreach (clsEvalCredIDs oEvalCredIDs in this.listEvalCredIDs)
            {
                nVentasNetas = 0m;
                nCostoVentas = 0m;
                nUBruta = 0m;
                nGastoNegocio = 0m;
                nUOperativa = 0m;
                nGastosFinancieros = 0m;
                nUNeta = 0m;
                nOtrosIngresos = 0m;
                nOtrosEgresos = 0m;
                nGastosFamiliares = 0m;
                nUDisponible = 0m;

                foreach (clsEstResEvalGrupoSol oEstResEvalGrupoSol in this.listEstResEvalGrupoSol)
                {
                    if (oEstResEvalGrupoSol.idEEFF == EEFF.VentasNetas)
                    {
                        nVentasNetas = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.CostoVentas)
                    {
                        nCostoVentas = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.UtilidadBruta)
                    {
                        nUBruta = nVentasNetas - nCostoVentas;
                        AsignarValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred, nUBruta);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.GastosNegocio)
                    {
                        nGastoNegocio = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.UtilidadOperativa)
                    {
                        nUOperativa = nUBruta - nGastoNegocio;
                        AsignarValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred, nUOperativa);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.GastosFinancieros)
                    {
                        nGastosFinancieros = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.UtilidadNeta)
                    {
                        nUNeta = nUOperativa - nGastosFinancieros;
                        AsignarValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred, nUNeta);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.OtrosIngresos)
                    {
                        nOtrosIngresos = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.OtrosEgresos)
                    {
                        nOtrosEgresos = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.GastosFamiliares)
                    {
                        nGastosFamiliares = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.UtilidadDisponible)
                    {
                        nUDisponible = nUNeta + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares;
                        AsignarValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred, nUDisponible);
                    }
                }
            }
        }

        private string EstResEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEstResEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));
            dt.Columns.Add("nTotalMN", typeof(decimal));
            dt.Columns.Add("nTotalME", typeof(decimal));

            foreach (clsEstResEval er in this.listEstResEvalDB)
            {
                dt.Rows.Add(
                    er.idEstResEval,
                    er.nTotalUltEvMA,
                    er.nTotalMA,
                    er.nAnalisisVerti,
                    er.nAnalisisHoriz,
                    er.nTotalMN,
                    er.nTotalME
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "EstResEval", "Item");
        }
        #endregion

        #region Métodos Privados Indicadores Financieros
        private void FormatearDataGridViewIndiFinan()
        {
            int i = 0;
            foreach (DataGridViewColumn column in this.dtgIndiFinanc.Columns)
            {
                column.Visible = false;
                column.Width = 70;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                for (i = 0; i < listEvalCredIDs.Count; i++)
                {
                    if (column.DataPropertyName == ("nIntegrante" + (i + 1).ToString().PadLeft(2, '0')))
                    {
                        column.HeaderText = (i+1).ToString();
                        column.Visible = true;
                        column.DefaultCellStyle.Format = "P2";
                        break;
                    }
                }
            }

            dtgIndiFinanc.Columns["nCodigo"].Visible = false;

            dtgIndiFinanc.Columns["cDescripcion"].Visible = true;
            dtgIndiFinanc.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgIndiFinanc.Columns["cDescripcion"].Width = 140;
            dtgIndiFinanc.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private clsIndicadorEvalGrupoSol TransponerIndicadorEval(List<clsEvalCredIDs> _listEvalCredGrupoIDs, List<clsIndicadorEval> _listIndicadorEval, int _nCodigo)
        {
            clsIndicadorEvalGrupoSol objIndicadorEvalGrupoSol = new clsIndicadorEvalGrupoSol();

            int i = 1;
            foreach (var q in _listEvalCredGrupoIDs)
            {
                var list = from p in _listIndicadorEval
                           where p.idEvalCred == q.idEvalCred && p.nCodigo == _nCodigo
                           select p;

                objIndicadorEvalGrupoSol.cDescripcion = list.First().cDescripcion;
                objIndicadorEvalGrupoSol.nCodigo = _nCodigo;

                switch (i)
                {
                    case 1: objIndicadorEvalGrupoSol.nIntegrante01 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred01 = q.idEvalCred; break;
                    case 2: objIndicadorEvalGrupoSol.nIntegrante02 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred02 = q.idEvalCred; break;
                    case 3: objIndicadorEvalGrupoSol.nIntegrante03 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred03 = q.idEvalCred; break;
                    case 4: objIndicadorEvalGrupoSol.nIntegrante04 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred04 = q.idEvalCred; break;
                    case 5: objIndicadorEvalGrupoSol.nIntegrante05 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred05 = q.idEvalCred; break;
                    case 6: objIndicadorEvalGrupoSol.nIntegrante06 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred06 = q.idEvalCred; break;
                    case 7: objIndicadorEvalGrupoSol.nIntegrante07 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred07 = q.idEvalCred; break;
                    case 8: objIndicadorEvalGrupoSol.nIntegrante08 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred08 = q.idEvalCred; break;
                    case 9: objIndicadorEvalGrupoSol.nIntegrante09 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred09 = q.idEvalCred; break;
                    case 10: objIndicadorEvalGrupoSol.nIntegrante10 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred10 = q.idEvalCred; break;
                    case 11: objIndicadorEvalGrupoSol.nIntegrante11 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred11 = q.idEvalCred; break;
                    case 12: objIndicadorEvalGrupoSol.nIntegrante12 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred12 = q.idEvalCred; break;
                    case 13: objIndicadorEvalGrupoSol.nIntegrante13 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred13 = q.idEvalCred; break;
                    case 14: objIndicadorEvalGrupoSol.nIntegrante14 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred14 = q.idEvalCred; break;
                    case 15: objIndicadorEvalGrupoSol.nIntegrante15 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred15 = q.idEvalCred; break;
                    case 16: objIndicadorEvalGrupoSol.nIntegrante16 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred16 = q.idEvalCred; break;
                    case 17: objIndicadorEvalGrupoSol.nIntegrante17 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred17 = q.idEvalCred; break;
                    case 18: objIndicadorEvalGrupoSol.nIntegrante18 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred18 = q.idEvalCred; break;
                    case 19: objIndicadorEvalGrupoSol.nIntegrante19 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred19 = q.idEvalCred; break;
                    case 20: objIndicadorEvalGrupoSol.nIntegrante20 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred20 = q.idEvalCred; break;
                    case 21: objIndicadorEvalGrupoSol.nIntegrante21 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred21 = q.idEvalCred; break;
                    case 22: objIndicadorEvalGrupoSol.nIntegrante22 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred22 = q.idEvalCred; break;
                    case 23: objIndicadorEvalGrupoSol.nIntegrante23 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred23 = q.idEvalCred; break;
                    case 24: objIndicadorEvalGrupoSol.nIntegrante24 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred24 = q.idEvalCred; break;
                    case 25: objIndicadorEvalGrupoSol.nIntegrante25 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred25 = q.idEvalCred; break;
                    case 26: objIndicadorEvalGrupoSol.nIntegrante26 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred26 = q.idEvalCred; break;
                    case 27: objIndicadorEvalGrupoSol.nIntegrante27 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred27 = q.idEvalCred; break;
                    case 28: objIndicadorEvalGrupoSol.nIntegrante28 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred28 = q.idEvalCred; break;
                    case 29: objIndicadorEvalGrupoSol.nIntegrante29 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred29 = q.idEvalCred; break;
                    case 30: objIndicadorEvalGrupoSol.nIntegrante30 = list.First().nRatio; objIndicadorEvalGrupoSol.idEvalCred30 = q.idEvalCred; break;
                }

                i++;
            }

            return objIndicadorEvalGrupoSol;
        }

        private void AsignarObjetoIndiFinanEval(int _idEvalCred, decimal _nRatio, int _nCodigo)
        {
            if (_idEvalCred > 0)
            {
                clsIndicadorEval obj = (from q in this.listIndiFinancDB
                                     where q.idEvalCred == _idEvalCred && q.nCodigo == _nCodigo
                                     select q).FirstOrDefault();

                obj.nRatio = _nRatio;
            }
        }

        private void AsignarObjetoIndiFinanPorIntegrantes(clsIndicadorEvalGrupoSol _oIndicadorEvalGrupoSol, int _nCodigo)
        {
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred01, _oIndicadorEvalGrupoSol.nIntegrante01, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred02, _oIndicadorEvalGrupoSol.nIntegrante02, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred03, _oIndicadorEvalGrupoSol.nIntegrante03, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred04, _oIndicadorEvalGrupoSol.nIntegrante04, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred05, _oIndicadorEvalGrupoSol.nIntegrante05, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred06, _oIndicadorEvalGrupoSol.nIntegrante06, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred07, _oIndicadorEvalGrupoSol.nIntegrante07, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred08, _oIndicadorEvalGrupoSol.nIntegrante08, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred09, _oIndicadorEvalGrupoSol.nIntegrante09, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred10, _oIndicadorEvalGrupoSol.nIntegrante10, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred11, _oIndicadorEvalGrupoSol.nIntegrante11, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred12, _oIndicadorEvalGrupoSol.nIntegrante12, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred13, _oIndicadorEvalGrupoSol.nIntegrante13, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred14, _oIndicadorEvalGrupoSol.nIntegrante14, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred15, _oIndicadorEvalGrupoSol.nIntegrante15, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred16, _oIndicadorEvalGrupoSol.nIntegrante16, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred17, _oIndicadorEvalGrupoSol.nIntegrante17, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred18, _oIndicadorEvalGrupoSol.nIntegrante18, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred19, _oIndicadorEvalGrupoSol.nIntegrante19, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred20, _oIndicadorEvalGrupoSol.nIntegrante20, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred21, _oIndicadorEvalGrupoSol.nIntegrante21, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred22, _oIndicadorEvalGrupoSol.nIntegrante22, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred23, _oIndicadorEvalGrupoSol.nIntegrante23, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred24, _oIndicadorEvalGrupoSol.nIntegrante24, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred25, _oIndicadorEvalGrupoSol.nIntegrante25, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred26, _oIndicadorEvalGrupoSol.nIntegrante26, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred27, _oIndicadorEvalGrupoSol.nIntegrante27, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred28, _oIndicadorEvalGrupoSol.nIntegrante28, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred29, _oIndicadorEvalGrupoSol.nIntegrante29, _nCodigo);
            AsignarObjetoIndiFinanEval(_oIndicadorEvalGrupoSol.idEvalCred30, _oIndicadorEvalGrupoSol.nIntegrante30, _nCodigo);
        }

        private void ActualizarIndicadorFinanciero()
        {
            //decimal nCuotaAprox = CuotasAprox();
            decimal nCuotaAprox;

            decimal nGastosFinancieros = 0m,
                    nUDisponible = 0m,
                    nCapacidadPago = 0m;

            foreach (clsEvalCredIDs oEvalCredIDs in this.listEvalCredIDs)
            {
                clsEvalCredIntegGrupoSol obj = (from p in this.lstEvalCredIntegGrupoSol
                                              where p.idEvalCred == oEvalCredIDs.idEvalCred
                                              select p).First();

                nGastosFinancieros = 0m;
                nUDisponible = 0m;
                nCuotaAprox = obj.nCuotaAprox;

                //---------------- Estados Financieros
                foreach (clsEstResEvalGrupoSol oEstResEvalGrupoSol in this.listEstResEvalGrupoSol)
                {
                    if (oEstResEvalGrupoSol.idEEFF == EEFF.GastosFinancieros)
                    {
                        nGastosFinancieros = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }

                    if (oEstResEvalGrupoSol.idEEFF == EEFF.UtilidadDisponible)
                    {
                        nUDisponible = ObtenerValorEstResEval(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred);
                    }
                }

                //---------------- Indicadores Financieros
                nCapacidadPago = clsNumerico.Dividir((nCuotaAprox + nGastosFinancieros), (nUDisponible + nGastosFinancieros));

                foreach (clsIndicadorEvalGrupoSol oEstResEvalGrupoSol in this.listIndiFinancGrupoSol)
                {
                    if (oEstResEvalGrupoSol.nCodigo == IFN.CapacidadPago)
                    {
                        //if (nCapacidadPago == 0)
                        //{
                        //    MessageBox.Show("La capacidad de pago NO debe de ser igual(=) a 0%.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        //if (nCapacidadPago < 0) 
                        //{ 
                        //    MessageBox.Show("La capacidad de pago NO debe de ser menor(<) a 0%.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        //decimal nTop = nCapacidadPago * 100;
                        //if (nTop > 80)
                        //{
                        //    MessageBox.Show("La capacidad de pago debe ser mayor(>) a cero y menor o igual(<=) a 80%.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}

                        AsignarValorIndicadorFinan(oEstResEvalGrupoSol, oEvalCredIDs.idEvalCred, nCapacidadPago);
                    }
                }
            }

            this.dtgIndiFinanc.Refresh(); //ok
        }

        private void AsignarValorIndicadorFinan(clsIndicadorEvalGrupoSol _oIndicadorEvalGrupoSol, int _idEvalCred, decimal _nTotal)
        {
            if (_oIndicadorEvalGrupoSol.idEvalCred01 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante01 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred02 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante02 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred03 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante03 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred04 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante04 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred05 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante05 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred06 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante06 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred07 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante07 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred08 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante08 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred09 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante09 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred10 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante10 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred11 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante11 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred12 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante12 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred13 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante13 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred14 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante14 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred15 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante15 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred16 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante16 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred17 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante17 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred18 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante18 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred19 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante19 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred20 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante20 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred21 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante21 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred22 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante22 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred23 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante23 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred24 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante24 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred25 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante25 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred26 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante26 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred27 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante27 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred28 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante28 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred29 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante29 = _nTotal;
            else if (_oIndicadorEvalGrupoSol.idEvalCred30 == _idEvalCred) _oIndicadorEvalGrupoSol.nIntegrante30 = _nTotal;
        }

        private string IndicadoresToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idIndicadorEval", typeof(int));
            dt.Columns.Add("nRatio", typeof(decimal));

            foreach (clsIndicadorEval rc in this.listIndiFinancDB)
            {
                dt.Rows.Add(rc.idIndicadorEval, rc.nRatio);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "IndicadorEval", "Item");
        }
        #endregion

        private void HabilitarFormulario(EventoFormulario eButton)
        {
            switch (eButton)
            {
                case EventoFormulario.EDITAR:
                    this.btnGrabar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.dtgEstResEval.Enabled = true;

                    break;

                case EventoFormulario.GRABAR:
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.dtgEstResEval.Enabled = false;

                    this.dtgEstResEval.ClearSelection();
                    this.dtgIndiFinanc.ClearSelection();
                    break;

                case EventoFormulario.CANCELAR:
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.dtgEstResEval.Enabled = false;

                    this.dtgEstResEval.ClearSelection();
                    this.dtgIndiFinanc.ClearSelection();
                    break;
            }
        }
        #endregion

        #region Eventos
        #region Eventos del Formulario
        private void frmGrupoSolEvalIntegrantes_Load(object sender, EventArgs e)
        {
            RecuperarDatos();
        }
        #endregion

        #region Eventos DataGridView Estados de Resultados
        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularEERR();
            this.dtgEstResEval.Refresh(); //ok

            ActualizarIndicadorFinanciero();

            //if (CellValueChangedEstadosFinancieros != null)
            //    CellValueChangedEstadosFinancieros(sender, e);
        }

        private void dtgEstResEval_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalUltEvMA") || dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalMA"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void dtgEstResEval_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgEstResEval.ClearSelection();
            this.dtgEstResEval.Refresh();
        }

        private void dtgEstResEval_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Se ingresó un valor invalido en la celda.\nVer Columna \""
                    + dtg.CurrentCell.OwningColumn.HeaderText + "\" y fila " + (e.RowIndex + 1) + ".",
                    "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if ((e.Exception) is ConstraintException)
            {
                dtg.Rows[e.RowIndex].ErrorText = "an error";
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }
        #endregion

        #region Eventos DataGridView Indicadores Financieros
        private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dtgIndiFinanc_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgIndiFinanc.ClearSelection();
            this.dtgIndiFinanc.Refresh();
        }

        #endregion

        #region Eventos Botones
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            foreach (clsEstResEvalGrupoSol oEstResEvalGrupoSol in this.listEstResEvalGrupoSol)
            {
                AsignarObjetoEstResPorIntegrantes(oEstResEvalGrupoSol, oEstResEvalGrupoSol.idEEFF);
            }

            foreach (clsIndicadorEvalGrupoSol oIndicadorEvalGrupoSol in this.listIndiFinancGrupoSol)
            {
                AsignarObjetoIndiFinanPorIntegrantes(oIndicadorEvalGrupoSol, oIndicadorEvalGrupoSol.nCodigo);
            }

            string xmlEstResEval = this.EstResEvalToXML();
            string xmlIndicadorEval = IndicadoresToXML();

            DataTable dt = (new CRE.CapaNegocio.clsCNGrupoSolidario()).GuardarEvalIntegrantes(this.idEvalCredGrupoSol, xmlEstResEval, xmlIndicadorEval);

            if (dt.Rows.Count > 0)
            {
                DataRow drResult = dt.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    this.lGuardado = true;

                    MessageBox.Show(drResult["cMsje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HabilitarFormulario(EventoFormulario.GRABAR);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.CANCELAR);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.EDITAR);
        }
        #endregion

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
