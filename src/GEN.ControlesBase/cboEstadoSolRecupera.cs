using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboEstadoSolRecupera : cboBase
    {
        public cboEstadoSolRecupera()
        {
            InitializeComponent();
        }

        public cboEstadoSolRecupera(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dt = new clsCNEstadoSolRecupera().ListarEstadoSolRecupera();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarParaAprobacion()
        {
            DataTable dt = new clsCNEstadoSolRecupera().ListarEstadoSolRecupera();

            DataTable dtEstadoSolRecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true && (Convert.ToInt32(item["idEstadoSolRec"])).In(2,4)
             select item).CopyToDataTable(dtEstadoSolRecupera, LoadOption.OverwriteChanges);

            this.DataSource = dtEstadoSolRecupera;
            this.ValueMember = dtEstadoSolRecupera.Columns[0].ToString();
            this.DisplayMember = dtEstadoSolRecupera.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
