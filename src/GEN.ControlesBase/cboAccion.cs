using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboAccion : cboBase
    {
        clsCNAccion cnAccion = new clsCNAccion();
        public cboAccion()
        {
            InitializeComponent();
            cargarVigentes();
        }

        public cboAccion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            cargarVigentes();
        }

        public void cargarDatosPorPerfil(int idPerfil)
        {
            DataTable dt = cnAccion.ListarAccionesPorPerfil(idPerfil);
            dt.DefaultView.RowFilter = "lVigente = 1";
            ValueMember = "idTipoAccion";
            DisplayMember = "cTipoAccion";
            DataSource = dt.DefaultView;
        }

        public void cargarTodos()
        {
            DataTable dt = cnAccion.ListarAcciones();
            ValueMember = "idTipoAccion";
            DisplayMember = "cTipoAccion";
            DataSource = dt;
        }

        public void cargarVigentes()
        {
            DataTable dt = cnAccion.ListarAcciones();
            var result = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["idEstado"]));
            if (result.Any())
            {
                dt = result.CopyToDataTable();
            }
            ValueMember = "idTipoAccion";
            DisplayMember = "cTipoAccion";
            DataSource = dt;           
        }
    }
}
