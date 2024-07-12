using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboTipoLocalActividad : cboBase
    {
        public DataTable dtTipoLocalActividad;
        public cboTipoLocalActividad()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoLocalActividad(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargarTipoLocalActividad(int idProducto)
        {
            dtTipoLocalActividad = (new clsCNTipoLocalActividad()).listarTipoLocalActividad(idProducto);
            if (dtTipoLocalActividad.Rows.Count == 0)
            {
                dtTipoLocalActividad = new DataTable();
                dtTipoLocalActividad.Columns.Add("idTipoLocalActividad", typeof(int));
                dtTipoLocalActividad.Columns.Add("cTipoLocalActividad", typeof(string));

                DataRow drFila = dtTipoLocalActividad.NewRow();
                drFila["idTipoLocalActividad"] = 0;
                drFila["cTipoLocalActividad"] = "Irrelevante";

                dtTipoLocalActividad.Rows.Add(drFila);
            }
            this.DataSource = dtTipoLocalActividad;
            this.ValueMember = dtTipoLocalActividad.Columns["idTipoLocalActividad"].ToString();
            this.DisplayMember = dtTipoLocalActividad.Columns["cTipoLocalActividad"].ToString();
        }
    }
}
