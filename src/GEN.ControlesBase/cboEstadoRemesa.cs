using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoRemesa : cboBase
    {
        public cboEstadoRemesa()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboEstadoRemesa(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public void ListarEstadoRemesa(int idTipoRemesa,int idPerfil, int idEstadoRemesa)
        {
            clsCNRemesa ListarEstadoRemesa = new clsCNRemesa();
            DataTable dtEstadoRemesa = ListarEstadoRemesa.CNListarEstadoRemesa(idTipoRemesa, idPerfil, idEstadoRemesa);

            if (dtEstadoRemesa.Rows.Count > 0)
            {
                this.DataSource = dtEstadoRemesa;
                this.ValueMember = dtEstadoRemesa.Columns[0].ToString();
                this.DisplayMember = dtEstadoRemesa.Columns[1].ToString();
                this.Enabled = true;
            }
            else 
            {
                this.DataSource = null;
                this.Items.Clear();
                this.Enabled = false;
            }
            this.SelectedValue = -1;
        }
        public void ListarEstadoRemesas(int idTipoRemesa)
        {
            clsCNRemesa ListarEstadoRemesa = new clsCNRemesa();
            DataTable dtEstadoRemesa = ListarEstadoRemesa.CNListarEstadoRemesa(idTipoRemesa, 0, 0);
            DataRow row = dtEstadoRemesa.NewRow();
            row["idEstadoRemesa"] = 0;
            row["cDescripcion"] = "-* TODOS *-";
            dtEstadoRemesa.Rows.InsertAt(row, 0);

            this.DataSource = dtEstadoRemesa;
            this.ValueMember = dtEstadoRemesa.Columns[0].ToString();
            this.DisplayMember = dtEstadoRemesa.Columns[1].ToString();
            this.Enabled = true;
            this.SelectedValue = -1;
        }
    }
}
