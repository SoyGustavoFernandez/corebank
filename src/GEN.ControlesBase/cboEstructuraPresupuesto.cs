using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboEstructuraPresupuesto : cboBase
    {
        DataTable dtEstructuras = new DataTable();
        public cboEstructuraPresupuesto()
        {
            InitializeComponent();            
        }

        public cboEstructuraPresupuesto(IContainer container)
        {
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            container.Add(this);
            InitializeComponent();
            
            dtEstructuras.Columns.Add("idEstruc", typeof(String));
            dtEstructuras.Columns.Add("cEstruc", typeof(String));
            DataRow drEstructura = dtEstructuras.NewRow();
            drEstructura["idEstruc"] = "";
            drEstructura["cEstruc"] = "Todos";
            dtEstructuras.Rows.Add(drEstructura);
            DataRow drEstructura2 = dtEstructuras.NewRow();
            drEstructura2["idEstruc"] = "EPG";
            drEstructura2["cEstruc"] = "Est.Ganancias y Pérdidas";
            dtEstructuras.Rows.Add(drEstructura2);
            DataRow drEstructura3 = dtEstructuras.NewRow();
            drEstructura3["idEstruc"] = "BG";
            drEstructura3["cEstruc"] = "Balance General";
            dtEstructuras.Rows.Add(drEstructura3);

            this.DataSource = dtEstructuras;
            this.DisplayMember = "cEstruc";
            this.ValueMember = "idEstruc";    
        }
        /*============================================================================*/
        /* - lista solo las estructuras sin Todos                                     */
        /*============================================================================*/
        public void soloEstructuras()
        {
            DataRow drTodos = dtEstructuras.Rows[0];             
            dtEstructuras.Rows.Remove(drTodos);
        }
    }
}
