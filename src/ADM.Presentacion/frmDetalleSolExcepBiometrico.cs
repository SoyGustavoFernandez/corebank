#region REferencias
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
using EntityLayer;
using CLI.Servicio;
using ADM.CapaNegocio;
using GEN.Funciones;
#endregion



namespace ADM.Presentacion
{
    public partial class frmDetalleSolExcepBiometrico : frmBase
    {
        #region Variables Globales

        private clsCNBiometriaExcepcion objCNBiometriaExcepcion { get; set; }
        private  clsBiometriaExcep objBiometriaExcep { get; set; }
        private List<clsAprobaSolici> lstAprobaSolic { get; set; }
        private BindingSource bsAprobadorSolicitud { get; set; }

        #endregion

        #region Constructores
        public frmDetalleSolExcepBiometrico()
        {
            InitializeComponent();
        }
        public frmDetalleSolExcepBiometrico(clsBiometriaExcep _objBiometriaExcep)
        {
            InitializeComponent();

            cargarComponentes(_objBiometriaExcep);
        }
        #endregion

        #region Eventos

        private void frmDetalleSolExcepBiometrico_Load(object sender, EventArgs e)
        {
            formatearAprobadoresSolicitud();
            cargarDatosSolicitudExcepcionBiometrica();
        }

        private void btnArchivoAdjunto_Click(object sender, EventArgs e)
        {
            
            DataTable dtDetalleArchivo = objCNBiometriaExcepcion.CNObtenerDetalleArchivoExcepBiometrica(this.objBiometriaExcep.idBiometriaExcep);

            if(dtDetalleArchivo.Rows.Count == 0)
            {
                MessageBox.Show("No se puede mostrar el archivo adjunto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrWhiteSpace(Convert.ToString(dtDetalleArchivo.Rows[0]["cNombreArchivo"])))
            {
                MessageBox.Show("La solicitud de excepción no tiene archivo adjunto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.objBiometriaExcep.bArchivo = (byte[])dtDetalleArchivo.Rows[0]["bArchivo"];
            this.objBiometriaExcep.cExtencion = Convert.ToString(dtDetalleArchivo.Rows[0]["cExtencion"]);
            this.objBiometriaExcep.cNombreArchivo = Convert.ToString(dtDetalleArchivo.Rows[0]["cNombreArchivo"]);
            this.objBiometriaExcep.idTipoArchivo = Convert.ToInt32(dtDetalleArchivo.Rows[0]["idTipoArchivo"]);

            if(this.objBiometriaExcep.idTipoArchivo == 1)
            {
                frmMostrarImagen frmImagen = new frmMostrarImagen(this.objBiometriaExcep.cNombreArchivo, this.objBiometriaExcep.cExtencion, Compresion.DescompressedByte(this.objBiometriaExcep.bArchivo));
                frmImagen.ShowDialog();
            }
            else
            {
                frmDisplayPDF oFrm = new frmDisplayPDF(this.objBiometriaExcep.cNombreArchivo, this.objBiometriaExcep.cExtencion, Compresion.DescompressedByte(this.objBiometriaExcep.bArchivo));
                oFrm.ShowDialog();
            }
            

            
        }

        private void dtgAprobadores_SelectionChanged(object sender, EventArgs e)
        {
            this.dtgAprobadores.ClearSelection();
        }
        #endregion

        #region Metodos

        public void cargarComponentes(clsBiometriaExcep _objBiometriaExcep)
        {
            objCNBiometriaExcepcion = new clsCNBiometriaExcepcion();
            objBiometriaExcep = _objBiometriaExcep;
            bsAprobadorSolicitud = new BindingSource();
            lstAprobaSolic = new List<clsAprobaSolici>();
            bsAprobadorSolicitud.DataSource = lstAprobaSolic;
            dtgAprobadores.DataSource = bsAprobadorSolicitud;
        }

        private void formatearAprobadoresSolicitud()
        {
            dtgAprobadores.ReadOnly = false;
            dtgAprobadores.CellBorderStyle = DataGridViewCellBorderStyle.Raised;


            foreach (DataGridViewColumn dgvColumna in dtgAprobadores.Columns)
            {
                dgvColumna.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.ReadOnly = true;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }


            dtgAprobadores.Columns["nOrdenAprobacion"].Visible      = true;
            dtgAprobadores.Columns["idUsuarioEmiOpi"].Visible       = true;
            dtgAprobadores.Columns["cOpinion"].Visible              = true;
            dtgAprobadores.Columns["dFecHoraEmiOpi"].Visible        = true;
            dtgAprobadores.Columns["cNivelAproba"].Visible          = true;
            dtgAprobadores.Columns["cEstadoSol"].Visible            = true;
            dtgAprobadores.Columns["cWinUser"].Visible              = true;
            dtgAprobadores.Columns["cNombreUsuario"].Visible        = true;
            dtgAprobadores.Columns["cAgenciaEmiteOpinion"].Visible  = true;
            dtgAprobadores.Columns["cPerfilEmiteOpinion"].Visible   = true;
            dtgAprobadores.Columns["cCargoEmiteOpinion"].Visible    = true;

            dtgAprobadores.Columns["nOrdenAprobacion"].HeaderText      = "Orden Aprobación";
            dtgAprobadores.Columns["idUsuarioEmiOpi"].HeaderText       = "Cod. Usuario";
            dtgAprobadores.Columns["cOpinion"].HeaderText              = "Opinión";
            dtgAprobadores.Columns["dFecHoraEmiOpi"].HeaderText        = "Fecha Hora Opinión";
            dtgAprobadores.Columns["cNivelAproba"].HeaderText          = "Nivel Aprobación";
            dtgAprobadores.Columns["cEstadoSol"].HeaderText            = "Estado Aprobación";
            dtgAprobadores.Columns["cWinUser"].HeaderText              = "Usuario";
            dtgAprobadores.Columns["cNombreUsuario"].HeaderText        = "Nombre Usuario";
            dtgAprobadores.Columns["cAgenciaEmiteOpinion"].HeaderText  = "Agencia";
            dtgAprobadores.Columns["cPerfilEmiteOpinion"].HeaderText   = "Perfil";
            dtgAprobadores.Columns["cCargoEmiteOpinion"].HeaderText    = "Cargo";

            dtgAprobadores.Columns["cAgenciaEmiteOpinion"].DisplayIndex     = 0;
            dtgAprobadores.Columns["idUsuarioEmiOpi"].DisplayIndex          = 1;
            dtgAprobadores.Columns["cNivelAproba"].DisplayIndex             = 2;
            dtgAprobadores.Columns["cWinUser"].DisplayIndex                 = 3;
            dtgAprobadores.Columns["cNombreUsuario"].DisplayIndex           = 4;
            dtgAprobadores.Columns["cEstadoSol"].DisplayIndex               = 5;
            dtgAprobadores.Columns["dFecHoraEmiOpi"].DisplayIndex           = 6;
            dtgAprobadores.Columns["cPerfilEmiteOpinion"].DisplayIndex      = 7;
            dtgAprobadores.Columns["cCargoEmiteOpinion"].DisplayIndex       = 8;
            dtgAprobadores.Columns["nOrdenAprobacion"].DisplayIndex         = 9;
            dtgAprobadores.Columns["cOpinion"].DisplayIndex                 = 10;

            dtgAprobadores.Columns["idAprobadorSol"].DisplayIndex           = 11;
            dtgAprobadores.Columns["idSolAproba"].DisplayIndex              = 12;
            dtgAprobadores.Columns["idNivelAprRanOpe"].DisplayIndex         = 13;
            dtgAprobadores.Columns["idEstado"].DisplayIndex                 = 14;
            dtgAprobadores.Columns["idAgeUsuEmiOpi"].DisplayIndex           = 15;
            dtgAprobadores.Columns["idPerfilEmiOpi"].DisplayIndex           = 16;
            dtgAprobadores.Columns["idCargoEmiOpi"].DisplayIndex            = 17;
            dtgAprobadores.Columns["dFechaEmiOpi"].DisplayIndex             = 18;
            dtgAprobadores.Columns["lSoloComent"].DisplayIndex              = 19;

            dtgAprobadores.Columns["cAgenciaEmiteOpinion"].Width            = 150;
            dtgAprobadores.Columns["idUsuarioEmiOpi"].Width                 = 100;
            dtgAprobadores.Columns["cNivelAproba"].Width                    = 150;
            dtgAprobadores.Columns["cWinUser"].Width                        = 100;
            dtgAprobadores.Columns["cNombreUsuario"].Width                  = 250;
            dtgAprobadores.Columns["cEstadoSol"].Width                      = 150;
            dtgAprobadores.Columns["dFecHoraEmiOpi"].Width                  = 150;
            dtgAprobadores.Columns["cPerfilEmiteOpinion"].Width             = 200;
            dtgAprobadores.Columns["cCargoEmiteOpinion"].Width              = 200;
            dtgAprobadores.Columns["nOrdenAprobacion"].Width                = 100;
            dtgAprobadores.Columns["cOpinion"].Width                        = 300;

        }

        private void identificarEstadoExcepcion()
        {
            foreach (DataGridViewRow drgvRegistro in dtgAprobadores.Rows)
            {
                clsAprobaSolici objAprobaSolici = (clsAprobaSolici)drgvRegistro.DataBoundItem;
                if (objAprobaSolici.idEstado == 1)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.PowderBlue;
                else if (objAprobaSolici.idEstado == 2)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.PaleGreen;
                else if (objAprobaSolici.idEstado == 4)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        public void cargarDatosSolicitudExcepcionBiometrica()
        {
            txtBiometriaExcep.Text      = Convert.ToString(objBiometriaExcep.idBiometriaExcep);
            txtCliente.Text             = Convert.ToString(objBiometriaExcep.idCli);
            txtDocumentoID.Text         = objBiometriaExcep.cDocumentoID;
            txtNombreCliente.Text       = objBiometriaExcep.cNombres;

            txtFechaRegistro.Text       = Convert.ToString(objBiometriaExcep.dFechaReg);
            txtAgencia.Text             = objBiometriaExcep.cAgencia;
            txtEstablecimiento.Text     = objBiometriaExcep.cEstablecimiento;

            txtUsuario.Text             = objBiometriaExcep.cNombreUsuarioReg;
            txtWinUsuario.Text          = objBiometriaExcep.cWinUserReg;
            txtMotivo.Text              = objBiometriaExcep.cMotivoBiometriaExcep;
            txtDetalleExcepcion.Text    = objBiometriaExcep.cBiometriaExcep;
            txtArchivoAdjunto.Text      = objBiometriaExcep.cNombreArchivo;

            txtSolicitudAprobacion.Text = Convert.ToString(objBiometriaExcep.idSolAproba);
            txtTipoOperacion.Text       = Convert.ToString(objBiometriaExcep.cTipoOperacion);
            txtEstadoSolicitud.Text     = objBiometriaExcep.cEstadoSolicitud;
            txtProducto.Text            = objBiometriaExcep.cProducto;
            txtMonto.Text               = objBiometriaExcep.nMonto.ToString("N2");
            txtMoneda.Text              = objBiometriaExcep.cMoneda;

            lstAprobaSolic.Clear();
            lstAprobaSolic.AddRange(objBiometriaExcep.lstAprobaSolici);
            bsAprobadorSolicitud.ResetBindings(false);
            identificarEstadoExcepcion();
            dtgAprobadores.Refresh();
        }


        #endregion
    }
}
