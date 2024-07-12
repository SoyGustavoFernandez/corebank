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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDesvincularSolicitudGarantia : frmBase
    {
        #region Variable Globales

        clsCNRetornsCuentaSolCliente cnbusqueda = new clsCNRetornsCuentaSolCliente();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        #endregion

        public frmDesvincularSolicitudGarantia()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            conBusCli1.txtCodCli.Focus();
        }


        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;


            return lValida;
        }

        private void formatoGridsolicitudes()
        {
            foreach (DataGridViewColumn item in dtgSolicitudes.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolicitudes.Columns["IdNum"].Visible = true;
            dtgSolicitudes.Columns["cEstado"].Visible = true;
            dtgSolicitudes.Columns["Fecha_Desembolso"].Visible = true;
            dtgSolicitudes.Columns["nMonto"].Visible = true;
            dtgSolicitudes.Columns["cProducto"].Visible = true;
            dtgSolicitudes.Columns["cMoneda"].Visible = true;



            dtgSolicitudes.Columns["IdNum"].HeaderText = "Cod.Solicitud";
            dtgSolicitudes.Columns["cEstado"].HeaderText = "Estado";
            dtgSolicitudes.Columns["Fecha_Desembolso"].HeaderText = "Fecha Des.";
            dtgSolicitudes.Columns["nMonto"].HeaderText = "Monto";
            dtgSolicitudes.Columns["cProducto"].HeaderText = "Producto";
            dtgSolicitudes.Columns["cMoneda"].HeaderText = "Moneda";

            dtgSolicitudes.Columns["nMonto"].DefaultCellStyle.Format = "N2";
            dtgSolicitudes.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgSolicitudes.Columns["IdNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["Fecha_Desembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void formatoGridGarantia()
        {
            foreach (DataGridViewColumn item in this.dtgGarantias.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGarantias.Columns["idGarantia"].Visible = true;
            dtgGarantias.Columns["nGravamen"].Visible = true;
            dtgGarantias.Columns["nPorcentaje"].Visible = true;
            dtgGarantias.Columns["idCli"].Visible = true;
            dtgGarantias.Columns["cNombre"].Visible = true;
            dtgGarantias.Columns["cDocumentoID"].Visible = true;
            dtgGarantias.Columns["cGarantia"].Visible = true;
            dtgGarantias.Columns["cTipoGarantia"].Visible = true;
            dtgGarantias.Columns["cClaseGarantia"].Visible = true;
            dtgGarantias.Columns["cDesGrupo"].Visible = true;
            dtgGarantias.Columns["cMoneda"].Visible = true;
            dtgGarantias.Columns["nMonGarantia"].Visible = true;


            dtgGarantias.Columns["idGarantia"].HeaderText = "Cod.Garantía";
            dtgGarantias.Columns["nGravamen"].HeaderText = "Monto Gravado";
            dtgGarantias.Columns["nPorcentaje"].HeaderText = "Porcentaje";
            dtgGarantias.Columns["idCli"].HeaderText = "Cod.Propietario Gar.";
            dtgGarantias.Columns["cNombre"].HeaderText = "Nombre Propietario Garantía";
            dtgGarantias.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgGarantias.Columns["cGarantia"].HeaderText = "Descripción Garantía";
            dtgGarantias.Columns["cTipoGarantia"].HeaderText = "Tipo Garantía";
            dtgGarantias.Columns["cClaseGarantia"].HeaderText = "Clase Garantía";
            dtgGarantias.Columns["cDesGrupo"].HeaderText = "Grupo Garantía";
            dtgGarantias.Columns["cMoneda"].HeaderText = "Moneda";
            dtgGarantias.Columns["nMonGarantia"].HeaderText = "Monto Garantía";

            dtgGarantias.Columns["nMonGarantia"].DefaultCellStyle.Format = "N2";
            dtgGarantias.Columns["nMonGarantia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void limpiar()
        {

        }

        #endregion

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli>0)
            {
                //LISTAR SOLICITUDES SOLO ANULADAS O RECHAZADAS
                DataTable dtDatosCuentaSolCliente = cnbusqueda.RetornaCuentaSolCliente(conBusCli1.idCli, "S", "[1,3,4]");
                if (dtDatosCuentaSolCliente.Rows.Count > 0)
                {
                    dtgSolicitudes.DataSource = dtDatosCuentaSolCliente;
                    formatoGridsolicitudes();
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            dtgSolicitudes.DataSource = null;
            dtgGarantias.DataSource = null;
            btnAnular1.Enabled = false;
        }

        private void btnAnular1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count > 0)
            {
                int idSolicitud = (int)dtgSolicitudes.SelectedRows[0].Cells["IdNum"].Value;
                var dResultado = MessageBox.Show("¿Desea desvincular la solicitud nro. : " + idSolicitud + " de la(s) garantía(s)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResultado == System.Windows.Forms.DialogResult.Yes)
                {
                    var dtResultado=cnsolicitud.CNRegDesvinculacionSolGar(idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                    if ((int)dtResultado.Rows[0][0]==1)
                    {
                        MessageBox.Show("La desvinculación se grabó correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la desvinculación", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    conBusCli1_ClicBuscar(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Seleccione la solicitud de crédito a desvincular", "Validación de desvinculación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count > 0)
            {
                dtgGarantias.DataSource = null;
                int idsolicitud = (int)dtgSolicitudes.SelectedRows[0].Cells["IdNum"].Value;

                var dtGarSol = cnsolicitud.CNListarGarantiasxSolicitud(idsolicitud);

                if (dtGarSol.Rows.Count>0)
                {
                    dtgGarantias.DataSource = dtGarSol;
                    formatoGridGarantia();
                    btnAnular1.Enabled = true;
                }
                else
                {
                    btnAnular1.Enabled = false;
                }
            }
        }
    }
}
