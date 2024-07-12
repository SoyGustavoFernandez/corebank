using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmScoring : frmBase
    {
        List<clsVariableScoring> lstVariables = new List<clsVariableScoring>();
        clsCNScoring CNScoring = new clsCNScoring();
        List<Puntuacion> lstPuntuaciones = new List<Puntuacion>();
        DataTable dtMontosMaximosOtor = new DataTable();
        clsPersonaScoring objPersonaScoring = new clsPersonaScoring();

        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        decimal nScoring = 0.00M;

        public frmScoring()
        {
            InitializeComponent();
        }

        private void frmScoring_Load(object sender, EventArgs e){
            cboEstadoCivil.CargarEstadoCivil(1);
            cboEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestinoCredito.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dtValores = CNScoring.ObtenerVariables(false);
            lstVariables = (List<clsVariableScoring>)dtValores.ToList<clsVariableScoring>();
            grbDatosAdicionales.Enabled = false;
            limpiar();
            txtNroDocumento.Focus();
            grbDocumento.Enabled = true;
        }

        private void btnMiniAceptar1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            ObtenerDatosCliente();
            if (!ClienteConCreditoAprobado())
            {
                if (!PrimerScoring() || objPersonaScoring.nEndeudamientoRCC > 19700M)
                {
                    MessageBox.Show("El cliente requiere evaluación normal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblMensaje.Text = "El cliente requiere evaluación normal";
                    CNScoring.RegistroLogScoring(txtNroDocumento.Text.ToString().Trim(), nScoring, clsVarGlobal.PerfilUsu.idUsuario, 2, false);
                }
                else
                {
                    //AGREGAR LO INDICADO
                    dtMontosMaximosOtor = CNScoring.ObtenerMaximoMontos(chcBancarizado.Checked, Convert.ToInt32(cboDestinoCredito.SelectedValue), 20000.00M - objPersonaScoring.nEndeudamientoRCC, false);
                    //AQUI AGREGAMOS
                    if (dtMontosMaximosOtor.Rows.Count > 0)
                    {
                        objPersonaScoring.nPlazoMaximo = Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoConEvaluacion"]);
                        objPersonaScoring.nMontoMaximo = Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoConEvaluacion"]);
                        lblMaxMonto.Text = "Max. " + objPersonaScoring.nMontoMaximo.ToString("0,0.00");
                        lblMaxPlazo.Text = "Max. " + objPersonaScoring.nPlazoMaximo + " meses";
                    }
                    grbDatosAdicionales.Enabled = true;

                    if (!VerificarInformacionContactado())
                    {
                        MostrarFormContact();
                    }
                    btnRegInfCli.Enabled = true;
                    CNScoring.RegistroLogScoring(txtNroDocumento.Text.ToString().Trim(), nScoring, clsVarGlobal.PerfilUsu.idUsuario, 1, false);
                }
            }
            else
            {
                grbDatosAdicionales.Enabled = false;

                if (!VerificarInformacionContactado())
                {
                    MostrarFormContact();
                }
                btnRegInfCli.Enabled = true;

                CNScoring.RegistroLogScoring(txtNroDocumento.Text.ToString().Trim(), nScoring, clsVarGlobal.PerfilUsu.idUsuario, 3, false);
            }           

        }

        private void txtNroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                buscar();
            }
        }

        private bool ClienteConCreditoAprobado()
        {
            
            if (objPersonaScoring.lCampanha)//if (objPersonaScoring.nMonto > 0.00M)
            {
                String cMensaje = "";
                String cMensaje_lbl = "";

                /*
                if (objPersonaScoring.lRatuki)
                {
                    cMensaje = "El cliente tiene un crédito " + objPersonaScoring.cNombreCampanha + " "
                                    + ((objPersonaScoring.idCalificacionInterna == 1) ? "APROBADO" : "PRE - APROBADO")
                                    + " \nProducto: " + objPersonaScoring.cProducto
                                    + " \nAgencia: " + objPersonaScoring.cAgencia
                                    + " \nMonto: S/. " + objPersonaScoring.nMonto.ToString("0,0.00")                                    
                                    + " \nPlazo (Activo fijo): " + objPersonaScoring.nPlazoActivoFijo + " Meses "
                                    + " \nPlazo (Capital trabajo): " + objPersonaScoring.nPlazoCapitalTrabajo + " Meses ";
                }
                else
                {
                    cMensaje = "El cliente tiene un crédito " + objPersonaScoring.cNombreCampanha + " "
                                    + " \nProducto: " + objPersonaScoring.cProducto
                                    + " \nAgencia: " + objPersonaScoring.cAgencia
                                    + "\n\nAPROBADO"
                                    + " \nMonto: S/. " + objPersonaScoring.nMonto.ToString("0,0.00")
                                    + " \nPlazo (Activo fijo): " + objPersonaScoring.nPlazoActivoFijo + " Meses "
                                    + " \nPlazo (Capital trabajo): " + objPersonaScoring.nPlazoCapitalTrabajo + " Meses "
                                    + "\n\nPRE - APROBADO"
                                    + " \nMonto: S/. " + objPersonaScoring.nMontoPreAprobado.ToString("0,0.00")
                                    + " \nPlazo (Activo fijo): " + objPersonaScoring.nPlazoActivoFijoPreAprobado + " Meses "
                                    + " \nPlazo (Capital trabajo): " + objPersonaScoring.nPlazoCapitalTrabajoPreAprobado + " Meses ";
                }
                */
                string cMensajeClienteNuevo = "Esta persona aún no se encuentra registrada como CLIENTE.";

                DataTable dtObtieneMsj =  CNScoring.CNObtieneMensaje(Convert.ToInt32(objPersonaScoring.idGrupoCamp));

                string cSubMensaje1 = Convert.ToString(dtObtieneMsj.Rows[0]["cSubMensaje1"]);
                string cSubMensaje2 = Convert.ToString(dtObtieneMsj.Rows[0]["cSubMensaje2"]);
                string cSubMensaje3 = Convert.ToString(dtObtieneMsj.Rows[0]["cSubMensaje3"]);
                string cTipoCampania = Convert.ToString(dtObtieneMsj.Rows[0]["cTipoCampania"]);
                int  idGrupoCampBD = Convert.ToInt32(dtObtieneMsj.Rows[0]["idGrupoCampBD"]);


                if (idGrupoCampBD == 0)
                {
                    cMensaje = "El cliente tiene un crédito " + objPersonaScoring.cNombreCampanha + " "
                                    + " \nProducto: " + objPersonaScoring.cProducto
                                    + " \nAgencia: " + objPersonaScoring.cAgencia
                                    + " \n" + cSubMensaje1 + " \n" + cSubMensaje2 + " \n" + cSubMensaje3;

                }
                else
                {
                    string cMonto = "";
                    if (cTipoCampania == "APROBADO")
                    {
                        cMonto = "S/ " + objPersonaScoring.nMonto.ToString("0,0.00");

                    }
                    else 
                    {
                        cMonto = "S/ " + objPersonaScoring.nMontoPreAprobado.ToString("0,0.00");
                    
                    }

                    cMensaje = "El cliente tiene un crédito " + cTipoCampania + ":" + objPersonaScoring.cNombreCampanha + " "
                                      + " \nProducto: " + objPersonaScoring.cProducto
                                      + ((objPersonaScoring.idGrupoCamp == 82) ? " \nAgencia: " + objPersonaScoring.cAgencia : "")
                                      + " \nMonto: " + cMonto
                                      + " \n" + cSubMensaje1 + " \n" + cSubMensaje2 + " \n" + cSubMensaje3;
                    
                }
                                
                if (objPersonaScoring.idCliente == 0)
                { 
                    cMensaje =  cMensajeClienteNuevo+"\n\n"+cMensaje;
                }

                
                MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                cMensaje_lbl = cMensaje;
                

                lblMensaje.Text = cMensaje_lbl;
                return true;
            }
            return false;
        }

        private bool PrimerScoring()
        {
            nScoring = 0.00M;

            ObtenerValPrimerFiltroCliente();

            llenarDataTable();
            

            foreach (Puntuacion item in lstPuntuaciones)
            {
                nScoring += item.nPuntos;
                if (item.lExpluyente && item.nPuntos == 0.00M)
                {
                    nScoring = 0.00M;
                    return false;
                }
            }
            return true;
        }

        private void ObtenerDatosCliente()
        {
            DataTable dtPersona = CNScoring.ObtenerDatosClienteScoring(txtNroDocumento.Text.Trim().ToString(), false);
            if (dtPersona.Rows.Count > 0)
            {
                objPersonaScoring = dtPersona.ToList<clsPersonaScoring>()[0];
                txtNombres.Text = objPersonaScoring.cNombreCliente;
                txtTipoCliente.Text = (objPersonaScoring.nNroCreditos > 0) ? "Recurrente" : "Nuevo";
                chcBancarizado.Checked = objPersonaScoring.lBancarizado;

                if (objPersonaScoring.idCliente > 0)
                {
                    txtEdad.Text = objPersonaScoring.nEdad.ToString();
                    txtEdad.Enabled = false;
                    txtCodigoUbigeo.Text = objPersonaScoring.cUbigeoRENIEC;
                    txtCodigoUbigeo.Enabled = (objPersonaScoring.cUbigeoRENIEC.Equals("000000"));
                    cboEstadoCivil.SelectedValue = objPersonaScoring.idEstadoCivil;
                    cboEstadoCivil.Enabled = false;
                }
                else
                {
                    txtEdad.Text = "";
                    txtEdad.Enabled = true;
                    txtCodigoUbigeo.Text = "";
                    txtCodigoUbigeo.Enabled = true;
                    cboEstadoCivil.SelectedIndex = 0;
                    cboEstadoCivil.Enabled = true;
                }
            }
            else
            {
                txtEdad.Text = "";
                txtEdad.Enabled = true;
                txtCodigoUbigeo.Text = "";
                txtCodigoUbigeo.Enabled = true;
                cboEstadoCivil.SelectedIndex = 0;
                cboEstadoCivil.Enabled = true;
            }

            grbDocumento.Enabled = false;
        }

        private void ObtenerValPrimerFiltroCliente()
        {
            clsVariableScoring clsVariable = new clsVariableScoring();
            Puntuacion objPuntuacion = new Puntuacion();

            //Calificación RCC
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "CalificacionRCC";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValCalificacionRCC(clsVariable,(int)objPersonaScoring.nCalificacionRCC, objPersonaScoring.lBancarizado);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Numero entidades RCC
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "NumeroEntidadesRCC";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValNumeroEntidadesRCC(clsVariable, objPersonaScoring.nNroEntidadesRCC);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

        }

        private void ObtenerValSegundoFiltro()
        {
            clsVariableScoring clsVariable = new clsVariableScoring();
            Puntuacion objPuntuacion = new Puntuacion();

            //Nivel de endeudamiento
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "NivelEndeudamiento";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValNivelEndeudamiento(clsVariable, Convert.ToDecimal(txtMontoSolicitado.Text), objPersonaScoring.nEndeudamientoRCC);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Experiencia en el Negocio
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "ExperienciaNegocio";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValExperienciaNegocio(clsVariable, Convert.ToInt32(txtExperienciaNegocio.Text));
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Residencia
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Residencia";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValResidencia(clsVariable, clsVarGlobal.PerfilUsu.idUsuario, txtCodigoUbigeo.Text, false);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Formalizacion
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Formalizacion";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValFormalizado(clsVariable, chcFormalizado.Checked);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //Edad
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "Edad";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValEdad(clsVariable, Convert.ToInt32(txtEdad.Text));
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //RatioCuotaExcedente  -- no se tiene tasa para determinar el valor de la cuota
            double nTasa = CNScoring.obtenerTasaScoring(Convert.ToDecimal(txtMontoSolicitado.Text), false)/100;
            double nMontoDesembolso = Convert.ToDouble(txtMontoSolicitado.Text);
            double nPlazo = Convert.ToInt32(txtPlazo.Text);

            double nCuotaMensual = nMontoDesembolso * (
                                                             (nTasa * Math.Pow((1.00D + nTasa), nPlazo)) /
                                                             (Math.Pow((1.00D + nTasa), nPlazo) - 1)
                                                         );

            double nRatio = ((nCuotaMensual + Convert.ToDouble(txtObligacionesFinancieras.Text)) / (Convert.ToDouble(txtExcedente.Text) + Convert.ToDouble(txtObligacionesFinancieras.Text))) * 100;

            objPuntuacion = new Puntuacion();
            decimal nRatioResultado = Convert.ToDecimal(nRatio) ;
            objPuntuacion.cVariable = "RatioCuotaExcedente";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValRatioCuotaExcedente(clsVariable, nRatioResultado);
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //EstadoCivil
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "EstadoCivil";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValEstadoCivil(clsVariable, Convert.ToInt32(cboEstadoCivil.SelectedValue));
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

            //PlazoCredito
            objPuntuacion = new Puntuacion();
            objPuntuacion.cVariable = "PlazoCredito";
            clsVariable = lstVariables.Find(x => x.cVariable == objPuntuacion.cVariable);
            objPuntuacion.nPuntos = CNScoring.obtValPlazoCredito(clsVariable, Convert.ToInt32(txtPlazo.Text));
            objPuntuacion.lExpluyente = clsVariable.lExcluyente;
            lstPuntuaciones.Add(objPuntuacion);

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            grbDocumento.Enabled = true;
            grbDatosAdicionales.Enabled = false;
            btnRegInfCli.Enabled = false;
            txtNroDocumento.Focus();            
        }

        private void limpiar()
        {
            txtNroDocumento.Clear();
            txtNombres.Clear();
            txtTipoCliente.Clear();
            chcBancarizado.Checked = false;
            cboEstadoCivil.SelectedIndex = 0;
            txtEdad.Clear();
            txtCodigoUbigeo.Clear();
            txtExperienciaNegocio.Clear();
            chcFormalizado.Checked = false;
            cboDestinoCredito.SelectedIndex = 0;
            txtMontoSolicitado.Clear();
            txtPlazo.Clear();
            txtExcedente.Clear();
            txtObligacionesFinancieras.Clear();
            lblMensaje.Text = "";
            lblMaxMonto.Text = "";
            lblMaxPlazo.Text = "";
            lstPuntuaciones = new List<Puntuacion>();
            objPersonaScoring = new clsPersonaScoring();
        }

        private bool validarScoring()
        {
            string cMensaje = "";
            bool lValido = true;
            if (Convert.ToDecimal(txtMontoSolicitado.Text) > objPersonaScoring.nMontoMaximo)
            {
                cMensaje += ("Monto maximo " + objPersonaScoring.nMontoMaximo.ToString("0,0.00"));
                lValido = false;
            }

            if (Convert.ToInt32(txtPlazo.Text) > objPersonaScoring.nPlazoMaximo)
            {
                cMensaje += ("\nPlazo maximo " + objPersonaScoring.nPlazoMaximo + " meses");
                lValido = false;
            }

            if (!lValido)
            {
                MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lValido;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (!validarScoring())
                return;

            grbDatosAdicionales.Enabled = false;

            decimal nPuntajeFinal = SegundoScoring();
            string cMensajeMontos = "";
            //dtMontosMaximosOtor = CNScoring.ObtenerMaximoMontos(chcBancarizado.Checked, Convert.ToInt32(cboDestinoCredito.SelectedValue), 20000.00M - objPersonaScoring.nEndeudamientoRCC, false);
            if (dtMontosMaximosOtor.Rows.Count > 0)
            {
                cMensajeMontos += "\n========================================";

                if (Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoAprobado"]) != 0 && Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoAprobado"]) > 0.00M)
                {
                    cMensajeMontos += ("\n\nAPROBADO hasta S/ " + Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoAprobado"]).ToString("0,0.00")
                                    + " con plazo hasta " + dtMontosMaximosOtor.Rows[0]["nPlazoAprobado"] + " meses.");
                }

                if (Convert.ToInt32(dtMontosMaximosOtor.Rows[0]["nPlazoConEvaluacion"]) != 0 && Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoConEvaluacion"]) > 0.00M)
                {
                    cMensajeMontos += ("\n\nPRE - APROBADO hasta S/ " + Convert.ToDecimal(dtMontosMaximosOtor.Rows[0]["nMontoConEvaluacion"]).ToString("0,0.00")
                                    + " con plazo hasta " + dtMontosMaximosOtor.Rows[0]["nPlazoConEvaluacion"] + " meses.");                        
                }
               
            }

            CNScoring.ActualizarLogScoring(txtNroDocumento.Text.ToString().Trim(), nPuntajeFinal - nScoring, clsVarGlobal.PerfilUsu.idUsuario, Convert.ToInt32(cboEstadoCivil.SelectedValue), Convert.ToInt32(txtEdad.Text.ToString()), txtCodigoUbigeo.Text.ToString(), Convert.ToInt32(txtExperienciaNegocio.Text.ToString()), chcFormalizado.Checked, Convert.ToInt32(cboDestinoCredito.SelectedValue), Convert.ToDecimal(txtMontoSolicitado.Text.ToString()), Convert.ToInt32(txtPlazo.Text.ToString()), Convert.ToDecimal(txtExcedente.Text.ToString()), Convert.ToDecimal(txtObligacionesFinancieras.Text.ToString()), false);

            if (nPuntajeFinal >= 40.00M)
            {
                if (nPuntajeFinal >= 70.00M)
                {
                    MessageBox.Show("APROBADO" + cMensajeMontos, "Resultado de scoring", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblMensaje.Text = "APROBADO" + cMensajeMontos;
                }
                else
                {
                    MessageBox.Show("PRE - APROBADO" + cMensajeMontos, "Resultado de scoring", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblMensaje.Text = "PRE - APROBADO" + cMensajeMontos;
                }
            }
            else
            {
                MessageBox.Show("EVALUACIÓN NORMAL", "Resultado de scoring", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblMensaje.Text = "EVALUACIÓN NORMAL";
            }
        }


        private decimal SegundoScoring()
        {
            decimal nPuntajeFinal = 0.00M;
            ObtenerValSegundoFiltro();
            llenarDataTable();
            foreach (Puntuacion item in lstPuntuaciones)
            {
                if (item.lExpluyente && item.nPuntos == 0.00M)
                {
                    nPuntajeFinal = 0.00M;
                    break;
                }
                nPuntajeFinal += item.nPuntos;
            }
            return nPuntajeFinal;
        }


        public void llenarDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cVariable");
            dt.Columns.Add("nPuntos");
            dt.Columns.Add("lExpluyente");

            foreach (Puntuacion item in lstPuntuaciones)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.cVariable;
                dr[1] = item.nPuntos;
                dr[2] = item.lExpluyente;
                dt.Rows.Add(dr);
            }

            dtgBase1.DataSource = dt;
        }

        public void MostrarFormContact()
        {
            int idCliente = 0;
            string cDocumento = "";
            
            idCliente = objPersonaScoring.idCliente;
            cDocumento = Convert.ToString(txtNroDocumento.Text.Trim());

            if(idCliente != 0 || !String.IsNullOrWhiteSpace(cDocumento))
            {
                frmRegistroInfClienteOferta frm = new frmRegistroInfClienteOferta(idCliente, cDocumento);
                frm.ShowDialog();
            }
        }

        public bool VerificarInformacionContactado()
        {
            int idCliente = 0;
            string cDocumentoID = String.Empty;

            idCliente = objPersonaScoring.idCliente;
            cDocumentoID = Convert.ToString(txtNroDocumento.Text.Trim());

            if (idCliente != 0 || !String.IsNullOrWhiteSpace(cDocumentoID))
            {
                DataTable dtInfoContacto = objCE.CNVerificarInformacionContacto(idCliente, cDocumentoID);
                if (dtInfoContacto.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void btnRegInfCli_Click(object sender, EventArgs e)
        {
            MostrarFormContact();
        }
    }
    
}
