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
    public partial class cboPeriodoDeclaracion : cboBase
    {
        clsCNPeriodoDeclaracion objPeriodoDeclaracion = new clsCNPeriodoDeclaracion();
        public DataTable dtPeriodo;

        public cboPeriodoDeclaracion()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboPeriodoDeclaracion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListarPeriodoDeclaracionVigente();
        }

        public void ListarPeriodoDeclaracionVigente()
        {
            dtPeriodo = objPeriodoDeclaracion.CNListarPeriodosDeclaracionVigente();
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodoDeclaracion"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodoDeclaracion"].ToString();
        }

        public void ListarTodosPeriodoDeclaracion()
        {
            dtPeriodo = objPeriodoDeclaracion.CNListarPeriodosDeclaracion();
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodoDeclaracion"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodoDeclaracion"].ToString();
        }
    }
}
