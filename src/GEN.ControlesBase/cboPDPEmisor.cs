using CNE.CapaNegocio;
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
    public partial class cboPDPEmisor : cboBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();

        public cboPDPEmisor()
        {
            InitializeComponent();
        }

        public cboPDPEmisor(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }

        public void cargarVigentes()
        {            
            DataTable dt = cnRptPdp.ObtenerEmisores();            

            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }            

            ValueMember = "idPDPEmisor";
            DisplayMember = "cEmisor";
            DataSource = dt;
        }

        public void cargarVigentesTodos()
        {
            DataTable dt = cnRptPdp.ObtenerEmisores();

            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }

            DataRow dr = dt.NewRow();

            dr["idPDPEmisor"] = 0;
            dr["cEmisor"] = "TODOS";

            dt.Rows.InsertAt(dr, 0);

            ValueMember = "idPDPEmisor";
            DisplayMember = "cEmisor";
            DataSource = dt;
        }
    }
}
