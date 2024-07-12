using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboSupervisorOperacion : cboBase
    {
        clsCNSupervisorOperacion clsSupervOpe = new clsCNSupervisorOperacion();

        public cboSupervisorOperacion()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboSupervisorOperacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargarSupervisor(string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin, int idRegion, int idAgencia, int idEstablecimiento, int idEstado )
        {
            DataTable dt = clsSupervOpe.CNListarSupervisorOperacion(cTipoSupervision, dFechaIni, dFechaFin, idRegion, idAgencia, idEstablecimiento, idEstado);

            if (dt.Rows.Count > 1 || dt.Rows.Count == 0)
            {
                DataRow row = dt.NewRow();
                row["idUsuario"] = 0;
                row["cNombre"] = "-* TODOS *-";
                dt.Rows.InsertAt(row, 0);
            }
            
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }

        public void mostrarSoloTodos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("cNombre");

            DataRow row = dt.NewRow();
            row["idUsuario"] = 0;
            row["cNombre"] = "-* TODOS *-";
            dt.Rows.InsertAt(row, 0);

            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }

        public int getIdZona( int idUsuario)
        {
            DataTable dt = (DataTable)this.DataSource;
            foreach(DataRow row in dt.Rows){
                if (Convert.ToInt32(row["idUsuario"]) == idUsuario)
                {
                    return Convert.ToInt32(row["idZona"]);
                }
            }
            return 0;
        }
    }
}
