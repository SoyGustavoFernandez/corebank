using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboCondicionInmueble : cboBase
    {
        public cboCondicionInmueble()
        {
            InitializeComponent();
        }

        public void cargarLista()
        {
            this.DataSource = new clsCNCondicionInmueble().listarCondicionInmueble();
            this.ValueMember = "idCondiInmueble";
            this.DisplayMember = "cCondiInmueble";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
