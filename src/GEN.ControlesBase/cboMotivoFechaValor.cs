using CRE.CapaNegocio;
using System.ComponentModel;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboMotivoFechaValor : cboBase
    {
        public DataTable dtMotivos;
        public clsCNFechaValor cnFecha = new clsCNFechaValor();

        public cboMotivoFechaValor()
        {
            InitializeComponent();
        }

        public cboMotivoFechaValor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            dtMotivos = cnFecha.CNListarMotivosPago();
            this.DataSource = dtMotivos;

            if (dtMotivos.Rows.Count > 0)
            {
                this.ValueMember = dtMotivos.Columns["nIdMotivoPagoFechaValor"].ToString();
                this.DisplayMember = dtMotivos.Columns["cDescripcion"].ToString();
            }
        }
    }
}