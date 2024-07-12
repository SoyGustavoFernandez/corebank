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
    public partial class cboTipoControl : cboBase
    {
        public cboTipoControl()
        {
            InitializeComponent();
        }

        public cboTipoControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargar();
        }

        public void cargar()
        {
            List<clsTipoControl> listatipocontrol = new List<clsTipoControl>();
            listatipocontrol.Add(new clsTipoControl() { idTipoControl = 1, cTipoControl = "Formulario" });
            listatipocontrol.Add(new clsTipoControl() { idTipoControl = 2, cTipoControl = "Control" });

            this.DataSource = listatipocontrol;
            this.ValueMember = "idTipoControl";
            this.DisplayMember = "cTipoControl";
        }
    }

    class clsTipoControl
    {
        public int idTipoControl { get; set; }
        public string cTipoControl { get; set; }
    }
    
}
