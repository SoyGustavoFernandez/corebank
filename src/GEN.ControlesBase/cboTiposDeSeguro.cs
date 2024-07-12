using CRE.CapaNegocio;
using EntityLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GEN.ControlesBase
{
    public partial class cboTiposDeSeguro : cboBase
    {
        public cboTiposDeSeguro()
        {
            InitializeComponent();
        }

        public cboTiposDeSeguro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            List<clsSolicitudCreditoSeguro> dtListaSeguros = new clsCNCreditoCargaSeguro().CNObtenerSolicitudSeguroTipo(0);

            if (dtListaSeguros.Count > 0)
            {
                dtListaSeguros = dtListaSeguros.FindAll(x => x.lPagoCuotas == false);

                clsSolicitudCreditoSeguro objNinguno = new clsSolicitudCreditoSeguro
                {
                    idTipoSeguro = -1,
                    cTipoSeguro = "NINGUNO"
                };
                dtListaSeguros.Insert(0, objNinguno);

                this.DataSource = dtListaSeguros;
                this.ValueMember = "idTipoSeguro";
                this.DisplayMember = "cTipoSeguro";
            }
        }
    }
}
