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
using GEN.BotonesBase;
using Microsoft.Reporting.WinForms;
using System.IO;
using WCF.Reniec;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections;


namespace CLI.Presentacion
{
    public partial class frmConsultaDni : frmBase
    {

        clsProcesaDatosRen dataRen = new clsProcesaDatosRen();

        string cDniBusqueda = "";
        string cTitulo = "CONSULTA DNI RENIEC";
        string nIdMod = clsVarGlobal.idModulo.ToString().Trim();
        string cDocAutorizado = "";
        //string cCodEmp = "DE2089";
        string cIdUsu=clsVarGlobal.User.idUsuario.ToString().Trim();

        public frmConsultaDni()
        {
            InitializeComponent();
            ObtenerDniAut();
            habilitarCampos(false);
            this.btnBusqueda1.Enabled = true;
            this.btnImprimir1.Enabled = false;
            this.btnBlanco1.Enabled = false;
        }
        public frmConsultaDni(string cNroDni)
        {
            InitializeComponent();
            ObtenerDniAut();
            habilitarCampos(false);
            this.btnBusqueda1.Enabled = true;
            this.btnImprimir1.Enabled = false;
            this.btnBlanco1.Enabled = false;

            this.txtNumerico1.Visible = false;
            this.lblBase2.Visible = false;
            this.btnBusqueda1.Visible = false;
            this.lblBase1.Visible = false;
            this.btnBlanco1.Visible = false;
            this.btnCancelar1.Visible = false;

            this.txtNumerico1.Text = cNroDni;
            this.Buscar();

            this.txtBase9.Enabled = false;
            this.txtBase2.Enabled = false;
            this.txtBase1.Enabled = false;
            this.txtBase6.Enabled = false;
            this.txtBase7.Enabled = false;
            this.txtBase3.Enabled = false;
            this.txtBase4.Enabled = false;
            this.txtBase5.Enabled = false;
            this.txtBase8.Enabled = false;
        }
        private void ObtenerDniAut()
        {
            clsCNConsultaDatos ConsultaDNI = new clsCNConsultaDatos();
            DataTable dtDniAut = ConsultaDNI.CNConsultaDatosDniAut(Convert.ToInt32(nIdMod));
            cDocAutorizado=dtDniAut.Rows[0]["cDocumentoID"].ToString();
        }
        private bool GetReniec(string cNroDni)
        {
            string dicto = "{\"cNroDni\":\"" + cNroDni + "\",\"cDocAutorizado\":\"" + cDocAutorizado +"\",\"cIdUsu\":\"" + cIdUsu + "\"}";

            //string cServicio = "http://10.4.12.15/WCFReniec/Service1.svc";
            //string cServicio = "http://localhost:21982/Service1.svc";
            //string cServicio = "http://10.4.12.4/WCFReniec/Service1.svc";
            //string cServicio = "http://10.5.5.70:8000/ServicioReniec.svc";
            string cServicio = clsVarApl.dicVarGen["cServicioWCFRen"];

            byte[] bBytes = Encoding.ASCII.GetBytes(dicto); //Encoding.ASCII.GetBytes(dicto);
            byte[] response;

            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            string serviceURL = string.Format(cServicio + "/ConsultaIndInfPerReniec", dicto);
            
            try
            {
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                Stream stream = new MemoryStream(response);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                //obj = new DataContractJsonSerializer(typeof(Persona));
                clsProcesaDatosRen resultPersona = obj.ReadObject(stream) as clsProcesaDatosRen;
                dataRen = resultPersona;
                return true;
            }
            catch(Exception e)
            { 
                //MessageBox.Show("Mensajes Errores:"+e.Message+" "+e.StackTrace);
                return false;
            }
            

            //this.txtBase2.Text = resultPersona.cNombres.Trim() + " " + resultPersona.cApellidoPater.Trim() + " " + resultPersona.cApellidoMater.Trim();
            
 
        }
        public void BorrarDatos()
        {
            //this.txtBase1.Text = null;
            this.txtBase2.Text = null;
            this.txtBase3.Text = null;
            this.txtBase4.Text = null;
            this.txtBase5.Text = null;
            this.txtNumerico1.Text = null;

            this.txtBase1.Text = null;
            this.txtBase6.Text = null;
            this.txtBase7.Text = null;
            this.txtBase8.Text = null;
            this.txtBase9.Text = null;


            this.datePicker1.Value = clsVarGlobal.dFecSystem.ToShortDateString();
            this.datePicker2.Value = clsVarGlobal.dFecSystem.ToShortDateString();
            this.datePicker3.Value = clsVarGlobal.dFecSystem.ToShortDateString();
            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;
            if (txtNumerico1.Text == "")
                label1.Text = "";

        }

        public void BuscarDatos(string cDNI)
        {
            if (!GetReniec(cDNI))
            {
                DataTable dtBusLog = new clsCNConsultaDatos().CNBuscaLog(cDNI);
                if (dtBusLog.Rows.Count > 0)
                {
                    string cErrorLog = dtBusLog.Rows[0]["cError"].ToString();
                    string cDescripcion = dtBusLog.Rows[0]["cDescripcion"].ToString();

                    MessageBox.Show("No se obtuvo la consulta debido a:  " + cErrorLog + " - " + cDescripcion, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("No se obtuvo la consulta.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return;
            }

            if (dataRen.cNombres.Trim() == null)
            {
                BorrarDatos();
                MessageBox.Show("No se obtuvo alguna respuesta o se contempla algun error.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.label1.Text = dataRen.cDniF.Trim()+"-"+dataRen.cDigitoVerif;
            this.txtBase2.Text = dataRen.cNombres.Trim();
            this.txtBase1.Text = dataRen.cApellidoPater.Trim();
            this.txtBase6.Text = dataRen.cApellidoMater.Trim();
            this.txtBase7.Text = dataRen.cApellidoCasada.Trim();
            DataTable dtRes = new clsCNConsultaDatos().CNRetornaRestri(dataRen.cRestrccion);

            this.txtBase8.Text = Convert.ToString(dtRes.Rows[0]["cDescripcion"].ToString());
            this.txtBase9.Text = dataRen.cDniF.Trim();


            this.txtBase3.Text = dataRen.cDireccion.Trim() + " " + dataRen.cNumDireccion.Trim();
            this.txtBase4.Text = dataRen.cUbigeoDepNac.Trim() + dataRen.cUbigeoProvNac.Trim() + dataRen.cUbigeoDistNac.Trim() + "-" + dataRen.cNomDepNac.Trim() + "/" + dataRen.cNomProvNac.Trim() + "/" + dataRen.cNomDistNac.Trim();
            this.txtBase5.Text = dataRen.cUbigeoDep.Trim() + dataRen.cUbigeoProv.Trim() + dataRen.cUbigeoDist.Trim() + "-" + dataRen.cNomDep.Trim() + "/" + dataRen.cNomProv.Trim() + "/" + dataRen.cNomDist.Trim();

            if (dataRen.cFechaInsc.Trim() != "")
                this.datePicker1.Value = ConvertirFecha(dataRen.cFechaInsc.Trim());
            if (dataRen.cFechaExpe.Trim() != "")
                this.datePicker2.Value = ConvertirFecha(dataRen.cFechaExpe.Trim());
            if (dataRen.cFechaNac.Trim() != "")
                this.datePicker3.Value = ConvertirFecha(dataRen.cFechaNac.Trim());


            // Set the size of the PictureBox control.//177, 254
            this.pictureBox1.Size = new System.Drawing.Size(230, 291);
            //Set the SizeMode to center the image.
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            // Set the size of the PictureBox control.
            this.pictureBox2.Size = new System.Drawing.Size(264, 129);
            //Set the SizeMode to center the image.
            this.pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            // Convert base 64 string to byte[]
            
            byte[] imgFoto = Convert.FromBase64String(dataRen.cFotoF);
            byte[] imgFirma = Convert.FromBase64String(dataRen.cFirmaF);

            // Convert byte[] to Image
            if (imgFoto.Length > 0)
            {
                using (var ms = new MemoryStream(imgFoto, 0, imgFoto.Length))
                {
                    pictureBox1.Image = Image.FromStream(ms, true);
                }
            }
            if (imgFirma.Length > 0)
            {
                using (var ms = new MemoryStream(imgFirma, 0, imgFirma.Length))
                {
                    pictureBox2.Image = Image.FromStream(ms, true);
                }
            }

            habilitarCampos(true);
            //this.txtBase1.Text = null;
            this.txtNumerico1.Text = null;
            this.txtNumerico1.Enabled = false;
            this.btnImprimir1.Enabled = true;
            this.btnBlanco1.Enabled = true;

        }
        private void habilitarCampos( bool camp)
        {
            this.txtBase2.Enabled = camp;
            this.txtBase3.Enabled = camp;
            this.txtBase4.Enabled = camp;
            this.txtBase5.Enabled = camp;
            this.txtBase1.Enabled = camp;
            this.txtBase6.Enabled = camp;
            this.txtBase7.Enabled = camp;
            this.txtBase8.Enabled = camp;
            this.txtBase9.Enabled = camp;

            

           /* this.datePicker1.Enabled = camp;
            this.datePicker2.Enabled = camp;
            this.datePicker3.Enabled = camp;
            */
            this.btnBusqueda1.Enabled = camp;
        
        }
        private DateTime ConvertirFecha(string cFecha)
        {
            int nAnio = Convert.ToInt32(cFecha.Substring(0, 4));
            int nMes = Convert.ToInt32(cFecha.Substring(4, 2));
            int nDia = Convert.ToInt32(cFecha.Substring(6, 2));
            DateTime date1 = new DateTime(nAnio, nMes, nDia, 0, 0, 0);
            return date1;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            //if (this.txtBase1.Text == "" || this.txtBase1.Text == null)
            if (this.txtNumerico1.Text == "" || this.txtNumerico1.Text == null || this.txtNumerico1.TextLength<8)
            {
                MessageBox.Show("Ingrese un número de DNI", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            cDniBusqueda = this.txtNumerico1.Text;
            // BorrarDatos();
            BuscarDatos(cDniBusqueda);
        
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            BorrarDatos();
            habilitarCampos(false);
            this.btnBusqueda1.Enabled = true;
            this.txtNumerico1.Enabled = true;
            this.btnImprimir1.Enabled = false;
            this.btnBlanco1.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.txtBase2.Text == "" || this.txtBase2.Text == null)
            {
                MessageBox.Show("No existe algún dato para este DNI.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //string cLogTransac = Convert.ToString(this.cboLogTransacEstado.SelectedValue);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            //string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();
            string dFecOpe = clsVarGlobal.dFecSystem.ToString();   //clsVarApl.dicVarGen["CRUTALOGO"].ToString();


            clsCNConsultaDatos ConsultaDatos = new clsCNConsultaDatos();

            DataTable dtData =  ConsultaDatos.CNConsultaDatosReporte(dataRen.cDniF);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("DataSet1", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cDocumentoID", dataRen.cDniF.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe, false));

                string reportPath = "rptConsultaReniec.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta Consulta.", cTitulo + "- REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
        }

        private void txtBase1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten numeros", cTitulo + "- ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void txtNumerico1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Buscar();
            }

        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(dataRen.cDniF , true);
                MessageBox.Show("Número de DNI copiado al portapapeles.",
                    cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("No se tiene una consulta activa, no se copio número de DNI al portapapeles", cTitulo,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

   
    }
}
