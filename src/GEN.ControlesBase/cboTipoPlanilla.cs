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
    public partial class cboTipoPlanilla : cboBase
    {
        clsCNTipoPlanilla objTipoPlanilla = new clsCNTipoPlanilla();

        public cboTipoPlanilla()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoPlanilla(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarTipoPlanillaRelacionLab(int idTipoRelLab)
        {
            DataTable dtTipoPlanilla = objTipoPlanilla.CNListarTipoPlanillaRelacionLab(idTipoRelLab);
            this.DataSource = dtTipoPlanilla;
            this.ValueMember = dtTipoPlanilla.Columns["idTipoPlanilla"].ToString();
            this.DisplayMember = dtTipoPlanilla.Columns["cTipoPlanilla"].ToString();
        }

        public void ListarTipoPlanillaProvisionRelacionLab(int idTipoRelLab)
        {
            DataTable dtTipoPlanilla = objTipoPlanilla.CNListarTipoPlanillaProvisionRelacionLab(idTipoRelLab);
            this.DataSource = dtTipoPlanilla;
            this.ValueMember = dtTipoPlanilla.Columns["idTipoPlanilla"].ToString();
            this.DisplayMember = dtTipoPlanilla.Columns["cTipoPlanilla"].ToString();
        }

        public void ListarTipoPlanillaAdelantoRelacionLab(int idTipoRelLab)
        {
            DataTable dtTipoPlanilla = objTipoPlanilla.CNListarTipoPlanillaAdelantoRelacionLab(idTipoRelLab);
            this.DataSource = dtTipoPlanilla;
            this.ValueMember = dtTipoPlanilla.Columns["idTipoPlanilla"].ToString();
            this.DisplayMember = dtTipoPlanilla.Columns["cTipoPlanilla"].ToString();
        }
    }
}