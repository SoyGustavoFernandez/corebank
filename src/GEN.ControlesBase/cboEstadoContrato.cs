using GEN.CapaNegocio;
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
    public partial class cboEstadoContrato : cboBase
    {
        
        public cboEstadoContrato()
        {
            InitializeComponent();            
        }

        public cboEstadoContrato(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dtEstContrato = new clsCNBuscaPersonal().ListarEstadoContratoTodos(0);
            this.DataSource = dtEstContrato;
            this.ValueMember = dtEstContrato.Columns[0].ToString();
            this.DisplayMember = dtEstContrato.Columns[1].ToString();
        }
        public void verMasTodos()
        {
            DataTable dtEstContrato = new clsCNBuscaPersonal().ListarEstadoContratoTodos(1);
            this.DataSource = dtEstContrato;
            this.ValueMember = dtEstContrato.Columns[0].ToString();
            this.DisplayMember = dtEstContrato.Columns[1].ToString();            
        }
    }
}
