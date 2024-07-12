using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoComprobante : cboBase
    {
        public cboEstadoComprobante()
        {
            InitializeComponent();
        }

        public cboEstadoComprobante(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNCajaChica ListarEstado = new clsCNCajaChica();
            DataTable dt = ListarEstado.ListarEstadosCpg();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void CargaEstado()
        {
            clsCNCajaChica ListaTodosEstado = new clsCNCajaChica();
            DataTable dt = ListaTodosEstado.CNListadoEstadoCpg();

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
