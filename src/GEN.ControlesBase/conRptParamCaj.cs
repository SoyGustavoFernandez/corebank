using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    enum ePerfilesRestriccion 
    {
        JEFE_OFICINA = 85,
        SUPERVISOR_OPERACIONES_SERV = 93
    }

    public partial class conRptParamCaj : UserControl
    {
        public event EventHandler continuar;
        public clsCNControlLimitesBoveda oBD;
        private DataSet dsAgenciasEOBs;

        public conRptParamCaj()
        {
            InitializeComponent();
        }

        #region Metodos
        void configurarRestriccion()
        {
            try 
            {
                if (Convert.ToInt16(clsVarApl.dicVarGen["lRestringirAccesoPerfilesRCLB"]) == 1)
                {
                    if (
                    clsVarGlobal.PerfilUsu.idPerfil == (int)ePerfilesRestriccion.JEFE_OFICINA ||
                    clsVarGlobal.PerfilUsu.idPerfil == (int)ePerfilesRestriccion.SUPERVISOR_OPERACIONES_SERV)
                    {
                        var dsResults = this.oBD.listaAgenciasEOBs(clsVarGlobal.PerfilUsu.idUsuario);
                        if (clsVarGlobal.PerfilUsu.idPerfil == (int)ePerfilesRestriccion.JEFE_OFICINA)
                        {
                            if (dsResults.Tables[2].Rows.Count > 0)
                            {
                                this.cboZona1.SelectedValue = Convert.ToInt32(dsResults.Tables[2].Rows[0]["idZona"]);
                                this.cboZona1.Enabled = false;
                                this.cboAgencia1.SelectedValue = clsVarGlobal.nIdAgencia;
                                this.cboAgencia1.Enabled = false;
                            }
                        }
                        if (clsVarGlobal.PerfilUsu.idPerfil == (int)ePerfilesRestriccion.SUPERVISOR_OPERACIONES_SERV)
                        {
                            if (dsResults.Tables[2].Rows.Count > 0)
                            {
                                this.cboZona1.SelectedValue = Convert.ToInt32(dsResults.Tables[2].Rows[0]["idZona"]);
                                this.cboZona1.Enabled = false;
                            }
                        }
                    }
                }
            } catch(Exception)
            {
                MessageBox.Show("Ocurrió un error al seleccionar las regiones y agencias");
            }
        }
        void configurarAgencias(DataTable dtAgencias)
        {
            this.cboAgencia1.DataSource = dtAgencias;
            this.cboAgencia1.ValueMember = "idAgencia";
            this.cboAgencia1.DisplayMember = "cNombreAge";
        }
        void configurarEstablecimientos(DataTable dtEstabl)
        {
            this.cboEstablecimiento1.DataSource = dtEstabl;
            this.cboEstablecimiento1.ValueMember = "idEstablecimiento";
            this.cboEstablecimiento1.DisplayMember = "cNombreEstab";
        }
        Boolean validar()
        {
            if (this.cboAgencia1.SelectedValue == null)
            {
                return false;
            }
            if (this.dtpIni.Value == null)
            {
                return false;
            }
            if (this.dtpFin.Value == null)
            {
                return false;
            }
            return true;
        }
        public void cargarFormulario()
        {
            this.dtpIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFin.Value = clsVarGlobal.dFecSystem;
            this.cboZona1.cargarZona(true, false);
            this.cboZona1.SelectedValueChanged += new EventHandler(this.cboZona1_SelectedValueChanged);

            this.oBD = new clsCNControlLimitesBoveda();
            this.dsAgenciasEOBs = this.oBD.listaAgenciasEOBs(clsVarGlobal.PerfilUsu.idUsuario);
            this.configurarAgencias(this.dsAgenciasEOBs.Tables[0]);
            this.cboAgencia1.SelectedValueChanged += new EventHandler(this.cboAgencia1_SelectedValueChanged);

            this.configurarRestriccion();
        }
        #endregion Metodos

        #region Eventos
        
        private void cboAgencia1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboAgencia1.SelectedValue != null && this.cboAgencia1.SelectedValue != DBNull.Value)
            {
                this.cboEstablecimiento1.CargarEstablecimientos(
                    Convert.ToInt32(this.cboAgencia1.SelectedValue)
                    );
            }
        }

        private void cboZona1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboZona1.SelectedValue != null)
            {
                this.cboAgencia1.SelectedValue = 0;
                if (Convert.ToInt32(this.cboZona1.SelectedValue) == 0)
                {
                    this.configurarAgencias(this.dsAgenciasEOBs.Tables[0]);
                }
                else
                {
                    var dtAgencias = this.dsAgenciasEOBs.Tables[0].Select("idZona = " + this.cboZona1.SelectedValue.ToString()).CopyToDataTable();
                    dtAgencias.ImportRow(this.dsAgenciasEOBs.Tables[0].Rows[0]);
                    dtAgencias = dtAgencias.AsEnumerable().OrderBy(x => x.Field<Int32>("idAgencia")).CopyToDataTable();
                    this.configurarAgencias(dtAgencias);
                }
            }
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if (this.validar())
            {
                if (this.continuar != null)
                    this.continuar(this, e);
            }
        }
        #endregion Eventos

    }
}
