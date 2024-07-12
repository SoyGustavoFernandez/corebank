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
    public partial class cboSubTipoCorrespondencia : cboBase
    {
        public cboSubTipoCorrespondencia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboSubTipoCorrespondencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarSubTipoCorrespondencia(int idTipoCorrespondencia)
        {

            clsCNCondonacion cnSubTipoCorrespondencia = new clsCNCondonacion();
            DataTable dt = cnSubTipoCorrespondencia.listaSubTipoCorrespondencia(idTipoCorrespondencia);

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idSubTipoCorrespondencia"].ToString();
            this.DisplayMember = dt.Columns["cSubTipoCorrespondencia"].ToString();
        }
    }
}
