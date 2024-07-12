using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CRE.CapaNegocio;
using System.Data;
using EntityLayer;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboDestinoCredito : cboBase
    {
        public bool lTasa = false;

        private readonly ToolTip _toolTip;
        public string _cNombreObjeto = String.Empty;
        public bool lMostrarToolTip { get; set; }
        public cboDestinoCredito()
        {
            InitializeComponent();
            _toolTip = new ToolTip();
        }

        public cboDestinoCredito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _toolTip = new ToolTip();
            lMostrarToolTip = false;

            clsCNDestinoCredito ListaDestino = new clsCNDestinoCredito();            
            DataTable dt = ListaDestino.ListaDestino();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public string cNombreObjecto
        {
            get
            {
                return _cNombreObjeto;
            }
            set
            {
                _cNombreObjeto = value;
                if (lMostrarToolTip)
                {
                    _toolTip.SetToolTip(this, value);
                }
            }
        }

        public void cargar()
        {
            clsCNDestinoCredito ListaDestino = new clsCNDestinoCredito();
            ListaDestino.lTasa = lTasa;
            DataTable dt = ListaDestino.ListaDestino();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void cargarEspeciales()
        {
            clsCNDestinoCredito ListaDestino = new clsCNDestinoCredito();
            DataTable dt = ListaDestino.ListaDestinoEspeciales();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void cargarEspecificos(int idProducto)
        {
            clsCNDestinoCredito ListaDestino = new clsCNDestinoCredito();
            DataTable dt = ListaDestino.listaDestinoCredito(idProducto);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void filtrarGrupoSolidario()
        {
            clsCNDestinoCredito ListaDestino = new clsCNDestinoCredito();
            DataTable dt = ListaDestino.ListaDestino();

            DataView vista = new DataView(dt);
            vista.RowFilter = "idDestino IN (" + clsVarApl.dicVarGen["cDestinosGrupoSolidario"].ToString() + ")";
            DataTable dt2 = vista.ToTable();

            this.DataSource = dt2;
            this.ValueMember = dt2.Columns[0].ToString();
            this.DisplayMember = dt2.Columns[1].ToString();
        }
        private void cboDestinoCredito_MouseHover(object sender, EventArgs e)
        {
            if (lMostrarToolTip && this.SelectedItem != null)
            {
                DataRowView selectedRow = this.SelectedItem as DataRowView;
                string selectedValue = selectedRow[this.DisplayMember].ToString();
                cNombreObjecto = selectedValue;
            }
        }
    }
}
