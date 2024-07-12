using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class conUbigeo : UserControl
    {
        public conUbigeo()
        {
            InitializeComponent();
        }

        private void conUbigeo_Load(object sender, EventArgs e)
        {
            clsCNPais ListaPais = new clsCNPais();
            DataTable tbpais=ListaPais.ListarPaises();
            conUbigeo Contenedor = new conUbigeo();
            Contenedor.cboPais.DataSource = tbpais;
            Contenedor.cboPais.ValueMember = tbpais.Columns[0].ToString();
            Contenedor.cboPais.DisplayMember = tbpais.Columns[1].ToString();
        }
    }
}
