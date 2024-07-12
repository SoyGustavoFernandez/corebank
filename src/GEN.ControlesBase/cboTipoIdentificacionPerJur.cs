using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;


namespace GEN.ControlesBase
{
    public partial class cboTipoIdentificacionPerJur  : cboBase
    {
        public cboTipoIdentificacionPerJur()
        {
            InitializeComponent();
        }

        public cboTipoIdentificacionPerJur(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoIdentificacionPerJur objTipoIdentificacionPerJur = new clsCNTipoIdentificacionPerJur();
            DataTable dtTipoIdentificacionPerJur = objTipoIdentificacionPerJur.CNListaTipoIdentificacionPerJur();
            this.DataSource = dtTipoIdentificacionPerJur;
            this.ValueMember = dtTipoIdentificacionPerJur.Columns["idIdentificacion"].ToString();
            this.DisplayMember = dtTipoIdentificacionPerJur.Columns["cTipoIdentificacion"].ToString();
        }
    }
}
