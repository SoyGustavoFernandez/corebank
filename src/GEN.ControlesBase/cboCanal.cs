using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboCanal : cboBase
    {
        clsCNCanal Canal = new clsCNCanal();
        public DataTable dtCanal;

        public cboCanal()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboCanal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            dtCanal = Canal.ListaCanal();
            
            this.DataSource = dtCanal;
            this.ValueMember = dtCanal.Columns["idCanal"].ToString();
            this.DisplayMember = dtCanal.Columns["cCanal"].ToString();
        }

        public void ListarCanalTipOpe(int idTipOpeProduc)
        {
            dtCanal = Canal.CNListarCanalTipOpe(idTipOpeProduc);
           // dtCanal.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtCanal.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtCanal.Rows.Remove(row);

            this.DataSource = dtCanal;
            this.ValueMember = dtCanal.Columns["idCanalTipOpe"].ToString();
            this.DisplayMember = dtCanal.Columns["cCanal"].ToString();
        }
    }
}
