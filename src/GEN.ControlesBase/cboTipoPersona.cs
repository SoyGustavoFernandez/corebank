using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class cboTipoPersona : cboBase
    {
        clsCNTipoPersona ListadoTipoPersona = new clsCNTipoPersona();
        public DataTable dtTipoPersona;

        public cboTipoPersona()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoPersona(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            dtTipoPersona = ListadoTipoPersona.listarTipoPersona();
            this.DataSource = dtTipoPersona;
            this.ValueMember = dtTipoPersona.Columns[0].ToString();
            this.DisplayMember = dtTipoPersona.Columns[1].ToString();         
        }

        public void TipospersonaYTodos()
        {
            dtTipoPersona = ListadoTipoPersona.listarTipoPersona();

            DataRow row = dtTipoPersona.NewRow();
            row["idTipoPersona"] = 0;
            row["cTipoPersona"] = "TODOS";
            dtTipoPersona.Rows.Add(row);

            this.DataSource = dtTipoPersona;
            this.ValueMember = dtTipoPersona.Columns[0].ToString();
            this.DisplayMember = dtTipoPersona.Columns[1].ToString();
        }

        public void TipoPersonaProducto(int idProducto)
        {
            dtTipoPersona = ListadoTipoPersona.CNListarTipPersonaProducto(idProducto);
//            dtTipoPersona.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtTipoPersona.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtTipoPersona.Rows.Remove(row);

            this.DataSource = dtTipoPersona;
            this.ValueMember = dtTipoPersona.Columns["idTipPerProduc"].ToString();
            this.DisplayMember = dtTipoPersona.Columns["cTipoPersona"].ToString();
        }
    }
}
