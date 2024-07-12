using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.ControlesBase.Model; 
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GEN.ControlesBase
{
    public partial class frmRptAutUsoDatoClienteBase : frmBase
    {
        AutorizaTratamientoUsoDatos[] lstData;
        int nMaxDiasBusqueda = 15;
        public frmRptAutUsoDatoClienteBase()
        {
            InitializeComponent();
        }

        private async void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
               
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((dtpFecFin.Value - dtpFecInicio.Value).Days > nMaxDiasBusqueda - 1)
            {
                MessageBox.Show("El rango entre las fechas de búsqueda inicial y final solo puede ser en un máximos de " + nMaxDiasBusqueda + " Días.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
         
            this.cprogressbar.Visible = true;
            this.btnImprimir1.Enabled = false;
            string Uri =  clsVarApl.dicVarGen["CRUTAAUTUSODATOS"]+ "ReporteAutorizacion";
            //Creamos el listado de Posts a llenar
            FiltroReporteAutorizacion data = new FiltroReporteAutorizacion();
            
            data.idTipoAutorizacion = Convert.ToInt32(cboTipoAutorizacion1.SelectedValue );    
            data.idOficina          = Convert.ToInt32(cboAgencias1.SelectedValue          );
            data.idRegion           = Convert.ToInt32(cboZona1.SelectedValue             );
            data.idEstado           = Convert.ToInt32(cboEstadoAutUsoDatos1.SelectedValue);
            data.dFecInicio         = dtpFecInicio.Value;
            data.dFecFin            = dtpFecFin.Value;

            clsCNTipAutUsoDatos objCNTraDatos = new clsCNTipAutUsoDatos(); 
            XmlSerializer xsSubmit = new XmlSerializer(typeof(FiltroReporteAutorizacion));

            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data);
                    xml = sww.ToString(); // Your XML
                }
            }

            var dataResp = objCNTraDatos.ListarReporteAutTratamientoUsoDatos(xml);

            //Instanciamos un objeto Reply
            //clsApiRespuesta oRespuesta = new clsApiRespuesta();
            ////poblamos el objeto con el método generic Execute
            //oRespuesta = await clsApiConsumer.Execute<RespLisAutorizacionTraDatos>(Uri, methodHttp.POST, data);

            //if (oRespuesta.StatusCode == "OK")
            //{
                //Poblamos el datagridview
                //RespLisAutorizacionTraDatos respuesta = (RespLisAutorizacionTraDatos)oRespuesta.Data;
                //lstData = respuesta.LisAutorizacion;
           if (dataResp.Rows.Count > 0)
                {

                    this.cprogressbar.Visible = false;
                    this.btnImprimir1.Enabled = true;
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsDatoAutoCliente", dataResp));

                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                    string reportPath = "rptAutUsoDatosCli.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {

                    this.cprogressbar.Visible = false;
                    this.btnImprimir1.Enabled = true;
                    MessageBox.Show("No existe datos para los parámetros seleccionados.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}

                    }

        private void frmRptAutUsoDatoCliente_Load(object sender, EventArgs e)
        {
            cboZona1.AgregarTodos(); 
            cboTipoAutorizacion1.filtroTodosAutorizaciones();
            cboEstadoAutUsoDatos1.filtrarEstadoTodos();

            cboTipoAutorizacion1.SelectedValue = 0;
            cboZona1.SelectedValue = 0;
            cboEstadoAutUsoDatos1.SelectedValue = 0;
            cboAgencias1.SelectedValue = 0;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.MaxDate = clsVarGlobal.dFecSystem.Date;
            dtpFecInicio.MaxDate = clsVarGlobal.dFecSystem.Date;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZona = Convert.ToInt32(cboZona1.SelectedValue);
            cboAgencias1.FiltrarPorZonaTodos(idZona);
        }
    }
}
