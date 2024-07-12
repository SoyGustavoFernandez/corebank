using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using DEP.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboPeriodoCTS : cboBase
    {
        public cboPeriodoCTS()
        {
            InitializeComponent();
        }

        public cboPeriodoCTS(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void cargarPeriodoCTS(DateTime dtFechaOpe)
        {
            clsCNDeposito ListaPeriodoCTS = new clsCNDeposito();
            DataTable tbPeriodoCTS = ListaPeriodoCTS.CNListaPeriodoCTS(dtFechaOpe);
            this.DataSource = tbPeriodoCTS;
            this.ValueMember = tbPeriodoCTS.Columns[0].ToString();
            this.DisplayMember = tbPeriodoCTS.Columns[1].ToString();
            
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
