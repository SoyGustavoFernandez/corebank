using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboContactoRecupera : cboBase
    {
        public cboContactoRecupera()
        {
            InitializeComponent();
        }

        public cboContactoRecupera(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dt = new clsCNContactoRecupera().ListarContactoRecupera();
            this.DataSource = dt;   
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
