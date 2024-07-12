using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoIntervCre : cboBase
    {
        clsCNInterviniente TipoInterv = new clsCNInterviniente();
        public cboTipoIntervCre()
        {
            InitializeComponent();
        }

        public cboTipoIntervCre(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNInterviniente TipoInterv = new clsCNInterviniente();
            DataTable dtTipoInterv = TipoInterv.CNListaTipoInterv();
            this.DataSource = dtTipoInterv;
            this.ValueMember = dtTipoInterv.Columns["idtipointerv"].ToString();
            this.DisplayMember = dtTipoInterv.Columns["CTIPOINTERVENCION"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void listarTipoIntervRegCredito()
        {
            DataTable dtTipoInterv = TipoInterv.listarTipoIntervRegCredito();
            this.DataSource = dtTipoInterv;
            this.ValueMember = dtTipoInterv.Columns["idTipoInterv"].ToString();
            this.DisplayMember = dtTipoInterv.Columns["cTipoIntervencion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
