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
    public partial class cboTipoTasaCredito : cboBase
    {
        clsCNTipoTasaCredito cnTipoCredito = new clsCNTipoTasaCredito();
        DataTable dtTipoTasaCredito;
        public cboTipoTasaCredito()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;            
        }

        public cboTipoTasaCredito(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void cargarDatos(int idModulo)
        {
            dtTipoTasaCredito = cnTipoCredito.listarTipoTasaCredito(idModulo);
            this.DataSource = dtTipoTasaCredito;
            this.ValueMember = dtTipoTasaCredito.Columns[0].ToString();
            this.DisplayMember = dtTipoTasaCredito.Columns[1].ToString();            
        }
    }
}
