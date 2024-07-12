using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTasaCompensatoria : cboBase
    {
        public DataTable dt;
        public cboTasaCompensatoria()
        {
            InitializeComponent();
        }

        public cboTasaCompensatoria(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarTasa(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion, int idClasificacionInterna)
        {
            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
            dt = TasaCredito.ListaTasaCredito(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idOperacion, idClasificacionInterna);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
