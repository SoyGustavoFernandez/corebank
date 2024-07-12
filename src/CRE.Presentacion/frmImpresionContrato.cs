using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.ControlesBase;
using ADM.CapaNegocio;
using Microsoft.Reporting.WinForms;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace CRE.Presentacion
{
    public partial class frmImpresionContrato : frmBase
    {
        #region Variables
        clsCNConfiguracionImpresionContratos clsConfiguracion = new clsCNConfiguracionImpresionContratos();
        private int idModulo = 2;
        private int idSolicitud;
        private int idCuenta;
        private DataTable dtIntervinientes;
        private bool lImpirmirConIntervinietes = false;
        private List<string> listaEmails = null;
        #endregion
        public frmImpresionContrato()
        {
            InitializeComponent();
        }

        #region Meotodos
        private void formatoDtgIntervinientes()
        {
            foreach (DataGridViewColumn column in dtgIntervinientes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgIntervinientes.Columns["cDocumentoID"].HeaderText = "DOCUMENTO";
            dtgIntervinientes.Columns["cNombre"].HeaderText = "NOMBRE DEL CLIENTE";
            dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "INTERVINIENTE";
            dtgIntervinientes.Columns["cCorreo"].HeaderText = "CORREO";

            dtgIntervinientes.Columns["cDocumentoID"].Visible = true;
            dtgIntervinientes.Columns["cNombre"].Visible = true;
            dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;
            dtgIntervinientes.Columns["cCorreo"].Visible = true;

            dtgIntervinientes.Columns["cDocumentoID"].FillWeight = 15;
            dtgIntervinientes.Columns["cNombre"].FillWeight = 35;
            dtgIntervinientes.Columns["cTipoIntervencion"].FillWeight = 15;
            dtgIntervinientes.Columns["cCorreo"].FillWeight = 35;

            dtgIntervinientes.Columns["cDocumentoID"].DisplayIndex = 0;
            dtgIntervinientes.Columns["cNombre"].DisplayIndex = 1;
            dtgIntervinientes.Columns["cTipoIntervencion"].DisplayIndex = 2;
            dtgIntervinientes.Columns["cCorreo"].DisplayIndex = 3;
        }

        private void llenarIntervinientes()
        {
            dtIntervinientes = clsConfiguracion.listarIntervinientes(idModulo, idSolicitud);

            dtgIntervinientes.DataSource = dtIntervinientes;
            formatoDtgIntervinientes();
            bool lEmailValidos = true;
            if (dtIntervinientes.Rows.Count > 0)
            {
                this.listaEmails = new List<string>();
                foreach (DataRow interviniente in dtIntervinientes.Rows)
                {
                    if (interviniente["idTipoInterv"].ToString().In("1","6"))
                    {
                        if (new EmailAddressAttribute().IsValid(interviniente["cCorreo"].ToString()))
                        {
                            if (!this.listaEmails.Contains(interviniente["cCorreo"].ToString(), StringComparer.OrdinalIgnoreCase))
                            {
                                this.listaEmails.Add(interviniente["cCorreo"].ToString());
                            }
                        }
                        else
                        {
                            lEmailValidos = false;
                        }
                    }
                }

                btnEmail1.Enabled = lEmailValidos;
                btnImprimir1.Enabled = true;
            }

            mostrarNumeroImpresiones();
        }

        private void mostrarNumeroImpresiones()
        {
            string nNumeroImpresiones = "0";
            DataTable dtImpresiones = clsConfiguracion.obtenerNumeroImpresiones(idModulo, idSolicitud);
            if (dtImpresiones.Rows.Count > 0)
            {
                nNumeroImpresiones = dtImpresiones.Rows[0]["nRegistros"].ToString();
            }

            txtNumImpresiones.Text = nNumeroImpresiones;
            pnlNumImpresiones.Visible = true;
        }

        private void limpiarControles()
        {
            conBusCli1.limpiarControles();
            conBusCtaAho.LimpiarControles();
            conBusGrupoSol1.LimpiarControl();
            dtIntervinientes = null;
            dtgIntervinientes.DataSource = null;
            listaEmails = null;
            tabControl1.Enabled = true;

            rdoAhorros.Checked = false;
            rdoCreditos.Checked = false;
            rdoGrupoSol.Checked = false;

            btnImprimir1.Enabled = false;
            btnEmail1.Enabled = false;

            idSolicitud = 0;

            txtNumImpresiones.Text = "0";
            pnlNumImpresiones.Visible = false;
        }

        public static string encriptarCadena(string cCadenaEncriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(cCadenaEncriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string desEncriptarCadena(string cCadenaDesencriptar)
        {
            string result = string.Empty;
            byte[] decryted =
            Convert.FromBase64String(cCadenaDesencriptar);
            System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        #endregion

        #region Funciones
        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            idSolicitud = conBusCtaAho.idcuenta;
            if (conBusCtaAho.idcuenta != 0)
            {
                llenarIntervinientes();
                tabControl1.Enabled = false;
            }
            
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            int idCli = conBusCli1.idCli;

            GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
            frmBusCuenCli.conBusCli.txtCodCli.Enabled = false;
            frmBusCuenCli.CargarDatos(idCli, "C", "[5]");
            frmBusCuenCli.ShowDialog();

            idSolicitud = Convert.ToInt32(frmBusCuenCli.idSolicitud);
            idCuenta = frmBusCuenCli.idCuenta == "" ? 0 : Convert.ToInt32(frmBusCuenCli.idCuenta);
            if (Convert.ToInt32(frmBusCuenCli.idSolicitud) != 0)
            {
                llenarIntervinientes();
                tabControl1.Enabled = false;
            }
        }
       

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol1.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int idGrupoSol = Convert.ToInt32(conBusGrupoSol1.txtIdGrupoSolidario.Text.ToString());
                frmBuscaSolicitudGrupoSol frmBuscaSol = new frmBuscaSolicitudGrupoSol(idGrupoSol);
                frmBuscaSol.ShowDialog();

                idSolicitud = frmBuscaSol.getSolicitudGrupoSolidario();
                if (idSolicitud != 0)
                {
                    llenarIntervinientes();
                    tabControl1.Enabled = false;
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                idModulo = 2;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                idModulo = 1;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                idModulo = 0;
            }
        }

        private void pnlExpandCollapse1_ExpandCollapse(object sender, ExpandCollapseEventArgs e)
        {
            if (pnlExpandCollapse2.IsExpanded)
            {
                pnlExpandCollapse2.ExpandCollapse -= pnlExpandCollapse2_ExpandCollapse;
                pnlExpandCollapse2.IsExpanded = false;
                pnlExpandCollapse2.ExpandCollapse += pnlExpandCollapse2_ExpandCollapse;
            }

            limpiarControles();

            lImpirmirConIntervinietes = false;
        }

        private void pnlExpandCollapse2_ExpandCollapse(object sender, ExpandCollapseEventArgs e)
        {
            if (pnlExpandCollapse1.IsExpanded)
            {
                pnlExpandCollapse1.ExpandCollapse -= pnlExpandCollapse1_ExpandCollapse;
                pnlExpandCollapse1.IsExpanded = false;
                pnlExpandCollapse1.ExpandCollapse += pnlExpandCollapse1_ExpandCollapse;
            }

            limpiarControles();

            lImpirmirConIntervinietes = true;
            tabControl1.SelectedIndex = (idModulo == 0 ? 2 : (idModulo == 1 ? 1: 0));
        }

        private void rdoAhorros_CheckedChanged(object sender, EventArgs e)
        {
            idModulo = 2;
            btnImprimir1.Enabled = true;
        }

        private void rdoCreditos_CheckedChanged(object sender, EventArgs e)
        {
            idModulo = 1;
            btnImprimir1.Enabled = true;
        }

        private void rdoGrupoSol_CheckedChanged(object sender, EventArgs e)
        {
            idModulo = 0;
            btnImprimir1.Enabled = true;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private Tuple<List<ReportDataSource>, List<ReportParameter>> prepararReporte()
        {
            string cCadenaEncriptada = encriptarCadena(idModulo + "-" + idSolicitud + "-" + clsVarGlobal.PerfilUsu.idPerfil + "-" + clsVarGlobal.PerfilUsu.idUsuario + "(" + DateTime.Now.ToString() + ")");
            int nNumeroImprsion = 0;
            DataTable dtRegistro = clsConfiguracion.guardarRegistroImpresion(idModulo, idSolicitud, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.PerfilUsu.idUsuario, cCadenaEncriptada);
            if (dtRegistro.Rows.Count > 0)
            {
                if (dtRegistro.Rows[0]["idRegistro"].ToString() == "0")
                {
                    MessageBox.Show(dtRegistro.Rows[0]["cMensaje"].ToString(), "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                else
                {
                    nNumeroImprsion = Convert.ToInt32(dtRegistro.Rows[0]["idRegistro"]);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error, intente de nuevo.", "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            DataTable dtVariable = clsConfiguracion.obtenerVariableConfiguracion();

            DataTable dtTmpInterv = new DataTable();

            string dFecha = "";
            if (lImpirmirConIntervinietes)
            {
                dtTmpInterv = clsConfiguracion.listarIntervinientesImprimir(idModulo, idSolicitud);
                mostrarNumeroImpresiones();
                DataTable dtFecha = clsConfiguracion.obtenerFechaCuenta(idModulo, idSolicitud);
                if (dtFecha.Rows.Count > 0)
                {
                    dFecha = "Lugar " + dtFecha.Rows[0]["cCiudad"] + " Fecha " + dtFecha.Rows[0]["nDia"] + " de " + dtFecha.Rows[0]["cMes"] + " del " + dtFecha.Rows[0]["nAnio"];
                }
            }
            else
            {
                dtTmpInterv = clsConfiguracion.retornaIntervinientesImprimirBlanco(dtVariable, idModulo);
                dFecha = "Lugar____________________Fecha____________de_______________del 202__";
            }

            DataTable dtIntervinientes = dtTmpInterv.Clone();
            DataTable dtFiadores = dtTmpInterv.Clone();

            if (idModulo == 1)
            {
                for (int i = 0; i < dtTmpInterv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtTmpInterv.Rows[i]["idTipoInterv"]) == 1)
                        dtIntervinientes.ImportRow(dtTmpInterv.Rows[i]);
                    else 
                        dtFiadores.ImportRow(dtTmpInterv.Rows[i]);
                }
            }
            else
            {
                dtIntervinientes = dtTmpInterv;
            }

            dtslist.Add(new ReportDataSource("dtIntervinientes", dtIntervinientes));
            dtslist.Add(new ReportDataSource("dtFiadores", dtFiadores));
            dtslist.Add(new ReportDataSource("dtTestigosRuego", clsConfiguracion.retornaTestigosRuego()));
            dtslist.Add(new ReportDataSource("dtVariables", dtVariable));

            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idModulo", idModulo.ToString(), false));
            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
            paramlist.Add(new ReportParameter("nCodigo", cCadenaEncriptada, false));
            paramlist.Add(new ReportParameter("nNumeroImpresion", nNumeroImprsion.ToString(), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha, false));

            return Tuple.Create(dtslist, paramlist);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            var datosReporte = this.prepararReporte();

            if (datosReporte == null)
            {
                return;
            }

            List<ReportDataSource> dtslist = datosReporte.Item1;
            List<ReportParameter> paramlist = datosReporte.Item2;
            string reportpath = "rptContratoFirmas.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }        

        private void frmImpresionContrato_Load(object sender, EventArgs e)
        {
            pnlExpandCollapse2.ExpandCollapse -= pnlExpandCollapse2_ExpandCollapse;
            pnlExpandCollapse2.IsExpanded = false;
            pnlExpandCollapse2.ExpandCollapse += pnlExpandCollapse2_ExpandCollapse;

            pnlNumImpresiones.Visible = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
        }

        public static byte[] concatenarPdfs(List<byte[]> lstPdfs)
        {
            List<PdfDocument> lstDocumentos = new List<PdfDocument>();
            foreach (var pdf in lstPdfs)
            {
                lstDocumentos.Add(PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.Import));
            }

            using (PdfDocument resultadoPdf = new PdfDocument())
            {
                for (int i = 0; i < lstDocumentos.Count; i++)
                {
                    foreach (PdfPage pagina in lstDocumentos[i].Pages)
                    {
                        resultadoPdf.AddPage(pagina);
                    }
                }

                MemoryStream stream = new MemoryStream();
                resultadoPdf.Save(stream, false);
                byte[] bytes = stream.ToArray();

                return bytes;
            }
        }

        private string obtenerNombrePlantilla()
        {
            switch (this.tabControl1.SelectedTab.Name)
            {
                case "tabAhorros": return "ContratoAhorros";
                case "tabCreditos": return "ContratoCreditos";
                case "tabGrupoSolidario": return "ContratoGrupal";
            }
            return "Ninguno";
        }

        private void enviarEmailsContrato(string cPrefijoContrato, byte[] bArchivo)
        {
            string cContratosSmtp = clsVarApl.dicVarGen["cContratosSmtp"];
            int nContratosSmtpPuerto = clsVarApl.dicVarGen["nContratosSmtpPuerto"];
            string cContratosEmailRemitente = clsVarApl.dicVarGen["cContratosEmailRemitente"];
            string cContratosEmailRemitenteClave = clsVarApl.dicVarGen["cContratosEmailRemitenteClave"];

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(cContratosEmailRemitente);

            foreach(string direccionEmail in listaEmails) {
                mail.To.Add(direccionEmail);  // se puede cambiar la rediccion realcon proposito de pruebas
            }

            mail.Subject = "Contrato Caja Rural de Ahorro y Crédito los Andes";
            mail.Body = "Estimado cliente,\n\nMediante el presente le enviamos una copia adjunta del contrato suscrito con nuestra institución.\n\nSaludos.";

            MemoryStream adjunto = new MemoryStream(bArchivo);

            string nombreAdjunto = cPrefijoContrato + "__" + DateTime.Now.Date.ToString("dd_MM_yyy") + ".pdf";

            mail.Attachments.Add(new Attachment(adjunto, nombreAdjunto, "application/pdf"));

            SmtpClient smtp = new SmtpClient(cContratosSmtp, nContratosSmtpPuerto);
            smtp.Credentials = new NetworkCredential(cContratosEmailRemitente, cContratosEmailRemitenteClave);

            smtp.Send(mail);
        }

        private void descargarCopiaContrato(string cPrefijoContrato, byte[] bArchivo)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = cPrefijoContrato + "__" + DateTime.Now.Date.ToString("dd_MM_yyy");
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF documents (.pdf)|*.pdf";

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create);
                fs.Write(bArchivo, 0, bArchivo.Length);
                fs.Flush();
                fs.Close();
            }
        }

        private void btnEmail1_Click(object sender, EventArgs e)
        {
            DialogResult lEnviarEmail = MessageBox.Show("¿Desea enviar un email con el contrato en formato PDF a el/los titular(es)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (lEnviarEmail == DialogResult.No)
            {
                return;
            }

            var datosReporte = this.prepararReporte();

            if (datosReporte == null)
            {
                return;
            }

            List<ReportDataSource> dtslist = datosReporte.Item1;
            List<ReportParameter> paramlist = datosReporte.Item2;
            string reportpath = "rptContratoFirmas.rdlc";

            string nombrePlantilla = obtenerNombrePlantilla();
            if (nombrePlantilla == "Ninguno")
            {
                MessageBox.Show("No se cuenta con plantilla para el tipo de contrato", "Envío de Contrato a Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDocumentoPlantilla = clsConfiguracion.obtenerDocumentoPlantilla(nombrePlantilla);
            if (dtDocumentoPlantilla.Rows.Count == 0)
            {
                MessageBox.Show("No se cuenta con plantilla para el tipo de contrato " + nombrePlantilla, "Envío de Contrato a Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /// Se obtiene plantilla de base de datos
            byte[] bDocumentoPlantillaBinario = (byte[])dtDocumentoPlantilla.Rows[0]["bBinario"];

            // Obtener numero dde paginas de plantilla
            PdfDocument documentoTemporal = PdfReader.Open(new MemoryStream(bDocumentoPlantillaBinario), PdfDocumentOpenMode.Import);
            int nNumeroPaginas = documentoTemporal.PageCount;

            // Obtener plantilla de firma
            frmReporteLocal bReporteFirma = new frmReporteLocal(dtslist, reportpath, paramlist, true, enuFormatoReporte.Pdf);
            var firmaBinario = bReporteFirma.obtenerBinario();

            // Documento contrato ha ser enviado
            byte[] bResultadoContrato = concatenarPdfs(new List<byte[]> { bDocumentoPlantillaBinario, firmaBinario });

            try
            {
                this.enviarEmailsContrato(nombrePlantilla, bResultadoContrato);
                MessageBox.Show("Se ha enviado correctamente el contrato al email.", "Envío de Contrato a Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error.\n\n"+ex.Message, "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

            /*Funcionalidad de descarga en PDF*/
            /*Se comenta código por si más adelante sea necesario*/
            /*DialogResult lDescargar = MessageBox.Show("¿Desea descargar una copia del contrato en formato PDF?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (lDescargar == DialogResult.Yes)
            {
                this.descargarCopiaContrato(nombrePlantilla, bResultadoContrato);
            }*/
        }
        #endregion
    }
}
