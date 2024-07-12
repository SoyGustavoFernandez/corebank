using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPL.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoFamiliar : cboBase
    {
        public cboTipoFamiliar()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void cargarTodos()
        {
            clsCNTipoFamiliar tiposfam = new clsCNTipoFamiliar();
            DataTable dtbfamiliar = tiposfam.ListarTipoFamiliar();
            this.DataSource = dtbfamiliar;
            this.ValueMember = dtbfamiliar.Columns[0].ToString();
            this.DisplayMember = dtbfamiliar.Columns[1].ToString();
        }

        public void cargarBeneficiarios()
        {
            clsCNTipoFamiliar tiposfam = new clsCNTipoFamiliar();
            DataTable dtbfamiliar = tiposfam.ListarTipoFamiliar();

            var query = from item in dtbfamiliar.AsEnumerable()
                        where (bool)item["lIndBenefic"] == true
                        select item;

            DataTable dtbeneficiarios = dtbfamiliar.Clone();
            dtbeneficiarios.Rows.Clear();

            foreach (DataRow item in query)
            {
                dtbeneficiarios.ImportRow(item);
            }            

            this.DataSource = dtbeneficiarios;
            this.ValueMember = dtbeneficiarios.Columns[0].ToString();
            this.DisplayMember = dtbeneficiarios.Columns[1].ToString();
        }

        public void cargarTipoVinculo()
        {
            clsCNTipoFamiliar tiposfam = new clsCNTipoFamiliar();
            DataTable dtTipoVinculo = tiposfam.ListarTipoVinculo();

            this.DataSource = dtTipoVinculo;
            this.ValueMember = dtTipoVinculo.Columns[0].ToString();//idTipoVinculo
            this.DisplayMember = dtTipoVinculo.Columns[1].ToString();//cTipoVinculo
        }
    }
}
