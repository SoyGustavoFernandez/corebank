using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CLI.Presentacion
{
    public partial class frmFuentesIngreso : frmBase
    {
        clsCliente objcliente = null;
        clsCliente objClienteMaestro;
        clsCNRetDatosCliente cnDatCli = new clsCNRetDatosCliente();
        clsCNFuentesIngreso cnfuenteingreso = new clsCNFuentesIngreso();
        int idFuenteIngreso = 0;
        public frmFuentesIngreso()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtCodicionLaboral = cnfuenteingreso.CNListarCondicionLaboralCliente();
            cboCondicionLaboral.DataSource = dtCodicionLaboral;
            cboCondicionLaboral.ValueMember = dtCodicionLaboral.Columns["idCondiLaboral"].ToString();
            cboCondicionLaboral.DisplayMember = dtCodicionLaboral.Columns["cCondiLaboral"].ToString();
            
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            
            this.cboTipoRelacLaboral1.cargarActivos();
            this.nudAnioLabora.Maximum = clsVarGlobal.dFecSystem.Year;
            this.nudAnioLabora.Value = clsVarGlobal.dFecSystem.Year;
            dtpFechaRegistro.Value = clsVarGlobal.dFecSystem;
        }

        private void btnBalance1_Click(object sender, EventArgs e)
        {
            if (this.lstFuentesInd.SelectedItem==null)
            {
                MessageBox.Show("Debe seleccionar una fuente de ingreso independiente por favor", "Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
                return;
            }

            clsCliente cliselecion=(clsCliente)this.lstFuentesInd.SelectedItem;
            frmBalance frmbalance = new frmBalance();
            frmbalance.clienteFuente = cliselecion;
            frmbalance.idCli = conBusCli1.idCli;
            int idFuenteIngreso = 0;

            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (cliselecion.idCli == item.idCliFuente && item.idTipoFuente == 2)
                {
                    idFuenteIngreso= item.idFuenteIngreso;
                    break;
                }
            }

            frmbalance.idFuenteIngreso = idFuenteIngreso;
            frmbalance.ShowDialog();
        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            LimpiarDatosDependiente();
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli) || frmbuscli.pcCodCli =="0")
            {
                objcliente = null;
                return;
            }

            int idcli = Convert.ToInt32(frmbuscli.pcCodCli);
            //VALIDACION SI PERTENECE A LA CRAC LOS ANDES
            int idCliCol = Convert.ToInt32(conBusCli1.txtCodCli.Text.Trim());
            DataTable dtValidaCol = cnfuenteingreso.CNValidaColByEmpresa(idCliCol, idcli);
            if (Convert.ToInt32(dtValidaCol.Rows[0]["Rpta"]) == 0)
            {
                MessageBox.Show("El cliente no es colaborador de la " + clsVarApl.dicVarGen["cNomEmpresa"], "Fuentes de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (frmbuscli.pnTipoPersona ==1)
            {
                this.conDatCli1.cargarCliente(idcli);      
            }
            else
            {
                this.conDatCli1.cargarClienteJur(idcli);
            }

            objcliente = null;
            objcliente = this.conDatCli1.cliente;

            this.conDirecPrincipal1.cargarDireccion(idcli);
            txtNumEmplea.Text = objcliente.cCantEmpl.ToString();
            cboActividadEcoDep.SelectedValue = objcliente.idActivEcoInt;
            txtCodigoEmpleado.Text = "";
            txtSueldo.Text = "0.00";
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (objClienteMaestro==null)
            {
                MessageBox.Show("Debe seleccionar a un cliente para agregar fuentes de ingreso", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (objcliente == null)
            {
                MessageBox.Show("No existen datos por añadir", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var lnoesxite = true;
            foreach (var item in lstFuentesDep.Items)
            {
                if (item.ToString() == objcliente.ToString() && ((clsCliente)item).cDocumentoID == objcliente.cDocumentoID)
                {
                    lnoesxite = false;
                }
            }
            if (lnoesxite)
            {
                //Validación de actividad principal
                clsFuentesIngreso fuentedep = new clsFuentesIngreso();
                if (chcPrincipalDep.Checked == true)
                {
                    if (objClienteMaestro.lisFuentesIngreso.Count > 0)
                    {
                        foreach (var item in objClienteMaestro.lisFuentesIngreso)
                        {
                            if (item.lIndPrincipal == true)
                            {
                                if (item.idFuenteIngreso != idFuenteIngreso)
                                {
                                    MessageBox.Show("Ya existe la actividad principal del cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    chcPrincipalDep.Checked = false;
                                    return;
                                }

                            }
                        }
                    }

                }
                //VALIDACIÓN DE DATOS 
                if (cboCondicionLaboral.Text == "")
                {
                    MessageBox.Show("Seleccione la Condición laboral", "Validación de Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboCondicionLaboral.Focus();
                    return;
                }
                if (cboTipoRelacLaboral1.Text=="")
                {
                    MessageBox.Show("Seleccione el tipo de relación laboral", "Validación de Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoRelacLaboral1.Focus();
                    return;
                } 
                if (string.IsNullOrEmpty(txtCodigoEmpleado.Text))
                {
                    MessageBox.Show("Registre el código del empleado o DNI del cliente de quien registra la fuentes de ingreso","Validación de Fuentes de Ingreso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    txtCodigoEmpleado.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSueldo.Text))
                {
                    MessageBox.Show("Registre el sueldo del cliente", "Validación de Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSueldo.Focus();
                    return;
                }

                MessageBox.Show("Se Procederá a guardar la fuente de ingreso", "Validación de Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fuentedep.idCliFuente = objcliente.idCli;
                fuentedep.idCondiLaboral = (int)cboCondicionLaboral.SelectedValue;
                fuentedep.idRelacLaboral = (int)cboTipoRelacLaboral1.SelectedValue;

                fuentedep.cCodEmpleado = txtCodigoEmpleado.Text;
                fuentedep.nLaboraDesde = Convert.ToInt32(nudAnioLabora.Value);
                fuentedep.nIngresos = txtSueldo.nDecValor;

                fuentedep.idCli = objClienteMaestro.idCli;
                fuentedep.dFechaRegistro = dtpFechaRegistro.Value;
                fuentedep.idUsuReg = clsVarGlobal.User.idUsuario;
                fuentedep.dFechaModifica = dtpFechaRegistro.Value;
                fuentedep.idUsuModifica = clsVarGlobal.User.idUsuario;
                fuentedep.idTipoFuente = 1;
                fuentedep.idCondicion = 0;
                fuentedep.idEstado = 1;
                fuentedep.idActivEco = Convert.ToInt32(cboActividadEcoDep.SelectedValue);
                fuentedep.lIndPrincipal = chcPrincipalDep.Checked; 
                fuentedep.cReferCentroLaboral = txtReferenciaLaboral.Text;
                fuentedep.cDetalleActivLaboral = txtDetalleActivCol.Text;
                fuentedep.nAnios = 0;
                fuentedep.nDias = 0;
                fuentedep.nMeses = 0;
                objClienteMaestro.lisFuentesIngreso.Add(fuentedep);

                this.lstFuentesDep.Items.Add(objcliente);
            }
            cnfuenteingreso.insactFuentesIngreso(objClienteMaestro.lisFuentesIngreso);
            listarfuentes();
            LimpiarDatosDependiente();
        }

        private bool validarFueIngDep()
        {
            bool lEstado = false;
            if (this.txtSueldo.nDecValor<=0.0M)
            {
                MessageBox.Show("Mensaje", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSueldo.Focus();
                return lEstado;
            }

            lEstado = true;

            return lEstado;
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (lstFuentesDep.SelectedItems.Count == 0)
            {
                MessageBox.Show("No hay fuentes de ingreso seleccionados", "Fuentes de Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                

            DialogResult dr = MessageBox.Show("¿Desea eliminar la fuente de ingreso seleccionada?", "Fuentes de Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            int FuenteIngrDep = 0;
            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (item.idTipoFuente == 1)
                {
                    FuenteIngrDep++;
                }
            }

            if (FuenteIngrDep == 0)
            {
                MessageBox.Show("No existen datos a eliminar", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsCliente objclisel=(clsCliente)this.lstFuentesDep.SelectedItem;

            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (objclisel.idCli == item.idCliFuente && item.idTipoFuente == 1)
                {
                    //objClienteMaestro.lisFuentesDepen.Remove(item);
                    item.idEstado = 0;
                    break;
                }
            }
            this.lstFuentesDep.Items.Remove(objclisel);
            cnfuenteingreso.insactFuentesIngreso(objClienteMaestro.lisFuentesIngreso);
            listarfuentes();
            LimpiarDatosDependiente();
        }

        private void lstFuentesDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstFuentesDep.SelectedItem == null)return;

            clsCliente objcliselec = (clsCliente)lstFuentesDep.SelectedItem;

            if (objcliselec.IdTipoPersona==1)
            {
                this.conDatCli1.cargarCliente(objcliselec.idCli);
            }
            else
            {
                this.conDatCli1.cargarClienteJur(objcliselec.idCli);
            }

            this.conDirecPrincipal1.cargarDireccion(objcliselec.idCli);
            txtNumEmplea.Text = objcliselec.cCantEmpl.ToString();

            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (item.idTipoFuente == 1 && objcliselec.idCli==item.idCliFuente)
                {
                    idFuenteIngreso = item.idFuenteIngreso;
                    cboCondicionLaboral.SelectedValue = item.idCondiLaboral;
                    cboTipoRelacLaboral1.SelectedValue = item.idRelacLaboral;
                    txtCodigoEmpleado.Text = item.cCodEmpleado;
                    nudAnioLabora.Value = item.nLaboraDesde;
                    txtSueldo.Text = item.nIngresos.ToString();
                    cboActividadEcoDep.SelectedValue= item.idActivEco;
                    txtReferenciaLaboral.Text=item.cReferCentroLaboral;
                    dtpFechaRegistro.Value=item.dFechaRegistro;
                    txtDetalleActivCol.Text = item.cDetalleActivLaboral;
                    chcPrincipalDep.Checked = item.lIndPrincipal;
                }
            }
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli==0)
	        {
                return;
	        }

            if(conBusCli1.nidTipoPersona > 1)
            {
                MessageBox.Show("Una persona jurídica no puede registrar fuentes de ingresos", "Fuentes de Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnEditar1.Enabled = false;
                return;
            }

            objClienteMaestro = cnDatCli.retornarCliente(conBusCli1.idCli);
            conBusCli1.Enabled = false;      

            this.btnEditar1.Enabled = true;

            listarfuentes();
            
        }
        private void listarfuentes()
        {
            lstFuentesInd.Items.Clear();
            lstFuentesDep.Items.Clear();
            objClienteMaestro.lisFuentesIngreso = new clslisFuentesIngreso();

            var fuentesdepen = from item in cnfuenteingreso.retornaFuentesIngreso(conBusCli1.idCli)
                               where item.idTipoFuente == 1
                               select item;

            foreach (var item in fuentesdepen.ToList())
            {
                clsCliente clifuente = cnDatCli.retornarCliente(item.idCliFuente);

                this.lstFuentesDep.Items.Add(cnDatCli.retornarCliente(clifuente.idCli, clifuente.IdTipoPersona == 1 ? "N" : "J"));
                objClienteMaestro.lisFuentesIngreso.Add(item);
            }

            var fuentesindepen = from item in cnfuenteingreso.retornaFuentesIngreso(conBusCli1.idCli)
                                 where item.idTipoFuente == 2
                                 select item;

            foreach (var item in fuentesindepen.ToList())
            {
                clsCliente clifuente = cnDatCli.retornarCliente(item.idCliFuente);
                this.lstFuentesInd.Items.Add(cnDatCli.retornarCliente(clifuente.idCli, clifuente.IdTipoPersona == 1 ? "N" : "J"));
                objClienteMaestro.lisFuentesIngreso.Add(item);
            }
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            tbcFuentesIngreso.Enabled = true;
            this.btnEditar1.Enabled = false;
            this.btnCancelar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.tbcFuentesIngreso.Enabled = false;
            this.btnEditar1.Enabled = false;
            limpiarConbuscli();
            
            conBusCli1.Enabled = true;
            conBusCli1.txtCodCli.Enabled = true;
            lstFuentesDep.Items.Clear();
            lstFuentesInd.Items.Clear();
            LimpiarDatosDependiente();
            LimpiarIndependiente();
        }
        private void LimpiarDatosDependiente()
        {
            //FUENTES DE INGRESO DEPENDIENTES:
            conDatCli1.txtCodCli.Clear();
            conDatCli1.txtNombre.Clear();
            conDatCli1.txtNroDoc.Clear();
            txtNumEmplea.Clear();
            conDirecPrincipal1.textZona.Clear();
            conDirecPrincipal1.textVia.Clear();
            conDirecPrincipal1.textNro.Clear();
            conDirecPrincipal1.textDpto.Clear();
            conDirecPrincipal1.textInt.Clear();
            conDirecPrincipal1.textKm.Clear();
            conDirecPrincipal1.textMz.Clear();
            conDirecPrincipal1.textLote.Clear();
            conDirecPrincipal1.txtDireccion.Clear();
            conDirecPrincipal1.txtReferencia.Clear();
            cboActividadEcoDep.SelectedIndex=-1;
            txtReferenciaLaboral.Clear();
            dtpFechaRegistro.Value = clsVarGlobal.dFecSystem;
            cboCondicionLaboral.SelectedIndex =-1;
            txtCodigoEmpleado.Clear();
            cboTipoRelacLaboral1.SelectedIndex =-1;
            txtDetalleActivCol.Clear();
            txtSueldo.Clear();
            chcPrincipalDep.Checked = false;
        
        }
        private void LimpiarIndependiente()
        {
            //FUENTES DE INGRESO INDEPENDIENTE:
            conDatCli2.txtCodCli.Clear();
            conDatCli2.txtNombre.Clear();
            conDatCli2.txtNroDoc.Clear();
            txtNumEmpleaInd.Clear();
            conDirecPrincipal2.textZona.Clear();
            conDirecPrincipal2.textVia.Clear();
            conDirecPrincipal2.textNro.Clear();
            conDirecPrincipal2.textDpto.Clear();
            conDirecPrincipal2.textInt.Clear();
            conDirecPrincipal2.textKm.Clear();
            conDirecPrincipal2.textMz.Clear();
            conDirecPrincipal2.textLote.Clear();
            conDirecPrincipal2.txtDireccion.Clear();
            conDirecPrincipal2.txtReferencia.Clear();
            cboActividadInternaIndep.SelectedIndex = -1;
            nudAnios.Value = 0;
            nudMeses.Value = 0;
            nudDias.Value = 0;
            chcPrinIndep.Checked = false;
            nudFamMas.Value = 0;
            nudFamFem.Value = 0;
            nudNoFamMas.Value = 0;
            nudNoFamFem.Value = 0;
            rbtnMicroEmp.Checked = false;
            rbtnPeqEmp.Checked = false;
        }
        private void limpiarConbuscli()
        {
            conBusCli1.txtCodAge.Text = "";
            conBusCli1.txtCodCli.Text = "";
            conBusCli1.txtCodInst.Text = "";
            conBusCli1.txtDireccion.Text = "";
            conBusCli1.txtNombre.Text = "";
            conBusCli1.txtNroDoc.Text = "";
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            //VALIDAR CAMPOS:
            //Validad que exista una actividad principal
            int nActivPrinc = 0;
            if (objClienteMaestro.lisFuentesIngreso.Count>0)
            {
                foreach (var item in objClienteMaestro.lisFuentesIngreso)
                {
                    if (item.lIndPrincipal == true)
                    {
                        nActivPrinc = 1;
                    }
                }
            }
           
            if (nActivPrinc==0)
            {
                MessageBox.Show("Selecione la actividad principal del cliente","fuentes de ingreso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Inicio-Registro de fuentes de ingreso del cliente", this.btnAgregar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            cnfuenteingreso.insactFuentesIngreso(objClienteMaestro.lisFuentesIngreso);            

            MessageBox.Show("Se grabaron correctamente los datos ingresados", "Registro Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Fin-Registro de fuentes de ingreso del cliente", this.btnAgregar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        private void btnBusCliente2_Click(object sender, EventArgs e)
        {
            LimpiarIndependiente();
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli) || frmbuscli.pcCodCli == "0")
            {
                objcliente = null;
                return;
            }

            

            int idcli = Convert.ToInt32(frmbuscli.pcCodCli);

            if (frmbuscli.pnTipoPersona == 1)
            {
                if (idcli != Convert.ToInt32(conBusCli1.txtCodCli.Text.Trim()))
                {
                    MessageBox.Show("No puede agregar a otro cliente que no sea el mismo", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.conDatCli2.cargarCliente(idcli);
            }
            else
            {
                this.conDatCli2.cargarClienteJur(idcli);
            }

            objcliente = null;
            objcliente = this.conDatCli2.cliente;

            this.conDirecPrincipal2.cargarDireccion(idcli);
            txtNumEmpleaInd.Text = objcliente.cCantEmpl.ToString();
            cboActividadInternaIndep.SelectedValue = objcliente.idActivEcoInt;
            nudFamFem.Value= 0;
            nudFamMas.Value = 0;
            nudNoFamFem.Value = 0;
            nudNoFamMas.Value = 0;
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            if (objClienteMaestro == null)
            {
                MessageBox.Show("Debe seleccionar a un cliente para agregar fuentes de ingreso", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (objcliente == null)
            {
                MessageBox.Show("No existen datos por añadir","Fuentes de Ingreso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            var lnoesxite = true;
            foreach (var item in this.lstFuentesInd.Items)
            {
                if (item.ToString() == objcliente.ToString() && ((clsCliente)item).cDocumentoID == objcliente.cDocumentoID)
                {
                    lnoesxite = false;
                }
            }
            if (lnoesxite)
            {
                //Validar actividad principal
                if (chcPrinIndep.Checked == true)
                {
                    if (objClienteMaestro.lisFuentesIngreso.Count > 0)
                    {
                        foreach (var item in objClienteMaestro.lisFuentesIngreso)
                        {
                            if (item.lIndPrincipal == true)
                            {
                                if (item.idFuenteIngreso != idFuenteIngreso)
                                {
                                    MessageBox.Show("Ya existe la actividad principal del cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    chcPrinIndep.Checked = false;
                                    return;
                                }

                            }
                        }
                    }
                }
                //VALIDAR DATOS 
                if (cboActividadInternaIndep.Text=="")
                {
                    MessageBox.Show("Seleccione la actividad económica del cliente","Fuentes de ingreso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    cboActividadInternaIndep.Focus();
                    return;
                }

                if (nudAnios.Value == 0)
                {
                    if (nudMeses.Value == 0)
                    {
                        if (nudDias.Value == 0)
                        {
                            MessageBox.Show("No puede tener 0 días de experiencia", "Fuentes de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nudDias.Focus();
                            return;
                        }
                    }
                }
                

                //
                clsFuentesIngreso fuentedep = new clsFuentesIngreso();

                fuentedep.idCliFuente = objcliente.idCli;
                fuentedep.idCondiLaboral = 0;
                fuentedep.idRelacLaboral = 0;
                fuentedep.cCodEmpleado = "";
                fuentedep.nLaboraDesde = 0;
                fuentedep.nIngresos = 0.00M;

                fuentedep.idCli = objClienteMaestro.idCli;
                fuentedep.dFechaRegistro = dtpFechaRegistro.Value;
                fuentedep.idUsuReg = clsVarGlobal.User.idUsuario;
                fuentedep.dFechaModifica = dtpFechaRegistro.Value;
                fuentedep.idUsuModifica = clsVarGlobal.User.idUsuario;
                fuentedep.idTipoFuente = 2;

                fuentedep.nFamMasculino	=(int)nudFamMas.Value;
                fuentedep.nFamFemenino	=(int)nudFamFem.Value;
                fuentedep.nNoFamMascu	=(int)nudNoFamMas.Value;	
                fuentedep.nNoFamFeme		=(int)nudNoFamFem.Value;
                fuentedep.idCondicion = rbtnMicroEmp.Checked == true ? 1 : 2;
                fuentedep.idEstado = 1;
                fuentedep.cCodEmpleado = Convert.ToString(txtCodigoEmpleado.Text);
                fuentedep.idActivEco	=Convert.ToInt32(cboActividadEcoDep.SelectedValue);
                fuentedep.lIndPrincipal	=chcPrinIndep.Checked ;
                fuentedep.cReferCentroLaboral	="";
                fuentedep.cDetalleActivLaboral	="";
                fuentedep.nAnios = Convert.ToInt32(nudAnios.Value);
                fuentedep.nMeses = Convert.ToInt32(nudMeses.Value);
                fuentedep.nDias = Convert.ToInt32(nudDias.Value);
                fuentedep.cDetalleActivLaboral = "";
                //fuentedep.nTiempoExperienc=Convert.ToInt32(txtCBTiempoExper.Text.Trim());
                //fuentedep.idTipoTiempoExper=Convert.ToInt32(cboTipoMedTiempo1.SelectedValue) ;
                objClienteMaestro.lisFuentesIngreso.Add(fuentedep);

                this.lstFuentesInd.Items.Add(objcliente);
            }
            cnfuenteingreso.insactFuentesIngreso(objClienteMaestro.lisFuentesIngreso);
            listarfuentes();
            LimpiarIndependiente();
        }

        private void btnQuitar2_Click(object sender, EventArgs e)
        {
            if (lstFuentesInd.SelectedItems.Count == 0)
            {
                MessageBox.Show("No hay fuentes de ingreso seleccionados", "Fuentes de Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                

            DialogResult dr = MessageBox.Show("¿Desea eliminar la fuente de ingreso seleccionada?", "Fuentes de Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            int FuenteIngrInd = 0;
            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if ( item.idTipoFuente == 2)
                {
                    FuenteIngrInd++;
                }
            }

            if (FuenteIngrInd == 0)
            {
                MessageBox.Show("No existen datos a eliminar", "Fuentes de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            clsCliente objclisel = (clsCliente)this.lstFuentesInd.SelectedItem;
            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (objclisel.idCli == item.idCliFuente && item.idTipoFuente==2)
                {
                    item.idEstado = 0;
                }
            }
            this.lstFuentesInd.Items.Remove(objclisel);
            cnfuenteingreso.insactFuentesIngreso(objClienteMaestro.lisFuentesIngreso);
            listarfuentes();
            LimpiarIndependiente();
        }

        private void tbcFuentesIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            objcliente = null;
        }

        private void lstFuentesInd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstFuentesInd.SelectedItem == null) return;

            clsCliente objcliselec = (clsCliente)lstFuentesInd.SelectedItem;

            if (objcliselec.IdTipoPersona==1)
            {
                this.conDatCli2.cargarCliente(objcliselec.idCli);
            }
            else
            {
                this.conDatCli2.cargarClienteJur(objcliselec.idCli);
            }           

            this.conDirecPrincipal2.cargarDireccion(objcliselec.idCli);
            this.txtNumEmpleaInd.Text = objcliselec.cCantEmpl.ToString();

            foreach (var item in objClienteMaestro.lisFuentesIngreso)
            {
                if (item.idTipoFuente == 2 && objcliselec.idCli == item.idCliFuente)
                {
                    idFuenteIngreso = item.idFuenteIngreso;
                    nudFamMas.Value = item.nFamMasculino;
                    nudFamFem.Value = item.nFamFemenino;
                    nudNoFamMas.Value = item.nNoFamMascu;
                    nudNoFamFem.Value = item.nNoFamFeme;
                    this.rbtnMicroEmp.Checked = item.idCondicion == 1 ? true : false;
                    this.rbtnPeqEmp.Checked = item.idCondicion == 1 ? false : true;
                    cboActividadInternaIndep.SelectedValue=item.idActivEco;
                    nudAnios.Value = item.nAnios;
                    nudMeses.Value = item.nMeses;
                    nudDias.Value = item.nDias;
                    chcPrinIndep.Checked=item.lIndPrincipal;
                }
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmListaActivEcoInterna frmActivEco = new frmListaActivEcoInterna();
            frmActivEco.ShowDialog();
            cboActividadInternaIndep.SelectedValue = frmActivEco.idActivEcoInt;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            limpiarForms();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            limpiarForms();
        }

        private void limpiarForms()
        {
            LimpiarIndependiente();
            LimpiarDatosDependiente();
        }
    }
}
