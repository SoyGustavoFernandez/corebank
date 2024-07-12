using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System.IO;
using System.Globalization;
using Microsoft.Reporting.WinForms;
namespace CRE.Presentacion
{
    public partial class frmReasCarte : frmBase
    {
        int nIdAseOri = 0;
        int nIdAseDes = 0;
        
        clsCNCredito Credito = new clsCNCredito();
        DataSet ds = new DataSet();
        DataTable dtUpd = new DataTable();
        DataTable dtCreDes = new DataTable();
        DataTable dtRangoOrigen;
        DataTable dtRangoDestino;
        string xml;

        public frmReasCarte()
        {
            InitializeComponent();
            cboCategoriaPersonal1.cargarCategoria(0);
            cboCategoriaPersonal2.cargarCategoria(0);
            cboCategoriaPersonal1.Enabled = false;
            cboCategoriaPersonal2.Enabled = false;
        }

        private void frmReasCarte_Load(object sender, EventArgs e)
        {   
            this.cboAseOri.SelectedIndexChanged += new EventHandler(cboAseOri_SelectedIndexChanged);
            this.cboAseDes.SelectedIndexChanged += new EventHandler(cboAseDes_SelectedIndexChanged);
            cboAseDes.DataSource = null;
            cboAseOri.DataSource = null;
            CleanData(1);

            this.conBusUbigOrigen.cargar();
            this.conBusUbigOrigen.cboPais.SelectedIndex = 170;
            this.conBusUbigOrigen.cboPais.Enabled = false;

            this.conBusUbigDes.cargar();
            this.conBusUbigDes.cboPais.SelectedIndex = 170;
            this.conBusUbigDes.cboPais.Enabled = false;

            this.conBusUbigOrigen.cboDepartamento.SelectedIndexChanged += cboDepartamentoOrigen_SelectedIndexChanged;
            this.conBusUbigOrigen.cboProvincia.SelectedIndexChanged += cboProvinciaOrigen_SelectedIndexChanged;
            this.conBusUbigOrigen.cboDistrito.SelectedIndexChanged += cboDistritoOrigen_SelectedIndexChanged;
            this.conBusUbigOrigen.cboAnexo.SelectedIndexChanged += cboAnexoOrigen_SelectedIndexChanged;

            this.conBusUbigDes.cboDepartamento.SelectedIndexChanged += cboDepartamentoDestino_SelectedIndexChanged;
            this.conBusUbigDes.cboProvincia.SelectedIndexChanged += cboProvinciaDestino_SelectedIndexChanged;
            this.conBusUbigDes.cboDistrito.SelectedIndexChanged += cboDistritoDestino_SelectedIndexChanged;
            this.conBusUbigDes.cboAnexo.SelectedIndexChanged += cboAnexoDestino_SelectedIndexChanged;

            //this.cboCondicionContable1.SelectedIndex = 1;

            this.cboCondicionContable1.ListarCondicionContablePorModulo(1);
            this.cboAgenciasOri.SelectedValue = clsVarGlobal.nIdAgencia;
            this.cboAgenciasDes.SelectedValue = clsVarGlobal.nIdAgencia;
        }

        void cboDepartamentoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigOrigen.Enabled)
            {
                if (this.conBusUbigOrigen.cboDepartamento.SelectedIndex > 0)
                    LoadCreOriUbi((int)this.conBusUbigOrigen.cboDepartamento.SelectedValue);
                if (this.conBusUbigOrigen.cboDepartamento.SelectedIndex == 0)
                    LoadCreOri();
            }
        }

        void cboProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigOrigen.Enabled)
            {
                if (this.conBusUbigOrigen.cboProvincia.SelectedIndex > 0)
                    LoadCreOriUbi((int)this.conBusUbigOrigen.cboProvincia.SelectedValue);
                if (this.conBusUbigOrigen.cboProvincia.SelectedIndex == 0)
                    cboDepartamentoOrigen_SelectedIndexChanged(sender, e);
            }
        }

        void cboDistritoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigOrigen.Enabled)
            {
                if (this.conBusUbigOrigen.cboDistrito.SelectedIndex > 0)
                    LoadCreOriUbi((int)this.conBusUbigOrigen.cboDistrito.SelectedValue);
                if (this.conBusUbigOrigen.cboDistrito.SelectedIndex == 0)
                    cboProvinciaOrigen_SelectedIndexChanged(sender, e);
            }
        }

        void cboAnexoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigOrigen.Enabled)
            {
                if (this.conBusUbigOrigen.cboAnexo.SelectedIndex > 0)
                    LoadCreOriUbi((int)this.conBusUbigOrigen.cboAnexo.SelectedValue);
                if (this.conBusUbigOrigen.cboAnexo.SelectedIndex == 0)
                    cboDistritoOrigen_SelectedIndexChanged(sender, e);
            }
        }
        
        void cboDepartamentoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigDes.Enabled)
            {
                if (this.conBusUbigDes.cboDepartamento.SelectedIndex > 0)
                    LoadCreDesUbi((int)this.conBusUbigDes.cboDepartamento.SelectedValue);
                if (this.conBusUbigDes.cboDepartamento.SelectedIndex == 0)
                    LoadCreOri();
            }
        }

        void cboProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigDes.Enabled)
            {
                if (this.conBusUbigDes.cboProvincia.SelectedIndex > 0)
                    LoadCreDesUbi((int)this.conBusUbigDes.cboProvincia.SelectedValue);
                if (this.conBusUbigDes.cboProvincia.SelectedIndex == 0)
                    cboDepartamentoDestino_SelectedIndexChanged(sender, e);
            }
        }

        void cboDistritoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigDes.Enabled)
            {
                if (this.conBusUbigDes.cboDistrito.SelectedIndex > 0)
                    LoadCreDesUbi((int)this.conBusUbigDes.cboDistrito.SelectedValue);
                if (this.conBusUbigDes.cboDistrito.SelectedIndex == 0)
                    cboProvinciaDestino_SelectedIndexChanged(sender, e);
            }
        }

        void cboAnexoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigDes.Enabled)
            {
                if (this.conBusUbigDes.cboAnexo.SelectedIndex > 0)
                    LoadCreDesUbi((int)this.conBusUbigDes.cboAnexo.SelectedValue);
                if (this.conBusUbigDes.cboAnexo.SelectedIndex == 0)
                    cboDistritoDestino_SelectedIndexChanged(sender, e);
            }
        }
        
        void cboAseDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.conBusUbigDes.Enabled = false;

            this.conBusUbigDes.cboDepartamento.SelectedIndex = -1;
            this.conBusUbigDes.cboProvincia.SelectedIndex = -1;
            this.conBusUbigDes.cboDistrito.SelectedIndex = -1;
            this.conBusUbigDes.cboAnexo.SelectedIndex = -1;

            LoadCreDes();

            if (this.dtgCreDes.Rows.Count > 0)
                this.conBusUbigDes.Enabled = true;

            seleccionaCategoriaPersonal(cboCategoriaPersonal2, cboAseDes, ref dtRangoDestino);
        }

        private void seleccionaCategoriaPersonal(cboCategoriaPersonal cboCat, cboPersonalCreditos cboPer, ref DataTable dt)
        {
            if (cboPer.DataSource != null && cboPer.SelectedIndex!=-1)
            {
                cboCat.SelectedValue = Convert.ToInt32((((DataTable)cboPer.DataSource).Rows[cboPer.SelectedIndex]["idCategoria"] == DBNull.Value) ? 0 :
                            ((DataTable)cboPer.DataSource).Rows[cboPer.SelectedIndex]["idCategoria"]);

                dt = Credito.CNRetornaCategoriaAsesorPoIdCatPersonal(Convert.ToInt32(cboCat.SelectedValue));
            }
            
        }
        void cboAseOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.conBusUbigOrigen.Enabled = false;

            this.conBusUbigOrigen.cboDepartamento.SelectedIndex = -1;
            this.conBusUbigOrigen.cboProvincia.SelectedIndex = -1;
            this.conBusUbigOrigen.cboDistrito.SelectedIndex = -1;
            this.conBusUbigOrigen.cboAnexo.SelectedIndex = -1;
            this.chcTodos.Checked = false;                                
            
            LoadCreOri();
            actualizarSeleccionados();

            //if (this.dtgCreOri.Rows.Count > 0)
                this.conBusUbigOrigen.Enabled = true;

            seleccionaCategoriaPersonal(cboCategoriaPersonal1, cboAseOri, ref dtRangoOrigen);
        }

        private void LoadCreOri()
        {
            try
            {
                if (cboAseOri.SelectedItem != null)
                {
                    dtUpd = new DataTable();
                    //dtUpd = Credito.LisCreByAna(Convert.ToInt32(cboAseOri.SelectedValue));
                    dtUpd = Credito.LisCreByAnaEst(Convert.ToInt32(cboAseOri.SelectedValue), Convert.ToInt32(cboCondicionContable1.SelectedValue));
                    dtUpd.Columns["lSeleCta"].ReadOnly = false;

                    dtgCreOri.DataSource = dtUpd;
                    lblBase1.Text = dtgCreOri.Rows.Count.ToString() + " Créditos.";
                    SaldoTotalAsesor(dtgCreOri, lblBase8);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void LoadCreOriUbi(int nIdUbigeo)
        {
            try
            {
                if (cboAseOri.SelectedItem != null)
                {
                    dtUpd = new DataTable();
                    dtUpd = Credito.LisCreByAnaUbiEst(Convert.ToInt32(cboAseOri.SelectedValue), nIdUbigeo, Convert.ToInt32(cboCondicionContable1.SelectedValue));
                    dtUpd.Columns["lSeleCta"].ReadOnly = false;

                    dtgCreOri.DataSource = dtUpd;
                    lblBase1.Text = dtgCreOri.Rows.Count.ToString() + " Créditos.";
                    SaldoTotalAsesor(dtgCreOri, lblBase8);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene el saldo capital del asesor leyendo el dtg y lo visualiza en el lbl
        /// </summary>
        /// <param name="dtg">DataGridView para recorrer y encontrar el nSaldoCapital</param>
        /// <param name="lbl">Label donde se verá el resultado del saldo capital total</param>
        private void SaldoTotalAsesor(DataGridView dtg, lblBase lbl)
        {
            lbl.Text = "Saldo Capital Total: " + String.Format("{0:n}", SaldoTotalAsesor(dtg));
        }

        private Decimal SaldoTotalAsesor(DataGridView dtg) 
        {
            DataTable dt = ((DataTable)dtg.DataSource);
            decimal nSaldoTotalAsesor = 0;
            foreach (DataRow item in dt.Rows)
            {
                nSaldoTotalAsesor += Convert.ToDecimal(item["nSaldoCapital"]);
            }
            return nSaldoTotalAsesor;
        }

        private void LoadCreDes()
        {
            try
            {
                if (cboAseDes.SelectedItem != null)
                {
                    dtCreDes = Credito.LisCreByAna((Int32)cboAseDes.SelectedValue);
                    //dtCreDes = Credito.LisCreByAnaEst((Int32)cboAseDes.SelectedValue, Convert.ToInt32(cboCondicionContable2.SelectedValue));
                    dtCreDes.Columns["lSeleCta"].ReadOnly = false;
                    dtgCreDes.DataSource = dtCreDes;
                    lblBase2.Text = dtgCreDes.Rows.Count.ToString() + " Créditos.";
                    SaldoTotalAsesor(dtgCreDes, lblBase9);
                }
            }
            catch (Exception ex)
            {            
                throw ex;
            }
        }

        private void LoadCreDesUbi(int nIdUbigeo)
        {
            try
            {
                if (cboAseDes.SelectedItem != null)
                {
                    dtCreDes = Credito.LisCreByAnaUbi((Int32)cboAseDes.SelectedValue, nIdUbigeo);
                    //dtCreDes = Credito.LisCreByAnaUbiEst((Int32)cboAseDes.SelectedValue, nIdUbigeo, Convert.ToInt32(cboCondicionContable2.SelectedValue));
                    dtCreDes.Columns["lSeleCta"].ReadOnly = false;
                    dtgCreDes.DataSource = dtCreDes;
                    lblBase2.Text = dtgCreDes.Rows.Count.ToString() + " Créditos.";
                    SaldoTotalAsesor(dtgCreDes, lblBase9);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {           
            if (Validacion())
            {
                DialogResult drResultadoReasignar = MessageBox.Show("Se DERIVARÁ la Solicitud de Reasignación de Cartera de " + contarCreditosSeleccionados() + " créditos con saldo capital acumulado de " + String.Format("{0:n}", sumarSaldoTotalCreditosSeleccionados()) + " soles del asesor " + cboAseOri.Text + " al asesor " + cboAseDes.Text + ", \n\n ¿ Desea Continuar ?", "Solicitud de Reasignación de Cartera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultadoReasignar == DialogResult.Yes)
                {
                    if (ds.Tables.Contains("Table1"))
                        ds.Tables.Remove("Table1");
                    
                    DataTable dt = dtUpd.Copy();

                    dt.Columns.Remove("cNombre");
                    ds.Tables.Add(dt);
                    xml = ds.GetXml();

                    DataTable dtResultado = Credito.UpdCreByAse(xml, (Int32)cboAseDes.SelectedValue, (Int32)cboAgenciasDes.SelectedValue, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, txtSustento.Text.Trim().ToUpper(),contarCreditosSeleccionados());
                    if (dtResultado.Rows.Count > 0)
                    {
                        int nIdReasignacionCartera = Convert.ToInt32(dtResultado.Rows[0][0].ToString());
                        if (nIdReasignacionCartera != 0)
                        {
                            //impreso
                            
                            string cNombreDestino = cboAseDes.Text;
                            //string lugarFecha = clsVarGlobal.cNomAge + ", " + DateTime.Now.ToString("D", new CultureInfo("es-ES")).ToUpperInvariant();
                            string lugarFecha = clsVarGlobal.cNomAge + ", " + clsVarGlobal.dFecSystem.ToString("D", new CultureInfo("es-ES")).ToUpperInvariant();

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();
                            dtslist.Add(new ReportDataSource("dsListaCreditosReasignados", Credito.ListCredReasignados(nIdReasignacionCartera)));

                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Clear();
                            paramlist.Add(new ReportParameter("cNombreOperador", clsVarGlobal.User.cNomUsu, false));
                            paramlist.Add(new ReportParameter("nombreAsesorDestino", cNombreDestino, false));
                            paramlist.Add(new ReportParameter("lugarFecha", lugarFecha, false));
                            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
                            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlist.Add(new ReportParameter("cSustento", txtSustento.Text.ToLower(), false));

                            string reportpath = "rptActaReasignacionCartera.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                            txtSustento.Text = "";
                            LoadCreOri();
                            LoadCreDes();
                            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGrabar1.Enabled = false;
                            ds.Tables.Remove("Table1");
                            chcTodos.Checked = false;

                            if ((int)cboAgenciasOri.SelectedValue != (int)cboAgenciasDes.SelectedValue)
                            {
                                MessageBox.Show("Debe Realizar el Traslado del Expediente(s) de la Cartera Reasignada \nPara Realizar el Traslado de Expediente presionar el botón TRASLADAR", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            actualizarSeleccionados();
                        }
                        else
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }          
        }

        private bool Validacion()
        {
            bool res = true;
            if (dtgCreOri.Rows.Count<=0)
            {
                MessageBox.Show("El Asesor no tiene créditos asignados", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                res=false;
                return res;
            }

            if (cboAseDes.SelectedIndex<0)
            {
                MessageBox.Show("Debe Seleccionar el Asesor de Destino", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                res = false;
                return res;
            }
            if ((int)cboAseOri.SelectedValue == (int)cboAseDes.SelectedValue)
            {
                MessageBox.Show("El Asesor de Orígen y de Destino no pueden ser los mismos.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                res = false;
                return res;
            }

            if (txtSustento.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Debe ingresar el sustento de la reasiganción de la cartera.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSustento.Focus();
                res = false;
                return res;
            }
            bool n = false;
            foreach (DataRow item in dtUpd.Rows)
            {
                if ((bool)item["lSeleCta"])
                {
                    n = true;
                    break;
                }
            }
            if (!n)
            {
                MessageBox.Show("Debe seleccionar algún credito.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                res = false;
                return res;
            }
            
            if (!validarTransPermitidaPorCategoriaPersonal())
                res = false;

            return res;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            CleanData(2);
            btnGrabar1.Enabled = true;
        }
        /// <summary>
        /// Vuelve los controles a forma incial
        /// 
        /// </summary>
        private void CleanData(int nModalidad)
        {
            if (nModalidad == 1)
            {
                cboAseDes.SelectedIndex = -1;
                cboAseOri.SelectedIndex = -1;
                cboAgenciasDes.SelectedIndex = -1;
                cboAgenciasOri.SelectedIndex = -1;

                this.conBusUbigOrigen.cboDepartamento.SelectedIndex = -1;
                this.conBusUbigOrigen.cboProvincia.SelectedIndex = -1;
                this.conBusUbigOrigen.cboDistrito.SelectedIndex = -1;
                this.conBusUbigOrigen.cboAnexo.SelectedIndex = -1;
                this.chcTodos.Checked = false;
                this.conBusUbigOrigen.Enabled = false;
                this.conBusUbigDes.Enabled = false;


                this.conBusUbigDes.cboDepartamento.SelectedIndex = -1;
                this.conBusUbigDes.cboProvincia.SelectedIndex = -1;
                this.conBusUbigDes.cboDistrito.SelectedIndex = -1;
                this.conBusUbigDes.cboAnexo.SelectedIndex = -1;
                this.conBusUbigDes.cboDepartamento.Enabled = false;

                dtCreDes.Clear();
                dtUpd.Clear();
            }
            else if (nModalidad == 2)
            {
                //cboAseDes.SelectedIndex = -1;
                //cboAseOri.SelectedIndex = -1;                
                //cboAgenciasDes.SelectedIndex = -1;
                //cboAgenciasOri.SelectedIndex = -1;

                this.conBusUbigOrigen.cboDepartamento.SelectedIndex = -1;
                this.conBusUbigOrigen.cboProvincia.SelectedIndex = -1;
                this.conBusUbigOrigen.cboDistrito.SelectedIndex = -1;
                this.conBusUbigOrigen.cboAnexo.SelectedIndex = -1;
                this.chcTodos.Checked = false;
                //this.conBusUbigOrigen.Enabled = false;
                //this.conBusUbigDes.Enabled = false;                

                this.conBusUbigDes.cboDepartamento.SelectedIndex = -1;
                this.conBusUbigDes.cboProvincia.SelectedIndex = -1;
                this.conBusUbigDes.cboDistrito.SelectedIndex = -1;
                this.conBusUbigDes.cboAnexo.SelectedIndex = -1;
                //this.conBusUbigDes.cboDepartamento.Enabled = false;

                dtCreDes.Clear();
                dtUpd.Clear();
                
                //
                LoadCreOri();                
                LoadCreDes();

                actualizarSeleccionados();
                //
            }            
        }
                
        private void cboAgenciasOri_SelectedIndexChanged(object sender, EventArgs e)
        {
           int pidAgen = Convert.ToInt32(cboAgenciasOri.SelectedValue);
            if (pidAgen == 0)
            {
                cboAseOri.DataSource = null;                
                dtUpd.Clear();      
            }
            else
            {
                if (Convert.ToInt32(cboAgenciasOri.SelectedValue) == Convert.ToInt32(cboAgenciasDes.SelectedValue))
                {
                    btnTrasladarExp1.Enabled = false;
                }
                else
                {
                    btnTrasladarExp1.Enabled = true;
                }

                cboAseOri.ListarPersonal(pidAgen, false, 0);
            }            
        }

        private void cboAgenciasDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pidAgen = Convert.ToInt32(cboAgenciasDes.SelectedValue);
            if (pidAgen == 0)
            {
                cboAseDes.DataSource = null;
                dtCreDes.Clear();
            }
            else
            {

                if (Convert.ToInt32(cboAgenciasOri.SelectedValue) == Convert.ToInt32(cboAgenciasDes.SelectedValue))
                {
                    btnTrasladarExp1.Enabled = false;
                }
                else
                {
                    btnTrasladarExp1.Enabled = true;
                }
                cboAseDes.ListarPersonal(Convert.ToInt32(cboAgenciasDes.SelectedValue), false, 1);
                if (cboAseDes.Items.Count<=0)
                {
                    dtCreDes.Clear();
                }
            }

        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                foreach (DataRow NRow in dtUpd.Rows)
                {
                    NRow["lSeleCta"] = true;
                }
                dtgCreOri.Refresh();
            }
            else
            {
                foreach (DataRow NRow in dtUpd.Rows)
                {
                    NRow["lSeleCta"] = false;
                }
                dtgCreOri.Refresh();
            }
            actualizarSeleccionados();
        }
    
        private void dtgCreOri_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgCreOri.IsCurrentCellDirty)
            {
                dtgCreOri.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgCreOri_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarTodosLosCreditosDeUnCliente(e.RowIndex);
            foreach (DataRow NRow in dtUpd.Rows)
            {
                bool selec = Convert.ToBoolean(NRow["lSeleCta"]);
                if (selec == false)
                {
                    chcTodos.CheckedChanged -= new EventHandler(chcTodos_CheckedChanged);
                    chcTodos.Checked = false;
                    chcTodos.CheckedChanged += new EventHandler(chcTodos_CheckedChanged);
                    break;
                }               
            }
            actualizarSeleccionados();
        }
        /// <summary>
        /// Actualiza las vistas con el conteo realizado.
        /// </summary>
        public void actualizarSeleccionados()
        {
            if (dtgCreOri.Rows.Count > 0)
            {
                lblCreditosSeleccionados.Text = contarCreditosSeleccionados() + " Crédito(s) seleccionados";
                lblTotalSaldoCapital.Text = "Total Saldo Capital: " + String.Format("{0:n}", sumarSaldoTotalCreditosSeleccionados());
            }
            else
            {
                lblCreditosSeleccionados.Text = "Crédito(s) seleccionados";
                lblTotalSaldoCapital.Text = "Total Saldo Capital";
            }
        }

        private void btnTrasladarExp1_Click(object sender, EventArgs e)
        {
            if (dtgCreOri.Rows.Count==0)
            {
                MessageBox.Show("No se tiene datos de origen","Validad datos de reasignación",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (!validarTransPermitidaPorCategoriaPersonal())
                    return;

                frmExpedientesTraslado FrmTrasladar = new frmExpedientesTraslado();
                FrmTrasladar.ShowDialog();
            }
         
        }

        #region Validar Tope Transferencia
        private Boolean validarTransPermitidaPorCategoriaPersonal()
        {
            if (!validarTopeTransferenciaOrigen())
                return false;
            
            if (!validarGestionDestino())
                return false;

            return true;
        }
        private Boolean validarGestionDestino()
        {
            //Validar Rangos por categoria de Persnal
            if (dtRangoDestino.Rows.Count == 0)
            {
                MessageBox.Show("No se tiene configurado los Rangos de Cartera para la categoría de Destino "+cboCategoriaPersonal2.Text, "Validar datos de reasignación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Validar que existan datos de destino
            if (cboAgenciasDes.SelectedValue==null)
            {
                MessageBox.Show("Seleccione la agencia destino","Validar datos de reasignación",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboAseDes.SelectedValue==null)
            {
                MessageBox.Show("Seleccione la asesor destino", "Validar datos de reasignación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;            
             }
            //---------------------------------------------------//
            // Validando si puede gestionar todos sus clientes + los clientes a transferir
            //----------------------------------------------------//
            int nNroCliMin = Convert.ToInt32(dtRangoDestino.Rows[0]["nMinNroClientesGestion"]);
            int nNroCliMax = Convert.ToInt32(dtRangoDestino.Rows[0]["nMaxNroClientesGestion"]);
            Decimal nNroSaldoMin = Convert.ToDecimal(dtRangoDestino.Rows[0]["nMinSaldoCarteraGestion"]);
            Decimal nNroSaldoMax = Convert.ToDecimal(dtRangoDestino.Rows[0]["nMaxSaldoCarteraGestion"]);
            int nNroCliDestino = nroClientesUnicosDataTable(((DataTable)dtgCreDes.DataSource));
            int nNroCliTrans   = nroClientesParaTransferir();
            int nNroCliAGestionar = nNroCliDestino + nNroCliTrans;
        
            Decimal nNroSaldoAgestionar = SaldoTotalAsesor(dtgCreDes) + Convert.ToDecimal(sumarSaldoTotalCreditosSeleccionados());
            if (nNroCliMax < nNroCliAGestionar)
            {
                MessageBox.Show("El Asesor no puede gestionar  " + Convert.ToString(nNroCliAGestionar) + " clientes; Máximo el Asesor solo puede gestionar hasta: "
                    + Convert.ToInt32(nNroCliMax).ToString() + " Clientes.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (nNroSaldoMax < nNroSaldoAgestionar)
            {
                MessageBox.Show("El Asesor no puede gestionar " + nNroSaldoAgestionar.ToString() + " de Saldo; Máximo solo puede gestionar hasta "
                        + nNroSaldoMax.ToString() +" de Saldo" , "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private Boolean validarTopeTransferenciaOrigen()
        {
            //Validar Rangos por categoria de Persnal
            if (dtRangoOrigen.Rows.Count == 0)
            {
                MessageBox.Show("No se tiene configurado los Rangos de Cartera para la categoría de Origen "+cboCategoriaPersonal1.Text, "Validar datos de reasignación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            /*---------------------------------------------------*
             Validando si puede transferir un nro de clientes
            /----------------------------------------------------*/
            int nNroCliTrans = nroClientesParaTransferir();
            Decimal /*era double*/nSaldoTotalCreSelec = sumarSaldoTotalCreditosSeleccionados();
            if (Convert.ToInt32(dtRangoOrigen.Rows[0]["nTopeTransNroCliMax"]) < nNroCliTrans) 
            {
                MessageBox.Show("No puede Transferir " + nNroCliTrans.ToString() + " clientes; Máximo el Asesor solo puede transferir hasta: " 
                    + Convert.ToInt32(dtRangoOrigen.Rows[0]["nTopeTransNroCliMax"]).ToString() +" Clientes.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            /*---------------------------------------------------*
             Validando si puede transferir Monto
            /----------------------------------------------------*/
            if (Convert.ToDecimal /*era ToDouble*/(dtRangoOrigen.Rows[0]["nTopeTransSaldoMax"]) < nSaldoTotalCreSelec)
            {
                MessageBox.Show("No puede Transferir " + nSaldoTotalCreSelec.ToString() + " de Saldo; Máximo el Asesor solo puede transferir hasta: "
                    + Convert.ToDecimal /*era ToDouble*/(dtRangoOrigen.Rows[0]["nTopeTransSaldoMax"]).ToString() + " de Saldo.", "Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private int nroClientesParaTransferir()
        {
            if (dtgCreOri.Rows.Count>0)
            {
                DataTable dtNroClientes = ((DataTable)dtgCreOri.DataSource).Clone();
                foreach (DataRow item in ((DataTable)dtgCreOri.DataSource).Rows)
                {
                    if (Convert.ToBoolean(item["lSeleCta"]))
                    {
                        dtNroClientes.ImportRow(item);
                    }
                }
                return nroClientesUnicosDataTable(dtNroClientes);
            }
            else
            {
                return 0;
            }
     
            
        }
        public int nroClientesUnicosDataTable(DataTable dt)
        {
            DataView dv = new DataView(dt);
            DataTable dtNro = dv.ToTable(true, "idCli");
            return dtNro.Rows.Count;
        }
        #endregion 

        /// <summary>
        /// Cuenta el numero de creditos que estan chekados para la reasignación de estos.
        /// </summary>
        /// <returns>Cantidad de registros chekados</returns>
        public int contarCreditosSeleccionados()
        {
            int iContador = 0;
            DataTable dtCreditosOrigen = (DataTable)dtgCreOri.DataSource;
            if (dtgCreOri.Rows.Count>0)
            {
                foreach (DataRow drCredito in dtCreditosOrigen.Rows)
                {
                    if ((bool)drCredito[0])
                    {
                        iContador++;
                    }
                }
                return iContador;
            }
            return 0;
        }
        /// <summary>
        /// Cuenta el numero de creditos que estan chekados para la reasignación de estos.
        /// </summary>
        /// <returns>Cantidad de registros chekados</returns>
        public Decimal /*era double*/sumarSaldoTotalCreditosSeleccionados()
        {
            Decimal /*era double*/dMonto = 0;
            DataTable dtCreditosOrigen = (DataTable)dtgCreOri.DataSource;
            if (dtgCreOri.Rows.Count>0)
            {
                foreach (DataRow drCredito in dtCreditosOrigen.Rows)
                {
                    if ((bool)drCredito[0])
                    {
                        dMonto += Convert.ToDecimal /*era ToDouble*/(drCredito["nSaldoCapital"].ToString());
                    }
                }
                return dMonto;
            }
            else
            {
                return 0;
            }
           
        }
        /// <summary>
        /// Busca y selecciona todos los creditos de un determinado cliente
        /// </summary>
        /// <param name="idSeleccionado">la fila seleccionada</param>
        public void seleccionarTodosLosCreditosDeUnCliente(int idSeleccionado)
        {
            
            if (idSeleccionado > 0)
            {
                int idCliente = Convert.ToInt32(dtgCreOri.Rows[idSeleccionado].Cells["idCli"].Value);
                for (int i = 0; i < dtgCreOri.Rows.Count; i++)
                {
                    if (idCliente == Convert.ToInt32(dtgCreOri.Rows[i].Cells["idCli"].Value))
                    {
                        dtgCreOri.Rows[i].Cells["lSeleCta"].Value = dtgCreOri.Rows[idSeleccionado].Cells["lSeleCta"].Value;
                    }
                }
            }
            
        }

        private void cboCondicionContable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conBusUbigOrigen.Enabled)
            {
                if (this.conBusUbigOrigen.cboAnexo.SelectedIndex > 0)
                    LoadCreOriUbi((int)this.conBusUbigOrigen.cboAnexo.SelectedValue);
                else
                {
                    LoadCreOri();
                    actualizarSeleccionados();
                }                    
            }       
        }

   }
}
