using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMotivoBloqueo : cboBase
    {
        public cboMotivoBloqueo()
        {
            InitializeComponent();
        }

        public cboMotivoBloqueo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNMotivoBloqueo ListadoMotivoBloqueo = new clsCNMotivoBloqueo();
            DataTable dt = ListadoMotivoBloqueo.CNListaMotivoBloqueo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idMotivoBloq"].ToString();
            this.DisplayMember = dt.Columns["cDescripcion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedValue = -1;
        }
        
        public void MotivoBloqueoYTodos()
        {
            clsCNMotivoBloqueo ListadoMotivoBloqueo = new clsCNMotivoBloqueo();
            DataTable dt = ListadoMotivoBloqueo.CNListaMotivoBloqueo();

            DataRow row = dt.NewRow();
            row["idMotivoBloq"] = 0;
            row["cDescripcion"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
