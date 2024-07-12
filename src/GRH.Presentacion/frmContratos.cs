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
using GEN.CapaNegocio;
using GEN.ControlesBase;

namespace GRH.Presentacion
{
    public partial class frmContratos : frmBase
    {
        private string cOpcion="";
        private int pidContrato=0;
        private DateTime dFechaMaxima;
        public frmContratos()
        {
            InitializeComponent();
        }

        private void frmContratos_Load(object sender, EventArgs e)
        {
            DataTable dtContrato = new clsCNBuscaPersonal().ListarTipoContrato();
            cboTipoContrato.SelectedIndexChanged -= new EventHandler(cboTipoContrato_SelectedIndexChanged);
            cboTipoContrato.DataSource = dtContrato;
            cboTipoContrato.ValueMember = dtContrato.Columns[0].ToString();
            cboTipoContrato.DisplayMember = dtContrato.Columns[1].ToString();
            cboTipoContrato.SelectedIndexChanged += new EventHandler(cboTipoContrato_SelectedIndexChanged);

            DataTable dtEstContrato = new clsCNBuscaPersonal().ListarEstadoContrato();
            cboEstado.DataSource = dtEstContrato;
            cboEstado.ValueMember = dtEstContrato.Columns[0].ToString();
            cboEstado.DisplayMember = dtEstContrato.Columns[1].ToString();
            iniciodatos();
            HabilitarControles(false);
        }
        private void iniciodatos()
        {
            dtFechaIni.Value = clsVarGlobal.dFecSystem;
            dtFechaCese.Value = clsVarGlobal.dFecSystem;
            dtFecVencimiento.Value = Convert.ToDateTime("01/01/1900"); 

            cboAgencias1.SelectedValue = -1;
            cboArea1.SelectedValue = -1;
            cboTipoContrato.SelectedValue = -1;
            cboEstado.SelectedValue = -1;
            cboCargoPersonal.SelectedValue = -1;

            cboTipoPagoRemun1.SelectedIndexChanged -= new EventHandler(cboTipoPagoRemun1_SelectedIndexChanged);
            cboTipoPagoRemun1.ListTipoPagoRemun(0);
            cboTipoPagoRemun1.SelectedValue = -1;
            cboTipoPagoRemun1.SelectedIndexChanged += new EventHandler(cboTipoPagoRemun1_SelectedIndexChanged);
            cboTipoPagoRemun2.SelectedValue = -1;

            cboModalidadContrato1.SelectedValue = -1;

        }
        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusCol1.txtCod.Text.Trim() == "")
            {
                MessageBox.Show("No se encontró registro", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCol1.txtCod.Focus();
                return;
            }

            Int32 nidCliente = Convert.ToInt32(this.conBusCol1.idCliPer);
            this.BuscaPersonal(nidCliente);
            conBusCol1.btnConsultar.Enabled = true;
            conBusCol1.txtCod.Enabled = false;
        }

        public void BuscaPersonal(int nIdPersonal)
        {
            int x_idEstado = 0;
            dtgContratos.DataSource = null;          

            DataTable dtHistorial=new DataTable();
            clsCNBuscaPersonal BuscaPersonal = new clsCNBuscaPersonal();
             dtHistorial = BuscaPersonal.DatosHistorial(nIdPersonal);
             for (int i = 0; i < dtHistorial.Rows.Count; i++)
             {
                 x_idEstado = Convert.ToInt32(dtHistorial.Rows[i]["idEstado"]);
                 txtCodRelLab.Text = dtHistorial.Rows[i]["idRelacionLab"].ToString();
                 txtRelLab.Text = dtHistorial.Rows[i]["cRelLaboral"].ToString();

                 //if (Convert.ToInt32(dtHistorial.Rows[i]["idEstado"]) == 1)
                 //{
                 //    txtCodRelLab.Text = dtHistorial.Rows[i]["idRelacionLab"].ToString();
                 //    txtRelLab.Text = dtHistorial.Rows[i]["cRelLaboral"].ToString();
                 //}
             }
             DataTable dtContrato = new DataTable();
             clsCNBuscaPersonal Contrato = new clsCNBuscaPersonal();
             dtContrato = Contrato.ListarContratos(Convert.ToInt32(txtCodRelLab.Text));

             dtgContratos.DataSource = dtContrato.DefaultView;
             dtgContratos.Focus();
             dtgContratos.Columns["idContrato"].Visible = false;
             dtgContratos.Columns["idRelacionLab"].Visible = false;
             dtgContratos.Columns["idTipoContrato"].Visible = false;
             dtgContratos.Columns["idArea"].Visible = false;
             dtgContratos.Columns["IdAgencia"].Visible = false;
             dtgContratos.Columns["idEstado"].Visible = false;
             dtgContratos.Columns["lVigente"].Visible = false;
             dtgContratos.Columns["dFechaRegistro"].Visible = false;
             dtgContratos.Columns["idCargo"].Visible = false;
             dtgContratos.Columns["idModalidadCont"].Visible = false;
             dtgContratos.Columns["idTipoPagoRem"].Visible = false;
             dtgContratos.Columns["idTipoPagoRemPadre"].Visible = false;
            
             dtgContratos.Columns["dFechaInicio"].HeaderText = "Fecha Inicio";
             dtgContratos.Columns["dFechaCese"].HeaderText = "Fecha Final";
             dtgContratos.Columns["dFechaVencimiento"].HeaderText = "Fecha Venc.";

             dtgContratos.Columns["Agencia"].HeaderText = "Agencia";
             dtgContratos.Columns["cArea"].HeaderText = "Area";
             dtgContratos.Columns["cCargo"].HeaderText = "Cargo";
             dtgContratos.Columns["cTipoContratoCorto"].HeaderText = "Tipo Contrato";             
             dtgContratos.Columns["cEstado"].HeaderText = "Estado";

             dtgContratos.Columns["dFechaInicio"].DisplayIndex = 1;
             dtgContratos.Columns["dFechaVencimiento"].DisplayIndex = 2;
             dtgContratos.Columns["dFechaCese"].DisplayIndex = 3;
             dtgContratos.Columns["Agencia"].DisplayIndex = 4;
             dtgContratos.Columns["cArea"].DisplayIndex = 5;
             dtgContratos.Columns["cCargo"].DisplayIndex = 6;
             dtgContratos.Columns["cTipoContratoCorto"].DisplayIndex = 7;
             dtgContratos.Columns["cEstado"].DisplayIndex = 8;
                        
            //========================================================================
            //--Asignando Valores
            //========================================================================
             if (dtContrato.Rows.Count == 0)
             {
                
                 HabilitarControles(false);
                 this.btnNuevo1.Enabled = true;
                 this.btnEditar1.Enabled = false;
                 this.btnGrabar1.Enabled = false;
                 this.btnCancelar1.Enabled = true;
                 dtgContratos.Enabled = false;
                 btnEliminar1.Enabled = false;
             }
             else
             {
                 this.btnNuevo1.Enabled = true;
                 this.btnEditar1.Enabled = true;
                 this.btnGrabar1.Enabled = false;
                 this.btnCancelar1.Enabled = true;
                 object maxDate = dtContrato.Compute("MAX(dFechaCese)", null);
                 dFechaMaxima = (DateTime)maxDate;
                 HabilitarControles(false);
                 dtgContratos.Enabled = true;
                 btnEliminar1.Enabled = true;
             }
             if (x_idEstado == 2)
             {
                 this.btnNuevo1.Enabled = false;
             }
        }

        private void HabilitarControles(bool lValue)
        {
            cboAgencias1.Enabled = lValue ;
            cboArea1.Enabled = lValue;
            cboTipoContrato.Enabled = lValue;
            dtFechaIni.Enabled = lValue;
            dtFechaCese.Enabled = lValue;
            dtFecVencimiento.Enabled = lValue;
            cboCargoPersonal.Enabled = lValue;
            //cboEstado.Enabled = lValue;
            dtgContratos.Enabled = !lValue;
            cboTipoPagoRemun1.Enabled = lValue;
            cboTipoPagoRemun2.Enabled = lValue;
            cboModalidadContrato1.Enabled = lValue;
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias1.Text.Trim() != "")
            {
                cboArea1.SelectedIndexChanged -= new EventHandler(cboArea1_SelectedIndexChanged);
                this.cboArea1.CargarTodosporArea(Convert.ToInt32(cboAgencias1.SelectedValue));
                this.cboArea1.SelectedIndex = -1;
                cboArea1.SelectedIndexChanged += new EventHandler(cboArea1_SelectedIndexChanged);
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {          
            HabilitarControles(true);
            this.btnNuevo1.Enabled = false;
            this.btnEditar1.Enabled = false;
            this.btnGrabar1.Enabled = true ;
            this.btnCancelar1.Enabled = true;
            btnEliminar1.Enabled = false;
            dtFechaCese.Enabled = false;
            dtFecVencimiento.Enabled = false;

            cOpcion = "N";
            pidContrato = 0;
            iniciodatos();
            cboEstado.Enabled = false;            
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            //HabilitarControles(false);
            this.btnNuevo1.Enabled = false;
            this.btnEditar1.Enabled = false;
            this.btnGrabar1.Enabled = true;
            this.btnCancelar1.Enabled = true;
            btnEliminar1.Enabled = false;
            dtFechaCese.Enabled = true;
            cOpcion = "E";
            cboEstado.SelectedValue = 5;
            cboEstado.Enabled = false;
            dtgContratos.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            
            if (cOpcion.Equals("N"))
            {
                cboEstado.SelectedValue = 1;
            }
            DataTable dtHistorial = new DataTable();
            clsCNGuardaPersonal GuardaContatoPer = new clsCNGuardaPersonal();
            DataTable dtResul = new DataTable();
            int idRelacionLab=Convert.ToInt32(txtCodRelLab.Text);
            int idTipoContrato=Convert.ToInt32(cboTipoContrato.SelectedValue); 
            DateTime dFechaInicio=dtFechaIni.Value;
            DateTime dFechaVencimiento=dtFecVencimiento.Value; 
            int idArea=Convert.ToInt32(cboArea1.SelectedValue);
            int IdAgencia=Convert.ToInt32(cboAgencias1.SelectedValue);
            int idEstado=Convert.ToInt32(cboEstado.SelectedValue);
            bool lVigente=true;
            int idCargo = Convert.ToInt32(cboCargoPersonal.SelectedValue);
            int idModalidadCont = Convert.ToInt32(cboModalidadContrato1.SelectedValue) ;
            int idTipoPagoRem = Convert.ToInt32(cboTipoPagoRemun2.SelectedValue);

            if (cOpcion.Equals("N"))
            {
                dtResul = GuardaContatoPer.RegistraContratoPersonal(idRelacionLab, idTipoContrato, dFechaInicio, dFechaVencimiento, idArea, IdAgencia, idEstado, idCargo, idModalidadCont, idTipoPagoRem);
            }  
            if (cOpcion.Equals("E"))
            {
                DateTime dFechaCese = dtFechaCese.Value;
                dtResul = GuardaContatoPer.ActualizaContratoPersonal(pidContrato, idRelacionLab, idTipoContrato, dFechaInicio, dFechaCese, dFechaVencimiento, idArea, IdAgencia, idEstado, lVigente, idCargo, idModalidadCont, idTipoPagoRem);
            }
            if (Convert.ToInt32(dtResul.Rows[0]["nResp"])==1)
            {
                Int32 nidCliente = Convert.ToInt32(this.conBusCol1.idCliPer);
                this.BuscaPersonal(nidCliente);

                MessageBox.Show(dtResul.Rows[0]["mResp"].ToString(),"Mantenimiento de Contratos",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                
                HabilitarControles(false);
                this.btnNuevo1.Enabled = true;
                this.btnEditar1.Enabled = true;
                this.btnGrabar1.Enabled = false;
                this.btnCancelar1.Enabled = true;
                btnEliminar1.Enabled = true;
                dtgContratos.Enabled = true;
            }
            
            if (dtFechaIni.Value <= clsVarGlobal.dFecSystem && clsVarGlobal.dFecSystem < dtFecVencimiento.Value && cOpcion.Equals("N"))
            {
                cboEstado.SelectedValue = 3;
            }           
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            iniciodatos();
            conBusCol1.idUsu = "";
            conBusCol1.cDocID = "";
            conBusCol1.cCargoPer = "";
            conBusCol1.idCliPer = "";
            conBusCol1.txtCargo.Clear();
            conBusCol1.txtCod.Clear();
            conBusCol1.txtNom.Clear();
            txtCodRelLab.Clear();
            txtRelLab.Clear();
            dtgContratos.DataSource = null;
            cboAgencias1.SelectedValue = -1;
            cboArea1.SelectedValue = -1;
            cboTipoContrato.SelectedValue = -1;
            cboEstado.SelectedValue = -1;
            HabilitarControles(false);
            this.btnNuevo1.Enabled = false;
            dtgContratos.Enabled = false;
           
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            btnEliminar1.Enabled = false;
            //if (dtgContratos.RowCount>0)
            //{
                this.btnEditar1.Enabled = false;
            //}  
            conBusCol1.txtCod.Enabled = true;
            conBusCol1.txtCod.Focus();
        }
        private bool validar()
        {
            if (conBusCol1.idCliPer.Equals(""))
            {
                MessageBox.Show("Debe seleccionar al personal","Mantenimiento de contrato",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }
            if (txtCodRelLab.Text.Equals(""))
            {
                MessageBox.Show("El personal no cuenta con una relacion laboral", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboAgencias1.SelectedIndex<0)
            {
                MessageBox.Show("Debe seleccionar la agencia", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboArea1.SelectedIndex <0)
            {
                MessageBox.Show("Debe seleccionar el área", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboTipoContrato.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de contrato", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboCargoPersonal.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el cargo", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (cOpcion.Equals("E"))
            {
                if (Convert.ToInt32(cboTipoContrato.SelectedValue) == 2) //--contrato Parcial
                {
                    if (dtFechaCese.Value > dtFecVencimiento.Value)
                    {
                        MessageBox.Show("La Fecha de Finalización, no puede ser mayor a la fecha de Vencimiento", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtFechaCese.Focus();
                        return true;
                    }
                }
            }


            if (cboModalidadContrato1.SelectedIndex < 0)
            {
                 MessageBox.Show("Debe seleccionar la modalidad del contrato", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 cboModalidadContrato1.Focus();
                 return true;
            }

            if (cboTipoPagoRemun1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de pago", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPagoRemun1.Focus();
                return true;
            }

            if (cboTipoPagoRemun2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la modalidad del tipo de pago", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPagoRemun2.Focus();
                return true;
            }

            if (dFechaMaxima >= dtFechaIni.Value && cOpcion.Equals("N"))
            {
                MessageBox.Show("La fecha de inicio debe ser mayor a la ultima fecha de finalización", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if ( dtFechaIni.Value < clsVarGlobal.dFecSystem && cOpcion.Equals("N"))
            {
                MessageBox.Show("La fecha de inicio debe ser mayor a la fecha del Sistema", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if ( Convert.ToInt32(cboTipoContrato.SelectedValue) != 1)
            {
                if (dtFechaIni.Value >= dtFecVencimiento.Value)
                {
                    MessageBox.Show("La fecha de vencimiento debe ser mayor a la fecha de inicio ", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }            
            
            if (dtFechaIni.Value >= dtFechaCese.Value && cOpcion.Equals("E"))
            {
                MessageBox.Show("La fecha de cese debe ser mayor a la fecha de inicio ", "Mantenimiento de contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }            
            return false;
        }

        private void dtgContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                MostrarDatos();           
        }

        private void MostrarDatos()
        {
            if (Convert.ToInt32(this.dtgContratos.Rows.Count) > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgContratos.CurrentRow.Index);
                pidContrato =Convert.ToInt32( dtgContratos.Rows[filaseleccionada].Cells["idContrato"].Value.ToString());
                cboAgencias1.SelectedValue =Convert.ToInt32( dtgContratos.Rows[filaseleccionada].Cells["IdAgencia"].Value.ToString());
                cboArea1.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idArea"].Value.ToString());
                cboTipoContrato.SelectedValue =Convert.ToInt32( dtgContratos.Rows[filaseleccionada].Cells["idTipoContrato"].Value.ToString());
                dtFechaIni.Value  =   Convert.ToDateTime(dtgContratos.Rows[filaseleccionada].Cells["dFechaInicio"].Value.ToString());
                dtFecVencimiento.Value = Convert.ToDateTime(dtgContratos.Rows[filaseleccionada].Cells["dFechaVencimiento"].Value.ToString());
                cboEstado.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idEstado"].Value.ToString());               
                dtFechaCese.Value = Convert.ToDateTime(dtgContratos.Rows[filaseleccionada].Cells["dFechaCese"].Value.ToString());
                cboCargoPersonal.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idCargo"].Value.ToString());
                cboModalidadContrato1.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idModalidadCont"].Value.ToString());
                cboTipoPagoRemun1.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idTipoPagoRemPadre"].Value.ToString());
                cboTipoPagoRemun2.SelectedValue = Convert.ToInt32(dtgContratos.Rows[filaseleccionada].Cells["idTipoPagoRem"].Value.ToString());
                dtFecVencimiento.Enabled = false;
             }
        }       

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dtgContratos.Rows.Count) > 0)
            {
                dtgContratos.Focus();
                int filaseleccionada = Convert.ToInt32(this.dtgContratos.CurrentRow.Index);               
               
                if (Convert.ToDateTime(dtgContratos.Rows[filaseleccionada].Cells["dFechaCese"].Value.ToString())!=dFechaMaxima)
                {
                    MessageBox.Show("Debe eliminar el último contrato", "Mantenimiento de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable dtHistorial = new DataTable();
                clsCNGuardaPersonal GuardaContatoPer = new clsCNGuardaPersonal();
                DataTable dtResul = new DataTable();
                int idRelacionLab = Convert.ToInt32(txtCodRelLab.Text);
                int idTipoContrato = Convert.ToInt32(cboTipoContrato.SelectedValue);
                DateTime dFechaInicio = dtFechaIni.Value;
                DateTime dFechaVencimiento = dtFecVencimiento.Value;
                int idArea = Convert.ToInt32(cboArea1.SelectedValue);
                int IdAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
                int idEstado = 2;
                bool lVigente = false;
                int idCargo = Convert.ToInt32(cboCargoPersonal.SelectedValue);
                DateTime dFechaCese = dtFechaCese.Value;
                int idModalidadCont = Convert.ToInt32(cboModalidadContrato1.SelectedValue);
                int idTipoPagoRem = Convert.ToInt32(cboTipoPagoRemun2.SelectedValue);

                dtResul = GuardaContatoPer.ActualizaContratoPersonal(pidContrato, idRelacionLab, idTipoContrato, dFechaInicio, dFechaCese, dFechaVencimiento, idArea, IdAgencia, idEstado, lVigente, idCargo, idModalidadCont, idTipoPagoRem);           
                if (Convert.ToInt32(dtResul.Rows[0]["nResp"])==1)
                {
                    Int32 nidCliente = Convert.ToInt32(this.conBusCol1.idCliPer);
                    this.BuscaPersonal(nidCliente);
                    MessageBox.Show(dtResul.Rows[0]["mResp"].ToString(),"Mantenimiento de Contratos",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                    HabilitarControles(false);
                    this.btnNuevo1.Enabled = true;
                    
                    this.btnGrabar1.Enabled = false;
                    this.btnCancelar1.Enabled = true;
                    if (dtgContratos.RowCount>0)
                    {
                        this.btnEditar1.Enabled = true;
                        iniciodatos();
                    }
                }
            }
        }

        private void dtgContratos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArea1.Text.Trim().ToString() != "" && cboArea1.SelectedIndex > -1)
            {
                cboCargoPersonal.CargarCargoTodos(Convert.ToInt32(cboArea1.SelectedValue));
                cboCargoPersonal.SelectedIndex = -1;
            }
        }

        private void cboTipoPagoRemun1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoPagoRemun2.ListTipoPagoRemun(Convert.ToInt32(cboTipoPagoRemun1.SelectedValue));

            if (Convert.ToInt32(cboTipoPagoRemun1.SelectedIndex)==0)
            {
                cboTipoPagoRemun2.Enabled = false;
            }
            else
            {
                cboTipoPagoRemun2.SelectedValue = -1;
                cboTipoPagoRemun2.Enabled = true;
            }
        }      

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoContrato.SelectedValue) > 1)
            {
                dtFecVencimiento.Value = clsVarGlobal.dFecSystem;
                dtFecVencimiento.Enabled = true;
            }
            else
            {
                dtFecVencimiento.Value = Convert.ToDateTime("01/01/1900"); 
                dtFecVencimiento.Enabled = false;
            }
        }

        private void cboCargoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
