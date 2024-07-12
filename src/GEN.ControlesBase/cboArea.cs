using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboArea : cboBase
    {
        public cboArea()
        {
            InitializeComponent();
        }

        public cboArea(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarArea(int idAgencia) {
                        
            DataTable dtTarj = new clsCNArea().CNListadoArea(idAgencia);
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();        
        }

        public void CargarTodasArea()
        {

            DataTable dtTarj = new clsCNArea().CNListarTodasAreas();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();
        }

        public void CargarTodosporArea(int idAgencia)
        {
            DataTable dtTarj = new clsCNArea().CNListadoTodosPorArea(idAgencia);
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();
        }

    }
}
