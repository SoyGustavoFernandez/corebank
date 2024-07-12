using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEmpresasConvenio : cboBase
    {
        public cboEmpresasConvenio()
        {
            InitializeComponent();
        }

        public cboEmpresasConvenio(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarEmpresasConv();
        }

        public void cargarEmpresasConv()
        {
            clsCNEmpresasConvenio objEmp = new clsCNEmpresasConvenio();
            DataTable dt = objEmp.CNObtenerListaEmpresas();

            this.DisplayMember = dt.Columns[1].ToString();
            this.ValueMember = dt.Columns[0].ToString();
            this.DataSource = dt;

            this.AutoCompleteCustomSource = AutoCompletar(dt);
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        }

        public static AutoCompleteStringCollection AutoCompletar(DataTable dt)
        {
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row[dt.Columns[1].ToString()]));
            }

            return coleccion;
        }
    }
}
