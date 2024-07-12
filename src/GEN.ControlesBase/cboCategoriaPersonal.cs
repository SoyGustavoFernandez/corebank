using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboCategoriaPersonal : cboBase
    {
        clsCNMantCargos cncategoria = new clsCNMantCargos();

        public cboCategoriaPersonal()
        {
            InitializeComponent();
        }

        public cboCategoriaPersonal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            
        }
        public void cargarCategoria(int idCargoPersonal, Boolean lbol = false) 
        {
            DataTable dtCargoPersonal = cncategoria.CNListarCategoriaPersonalidCargo(idCargoPersonal);
            this.DataSource = dtCargoPersonal;
            this.ValueMember = "idCategoria";
            this.DisplayMember = "cCategoria";

            if (lbol)
            {
                this.AutoCompleteCustomSource = AutoCompletar(dtCargoPersonal);
                this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            }
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
