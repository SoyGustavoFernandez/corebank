using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipSubClasif : cboBase
    {
        public cboTipSubClasif()
        {
            InitializeComponent();
        }

        public cboTipSubClasif(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void CargarSubClasificacion(int idTipClasificacion)
        {
            clsCNTipSubClasif ListaTipSubClas = new clsCNTipSubClasif();
            DataTable tbTipSubClas = ListaTipSubClas.ListaTipSubClasificacion(idTipClasificacion);            
            this.ValueMember = tbTipSubClas.Columns[0].ToString();
            this.DisplayMember = tbTipSubClas.Columns[1].ToString();
            this.DataSource = tbTipSubClas;
        }

        public void Habilitar(Label label)
        {
            //this.SelectedIndex = -1;
            label.Visible = true;
            this.Visible = true;
        }

        public void Deshabilitar(Label label)
        {
            label.Visible = false;
            this.Visible = false;
        }
    }
}
