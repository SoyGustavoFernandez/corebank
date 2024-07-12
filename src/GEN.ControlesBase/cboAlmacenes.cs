using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboAlmacenes : cboBase
    {
        public cboAlmacenes()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboAlmacenes(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            var dtAlmacen = new clsCNAlmacen().ListarAlmacenes();
            this.DataSource = dtAlmacen;
            this.ValueMember = dtAlmacen.Columns[0].ToString();
            this.DisplayMember = dtAlmacen.Columns[1].ToString();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public void CargarAlmacenOfi(int idAgencia)
        {

            DataTable dtAlmacenxAgencia = new clsCNAlmacen().CNListaAlmacenesxAgencia(idAgencia);
            this.DataSource = dtAlmacenxAgencia;
            this.ValueMember = dtAlmacenxAgencia.Columns[0].ToString();
            this.DisplayMember = dtAlmacenxAgencia.Columns[1].ToString();
        }
    }
}
