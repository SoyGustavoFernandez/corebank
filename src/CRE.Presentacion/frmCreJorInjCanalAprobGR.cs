#region referencias
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
using GEN.BotonesBase;
using GEN.CapaNegocio;
using EntityLayer;
#endregion


namespace CRE.Presentacion
{
    /***
     * 
     * CANAL DE APROBACION DE GERENTE REGIONAL
     * PARA CREDITO JORNALERO
     * 
     ***/

    public partial class frmCreJorInjCanalAprobGR : frmBase
    {
        #region variables
        public int idSolicitud = -1;
        public int idRegla = -1;
        public int idReglaNoContemplada = -1;
        public btnAprobar btnAprobar;
        public btnDenegar btnDenegar;
        public lblBase lblJefeCred;
        public lblBase lblGNegocios;
        public Button btnJefeCred;
        #endregion
        #region Constructor
        public frmCreJorInjCanalAprobGR(
            int idSolicitud,
            int idRegla,
            int idReglaNoContemplada,
            ref btnAprobar btnAprobar,
            ref btnDenegar btnDenegar,
            ref lblBase lblJefeCred,
            ref lblBase lblGNegocios,
            ref Button btnJefeCred,
            ref Button btnGNegocios
            )
        {
            InitializeComponent();
            string listaReglas = Convert.ToString(clsVarApl.dicVarGen["listaReglasCanalGR"]);
            int idPerfilGerReg = Convert.ToInt32(clsVarApl.dicVarGen["idPerfilGerenteRegional"]);
            if (listaReglas.Split(',').Contains(idRegla.ToString()))
            {
                if (clsVarGlobal.PerfilUsu.idPerfil == idPerfilGerReg)
                {
                    this.idReglaNoContemplada = idReglaNoContemplada;
                    this.btnAprobar = btnAprobar;
                    this.btnDenegar = btnDenegar;
                    this.btnAprobar.Click += new System.EventHandler(this.aprobar);
                    this.btnDenegar.Click += new System.EventHandler(this.denegar);
                }
                int idPerfilAsesor = Convert.ToInt32(clsVarApl.dicVarGen["nIdPerfilAsesorNegocios"]);
                if (clsVarGlobal.PerfilUsu.idPerfil == idPerfilAsesor)
                {
                    lblJefeCred.Visible = false;
                    lblGNegocios.Visible = false;
                    btnJefeCred.Visible = false;
                    btnGNegocios.Visible = false;
                }
            }
            else
            {
                lblJefeCred.Visible = true;
                lblGNegocios.Visible = true;
                btnJefeCred.Visible = true;
                btnGNegocios.Visible = true;
            }
        }
        #endregion
        #region Metodos
        public void aprobar(object sender, EventArgs e)
        {
            clsDBResp objDbResp = new clsCNSolicitud().CNAprobacionesSolicitudRNC(
                this.idReglaNoContemplada, 
                "Aprobado por canal de Gerente Regional", 
                5, 
                1, 
                clsVarGlobal.User.idUsuario);
        }
        public void denegar(object sender, EventArgs e)
        {
            clsDBResp objDbResp = new clsCNSolicitud().CNAprobacionesSolicitudRNC(
                this.idReglaNoContemplada, 
                "Anulado por canal de Gerente Regional", 
                5, 
                0,
                clsVarGlobal.User.idUsuario);
        }
        #endregion
    }
}
