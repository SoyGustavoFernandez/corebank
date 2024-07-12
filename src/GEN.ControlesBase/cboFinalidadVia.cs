using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboFinalidadVia : cboBase
    {
        public cboFinalidadVia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboFinalidadVia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarMotBloq();
        }

        public void CargarMotBloq()
        {
            DataTable dtTarj = new clsCNControlViaticos().CNListadoFinalidadViatico();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns["idFinalidad"].ToString();
            this.DisplayMember = dtTarj.Columns["cDescripcion"].ToString();
        }

    }
}
