using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboEstadoCredito : cboBase
    {
        clsCNEstadoCredito ListarEstado = new clsCNEstadoCredito();

        public cboEstadoCredito()
        {
            InitializeComponent();
        }

        public cboEstadoCredito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargaEstado(Int32 nCodEstadoPad)
        {
            DataTable dt = ListarEstado.ListarEstado(nCodEstadoPad);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void CargaEstadoActual(Int32 nEstadoActual)
        {
            DataTable dt = ListarEstado.ListarEstadoActual(nEstadoActual);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void CargaEstadoPreSol(Int32 nCodEstado)
        {

            DataTable dt = ListarEstado.ListaEstCre(nCodEstado);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public DataTable retornarTodosEstado()
        {
            return ListarEstado.retornarTodosEstado();
        }

        public void CargarEstPreSolicitud()
        {
            CargaEstado(1);
            DataTable dtData = this.DataSource as DataTable;
            var result = dtData.AsEnumerable().Where(x => x.Field<int>(0) != 2);
            if (result.Count() > 0)
            {
                dtData = result.CopyToDataTable();
            }

            this.ValueMember = dtData.Columns[0].ToString();
            this.DisplayMember = dtData.Columns[1].ToString();
            this.DataSource = dtData;
        }



    }
}
