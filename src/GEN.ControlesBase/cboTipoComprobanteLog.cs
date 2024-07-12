using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using System.Data;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoComprobanteLog : cboBase
    {
        public cboTipoComprobanteLog()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoComprobanteLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarTipoComporbantes()
        {
            DataTable dtComprobantes = new clcCNTipoComprobantes().CNListarTipoComprobantes();
            this.DataSource = dtComprobantes;
            this.ValueMember = dtComprobantes.Columns[0].ToString();
            this.DisplayMember = dtComprobantes.Columns[1].ToString();
        }
    }
}
