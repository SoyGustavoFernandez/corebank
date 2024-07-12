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
    public partial class cboModalidadPlanilla : cboBase
    {
        clsCNModalidadPlanilla objModalidadPlanilla = new clsCNModalidadPlanilla();

        public cboModalidadPlanilla()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboModalidadPlanilla(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListarModalidadPlanilla();
        }

        public void ListarModalidadPlanilla()
        {
            DataTable dtModalidadPlanilla = objModalidadPlanilla.CNListarModalidadPlanilla();
            this.DataSource = dtModalidadPlanilla;
            this.ValueMember = dtModalidadPlanilla.Columns["idModalidad"].ToString();
            this.DisplayMember = dtModalidadPlanilla.Columns["cModalidad"].ToString();
        }

        public void ListarModalidadTipoPlanilla(int idTipoPlanilla)
        {
            DataTable dtModalidadPlanilla = objModalidadPlanilla.CNListarModalidadTipoPlanilla(idTipoPlanilla);
            this.DataSource = dtModalidadPlanilla;
            this.ValueMember = dtModalidadPlanilla.Columns["idModalidad"].ToString();
            this.DisplayMember = dtModalidadPlanilla.Columns["cModalidad"].ToString();
        }

        public void ListarModalidadDctoAdelantoTipoPlanilla(int idTipoPlanilla)
        {
            DataTable dtModalidadPlanilla = objModalidadPlanilla.CNListarModalidadDctoAdelantoTipoPlanilla(idTipoPlanilla);
            this.DataSource = dtModalidadPlanilla;
            this.ValueMember = dtModalidadPlanilla.Columns["idModalidad"].ToString();
            this.DisplayMember = dtModalidadPlanilla.Columns["cModalidad"].ToString();
        }
    }
}