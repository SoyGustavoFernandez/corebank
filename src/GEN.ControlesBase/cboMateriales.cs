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
    public partial class cboMateriales : cboBase
    {
        public cboMateriales()
        {
            InitializeComponent();
        }

        public void cargarListaPared()
        {
            this.DataSource = new clsCNMaterial().listarMaterialPared();
            this.ValueMember = "idMaterial";
            this.DisplayMember = "cMaterial";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarListaTecho()
        {
            this.DataSource = new clsCNMaterial().listarMaterialTecho();
            this.ValueMember = "idMaterial";
            this.DisplayMember = "cMaterial";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarListaVentana()
        {
            this.DataSource = new clsCNMaterial().listarMaterialVentana();
            this.ValueMember = "idMaterial";
            this.DisplayMember = "cMaterial";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
