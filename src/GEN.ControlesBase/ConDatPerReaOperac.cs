using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;
using CLI.Servicio;
using System.Xml;

namespace GEN.ControlesBase
{
    public partial class ConDatPerReaOperac : UserControl
    {
        clsProcesaDatosRen objCliente; //jcasas
        public string cDocumentoID = "";
        public string cNombre = "";
        public string cDireccion = "";
        public int idCli = 0;
        public bool bExiste = false;
        public bool lMostrarMsjeJuridico;

        clsCNBuscarCli BusPerson = new clsCNBuscarCli();
        DataTable dtPerson;
        BackupTitular modelBackTitular = new BackupTitular();
        clsCNGenVariables RetVar = new clsCNGenVariables();
        public ConDatPerReaOperac()
        {
            InitializeComponent();
            lMostrarMsjeJuridico = true;
          
        }

        private void LimpiarDatos()
        {
            cNombre = "";
            cDireccion = "";
            idCli = 0;
        }

        public void DesabilitarCtrls()
        {
            txtDocIdePerson.Enabled = false;
            txtNombrePerson.Enabled = false;
            txtDireccPerson.Enabled = false;
        }
        public void BackupTitular(string cNombre,string cDireccion,string cDni)
        {
            
            modelBackTitular.cNombre = cNombre;
            modelBackTitular.cDireccion = cDireccion;
            modelBackTitular.cDni = cDni;
        }
        public void BusPerByDocIde()
        {
            LimpiarDatos();
      
            if (txtDocIdePerson.Text.Length >= 8)
            {
                dtPerson = BusPerson.ListarClientes("1", txtDocIdePerson.Text);

                if (dtPerson.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtPerson.Rows[0]["IdTipoPersona"])!=1) //--Si es Distinto a Persona Natural
                    {
                        if (lMostrarMsjeJuridico)
                        {
                            MessageBox.Show("No puede ser una Persona Jurídica...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        txtDocIdePerson.Clear();
                        txtDocIdePerson.Focus();
                        return;
                    }
                    cNombre = Convert.ToString(dtPerson.Rows[0]["cNombre"]);
                    cDireccion = Convert.ToString(dtPerson.Rows[0]["cDireccion"]);
                    idCli = Convert.ToInt32(dtPerson.Rows[0]["idCli"]);
                    
                    txtNombrePerson.Enabled = false;
                    txtDireccPerson.Enabled = false;
                    BackupTitular(cNombre, cDireccion, Convert.ToString(dtPerson.Rows[0]["cDocumentoID"]));
                    bExiste = true;
                }
                else
                {

                    LimpiarDatos();
                    txtNombrePerson.Enabled = true;
                    txtDireccPerson.Enabled = true;
                    bExiste = false;
                 
                }

          
            }
            txtNombrePerson.Text = cNombre;
            txtDireccPerson.Text = cDireccion;
      
 

          
        }
        private void GestionarConsultaReniec(string cDocumento) //jcasas
        {

            if (cDocumento.Length != 8)
            {
                MessageBox.Show("Formato de DNI incorrecto", "Consulta RENIEC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDocumento, clsVarGlobal.User.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);

            clsReniec obj = new clsReniec(objParam, objReniec);

            objCliente = obj.GetReniec();

        }

        private void AsignarDatos() //jcasas
        {
            /****
             * 
             * datos Generales
             * 
             * *****/

            if (objCliente.cNombres.Trim() == "NA")
            {
                MessageBox.Show("No se obtuvo la consulta de RENIEC.", "Consulta RENIEC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cNombre = "";//modelBackTitular.cNombre;
                cDireccion = "";// modelBackTitular.cDireccion;
                cDocumentoID = "";//;modelBackTitular.cDni;
                return;
            }

            cNombre = objCliente.cApellidoPater.Trim() + " " + objCliente.cApellidoMater.Trim() +" " + objCliente.cNombres;
            cDireccion = objCliente.cDireccion.Trim();


     

        }
        private void ConDatPerReaOperac_Load(object sender, EventArgs e)
        {

        }

        private void txtDocIdePerson_TextChanged_1(object sender, EventArgs e)
        {
            BusPerByDocIde();
            if (txtDocIdePerson.Text.Length >= 8)
            {
                if (bExiste == false)
                {
                    int nBuscarReniec = Convert.ToInt32(RetVar.RetornaVariable("nBuscarReniec", 0));

                    if (nBuscarReniec == 1)
                        {
                            if (MessageBox.Show("¿Desea realizar una consulta a RENIEC para este número de DNI?", "Consulta RENIEC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                GestionarConsultaReniec(Convert.ToString(txtDocIdePerson.Text.Trim()));
                                AsignarDatos();
                                txtNombrePerson.Text = cNombre;
                                txtDireccPerson.Text = cDireccion;


                            }
                            else
                            {
                                MessageBox.Show("Por favor continúe con el registro de Datos del Cliente.", "Consulta RENIEC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

             

                
                  
                }
            }
        }

        private void txtDocIdePerson_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                BusPerByDocIde();

            }
        }

        public void OcultarDireccion()
        {
            lblBase1.Visible = false;
            txtDireccPerson.Visible = false;
        }

    }
}
public class BackupTitular
{
    public string cNombre { get; set; }
    public string cDireccion { get; set; }
    public string cDni { get; set; }
}