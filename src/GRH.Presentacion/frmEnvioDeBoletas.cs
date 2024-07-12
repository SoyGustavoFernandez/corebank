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
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using GRH.CapaNegocio;
namespace GRH.Presentacion
{
    public partial class frmEnvioDeBoletas : frmBase
    {

        #region Variables Globales
        string cTitulo = "Envío de Boletas de Pago";
        string cDominio ="@cajalosandes.pe";
        string cCorreoValidacion = "Este es un correo de validacion, para el envío de Boletas de Pago,<br> que se envió desde el formulario : Envío de Boletas de Pago, desde el CoreBank <br> <br> Saludos";
        #endregion

        #region eventos
        public frmEnvioDeBoletas()
        {
            InitializeComponent();
            DesactivarBotones();
        }
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (dtgBase1.RowCount > 0)
            {
                int c = 0;
                int contadorENV = 0;
                int contadorNOENV = 0;

                foreach (DataGridViewRow row in dtgBase1.Rows)
                {
                    dtgBase1.Rows[c].Selected = true;
                    c++;

                    string cNomArchivo;
                    string cDni = Convert.ToString(row.Cells["dni"].Value).Trim();
                    string cNombres = Convert.ToString(row.Cells["nombres"].Value).Trim();
                    string cApellidos = Convert.ToString(row.Cells["paterno"].Value).Trim() + " " + Convert.ToString(row.Cells["materno"].Value).Trim();
                    string cPeriodo = Convert.ToString(row.Cells["periodo"].Value).Trim();
                    string cAgencia = Convert.ToString(row.Cells["agencia"].Value).Trim();
                    string cCorreoColabString = Convert.ToString(row.Cells["correo"].Value).Trim();
                    string cSexo = Convert.ToString(row.Cells["sexo"].Value);

                    TextInfo textInfo = new CultureInfo("es-PE", false).TextInfo;
                    cNombres = textInfo.ToTitleCase(cNombres.ToLower());
                    cApellidos = textInfo.ToTitleCase(cApellidos.ToLower());
                    cAgencia = textInfo.ToTitleCase(cAgencia.ToLower());
                    cPeriodo = textInfo.ToLower(cPeriodo.ToLower());
                    cSexo = textInfo.ToLower(cSexo.ToLower());
                    cNomArchivo = txtBase3.Text.Trim() + "\\" + cDni.Trim() + " " + cNombres.Trim() + " " + cApellidos.Trim() + " boleta de pago  " + cPeriodo.Trim() + "   " + cAgencia.Trim() + ".pdf";
                    //MessageBox.Show(cNomArchivo);

                    List<string> cCorreoColab = new List<string>();
                    cCorreoColab.Add(cCorreoColabString);//txtBase1.Text.Trim()); //Cambiar correo para pruebas
                    List<string> cAdjunto = new List<string>();
                    cAdjunto.Add(cNomArchivo);
                    string cEstim = cSexo == "m" ? "Estimado" : "Estimada";
                    string cCorreo = cEstim + " " + cNombres + "<br><br>Mediante el presente se le envía su boleta de pago correspondiente al presente mes.<br><br>Nota: Favor de firmar una copia y entregarla al coordinador de operaciones o a quien haga sus veces, para que luego sea remitida a esta gerencia.<br><br>Gracias.<br>Atentamente,<br>Gerencia de Talento Humano.<br>";
                    string cEstado = "0";
                    string cError = "0";

                    try
                    {
                        if (enviarMensaje(cCorreoColab, cNombres + " tu boleta de pago de " + cPeriodo, cCorreo, cAdjunto))
                        {
                            // MessageBox.Show("Envio correcto");
                            contadorENV++;
                            cEstado = "1";
                            cError = "1";
                            DataTable InsDatos = new clsCNEnvioBoletas().CNInsertarDatos(cDni, cNombres, cApellidos, cPeriodo, cAgencia, cCorreoColabString, cSexo, cNomArchivo, cEstado, cError);
                        }


                    }
                    catch (Exception f)
                    {

                        contadorNOENV++;
                        cError = f.InnerException + "*****" + f.Message + "*****" + f.Source + "*****" + f.StackTrace + "*****" + f.TargetSite;
                        DataTable InsDatos = new clsCNEnvioBoletas().CNInsertarDatos(cDni, cNombres, cApellidos, cPeriodo, cAgencia, cCorreoColabString, cSexo, cNomArchivo, cEstado, cError);
                    }


                }
                MessageBox.Show("Correos enviados(" + Convert.ToString(contadorENV) + ") , Correos no enviados (" + Convert.ToString(contadorNOENV) + ")", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No existen registros para el envío.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.txtBase1.Text = null;
            this.txtBase2.Text = null;
            this.txtBase3.Text = null;
            this.dtgBase1.DataSource = null;
            DesactivarBotones();

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            clsCNEnvioBoletas VerDatos = new clsCNEnvioBoletas();
            DateTime dhoyy = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            DataTable dtData2 = VerDatos.CNVerDatos(1);
            int nDato = 1;

            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("DataSet1", dtData2));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("dhoyy", dhoyy.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("nDato", nDato.ToString(), false));
                string reportPath = "rptEnvioBoletas.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }


        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBase3.Text = folderBrowserDialog1.SelectedPath;
                this.txtBase1.Enabled = true;
                this.txtBase2.Enabled = true;
                this.btnValidar1.Enabled = true;

            }

        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Documentos(*.xls, *.xlsx ) | *.xls; *.xlsx";
            string ruta = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                string strConnnectionOle = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + ruta + ";Extended Properties = " + '"' + "Excel 12.0 Xml;HDR = YES" + '"';
                string sqlExcel = "Select * From [masivo$]";
                DataTable DS = new DataTable();
                OleDbConnection oledbConn = new OleDbConnection(strConnnectionOle);
                try
                {
                    oledbConn.Open();
                    OleDbCommand oledbCmd = new OleDbCommand(sqlExcel, oledbConn);
                    OleDbDataAdapter da = new OleDbDataAdapter(oledbCmd);

                    da.Fill(DS);
                    dtgBase1.DataSource = DS;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            this.btnEnviar1.Enabled = true;
            this.btnExporExcel1.Enabled = false;


        }

        private void btnValidar1_Click(object sender, EventArgs e)
        {

            List<string> cDestinoCorreo = new List<string>();
            cDestinoCorreo.Add(txtBase1.Text.Trim() + cDominio);//txtBase1.Text.Trim()); //Cambiar correo para pruebas
            List<string> cAdjunto = new List<string>();
            string Adjunto = txtBase3.Text.Trim() + "\\PruebaEnvio.pdf";
            //string rutal="/795980 Jose Luis Campos Raffo boleta de pago enero 2018 Arequipa.pdf";
            cAdjunto.Add(Adjunto);


            if (enviarMensaje(cDestinoCorreo, "Boletas de Pago", cCorreoValidacion, cAdjunto))
            {
                MessageBox.Show("El correo de validación se envió correctamente a : " + txtBase1.Text.Trim() + cDominio + ",\npara poder continuar con el envío de las boletas \ndebe de validar que le haya llegado correctamente el correo de validación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.txtBase1.Enabled = false;
                this.txtBase2.Enabled = false;
                this.btnValidar1.Enabled = false;
                this.btnExporExcel1.Enabled = true;
                this.btnCargarFile1.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se pudo enviar el correo de validación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtBase1.Enabled = true;
                this.txtBase2.Enabled = true;

                return;
            }



        }
        #endregion 

        #region metodos

        private void DesactivarBotones()
        {
            this.btnCargarFile1.Enabled = true;
            this.btnEnviar1.Enabled = false;
            this.btnValidar1.Enabled = false;
            this.btnExporExcel1.Enabled = false;
            this.txtBase1.Enabled = false;
            this.txtBase2.Enabled = false;
            this.txtBase3.Enabled = false;


        }

        public bool enviarMensaje(List<string> cMailDestino, string cAsuntoMensaje, string cCuerpoMensaje, List<string> listAdjuntos)
        {
            try
            {
                if (cMailDestino.Count > 0)
                {
                    string cSmtpCliente = "mail.cajalosandes.pe"; //clsVarApl.dicVarGen["cSmtpCliente"];
                    string cCorreoGen = txtBase1.Text.Trim() + cDominio; //clsVarApl.dicVarGen["cCorreoGen"];
                    string cCorreoNombre = "Gerencia de Talento Humano"; //clsVarApl.dicVarGen["cCorreoNombre"];
                    string cPassCorreo = txtBase2.Text.Trim(); //clsVarApl.dicVarGen["cPassCorreo"];
                    //------//string cConfidencialidadMsg = clsVarApl.dicVarGen["cConfidencialidadMsg"];
                    int nPuertoSmtpCliente = clsVarApl.dicVarGen["nPuertoSmtpCliente"];

                    //------//cCuerpoMensaje = cCuerpoMensaje + "<br> <br>";// +cConfidencialidadMsg;

                    SmtpClient smtpcliente = new SmtpClient(cSmtpCliente, nPuertoSmtpCliente);
                    smtpcliente.UseDefaultCredentials = false;
                    NetworkCredential credenciales = new NetworkCredential(cCorreoGen, cPassCorreo);
                    smtpcliente.Credentials = credenciales;

                    MailAddress mensajeDE = new MailAddress(cCorreoGen, cCorreoNombre);

                    MailMessage mensaje = new MailMessage();

                    mensaje.From = mensajeDE;

                    cCuerpoMensaje = cCuerpoMensaje + "<br> <br>";// +cConfidencialidadMsg;

                    foreach (string item in cMailDestino)
                    {
                        mensaje.To.Add(new MailAddress(item));
                    }

                    if (listAdjuntos != null)
                    {
                        foreach (string cAdjunto in listAdjuntos)
                        {
                            if (System.IO.File.Exists(cAdjunto))
                            { mensaje.Attachments.Add(new Attachment(cAdjunto)); }
                            else
                            {

                            }
                        }
                    }

                    mensaje.Priority = MailPriority.High;
                    mensaje.Subject = cAsuntoMensaje;
                    mensaje.SubjectEncoding = Encoding.UTF8;
                    mensaje.Body = cCuerpoMensaje;
                    mensaje.BodyEncoding = Encoding.UTF8;
                    mensaje.IsBodyHtml = true;

                    try
                    {
                        smtpcliente.Send(mensaje);
                        return true;
                    }
                    catch (Exception e)
                    {
                        string msg = e.InnerException + "***" + e.Message + "***" + e.Source + "***" + e.StackTrace + "***" + e.TargetSite;
                        MessageBox.Show(msg, "Mensaje");
                        return false;
                    }


                }

                return false;
            }
            catch (SmtpException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        #endregion

    }
}
