using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEntidad : cboBase
    {
        public cboEntidad()
        {
            InitializeComponent();
        }

        public cboEntidad(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarEntidades(Int32 idTipoEntidad)
        {
            clsCNControlOpe ListaEntidad = new clsCNControlOpe();
            DataTable dt = ListaEntidad.CNEntidadFinanciera(idTipoEntidad,"%");
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void CargarEntidadesFondeo(Int32 idTipoEntidad, string cindicadorFondeo)
        {
            clsCNControlOpe ListaEntidad = new clsCNControlOpe();
            DataTable dt = ListaEntidad.CNEntidadFinanciera(idTipoEntidad, cindicadorFondeo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
