using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RCP.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoAfectaciones : cboBase
    {
        public cboTipoAfectaciones()
        {
            InitializeComponent();
        }

        public cboTipoAfectaciones(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            clsCNTipoAfectaciones afectaciones = new clsCNTipoAfectaciones();
            DataTable dt = afectaciones.ListarAfectaciones();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoAfectacion"].ToString();
            this.DisplayMember = dt.Columns["cTipoAfectacion"].ToString(); 
        }
    }
}
