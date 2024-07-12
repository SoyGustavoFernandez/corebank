using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboMedioPagoSunat : cboBase
    {
        public cboMedioPagoSunat()
        {
            InitializeComponent();
        }

        public cboMedioPagoSunat(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNMovimientoBancario listaMedioPagoSunat = new clsCNMovimientoBancario();
            DataTable dt = listaMedioPagoSunat.ListarMedioPagoSunat();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
    }
}
