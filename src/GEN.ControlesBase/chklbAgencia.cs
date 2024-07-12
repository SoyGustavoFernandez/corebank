using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class chklbAgencia : chklbBase
    {
        DataTable dtAgencia = new DataTable();
        public chklbAgencia()
        {
            InitializeComponent();
        }

        public chklbAgencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarAgencias();
        }

        public void cargarAgencias()
        {
            dtAgencia = new clsCNAgencia().LisSoloAgencias();
            this.DataSource = dtAgencia;
            this.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            this.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
        }
    }
}
