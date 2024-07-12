using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboMotivoDesistimiento : cboBase
    {
        private clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();
        public DataTable datoTipoAutorizacion;

        public cboMotivoDesistimiento()
        {
            InitializeComponent();
        }

        public cboMotivoDesistimiento(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtTipo = cnobjTipo.CNListaMotivoDesistimientoAutUsoDatos();
            datoTipoAutorizacion = dtTipo;
            this.DataSource = dtTipo;
            this.DisplayMember = dtTipo.Columns["cDescripcion"].ToString();
            this.ValueMember = dtTipo.Columns["idMotDesistimiento"].ToString();
        }         
    }
}
