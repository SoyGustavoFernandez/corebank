using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboDetalleGasto : cboBase
    {
        clsCNDetalleGasto clsTipoSeguro = new clsCNDetalleGasto();

        public String cMsjSeguroDevolucion;
        public String cTituloMsjSegDevolucion;

        public cboDetalleGasto()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            inicializarMsjDialog();
        }

        public void inicializarMsjDialog()
        {
            cMsjSeguroDevolucion = "Se ha seleccionando el Seguro de Desgravamen con Devolución y va a encarecer la cuota.\r\n¿Está seguro de mantener tu elección?";
            cTituloMsjSegDevolucion = "Seguro de Desgravamen con Devolución";
        }

        public cboDetalleGasto(IContainer container)
        {
            container.Add(this);
            
            InitializeComponent();
            inicializarMsjDialog();
        }

        public void listarDetalleTipoGasto(int idConcepto)
        {
            DataTable dtSeguros = clsTipoSeguro.CNListarDetalleTipoGasto(idConcepto);

            this.DataSource = dtSeguros;
            this.ValueMember = dtSeguros.Columns["idDetalleGasto"].ToString();
            this.DisplayMember = dtSeguros.Columns["cDetalleGasto"].ToString();
        }

        public void listarDetalleGastoEnSolicitud()
        {
            DataTable dtSeguros = clsTipoSeguro.CNListarDetalleTipoGasto(0);
            this.DataSource = dtSeguros.Select("idDetalleGasto IN (1,2,4)").CopyToDataTable();
            this.ValueMember = dtSeguros.Columns["idDetalleGasto"].ToString();
            this.DisplayMember = dtSeguros.Columns["cDetalleGasto"].ToString();
        }
    }
}
