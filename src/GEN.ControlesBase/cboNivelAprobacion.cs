using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;


namespace GEN.ControlesBase
{
    public partial class cboNivelAprobacion : cboBase
    {
        public cboNivelAprobacion()
        {
            InitializeComponent();
        }

        public cboNivelAprobacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
            CargarTodo();
        }

        public void CargarNivelesCanal(int idCanalAproCred)
        {
            clsCNNivelAprobacion cnnivelAprobacion = new clsCNNivelAprobacion();
            List<clsNivelAprobacion> lstNivelAprobacion = cnnivelAprobacion.listarNivelAprobacion(idCanalAproCred);

            this.DataSource = lstNivelAprobacion;
            this.ValueMember = "idNivelAprobacion";
            this.DisplayMember = "cNivelAprobacion";
        }

        public void CargarTodo()
        {
            clsCNNivelAprobacion cnnivelAprobacion = new clsCNNivelAprobacion();
            DataTable dtNivelAprobacion = cnnivelAprobacion.ListaTodoNivelAprobacion();

            this.DataSource = dtNivelAprobacion;
            this.ValueMember = dtNivelAprobacion.Columns["idNivelAprobacion"].ToString();
            this.DisplayMember = dtNivelAprobacion.Columns["cNivelAprobacion"].ToString();
        }

        public void CargarTodoDescripcionCompleta()
        {
            clsCNNivelAprobacion cnnivelAprobacion = new clsCNNivelAprobacion();
            DataTable dtNivelAprobacion = cnnivelAprobacion.ListaTodoNivelAprobacion();

            this.DataSource = dtNivelAprobacion;
            this.ValueMember = dtNivelAprobacion.Columns["idNivelAprobacion"].ToString();
            this.DisplayMember = dtNivelAprobacion.Columns["cDescripcionCompleta"].ToString();
        }
    }
}
