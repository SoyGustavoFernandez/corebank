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
    public partial class cboUbigeo : cboBase
    {
        public cboUbigeo()
        {
            InitializeComponent();
        }

        public cboUbigeo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void CargarUbigeo(Int32 nIdNodo)
        {
            clsCNUbigeo ListadoUbigeo = new clsCNUbigeo();
            DataTable dt = ListadoUbigeo.listarUbigeo(nIdNodo);
            DataSource = dt;
            ValueMember = "idUbigeo";
            DisplayMember = "cDescipcion";

        }
        
    }
}
