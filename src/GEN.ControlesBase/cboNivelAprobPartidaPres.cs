using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboNivelAprobPartidaPres : cboBase
    {
        public cboNivelAprobPartidaPres()
        {
            InitializeComponent();            
        }
        public cboNivelAprobPartidaPres(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarTodo();
        }
        public void CargarTodo()
        {
            clsCNNivelAprobPartidaPres CNNivelAprob = new clsCNNivelAprobPartidaPres();
            DataTable dtNivelAprob = CNNivelAprob.ListaTodoNivelAprobPartida();
            this.DataSource = dtNivelAprob;
            this.ValueMember = dtNivelAprob.Columns["idNivelAprobacion"].ToString();
            this.DisplayMember = dtNivelAprob.Columns["cDescripcion"].ToString();
        }
    }
}
