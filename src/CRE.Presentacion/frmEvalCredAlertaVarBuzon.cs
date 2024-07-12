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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmEvalCredAlertaVarBuzon : frmBase
    {
        #region Variables Globales
        private clsCNAlertaVariable objCNAlertaVariable;
        private clsEvalCredAlertaBuzon objEvalCredAlertaBuzon;

        private List<clsEvalCredAlertaVarResumen> lstAlertaNuevo;
        private List<clsEvalCredAlertaVarResumen> lstAlertaAtencion;
        private List<clsEvalCredAlertaVarResumen> lstAlertaReconsideracion;

        private List<clsEvalCredAlertaVarResumen> lstAlertaBusqueda;

        public clsEvalCredAlertaVarResumen objEvalCredAlertaVarResumen;

        private enum Tab : int { Nuevo = 0, Atencion = 1, Reconsideracion = 2, Busqueda = 3 }
        private Tab idTab;
        private int nIndice;
        #endregion
        public frmEvalCredAlertaVarBuzon()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNAlertaVariable = new clsCNAlertaVariable();
            this.objEvalCredAlertaBuzon = new clsEvalCredAlertaBuzon();

            this.lstAlertaNuevo = new List<clsEvalCredAlertaVarResumen>();
            this.lstAlertaAtencion = new List<clsEvalCredAlertaVarResumen>();
            this.lstAlertaReconsideracion = new List<clsEvalCredAlertaVarResumen>();

            this.lstAlertaBusqueda = new List<clsEvalCredAlertaVarResumen>();

            this.bsAlertaNuevo.DataSource = this.lstAlertaNuevo;
            this.bsAlertasAtencion.DataSource = this.lstAlertaAtencion;
            this.bsAlertasReconsideracion.DataSource = this.lstAlertaReconsideracion;

            this.bsAlertasBusqueda.DataSource = this.lstAlertaBusqueda;
            

            this.nIndice = -1;
            this.idTab = Tab.Nuevo;
            this.btnRevisar.Visible = false;
        }
        private void listarEvalCredAlertaResumen()
        {

            this.dtgNuevo.SelectionChanged -= dtgNuevo_SelectionChanged;
            this.dtgAtencion.SelectionChanged -= dtgAtencion_SelectionChanged;
            this.dtgReconsideracion.SelectionChanged -= dtgReconsideracion_SelectionChanged;

            this.objEvalCredAlertaBuzon = this.objCNAlertaVariable.listarEvalCredAlertaResumen();

            this.lstAlertaNuevo.Clear();
            this.lstAlertaNuevo.AddRange(this.objEvalCredAlertaBuzon.lstNuevo);
            this.bsAlertaNuevo.ResetBindings(false);
            this.dtgNuevo.Refresh();
            this.dtgNuevo.ClearSelection();

            this.lstAlertaAtencion.Clear();
            this.lstAlertaAtencion.AddRange(this.objEvalCredAlertaBuzon.lstAtencion);
            this.bsAlertasAtencion.ResetBindings(false);
            this.dtgAtencion.Refresh();
            this.dtgAtencion.ClearSelection();

            this.lstAlertaReconsideracion.Clear();
            this.lstAlertaReconsideracion.AddRange(this.objEvalCredAlertaBuzon.lstReconsideracion);
            this.bsAlertasReconsideracion.ResetBindings(false);
            this.dtgReconsideracion.Refresh();
            this.dtgReconsideracion.ClearSelection();

            if (this.lstAlertaNuevo.Count > 0)
            {
                this.btnRevisar.Visible = true;
            }
            else
            {
                this.btnRevisar.Visible = false;
            }

            this.dtgNuevo.SelectionChanged += dtgNuevo_SelectionChanged;
            this.dtgAtencion.SelectionChanged += dtgAtencion_SelectionChanged;
            this.dtgReconsideracion.SelectionChanged += dtgReconsideracion_SelectionChanged;
        }
        private void buscarEvalCredAlertas()
        {
            if (this.cboTipoBusqueda.SelectedIndex < 0) return;

            int nValorBusqueda;

            if (!Int32.TryParse(this.txtValorBusqueda.Text, out nValorBusqueda))
            {
                MessageBox.Show("¡El valor de la búsqueda debe ser un número entero!", "VALOR DE BUSQUEDA INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtValorBusqueda.Select();
                return;
            }

            int idTipoBusqueda = this.cboTipoBusqueda.SelectedIndex;

            this.dtgEncontrados.SelectionChanged -= dtgEncontrados_SelectionChanged;

            int idSolicitud;
            int idCliente;

            if (idTipoBusqueda == 0)
            {
                idSolicitud = nValorBusqueda;
                idCliente = 0;
            }
            else
            {
                idSolicitud = 0;
                idCliente = nValorBusqueda;
            }

            this.lstAlertaBusqueda.Clear();
            this.lstAlertaBusqueda.AddRange(this.objCNAlertaVariable.buscarEvalCredAlertas(idSolicitud,idCliente));
            this.bsAlertasBusqueda.ResetBindings(false);
            this.dtgEncontrados.Refresh();
            this.dtgEncontrados.ClearSelection();

            if (this.lstAlertaBusqueda.Count > 0)
            {
                this.btnRevisar.Visible = true;
                this.txtValorBusqueda.Text = "0";
            }
            else
            {
                MessageBox.Show("¡No se han encontrado datos para visualizar!","RESULTADO VACIO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnRevisar.Visible = false;
                this.txtValorBusqueda.Select();
            }
            
            this.dtgEncontrados.SelectionChanged += dtgEncontrados_SelectionChanged;
        }
        #endregion
        #region Eventos
        private void frmEvalCredAlertaVarBuzon_Shown(object sender, EventArgs e)
        {
            this.listarEvalCredAlertaResumen();
            this.cboTipoBusqueda.SelectedIndex = 0;
        }
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (this.nIndice < 0)
            {
                MessageBox.Show("¡Seleccione un ítem para revisar!", "ITEM NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (this.idTab)
            {
                case Tab.Nuevo:
                    this.objEvalCredAlertaVarResumen = this.lstAlertaNuevo[this.nIndice];
                    break;
                case Tab.Atencion:
                    this.objEvalCredAlertaVarResumen = this.lstAlertaAtencion[this.nIndice];
                    break;
                case Tab.Reconsideracion:
                    this.objEvalCredAlertaVarResumen = this.lstAlertaReconsideracion[this.nIndice];
                    break;
                case Tab.Busqueda:
                    this.objEvalCredAlertaVarResumen = this.lstAlertaBusqueda[this.nIndice];
                    break;
            }
            this.Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.objEvalCredAlertaVarResumen = null;
            this.Close();
        }

        private void tbcEvalCredAlerta_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idTab = (Tab)this.tbcEvalCredAlerta.SelectedIndex;

            this.btnRevisar.Visible = false;
            switch (this.idTab)
            {
                case Tab.Nuevo:
                    this.btnRevisar.Visible = (this.lstAlertaNuevo.Count > 0);
                    break;
                case Tab.Atencion:
                    this.btnRevisar.Visible = (this.lstAlertaAtencion.Count > 0);
                    break;
                case Tab.Reconsideracion:
                    this.btnRevisar.Visible = (this.lstAlertaReconsideracion.Count > 0);
                    break;
                case Tab.Busqueda:
                    this.btnRevisar.Visible = (this.lstAlertaBusqueda.Count > 0);
                    break;
            }
        }

        private void dtgNuevo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgNuevo.SelectedRows.Count == 0) return;
            this.nIndice = this.dtgNuevo.SelectedRows[0].Index;
        }

        private void dtgAtencion_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAtencion.SelectedRows.Count == 0) return;
            this.nIndice = this.dtgAtencion.SelectedRows[0].Index;
        }

        private void dtgReconsideracion_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgReconsideracion.SelectedRows.Count == 0) return;
            this.nIndice = this.dtgReconsideracion.SelectedRows[0].Index;
        }

        private void dtgEncontrados_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgEncontrados.SelectedRows.Count == 0) return;
            this.nIndice = this.dtgEncontrados.SelectedRows[0].Index;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            this.buscarEvalCredAlertas();
        }

        private void txtValorBusqueda_Enter(object sender, EventArgs e)
        {
            this.txtValorBusqueda.Select();
        }

        private void txtValorBusqueda_Click(object sender, EventArgs e)
        {
            this.txtValorBusqueda.Select(0, this.txtValorBusqueda.TextLength);
        }
        #endregion
    }
}
