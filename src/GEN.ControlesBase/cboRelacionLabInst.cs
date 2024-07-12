using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CLI.CapaNegocio;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboRelacionLabInst : cboBase
    {
        public cboRelacionLabInst()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboRelacionLabInst(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListarTipoRelacionLaboral();
            //clsCNListarRelacionLaboral ListaRelacion = new clsCNListarRelacionLaboral();
            //DataTable dt = ListaRelacion.ListarRelLaboral();
            //this.DataSource = dt;
            //this.ValueMember = dt.Columns[0].ToString();
            //this.DisplayMember = dt.Columns[1].ToString();
        }

        clsCNTipoRelacionLaboral objTipoRelacionLaboral = new clsCNTipoRelacionLaboral();

        public void ListarTipoRelacionLaboral()
        {
            DataTable dtTipoRelacionLaboral = objTipoRelacionLaboral.CNListarTipoRelacionLaboral();
            this.DataSource = dtTipoRelacionLaboral;
            this.ValueMember = dtTipoRelacionLaboral.Columns["idTipoRelLab"].ToString();
            this.DisplayMember = dtTipoRelacionLaboral.Columns["cTipoRelLab"].ToString();
        }

        public void ListarTipoRelacionLaboralPlanillas()
        {
            DataTable dtTipoRelacionLaboralPlanillas = objTipoRelacionLaboral.CNListarTipoRelacionLaboralPlanillas();
            this.DataSource = dtTipoRelacionLaboralPlanillas;
            this.ValueMember = dtTipoRelacionLaboralPlanillas.Columns["idTipoRelLab"].ToString();
            this.DisplayMember = dtTipoRelacionLaboralPlanillas.Columns["cTipoRelLab"].ToString();
        }
    }
}
