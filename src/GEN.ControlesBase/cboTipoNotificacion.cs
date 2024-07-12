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
    public partial class cboTipoNotificacion : cboBase
    {
        clsCNTipoNotificacion cnTipoNotificacion = new clsCNTipoNotificacion();

        public cboTipoNotificacion()
        {
            InitializeComponent();
        }

        public cboTipoNotificacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public void cargar(int nAtraso, int idTipoIntev)
        {
            DataTable dt = cnTipoNotificacion.obtenerTipoNotificaciones(nAtraso, idTipoIntev);
            DataRow dr = dt.NewRow();
            dr["idTipoNotificacion"] = 0;
            dr["cTipoNotificacion"] = "NO GENERAR NOTIFICACIÓN";
            dr["idTipoNotiSugerida"] = 0;
            dr["idTipoNotificacionEnRango"] = 0;
            dt.Rows.Add(dr);
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["idTipoNotificacionEnRango"]) != 0)
                {
                    row["cTipoNotificacion"] = "(SUGERIDO) " + row["cTipoNotificacion"];
                }
            }
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoNotificacion"].ToString();
            this.DisplayMember = dt.Columns["cTipoNotificacion"].ToString();
            this.SelectedValue = dt.Rows[0]["idTipoNotiSugerida"];
        }
    }
}
