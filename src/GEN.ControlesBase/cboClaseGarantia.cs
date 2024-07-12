using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboClaseGarantia : cboBase
    {
        public cboClaseGarantia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboClaseGarantia(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DataSource = new clsCNGarantia().listarClaseGarantia();
            this.ValueMember = "idClaseGarantia";
            this.DisplayMember = "cClaseGarantia";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
        }

        public void cargarClaseByGrupo(int idGrupo, bool lTodos = false)
        {
             var dt = new clsCNGarantia().listarClaseGarantia();

            DataTable dtClaseGarantia = dt.Clone();

            (from item in dt.AsEnumerable()
             where (int)item["idGrupo"] == idGrupo
             select item).CopyToDataTable(dtClaseGarantia, LoadOption.OverwriteChanges);

            if (lTodos)
            {
                DataRow dTodos = dtClaseGarantia.NewRow();
                dTodos["idClaseGarantia"] = 0;
                dTodos["cClaseGarantia"] = "[TODOS]";
                dtClaseGarantia.Rows.Add(dTodos);
            }

            this.DataSource = dtClaseGarantia;
            this.ValueMember = "idClaseGarantia";
            this.DisplayMember = "cClaseGarantia";
        }
    }
}
