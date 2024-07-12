using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CRE.Presentacion
{
    public partial class frmSolicitudAmortizacion : frmBase
    {

        #region Variables

        int idCli = 0;
        clslisDetSolAmortiza listaAmortizacion = new clslisDetSolAmortiza();
        clsCNSolicitudAmortiza cnsoliAmortiza = new clsCNSolicitudAmortiza();
        clsSolicitudAmortiza soliAmortiza = new clsSolicitudAmortiza();
        clslisDetSolAmortiza detalleAmortiza = new clslisDetSolAmortiza();
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsCNRetornsCuentaSolCliente objNumCreSol = new clsCNRetornsCuentaSolCliente();

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);

            btnAsignar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            LimpiarControles();
            idCli = conBusCli.idCli;
            if (idCli == 0)
            {
                dtgCreditos.DataSource = null;
                btnAsignar.Enabled = false;
                btnQuitar.Enabled = false;
                return;
            }
                        
            DataTable dtbNumCuentas = objNumCreSol.CNRetDetCuentasVinculadas(idCli,2);//2=>Refinanciación
            if (dtbNumCuentas.Rows.Count > 0)
            {
                dtgCreditos.DataSource = dtbNumCuentas;
                this.FormatoGrid(); 
                asignarColorSeleccion();
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAsignar.Enabled = true;
                btnQuitar.Enabled = true;
                btnEliminar.Visible = false;
                conBusCli.Enabled = false;
            }
            else
            {
                dtgCreditos.DataSource = null;
                btnAsignar.Enabled = false;
                btnQuitar.Enabled = false;

                MessageBox.Show("Cliente seleccionado no tiene créditos vinculados a una solicitud de refinanciación", "Validación de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli.limpiarControles();
                conBusCli.txtCodCli.Enabled = true;
                conBusCli.btnBusCliente.Enabled = true;
                conBusCli.Focus();
                conBusCli.txtCodCli.Focus();
                conBusCli.txtCodCli.Select();
                return;
            }

            soliAmortiza = cnsoliAmortiza.retornarDatSolAmortiza(idCli);
            if (soliAmortiza != null && soliAmortiza.listaDetalle.Count(x => x.idEstado == 1) > 0)
            {
                dtgAmortizacion.DataSource = soliAmortiza.listaDetalle;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAsignar.Enabled = false;
                btnQuitar.Enabled = false;

                if (soliAmortiza.listaDetalle.Where(x => x.idEstado == 2).Count() > 0)
                {
                    btnEliminar.Visible = false;
                }
                else
                {
                    btnEliminar.Visible = true;
                }

                dtgCreditos.Enabled = false;
                dtgAmortizacion.Enabled = false;

                MessageBox.Show("Ya se tiene una solicitud registrada pendiente de cobro", "Solicitud de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgCreditos.Enabled = true;
                dtgAmortizacion.Enabled = true;
                btnCancelar.Enabled = true;

                this.grbBase1.Enabled = true;
                this.grbBase2.Enabled = true;
                this.grbDistribucion.Enabled = true;
            }

        }

        private void txtCapitalAmo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCapitalAmo.Text))
            {
                txtCapitalAmo.Text = "0.00";
                CalcularTipoCambio();
                SumarTotales();
                return;
            }
            if (txtCapitalAmo.nDecValor > txtCapital.nDecValor)
            {
                MessageBox.Show("Debe asignar un monto menor igual al saldo capital", "Validación Capital", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapitalAmo.Text = "0.00";
            }
            txtCapitalAmo.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(txtCapitalAmo.Text));
            CalcularTipoCambio();
            SumarTotales();
        }

        private void txtInteresAmo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInteresAmo.Text))
            {
                txtInteresAmo.Text = "0.00";
                CalcularTipoCambio();
                SumarTotales();
                return;
            }
            if (txtInteresAmo.nDecValor > txtInteres.nDecValor && txtInteres.nDecValor > 0.00M)
            {
                MessageBox.Show("Debe asignar un monto menor igual al interes", "Validación Interes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInteresAmo.Text = "0.00";
            }
            txtInteresAmo.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(txtInteresAmo.Text));
            CalcularTipoCambio();
            SumarTotales();
        }

        private void txtIntCompAmo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIntCompAmo.Text))
            {
                txtIntCompAmo.Text = "0.00";
                CalcularTipoCambio();
                SumarTotales();
                return;
            }
            if (txtIntCompAmo.nDecValor > txtIntComp.nDecValor && txtIntComp.nDecValor > 0.00M)
            {
                MessageBox.Show("Debe asignar un monto menor igual al interes", "Validación Interes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIntCompAmo.Text = "0.00";
            }
            txtIntCompAmo.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(txtIntCompAmo.Text));
            CalcularTipoCambio();
            SumarTotales();
        }

        private void txtMoraAmo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMoraAmo.Text))
            {
                txtMoraAmo.Text = "0.00";
                CalcularTipoCambio();
                SumarTotales();
                return;
            }
            if (txtMoraAmo.nDecValor > txtMora.nDecValor)
            {
                MessageBox.Show("Debe asignar un monto menor igual a la mora", "Validación Mora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoraAmo.Text = "0.00";
            }
            txtMoraAmo.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(txtMoraAmo.Text));
            CalcularTipoCambio();
            SumarTotales();
        }

        private void txtGastosAmo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGastosAmo.Text))
            {
                txtGastosAmo.Text = "0.00";
                CalcularTipoCambio();
                SumarTotales();
                return;
            }
            if (txtGastosAmo.nDecValor > txtGastos.nDecValor)
            {
                MessageBox.Show("Debe asignar un monto menor igual a los gastos", "Validación Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGastosAmo.Text = "0.00";
            }
            txtGastosAmo.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(txtGastosAmo.Text));
            CalcularTipoCambio();
            SumarTotales();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (txtTotalAmo.nDecValor < 0.0M)
            {
                MessageBox.Show("Por favor ingresar montos válidos", "Asignar Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgCreditos.CurrentRow != null)
            {
                if (listaAmortizacion == null)
                {
                    listaAmortizacion = new clslisDetSolAmortiza();
                }
                var nExiste = listaAmortizacion.Exists(x => x.idCuenta == (int)dtgCreditos.CurrentRow.Cells["idCuenta"].Value);
                if (nExiste)
                {
                    MessageBox.Show("Ya se agregó la cuenta seleccionada \n para modificar debe quitar y volver a asignar", "Asignar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //Validar que no exista una solicitud pendiente o aprobada

                    DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(Convert.ToInt32(conBusCli.idCli), (int)dtgCreditos.CurrentRow.Cells["idCuenta"].Value);
                    if (SolicDuplicada.Rows.Count > 0)
                    {
                        MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                        "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        btnGrabar.Enabled = false;
                        btnCancelar.Enabled = true;
                        return;
                    }
                    listaAmortizacion.Add(new clsDetSolAmortiza()
                    {
                        idCuenta = (int)dtgCreditos.CurrentRow.Cells["idCuenta"].Value,
                        nCapital = txtCapitalAmo.nDecValor,
                        nInteres = txtInteresAmo.nDecValor,
                        nIntComp = txtIntCompAmo.nDecValor,
                        nMora = txtMoraAmo.nDecValor,
                        nGastos = txtGastosAmo.nDecValor
                    });

                    dtgAmortizacion.DataSource = null;
                    dtgAmortizacion.DataSource = listaAmortizacion;
                }
            }
            if (dtgAmortizacion.RowCount > 0)
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgAmortizacion.RowCount > 0)
            {
                var item = (clsDetSolAmortiza)dtgAmortizacion.CurrentRow.DataBoundItem;
                listaAmortizacion.Remove(item);
                dtgAmortizacion.DataSource = null;
                dtgAmortizacion.DataSource = listaAmortizacion;
            }
            if (dtgAmortizacion.RowCount > 0)
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            conBusCli.limpiarControles();
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAsignar.Enabled = false;
            btnQuitar.Enabled = false;
            btnEliminar.Visible = false;

            conBusCli.Enabled = true;
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.txtCodCli.Focus();

            txtTotalAmo.Enabled = false;
            txtCapitalAmo.Enabled = false;
            txtInteresAmo.Enabled = false;
            txtIntCompAmo.Enabled = false;
            txtMoraAmo.Enabled = false;
            txtGastosAmo.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Inicio - Registro de Solicitud Amortización", btnGrabar);
            if (soliAmortiza == null)
            {
                soliAmortiza = new clsSolicitudAmortiza();
            }
            if (detalleAmortiza == null)
            {
                detalleAmortiza = new clslisDetSolAmortiza();
            }
            soliAmortiza.idSolicitudAmortiza = 0;
            soliAmortiza.idCli = conBusCli.idCli;
            soliAmortiza.idSolicitud =  (int)dtgCreditos.Rows[0].Cells["idSolicitud"].Value;
            soliAmortiza.idUsuReg = clsVarGlobal.User.idUsuario;
            soliAmortiza.dFechaReg = clsVarGlobal.dFecSystem;
            soliAmortiza.idEstado = 1;

            foreach (var item in listaAmortizacion)
            {
                detalleAmortiza.Add(new clsDetSolAmortiza()
                {
                    idCuenta = item.idCuenta,
                    nCapital = item.nCapital,
                    nInteres = item.nInteres,
                    nIntComp = item.nIntComp,
                    nMora = item.nMora,
                    nGastos = item.nGastos,
                    idEstado = 1,
                    dFechaReg = clsVarGlobal.dFecSystem,
                    idDetSolAmortiza = 0,
                    idSolicitudAmortiza = 0,
                    idUsuReg = clsVarGlobal.User.idUsuario

                });

            }
            cnsoliAmortiza.insertaActSolAmortiza(soliAmortiza, detalleAmortiza);

            MessageBox.Show("Se registró de manera correcta la Solicitud de Amortización", "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnGrabar.Enabled = false;
            btnAsignar.Enabled = false;
            btnQuitar.Enabled = false;
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Fin - Registro de Solicitud Amortización", btnGrabar);
            this.grbBase1.Enabled = false;
            this.grbBase2.Enabled = false;
            this.grbDistribucion.Enabled = false;
            this.dtgCreditos.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Desea eliminar la solicitud de Amortización", "Eliminar Solicitud", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                soliAmortiza.idEstado = 0;
                soliAmortiza.listaDetalle.ForEach(x => x.idEstado = 0);
                soliAmortiza.listaDetalle.ForEach(x => x.dFechaReg = clsVarGlobal.dFecSystem);
                soliAmortiza.listaDetalle.ForEach(x => x.idUsuReg = clsVarGlobal.User.idUsuario);

                cnsoliAmortiza.insertaActSolAmortiza(soliAmortiza, soliAmortiza.listaDetalle);
                MessageBox.Show("Se eliminó de manera correcta la Solicitud de Amortización", "Eliminar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEliminar.Visible = false;
            }
        }

        private void dtgCreditos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCreditos.CurrentRow != null)
            {
                int idCuentaCre = (int)dtgCreditos.CurrentRow.Cells["idcuenta"].Value;
                CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
                clsCredito entCredito = credito.retornaDatosCredito(idCuentaCre);

                LimpiarMontosAmortizacion();

                txtCapital.Text = String.Format("{0:#,0.00}", entCredito.nCapitalDesembolso - entCredito.nCapitalPagado);
                txtInteres.Text = String.Format("{0:#,0.00}", entCredito.nInteresDia - entCredito.nInteresPagado);
                txtIntComp.Text = String.Format("{0:#,0.00}", entCredito.nInteresComp - entCredito.nInteresCompPago);
                txtMora.Text = String.Format("{0:#,0.00}", entCredito.nMoraGenerado - entCredito.nMoraPagada);
                txtGastos.Text = String.Format("{0:#,0.00}", entCredito.nOtrosGenerado - entCredito.nOtrosPagado);

                ActivarSeleccion();
                CalcularTipoCambio();
                SumarTotales();
            }

        }

        #endregion

        #region Métodos

        public frmSolicitudAmortizacion()
        {
            InitializeComponent();
        }

        private void FormatoGrid()
        {
            foreach (DataGridViewColumn item in dtgCreditos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditos.Columns["dFecDesembolso"].Visible = true;
            dtgCreditos.Columns["cProducto"].Visible = true;
            dtgCreditos.Columns["cMoneda"].Visible = true;
            dtgCreditos.Columns["nCuotas"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cod.Cuenta";
            dtgCreditos.Columns["nCapitalDesembolso"].HeaderText = "Monto Desembolsado";
            dtgCreditos.Columns["dFecDesembolso"].HeaderText = "Fec. Desembolso";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditos.Columns["nCuotas"].HeaderText = "N° Cuotas";

            dtgCreditos.Columns["idCuenta"].Width = 80;
            dtgCreditos.Columns["nCapitalDesembolso"].Width = 100;
            dtgCreditos.Columns["dFecDesembolso"].Width = 120;
            dtgCreditos.Columns["cMoneda"].Width = 80;
            dtgCreditos.Columns["nCuotas"].Width = 60;

            dtgCreditos.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;

            dtgCreditos.ClearSelection();
        }

        private void LimpiarMontosAmortizacion()
        {
            txtCapitalAmo.Text = "0.00";
            txtInteresAmo.Text = "0.00";
            txtIntCompAmo.Text = "0.00";
            txtMoraAmo.Text = "0.00";
            txtGastosAmo.Text = "0.00";
        }

        private void ActivarSeleccion()
        {
            txtCapitalAmo.Text = "0.00";
            txtInteresAmo.Text = "0.00";
            txtIntCompAmo.Text = "0.00";
            txtMoraAmo.Text = "0.00";
            txtGastosAmo.Text = "0.00";

            if (txtCapital.nDecValor > 0.0M)
            {
                txtCapitalAmo.Enabled = true;
            }
            else
            {
                txtCapitalAmo.Enabled = false;
            }
            if (txtInteres.nDecValor > 0.0M)
            {
                txtInteresAmo.Enabled = true;
            }
            else
            {
                txtInteresAmo.Enabled = false;
                txtInteresAmo.Text = string.Format("{0:#,0.00}", txtInteres.nDecValor);
            }
            if (txtIntComp.nDecValor > 0.0M)
            {
                txtIntCompAmo.Enabled = true;
            }
            else
            {
                txtIntCompAmo.Enabled = false;
            }
            if (txtMora.nDecValor > 0.0M)
            {
                txtMoraAmo.Enabled = true;
            }
            else
            {
                txtMoraAmo.Enabled = false;
            }
            if (txtGastos.nDecValor > 0.0M)
            {
                txtGastosAmo.Enabled = true;
            }
            else
            {
                txtGastosAmo.Enabled = false;
            }
        }

        private void SumarTotales()
        {
            txtTotalAmo.Text = string.Format("{0:#,0.00}", txtCapitalAmo.nDecValor +
                                                         txtInteresAmo.nDecValor +
                                                         txtIntCompAmo.nDecValor +
                                                         txtMoraAmo.nDecValor +
                                                         txtGastosAmo.nDecValor);

            txtSaldoCredito.Text = string.Format("{0:#,0.00}", txtCapital.nDecValor +
                                                             txtInteres.nDecValor +
                                                             txtIntComp.nDecValor +
                                                             txtMora.nDecValor +
                                                             txtGastos.nDecValor);

            txtTotalSol.Text = string.Format("{0:#,0.00}", txtCapitalSol.nDecValor +
                                                         txtInteresSol.nDecValor +
                                                         txtIntCompSol.nDecValor +
                                                         txtMoraSol.nDecValor +
                                                         txtGastosSol.nDecValor);
        }

        private void CalcularTipoCambio()
        {
            if (dtgCreditos.CurrentRow != null)
            {
                int idMoneda = (int)dtgCreditos.CurrentRow.Cells["idMoneda"].Value;
                decimal nTipoCambio = (decimal)clsVarApl.dicVarGen["nTipoCambio"];
                if (idMoneda == 2)
                {
                    txtCapitalSol.Text = string.Format("{0:#,0.00}", Math.Round(txtCapitalAmo.nDecValor * nTipoCambio, 2));
                    txtInteresSol.Text = string.Format("{0:#,0.00}", Math.Round(txtInteresAmo.nDecValor * nTipoCambio, 2));
                    txtIntCompSol.Text = string.Format("{0:#,0.00}", Math.Round(txtIntCompAmo.nDecValor * nTipoCambio, 2));
                    txtMoraSol.Text = string.Format("{0:#,0.00}", Math.Round(txtMoraAmo.nDecValor * nTipoCambio, 2));
                    txtGastosSol.Text = string.Format("{0:#,0.00}", Math.Round(txtGastosAmo.nDecValor * nTipoCambio, 2));
                }
                else
                {
                    txtCapitalSol.Text = txtCapitalAmo.Text;
                    txtInteresSol.Text = txtInteresAmo.Text;
                    txtIntCompSol.Text = txtIntCompAmo.Text;
                    txtMoraSol.Text = txtMoraAmo.Text;
                    txtGastosSol.Text = txtGastosAmo.Text;
                }
            }

        }

        private void LimpiarControles()
        {
            dtgAmortizacion.DataSource = null;
            dtgCreditos.DataSource = null;

            txtTotalAmo.Text = "0.00";
            txtCapitalAmo.Text = "0.00";
            txtInteresAmo.Text = "0.00";
            txtIntCompAmo.Text = "0.00";
            txtMoraAmo.Text = "0.00";
            txtGastosAmo.Text = "0.00";

            txtSaldoCredito.Text = "0.00";
            txtCapital.Text = "0.00";
            txtInteres.Text = "0.00";
            txtIntComp.Text = "0.00";
            txtMora.Text = "0.00";
            txtGastos.Text = "0.00";

            txtTotalSol.Text = "0.00";
            txtCapitalSol.Text = "0.00";
            txtInteresSol.Text = "0.00";
            txtIntCompSol.Text = "0.00";
            txtMoraSol.Text = "0.00";
            txtGastosSol.Text = "0.00";

            listaAmortizacion = null;
        }

        private void asignarColorSeleccion()
        {
            foreach (DataGridViewRow row in dtgCreditos.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        #endregion
    }
}
