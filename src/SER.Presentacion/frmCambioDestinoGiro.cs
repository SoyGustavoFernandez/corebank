using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using SER.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static SER.Presentacion.frmEnvioGiroNuevo;

namespace SER.Presentacion
{
    public partial class frmCambioDestinoGiro : frmBase
    {
        #region Variables
        private clsCNControlServ objCNControlServ = new clsCNControlServ();
        private List<clsTarifarioGiros> lstTarifario = new List<clsTarifarioGiros>();
        private int idProducto = 126;
        private int idTipoOperacion = 13;
        private DataTable dtGiros = new DataTable();
        private int idEstablecimientoAnterior = 0;
        private int idGiro = 0;
        private int idMoneda = 0;
        private const int idTipoOpeRegimenReforzado = 179;
        #endregion


        #region Constructor
        public frmCambioDestinoGiro()
        {
            InitializeComponent();
        }
        #endregion


        #region Eventos
        private void frmCambioDestinoGiro_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            this.cboMotivoOperacion1.ListarMotivoOperacion(this.idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            this.cboMotivoOperacion1.SelectedIndex = 0;
            clsCNGenVariables cnGenVar = new clsCNGenVariables();
            this.idTipoOperacion = Convert.ToInt32(cnGenVar.RetornaVariable("idTipoOpeCambioDestinoGiro", 0));
            ObtenerTarifario();
            Habilitar(false);
        }
        private void conBusPersonaRemitente_ehEncontrado(object sender, EventArgs e)
        {
            if (conBusPersonaRemitente.lEncontrado)
            {
                conBusPersonaRemitente.Enabled = false;
                Cargar();
            }
            else
            {
                btnGrabar.Enabled = false;
                cboEstablecimiento.Enabled = false;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            Limpiar();
            conBusPersonaRemitente.Focus();
            conBusPersonaRemitente.FocusNumeroDocumento();
            btnGrabar.Enabled = false;
            cboEstablecimiento.Enabled = false;
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(false);
        }

        private void dtgGiros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tarifa = ObtenerTarifa(
                    Convert.ToDecimal(dtgGiros.Rows[e.RowIndex].Cells["nMontoGiro"].Value.ToString()),
                    Convert.ToInt32(dtgGiros.Rows[e.RowIndex].Cells["idMoneda"].Value.ToString()),
                    conBusPersonaRemitente.idTipoPersonaBusqueda
                    );
                if(tarifa == null)
                {
                    MessageBox.Show("No se tiene configurada una tarifa para esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    cboEstablecimiento.SelectedValue = idEstablecimientoAnterior = Convert.ToInt32(dtgGiros.Rows[e.RowIndex].Cells["idEstablecimientoDestinatario"].Value.ToString());
                    idGiro = Convert.ToInt32(dtgGiros.Rows[e.RowIndex].Cells["idServGiro"].Value.ToString());
                    idMoneda = Convert.ToInt32(dtgGiros.Rows[e.RowIndex].Cells["idMoneda"].Value);
                    txtMontoComision.Text = tarifa.nMontoComision.ToString("N2");
                    conBusPersonaRemitente.setDireccion(dtgGiros.Rows[e.RowIndex].Cells["cDireccion"].Value.ToString());
                    conBusPersonaRemitente.setCelular(dtgGiros.Rows[e.RowIndex].Cells["cCelular"].Value.ToString());
                }                
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

                /*========================================================================================
                * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
                ========================================================================================*/
                clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(0, conBusPersonaRemitente.cNumeroDocumento, clsVarGlobal.nIdAgencia, this.idTipoOperacion, 0);
                if (validaciones.verificPararOperacion())
                {
                    return;
                }
                /*========================================================================================
                * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
                ========================================================================================*/

                //===================================================================
                //--Guardar Pago del Giro
                //===================================================================
                Decimal nComGiro = Convert.ToDecimal(this.txtMontoComision.Text.ToString());

                /*========================================================================================
                * VALIDACIONES PARA REGIMEN DEL CLIENTE
                ========================================================================================*/
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusPersonaRemitente.idCliente,
                                                                                   idMoneda,
                                                                                   0,
                                                                                   idGiro,
                                                                                  nComGiro);
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                {
                    return;
                }
                /*========================================================================================
                * FIN - VALIDACIONES PARA REGIMEN DEL CLIENTE
                ========================================================================================*/
                DataTable tbRegGiro = objCNControlServ.CNRegistrarCambioDestinoGiro(
                                                                            idGiro,
                                                                            Convert.ToInt32(cboEstablecimiento.SelectedValue),
                                                                            clsVarGlobal.nIdAgencia,
                                                                            Convert.ToDecimal(txtMontoComision.Text),
                                                                            clsVarGlobal.User.idUsuario,
                                                                            clsVarGlobal.dFecSystem,
                                                                            clsVarGlobal.idCanal,
                                                                            Convert.ToInt32(cboMotivoOperacion1.SelectedValue),
                                                                            idMoneda,
                                                                            idProducto,
                                                                            true,
                                                                            1);

                if (Convert.ToInt32(tbRegGiro.Rows[0]["idRpta"].ToString()) == 0)
                {
                    MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRegGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRegGiro.Rows[0]["nNroOperacion"].ToString(), "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                    int idKardex = Convert.ToInt32(tbRegGiro.Rows[0]["nNroOperacion"]);
                    ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(txtMontoComision.Text), 0, 0, 1);
                    Limpiar();
                    Habilitar(false);
                }
                else
                {
                    MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString(), "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #endregion


        #region Metodos
        private void Habilitar(bool lHabilitado = true)
        {
            btnNuevo.Enabled = !lHabilitado;
            btnGrabar.Enabled = lHabilitado;
            btnCancelar.Enabled = lHabilitado;
            cboEstablecimiento.Enabled = lHabilitado;
            conBusPersonaRemitente.Enabled = lHabilitado;
            dtgGiros.Enabled = lHabilitado;
        }
        private void Limpiar()
        {
            cboEstablecimiento.SelectedIndex = 0;
            txtMontoComision.Text = "0.00";
            dtGiros = new DataTable();
            dtgGiros.DataSource = dtGiros;
            conBusPersonaRemitente.Reiniciar();
        }
        private void ObtenerTarifario()
        {
            DataTable dt = objCNControlServ.CNObtenerTarifarioFiltro((int)GiroTarifarioTipo.CambioDestino);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    var objTarifa = new clsTarifarioGiros();
                    objTarifa.idGiroTarifario = Convert.ToInt32(item["idGiroTarifario"]);
                    objTarifa.idMoneda = Convert.ToInt32(item["idMoneda"]);
                    objTarifa.idTipoPersona = Convert.ToInt32(item["idTipoPersona"]);
                    objTarifa.idTipComGiro = Convert.ToInt32(item["idTipComGiro"]);
                    objTarifa.nMontoMinimo = Convert.ToDecimal(item["nMontoMinimo"]);
                    objTarifa.nMontoMaximo = Convert.ToDecimal(item["nMontoMaximo"]);
                    objTarifa.nMontoComision = Convert.ToDecimal(item["nMontoComision"]);
                    lstTarifario.Add(objTarifa);
                }
            }
        }
        private clsTarifarioGiros ObtenerTarifa(decimal nMonto, int idMoneda, int idTipoPersona)
        {
            var result = (from item in lstTarifario
                          where idMoneda == item.idMoneda &&
                              nMonto >= item.nMontoMinimo &&
                              nMonto <= item.nMontoMaximo &&
                              idTipoPersona == item.idTipoPersona
                          select item).ToList<clsTarifarioGiros>();
            if (result.Count > 0)
                return result[0];
            else
                return null;
            
        }
        private void Cargar()
        {
            dtGiros = objCNControlServ.CNListarGirosPendientesXRemitente(conBusPersonaRemitente.idTipoDocumento, conBusPersonaRemitente.cNumeroDocumento);
            if (dtGiros.Rows.Count > 0)
            {
                dtgGiros.DataSource = dtGiros;
                FormatearDtgGiros();
                dtgGiros.Focus();
                btnGrabar.Enabled = true;
                cboEstablecimiento.Enabled = true;
            }
            else
            {
                MessageBox.Show("La persona no tiene ningún giro pendiente a pagar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = false;
                cboEstablecimiento.Enabled = false;
                conBusPersonaRemitente.Enabled = true;
                conBusPersonaRemitente.Reiniciar();
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusNumeroDocumento();

            }
        }
        private void FormatearDtgGiros()
        {

            foreach (DataGridViewColumn column in dtgGiros.Columns)
            {
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGiros.Columns["nOrden"].Visible = true;
            dtgGiros.Columns["idServGiro"].Visible = true;
            dtgGiros.Columns["dFechaGiro"].Visible = true;
            dtgGiros.Columns["cAgenciaRemite"].Visible = true;
            dtgGiros.Columns["cDestinatario"].Visible = true;
            dtgGiros.Columns["cAgenciaDestino"].Visible = true;
            dtgGiros.Columns["cMoneda"].Visible = true;
            dtgGiros.Columns["nMontoGiro"].Visible = true;
            dtgGiros.Columns["cEstado"].Visible = true;

            dtgGiros.Columns["nOrden"].HeaderText = "N°";
            dtgGiros.Columns["idServGiro"].HeaderText = "Numero de giro";
            dtgGiros.Columns["dFechaGiro"].HeaderText = "Fecha de giro";
            dtgGiros.Columns["cAgenciaRemite"].HeaderText = "Agencia remitente";
            dtgGiros.Columns["cDestinatario"].HeaderText = "Destinatario";
            dtgGiros.Columns["cAgenciaDestino"].HeaderText = "Agencia destino";
            dtgGiros.Columns["cMoneda"].HeaderText = "Moneda";
            dtgGiros.Columns["nMontoGiro"].HeaderText = "Monto";
            dtgGiros.Columns["cEstado"].HeaderText = "Estado";

            int nOrden = 0;
            dtgGiros.Columns["nOrden"].DisplayIndex = nOrden++;
            dtgGiros.Columns["idServGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["dFechaGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cAgenciaRemite"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cDestinatario"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cAgenciaDestino"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cMoneda"].DisplayIndex = nOrden++;
            dtgGiros.Columns["nMontoGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cEstado"].DisplayIndex = nOrden++;

        }
        private bool Validar()
        {
            if (cboEstablecimiento.SelectedIndex < 0 || Convert.ToInt32(cboEstablecimiento.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar el destino del giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstablecimiento.Focus();
                return false;
            }
            if (idEstablecimientoAnterior == Convert.ToInt32(cboEstablecimiento.SelectedValue))
            {
                MessageBox.Show("La Agencia Nueva, Debe Ser Distinto al Actual", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstablecimiento.Focus();
                return false;
            }
            return true;
        }
        #endregion




    }
}
