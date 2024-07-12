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
    public partial class cboTipoEntidad : cboBase
    {
        
        public cboTipoEntidad()
        {
            InitializeComponent();
        }

        public cboTipoEntidad(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            
            cargarTipoDeEntidad("%");
        }
        public void cargarTipoDeEntidad(string cindicadorFondeo)
        {
            clsCNControlOpe ListadoEntidad = new clsCNControlOpe();
            DataTable dt = ListadoEntidad.CNTipoEntidadFinanciera(cindicadorFondeo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
