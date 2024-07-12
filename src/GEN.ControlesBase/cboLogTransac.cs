using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
using CNE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboLogTransac : cboBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();

        public cboLogTransac()
        {
            InitializeComponent();
        }

        public cboLogTransac(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void cboLogTransacUser(int idModulo)
        {
            InitializeComponent();

            DataTable dtTipoTransac = cnRptPdp.cnTipoTransac(idModulo);
            this.DataSource = dtTipoTransac;
            this.ValueMember = dtTipoTransac.Columns["cTpOpe"].ToString();
            this.DisplayMember = dtTipoTransac.Columns["cTpOpeCorto"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarVigentes(int idModulo)
        {
            DataTable dt = cnRptPdp.cnTipoTransac(idModulo);

            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }

            ValueMember = "cTpOpe";
            DisplayMember = "cTpOpeCorto";
            DataSource = dt;
        }

        public void cargarVigentesTodos(int idModulo)
        {
            DataTable dt = cnRptPdp.cnTipoTransac(idModulo);

            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }

            DataRow dr = dt.NewRow();

            dr["cTpOpe"] = "TODOS";
            dr["cTpOpeCorto"] = "TODOS";

            dt.Rows.InsertAt(dr, 0);

            ValueMember = "cTpOpe";
            DisplayMember = "cTpOpeCorto";
            DataSource = dt;
        }
    }
}
