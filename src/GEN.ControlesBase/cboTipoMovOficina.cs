using ADM.CapaNegocio;
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
    public partial class cboTipoMovOficina : cboBase
    {
        clsCNMantenimiento objMttoAgencia = new clsCNMantenimiento();
        public cboTipoMovOficina()
        {
            InitializeComponent();
        }

        public cboTipoMovOficina(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarTipoMovimiento(int idAgencia)
        {
            DataTable dt = objMttoAgencia.ListarTiposMovimiento(idAgencia);
            this.ValueMember = dt.Columns["idTipoMovimiento"].ToString();
            this.DisplayMember = dt.Columns["cTipoMovimiento"].ToString();
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
