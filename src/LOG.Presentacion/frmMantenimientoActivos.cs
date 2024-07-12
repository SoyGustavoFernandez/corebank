using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using LOG.CapaNegocio;
using CAJ.Presentacion;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;


namespace LOG.Presentacion
{
    public partial class frmMantenimientoActivos : frmBase
    {

        #region Variables

        clsCNActivos objCNActivos = new clsCNActivos();
        clsActivo objActivo;
        DataTable dtCargoEntrega = new DataTable();

        #endregion

        #region Eventos
        private void frmMantenimientoActivos_Load(object sender, EventArgs e)
        {
            txtValorComp.Text = "0.00";
            txtMontoDeprec.Text = "0.00";
            txtValActual.Text = "0.00";

            LimpiarControles();
            IniForm();
            cboGrupo.SelectedIndexChanged -= new EventHandler(cboGrupo_SelectedIndexChanged);
            cboGrupo.ListarGruposActivos(0);
            cboGrupo.SelectedIndex = -1;
            cboGrupo.SelectedIndexChanged += new EventHandler(cboGrupo_SelectedIndexChanged);
            FormatoControles();
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupo.SelectedValue is DataRowView) return;
            if (cboGrupo.SelectedIndex >= 0)
            {                
                cboSubGrupo.ListarGruposActivos(Convert.ToInt32(cboGrupo.SelectedValue));
                cboSubGrupo.SelectedIndex = -1;
            }
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubGrupo.SelectedValue is DataRowView) return;
            if (cboSubGrupo.SelectedIndex >= 0)
            {
                cboRubro.ListarGruposActivos(Convert.ToInt32(cboSubGrupo.SelectedValue));
                cboRubro.SelectedIndex = -1;
            }
        }

        private void cboRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRubro.SelectedValue is DataRowView) return;
            if (cboRubro.SelectedIndex >= 0)
            {
                cboProdCatalogo.ListarProductosCatalogo(Convert.ToInt32(cboRubro.SelectedValue));
                cboProdCatalogo.SelectedIndex = -1;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            objActivo = new clsActivo();
            ActControles(true);
            LimpiarControles();
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnImprimir.Enabled = false;
            BuscaColaboradorResp();
        }

        private void btnBusActivo_Click(object sender, EventArgs e)
        {
            FrmBuscaActivo FrmBuscaActivo = new FrmBuscaActivo();
            FrmBuscaActivo.ShowDialog();
            objActivo = new clsActivo(FrmBuscaActivo.pidActivo);

            if (objActivo.idActivo == 0)
            {
                MessageBox.Show("No seleccionó ningun Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                BuscaActivo(objActivo.idActivo);
            }
        }

        private void btnBusqCol_Click(object sender, EventArgs e)
        {
            LimpiaColaborador();
            BuscaColaborador();    
        }

        private void btnBuscProveedor_Click(object sender, EventArgs e)
        {
            LimpiaProveedor();
            BuscaProveedor();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Valida())
                return;

            objActivo.idCatalogo = Convert.ToInt32(cboProdCatalogo.SelectedValue);
            objActivo.idTipoActivo = 1;
            objActivo.cColor = Convert.ToString(txtColor.Text);
            objActivo.cMaterial = Convert.ToString(txtMaterial.Text);
            objActivo.cRubro = Convert.ToString(txtRubro.Text);
            objActivo.cMarca = Convert.ToString(txtMarca.Text);
            objActivo.cSerie = Convert.ToString(txtSerie.Text);
            objActivo.cModelo = Convert.ToString(txtModelo.Text);
            objActivo.dFechaActivacion = chcActivado.Checked ? Convert.ToDateTime(dtpFecActivac.Value) : (DateTime?)null;
            objActivo.idEstadoActivo = chcActivado.Checked ? 2 : 1;
            objActivo.dFechaCompra = Convert.ToDateTime(dtpFecCompra.Value);
            objActivo.nPorcDeprec = txtPorcDeprec.nDecValor;
            objActivo.nMontoDeprec = txtMontoDeprec.nDecValor;
            objActivo.nValorActual = txtValActual.nDecValor;
            objActivo.cSerieCpg = Convert.ToString(txtSerieCpg.Text);
            objActivo.cNumeroCpg = Convert.ToString(txtNumeroCpg.Text);
            objActivo.idTipComPag = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
            objActivo.idUsuReg = clsVarGlobal.User.idUsuario;
            objActivo.idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            objActivo.cUbicActivo = txtUbicacion.Text;
            objActivo.cCodInstActivo = txtCodInstActivo.Text;
            objActivo.cObsActiv = txtObserv.Text;
            objActivo.nValorCompra = txtValorComp.nDecValor;
            objActivo.dFechaReg = clsVarGlobal.dFecSystem;

            objActivo.nAdquisicionAdicion = Convert.ToDecimal(txtAdquisicionesAdiciones.Text);
            objActivo.nMejoras = Convert.ToDecimal(txtMejoras.Text);
            objActivo.nAjusteInflacion = Convert.ToDecimal(txtAjusteInflacion.Text);

            DataTable dtInsActivos = objCNActivos.CNGuardarActivos(objActivo);
            MessageBox.Show("El Activo se registro Correctamente", "Registro de Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActControles(false);
            dtpFecActivac.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void txtCodActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtCodActivo.Text))
                {
                    MessageBox.Show("No se encuentra datos del código de Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                objActivo = new clsActivo(Convert.ToInt32(txtCodActivo.Text));
                BuscaActivo(objActivo.idActivo);
            }
        } 

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            IniForm();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActControles(true);
            txtCodActivo.Enabled = false;
            btnBusActivo.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            dtpFecActivac.Enabled = chcActivado.Checked;
        }

        private void chcActivado_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecActivac.Enabled = chcActivado.Checked;
        }

        private void btnBusCpg_Click(object sender, EventArgs e)
        {
            frmBuscarComprPago frmBusCpg = new frmBuscarComprPago();
            frmBusCpg.chcTieneComprobante.Checked = true;
            frmBusCpg.chcCajChic.Checked = chcCajaChica.Checked;
            frmBusCpg.ShowDialog();

            if (frmBusCpg.pidComprobantePago == 0)
            {
                MessageBox.Show("No se seleccionó ningun comprobante de pago.", "Mantenimiento de activos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BuscarComprobante(frmBusCpg.pidComprobantePago);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idMovimiento = Convert.ToInt32(dtCargoEntrega.Rows[0]["idMovimiento"]);
            if (idMovimiento != -1)
            {
                // nuevas opciones de impresion //////////////////////////////////////////
                int nIdTipoImpresion = Convert.ToInt32(cboTipodeImpresion.SelectedValue);

                if (nIdTipoImpresion != 1)
                {
                    if (nIdTipoImpresion == 2)
                    {
                        int nIdMovimiento = idMovimiento;
                        ImprimirFormatoParaMoviles(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 3)
                    {
                        int nIdMovimiento = idMovimiento;
                        ImprimirFormatoParaComputadores(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 4)
                    {
                        int nIdMovimiento = idMovimiento;
                        ImprimirFormatoParaCamionetas(nIdMovimiento);
                        return;
                    }
                    if (nIdTipoImpresion == 5)
                    {
                        int nIdMovimiento = idMovimiento;
                        ImprimirFormatoParaMotos(nIdMovimiento);
                        return;
                    }
                }
                // end nuevas opciones de impresion //////////////////////////////////////////


                String cNomAgen = clsVarGlobal.cNomAge;
                String cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsactivos", new clsCNActivos().CNActivos(idMovimiento)));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idMovimiento", idMovimiento.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));

                string reportpath = "RptAsigActivo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("El Activo se ha asignado aun", "Registrar Asignación del Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Constructor
        public frmMantenimientoActivos()
        {
            InitializeComponent();

            var dtTiposCargoEntrega = objCNActivos.CNlistaTipoEncargo();
            cboTipodeImpresion.DataSource = dtTiposCargoEntrega;
            cboTipodeImpresion.ValueMember = dtTiposCargoEntrega.Columns[0].ToString();
            cboTipodeImpresion.DisplayMember = dtTiposCargoEntrega.Columns[1].ToString();
        }
        #endregion

        #region Metodos
        private void IniForm()
        { 
            txtCodActivo.Enabled = true;
            btnBusActivo.Enabled = true;
            cboGrupo.Enabled = false;
            cboSubGrupo.Enabled = false;
            cboRubro.Enabled = false;
            cboProdCatalogo.Enabled = false;
            txtRubro.Enabled = false;
            txtMarca.Enabled = false;
            txtSerie.Enabled = false;
            txtModelo.Enabled = false;
            txtColor.Enabled = false;
            txtMaterial.Enabled = false;          
            txtObserv.Enabled = false;
            txtColabResp.Enabled = false;
            btnBusqCol.Enabled = false;
            cboAgencias.Enabled = false;
            txtUbicacion.Enabled = false;
            dtpFecCompra.Enabled = false;
            txtValorComp.Enabled = false;
            txtPorcDeprec.Enabled = false;
            txtMontoDeprec.Enabled = false;
            txtValActual.Enabled = false;   
            txtDocProveed.Enabled = false;
            btnBuscProveedor.Enabled = false; 
            txtNomProvee.Enabled = false;
            txtSerieCpg.Enabled = false;
            txtNumeroCpg.Enabled = false;
            chcActivado.Enabled = false;
            dtpFecActivac.Enabled = false;
            cboTipoComprobantePago.Enabled = false;
            txtCodInstActivo.Enabled = false;
            btnBusCpg.Enabled = false;
            chcCajaChica.Enabled = false;
            // agregado
            txtAdquisicionesAdiciones.Enabled = false;
            txtMejoras.Enabled = false;
            txtAjusteInflacion.Enabled = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            txtCodActivo.Focus();
          
            cboGrupo.ListarGrupo(0, 1);
            cboGrupo.SelectedIndex = -1;
        }

        public void BuscaActivo(int idActivo)
        {
            List<clsActivo> LstActivos = objCNActivos.CNListaActivos(idActivo);
            if (LstActivos.Count > 0)
            {
                objActivo = LstActivos.First();
                if(objActivo.idEstadoActivo == 3)
                {
                    MessageBox.Show("El activo se encuentra en estado BAJA/DETERIORADO.", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                    btnGrabar.Enabled = false;

                    return;
                }
                MapEntidadActivoControls(objActivo);
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
                dtpFecActivac.Enabled = false;

                // funcionalidades de impresion de cargo de entrega
                btnImprimir.Enabled = true;
                dtCargoEntrega = objCNActivos.CNUltCargoEntrega(idActivo, 3);

                if (dtCargoEntrega.Rows.Count > 0) {
                    cboTipodeImpresion.SelectedValue = Convert.ToInt32(dtCargoEntrega.Rows[0]["idTipoCargoEntrega"]);
                    if (Convert.ToInt32(dtCargoEntrega.Rows[0]["idMovimiento"]) == -1)
                    {
                        btnImprimir.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encuentra datos del código ingresado o el activo no se encuentra vigente", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                btnGrabar.Enabled = false;

                return;
            }
        }

        private void LimpiaColaborador()
        {
            txtColabResp.Text = string.Empty;
            cboAgencias.SelectedIndex = -1;
        }

        private void BuscaColaborador()
        {
            FrmBusCol frmColaborador = new FrmBusCol();
            frmColaborador.ShowDialog();
            if (!string.IsNullOrEmpty(Convert.ToString(frmColaborador.idUsu)))
            {
                objActivo.idUsuResp = Convert.ToInt32(frmColaborador.idUsu);
                txtColabResp.Text = frmColaborador.cNom;
                cboAgencias.SelectedValue = frmColaborador.nidAgencia;
            }
            else
            {
                LimpiaColaborador();
            }
        }
        private void BuscaColaboradorResp()
        {
            clsCNBuscaPersonal lisPer = new clsCNBuscaPersonal();
            DataTable dtPer = lisPer.BusPerByCod(clsVarGlobal.User.idUsuario,1);//corregir se agrego estado 1
            objActivo.idUsuResp = Convert.ToInt32(dtPer.Rows[0]["idUsuario"]);
            txtColabResp.Text = dtPer.Rows[0]["cNombre"].ToString();
            cboAgencias.SelectedValue = Convert.ToInt32(dtPer.Rows[0]["idAgencia"]);
        }

        private void LimpiaProveedor()
        {
            txtDocProveed.Text = string.Empty;
            txtNomProvee.Text = string.Empty;
        }

        private void BuscaProveedor()
        {
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

            if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo))
            {
                objActivo.idCliProveedor = Convert.ToInt32(frmbuscarcli.pcCodCli);
                txtDocProveed.Text = frmbuscarcli.pcNroDoc;
                txtNomProvee.Text = frmbuscarcli.pcNomCli;
            }
            else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
            {
                LimpiaProveedor();
            }
        }

        private void ActControles(bool lactivar)
        {
            txtCodActivo.Enabled = !lactivar;
            btnBusActivo.Enabled = !lactivar;
            txtColor.Enabled = lactivar;
            txtMaterial.Enabled = lactivar;
            txtRubro.Enabled = lactivar;
            txtMarca.Enabled = lactivar;
            txtSerie.Enabled = lactivar;
            txtModelo.Enabled = lactivar;
            cboProdCatalogo.Enabled = lactivar;
            txtObserv.Enabled = lactivar;
            txtUbicacion.Enabled = lactivar;
            txtValorComp.Enabled = lactivar;
            txtPorcDeprec.Enabled = lactivar;
            txtMontoDeprec.Enabled = lactivar;
            txtValActual.Enabled = lactivar;
            //txtSerieCpg.Enabled = lactivar;
            //txtNumeroCpg.Enabled = lactivar;
            cboGrupo.Enabled = lactivar;
            cboSubGrupo.Enabled = lactivar;
            cboRubro.Enabled = lactivar;
            //cboTipoComprobantePago.Enabled = lactivar;
            txtCodInstActivo.Enabled = lactivar;
            btnBusCpg.Enabled = lactivar;
            chcCajaChica.Enabled = lactivar;
            //cboAgencias.Enabled = lactivar;
            chcActivado.Enabled = lactivar;
            dtpFecCompra.Enabled = lactivar;
            dtpFecActivac.Enabled = chcActivado.Checked;
            btnBusqCol.Enabled = lactivar;
            btnBuscProveedor.Enabled = lactivar;
            
            // agregado
            txtAdquisicionesAdiciones.Enabled = lactivar;
            txtMejoras.Enabled = lactivar;
            txtAjusteInflacion.Enabled = lactivar;

            // impresion
            btnImprimir.Enabled = lactivar;
        }


        private void ImprimirFormatoParaMoviles(int nIdMovimiento)
        {
            frmCargoEntregaMoviles frmcargoentregamoviles = new frmCargoEntregaMoviles(nIdMovimiento);
            frmcargoentregamoviles.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaComputadores(int nIdMovimiento)
        {
            frmCargoEntregaComputadores frmcargoentregacomputadores = new frmCargoEntregaComputadores(nIdMovimiento);
            frmcargoentregacomputadores.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaMotos(int nIdMovimiento)
        {
            frmCargoEntregaMoto frmcargoentregamotos = new frmCargoEntregaMoto(nIdMovimiento);
            frmcargoentregamotos.ShowDialog();
            return;
        }

        private void ImprimirFormatoParaCamionetas(int nIdMovimiento)
        {
            frmCargoEntregaCamionetas frmcargoentregacamionetas = new frmCargoEntregaCamionetas(nIdMovimiento);
            frmcargoentregacamionetas.ShowDialog();
            return;
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(txtCodInstActivo.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el código institucional del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodInstActivo.Focus();
                return false;
            }

            if (cboGrupo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el GRUPO del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboGrupo.Focus();
                return false;
            }

            if (cboSubGrupo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el SUBGRUPO del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboSubGrupo.Focus();
                return false;
            }

            if (cboRubro.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el RUBRO del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboRubro.Focus();
                return false;
            }

            if (cboProdCatalogo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el producto", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProdCatalogo.Focus();
                return false;
            }

            

            if (Convert.ToInt32(cboAgencias.SelectedValue) < 0)
            {
                MessageBox.Show("Debe Seleccionar Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRubro.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el Rubro", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRubro.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar marca", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMarca.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Debe ingresar serie", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSerie.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtColabResp.Text))
            {
                MessageBox.Show("Debe ingresar Colaborador Responsable", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtColabResp.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUbicacion.Text))
            {
                MessageBox.Show("Debe ingresar Ubicacion del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUbicacion.Focus();
                return false;
            }

           
            if (string.IsNullOrEmpty(txtValorComp.Text))
            {
                MessageBox.Show("Debe ingresar Valor de Compra del activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtValorComp.Focus();
                return false;
            }

            if(txtPorcDeprec.nDecValor > 100 || txtPorcDeprec.nDecValor< 0)
            {
                MessageBox.Show("El porcentaje de depreciación tiene que estar en el rango de 0 a 100.", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorcDeprec.Focus();
                return false;
            }

            if (txtMontoDeprec.nDecValor > txtValorComp.nDecValor)
            {
                MessageBox.Show("El monto depreciado no puede ser mayor al valor de compra.", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorcDeprec.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txtCodActivo.Text = string.Empty;
            cboGrupo.SelectedIndex = -1;
            cboSubGrupo.SelectedIndex = -1;
            cboRubro.SelectedIndex = -1;
            cboProdCatalogo.SelectedIndex = -1;
            txtRubro.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtSerie.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtMaterial.Text = string.Empty;
            txtObserv.Text = string.Empty;
            txtColabResp.Text = string.Empty;
            cboAgencias.SelectedIndex = -1;
            txtUbicacion.Text = string.Empty;
            dtpFecCompra.Value = clsVarGlobal.dFecSystem;
            //txtValorComp.Text = string.Empty;
            txtPorcDeprec.Text = string.Empty;
            //txtMontoDeprec.Text = string.Empty;
            //txtValActual.Text = string.Empty;
            dtpFecActivac.Value = clsVarGlobal.dFecSystem;
            txtDocProveed.Text = string.Empty;
            txtNomProvee.Text = string.Empty;
            txtSerieCpg.Text = string.Empty;
            txtNumeroCpg.Text = string.Empty;
            txtCodInstActivo.Text = string.Empty;
            chcCajaChica.Checked = false;
            cboTipoComprobantePago.SelectedIndex = -1;
            chcActivado.Checked = false;
            txtValorComp.Text = "0.00";
            txtMontoDeprec.Text = "0.00";
            txtValActual.Text = "0.00";
            txtPorcDeprec.Text = "0";
            // agregado
            txtAdquisicionesAdiciones.Text = "0.00";
            txtMejoras.Text = "0.00";
            txtAjusteInflacion.Text = "0.00";
        }

        private void MapEntidadActivoControls(clsActivo objActivo)
        {
            txtCodActivo.Text = objActivo.idActivo.ToString();
            txtColor.Text = objActivo.cColor;
            txtMaterial.Text = objActivo.cMaterial;
            txtRubro.Text = objActivo.cRubro;
            txtMarca.Text = objActivo.cMarca;
            txtSerie.Text = objActivo.cSerie;
            txtModelo.Text = objActivo.cModelo;
            
            txtObserv.Text = objActivo.cObsActiv;
            txtValorComp.Text = objActivo.nValorCompra.ToString();
            txtPorcDeprec.Text = objActivo.nPorcDeprec.ToString();
            txtMontoDeprec.Text = objActivo.nMontoDeprec.ToString();
            txtValActual.Text = objActivo.nValorActual.ToString();

            txtSerieCpg.Text = objActivo.cSerieCpg;
            txtNumeroCpg.Text = objActivo.cNumeroCpg;
            txtColabResp.Text = objActivo.cNombreColResp;

            cboGrupo.SelectedValue = objActivo.idSubTipoBien;
            cboSubGrupo.SelectedValue = objActivo.idGrupo;
            cboRubro.SelectedValue = objActivo.idSubGrupo;
            cboProdCatalogo.SelectedValue = objActivo.idCatalogo;
            cboTipoComprobantePago.SelectedValue = objActivo.idTipComPag;
            cboAgencias.SelectedValue = objActivo.idAgencia;
            dtpFecCompra.Value = objActivo.dFechaCompra;
            chcActivado.Checked = objActivo.dFechaActivacion != null;
            dtpFecActivac.Value = objActivo.dFechaActivacion == null ? clsVarGlobal.dFecSystem : Convert.ToDateTime(objActivo.dFechaActivacion);
            txtDocProveed.Text = objActivo.cDocProveedor;
            txtNomProvee.Text = objActivo.cNomProveedor;
            txtUbicacion.Text = objActivo.cUbicActivo;
            txtCodInstActivo.Text = objActivo.cCodInstActivo;

            txtAdquisicionesAdiciones.Text = objActivo.nAdquisicionAdicion.ToString();
            txtMejoras.Text = objActivo.nMejoras.ToString();
            txtAjusteInflacion.Text = objActivo.nAjusteInflacion.ToString();

            FormatoControles();
            //idUsu = Convert.ToInt32(dtListaActivo.Rows[0]["idUsuReg"]);
        }

        private void FormatoControles() 
        {
            txtValorComp.Text = string.IsNullOrEmpty(txtValorComp.Text) ? string.Empty : string.Format("{0:0.00}", Convert.ToDecimal(txtValorComp.Text));
            txtPorcDeprec.Text = string.IsNullOrEmpty(txtPorcDeprec.Text) ? string.Empty : string.Format("{0:0.00}", Convert.ToDecimal(txtPorcDeprec.Text));
            txtMontoDeprec.Text = string.IsNullOrEmpty(txtMontoDeprec.Text) ? string.Empty : string.Format("{0:0.00}", Convert.ToDecimal(txtMontoDeprec.Text));
            txtValActual.Text = string.IsNullOrEmpty(txtValActual.Text) ? string.Empty : string.Format("{0:0.00}", Convert.ToDecimal(txtValActual.Text));
            //dtpFecActivac.Format = DateTimePickerFormat.Long;
            //dtpFecCompra.Format = DateTimePickerFormat.Long;
        }

        private void BuscarComprobante(int idCpg)
        {
            DataTable dtComprPago = new clsCNCajaChica().BuscarComprPago(idCpg);
            if (dtComprPago.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Comprobante...Validar", "Buscar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]) == 3)
            {
                MessageBox.Show("El Comprobante se Encuentra Eliminado", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtSerieCpg.Text = Convert.ToString(dtComprPago.Rows[0]["cSerie"]);
            txtNumeroCpg.Text = Convert.ToString(dtComprPago.Rows[0]["cNumero"]);
            cboTipoComprobantePago.SelectedValue = Convert.ToInt16(dtComprPago.Rows[0]["idTipoComprobantePago"]);
            chcCajaChica.Checked = Convert.ToBoolean(dtComprPago.Rows[0]["lCpgCajChica"]);
        }

        #endregion       

        private void txtValorComp_Leave(object sender, EventArgs e)
        {
            txtValActual.Text = (txtValorComp.nDecValor - txtMontoDeprec.nDecValor).ToString("#,0.00");
        }

        private void txtMontoDeprec_TextChanged(object sender, EventArgs e)
        {
            txtValActual.Text = (txtValorComp.nDecValor - txtMontoDeprec.nDecValor).ToString("#,0.00");
        }

    }
}
