using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboMotivos : cboBase
    {
        public cboMotivos()
        {
            InitializeComponent();
        }

        public cboMotivos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarMotivos(int idTipoMotivo){

            clsCNMotivoExtorno ListarMotivoExtorno = new clsCNMotivoExtorno();
            DataTable dt = ListarMotivoExtorno.ListaMotivioExtrono(idTipoMotivo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        
        }
    }
}
