using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPeriodoPlanilla : cboBase
    {
        clsCNPeriodoPlanilla objPeriodoPlanilla = new clsCNPeriodoPlanilla();
        public DataTable dtPeriodo;

        public cboPeriodoPlanilla()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboPeriodoPlanilla(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarPeriodoVigenteTipoPlanilla(int idTipoPlanilla)
        {
            dtPeriodo = objPeriodoPlanilla.CNListarPeriodoVigenteTipoPlanilla(idTipoPlanilla);
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();
        }

        public void ListarTodosPeriodoTipoPlanilla(int idTipoPlanilla)
        {
            dtPeriodo = objPeriodoPlanilla.CNListarTodosPeriodoTipoPlanilla(idTipoPlanilla);
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();
        }
    }
}
