using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboGrupoOficina : cboBase
    {
        clsCNCategoriaOficina cnCategoriaOficina = new clsCNCategoriaOficina();
        public cboGrupoOficina()
        {
            InitializeComponent();
        }

        public cboGrupoOficina(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void cargarDatos(bool lSoloVigentes, int idPeriodoCateOfi)
        {
            DataTable dtGrupoOficina = cnCategoriaOficina.ListarGrupoOficina(lSoloVigentes, idPeriodoCateOfi);
            this.ValueMember = "idGrupoOfi";
            this.DisplayMember = "cDescripcion";
            this.DataSource = dtGrupoOficina;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

    }
}
