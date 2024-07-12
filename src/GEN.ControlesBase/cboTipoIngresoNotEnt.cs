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
    public partial class cboTipoIngresoNotEnt : cboBase
    {
        public cboTipoIngresoNotEnt()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoIngresoNotEnt(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            var dtAlmacen = new clsCNNotaEntrada().ListarTipoIngresoNotaEntrada();
            this.DataSource = dtAlmacen;
            this.ValueMember = dtAlmacen.Columns[0].ToString();
            this.DisplayMember = dtAlmacen.Columns[1].ToString();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
