using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using ADM.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstadoSupervision : cboBase
    {
        clsCNEstadoSupervision clsEstado = new clsCNEstadoSupervision();

        public cboEstadoSupervision()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboEstadoSupervision(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarEstadoSupervision();
        }

        public void cargarEstadoSupervision()
        {
            DataTable dt = clsEstado.CNListarEstadoSupervisorOperacion();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row["idEstado"] = 0;
                row["cEstado"] = "-* TODOS *-";
                dt.Rows.InsertAt(row, 0);
            }

            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
