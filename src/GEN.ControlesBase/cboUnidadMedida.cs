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
    public partial class cboUnidadMedida : cboBase
    {
        public cboUnidadMedida()
        {
            InitializeComponent();
        }

        public cboUnidadMedida(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarUnidaMedida();
        }
        public void CargarUnidaMedida()
        {
            clsCNAdquisionesLogistica UndMed = new clsCNAdquisionesLogistica();

            DataTable dt = UndMed.listaUnidaMedida();
            DataSource = dt;
            ValueMember = dt.Columns[0].ToString();
            DisplayMember = dt.Columns[1].ToString();
        }
    }
}
