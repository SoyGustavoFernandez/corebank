using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboEstadoAutUsoDatos : cboBase
    {
        private clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();

        public cboEstadoAutUsoDatos()
        {
            InitializeComponent();
        }

        public cboEstadoAutUsoDatos(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargaDato();
        }
        public async void cargaDato()
        {
            DataTable dtTipo = cnobjTipo.CNEstadoAutUsoDatos();
            this.DataSource = dtTipo;
            this.DisplayMember = dtTipo.Columns["cEstado"].ToString();
            this.ValueMember = dtTipo.Columns["idEstado"].ToString();
        }
        public void filtrarEstadoTodos()
        {
            DataTable dtEstado = cnobjTipo.CNEstadoAutUsoDatos();
            this.DataSource = dtEstado;

            DataRow row = dtEstado.NewRow();
            row["idEstado"] = 0;
            row["cEstado"] = "TODOS";
            dtEstado.Rows.Add(row);
             
            this.DataSource = dtEstado;
            this.ValueMember = dtEstado.Columns[0].ToString();
            this.DisplayMember = dtEstado.Columns[1].ToString();
            this.ValueMember = dtEstado.Columns["idEstado"].ToString();
            this.DisplayMember = dtEstado.Columns["cEstado"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
