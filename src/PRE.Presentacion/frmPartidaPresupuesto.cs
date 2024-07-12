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
using PRE.CapaNegocio;
using CNT.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmPartidaPresupuesto : frmBase
    {
        #region Variables Globales

        private DataTable dtPartidas;        
        private String cTipoOperacion = "N";    //Puede ser N --> Nuevo, A--> Actualizar, C--> Actualiza cuentas contables
        private int idPartida = 0;
        private int idPadrePartida = 0;
        private int idPlantillaPartida = 0;
        private int idFilaSelecPartida = 0;
        private int idPeriodoPlanificacion = 0;
        private Boolean lEsPlanificacion = true;
        private Boolean lExistenCC = false;
        private String cTituloMensaje = "Registro de partidas presupuestales";

        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        private DataTable dtCuentasCont;

        #endregion         
        public frmPartidaPresupuesto()
        {
            InitializeComponent();
        }
        #region Eventos

        private void frmPartidaPresupuesto_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (this.cboPeriodoPresupuestal1.Items.Count <= 0)
            {
                this.lEsPlanificacion = false;
                habilitarControles(false);
                return;
            }
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            this.cboNivel.DropDownStyle = ComboBoxStyle.DropDownList;            
            this.nudPorcentaje.Maximum = 100;
            this.nudPorcentaje.DecimalPlaces = 2;
            this.txtNombrePartida.CharacterCasing = CharacterCasing.Upper;                        
            this.nudPorcentaje.Minimum = 0;
            this.chcAfectacionSaldo.Checked = true;           
            formatoCboSigno();
            listarPartidas(idPeriodoSelect, Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));
            formatoDTGPartidas();
            verificarEstadoPeriodo();
            habilitarControles(false);            
        }        
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (tieneCuentasContab(idPartida))
            {
                lExistenCC = true;
            } else {
                lExistenCC = false;
            }
            limpiarControles();
            habilitarControles(true);           
            cTipoOperacion = "N";
            this.cboLimAplicaSaldo1.SelectedIndex = 1;
            this.cboNivel.Focus();
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgPartidasPres.Rows.Count <= 0)
            {
                MessageBox.Show("No existen partidas para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            habilitarControles(true);
            cTipoOperacion = "A";
            this.cboNivel.Enabled = false;                                   
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            mostrarDetalles();
            cTipoOperacion = "";
        }
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (this.dtgPartidasPres.Rows.Count <= 0)
            {
                MessageBox.Show("No existen partidas para eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Se eliminará la partida, sub partidas y cuentas contables, ¿Desea continuar eliminando?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                int idPartida = Convert.ToInt32(this.dtgPartidasPres.SelectedRows[0].Cells["idPartida"].Value);
                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                eliminarPartida(idPartida, idUsuReg, dFechaReg);
                int idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
                listarPartidas(idPeriodo, Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));
            }
            habilitarControles(false);                       
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validarDatos())
            { return; }
            int idNivel = Convert.ToInt32( this.cboNivel.SelectedValue);
            int idPeriodo = Convert.ToInt32( this.cboPeriodoPresupuestal1.SelectedValue);
            String cNombre = this.txtNombrePartida.Text;
            Decimal nValor = 0;
            Decimal nPorcentaje = this.nudPorcentaje.Value;            
            Boolean lAfectaSaldo = this.chcAfectacionSaldo.Checked;
            int idNivelAprob = Convert.ToInt32(this.cboNivelAprobPartida.SelectedValue);
            if (idNivelAprob == 0) lAfectaSaldo = false;
            int idLimAprobacion = Convert.ToInt32(this.cboLimAplicaSaldo1.SelectedValue);
            int idUsuReg = clsVarGlobal.User.idUsuario;            
            DateTime dFechaReg = clsVarGlobal.dFecSystem;
            int nSigno = Convert.ToInt32(this.cboSigno.SelectedValue);

            if (cTipoOperacion == "N" && idNivel == 1)
            {
                insertarNuevaPartida(0, idPadrePartida, cNombre, 0, idPeriodo, nValor, lAfectaSaldo, idNivelAprob, nPorcentaje, idUsuReg, dFechaReg, idLimAprobacion, nSigno);
            }
            else if(cTipoOperacion == "N" && idNivel == 2)
            {
                insertarNuevaPartida(0, idPartida, cNombre, 0, idPeriodo, nValor, lAfectaSaldo, idNivelAprob, nPorcentaje, idUsuReg, dFechaReg, idLimAprobacion, nSigno);
            }
            else if (cTipoOperacion == "A")
            {
                insertarNuevaPartida(idPartida, idPadrePartida, cNombre, idPlantillaPartida, idPeriodo, nValor, lAfectaSaldo, idNivelAprob, nPorcentaje, idUsuReg, dFechaReg, idLimAprobacion, nSigno);
            }
            listarPartidas(idPeriodo, Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));
            habilitarControles(false);
        }
       
        private void dtgPartidasPres_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDetalles();
        }

        private void cboPeriodoPresupuestal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            this.dtgPartidasPres.DataSource = null;
            listarPartidas(idPeriodoSelect, Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));            
            verificarEstadoPeriodo();
            habilitarControles(false);
            formatoDTGPartidas();
            //idPadrePartida = 0;
        }
        private void cboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboNivel.SelectedValue) == 2)
            {
                if (lExistenCC)
                {
                    MessageBox.Show("Las cuentas contables de la partida " + this.dtgPartidasPres.SelectedRows[0].Cells["cNombre"].Value + " seran borradas", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);                     
                }               
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (!tieneHijo())
            {
                frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();                
                frmBscCtaCtb.ShowDialog();
                if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;                
                clsCtaContable detalleCuentaC = new clsCtaContable();
                detalleCuentaC = new clsCNCtaContable().detallectactb(frmBscCtaCtb.pcCtaCtb);
                int nHijosCuentaContable = detalleCuentaC.nHijos;
                /// DESHABILITADO PARA ASIGNAR CUALQUIER CUENTA CONTABLE. Normalmente debe estar activado, para seleccionar unicamente partidas de ultimo nivel
                //if (nHijosCuentaContable > 0)
                //{
                //    MessageBox.Show("Seleccione una cuenta contable de nivel menor", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                    if (existeCuentContEnDTG(frmBscCtaCtb.pcCtaCtb))
                    {
                        MessageBox.Show("la cuenta contable " + frmBscCtaCtb.pcCtaCtb + " ya está en la lista", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DataRow dr = dtCuentasCont.NewRow();
                        dr["idCCPartida"] = 0;
                        dr["cCuenta"] = frmBscCtaCtb.pcCtaCtb;
                        dr["cDescripcion"] = frmBscCtaCtb.pcDesCtaCtb;
                        dtCuentasCont.Rows.Add(dr);                     
                    }    
                //}                           
            } 
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (!tieneHijo())
            {
                if (this.dtgCuentasCont.Rows.Count <= 0)
                {
                    MessageBox.Show("No existen cuentas contables para quitar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (this.dtgCuentasCont.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar la cuenta contable que desea eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        int id = this.dtgCuentasCont.SelectedRows[0].Index;                        
                        dtCuentasCont.Rows.RemoveAt(id);
                    }
                }   
            }            
        }
        private void chcAfectacionSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcAfectacionSaldo.Enabled)
            {
                if (this.chcAfectacionSaldo.Checked)
                {
                    this.cboNivelAprobPartida.Enabled = true;
                }
                else
                {
                    this.cboNivelAprobPartida.Enabled = false;
                    this.cboNivelAprobPartida.SelectedValue = 0;
                }
            }
            else
            {
                this.cboNivelAprobPartida.Enabled = false;
            }
        }
        private void btnExportarPartidas_Click(object sender, EventArgs e)
        {
            //if (this.idPeriodoPlanificacion != 0)
            //{
            //    if (MessageBox.Show("¿Está seguro de exportar estas partidas a periodo de planificación?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        exportarAplanificacion(Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue), this.idPeriodoPlanificacion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);   
            //    }                
            //}
            //else
            //{
            //    MessageBox.Show("No existe periodo en planificación.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }        
        private void cboEstructuraPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPartidas((int)this.cboPeriodoPresupuestal1.SelectedValue, Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));
        }

        private void btnImportExcel1_Click(object sender, EventArgs e)
        {
            frmCargarDeExcel CargaExcel = new frmCargarDeExcel(Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue));
            CargaExcel.ShowDialog();
            listarPartidas(Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue), Convert.ToString(this.cboEstructuraPresupuesto.SelectedValue));
        }
        #endregion

        #region Metodos
        private Boolean tieneHijo()
        {
            if( cTipoOperacion == "N") // si es nuevo, no tiene hijo
            {
                return false;    
            }
            try
            {
                int idPartida = Convert.ToInt32(dtPartidas.Rows[idFilaSelecPartida]["idPartida"].ToString());
                int idPadreSigRow = Convert.ToInt32(dtPartidas.Rows[idFilaSelecPartida + 1]["idPartidaPadre"].ToString());
                if (idPartida == idPadreSigRow )
                {
                    MessageBox.Show("Edite las cuentas contables a nivel menor", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            catch {
                
            }
            return false;            
        }
        private Boolean existeCuentContEnDTG(String cCuentCont)
        {
            foreach (DataGridViewRow Row in dtgCuentasCont.Rows)
            {                
                String cValorCC = Row.Cells["cCuenta"].Value.ToString();
                if (cValorCC == cCuentCont)
                {
                    return true;
                }
            }
            return false;
        }
        private Boolean tieneCuentasContab(int idPartida)
        {
            DataTable dtCuentCont = cnpartidaspres.listarCuentasContables(idPartida);
            if (dtCuentCont.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void verificarEstadoPeriodo()
        {           
            int idEstadoPeriodo = Convert.ToInt32( this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "idEstado"));
            this.lblPlanificacion.Text = this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "cEstado");
                if (idEstadoPeriodo == 1)   // 1 = planificacion
                {
                    this.lblPlanificacion.ForeColor = Color.DarkGreen;
                    lEsPlanificacion = true;
                    this.idPeriodoPlanificacion = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
                }
                else if (idEstadoPeriodo == 2) //2 = ejecución
                {
                    this.lblPlanificacion.ForeColor = Color.RoyalBlue;
                    lEsPlanificacion = true;
                }
                else
                {
                    this.lblPlanificacion.ForeColor = Color.Gray;
                    lEsPlanificacion = false;                    
                }                      
        }
     
        private void listarPartidas(int nPeriodoPlanific, String cEstructura)
        {
            dtPartidas = cnpartidaspres.ListarPartidasXEstructura(nPeriodoPlanific, cEstructura);
            this.dtgPartidasPres.DataSource = dtPartidas;
                       
            if (this.dtgPartidasPres.RowCount <= 0)
            {   
                listarCuentasContables(0);
                habilitarControles(false);                
                limpiarControles();                
            }            
        }
        private void formatoDTGPartidas()
        {
            foreach (DataGridViewColumn item in dtgPartidasPres.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;                
            }                      
            this.dtgPartidasPres.Columns["cDescripcion"].Visible = true;            
            this.dtgPartidasPres.Columns["nPorcentajeAsignacion"].Visible = true;
            this.dtgPartidasPres.Columns["cDescripcionLimAplicacion"].Visible = true;
            this.dtgPartidasPres.Columns["lAfectacionSaldo"].Visible = true;
            this.dtgPartidasPres.Columns["cDescripcionAprobacion"].Visible = true; 
            
            this.dtgPartidasPres.Columns["cDescripcion"].Width = 320;            
            this.dtgPartidasPres.Columns["nPorcentajeAsignacion"].Width = 80;
            this.dtgPartidasPres.Columns["lAfectacionSaldo"].Width = 70;
            this.dtgPartidasPres.Columns["cDescripcionAprobacion"].Width = 90;
         
            this.dtgPartidasPres.Columns["nPorcentajeAsignacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgPartidasPres.Columns["lAfectacionSaldo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgPartidasPres.Columns["cDescripcionAprobacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.dtgPartidasPres.Columns["cDescripcion"].HeaderText = "Descripción";            
            this.dtgPartidasPres.Columns["nPorcentajeAsignacion"].HeaderText = "Porcentaje de Asignación";
            this.dtgPartidasPres.Columns["lAfectacionSaldo"].HeaderText = "Nivel";
            this.dtgPartidasPres.Columns["cDescripcionAprobacion"].HeaderText = "de aprobación";
            this.dtgPartidasPres.Columns["cDescripcionLimAplicacion"].HeaderText = "Límite de aplicación";            
        }
        private void mostrarDetalles()
        {
            int idPartida = 0;
            if (this.dtgPartidasPres.SelectedRows.Count > 0)
            {
                this.txtCodigo.Text = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["cCodigoPresupuestal"].Value);
                this.txtNombrePartida.Text = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["cNombre"].Value);
                idPadrePartida = Convert.ToInt32(this.dtgPartidasPres.SelectedRows[0].Cells["idPartidaPadre"].Value);
                this.nudPorcentaje.Text = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["nPorcentajeAsignacion"].Value);
                this.cboNivelAprobPartida.SelectedValue = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["idNivelAprobAfectacion"].Value);
                this.cboLimAplicaSaldo1.SelectedValue = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["idLimAplicacion"].Value);
                this.chcAfectacionSaldo.Checked = Convert.ToBoolean(this.dtgPartidasPres.SelectedRows[0].Cells["lAfectacionSaldo"].Value);
                idPartida = Convert.ToInt32(this.dtgPartidasPres.SelectedRows[0].Cells["idPartida"].Value);
                idPlantillaPartida = Convert.ToInt32(this.dtgPartidasPres.SelectedRows[0].Cells["idPlantillaPartida"].Value);
                this.cboSigno.SelectedValue = Convert.ToString(this.dtgPartidasPres.SelectedRows[0].Cells["nSigno"].Value);
                idFilaSelecPartida = this.dtgPartidasPres.SelectedRows[0].Index;
                this.idPartida = idPartida;
                habilitarControles(false);
            }
            else {
                idPadrePartida = 0;
                idFilaSelecPartida = 0;
                idPartida = 0;
                idPlantillaPartida = 0;
                limpiarControles();
            }
            listarCuentasContables(idPartida);
        }
        private void listarCuentasContables(int idPartida)
        {
            dtCuentasCont = cnpartidaspres.listarTodasCuentasContables(idPartida);
            this.dtgCuentasCont.DataSource = dtCuentasCont.DefaultView;

            foreach (DataGridViewColumn item in this.dtgCuentasCont.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }            
            this.dtgCuentasCont.Columns["cDescripcion"].Visible = true;
            this.dtgCuentasCont.Columns["cDescripcion"].HeaderText = "Descripción";        
        }
        private void insertarNuevaPartida(int idPartida, int idPadre, String cNombre, int idPlantilla, int idPeriodo, Decimal nPresupuesto, Boolean lAfectacion,
                                            int idNivelAprob, Decimal nPorcentaje, int idUsu, DateTime dFecha, int idLimAplicacion, int nSigno)
        {
            DataSet DSCuentasContables = new DataSet("DSCuentasContables");
            DSCuentasContables.Tables.Add(dtCuentasCont);
            string xmlCuentasConta = DSCuentasContables.GetXml();
            xmlCuentasConta = clsCNFormatoXML.EncodingXML(xmlCuentasConta);
            DSCuentasContables.Tables.Clear();           
            DataTable dtResultado = cnpartidaspres.InsertarPartidaPres(idPartida, idPadre, idPlantilla, cNombre, idPeriodo, nPresupuesto, lAfectacion, idNivelAprob, nPorcentaje, idUsu, dFecha, xmlCuentasConta, idLimAplicacion, nSigno);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        private void eliminarPartida(int idPartida, int idUsu, DateTime dFecha)
        {
            DataTable dtResultado = cnpartidaspres.EliminarPartidaPres(idPartida, idUsu, dFecha);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        //private void exportarAplanificacion(int idPeriodoOrigen, int idPeriodoPlanif, int idUsu, DateTime dFecha)
        //{
        //    DataTable dtResultado = cnpartidaspres.ExportarPartidasAPlanif(idPeriodoOrigen, idPeriodoPlanif, idUsu, dFecha);
        //    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));            
        //}
        private void limpiarControles()
        {
            this.txtNombrePartida.Clear();            
            this.nudPorcentaje.Value = 100;
            this.cboNivel.SelectedValue = 1;            
            this.cboNivelAprobPartida.SelectedIndex = -1;
            this.cboLimAplicaSaldo1.SelectedIndex = -1;
            this.chcAfectacionSaldo.Checked = false;
            dtCuentasCont.Rows.Clear();            
        }
        private void habilitarControles(Boolean Val)
        {
            this.cboPeriodoPresupuestal1.Enabled = !Val;            
            this.txtNombrePartida.Enabled = Val;
            this.txtCodigo.Enabled = Val;            
            this.nudPorcentaje.Enabled = Val;
            this.cboNivel.Enabled = Val;
            this.cboLimAplicaSaldo1.Enabled = Val;
            this.chcAfectacionSaldo.Enabled = Val;
            if (this.chcAfectacionSaldo.Enabled && this.chcAfectacionSaldo.Checked)
            {
                this.cboNivelAprobPartida.Enabled = true;
            } else {
                this.cboNivelAprobPartida.Enabled = false;
            }

            if (!lEsPlanificacion)
            {
                this.btnNuevo1.Enabled = false;
                this.btnEditar1.Enabled = false;
                this.btnEliminar1.Enabled = false;
                this.btnImportExcel1.Enabled = false;
                //this.btnExportarPartidas.Visible = true;
            }else{
                this.btnNuevo1.Enabled = !Val;
                this.btnEditar1.Enabled = !Val;
                this.btnEliminar1.Enabled = !Val;
                this.btnImportExcel1.Enabled = true;
                //this.btnExportarPartidas.Visible = false;
            }            
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;
            this.btnMiniAgregar1.Enabled = Val;
            this.btnMiniQuitar1.Enabled = Val;
            this.cboSigno.Enabled = Val;

            this.dtgPartidasPres.Enabled = !Val;         
        }
        private Boolean validarDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombrePartida.Text))
            {
                MessageBox.Show("Ingresar nombre de partida", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNombrePartida.Focus();
                return false;
            }
            if (this.chcAfectacionSaldo.Checked && this.cboNivelAprobPartida.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccionar nivel de aprobación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboNivelAprobPartida.Focus();
                return false;
            }
            if (this.cboLimAplicaSaldo1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccionar límite de aplicación sobre saldo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboLimAplicaSaldo1.Focus();
                return false;
            }
            return true;
        }
       
        private void formatoCboSigno()
        {
            DataTable dtSigno = new DataTable();
            dtSigno.Columns.Add("nSigno", typeof(String));
            dtSigno.Columns.Add("cNomSigno", typeof(String));
            DataRow drSigno = dtSigno.NewRow();
            drSigno["nSigno"] = "1";
            drSigno["cNomSigno"] = "Suma";
            dtSigno.Rows.Add(drSigno);
            DataRow drSigno2 = dtSigno.NewRow();
            drSigno2["nSigno"] = "-1";
            drSigno2["cNomSigno"] = "Resta";
            dtSigno.Rows.Add(drSigno2);

            this.cboSigno.DataSource = dtSigno;
            cboSigno.ValueMember = "nSigno";
            cboSigno.DisplayMember = "cNomSigno";
        }

        #endregion               

        
    }
}
