using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoPago : cboBase
    {
        clsCNTipoPago TipoPago = new clsCNTipoPago();
        public DataTable dtTipoPago;
        
        public cboTipoPago()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoPago(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            dtTipoPago = TipoPago.ListaTipoPago();

            this.DataSource = dtTipoPago;
            this.ValueMember = dtTipoPago.Columns["idTipoPago"].ToString();
            this.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();
        }

        public void ListarTipPagCanal(int idCanalTipOpe)
        {
            dtTipoPago = TipoPago.CNListarTipPagCanal(idCanalTipOpe);
            //dtTipoPago.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtTipoPago.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtTipoPago.Rows.Remove(row);

            this.DataSource = dtTipoPago;
            this.ValueMember = dtTipoPago.Columns["idTipPagCanal"].ToString();
            this.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();
        }
        public void ListarTipPagOrdenCompra()
        {
            dtTipoPago = TipoPago.CNListaTipPagOrdenComp();

            this.DataSource = dtTipoPago;
            this.ValueMember = dtTipoPago.Columns["idTipoPago"].ToString();
            this.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();
        }
    }
}
