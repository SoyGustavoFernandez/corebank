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
    public partial class cboTipoMenu : cboBase
    {
        public cboTipoMenu()
        {
            InitializeComponent();
        }

        public cboTipoMenu(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargar();
        }

        public void cargar()
        {
            List<clsTipoMenu> listatipocontrol = new List<clsTipoMenu>();
            listatipocontrol.Add(new clsTipoMenu() { idTipoMenu = 1, cTipoMenu = "Formulario" });
            listatipocontrol.Add(new clsTipoMenu() { idTipoMenu = 2, cTipoMenu = "Carpeta" });
            listatipocontrol.Add(new clsTipoMenu() { idTipoMenu = 3, cTipoMenu = "Formulario Web" });
            listatipocontrol.Add(new clsTipoMenu() { idTipoMenu = 4, cTipoMenu = "Carpeta Web" });

            this.DataSource = listatipocontrol;
            this.ValueMember = "idTipoMenu";
            this.DisplayMember = "cTipoMenu";
        }

    
    }
    class clsTipoMenu
    {
        public int idTipoMenu { get; set; }
        public string cTipoMenu { get; set; }
    }
}
