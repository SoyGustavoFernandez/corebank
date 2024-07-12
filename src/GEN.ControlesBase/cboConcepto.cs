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
    public partial class cboConcepto : cboBase
    {
        clsCNConcepto Concepto = new clsCNConcepto();
        public DataTable dtConcepto;

        public cboConcepto()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboConcepto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarConcepto(int idGrupoCon)
        {
            dtConcepto = Concepto.CNListarConcepto(idGrupoCon);

            this.DataSource = dtConcepto;
            this.ValueMember = dtConcepto.Columns["idConcepto"].ToString();
            this.DisplayMember = dtConcepto.Columns["cConcepto"].ToString();
        }

        public void ListarConcepTipPag(int idTipPagCanal)
        {
            dtConcepto = Concepto.CNListarConcepTipPag(idTipPagCanal);
            //dtConcepto.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtConcepto.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtConcepto.Rows.Remove(row);

            this.DataSource = dtConcepto;
            this.ValueMember = dtConcepto.Columns["idConcepTipPag"].ToString();
            this.DisplayMember = dtConcepto.Columns["cConcepto"].ToString();
        }
        public void ListarConcepRecTipPag(int idTipPagCanal)
        {
            dtConcepto = Concepto.CNListarConcepRecTipPag(idTipPagCanal);
            //dtConcepto.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtConcepto.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtConcepto.Rows.Remove(row);

            this.DataSource = dtConcepto;
            this.ValueMember = dtConcepto.Columns["idConcepTipPag"].ToString();
            this.DisplayMember = dtConcepto.Columns["cConcepto"].ToString();
        }
    }
}
