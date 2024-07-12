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
using GEN.PrintHelper;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using SPL.CapaNegocio;
using System.Xml.Linq;

namespace CLI.Presentacion
{
    public partial class frmSocio : frmBase
    {
#region Variables
        clsCNSocio cnsocio                  = new clsCNSocio();
        clsCNAporte cnaporte                = new clsCNAporte();
        clsCNFondoMortuorio cnfondo         = new clsCNFondoMortuorio();
        clsCNBeneficiario cnbeneficiario    = new clsCNBeneficiario();

        clslisBeneficiario listabeneficiarios = new clslisBeneficiario();
        clslisBeneficiario listabeneficiariosElimados = new clslisBeneficiario();
        clsSocio objsocio           =   null;
        clsAporte objaporte         =   null;
        clsFondoMortuorio objfondo  =   null;
        private int pIdSocio        =   0;
        Transaccion operacion       =   Transaccion.Nuevo;

        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        Boolean lInscribirConFondoSeguro = true;//Indicador para considerar el tipo de FONDO DE SEGURO en la inscripción

        DataTable dtTipoFondoSeguro = new DataTable();//Contendrá los tipos de Fondo de Seguro

        DataTable dtActividadLaboralEconom = new DataTable();//Tabla que contendrá la actividad Laboral o Económica
        DataTable dtReferenciasLaboralEconomica = new DataTable();//Tabla que contendrá las referencias laborales o económicas de un Socio
        DataTable dtRefLabEconoElim = new DataTable();//tabla que contendra las referencias laborales o economicas eliminadad de un socio
        clsCNCliente cnCliente = new clsCNCliente();
        clsCNPep cnpep = new clsCNPep();
        int nEdadCli = 0;
        Boolean  lEsMayorEdad = true;//nos indica si el socio es de mayor o menor edad.
        int idCliApoderado = 0;//Se usará en caso el socio sea menor de Edad
#endregion
        
        public frmSocio()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Form1_Load(object sender, EventArgs e)
        {
            

            dtRefLabEconoElim = RetornarEstructuraRefLaborales();

            cboTipoFamiliar1.cargarTipoVinculo();
            this.dtpFecIniAporte.Value  = clsVarGlobal.dFecSystem;
            this.dtpIniFondo.Value      = clsVarGlobal.dFecSystem;
            this.btnInscripcion.Visible = false;
            conBusUbig1.cargar();
            conBusUbig1.cboPais.SelectedValue = 173;

            //------------ Deshabilitar Beneficiarios -------->
            conBusUbig1.Enabled     = false;
            btnAgregar1.Enabled     = false;
            btnQuitar1.Enabled      = false;
            btnBusCliente1.Enabled  = false;
            cboTipoFamiliar1.Enabled= false;
            txtBeneficio.Enabled    = false;
            chcBase1.Enabled        = false;

            btnBusCliente2.Enabled = false;
            //----------------------------------------------->

           // ((Control)tabPageActvLab).Enabled = false;
            pnlActvLaboral.Enabled = false;
            //------------------------------------ cargar combo Tipo Fondo Seguro --------------------------- >
            cboTipoFondoSeguro.SelectedIndexChanged -= new
            EventHandler(cboTipoFondoSeguro_SelectedIndexChanged);
            
            dtTipoFondoSeguro = new clsCNSocio().listarTipoFondoSeguro();
            this.cboTipoFondoSeguro.DataSource      = dtTipoFondoSeguro;
            this.cboTipoFondoSeguro.ValueMember     = dtTipoFondoSeguro.Columns["idTipoFondoSeguro"].ToString();
            this.cboTipoFondoSeguro.DisplayMember   = dtTipoFondoSeguro.Columns["cTipoFondoSeguro"].ToString();

            //añadir evento al cargar combo
            cboTipoFondoSeguro.SelectedIndexChanged += new
            EventHandler(cboTipoFondoSeguro_SelectedIndexChanged);
            //------------------------------------------------------------------------------------------------>
            CargarMontosPagoFondoSeguro();
            grbApoderado.Visible = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Inicio-Mantenimiento de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            objaporte   = new clsAporte();
            objfondo    = new clsFondoMortuorio();
            #region Actividad_Laboral_Economica
            DataTable dtActvLaboralDepEconom = new DataTable("dtActvLaboralDepEconom");
            dtActvLaboralDepEconom.Columns.Add("idActvLab", typeof(int));
            dtActvLaboralDepEconom.Columns.Add("cEmpresaInst", typeof(string));
            dtActvLaboralDepEconom.Columns.Add("cDomicilioEmpresa", typeof(string));
            dtActvLaboralDepEconom.Columns.Add("cCargo", typeof(string));
            dtActvLaboralDepEconom.Columns.Add("nTiempoServ", typeof(int));
            dtActvLaboralDepEconom.Columns.Add("idMonedaRemunerac", typeof(int));
            dtActvLaboralDepEconom.Columns.Add("nRemunerac", typeof(Decimal));

            DataTable dtActvLaboralIndepEconom = new DataTable("dtActvLaboralIndepEconom");
            dtActvLaboralIndepEconom.Columns.Add("idActvLab", typeof(int));
            dtActvLaboralIndepEconom.Columns.Add("cDescrActvEconPrinc", typeof(string));
            dtActvLaboralIndepEconom.Columns.Add("cOtros", typeof(string));
            dtActvLaboralIndepEconom.Columns.Add("cRUC", typeof(string));
            dtActvLaboralIndepEconom.Columns.Add("idTipoActvLab", typeof(int));
            dtActvLaboralIndepEconom.Columns.Add("lActvFormal", typeof(Boolean));
            dtActvLaboralIndepEconom.Columns.Add("nIngresoBruto", typeof(Decimal));
            dtActvLaboralIndepEconom.Columns.Add("idMonedaIngBruto", typeof(int));
#endregion
            #region Socio
            if (objsocio == null)//nuevo socio
            {
                objsocio = new clsSocio();
                objsocio.dFecModSoc = clsVarGlobal.dFecSystem;
                objsocio.dFecRegSoc = clsVarGlobal.dFecSystem;
                objsocio.idAgencia = clsVarGlobal.nIdAgencia;
                objsocio.idTipoFondoSeguro = Convert.ToInt32(cboTipoFondoSeguro.SelectedValue);
                objsocio.idAporte = 0;
                objsocio.idSocio = pIdSocio;
                objsocio.idCli = conBusCli1.idCli;
                objsocio.idEstado = 1;
                objsocio.idFondo = 0;
                objsocio.idTipoSocio = 1;
                objsocio.idUsuModSoc = clsVarGlobal.User.idUsuario;
                objsocio.idUsuRegSoc = clsVarGlobal.User.idUsuario;
                objsocio.nNumBene = Convert.ToInt32(txtNumBene.Text);
                objsocio.lTrabajaAct = (radioBtnSItrab.Checked == true ? true : false);
                objsocio.cInfOtrasActvEcon = (radioBtnSItrab.Checked == true ? txtInfOtrasActv.Text : "");
                objsocio.idActvLab = 0;
                if (radioBtnSItrab.Checked)//SI TRABAJA
                {
                    //DEPENDIENTE(1)//INDEPENDIENTE(2)
                    objsocio.idTipoVinculac = (radioBtnDepend.Checked == true ? 1 : 2);
                }
                if (radioBtnNOtrab.Checked)//NO TRABAJA
                {
                    objsocio.idTipoVinculac = 0;
                }
                objsocio.idCliApoderado = idCliApoderado;//0: en caso socio se mayor de edad 
            }
            else
            {
                objsocio.dFecModSoc = clsVarGlobal.dFecSystem;
                objsocio.idAgencia = clsVarGlobal.nIdAgencia;
                objsocio.idTipoFondoSeguro = Convert.ToInt32(cboTipoFondoSeguro.SelectedValue);
                objsocio.idCli = conBusCli1.idCli;        
                objsocio.idUsuModSoc = clsVarGlobal.User.idUsuario;
                objsocio.nNumBene = Convert.ToInt32(txtNumBene.Text);
                objsocio.lTrabajaAct = (radioBtnSItrab.Checked == true ? true : false);
                objsocio.cInfOtrasActvEcon = (radioBtnSItrab.Checked == true ? txtInfOtrasActv.Text : "");
                if (radioBtnSItrab.Checked)//SI TRABAJA
                {
                    //DEPENDIENTE(1)//INDEPENDIENTE(2)
                    objsocio.idTipoVinculac = (radioBtnDepend.Checked == true ? 1 : 2);
                }
                if (radioBtnNOtrab.Checked)//NO TRABAJA
                {
                    objsocio.idTipoVinculac = 0;
                }
                objsocio.idCliApoderado = idCliApoderado;//0: en caso socio se mayor de edad 
            }
#endregion
            #region Aporte
            objaporte.dFechaAporte  = dtpFecIniAporte.Value;
            objaporte.dFecModSoc    = clsVarGlobal.dFecSystem;
            objaporte.dFecRegSoc    = clsVarGlobal.dFecSystem;
            objaporte.idAgencia     = clsVarGlobal.nIdAgencia;
            objaporte.idAporte      = objsocio.idAporte;
            objaporte.idEstado      = 1;
            objaporte.idMoneda      = (int)cboMoneda1.SelectedValue;
            objaporte.idTipoPago    = 1;
            objaporte.idUsuModSoc   = clsVarGlobal.User.idUsuario;
            objaporte.idUsuRegSoc   = clsVarGlobal.User.idUsuario;
            objaporte.lAfectaCta    = false;
            objaporte.nMonAporte    = txtAporte.nDecValor;
            objaporte.nMonTotApor   = txtTotAporte.nDecValor;
            objaporte.nUtilidad     = txtTotUtilidad.nDecValor;
#endregion
            #region Fondo
            objfondo.dFechaPago = dtpIniFondo.Value;
            objfondo.dFecModSoc = clsVarGlobal.dFecSystem;
            objfondo.dFecRegSoc = clsVarGlobal.dFecSystem;
            objfondo.idAgencia = clsVarGlobal.nIdAgencia;
            objfondo.idEstado = 1;
            objfondo.idFondo = objsocio.idFondo;
            objfondo.idMoneda = (int)cboMoneda2.SelectedValue;
            objfondo.idTipoPago = 1;
            objfondo.idUsuModSoc = clsVarGlobal.User.idUsuario;
            objfondo.idUsuRegSoc = clsVarGlobal.User.idUsuario;
            objfondo.lAfectaCta = false;
            objfondo.nMonFondo = txtFondo.nDecValor;
            objfondo.nMonTotFon = txtTotFondo.nDecValor;      
            #endregion
            Decimal nMontoInscripcion = Convert.ToDecimal (txtMontoInscripAporte.Text);                  
           
            if (ValidacionGeneral())
            {
                return;
            }
            
            #region ActividadLavoral
             if (conBusCli1.nidTipoPersona == 1)//PERSONA NATURAL
             {
                if (objsocio.idTipoVinculac == 1)//DEPENDIENTE
                {
                    DataRow drFila = dtActvLaboralDepEconom.NewRow();
                    drFila["idActvLab"] = (operacion == Transaccion.Nuevo) ? 0 : objsocio.idActvLab;
                    drFila["cEmpresaInst"] = txtNomEmpresa.Text;
                    drFila["cDomicilioEmpresa"] = txtDomicilioEmpresa.Text;
                    drFila["cCargo"] = txtCargo.Text;
                    drFila["nTiempoServ"] = txtTiempoServicio.Text;
                    drFila["nRemunerac"] = Convert.ToDecimal (txtRemunercActvDep.Text);
                    drFila["idMonedaRemunerac"] = Convert.ToInt32(cboMonedaRemunerac.SelectedValue);
                    dtActvLaboralDepEconom.Rows.Add(drFila);
                }
                if (objsocio.idTipoVinculac == 2)//INDEPENDIENTE
                {
                    DataRow drFila = dtActvLaboralIndepEconom.NewRow();
                    drFila["idActvLab"] = (operacion == Transaccion.Nuevo)? 0 : objsocio.idActvLab;
                    drFila["cDescrActvEconPrinc"] = txtDescrActvEconomPrinc.Text;
                    drFila["cOtros"] = txtDescripOtros.Text;
                    drFila["cRUC"] = txtRUC.Text;

                    if (radioBtnComerc.Checked)
                    {
                        drFila["idTipoActvLab"] = 1;
                    }
                    else if (radioBtnServ.Checked)
                    {
                        drFila["idTipoActvLab"] = 2;
                    }
                    else//Otros
                    {
                        drFila["idTipoActvLab"] = 3;
                    }
                    drFila["lActvFormal"] = (radioBtnActFormSI.Checked == true ? true : false);
                    drFila["idMonedaIngBruto"] = Convert.ToInt32(cboMonedaIngBruto.SelectedValue);
                    drFila["nIngresoBruto"] = Convert.ToDecimal (txtIngresoBruto.Text);
                    dtActvLaboralIndepEconom.Rows.Add(drFila);
                }
                //lInscribirConFondoSeguro = true ;
            }
            else
            {
                lInscribirConFondoSeguro = false;
            } 
            #endregion
                     
            if (operacion == Transaccion.Nuevo)
            {
                DataSet dsActvLaboralDepEconom      = new DataSet("dsActvLaboralDepEconom");
                dsActvLaboralDepEconom.Tables.Add(dtActvLaboralDepEconom);
                String xmlActvLaboralDepEconom      = dsActvLaboralDepEconom.GetXml();
                xmlActvLaboralDepEconom             = clsCNFormatoXML.EncodingXML(xmlActvLaboralDepEconom);

                DataSet dsActvLaboralIndepEconom    = new DataSet("dsActvLaboralIndepEconom");
                dsActvLaboralIndepEconom.Tables.Add(dtActvLaboralIndepEconom);
                String xmlActvLaboralIndepEconom    = dsActvLaboralIndepEconom.GetXml();
                xmlActvLaboralIndepEconom           = clsCNFormatoXML.EncodingXML(xmlActvLaboralIndepEconom);

                dtReferenciasLaboralEconomica.TableName = "dtRefLabSocio";
                DataSet dsRefLabSocio = new DataSet("dsRefLabSocio");
                dsRefLabSocio.Tables.Add(dtReferenciasLaboralEconomica);
                String xmlRefLabSocio = dsRefLabSocio.GetXml();
                xmlRefLabSocio = clsCNFormatoXML.EncodingXML(xmlRefLabSocio);
               
                Boolean lUsaMontoEspecInscrip   = chkMontoEspecialInscr.Checked;
                Boolean lUsaMontoEspecAporte    = chkMontoEspecialAporte.Checked;
                Boolean lUsaMontoEspecFondoSeg  = chkMontoEspecialFondoSeg.Checked;           

                decimal MontoEspecialInscr      = string.IsNullOrEmpty(txtMontoEspecialInscr.Text) ? 0.00M: Convert.ToDecimal(txtMontoEspecialInscr.Text);
                decimal MontoEspecialAporte     = string.IsNullOrEmpty(txtMontoEspecialAporte.Text) ? 0.00M : Convert.ToDecimal(txtMontoEspecialAporte.Text);
                decimal MontoEspecialFondoSeguro= string.IsNullOrEmpty(txtMontoEspecialFondoSeguro.Text) ? 0.00M : Convert.ToDecimal(txtMontoEspecialFondoSeguro.Text);

                //--  Si es que está usando Montos Especiales --------------------->
                nMontoInscripcion       = lUsaMontoEspecInscrip ? Convert.ToDecimal (txtMontoEspecialInscr.Text) : nMontoInscripcion;
                objaporte.nMonAporte    = lUsaMontoEspecAporte ? MontoEspecialAporte : objaporte.nMonAporte;
                objfondo.nMonFondo      = lUsaMontoEspecFondoSeg ? MontoEspecialFondoSeguro : objfondo.nMonFondo;
                //---------------------------------------------------------------->

                DataTable dtResultado = cnsocio.insertarActSocioBeneficiario(objsocio, listabeneficiarios, objaporte, objfondo, nMontoInscripcion,
                                            lUsaMontoEspecInscrip   , Convert.ToInt32(cboMoneda1.SelectedValue), MontoEspecialInscr, txtDescripInscrip.Text,
                                            lUsaMontoEspecAporte    , Convert.ToInt32(cboMoneda1.SelectedValue), MontoEspecialAporte, txtDescripAporte.Text,
                                            lUsaMontoEspecFondoSeg  , Convert.ToInt32(cboMoneda2.SelectedValue), MontoEspecialFondoSeguro, txtDecripFondoSeguro.Text,
                                            lInscribirConFondoSeguro, lEsMayorEdad,
                                            xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom, xmlRefLabSocio);//objfondo para 'Fondo Previsión social' y 'Fondo mortuorio'

                if ((int)dtResultado.Rows[0]["nResp"]== 0)//Ocurrió algún error
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Afiliación Socio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Afiliación Socio", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    btnGrabar1.Enabled              = false;
                    btnInscripcion.Enabled          = true;
                    btnCancelar1.Enabled            = true;
            
                    cargarDatos(conBusCli1.idCli);
                    btnAgregar1.Enabled             = false;
                    btnQuitar1.Enabled              = false;
                    btnBusCliente1.Enabled          = false;
                    conBusCli1.btnBusCliente.Enabled= true;
                    cboTipoFamiliar1.Enabled        = false;
                    txtBeneficio.Enabled            = false;
                    if (dtgRefLaboralesSocio.DataSource !=null)
                    {
                        FormatoGridRefLaboralEconomica();  
                    }                              
                }                
            
            }

            if (operacion == Transaccion.Edita)
            {
                //Referencia Laboral del socio
                DataTable dtRefLabEconoMerge = RetornarEstructuraRefLaborales();
                dtRefLabEconoMerge.Merge(dtReferenciasLaboralEconomica);
                dtRefLabEconoMerge.Merge(dtRefLabEconoElim);

                dtRefLabEconoMerge.TableName = "dtRefLabSocio";
                DataSet dsRefLabSocio = new DataSet("dsRefLabSocio");
                dsRefLabSocio.Tables.Add(dtRefLabEconoMerge);
                String xmlRefLabSocio = dsRefLabSocio.GetXml();
                xmlRefLabSocio = clsCNFormatoXML.EncodingXML(xmlRefLabSocio);
                dtRefLabEconoElim.Clear();

                DataSet dsActvLaboralDepEconom = new DataSet("dsActvLaboralDepEconom");
                dsActvLaboralDepEconom.Tables.Add(dtActvLaboralDepEconom);
                String xmlActvLaboralDepEconom = dsActvLaboralDepEconom.GetXml();
                xmlActvLaboralDepEconom = clsCNFormatoXML.EncodingXML(xmlActvLaboralDepEconom);

                DataSet dsActvLaboralIndepEconom = new DataSet("dsActvLaboralIndepEconom");
                dsActvLaboralIndepEconom.Tables.Add(dtActvLaboralIndepEconom);
                String xmlActvLaboralIndepEconom = dsActvLaboralIndepEconom.GetXml();
                xmlActvLaboralIndepEconom = clsCNFormatoXML.EncodingXML(xmlActvLaboralIndepEconom);

                DataTable dtResultado = cnsocio.ActualizarBeneficiario(objsocio.obtenerXml(), xmlRefLabSocio, ObtenerXmlBeneficiarios(), xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom);
                if ((int)dtResultado.Rows[0]["nResp"] == 0)//Ocurrió algún error
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Afiliación Socio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Afiliación Socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled = false;
                    btnInscripcion.Enabled = true;
                    btnCancelar1.Enabled = true;
                    cargarDatos(conBusCli1.idCli);
                    btnAgregar1.Enabled = false;
                    btnQuitar1.Enabled = false;
                    btnBusCliente1.Enabled = false;
                    conBusCli1.btnBusCliente.Enabled = true;
                    cboTipoFamiliar1.Enabled = false;
                    txtBeneficio.Enabled = false;
                    if (dtgRefLaboralesSocio.DataSource != null)
                    {
                        FormatoGridRefLaboralEconomica();
                    }                              
                }
            }
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Fin-Mantenimiento de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }
        private string ObtenerXmlBeneficiarios()
        {
           // listabeneficiarios.AddRange(listabeneficiariosElimados);
            var listBenFinal = listabeneficiarios.Union(listabeneficiariosElimados).ToList();

            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                      new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                      new XElement("dsbeneficiario",
                                      from item in listBenFinal 
                                      select new XElement("dtbeneficiario",
                                                          new XAttribute("idBeneficiario", item.idBeneficiario),
                                                          new XAttribute("cBeneficiario", item.cBeneficiario),
                                                          new XAttribute("cNombres", item.cNombres),
                                                          new XAttribute("cApePatBen", item.cApePatBen),
                                                          new XAttribute("cApeMatBen", item.cApeMatBen),
                                                          new XAttribute("cApeCasBen", item.cApeCasBen),
                                                          new XAttribute("cDocIdeBen", item.cDocIdeBen),
                                                          new XAttribute("cDireccion", item.cDireccion),
                                                          new XAttribute("idUbigeo", item.idUbigeo),
                                                          new XAttribute("idTipoRela", item.idTipoRela),
                                                          new XAttribute("nBeneficio", item.nBeneficio),
                                                          new XAttribute("dFecRegBen", item.dFecRegBen),
                                                          new XAttribute("idUsuRegBen", item.idUsuRegBen),
                                                          new XAttribute("dFecBajBen", item.dFecBajBen.ToString()),                                                       
                                                          new XAttribute("idMotivBaj", item.idMotivBaj),
                                                          new XAttribute("idEstado", item.idEstado),
                                                          new XAttribute("idCli", item.idCli)))).ToString();
            listabeneficiariosElimados.Clear();
            return cxml;
        }
        private Boolean EsValidoCamposActividadLaboralEconomica()
        {
            if (conBusCli1.nidTipoPersona == 1)//PERSONA NATURAL
            {
                if (radioBtnSItrab.Checked == false && radioBtnNOtrab.Checked == false)
                {
                    MessageBox.Show("Debe seleccionar si el trabajador trabaja actualmente o no.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (radioBtnSItrab.Checked)//SI TRABAJA
                {
                    if (radioBtnDepend.Checked == false && radioBtnIndepend.Checked == false)//ES DEPENDIENTE O INDEPENDIENTE
                    {
                        MessageBox.Show("Debe seleccionar si el trabajador es INDEPENDIENTE ó DEPENDIENTE.", "Validación Monto Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (radioBtnDepend.Checked)//DEPENDIENTE
                    {
                        if (string.IsNullOrEmpty(txtNomEmpresa.Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre de la Empresa en que labora el socio.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtDomicilioEmpresa.Text))
                        {
                            MessageBox.Show("Debe ingresar el domicilio legal de la empresa.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCargo.Text))
                        {
                            MessageBox.Show("Debe el cargo que ocupa el socio en la empresa.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtTiempoServicio.Text))
                        {
                            MessageBox.Show("Debe ingresar el tiempo de servicio del socio en la empresa.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (Convert.ToInt32(txtTiempoServicio.Text) == 0)
                        {
                            MessageBox.Show("El tiempo de servicio debe ser diferente a cero.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtRemunercActvDep.Text))
                        {
                            MessageBox.Show("Debe ingresar el monto de Remuneración", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (Convert.ToDecimal (txtRemunercActvDep.Text) == 0.00m)
                        {
                            MessageBox.Show("El monto de Remuneración debe ser mayor que 0.00", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtRemunercActvDep.Focus();
                            return false;
                        }
                    }
                    if (radioBtnIndepend.Checked)//INDEPENDIENTE
                    {
                        if (radioBtnComerc.Checked == false && radioBtnServ.Checked == false && radioBtnOtro.Checked == false)
                        {
                            MessageBox.Show("Debe seleccionar el tipo de actividad en ACTIVIDAD INDEPENDIENTE.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (radioBtnOtro.Checked == true)
                        {
                            if (string.IsNullOrEmpty(txtDescripOtros.Text) == true)
                            {
                                MessageBox.Show("Debe ingresar la descripción/especificación en otros tipos de Actividad independiente.", "Validación Actividad Laborall", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }

                        if (radioBtnActFormSI.Checked == false && radioBtnActFormNO.Checked == false)
                        {
                            MessageBox.Show("Debe seleccionar si la actividad Laboral del cliente es Formal o no.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtIngresoBruto.Text))
                        {
                            MessageBox.Show("Debe ingresar el INGRESO BRUTO", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtRUC.Text))
                        {
                            MessageBox.Show("Debe ingresar el RUC", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtDescrActvEconomPrinc.Text))
                        {
                            MessageBox.Show("Debe ingresar la descripción de la actividad económica principal o actual.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }

                    //VALIDAR QUE LAS REFERENCIAS LABORALES NO SEAN VACIAS
                    if (dtgRefLaboralesSocio.Rows.Count > 0)
                    {
                        for (int f = 0; f < dtReferenciasLaboralEconomica.Rows.Count; f++)
                        {
                            if (string.IsNullOrEmpty(dtReferenciasLaboralEconomica.Rows[f]["cNombre"].ToString()))
                            {
                                MessageBox.Show("Existen campos vacios en el nombre de la referencia.", "Validación Actividad Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                    }
                }
            }
            return true; 
        }
        private Boolean ValidacionGeneral()
        {
            if (EsValidoCamposActividadLaboralEconomica() == false)
            {
                tbcBase1.SelectedTab = tabPageActvLab;
                return true ;
            }
            if (EsValidoMontosEspeciales() == false)
            {
                return true ;
            }
            if (conBusCli1.nidTipoPersona == 1)//PERSONA NATURAL
            {
                if (nEdadCli < 18 && objsocio.idCliApoderado == 0)
                {
                    MessageBox.Show("Debe ingresar al APODERADO", "Validación Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true ;
                }
                if (listabeneficiarios.Count() <= 0 && nEdadCli>=18)//BENEFICIARIOS
                {
                    MessageBox.Show("Debe ingresar a los BENEFICIARIOS", "Validación Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbcBase1.SelectedTab = tabPageBeneficiarios;
                    return true;
                }
            }
            //Campos Beneficiarios
            foreach (var item in listabeneficiarios)
            {
                if (item.cDocIdeBen.Length <= 0)
                {
                    MessageBox.Show("Debe ACTUALIZAR el Nro de DNI de: " + item.cBeneficiario, "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            foreach (var item in listabeneficiarios)
            {
                if (item.cDireccion.Length <= 0)
                {
                    MessageBox.Show("Debe ACTUALIZAR la DIRECCIÓN de: " + item.cBeneficiario, "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
           
            return false ;
        }
        private Boolean EsValidoMontosEspeciales()
        {
            if (chkMontoEspecialInscr.Checked)//MONTO INSCRIPCIÓN
            {
                if (string.IsNullOrEmpty(txtMontoEspecialInscr.Text))
                {
                    MessageBox.Show("Debe ingresar el monto especial para la INSCRIPCIÓN", "Validación Monto Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (string.IsNullOrEmpty(txtDescripInscrip.Text))
                {
                    MessageBox.Show("Debe ingresar el motivo para monto especial de INSCRIPCIÓN", "Validación motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (chkMontoEspecialAporte.Checked)//MONTO APORTE
            {
                if (string.IsNullOrEmpty(txtMontoEspecialAporte.Text))
                {
                    MessageBox.Show("Debe ingresar el monto especial para el APORTE", "Validación Monto Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (string.IsNullOrEmpty(txtDescripAporte.Text))
                {
                    MessageBox.Show("Debe ingresar el motivo para monto especial de APORTE", "Validación motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            //FONDO DE SEGURO
            if (conBusCli1.nidTipoPersona == 1)//NATURAL
            {
                if (chkMontoEspecialFondoSeg.Checked)//MONTO FONDO DE SEGURO
                {
                    if (string.IsNullOrEmpty(txtMontoEspecialFondoSeguro.Text))
                    {
                        MessageBox.Show("Debe ingresar el monto especial para FONDO DE SEGURO", "Validación Monto Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtDecripFondoSeguro.Text))
                    {
                        MessageBox.Show("Debe ingresar el motivo para monto especial de FONDO DE SEGURO SEGURO", "Validación motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }                    
            }
            return true;                        
        }
        
        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;

            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("Debe Seleccionar a un Cliente","Validación Socio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            pnlActvLaboral.Enabled = true;
            //------------ Habilitar Beneficiarios -------->
            conBusUbig1.Enabled         = false;
            btnAgregar1.Enabled         = true;
            btnQuitar1.Enabled          = true;
            btnBusCliente1.Enabled      = true;
            cboTipoFamiliar1.Enabled    = true;
            txtBeneficio.Enabled        = true;
            chcBase1.Enabled            = false;
            
            btnBusCliente2.Enabled = true;
            //----------------------------------------------->

            ((Control)tabPageActvLab).Enabled   = true;
            radioBtnDepend.Enabled              = false;
            radioBtnIndepend.Enabled            = false;
            grbDependiente.Enabled              = false;
            grbIndependiente.Enabled            = false;
            grbRef.Enabled                      = false;
            txtInfOtrasActv.Enabled             = false;


            btnGrabar1.Enabled      = true;
            btnCancelar1.Enabled    = true;
            btnInscripcion.Enabled  = false;
            conBusCli1.btnBusCliente.Enabled = false;           

            txtTotAporte.Text   = "0.00";
            txtAporte.Text      = Convert.ToString(clsVarApl.dicVarGen["nMonAporte"]);
            txtEstado.Text      = "Nuevo";

            //------------------- Habilitar uso montos especiales ---------------------------->
            if (conBusCli1.nidTipoPersona==1)//NATURAL
            {
                grbMontosEspcAporte.Enabled     = true;//Aportes Inscripción
                grbMontoEspecFondoSeg.Enabled   = true;//Fondo Seguro ()
                txtMontoInscripAporte.Text      = Convert.ToString(clsVarApl.dicVarGen["nMontoInscripPersoNatural"]);
                pnlFondoSeguro.Visible      = true;
                pnlBeneficiarios.Visible    = true;

                //----- Cargar Montos Fondo Seguro ---->
                CargarMontosPagoFondoSeguro();
                txtTotFondo.Text    = "0.00";
                txtEstadoFondo.Text = "Nuevo";
            }
            else//JURÍDICA
            {
                grbMontosEspcAporte.Enabled     = true;//Aportes Inscripción
                grbMontoEspecFondoSeg.Enabled   = false;//Fondo Seguro ()
                txtMontoInscripAporte.Text      = Convert.ToString(clsVarApl.dicVarGen["nMontoInscripPersoJuridic"]);
                pnlFondoSeguro.Visible      = false;
                pnlBeneficiarios.Visible    = false;
            }           
            //------------------------------------------------------------------------------->

            dtReferenciasLaboralEconomica   = RetornarEstructuraRefLaborales();
            dtgRefLaboralesSocio.DataSource = dtReferenciasLaboralEconomica;
            FormatoGridRefLaboralEconomica();
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila  = dtTablaParametros.NewRow();
            drfila[0]       = "idCli";
            drfila[1]       = conBusCli1.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila      = dtTablaParametros.NewRow();
            drfila[0]   = "nidTipoPersona";
            drfila[1]   = conBusCli1.nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);
            
            return dtTablaParametros;
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0) return;
            

            if (validarBaseNegativaSocio(conBusCli1.idCli) == 1)
            {
                MessageBox.Show("Persona seleccionada se encuentra en la base negativa de socios", "Validación Socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }

            //Validar REGLAS DINÁMICAS
            int nNivAuto = 0;//parámetro que se usa sólo en los 'Niveles de Autorización'
            String cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, conBusCli1.idCli,
                                                   1    , 0 , 0                             ,
                                                   0.00m , 0 , clsVarGlobal.dFecSystem       ,
                                                   2    , 2 , clsVarGlobal.User.idUsuario   , ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return;
            }
            if (conBusCli1.lIndDatosBasicos == true)
            {
                MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //------------------ limipar control de búsqueda ------>
                conBusCli1.txtCodAge.Clear();
                conBusCli1.txtCodCli.Clear();
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodInst.Clear();
                conBusCli1.txtDireccion.Clear();
                conBusCli1.txtNombre.Clear();
                conBusCli1.txtNroDoc.Clear();
                conBusCli1.idCli = 0;
                return;
            }
            cargarDatos(conBusCli1.idCli);
            if (conBusCli1.nidTipoPersona == 1)//Natural
            {
                pnlFondoSeguro.Visible      = true;
                pnlBeneficiarios.Visible    = true;

                lInscribirConFondoSeguro    = true;
                PermitirInscribirReinscribirConFondoSeguro();

                //======================== Habilitar Apoderado ==========================================>
                nEdadCli = cnCliente.CalcularEdad(conBusCli1.idCli, clsVarGlobal.dFecSystem);
                grbApoderado.Visible = (nEdadCli >= 18)?false:true;

                lEsMayorEdad = (nEdadCli >= 18) ? true : false;
                //===================================================================================>
                tbcBase1.SelectedTab = tabPageActvLab;
                
                
            }
            else //Jurídico
            {
                pnlFondoSeguro.Visible      = false;
                pnlBeneficiarios.Visible    = false;
                grbApoderado.Visible = false;
                tbcBase1.SelectedTab =  tabPageAportes;
                lEsMayorEdad = true;
            }
            
            txtNumBene.Text = dtgBeneficiario.Rows.Count.ToString();
            btnCancelar1.Enabled = true;

            //cargar Referecias laborales 
        }

        /// <summary>
        /// Valida con que tipo de Fondo de Seguro se va inscribir el SOCIO, o no se le va considerar el Fondo de seguro
        /// </summary>
        private void PermitirInscribirReinscribirConFondoSeguro()
        {       
            DateTime dFechaNacCli   = cnsocio.ObtenerFechaNacCli(conBusCli1.idCli);

            DateTime dfechaCliCumple_64Años_364dias = dFechaNacCli.AddYears(64).AddDays(364);
            DateTime dfechaCliCumple_74Años_364dias = dFechaNacCli.AddYears(74).AddDays(364);

            DateTime dFechaActual = clsVarGlobal.dFecSystem;

            if (((dFechaActual - dfechaCliCumple_64Años_364dias).Days >= 0) &&
            ((dFechaActual - dfechaCliCumple_74Años_364dias).Days < 0))
            {//NO PERMITIR INCLUIR FONDO DE SEGURO EN LA INSCRPCIÓN/REINSCRIPCIÓN DEL SOCIO
                lInscribirConFondoSeguro = false;
            }
            else
            {
                lInscribirConFondoSeguro = true;
                if ((dFechaActual - dfechaCliCumple_64Años_364dias).Days < 0)
                {//permitir inscripción con fondo de seguro: FONDO DE PREVENCIÓN SOCIAL
                    cboTipoFondoSeguro.SelectedValue = 1;
                }
                if ((dFechaActual - dfechaCliCumple_74Años_364dias).Days >= 0)
                {//permitir inscripción con fondo de seguro: FONDO MORTUORIO
                    cboTipoFondoSeguro.SelectedValue = 2;
                }
            }
        }
        
        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli))
            {
                return;
            }
            if (frmbuscli.pnTipoPersona!=1)
            {
                MessageBox.Show("Por favor ingresar una persona Natural", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ctipoPer=frmbuscli.pnTipoPersona==1?"N":"J";

            clsCliente datcliente = new clsCNRetDatosCliente().retornarCliente(Convert.ToInt32(frmbuscli.pcCodCli), ctipoPer);

            if (datcliente.cDocumentoID.Trim()==conBusCli1.txtNroDoc.Text.Trim())
            {
                MessageBox.Show("El socio titular no puede ser beneficiario", "Validación Beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);      
                return;
            }

            txtNombres.Text = (datcliente.cNombre + " " + datcliente.cNombreSeg + " " + datcliente.cNombreOtros).Trim();
            txtApePat.Text = datcliente.cApellidoPaterno.Trim();
            txtApeMat.Text = datcliente.cApellidoMaterno.Trim();
            txtApeCas.Text = datcliente.cApellidoCasado.Trim();
            txtDireccion.Clear(); 
            DataTable dtDatDirec=new clsCNDirecCli().ListaDirCli(datcliente.idCli);
            if (dtDatDirec.DefaultView.Count>0)
            {
                txtDireccion.Text = dtDatDirec.Rows[0]["cDireccion"].ToString();
                conBusUbig1.cargarUbigeo((int)dtDatDirec.Rows[0]["idUbigeo"]);
            }
         
            txtDocIde.Text      = datcliente.cDocumentoID.Trim();
           
            conBusUbig1.Enabled = false;
            txtBeneficio.Focus();
            txtBeneficio.SelectAll();

            txtIdCliBenef.Text = frmbuscli.pcCodCli;

            txtNumBene.Text = dtgBeneficiario.Rows.Count.ToString();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            #region Validaciones

            if (string.IsNullOrEmpty(txtDocIde.Text))
            {
                MessageBox.Show("Por favor primero busque un beneficiario", "Validación documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocIde.Focus();
                txtDocIde.SelectAll();
                return;
            }      

            var validaexiste = listabeneficiarios.Where(x => x.cDocIdeBen == txtDocIde.Text.Trim()).Count();
            if (validaexiste>0)
            {
                MessageBox.Show("Ya se agregó a la persona seleccionada", "Validación Beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);      
                return;
            }
            if (txtDocIde.Text.Trim() == conBusCli1.txtNroDoc.Text.Trim())
            {
                MessageBox.Show("El socio titular no puede ser beneficiario", "Validación Beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            if (string.IsNullOrEmpty(this.txtNombres.Text))
            {
                MessageBox.Show("Por favor ingrese los nombres del beneficiario", "Validación Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNombres.Focus();
                this.txtNombres.SelectAll();
                return;
            }            

            if (string.IsNullOrEmpty(this.txtApePat.Text))
            {
                MessageBox.Show("Por favor ingrese el apellido paterno", "Validación Apellido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtApePat.Focus();
                this.txtApePat.SelectAll();
                return;
            }           

            if (string.IsNullOrEmpty(this.txtDireccion.Text))
            {
                MessageBox.Show("Por favor ingrese la direción del beneficiario", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDireccion.Focus();
                this.txtDireccion.SelectAll();
                return;
            }

            if (this.txtBeneficio.nvalor<=0.0)
            {
                MessageBox.Show("Por favor ingresar un porcentaje mayor a cero(0) ", "Validación Porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBeneficio.Focus();
                this.txtBeneficio.SelectAll();
                return;
            }
            if (this.txtBeneficio.nvalor >100.0)
            {
                MessageBox.Show("Por favor ingresar un porcentaje menor igual a 100.00 ", "Validación Porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBeneficio.Focus();
                this.txtBeneficio.SelectAll();
                return;
            }

            if ((listabeneficiarios.Sum(x => x.nBeneficio) + this.txtBeneficio.nDecValor) >100.0M)
            {
                MessageBox.Show("Por favor ingresar un porcentaje que no supere en total el 100% ", "Validación Porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBeneficio.Focus();
                this.txtBeneficio.SelectAll();
                return;
            }
            if (conBusUbig1.cboDistrito.SelectedIndex<=0)
            {
                MessageBox.Show("Por favor seleccione el ubigeo de la dirección ", "Validación Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusUbig1.cboPais.Focus();
                return;
            }

            var dtConyugue = cnsocio.validaConyugueBen(txtDocIde.Text);

            if (dtConyugue.Rows.Count>0)
            {
                MessageBox.Show("Otro Socio ya declaro como conyugue al cliente seleccionado", "Validación Conyugue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBusCliente1.Focus();
                return;
            }

            #endregion
            agregarBene();
        }      

        private void tbcBase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcBase1.SelectedIndex == 2)
            {
                FormatoGrid();
            }
            else if (tbcBase1.SelectedIndex == 1)
            {
                pintarGridFondo();
                if (string.IsNullOrEmpty(conBusCli1.txtCodCli.Text) == false && conBusCli1.nidTipoPersona == 1 && objsocio == null)//PERSONA NATURAL-- y que se esté inscribiendo/reinscribiendo
                {
                    if (lInscribirConFondoSeguro == false)
                    {
                        MessageBox.Show("La edad del cliente sobrepasa los 64 años con 363 días." + Environment.NewLine + "Además es menor que 74 años con 363 días. Por lo que no se permite ningún tipo de fondo de seguro.", "Validar considerar Fondo de seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pnlFondoSeguro.Enabled  = false;
                        txtFondo.Text           = "0.00";
                        txtTotFondo.Text        = "0.00";
                        txtEstadoFondo.Text     = "";
                        dtpIniFondo.Text        = "";
                        //------- Asignar ningun tipo de seguro ---------------->
                        DataTable dtTablaNingunTipoSeguro       = TablaNingunTipoSeguro();
                        cboTipoFondoSeguro.DataSource           = dtTablaNingunTipoSeguro;
                        this.cboTipoFondoSeguro.ValueMember     = dtTablaNingunTipoSeguro.Columns["idTipoFondoSeguro"].ToString();
                        this.cboTipoFondoSeguro.DisplayMember   = dtTablaNingunTipoSeguro.Columns["cTipoFondoSeguro"].ToString();
                        //------------------------------------------------------>
                    }
                }
            }
            else if (tbcBase1.SelectedIndex == 0)
            {
                pintarGridAporte();
            }
        }

        private void tbcBase1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (conBusCli1.nidTipoPersona == 1)//PERSONA NATURAL
            {
                if ( nEdadCli >= 18 )
                {
                    grbApoderado.Visible = false;                  
                }
                else
                {
                    grbApoderado.Visible = true; 
                }
            }
            else//JURIDICA
            {
                if (tbcBase1.SelectedTab!=null)
                {
                    tbcBase1.SelectedTab = tabPageAportes;                 
                }                
            }
        }


        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgBeneficiario.CurrentRow==null)
            {
                MessageBox.Show("Debe seleccionar un beneficiario para quitar", "Validación Beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                var itemselec = (clsBeneficiario)dtgBeneficiario.CurrentRow.DataBoundItem;
                if (itemselec.idBeneficiario != null && listabeneficiariosElimados.Where(x => x.idBeneficiario == itemselec.idBeneficiario).Count() == 0)
                {
                    itemselec.idEstado = 0;
                    itemselec.dFecBajBen = clsVarGlobal.dFecSystem;
                    listabeneficiariosElimados.Add(itemselec);
                }
                listabeneficiarios.Remove(itemselec);
                dtgBeneficiario.DataSource = null;
                dtgBeneficiario.DataSource = listabeneficiarios;
                dtgBeneficiario.Refresh();

                
                

            }
            txtNumBene.Text = dtgBeneficiario.RowCount.ToString();
        }
        #endregion

        #region Metodos
        private void cargarDatos(int idCli)
        {
            objsocio = cnsocio.retornardatossocio(idCli);

            if (objsocio == null)
            {
                #region limpia campos para nuevo socio

                operacion                   = Transaccion.Nuevo;
                btnInscripcion.Visible      = true;
                btnEditar1.Enabled          = false;
                btnInscripcion.Enabled      = true;
                dtgBeneficiario.DataSource  = null;
                dtgDetalleFondo.DataSource  = null;
                dtgAportes.DataSource       = null;
                pIdSocio                    = 0;
                txtNombres.Clear();
                txtApePat.Clear();
                txtApeMat.Clear();
                txtApeCas.Clear();
                txtDireccion.Clear();
                txtDocIde.Clear();
                
                txtAporte.Clear();
                txtTotAporte.Clear();
                txtTotUtilidad.Clear();
                txtEstado.Clear();
                
                txtFondo.Clear();
                txtTotFondo.Clear();
                txtEstado.Clear();

                cboTipoFondoSeguro.SelectedIndex = 0;

                //========================= Limpiar Campos de Actividad Laboral o Económica =================>
                radioBtnSItrab.Checked = false;
                radioBtnNOtrab.Checked = false;
                radioBtnDepend.Checked = false;
                radioBtnIndepend.Checked = false;
            
                txtNomEmpresa.Clear();
                txtDomicilioEmpresa.Clear();
                txtCargo.Clear();
                txtTiempoServicio.Clear();
                txtRemunercActvDep.Clear();
                cboMonedaRemunerac.SelectedIndex    = 0;
                cboMonedaIngBruto.SelectedIndex     = 0;

                radioBtnComerc.Checked = false;
                radioBtnServ.Checked = false;
                radioBtnOtro.Checked = false;
                txtDescripOtros.Clear();
                radioBtnActFormSI.Checked = false;
                radioBtnActFormNO.Checked = false;
                txtIngresoBruto.Clear();
                txtRUC.Clear();
                txtDescrActvEconomPrinc.Clear();

                txtNomRef.Clear();
                txtRefComentario.Clear();
                dtgRefLaboralesSocio.DataSource = null;

                txtInfOtrasActv.Clear();

                pnlActvLaboral.Enabled      = false;
                pnlAportes.Enabled          = true;
                pnlFondoSeguro.Enabled      = true;
                pnlBeneficiarios.Enabled    = true;
                //==================================================================================>
            #endregion
            }
            else
            {
                pnlActvLaboral.Enabled  = false;
                pnlAportes.Enabled      = false;
                pnlFondoSeguro.Enabled  = false;
                pnlBeneficiarios.Enabled= false;

                btnInscripcion.Visible = false;

                var datAporte   = cnaporte.retornardatosaporte(objsocio.idAporte);
                var datFondo    = cnfondo.retornardatosfondo(objsocio.idFondo);

                pIdSocio        = objsocio.idSocio;
                txtMontoInscripAporte.Text = string.Format("{0:0.00}", objsocio.nInscripcion);
                if (objsocio.idCliApoderado > 0)
                {
                    buscarApoderadoSocio(objsocio.idCliApoderado, "N");
                }

                //---------------------------- APORTES -------------------------------------->
                txtTotAporte.Text       = string.Format("{0:0.00}", datAporte.nMonTotApor);
                dtpFecIniAporte.Value   = datAporte.dFechaAporte;
                txtAporte.Text          = string.Format("{0:0.00}", datAporte.nMonAporte);
                txtTotUtilidad.Text     = string.Format("{0:0.00}", datAporte.nUtilidad);
                cboMoneda1.SelectedValue= datAporte.idMoneda;
                txtEstado.Text          = datAporte.idEstado == 1 ? "Activo" : "Garantia";

                var lisdetaporte = datAporte.objDetalleAportes;
                dtgAportes.DataSource = null;
                dtgAportes.DataSource = lisdetaporte;
               
                
                //----------------------------------------------------------------------------->

                //-------------------------------- FONDO DE SEGURO ---------------------------->
                dtgDetalleFondo.DataSource = null;
                if (datFondo == null)//Cuando se ha inscrito/reinscrito a un socio a quien no le pertenece ningún FONDO DE SEGURO
                {
                    dtpIniFondo.Text        = "";

                    //------- Asignar ningun tipo de seguro ---------------->
                    DataTable dtTablaNingunTipoSeguro       = TablaNingunTipoSeguro();
                    cboTipoFondoSeguro.DataSource           = dtTablaNingunTipoSeguro;
                    this.cboTipoFondoSeguro.ValueMember     = dtTablaNingunTipoSeguro.Columns["idTipoFondoSeguro"].ToString();
                    this.cboTipoFondoSeguro.DisplayMember   = dtTablaNingunTipoSeguro.Columns["cTipoFondoSeguro"].ToString();
                    //------------------------------------------------------>

                    txtFondo.Text           = "0.00";
                    txtTotFondo.Text        = "0.00";
                    cboMoneda2.SelectedValue= 1;
                    txtEstadoFondo.Text     = "";                    
                }
                else
	            {
                    dtpIniFondo.Value       = datFondo.dFechaPago;
                    cboTipoFondoSeguro.SelectedValue = Convert.ToInt32(objsocio.idTipoFondoSeguro);
                    txtFondo.Text           = string.Format("{0:0.00}", datFondo.nMonFondo);
                    txtTotFondo.Text        = string.Format("{0:0.00}", datFondo.nMonTotFon);
                    cboMoneda2.SelectedValue= datFondo.idMoneda;
                    txtEstadoFondo.Text     = datFondo.idEstado == 1 ? "Activo" : "Garantia";

                    var lisdetfondo             = datFondo.objDetalleFondo;
                    dtgDetalleFondo.DataSource  = lisdetfondo;
	            }                
                //----------------------------------------------------------------------------->             

                dtgBeneficiario.DataSource = null;
                listabeneficiarios = cnbeneficiario.listarbeneficiarios(objsocio.idSocio);
                dtgBeneficiario.DataSource = listabeneficiarios;
                
                pintarGridAporte();
                //Indicador si el Socio trabaja actualmente
                //objsocio.lTrabajaAct==true // Trabaja
                radioBtnSItrab.Checked = (objsocio.lTrabajaAct==true?true:false);
                radioBtnNOtrab.Checked = (objsocio.lTrabajaAct==true?false:true); 

                if (objsocio.lTrabajaAct==true)//TRABAJA
                {
                    //Tipo de Vinculación DEPENDIENTE -- INDEPENDIENTE
                    //objsocio.idTipoVinculac == 1 // DEPENDIENTE
                    radioBtnDepend.Checked = (objsocio.idTipoVinculac == 1?true:false);
                    radioBtnIndepend.Checked = (objsocio.idTipoVinculac == 1 ? false  : true );
                }
                else//NO TRABAJA
                {
                    radioBtnDepend.Checked      = false;
                    radioBtnIndepend.Checked    = false;
                }

                txtInfOtrasActv.Text            = objsocio.cInfOtrasActvEcon;           

                dtActividadLaboralEconom        = cnsocio.RetornarDetActividadLaboralEconom(pIdSocio);
                dtReferenciasLaboralEconomica   = cnsocio.ReferenciasLaboralEconomica(pIdSocio);

                dtgRefLaboralesSocio.DataSource = dtReferenciasLaboralEconomica;
                if (dtActividadLaboralEconom.Rows.Count == 0)
                {
                    dtReferenciasLaboralEconomica   = RetornarEstructuraRefLaborales();
                    dtgRefLaboralesSocio.DataSource = dtReferenciasLaboralEconomica;
                    FormatoGridRefLaboralEconomica();
                }
                else //Cargar datos de Actividad Laboral o Económica 
                {
                    if (objsocio.idTipoVinculac == 1)//DEPENDIENTE
                    {
                        txtNomEmpresa.Text                  = dtActividadLaboralEconom.Rows[0]["cEmpresaInst"].ToString();
                        txtDomicilioEmpresa.Text            = dtActividadLaboralEconom.Rows[0]["cDomicilioEmpresa"].ToString();
                        txtCargo.Text                       = dtActividadLaboralEconom.Rows[0]["cCargo"].ToString();
                        txtTiempoServicio.Text              = dtActividadLaboralEconom.Rows[0]["nTiempoServ"].ToString();
                        txtRemunercActvDep.Text             = dtActividadLaboralEconom.Rows[0]["nRemunerac"].ToString();
                        cboMonedaRemunerac.SelectedValue    = Convert.ToInt32(dtActividadLaboralEconom.Rows[0]["idMonedaRemunerac"]);
                    }
                    if (objsocio.idTipoVinculac == 2)//INDEPENDIENTE
                    {
                        int idTipoActividad = Convert.ToInt32(dtActividadLaboralEconom.Rows[0]["idTipoActvLab"]);
                        
                        if (idTipoActividad==1)//COMERCIALIZACIÓN
                        {
                            radioBtnComerc.Checked  = true;
                            radioBtnServ.Checked    = false;
                            radioBtnOtro.Checked    = false;
                        }
                        if (idTipoActividad == 2)//SERVICIOS
                        {
                            radioBtnComerc.Checked  = false;
                            radioBtnServ.Checked    = true;
                            radioBtnOtro.Checked    = false;
                        }
                        if (idTipoActividad == 3)//OTROS
                        {
                            radioBtnComerc.Checked  = false;
                            radioBtnServ.Checked    = false;
                            radioBtnOtro.Checked    = true;

                            txtDescripOtros.Text = dtActividadLaboralEconom.Rows[0]["cOtros"].ToString();
                        }
                        //VERIFICA QUE ACTIVIDAD SEA FORMAL O NO
                        Boolean lEsFormal = Convert.ToBoolean(dtActividadLaboralEconom.Rows[0]["lActvFormal"]);
                        radioBtnActFormSI.Checked = (lEsFormal == true?true:false);
                        radioBtnActFormNO.Checked = (lEsFormal == true?false:true);
                       
                        txtIngresoBruto.Text            = dtActividadLaboralEconom.Rows[0]["nIngresoBruto"].ToString();
                        cboMonedaIngBruto.SelectedValue = Convert.ToInt32(dtActividadLaboralEconom.Rows[0]["idMonedaIngBruto"]);
                        txtRUC.Text                     = dtActividadLaboralEconom.Rows[0]["cRUC"].ToString();
                        txtDescrActvEconomPrinc.Text    = dtActividadLaboralEconom.Rows[0]["cDescrActvEconPrinc"].ToString();
                    }
                    FormatoGridRefLaboralEconomica();
                }

                //============== Recuperar Solicitudes Pendientes para Uso Montos especiales (Inscripc, Aporte, Fondo Seg) ==============>
                DataTable dtSolAprobac = cnsocio.RecuperarSolAprobacMontosEspeciales(objsocio.idSocio);
                if (dtSolAprobac.Rows.Count > 0)
                {
                    string cmensaje = "";
                    for (int i = 0; i < dtSolAprobac.Rows.Count; i++)
                    {
                        string cTipoOperac = dtSolAprobac.Rows[i]["cTipoOperacion"].ToString();

                        if (cTipoOperac.Equals("VALIDA AUTORIZ. MONTO ESPECIAL INSCRIPCIÓN SOCIO"))//INSCRIPCIÓN
                        {
                            chkMontoEspecialInscr.Checked   = true;
                            txtMontoEspecialInscr.Text      = dtSolAprobac.Rows[i]["nValAproba"].ToString();
                            txtDescripInscrip.Text          = dtSolAprobac.Rows[i]["cSustento"].ToString();
                        }
                        if (cTipoOperac.Equals("VALIDA AUTORIZ. MONTO ESPECIAL APORTE SOCIO"))//APORTE
                        {
                            chkMontoEspecialAporte.Checked  = true;
                            txtMontoEspecialAporte.Text     = dtSolAprobac.Rows[i]["nValAproba"].ToString();
                            txtDescripAporte.Text           = dtSolAprobac.Rows[i]["cSustento"].ToString();
                        }
                        if (cTipoOperac.Equals("VALIDA AUTORIZ. MONTO ESPECIAL FONDO SEGURO SOCIO"))//FONDO SEGURO
                        {
                            chkMontoEspecialFondoSeg.Checked = true;
                            txtMontoEspecialFondoSeguro.Text = dtSolAprobac.Rows[i]["nValAproba"].ToString();
                            txtDecripFondoSeguro.Text        = dtSolAprobac.Rows[i]["cSustento"].ToString();
                        }

                        cmensaje = cmensaje + dtSolAprobac.Rows[i]["idSolAproba"].ToString() + " - " + cTipoOperac + " - " + dtSolAprobac.Rows[i]["cEstadoSol"].ToString() + "." +Environment.NewLine;
                    }
                    MessageBox.Show("La inscripción del socio tiene solicitudes pendientes de Aprobación:" + Environment.NewLine + Environment.NewLine + cmensaje, "Búsqueda de Solicitudes de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //=======================================================================================================================>

                if (conBusCli1.idCli!=0 && conBusCli1.nidTipoPersona == 1)//Sólo para personas Naturales
                {
                    btnImprimir1.Enabled = true;
                    btnImprRegFirmas.Enabled = true;
                }
                else
	            {
                    btnImprimir1.Enabled        = false;
                    btnImprRegFirmas.Enabled    = false;
	            }

                btnImprSocio.Enabled = true;
            }
            btnAgregar1.Enabled             = false;
            btnQuitar1.Enabled              = false;
            btnBusCliente1.Enabled          = false;
            conBusCli1.btnBusCliente.Enabled= true;
            conBusUbig1.Enabled             = false;

        }

        private void FormatoGridRefLaboralEconomica()
        {   dtgRefLaboralesSocio.ReadOnly = false;
            dtgRefLaboralesSocio.Columns["idRefLabEcon"].Visible = false;
            dtgRefLaboralesSocio.Columns["idSocio"].Visible = false;

            dtgRefLaboralesSocio.Columns["cNombre"].HeaderText = "Nombre";
            dtgRefLaboralesSocio.Columns["cDescr"].HeaderText = "Descripción / Comentario";

            dtgRefLaboralesSocio.Columns["cNombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgRefLaboralesSocio.Columns["cDescr"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgRefLaboralesSocio.Columns["cNombre"].FillWeight = 120;
            dtgRefLaboralesSocio.Columns["lVigente"].Visible = false;
            
        }



        private DataTable TablaNingunTipoSeguro()
        {
            DataTable dtTipoFondoSeg = new DataTable();
            dtTipoFondoSeg.Columns.Add("idTipoFondoSeguro", typeof(int));
            dtTipoFondoSeg.Columns.Add("cTipoFondoSeguro", typeof(string));
            DataRow fila = dtTipoFondoSeg.NewRow();
            fila["idTipoFondoSeguro"] = 0;
            fila["cTipoFondoSeguro"] = "NINGUNO";
            dtTipoFondoSeg.Rows.Add(fila);

            return dtTipoFondoSeg;
        }

        private void pintarGridAporte()
        {
            foreach (DataGridViewRow item in dtgAportes.Rows)
            {
                if (Convert.ToDecimal (item.Cells[4].Value) == 0.0m)
                {
                    item.DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
            }            
        }
        private void pintarGridFondo()
        {
            foreach (DataGridViewRow item in dtgDetalleFondo.Rows)
            {
                if (Convert.ToDecimal (item.Cells[4].Value) == 0.0m)
                {
                    item.DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
            }
        }

        private void agregarBene()
        {
            clsBeneficiario nuevobeneficiario = new clsBeneficiario();

            //nuevobeneficiario.idCli         = conBusCli1.idCli;
            nuevobeneficiario.idCli         = Convert.ToInt32(txtIdCliBenef.Text);
            nuevobeneficiario.cApeCasBen    = txtApeCas.Text.Trim();
            nuevobeneficiario.cApeMatBen    = txtApeMat.Text.Trim();
            nuevobeneficiario.cApePatBen    = txtApePat.Text.Trim();
            nuevobeneficiario.cBeneficiario = (txtApePat.Text.Trim() + " " +
                                                txtApeMat.Text.Trim() + " " +
                                                txtApeCas.Text.Trim()).Trim() + ", " +
                                                txtNombres.Text.Trim();
            nuevobeneficiario.cDireccion    = txtDireccion.Text.Trim();
            nuevobeneficiario.cDocIdeBen    = txtDocIde.Text.Trim();
            nuevobeneficiario.cNombres      = txtNombres.Text.Trim();
            nuevobeneficiario.dFecRegBen    = clsVarGlobal.dFecSystem;
            nuevobeneficiario.dFecBajBen    = clsVarGlobal.dFecSystem;
            nuevobeneficiario.idEstado      = 1;
            nuevobeneficiario.idTipoRela    = (int)cboTipoFamiliar1.SelectedValue;
            nuevobeneficiario.idUsuRegBen   = clsVarGlobal.User.idUsuario;
            nuevobeneficiario.nBeneficio    = txtBeneficio.nDecValor;
            nuevobeneficiario.idUbigeo      = (int)conBusUbig1.cboDistrito.SelectedValue;
            
            listabeneficiarios.Add(nuevobeneficiario);

            dtgBeneficiario.DataSource = null;
            dtgBeneficiario.DataSource = listabeneficiarios;
            dtgBeneficiario.Refresh();
            txtNumBene.Text = dtgBeneficiario.RowCount.ToString();
        }

        private void FormatoGrid()
        {
            this.dtgBeneficiario.Columns[11].Width = 320;
            this.dtgBeneficiario.Columns[12].Width = 100;
            this.dtgBeneficiario.Columns[13].Width = 80;
        }

        private int validarBaseNegativaSocio(int idCli)
        {
            int nIndBaseNega = 0;
            cnsocio.retornarBaseNegativaSocio(idCli, ref nIndBaseNega);
            return nIndBaseNega;
        }
        #endregion

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            //========================= Limpiar Campos de Actividad Laboral o Económica =================>
            radioBtnSItrab.Checked = false;
            radioBtnNOtrab.Checked = false;
            radioBtnDepend.Checked = false;
            radioBtnIndepend.Checked = false;
            
            txtNomEmpresa.Clear();
            txtDomicilioEmpresa.Clear();
            txtCargo.Clear();
            txtTiempoServicio.Clear();
            txtRemunercActvDep.Clear();
            cboMonedaRemunerac.SelectedIndex = 0;
            cboMonedaIngBruto.SelectedIndex = 0;

            radioBtnComerc.Checked = false;
            radioBtnServ.Checked = false;
            radioBtnOtro.Checked = false;
            txtDescripOtros.Clear();
            radioBtnActFormSI.Checked = false;
            radioBtnActFormNO.Checked = false;
            txtIngresoBruto.Clear();
            txtRUC.Clear();
            txtDescrActvEconomPrinc.Clear();

            txtNomRef.Clear();
            txtRefComentario.Clear();
            dtgRefLaboralesSocio.DataSource = null;
            dtgRefLaboralesSocio.Rows.Clear();

            txtInfOtrasActv.Clear();
            //==================================================================================>

            //------------------ limipar control de búsqueda ------>
            conBusCli1.txtCodAge.Clear();
            conBusCli1.txtCodCli.Clear();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodInst.Clear();
            conBusCli1.txtDireccion.Clear();
            conBusCli1.txtNombre.Clear();
            conBusCli1.txtNroDoc.Clear();
            conBusCli1.idCli = 0;
            tbcBase1.SelectedIndex = 0;
            //---------------------------------------------------->

            // APORTES
            txtMontoInscripAporte.Text  = "0.00";
            txtAporte.Text              = "0.00";
            txtTotAporte.Text           = "0.00";
            txtTotUtilidad.Text         = "0.00";
            txtEstado.Text              = "0.00";
            dtgAportes.DataSource = null;
            dtgAportes.Rows.Clear();

            //FONDO SEGURO
            txtFondo.Text       = "0.00";
            txtTotFondo.Text    = "0.00";
            txtEstadoFondo.Text = "0.00";
            dtgDetalleFondo.DataSource = null;
            dtgDetalleFondo.Rows.Clear();

            //beneficiarios
            //------------ Deshabilitar Beneficiarios -------->
            conBusUbig1.Enabled     = false;
            btnAgregar1.Enabled     = false;
            btnQuitar1.Enabled      = false;
            btnBusCliente1.Enabled  = false;
            cboTipoFamiliar1.Enabled= false;
            txtBeneficio.Enabled    = false;
            chcBase1.Enabled        = false;

            btnBusCliente2.Enabled = false;
            //----------------------------------------------->
            txtNombres.Clear();
            txtApePat.Clear();
            txtApeMat.Clear();
            txtApeCas.Clear();
            txtDireccion.Clear();
            txtDocIde.Clear();
            txtBeneficio.Clear();
            txtNumBene.Clear();

            dtgBeneficiario.DataSource  = null;
            dtgBeneficiario.Rows.Clear();

            //------------------- Deshabilitar uso montos especiales ---------------------------->
            grbMontosEspcAporte.Enabled     = false;//Aportes Inscripción
            grbMontoEspecFondoSeg.Enabled   = false;//Fondo Seguro

            //---------------------------------------------------------------------------------->
            btnImprimir1.Enabled        = false;
            btnImprRegFirmas.Enabled    = false;
            btnImprSocio.Enabled        = false;

            btnCancelar1.Enabled    = true;
            btnInscripcion.Visible  = false;
            btnGrabar1.Enabled      = false;

            pnlFondoSeguro.Visible = true;
            pnlBeneficiarios.Visible = true;

            //------- Limpiar el uso de montos especiales ----------->
            chkMontoEspecialInscr.Checked = false;
            txtMontoEspecialInscr.Text = "";
            txtDescripInscrip.Text = "";

            chkMontoEspecialAporte.Checked = false;
            txtMontoEspecialAporte.Text = "";
            txtDescripAporte.Text = "";

            chkMontoEspecialFondoSeg.Checked = false;
            txtMontoEspecialFondoSeguro.Text = "";
            txtDecripFondoSeguro.Text = "";
            //------------------------------------------------------>

            //----------------- Limpiar Objetos de Búsqueda  ------>
            listabeneficiarios = new clslisBeneficiario();
            objsocio    = null;
            objaporte   = null;
            objfondo    = null;
            pIdSocio=0;
            //---------------------------------------------------->

            //------------------------------------ cargar combo Tipo Fondo Seguro --------------------------- >
            cboTipoFondoSeguro.SelectedIndexChanged -= new
            EventHandler(cboTipoFondoSeguro_SelectedIndexChanged);

            cboTipoFondoSeguro.DataSource           = null;
            this.cboTipoFondoSeguro.DataSource      = dtTipoFondoSeguro;
            this.cboTipoFondoSeguro.ValueMember     = dtTipoFondoSeguro.Columns["idTipoFondoSeguro"].ToString();
            this.cboTipoFondoSeguro.DisplayMember   = dtTipoFondoSeguro.Columns["cTipoFondoSeguro"].ToString();

            //añadir evento al cargar combo
            cboTipoFondoSeguro.SelectedIndexChanged += new
            EventHandler(cboTipoFondoSeguro_SelectedIndexChanged);
            //------------------------------------------------------------------------------------------------>

            conBusCli1.txtCodCli.Focus();
            conBusCli1.btnBusCliente.Enabled = true;
            pnlActvLaboral.Enabled = false;
            btnEditar1.Enabled = true;
            //------------------------------------ limpiar apoderado --------------------------- >
            txtNombreApoderado.Clear();
            txtApeCasadoApoderado.Clear();
            txtApeMatApoderado.Clear();
            txtApePatApoderado.Clear();
            txtDireccApoderado.Clear();
            txtTelefApoderado.Clear();
            txtDocIdentApoderado.Clear();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idSocio = objsocio.idSocio;
            DateTime dfechaRegSocio ;

            if (objsocio.dFecModSoc == null)
            {
                dfechaRegSocio = (DateTime)objsocio.dFecRegSoc;
            }
            else
            {
                dfechaRegSocio = (DateTime)objsocio.dFecModSoc;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_idSocio", idSocio.ToString(), false));
            paramlist.Add(new ReportParameter("nDia", dfechaRegSocio.Day.ToString(), false));
            paramlist.Add(new ReportParameter("cMes", MesNumeroLetra(dfechaRegSocio.Month), false));
            paramlist.Add(new ReportParameter("nAnnio", dfechaRegSocio.Year.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsDatosSocio", new clsCNSocio().CNDatosSocio(idSocio)));
            dtslist.Add(new ReportDataSource("dtsBeneficiarios", new clsCNSocio().CNBenficiariosFondoSeguro(idSocio)));

            string reportpath = "rptBeneficiarios.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprRegFirmas_Click(object sender, EventArgs e)
        {
            if (conBusCli1.nidTipoPersona == 1)
            {
                int idSocio = objsocio.idSocio;
                int idSocioApoderado = idCliApoderado;

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("idSocio", idSocio.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dtsRegFirmasSocio", new clsCNSocio().CNRegFirmasSocio(idSocio)));
                dtslist.Add(new ReportDataSource("dtsDatosApoderadoSocio", new clsCNSocio().CNDatosApoderadoSocio(idSocio)));

                string reportpath = "rptRegFirmas.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("Éste reporte es sólo personas naturales", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnImprSocio_Click(object sender, EventArgs e)
        {
            int nTipoPersona = conBusCli1.nidTipoPersona;
            if (nTipoPersona==1)//PERSONA NATURAL
            {
                int CodigoCliente   = Convert.ToInt32(conBusCli1.txtCodCli.Text);
                int idSocio = objsocio.idSocio;
                string cNomEmp  = clsVarApl.dicVarGen["cNomEmpresa"];
                String AgenEmision = clsVarApl.dicVarGen["cNomAge"];
                
                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("pnidCli", CodigoCliente.ToString(), false));
                paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

                paramlist.Add(new ReportParameter("x_idSocio", idSocio.ToString(), false));
                paramlist.Add(new ReportParameter("idSocio", idSocio.ToString(), false));

                dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoCliente(CodigoCliente)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsDatosPepCliente", cnpep.DatosPepCliente(CodigoCliente)));

                dtslist.Add(new ReportDataSource("dtsActividadLaboralDepEconom", cnsocio.CNRetornaActvLabEconomDependiente(idSocio)));
                dtslist.Add(new ReportDataSource("dtsActividadLaboralIndepEconom", cnsocio.CNRetornaActvLabEconomIndependiente(idSocio)));
                dtslist.Add(new ReportDataSource("dtsDatSocio", cnsocio.retornarDatosSocioComoTabla(CodigoCliente)));
                dtslist.Add(new ReportDataSource("dtsRefLaboralEconom", cnsocio.ReferenciasLaboralEconomica(idSocio)));
                dtslist.Add(new ReportDataSource("dtsBeneficiarios", new clsCNSocio().CNBenficiariosFondoSeguro(idSocio)));

                string reportpath = "rptRegSocioNatural.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog(); 
            }
            else//PERSONA JURIDICA
            {
                int CodigoCliente = Convert.ToInt32(conBusCli1.txtCodCli.Text);
                int idSocio = objsocio.idSocio;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist  = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

                paramlist.Add(new ReportParameter("idSocio", idSocio.ToString(), false));

                dtslist.Add(new ReportDataSource("dtsClienteJuridico", new clsRPTCNClientes().CNRetornoClienteJuridico(idSocio)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptRegSocioJuridico.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog(); 
            }                       
        }  

        private string MesNumeroLetra(int nMes)
        {
            string cMes = "";
            switch (nMes)
            {
                case 1: cMes = "Enero"; break;
                case 2: cMes = "Febrero"; break;
                case 3: cMes = "Marzo"; break;
                case 4: cMes = "Abril"; break;
                case 5: cMes = "Mayo"; break;
                case 6: cMes = "Junio"; break;
                case 7: cMes = "Julio"; break;
                case 8: cMes = "Agosto"; break;
                case 9: cMes = "Septiembre"; break;
                case 10: cMes = "Octubre"; break;
                case 11: cMes = "Noviembre"; break;
                case 12: cMes = "Diciembre"; break;
                default:
                    break;
            }
            return cMes;
        }

        private void cboTipoFondoSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMontosPagoFondoSeguro();
        }

        private void CargarMontosPagoFondoSeguro()
        {
            //=============== Cargar Montos de Pago para Fondo de Seguro: 'Fondo Prev Social' ó 'Fondo Mortuorio' ======>
            if (cboTipoFondoSeguro.SelectedItem != null && conBusCli1.nidTipoPersona != 0)
            {
                if (Convert.ToInt32(cboTipoFondoSeguro.SelectedValue) == 1)//Fondo Previsión Social
                {
                    txtFondo.Text = Convert.ToString(clsVarApl.dicVarGen["nMontoFondoPrevisionSocial"]);
                }
                else////Fondo Mortuorio
                {
                    txtFondo.Text = Convert.ToString(clsVarApl.dicVarGen["nMonFondoMor"]);
                }
            }
            //===========================================================================================================>
        }

        private void CargarMontosInscripcionAportesPersonaNaturalJuridica()
        {
            //=============== Cargar Montos de Inscripción para Aportes de una Persona: Natural ó Jurídica ======>
            if (cboTipoFondoSeguro.SelectedItem != null && conBusCli1.nidTipoPersona != 0)
            {             
                if (conBusCli1.nidTipoPersona == 1)//NATURAL
                {
                    txtMontoInscripAporte.Text = Convert.ToString(clsVarApl.dicVarGen["nMontoInscripPersoNatural"]);
                }
                else//JURIDICA
                {
                    txtMontoInscripAporte.Text = Convert.ToString(clsVarApl.dicVarGen["nMontoInscripPersoJuridic"]);
                } 
            }
            else
            {
                txtMontoInscripAporte.Text = "0.00";
            }
            //===================================================================================================> 
        }

        private void chkMontoEspecialFondoSeg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMontoEspecialFondoSeg.Checked == true)
            {
                txtMontoEspecialFondoSeguro.Enabled = true;
                txtDecripFondoSeguro.Enabled = true;
            }
            else
            {
                txtMontoEspecialFondoSeguro.Enabled = false;
                txtDecripFondoSeguro.Enabled = false;
            }
        }

        private void chkMontoEspecialInscr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMontoEspecialInscr.Checked == true)
            {
                txtMontoEspecialInscr.Enabled = true;
                txtDescripInscrip.Enabled = true;
            }
            else
            {
                txtMontoEspecialInscr.Enabled = false;
                txtDescripInscrip.Enabled = false;
            }
        }

        private void chkMontoEspecialAporte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMontoEspecialAporte.Checked == true)
            {
                txtMontoEspecialAporte.Enabled = true;
                txtDescripAporte.Enabled = true;
            }
            else
            {
                txtMontoEspecialAporte.Enabled = false;
                txtDescripAporte.Enabled = false;
            }
        }       


        private void radioBtnSItrab_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnSItrab.Checked==true)
            {
                radioBtnDepend.Enabled      = true;
                radioBtnIndepend.Enabled    = true;
                grbRef.Enabled              = true;

                txtInfOtrasActv.Enabled     = true;
            }
        }
        private void radioBtnNOtrab_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnNOtrab.Checked==true)
            {
                radioBtnDepend.Enabled      = false;
                radioBtnIndepend.Enabled    = false;
                grbDependiente.Enabled      = false;
                grbIndependiente.Enabled    = false;
                grbRef.Enabled              = false;
                txtInfOtrasActv.Enabled     = false;
            }            
        }



        private void radioBtnDepend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDepend.Checked == true)
            {
                grbDependiente.Enabled = true;
                grbIndependiente.Enabled = false;
                grbDependiente.BackColor = Color.FromName("Info");
            }
            else
            {
                grbDependiente.Enabled = false;
                grbIndependiente.Enabled = true;
                grbDependiente.BackColor = Color.FromName("Transparent");
            }
        }
        private void radioBtnIndepend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnIndepend.Checked == true)
            {
                grbIndependiente.Enabled = true;
                grbDependiente.Enabled = false;
                grbIndependiente.BackColor = Color.FromName("Info");
            }
            else
            {
                grbIndependiente.Enabled = false;
                grbDependiente.Enabled = true;
                grbIndependiente.BackColor = Color.FromName("Transparent");
            }
        }

        private void conBusCli2_ClicBuscar(object sender, EventArgs e)
        {
        }

        private void radioBtnOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnOtro.Checked == true)
	        {
                txtDescripOtros.Enabled = true;
                txtDescripOtros.Focus();
	        }
            else
            {
                txtDescripOtros.Enabled = false;
            }
        }

        private void btnMiniAgregaRefLab_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomRef.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la referencia Laboral.", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomRef.Focus();
                return;
            }

            DataRow drFila = dtReferenciasLaboralEconomica.NewRow();
            drFila["idRefLabEcon"]  = 0;
            drFila["cNombre"]       = txtNomRef.Text;
            drFila["cDescr"]        = txtRefComentario.Text;
            drFila["idSocio"]       = 0;
            drFila["lVigente"]      = true ;
            dtReferenciasLaboralEconomica.Rows.Add(drFila);

            txtNomRef.Clear();
            txtRefComentario.Clear();
            txtNomRef.Focus();
        }

        private void btnMiniQuitaRefLab_Click(object sender, EventArgs e)
        {
            if (dtgRefLaboralesSocio.Rows.Count>0)
            {
                dtgRefLaboralesSocio.Focus();
                int indice = dtgRefLaboralesSocio.CurrentRow.Index;  
                int idSoc=Convert.ToInt32(dtgRefLaboralesSocio.Rows[indice].Cells["idSocio"].Value.ToString());
                if (idSoc != 0)
                {
                    int idRefLab= Convert.ToInt32(dtgRefLaboralesSocio.Rows[indice].Cells["idRefLabEcon"].Value.ToString());
                    DataRow drFila = dtRefLabEconoElim.NewRow();
                    drFila["idRefLabEcon"]  = idRefLab;
                    drFila["cNombre"]       = "";
                    drFila["cDescr"]        = "";
                    drFila["idSocio"]       = idSoc;
                    drFila["lVigente"]      = false ;
                    dtRefLabEconoElim.Rows.Add(drFila);
                }
                
                dtgRefLaboralesSocio.Rows.RemoveAt(indice);
                dtReferenciasLaboralEconomica.Rows.RemoveAt(indice);
            }            
        }

        private DataTable RetornarEstructuraRefLaborales()
        {
            DataTable dtEstructuraRefLab = new DataTable();
            dtEstructuraRefLab.Columns.Add("idRefLabEcon", typeof(int));
            dtEstructuraRefLab.Columns.Add("cNombre", typeof(string));
            dtEstructuraRefLab.Columns.Add("cDescr", typeof(string));
            dtEstructuraRefLab.Columns.Add("idSocio", typeof(int));
            dtEstructuraRefLab.Columns.Add("lVigente", typeof(bool));
            return dtEstructuraRefLab;
        }

        private void btnBusCliente2_Click(object sender, EventArgs e)
        {
            FrmBusCli frmbuscli = new FrmBusCli();
            frmbuscli.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscli.pcCodCli))
            {
                return;
            }
            if (frmbuscli.pnTipoPersona != 1)
            {
                MessageBox.Show("Por favor ingresar una persona Natural", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //======================== Habilitar Apoderado ==========================================>
            int nEdadCliApo = cnCliente.CalcularEdad(Convert.ToInt32(frmbuscli.pcCodCli), clsVarGlobal.dFecSystem);
            if (nEdadCliApo<18)
            {
                 MessageBox.Show("El Apoderado debe tener mayoria de edad", "Apoderado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtNombreApoderado.Clear();
                 txtApeMatApoderado.Clear();
                 txtApePatApoderado.Clear();
                 txtApeCasadoApoderado.Clear();
                 frmbuscli.pcCodCli = "0";
                 txtDireccApoderado.Clear();
                 txtDocIdentApoderado.Clear();
                 txtTelefApoderado.Clear();
                 return;
            }
            //===================================================================================>

            string ctipoPer = frmbuscli.pnTipoPersona == 1 ? "N" : "J";
            buscarApoderadoSocio(Convert.ToInt32(frmbuscli.pcCodCli), ctipoPer);
            
        }
        private void buscarApoderadoSocio(int idcli,string cTipoPersona )
        {
            clsCliente datclienteApoderado = new clsCNRetDatosCliente().retornarCliente(idcli, cTipoPersona);

            if (datclienteApoderado.cDocumentoID.Trim() == conBusCli1.txtNroDoc.Text.Trim())
            {
                MessageBox.Show("El socio titular no puede ser APODERADO de si mismo", "Validación Apoderado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            idCliApoderado = idcli;
            DataTable dtDatDirec = new clsCNDirecCli().ListaDirCli(datclienteApoderado.idCli);
            if (dtDatDirec.Rows.Count <= 0)
            {
                MessageBox.Show("Debe Actualizar datos del Apoderado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNombreApoderado.Text = (datclienteApoderado.cNombre + " " + datclienteApoderado.cNombreSeg + " " + datclienteApoderado.cNombreOtros).Trim();
            txtApePatApoderado.Text = datclienteApoderado.cApellidoPaterno.Trim();
            txtApeMatApoderado.Text = datclienteApoderado.cApellidoMaterno.Trim();
            txtApeCasadoApoderado.Text = datclienteApoderado.cApellidoCasado.Trim();


            txtDireccApoderado.Text = dtDatDirec.Rows[0]["cDireccion"].ToString();
            txtDocIdentApoderado.Text = datclienteApoderado.cDocumentoID.Trim();
            txtTelefApoderado.Text = datclienteApoderado.nNumeroTelefono;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli!=0)
            {
                operacion = Transaccion.Edita;
                btnEditar1.Enabled = false;
                btnGrabar1.Enabled = true;
                
                btnAgregar1.Enabled = true;
                btnQuitar1.Enabled = true;
                btnBusCliente1.Enabled = true;
                pnlBeneficiarios.Enabled = true;
               
                
                cboTipoFamiliar1.Enabled = true;
                txtBeneficio.Enabled = true;
             
                tbcBase1.SelectedTab = tabPageActvLab;
                pnlActvLaboral.Enabled = true;
                btnBusCliente2.Enabled = true;
                grbApoderado.Enabled = true;
            }
        }             
    }
}

