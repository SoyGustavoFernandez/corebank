using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboResultadoVisitaRiesgos : cboBase
    {
        public cboResultadoVisitaRiesgos()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboResultadoVisitaRiesgos(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargarResultados();
        }
        public void CargarResultados()
        {
            DataTable dtResultado = new clsCNVisita().CNResultadoVisitas();
            this.DataSource = dtResultado;
            this.ValueMember = dtResultado.Columns[0].ToString();
            this.DisplayMember = dtResultado.Columns[1].ToString();
        }
    }
}
