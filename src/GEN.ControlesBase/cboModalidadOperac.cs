using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboModalidadOperac : cboBase
    {
        public DataTable dtModalidadOperac;
        
        public cboModalidadOperac()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboModalidadOperac(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtModalidadOperac = new clsCNGenAdmOpe().LisModalidadOperac();
            this.DataSource = dtModalidadOperac;
            this.ValueMember = dtModalidadOperac.Columns["idEstadoKardex"].ToString();
            this.DisplayMember = dtModalidadOperac.Columns["cEstadoKardex"].ToString();
        }
    }
}
