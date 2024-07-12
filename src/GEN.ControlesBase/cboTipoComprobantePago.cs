using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboTipoComprobantePago : cboBase
    {
        public cboTipoComprobantePago()
        {
            InitializeComponent();
           
        }

        public cboTipoComprobantePago(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            llenarDatosComprobante(0);
        }
        public void llenarDatosComprobante(int nOpcion)
        {
            clsCNCajaChica listaTipoCompPago = new clsCNCajaChica();
            DataTable dt = listaTipoCompPago.ListarTipoComprPago(nOpcion);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
