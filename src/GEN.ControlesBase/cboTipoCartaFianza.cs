using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoCartaFianza : cboBase
    {
        public cboTipoCartaFianza()
        {
            InitializeComponent();
        }

        public cboTipoCartaFianza(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
            CargarTipoCartaFianza();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarTipoCartaFianza()
        {
            clsCNTipoCartaFianza cnTipoCartaFianza = new clsCNTipoCartaFianza();
            DataTable dt = cnTipoCartaFianza.listarTipoCartaFianza();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoCartaFianza"].ToString();
            this.DisplayMember = dt.Columns["cTipoCartaFianza"].ToString();
        }
    }
}
