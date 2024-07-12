using CRE.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstadoSeguroMultiriesgo : cboBase
    {
        public DataTable dtEstadoSeguroMultiriesgo;

        public cboEstadoSeguroMultiriesgo()
        {
            InitializeComponent();
        }

        public cboEstadoSeguroMultiriesgo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            DataTable dt = (new clsCNCreditoCargaSeguro().CNListarEstadoSeguroMultiriesgo());
            DataSource = dt;
            ValueMember = dt.Columns["idEstado"].ToString();
            DisplayMember = dt.Columns["cDescripcion"].ToString();
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void AgregarTodos()
        {
            base.AgregarItemTodos = true;
        }
    }
}
