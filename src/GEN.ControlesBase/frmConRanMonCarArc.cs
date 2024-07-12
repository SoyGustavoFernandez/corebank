using CRE.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmConRanMonCarArc : frmBase
    {
        public clsConfigDocxMonto pDataConfiguracion;
        public bool lGuardado = false;
        public frmConRanMonCarArc()
        {
            InitializeComponent();
            this.Text = "Nuevo rango de montos";
            pDataConfiguracion = new clsConfigDocxMonto();
            this.txtDescripcionMonto.Text = string.Empty;
            this.txtMontoMinimo.Text = string.Empty;
            this.txtMontoMaximo.Text = string.Empty;
            this.pDataConfiguracion = new clsConfigDocxMonto();
            this.pDataConfiguracion.id = 0;
            this.lGuardado = false;
        }
        
        
        public frmConRanMonCarArc(clsConfigDocxMonto datasel)
        {
            InitializeComponent();
            this.Text = "Editar rango de montos";
            this.pDataConfiguracion = new   clsConfigDocxMonto();
            this.pDataConfiguracion.id = datasel.id;
            this.pDataConfiguracion.idPadre      =datasel.idPadre      ;
            this.pDataConfiguracion.lVisible     =datasel.lVisible     ;
            this.pDataConfiguracion.cDescripcion =datasel.cDescripcion ;
            this.pDataConfiguracion.lObligatorio =datasel.lObligatorio ;
            this.pDataConfiguracion.nMontoMinimo =datasel.nMontoMinimo ;
            this.pDataConfiguracion.nMontoMaximo =datasel.nMontoMaximo ;
        
            this.txtDescripcionMonto.Text = datasel.cDescripcion;
            this.txtMontoMinimo.Text = datasel.nMontoMinimo.ToString();
            this.txtMontoMaximo.Text = datasel.nMontoMaximo.ToString();
            this.lGuardado = false;
        }
        
        private void frmConRanMonCarArc_Load(object sender, EventArgs e)
        {

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de guardar la configuración?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.btnGrabar1.Enabled = false;
                this.txtMontoMaximo.ReadOnly = true;
                this.txtMontoMinimo.ReadOnly = true;
                this.txtDescripcionMonto.ReadOnly = true;

                clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
                pDataConfiguracion.nMontoMaximo = txtMontoMaximo.nDecValor;
                pDataConfiguracion.nMontoMinimo = txtMontoMinimo.nDecValor;
                pDataConfiguracion.cDescripcion = txtDescripcionMonto.Text;

                clsDBResp dtRes = clsConfiguracion.CNGuardarConfigMonto(pDataConfiguracion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date
                    );
                if (dtRes.nMsje == 0)
                {
                    pDataConfiguracion.id = dtRes.idGenerado;
                    MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lGuardado = true;
                }
                else
                {
                    MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGrabar1.Enabled = true;

                    this.txtMontoMaximo.ReadOnly = false;
                    this.txtMontoMinimo.ReadOnly = false;
                    this.txtDescripcionMonto.ReadOnly = false;
                }
            }

        }
    }
}
