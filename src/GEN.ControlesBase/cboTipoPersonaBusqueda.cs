using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoPersonaBusqueda : ComboBox
    {
        #region Variables
        clsCNTipoDocumento objCNTipoDocumento = new clsCNTipoDocumento();
        DataTable dt;
        #endregion
        #region Constructor
        public cboTipoPersonaBusqueda()
        {
            InitializeComponent();
        }        
        public cboTipoPersonaBusqueda(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            dt = objCNTipoDocumento.CNListarTipoPersonaBusqueda();

            Cargar();
        }
        #endregion
        #region Métodos
        public void CargarParaFiltro()
        {
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public void Cargar()
        {            
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[2].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion
    }
}
