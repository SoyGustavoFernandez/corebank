using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoBien : cboBase
    {
        public cboTipoBien()
        {
            InitializeComponent();
        }

        public cboTipoBien(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargarTipoBien(0);
        }
        public void cargarTipoBien(int idTipoPedido, bool lTodos = false)
        {
            clsCNTipoBien clstipobien = new clsCNTipoBien();
            DataTable dt = clstipobien.CNListaTipoBien(idTipoPedido);
            if (lTodos)
            {
                DataRow row = dt.NewRow();
                row["idTipoBien"] = 0;
                row["cDescripcion"] = "-* TODOS *-";
                dt.Rows.InsertAt(row, 0);
            }
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoBien"].ToString();
            this.DisplayMember = dt.Columns["cDescripcion"].ToString();
        }
    }
}
