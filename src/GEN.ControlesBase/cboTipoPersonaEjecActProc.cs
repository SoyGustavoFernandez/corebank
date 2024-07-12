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
    public partial class cboTipoPersonaEjecActProc : cboBase
    {
        clsCNTipoPersonaEjeActProc cnTipoPersonaEjeActProc = new clsCNTipoPersonaEjeActProc();
        public cboTipoPersonaEjecActProc()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void cargar()
        {
            DataTable dt = cnTipoPersonaEjeActProc.listar();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoPersonaEjecutaActProc"].ToString();
            this.DisplayMember = dt.Columns["cTipoPersonaEjecutaActProc"].ToString();
        }
    }
}
