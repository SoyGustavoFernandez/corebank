using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboRangoAtraso : cboBase
    {
        public cboRangoAtraso()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboRangoAtraso(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtRangoAtr = new clsCNRangoAtraso().CNRangoAtraso();
            this.DataSource = dtRangoAtr;
            this.ValueMember = dtRangoAtr.Columns["idRangoAtraso"].ToString();
            this.DisplayMember = dtRangoAtr.Columns["cRangoAtraso"].ToString();
        }
    }
}
