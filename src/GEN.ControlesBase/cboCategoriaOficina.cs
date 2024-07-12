using CRE.CapaNegocio;
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
    public partial class cboCategoriaOficina : cboBase
    {
        clsCNCategoriaOficina cnCategoriaOficina = new clsCNCategoriaOficina();

        public cboCategoriaOficina(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }


        public void cargarDatos(bool lSoloVigentes, int idPeriodoCateOfi)
        {
            DataTable dtCategoriaOficina = cnCategoriaOficina.ListarCategoriaOficina(lSoloVigentes, idPeriodoCateOfi);
            this.ValueMember = "idCategoriaOfi";
            this.DisplayMember = "cDescripcion";
            this.DataSource = dtCategoriaOficina;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }
    }
}
