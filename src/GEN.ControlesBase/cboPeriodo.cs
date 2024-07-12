using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboPeriodo : cboBase
    {
        public cboPeriodo()
        {
            InitializeComponent();
        }

        public cboPeriodo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dtPeriodo = new DataTable();
            dtPeriodo.Columns.Add("cPeriodo");
            dtPeriodo.Columns.Add("idPeriodo");
            DataRow row = dtPeriodo.NewRow();
            row["idPeriodo"] = "000000";
            row["cPeriodo"] = "TODOS";
            dtPeriodo.Rows.Add(row);
            for (int i = 1; i <= 12; i++)
            {
                row = dtPeriodo.NewRow();
                row["idPeriodo"] = i.ToString("00") + clsVarGlobal.dFecSystem.ToString("yyyy");
                row["cPeriodo"] = i.ToString("00") + " - " + clsVarGlobal.dFecSystem.ToString("yyyy");
                dtPeriodo.Rows.Add(row);
            }
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedValue = "000000";
        }
        public void cargarPeriodoDesdeFecha()
        {
            DataTable dtPeriodo = new DataTable();
            dtPeriodo.Columns.Add("cPeriodo");
            dtPeriodo.Columns.Add("idPeriodo");
            DataRow row = dtPeriodo.NewRow();
            row["idPeriodo"] = "000000";
            row["cPeriodo"] = "TODOS";
            dtPeriodo.Rows.Add(row);
            int nMes = clsVarGlobal.dFecSystem.Month;
            if (Convert.ToInt32(clsVarApl.dicVarGen["nDiasLimiteModificarMetas"]) <= clsVarGlobal.dFecSystem.Day)
            {
                nMes++;
            }
            for (int i = nMes; i <= 12; i++)
            {
                row = dtPeriodo.NewRow();
                row["idPeriodo"] = i.ToString("00") + clsVarGlobal.dFecSystem.ToString("yyyy");
                row["cPeriodo"] = i.ToString("00") + " - " + clsVarGlobal.dFecSystem.ToString("yyyy");
                dtPeriodo.Rows.Add(row);
            }
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedValue = "000000";
        }
        public void cargarPeriodoSinTodos()
        {
            DataTable dtPeriodo = new DataTable();
            dtPeriodo.Columns.Add("cPeriodo");
            dtPeriodo.Columns.Add("idPeriodo");            
            DataRow row = dtPeriodo.NewRow();
            for (int i = 1; i <= 12; i++)
            {
                row = dtPeriodo.NewRow();
                row["idPeriodo"] = i.ToString("00") + clsVarGlobal.dFecSystem.ToString("yyyy");
                row["cPeriodo"] = i.ToString("00") + " - " + clsVarGlobal.dFecSystem.ToString("yyyy");
                dtPeriodo.Rows.Add(row);
            }
            this.DataSource = dtPeriodo;
            this.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            this.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedValue = "000000";
        }
    }
}
