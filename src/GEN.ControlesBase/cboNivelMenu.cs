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
    public partial class cboNivelMenu : cboBase
    {
        public cboNivelMenu()
        {
            InitializeComponent();
        }

        public cboNivelMenu(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargar();
        }

        public void cargar()
        {
            List<clsNivelMenu> lista = new List<clsNivelMenu>();
            lista.Add(new clsNivelMenu() { idNivelMenu = 1, cNivelMenu = "Mismo Nivel" });
            lista.Add(new clsNivelMenu() { idNivelMenu = 2, cNivelMenu = "Menú Hijo" });

            this.DataSource = lista;
            this.ValueMember = "idNivelMenu";
            this.DisplayMember = "cNivelMenu";
        }
    }
    class clsNivelMenu
    {
        public int idNivelMenu { get; set; }
        public string cNivelMenu { get; set; }
    }
}
