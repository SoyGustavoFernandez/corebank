using SPL.CapaNegocio;
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
    public partial class cboTipoMapeoSPLAFT : cboBase
    {
        clsCNMapeoRiesgoYOpeInusual cnMantenimientoMapeo = new clsCNMapeoRiesgoYOpeInusual();
        public cboTipoMapeoSPLAFT()
        {
            InitializeComponent();
        }

        public cboTipoMapeoSPLAFT(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarTodosVigentes();
        }
        public void cargarTodosVigentes()
        {
            DataTable dt = cnMantenimientoMapeo.listaTiposMapeoTodos();
            dt.DefaultView.RowFilter = "lVigente = 1";
            ValueMember = "IdTipoMapeo";
            DisplayMember = "cTipoMapeo";
            DataSource = dt.DefaultView;
        }
    }
}
