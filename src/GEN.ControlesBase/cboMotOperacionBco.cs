using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboMotOperacionBco : cboBase
    {        
        public cboMotOperacionBco()
        {
            InitializeComponent();
        }

        public cboMotOperacionBco(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarMotivoOperacion(int idPadreMotivo)
        {
            clsCNMovimientoBancario listaMotOperacion = new clsCNMovimientoBancario();
            DataTable dt = listaMotOperacion.ListarMotOperacionBco(idPadreMotivo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            
        }
    }
}
