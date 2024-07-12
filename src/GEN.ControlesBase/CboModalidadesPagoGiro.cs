using EntityLayer;
using SER.CapaNegocio;
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
    public partial class CboModalidadesPagoGiro : cboBase
    {
        public CboModalidadesPagoGiro()
        {
            InitializeComponent();
        }

        public CboModalidadesPagoGiro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Cargar();
        }
        public void Cargar()
        {
            DataTable dt = new clsCNControlServ().CNListarModalidadesPago();
            ValueMember = dt.Columns[0].ToString();
            DisplayMember = dt.Columns[1].ToString();
            DataSource = dt;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
