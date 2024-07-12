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
    public partial class frmDesvincGarCreCancelado : frmBase
    {
        #region Variable Globales

        clsCNRetornsCuentaSolCliente cnbusqueda = new clsCNRetornsCuentaSolCliente();
        clsCNCredito cncredito = new clsCNCredito();

        #endregion

        public frmDesvincGarCreCancelado()
        {
            InitializeComponent();
        }

        private void frmDesvincGarCreCancelado_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            conBusCli1.txtCodCli.Focus();
        }


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



            dtgSolicitudes.Columns["IdNum"].HeaderText = "Nro. Cuenta";
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
            if (conBusCli1.idCli > 0)
            {
                //LISTAR SOLICITUDES SOLO ANULADAS O RECHAZADAS
                DataTable dtDatosCuentaCliente = cnbusqueda.RetornaCuentaSolCliente(conBusCli1.idCli, "C", "[6]");
                
                if (dtDatosCuentaCliente.Rows.Count > 0)
                {
                    var dtAux = dtDatosCuentaCliente.Clone();
                    (from item in dtDatosCuentaCliente.AsEnumerable()
                     where (bool)item["lGarantia"] == true
                     select item).CopyToDataTable(dtAux, LoadOption.OverwriteChanges);

                    if (dtAux.Rows.Count > 0)
                    {
                        dtgSolicitudes.DataSource = dtAux;
                        formatoGridsolicitudes();
                        this.btnCancelar1.Enabled = true;
                    }
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
            this.btnCancelar1.Enabled = false;
        }

        private void btnAnular1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count > 0)
            {
                #region Validacion
                int idCuenta = (int)dtgSolicitudes.SelectedRows[0].Cells["IdNum"].Value;
                var dtValida = cncredito.CNValidarEstadoCuentaAhoGarantia(idCuenta);
                int nVal = 0;
                foreach (DataRow item in dtValida.Rows)
                {
                    if (Convert.ToInt32(item["idEstado"])==2)
                    {
                        MessageBox.Show("La cuenta de ahorro ya se encuentra cancelada", "Valida cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nVal++;
                    }
                    if (Convert.ToInt32(item["idEstado"]) == 3)
                    {
                        MessageBox.Show("La cuenta de ahorro se encuentra extornada", "Valida cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nVal++;
                    }
                    if (Convert.ToInt32(item["idEstado"]) == 5)
                    {
                        MessageBox.Show("La cuenta de ahorro se encuentra anulada", "Valida cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nVal++;
                    }
                }

                if (nVal > 0)
                {
                    return;
                }

                #endregion


                var dResultado = MessageBox.Show("¿Desea desvincular el crédito nro. : " + idCuenta + " de la(s) garantía(s)?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResultado == System.Windows.Forms.DialogResult.Yes)
                {
                    var dtResultado = cncredito.CNActualizaSaldoGarantiaCli(idCuenta);
                    if ((int)dtResultado.Rows[0][0] == 1)
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
                int idCuenta = (int)dtgSolicitudes.SelectedRows[0].Cells["IdNum"].Value;

                var dtGarSol = cncredito.CNListarGarantiasxCredito(idCuenta);

                if (dtGarSol.Rows.Count > 0)
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
