using CRE.CapaNegocio;
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
    public partial class cboPeriodoCateOfi : cboBase
    {
        clsCNCategoriaOficina cnCategoriaOficina = new clsCNCategoriaOficina();
        public cboPeriodoCateOfi()
        {
            InitializeComponent();
        }

        public cboPeriodoCateOfi(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void cargarDatos(bool lSoloVigentes)
        {
            DataTable dtPeriodoCateOficina = cnCategoriaOficina.ListarPeriodoCateOficina(lSoloVigentes);
            this.ValueMember = "idPeriodoCateOfi";
            this.DisplayMember = "cNombre";
            this.DataSource = dtPeriodoCateOficina;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

    }
}
