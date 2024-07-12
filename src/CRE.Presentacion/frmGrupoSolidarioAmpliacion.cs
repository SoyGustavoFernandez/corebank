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

namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioAmpliacion : frmBase
    {
        #region Variables

        private clsCNGrupoSolidario objCNGrupoSolidario;
        public List<clsCreditoGrupoSolInt> lstCreditoGrupoInt;
        private clsCreditoGrupoSolInt objCreditoGrupoInt;

        private int idGrupoSolidario;

        public bool lAceptado;
        #endregion

        #region Metodos
        public frmGrupoSolidarioAmpliacion()
        {
            InitializeComponent();
            this.idGrupoSolidario = 0;
            this.inicializarDatos();
        }

        public frmGrupoSolidarioAmpliacion(int idGrupoSolidario)
        {
            InitializeComponent();
            this.idGrupoSolidario = idGrupoSolidario;
            this.inicializarDatos();
        }

        public void inicializarDatos()
        {
            this.objCNGrupoSolidario = new clsCNGrupoSolidario();
            this.lstCreditoGrupoInt = new List<clsCreditoGrupoSolInt>();
            this.objCreditoGrupoInt = new clsCreditoGrupoSolInt();

            this.bsCreditoApliacion.DataSource = this.lstCreditoGrupoInt;

            this.lAceptado = false;
        }

        public void listarCreditoAmpliableGrupoSol()
        {
            this.lstCreditoGrupoInt.Clear();
            this.lstCreditoGrupoInt.AddRange(this.objCNGrupoSolidario.listarCreditoAmpliableGrupoSol(this.idGrupoSolidario));

            if(this.lstCreditoGrupoInt.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("¡No se ha encontrado un CREDITO PRINCIPAL ACTIVO para AMPLIAR!",
                    "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.bsCreditoApliacion.ResetBindings(false);
            this.dtgCreditoAmpliacion.Refresh();
        }
        #endregion

        #region Eventos
        private void frmGrupoSolidarioAmpliacion_Load(object sender, EventArgs e)
        {
            this.listarCreditoAmpliableGrupoSol();
        }       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.lAceptado = true;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.lAceptado = false;
            this.Close();
        }

        private void dtgCreditoAmpliacion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCreditoAmpliacion.SelectedCells.Count > 0)
            {
                this.dtgCreditoAmpliacion.CellClick -= dtgCreditoAmpliacion_CellClick;

                int nFila = this.dtgCreditoAmpliacion.SelectedCells[0].RowIndex;
                int nColumna = this.dtgCreditoAmpliacion.SelectedCells[0].ColumnIndex;
                this.objCreditoGrupoInt = this.lstCreditoGrupoInt[nFila];

                if (this.dtgCreditoAmpliacion.Columns[e.ColumnIndex].Name.Equals("nMontoSolAmpliacion"))
                {
                    frmGrupoSolAmpMonto objFrmGrupoSolAmpMonto = new frmGrupoSolAmpMonto(this.objCreditoGrupoInt.nSaldoCapital, this.objCreditoGrupoInt.nMontoSolAmpliacion);
                    objFrmGrupoSolAmpMonto.ShowDialog();
                    if (objFrmGrupoSolAmpMonto.lAceptado)
                    {
                        this.dtgCreditoAmpliacion.CellEnter -= dtgCreditoAmpliacion_CellEnter;

                        this.objCreditoGrupoInt.nMontoAmpliado = (objFrmGrupoSolAmpMonto.nMonto - objCreditoGrupoInt.nSaldoCapital);
                        this.bsCreditoApliacion.ResetBindings(false);
                        this.dtgCreditoAmpliacion.Refresh();
                        this.dtgCreditoAmpliacion.CurrentCell = this.dtgCreditoAmpliacion[nColumna, nFila];

                        this.dtgCreditoAmpliacion.CellEnter += dtgCreditoAmpliacion_CellEnter;
                    }
                    else
                    {
                        this.dtgCreditoAmpliacion.CellClick -= dtgCreditoAmpliacion_CellClick;
                        this.dtgCreditoAmpliacion.CellClick += dtgCreditoAmpliacion_CellClick;
                    }
                }
            }
        }       

        private void dtgCreditoAmpliacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            if (this.dtgCreditoAmpliacion.Columns[e.ColumnIndex].DataPropertyName.Equals("nMontoAmpliado"))
            {
                double nValor;
                if (!double.TryParse(e.FormattedValue.ToString(), out nValor))
                {
                    MessageBox.Show("¡El valor del MONTO ingresado no debe estar VACIO ni contener LETRAS ni ESPACIOS!", "MONTO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }

                if (nValor < 0.00)
                {
                    MessageBox.Show("¡El Monto a Ampliar no puede ser Menor que Cero!", "MONTO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }
        private void dtgCreditoAmpliacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCreditoAmpliacion.SelectedCells.Count > 0)
            {
                int nFila = this.dtgCreditoAmpliacion.SelectedCells[0].RowIndex;
                int nColumna = this.dtgCreditoAmpliacion.SelectedCells[0].ColumnIndex;
                this.objCreditoGrupoInt = this.lstCreditoGrupoInt[nFila];

                if (this.dtgCreditoAmpliacion.Columns[e.ColumnIndex].Name.Equals("nMontoSolAmpliacion"))
                {
                    frmGrupoSolAmpMonto objFrmGrupoSolAmpMonto = new frmGrupoSolAmpMonto(this.objCreditoGrupoInt.nSaldoCapital, this.objCreditoGrupoInt.nMontoSolAmpliacion);
                    objFrmGrupoSolAmpMonto.ShowDialog();
                    if (objFrmGrupoSolAmpMonto.lAceptado)
                    {
                        this.dtgCreditoAmpliacion.CellEnter -= dtgCreditoAmpliacion_CellEnter;

                        this.objCreditoGrupoInt.nMontoAmpliado = (objFrmGrupoSolAmpMonto.nMonto - objCreditoGrupoInt.nSaldoCapital);
                        this.bsCreditoApliacion.ResetBindings(false);
                        this.dtgCreditoAmpliacion.Refresh();
                        this.dtgCreditoAmpliacion.CurrentCell = this.dtgCreditoAmpliacion[nColumna, nFila];

                        this.dtgCreditoAmpliacion.CellEnter += dtgCreditoAmpliacion_CellEnter;
                    }
                    this.dtgCreditoAmpliacion.CellClick -= dtgCreditoAmpliacion_CellClick;
                }
            }
        }
        #endregion


    }
}
