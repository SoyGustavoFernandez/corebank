using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboClasificacionInterna : cboBase
    {
        clsCNCalifInt oClasInt = new clsCNCalifInt();
        public cboClasificacionInterna()
        {
            InitializeComponent();
        }

        public cboClasificacionInterna(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            cargarClasificacionInterna();
        }

        public void cargarClasificacionInterna()
        {
            DataTable dt = oClasInt.CNGetClasifInt();
            this.ValueMember = "idClasifInterna";
            this.DisplayMember = "cClasifInterna";
            this.DataSource = dt;
        }
    }
}
