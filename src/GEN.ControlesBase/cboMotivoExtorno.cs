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
    public partial class cboMotivoExtorno : cboBase
    {
        public cboMotivoExtorno()
        {
            InitializeComponent();
        }

        public cboMotivoExtorno(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNMotivoExtorno ListarMotivoExtorno = new clsCNMotivoExtorno();
            DataTable dt = ListarMotivoExtorno.ListaMotivioExtrono(1);
            this.DataSource = dt;
            this.ValueMember= dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void cargarDatosOperacion(int idTipoOperacion)
        {
            clsCNMotivoExtorno ListarMotivoExtorno = new clsCNMotivoExtorno();
            DataTable dt = ListarMotivoExtorno.CNListaMotivoExtornoOperacion(1, idTipoOperacion);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

    }
}
