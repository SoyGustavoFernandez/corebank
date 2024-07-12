using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboCategoriaAsesor : cboBase
    {
        clsCNMeta cnMeta = new clsCNMeta();

        public cboCategoriaAsesor()
        {
            InitializeComponent();
        }

        public cboCategoriaAsesor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos();
        }
        public void cargarDatos()
        {
            DataTable dtCategoriaAsesor = cnMeta.CNListarCategoriaAsesor();
            this.ValueMember = "idCategoriaAsesor";
            this.DisplayMember = "cCategoriaAsesor";
            this.DataSource = dtCategoriaAsesor;
            
        }
    }
}
