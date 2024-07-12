using CRE.CapaNegocio;
using EntityLayer; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmRegDocConfiguracion : frmBase
    {
        public clsTipoArchivoEscaneado pDocumento = new clsTipoArchivoEscaneado();
        private clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
        clsListaTipoArchivoEscaneado plistaDocumento = new clsListaTipoArchivoEscaneado();
        public clsListaConfiguracionTipoArchivoEscaneado listaConfiguracion = new clsListaConfiguracionTipoArchivoEscaneado();
        public bool lGuardado = false;
        public frmRegDocConfiguracion()
        {
            InitializeComponent();
        }
        public frmRegDocConfiguracion(clsTipoArchivoEscaneado documento )
        {
            InitializeComponent();
            this.pDocumento = new clsTipoArchivoEscaneado();
            this.pDocumento = (clsTipoArchivoEscaneado)documento.Clone();
        }
      
        private void frmDocumentoConfigura_Load(object sender, EventArgs e)
        {
            cboGrupoCargaArchivo1.ListarGrupoCargaArchivo();
            this.plistaDocumento = clsConfiguracion.CNListarTipoArchivoGeneral(); 
            this.dtpFechaVigencia.Value = clsVarGlobal.dFecSystem.Date;
            if (this.pDocumento.idTipoArchivo == 0)
            {
                this.Text = "Registrar documentos"; 
               
                this.txtNuevoArchivo.Text = string.Empty;
                this.cboGrupoCargaArchivo1.SelectedIndex = -1; 
                this.dtpFechaVigencia.Value = clsVarGlobal.dFecSystem.Date;
                this.rbtConFechaVigencia.CheckedChanged -= rbtBase1_CheckedChanged;
                this.rbtConFechaVigencia.Checked = false;
                this.rbtConFechaVigencia.CheckedChanged += rbtBase1_CheckedChanged;
                this.rbtIndeterminado.Checked = true;
                this.chcConfiguracionBase.Enabled = true;
                pDocumento.dFecRegistro = clsVarGlobal.dFecSystem.Date;
                pDocumento.idUsuReg= clsVarGlobal.User.idUsuario;
                int nNuevoOrden= plistaDocumento.Max(x=>x.nOrden); 
                this.txtOrden.Text = (nNuevoOrden+1).ToString();
                this.txtOrden.Enabled = false;
            }
            else
            {
                this.Text = "Actualizar documentos";
                this.txtOrden.Text=pDocumento.nOrden.ToString()  ;
                this.txtNuevoArchivo.Text=pDocumento.cTipoArchivo ;

                this.rbtConFechaVigencia.CheckedChanged -= rbtBase1_CheckedChanged;
                this.rbtConFechaVigencia.Checked = pDocumento.lConFechaVigencia;
                this.rbtConFechaVigencia.CheckedChanged += rbtBase1_CheckedChanged;

                
                this.rbtIndeterminado.Checked = pDocumento.lIndefinido; 
                this.cboGrupoCargaArchivo1.SelectedValue = pDocumento.idGrupoArchivo  ;
                if(pDocumento.dFechaVigencia != null)
                {
               
                    if (this.pDocumento.dFechaVigencia >= clsVarGlobal.dFecSystem.Date)
                    {
                        this.dtpFechaVigencia.MinDate =clsVarGlobal.dFecSystem.Date;
                    }
                    else
                    {
                        this.dtpFechaVigencia.MinDate = this.pDocumento.dFechaVigencia.Value;

                    } 
                    this.dtpFechaVigencia.Value = (DateTime)pDocumento.dFechaVigencia;
                }

                this.cboGrupoCargaArchivo1.Enabled = false;
                this.txtNuevoArchivo.ReadOnly = true;
                this.txtOrden.Enabled = true;
                this.chcConfiguracionBase.Enabled = false;
                pDocumento.dFecAct = clsVarGlobal.dFecSystem.Date;
                pDocumento.idUsuAct= clsVarGlobal.User.idUsuario; 

            }

            

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.btnGrabar1.Enabled = false; 
            if (cboGrupoCargaArchivo1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir grupo de archivos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar1.Enabled = true; 
                return;
            }
            if (String.IsNullOrEmpty(txtNuevoArchivo.Text))
            {
                MessageBox.Show("Debe ingresar nombre del documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar1.Enabled = true; 
                return;
            }
            if (chcConfiguracionBase.Checked && String.IsNullOrEmpty(txtDocumentoBase.Text))
            {
                MessageBox.Show("Debe ingresar documento base de donde se realizará la replicara.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar1.Enabled = true; 
                return;
            }
            pDocumento.nOrden = Convert.ToInt32(txtOrden.Text);
            pDocumento.cTipoArchivo = txtNuevoArchivo.Text.Trim();
            pDocumento.idGrupoArchivo = (int)cboGrupoCargaArchivo1.SelectedValue;
            pDocumento.dFechaVigencia = rbtConFechaVigencia.Checked ? dtpFechaVigencia.Value : (DateTime?)null;
            pDocumento.lConFechaVigencia = rbtConFechaVigencia.Checked;
            pDocumento.lIndefinido = rbtIndeterminado.Checked;
           
            clsDBResp dtRes = clsConfiguracion.GrabarNuevaTipoDocumento(pDocumento);

        
            if (dtRes.nMsje == 0)
            {
                this.pDocumento.idTipoArchivo = dtRes.idGenerado;
                this.btnGrabar1.Enabled = false; 
                this.cboGrupoCargaArchivo1.Enabled = false;
                this.txtNuevoArchivo.ReadOnly = true;
                this.txtOrden.Enabled = false;
                this.dtpFechaVigencia.Enabled = false;
                this.rbtConFechaVigencia.Enabled = false;
                this.rbtIndeterminado.Enabled = false;
                this.chcConfiguracionBase.Enabled = false;
                this.btnMiniBusqDocumento.Enabled = false;
                this.lGuardado = true;
                MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
            else
            {
                MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lGuardado = false;
                this.btnGrabar1.Enabled = true; 
            }

        }
         

      
        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbtBase1_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaVigencia.Enabled =true;
            if (this.pDocumento.idTipoArchivo == 0 && rbtConFechaVigencia.Checked)
            {
                dtpFechaVigencia.MinDate = clsVarGlobal.dFecSystem.AddDays(1);
            }
            else
            {
                if (this.pDocumento.lIndefinido && rbtConFechaVigencia.Checked)
                {
                    dtpFechaVigencia.MinDate = clsVarGlobal.dFecSystem.AddDays(1);
                }
                else
                {
                    if (this.pDocumento.idTipoArchivo == 0)
                    {
                        dtpFechaVigencia.MinDate = clsVarGlobal.dFecSystem;
                        dtpFechaVigencia.Value = clsVarGlobal.dFecSystem;
                    }
                    else
                    {
                        dtpFechaVigencia.MinDate = clsVarGlobal.dFecSystem.AddYears(-1);
                        dtpFechaVigencia.Value = clsVarGlobal.dFecSystem;

                        if (pDocumento.dFechaVigencia != null)
                        {

                            if (this.pDocumento.dFechaVigencia >= clsVarGlobal.dFecSystem.Date)
                            {
                                this.dtpFechaVigencia.MinDate = clsVarGlobal.dFecSystem.Date;
                            }
                            else
                            {
                                this.dtpFechaVigencia.MinDate = this.pDocumento.dFechaVigencia.Value;

                            }
                            this.dtpFechaVigencia.Value = (DateTime)pDocumento.dFechaVigencia;
                        }
                    }
                   
                }
            }
            
        }

        private void rbtIndeterminado_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaVigencia.Enabled = false;

        }

        private void chcConfiguracionBase_CheckedChanged(object sender, EventArgs e)
        { 
            btnMiniBusqDocumento.Enabled = chcConfiguracionBase.Checked;
            if (!chcConfiguracionBase.Checked)
            {
                pDocumento.idTipArcOrigen = 0;
                pDocumento.cTipArcOrigen =null;
                txtDocumentoBase.Text=string.Empty;
            }
        }

        private void btnMiniBusqDocumento_Click(object sender, EventArgs e)
        {
            frmBuscarTipoArchivoConfiguracion frmBuscar = new frmBuscarTipoArchivoConfiguracion(plistaDocumento);
            frmBuscar.ShowDialog();
            if (frmBuscar.lAceptado)
            {
                pDocumento.idTipArcOrigen = frmBuscar.tipArcOrigen.idTipoArchivo;
                pDocumento.cTipArcOrigen = frmBuscar.tipArcOrigen.cTipoArchivo;
                txtDocumentoBase.Text = frmBuscar.tipArcOrigen.cTipoArchivo;
            }
        }
    }
}
