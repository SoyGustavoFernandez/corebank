using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboActividadLog : cboBase
    {
        public cboActividadLog()
        {
            InitializeComponent();
        }

        public cboActividadLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }
        public void ListarActividad(Int32 idperfil,Int32 idagencia)
        {
            clsCNActividadLog clsActividadLog = new clsCNActividadLog();
            DataTable dt = clsActividadLog.CNListaActividadLog(idagencia, idperfil);
            this.DataSource = dt;
            this.DisplayMember = dt.Columns["cActividadLog"].ToString();
            this.ValueMember = dt.Columns["idActividadLog"].ToString();
        }

    }
}
