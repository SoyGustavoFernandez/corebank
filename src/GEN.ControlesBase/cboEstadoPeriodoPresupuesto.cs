using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Windows.Forms;
using System.Drawing;
//using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstadoPeriodoPresupuesto : cboBase
    {
        private int ultimoId = 0;
        public cboEstadoPeriodoPresupuesto()
        {
            InitializeComponent();
        }
        public cboEstadoPeriodoPresupuesto(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarTodosPeriodos();
        }
        

        public void CargarTodosPeriodos()
        {
            DataTable dtTarj = new clsCNEstadosPeriodoPres().CNListarTodosEstados();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();
            
            DataRow fila = dtTarj.Rows[dtTarj.Rows.Count - 1];
            ultimoId = Convert.ToInt32(fila[0].ToString());
        }

        public void CargarUnEstado(int idEstado)
        {
            DataTable dtTarj = new clsCNEstadosPeriodoPres().CNListarUnEstado(idEstado);
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();

            ultimoId = idEstado;
        }

        public int DevuelveUltimoIDEstado()
        {
            return ultimoId;
        }
        

    }
}
