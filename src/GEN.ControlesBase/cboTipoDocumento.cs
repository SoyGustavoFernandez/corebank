using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoDocumento : ComboBox
    {
        #region Variables
        private DataTable dtFuente;
        #endregion
        #region Propiedades
        public int nTamanoMinimo { 
            get 
            {
                try
                {
                    return Convert.ToInt32(dtFuente.Rows[this.SelectedIndex]["nTamMinimo"]);
                }
                catch { return 0; }
            } 
        }
        public int idTipoPersonaBusqueda
        {
            get
            {
                try
                {
                    return Convert.ToInt32(dtFuente.Rows[this.SelectedIndex]["idTipoPersonaBusqueda"]);
                }
                catch { return 0; }
            }
        }
        public int nTamanoMaximo
        {
            get
            {
                try
                {
                    return Convert.ToInt32(dtFuente.Rows[this.SelectedIndex]["nTamMaximo"]);
                }
                catch { return 0; }
            }
        }
        public bool lAlfanumerico
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(dtFuente.Rows[this.SelectedIndex]["lAlfanumerico"]);
                }
                catch { return false; }
            }
        }
        #endregion
        #region Constructor
        public cboTipoDocumento()
        {
            InitializeComponent();
        }        
        public cboTipoDocumento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.listarTipoDocumento();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }
        #endregion
        #region Métodos públicos
        public void cargarTipDocEspecificos(string cCodTipDoc)
        {
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.listarTipDocEsp(cCodTipDoc);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarParaFiltro(int idPersonaTipoBusqueda = 0)
        {
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            DataTable dt = ListadoTipoDocumento.CNListarTipoDocumentosXDocumentoBusqueda(idPersonaTipoBusqueda);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public void cargarParaFiltroNumerado(bool lConsiderarRUC = false)
        {
            
            clsCNTipoDocumento ListadoTipoDocumento = new clsCNTipoDocumento();
            dtFuente = ListadoTipoDocumento.CNListarTipoDocumentosNumerados(lConsiderarRUC);
            this.DataSource = dtFuente;
            this.ValueMember = dtFuente.Columns[0].ToString();
            this.DisplayMember = dtFuente.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.MaxLength = 2;
            this.SelectedValue = 1;
        }
        #endregion
    }
}
