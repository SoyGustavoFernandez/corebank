using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoCategoria : cboBase
    {
        public cboTipoCategoria()
        {
            InitializeComponent();
        }
        public cboTipoCategoria(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargarTipoCategoria();
        }


        public void cargarTipoCategoria()
        {
            DataTable dtCategoria = new DataTable();
            dtCategoria.Columns.Add("idCategoria", typeof(int));
            dtCategoria.Columns.Add("cCategoria", typeof(string));

            DataRow dr;
            dr = dtCategoria.NewRow();
            dr["idCategoria"] = 1;
            dr["cCategoria"] = "MENOR";
            dtCategoria.Rows.Add(dr);

            dr = dtCategoria.NewRow();
            dr["idCategoria"] = 2;
            dr["cCategoria"] = "MAYOR";
            dtCategoria.Rows.Add(dr);

            this.DataSource = dtCategoria;
            this.ValueMember = "idCategoria";
            this.DisplayMember = "cCategoria";

        }

    }
}
