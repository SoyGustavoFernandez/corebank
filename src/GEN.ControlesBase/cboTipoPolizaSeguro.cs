using CRE.CapaNegocio;
using EntityLayer;
using System.Collections.Generic;
using System.ComponentModel;

namespace GEN.ControlesBase
{
    public partial class cboTipoPolizaSeguro : cboBase
    {
        public cboTipoPolizaSeguro()
        {
            InitializeComponent();
        }

        public cboTipoPolizaSeguro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            List<clsPolizaSeguro> dtListaPolizas = new clsCNSeguros().CNObtenerPolizaSeguro();

            if (dtListaPolizas.Count > 0)
            {
                clsPolizaSeguro objTodos = new clsPolizaSeguro
                {
                    nTipoPoliza = 0,
                    cPoliza = "TODOS"
                };
                dtListaPolizas.Insert(0, objTodos);

                this.DataSource = dtListaPolizas;
                this.ValueMember = "nTipoPoliza";
                this.DisplayMember = "cPoliza";
            }
        }
    }
}