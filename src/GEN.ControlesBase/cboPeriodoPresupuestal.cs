using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPeriodoPresupuestal : cboBase
    {
        DataTable dtTarj;
        public cboPeriodoPresupuestal()
        {
            
            InitializeComponent();
        }
        public cboPeriodoPresupuestal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarTodosPeriodos();
        }
        public void CargarTodosPeriodos()
        {
            dtTarj = new clsCNPeriodosPresupuesto().CNListarTodosPeriodos();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString(); 
        }
        public String devolverValor(int idFila, String cColumna)
        {
            if (idFila != -1)
                return dtTarj.Rows[idFila][cColumna].ToString();
            else
                return "";
        }
        
    }
}
