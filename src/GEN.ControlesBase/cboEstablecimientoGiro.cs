using System;
using System.ComponentModel;
using System.Data;
using GEN.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstablecimientoGiro : ComboBox
    {
        #region Variables
        private clsCNEstablecimiento objCNListarEstablecimiento = new clsCNEstablecimiento();
        private DataTable dtTipoEstablecimientoOriginal;
        private DataTable dtTipoEstablecimiento;
        private bool lEstaFiltrando = false;
        #endregion
        #region Propiedades
        public int idEstablecimiento
        {
            get
            {
                return (this.SelectedIndex >= 0) ?
                            Convert.ToInt32(this.SelectedValue) :
                            -1;
            }
        }
        public int idAgencia
        {
            get
            {
                return (this.SelectedIndex >= 0) ?
                            Convert.ToInt32(dtTipoEstablecimiento.Rows[this.SelectedIndex]["idAgencia"]) :
                            -1;
            }
        }
        public string cAgenciaPadre
        {
            get
            {
                return (this.SelectedIndex >= 0) ?
                            dtTipoEstablecimiento.Rows[this.SelectedIndex]["cNombreAgencia"].ToString() : "";
            }
        }
        #endregion
        #region Constructor
        public cboEstablecimientoGiro()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.DropDown += cboEstablecimientoGiro_DropDown;
            this.TextUpdate += cboEstablecimientoGenerado_TextUpdate;
            this.KeyDown += cboEstablecimientoGiro_KeyDown;
        }

        public cboEstablecimientoGiro(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Cargar();
        }
        #endregion
        #region Métodos privados
        private void Cargar()
        {
            dtTipoEstablecimientoOriginal = objCNListarEstablecimiento.CNListar(); 
            dtTipoEstablecimiento = dtTipoEstablecimientoOriginal.Copy();

            DataRow row = dtTipoEstablecimiento.NewRow();
            row[dtTipoEstablecimiento.Columns[0].ColumnName] = 0;
            row[dtTipoEstablecimiento.Columns[1].ColumnName] = string.Empty;
            row["idAgencia"] = 0; 
            dtTipoEstablecimiento.Rows.InsertAt(row, 0);

            this.DataSource = dtTipoEstablecimiento;
            this.ValueMember = dtTipoEstablecimiento.Columns[0].ToString();
            this.DisplayMember = dtTipoEstablecimiento.Columns[1].ToString();
            this.SelectedIndex = -1;

            this.DropDownStyle = ComboBoxStyle.DropDown;
            //this.DropDown += cboEstablecimientoGiro_DropDown;
            this.TextUpdate += cboEstablecimientoGenerado_TextUpdate;
            this.KeyDown += cboEstablecimientoGiro_KeyDown;
        }
        public void CargarConTodosYPrincipal()
        {
            dtTipoEstablecimientoOriginal = objCNListarEstablecimiento.CNListar();
            dtTipoEstablecimiento = dtTipoEstablecimientoOriginal.Copy();

            DataRow rowTodos = dtTipoEstablecimiento.NewRow();
            rowTodos["idEstablecimiento"] = 0;
            rowTodos["cNombreEstab"] = "TODOS";
            rowTodos["idAgencia"] = 0;
            rowTodos["cNombreAgencia"] = "TODOS";
            dtTipoEstablecimiento.Rows.InsertAt(rowTodos, 0);

            DataRow row = dtTipoEstablecimiento.NewRow();
            row["idEstablecimiento"] = 1;
            row["cNombreEstab"] = "PRINCIPAL - PUNO";
            row["idAgencia"] = 1;
            row["cNombreAgencia"] = "PRINCIPAL - PUNO";
            dtTipoEstablecimiento.Rows.InsertAt(row, 1);

            
            this.DataSource = dtTipoEstablecimiento;
            this.ValueMember = dtTipoEstablecimiento.Columns[0].ToString();
            this.DisplayMember = dtTipoEstablecimiento.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedValue = 0;
        }
        #endregion
        #region Eventos
        private void cboEstablecimientoGenerado_TextUpdate(object sender, EventArgs e)
        {
            if (lEstaFiltrando || dtTipoEstablecimientoOriginal == null)
            {
                return;
            }

            lEstaFiltrando = true;
            try
            {
                string cTextoActual = this.Text;
                int nSeleccionActual = this.SelectionStart;

                if (string.IsNullOrEmpty(cTextoActual))
                {
                    dtTipoEstablecimiento = dtTipoEstablecimientoOriginal.Copy();
                }
                else
                {
                    string cExpresion = $"{this.DisplayMember} LIKE '%{cTextoActual}%'";
                    var drFilasFiltradas = dtTipoEstablecimientoOriginal.Select(cExpresion);
                    dtTipoEstablecimiento = dtTipoEstablecimientoOriginal.Clone();
                    foreach (var item in drFilasFiltradas)
                    {
                        dtTipoEstablecimiento.ImportRow(item);
                    }
                    DataRow row = dtTipoEstablecimiento.NewRow();
                    row[dtTipoEstablecimiento.Columns[0].ColumnName] = 0;
                    row[dtTipoEstablecimiento.Columns[1].ColumnName] = string.Empty;
                    row["idAgencia"] = 0; 
                    dtTipoEstablecimiento.Rows.InsertAt(row, 0);
                }
                this.DataSource = dtTipoEstablecimiento;
                this.Text = cTextoActual;
                this.SelectionStart = nSeleccionActual;
                this.DroppedDown = true;
            }
            finally
            {
                lEstaFiltrando = false;
            }
        }
        private void cboEstablecimientoGiro_DropDown(object sender, EventArgs e)
        {
            dtTipoEstablecimiento = dtTipoEstablecimientoOriginal.Copy();

            DataRow row = dtTipoEstablecimiento.NewRow();
            row[dtTipoEstablecimiento.Columns[0].ColumnName] = 0;
            row[dtTipoEstablecimiento.Columns[1].ColumnName] = string.Empty;
            row["idAgencia"] = 0;
            dtTipoEstablecimiento.Rows.InsertAt(row, 0);

            this.DataSource = dtTipoEstablecimiento;
            this.Text = string.Empty;
        }

        private void cboEstablecimientoGiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dtTipoEstablecimiento.Rows.Count > 0)
            {
                this.DroppedDown = false;
            }
        }
        #endregion
    }
}