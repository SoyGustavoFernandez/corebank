using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoOperacionRiesgos : cboBase
    {
        public cboTipoOperacionRiesgos()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoOperacionRiesgos(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargarTipoOperacion();
        }
        public void CargarTipoOperacion()
        {
            DataTable dtTipoOperacion = new clsCNVisita().CNListaTipoOperacion();
            this.DataSource = dtTipoOperacion;
            this.ValueMember = dtTipoOperacion.Columns[0].ToString();
            this.DisplayMember = dtTipoOperacion.Columns[1].ToString();
        }
    }
}
