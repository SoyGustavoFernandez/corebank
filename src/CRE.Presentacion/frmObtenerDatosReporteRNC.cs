using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using System.Collections;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmObtenerDatosReporteRNC : frmBase
    {
        #region VariablesGlobales
        int idSoli = 0;
        int idRNC = 0;
        string cActividadPrincial = "";
        string cActividadSecundaria = "";
        string cInicial = "";
        string cDatosAval = "";
        string cCuotaNuevoCred = "";
        string cUtilidad = "";
        string cSuste = "";
        string cDesDestino = "";

        string cTituloMsjes = "Obtener Datos de Reporte de RNC.";
        clsCNSolicitud nSoliDatos = new clsCNSolicitud();
        private DataTable dtSolicitud;
        public int idDatosCompletos=0;
        public string cSustento;
        #endregion

        #region Eventos
        public frmObtenerDatosReporteRNC()
        {
            InitializeComponent();
        }
        public frmObtenerDatosReporteRNC(int idSolicitud,int idReglaNoContemplada)
        {
            idSoli = idSolicitud;
            idRNC = idReglaNoContemplada;
            InitializeComponent();
            BucarDatos();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            AsignarDatos();
            if (cActividadPrincial == "" || cActividadSecundaria == "" || cInicial == "" || cDatosAval == "" || cCuotaNuevoCred == "" || cUtilidad == "" || cSuste == "" || cDesDestino == "")
            {
                MessageBox.Show("Debe completar todos los campos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Grabar();
            }

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarTxt(2);
            this.btnGrabar1.Enabled = true;
            this.btnEditar1.Enabled = false;
            this.btnSalir1.Enabled = false;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            BucarDatos();
            if (dtSolicitud.Rows.Count > 0)
            {
                string cSustSalir = Convert.ToString(this.dtSolicitud.Rows[0]["cSustento"]);
                cSustento = cSustSalir;
            }
        }
        #endregion

        #region metodos
        private void AsignarDatos()
        {
            cActividadPrincial = this.txtBase0.Text;
            cActividadSecundaria = this.txtBase1.Text;
            cInicial = this.txtBase2.Text;
            cDatosAval = this.txtBase3.Text;
            cCuotaNuevoCred = this.txtBase4.Text;
            cUtilidad = this.txtBase5.Text;
            cSuste = this.txtSustento.Text;
            cDesDestino = this.txtBase6.Text;

        }
        private void Grabar()
        {
            clsDBResp objDbResp = new clsCNSolicitud().CNDatosReporteRNC(idSoli, cActividadPrincial, cActividadSecundaria, cInicial, cDatosAval, cCuotaNuevoCred, cUtilidad, cSuste,cDesDestino,idRNC);

            if (objDbResp.nMsje == 0)
            {

                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD
                habilitarTxt(1);
                cSustento = cSuste;
                this.btnGrabar1.Enabled = false;
                this.btnEditar1.Enabled = true;
                this.btnSalir1.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
            }

        }
        private void BucarDatos()
        {
            //DataTable dtResultado = (new clsCNSolicitud()).obtenerDatosReporteRNC(this.idSoli);
            dtSolicitud = nSoliDatos.obtenerDatosReporteRNC(idSoli,idRNC);
            if (dtSolicitud.Rows.Count > 0)
            {
                habilitarTxt(1);
                this.txtBase0.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cActividadPrin"]);
                this.txtBase1.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cActividadSec"]);
                this.txtBase2.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cInicial"]);
                this.txtBase3.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cDatosAval"]);
                this.txtBase4.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cCuotaNuevoCred"]);
                this.txtBase5.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cUtilidad"]);
                this.txtSustento.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cSustento"]);
                this.txtBase6.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cDestino"]);
                this.btnGrabar1.Enabled = false;//cambiar a true dependede RMOLINA
            }
            else
            {
                habilitarTxt(2);
                this.btnGrabar1.Enabled = true;
                this.btnEditar1.Enabled = false;
            }

        }
        private void habilitarTxt(int idEstado)
        {
            if (idEstado == 1) // deshabilitado
            {
                this.txtBase0.Enabled = false;
                this.txtBase1.Enabled = false;
                this.txtBase2.Enabled = false;
                this.txtBase3.Enabled = false;
                this.txtBase4.Enabled = false;
                this.txtBase5.Enabled = false;
                this.txtBase6.Enabled = false;
                this.txtSustento.Enabled = false;
            }
            else if (idEstado == 2) // habilitado
            {
                this.txtBase0.Enabled = true;
                this.txtBase1.Enabled = true;
                this.txtBase2.Enabled = true;
                this.txtBase3.Enabled = true;
                this.txtBase4.Enabled = true;
                this.txtBase5.Enabled = true;
                this.txtBase6.Enabled = true;
                this.txtSustento.Enabled = true;
            }
        }

        #endregion



    }
}
