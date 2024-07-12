using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboCanalAproCred : cboBase
    {
        private clsCNCanalAprobacionCred objCNCanalAprobacionCred = new clsCNCanalAprobacionCred();
        public cboCanalAproCred()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public cboCanalAproCred(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.listarCanalAprobacionCred();
        }
            
        public void listarCanalAprobacionCred()
        {
            List<clsCanalAprobacionCred> lstCanalAprobacionCred = objCNCanalAprobacionCred.listarCanalAprobacionCred("1");
            this.DataSource = lstCanalAprobacionCred;
            this.ValueMember = "idCanalAproCred";
            this.DisplayMember = "cCanalAproCred";
        }

        public void ListarCanales(DataTable dtCanalesAprobacionCred)
        {
            DataTable dtCanalAprobacionCred = objCNCanalAprobacionCred.ListarCanalesAprobacionCred(dtCanalesAprobacionCred);
            this.DataSource = dtCanalAprobacionCred;
            this.ValueMember = dtCanalAprobacionCred.Columns["idCanalAproCred"].ToString();
            this.DisplayMember = dtCanalAprobacionCred.Columns["cCanalAproCred"].ToString();
        }
    }
}
