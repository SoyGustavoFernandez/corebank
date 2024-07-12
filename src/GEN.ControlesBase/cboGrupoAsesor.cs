using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboGrupoAsesor : cboBase
    {
        clsCNMeta cnMeta = new clsCNMeta();

        public cboGrupoAsesor()
        {
            InitializeComponent();
        }

        public cboGrupoAsesor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos(Convert.ToBoolean(0)); //solo Vigentes
        }

        public void cargarDatos(Boolean lTodos)
        {
            DataTable dtResultado = cnMeta.CNListaGrupoAsesor(lTodos);
            this.ValueMember = dtResultado.Columns[0].ToString();
            this.DisplayMember = dtResultado.Columns[1].ToString();
            this.DataSource = dtResultado;
        }
    }
}
