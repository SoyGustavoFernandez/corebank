
using ADM.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GEN.CapaNegocio
{
    public partial class frmSolicitudExcepcionLimite : Form
    {
        #region Variables

        clsCNRegAprobaSolicitud clsCNRegAprobaSolicitud = new clsCNRegAprobaSolicitud();
        string cSustento = "";
        int idAgencia = Convert.ToInt32(clsVarGlobal.nIdAgencia.ToString());
        private int idsolicitud = 0;
        private int idCliente = 0, idProducto = 0, idMotivo = 0, idEstadoSol = 0, IExcepcion = 0, idEstadoOperac = 0, idTipoOpe = 0, idMoneda = 0, idTipoOpeExpc = 0; 
        private Decimal nValAproba = 0;
        private int idEstablecimiento = Convert.ToInt32(clsVarGlobal.User.idEstablecimiento.ToString());
        DateTime dFecSolici = clsVarGlobal.dFecSystem.Date;
        public SolicitudExcepcionLimite solicitudExcepcionLimite = new SolicitudExcepcionLimite();
        public bool lGrabado = false; 
        List<SolicitudExcepcionLimite> listaSolicitudExcepcionLimite = new List<SolicitudExcepcionLimite>();
        private int idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString());

        #endregion

        #region Metodos Publicos

        public frmSolicitudExcepcionLimite()
        {
            InitializeComponent();
        }

        public void cargarDatos(DataTable ValidarLimiteExcep, int nSolicitud, int nCli, int nProducto, int nMotivo, int nEstadoSol,
                                int idTipoOper, int nMoneda, int nEstadoOperac, int idTipoOpeExp)
        {
            idsolicitud = nSolicitud;
            idCliente = nCli;
            idProducto = nProducto;
            idMotivo = nMotivo;
            idEstadoSol = nEstadoSol;
            IExcepcion = 0;
            idEstadoOperac = nEstadoOperac;
            idTipoOpe = idTipoOper;
            idMoneda = nMoneda;
            idTipoOpeExpc = idTipoOpeExp;

            listaSolicitudExcepcionLimite = ValidarLimiteExcep.AsEnumerable().Select(x => new SolicitudExcepcionLimite
            {
                idTipoOperacion = Convert.ToInt32(x["idTipoOperacion"]),
                idTipoLimite = Convert.ToInt32(x["idTipoLimite"]),
                cTipoLimite = x["cTipoLimite"].ToString(),
                lExcepcion = Convert.ToBoolean(x["lExcepcion"]),
                nValAproba = Convert.ToDecimal(x["nValAproba"]),

            }).ToList();

            dtgExcepcion.AllowUserToAddRows = false;
            dtgExcepcion.DataSource = ValidarLimiteExcep;
            foreach (DataGridViewColumn item in dtgExcepcion.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            dtgExcepcion.Columns["cTipoLimite"].Visible = true;
            dtgExcepcion.Columns["lExcepcion"].Visible = true;
            dtgExcepcion.Columns["cTipoLimite"].HeaderText = "Limite Interno";
            dtgExcepcion.Columns["lExcepcion"].HeaderText = "Autorización";
            dtgExcepcion.ReadOnly = true;
            dtgExcepcion.ScrollBars = ScrollBars.None;
            dtgExcepcion.RowHeadersVisible = false;
            dtgExcepcion.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;


        }

        #endregion

        #region Metodos Privados

        private bool ValidarControles()
        {
            bool bResultado = true;
            string sustentoText = txtSustento.Text;
            if (sustentoText.Length < 10)
            {
                MessageBox.Show("El sustento debe tener al menos 10 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bResultado = false;
            }
            else if (sustentoText.Length > 500)
            {
                MessageBox.Show("El sustento no puede tener más de 500 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bResultado = false;
            }
            return bResultado;
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lGrabado = false;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarControles())
            {
                string limites = "";
                string cLimitesExcepcion = "";
                cLimitesExcepcion = string.Join(",", listaSolicitudExcepcionLimite
                                    .Where(x => x.lExcepcion)
                                    .Select(x => x.idTipoLimite.ToString()));



                foreach (var item in listaSolicitudExcepcionLimite)
                {
                    if (item.lExcepcion == true)
                    {
                        limites = limites + " - " + item.cTipoLimite + "\n";
                        nValAproba = Convert.ToDecimal(item.nValAproba);
                    }
                }

                cSustento = txtSustento.Text;
                dFecSolici = dFecSolici.Add(DateTime.Now.TimeOfDay);
                if (idMoneda == 2)
                    idMoneda = 1;

                DataTable dtSolExcepcion = clsCNRegAprobaSolicitud.CNRegistarSolicitudExcepcionLimite(idAgencia, idCliente, idTipoOpe,
                    idEstadoOperac, idMoneda, idProducto, nValAproba, idsolicitud,
                    dFecSolici, idMotivo, cSustento, idEstadoSol, dFecSolici, idUsuario, IExcepcion, idTipoOpeExpc, cLimitesExcepcion, idEstablecimiento);
                if (dtSolExcepcion.Rows.Count > 0)
                {
                    string cSolAproba = "";
                    string cAprobador = "";
                    string cMensaje = "";
                    string mensaje = "";


                    if (Convert.ToInt32(dtSolExcepcion.Rows[0]["idEstadoSol"].ToString()) != 4)
                    {
                        cSolAproba = dtSolExcepcion.Rows[0]["idSolAproba"].ToString();
                        DataTable CNObtenerAprobadorSolExcep = clsCNRegAprobaSolicitud.CNObtenerAprobadorSolExcep(Convert.ToInt32(cSolAproba));
                        if (CNObtenerAprobadorSolExcep.Rows.Count > 0)
                        {
                            cAprobador = CNObtenerAprobadorSolExcep.Rows[0]["nAbreCargo"].ToString() + ". " + CNObtenerAprobadorSolExcep.Rows[0]["cNombre"].ToString();
                        }
                        mensaje = "Límite por Transacción superado \n" +
                            limites + "\n" + "La solicitud se registró correctamente. \n \n" +
                            "Nro. de Solicitud: " + cSolAproba + "\n \n" +
                            "Se envió las notificaciones respectivas a: \n" + cAprobador + "\n" +
                            "POR FAVOR COORDINAR...";
                        //Enviar correo a los aprobador
                        try
                        {
                            DataTable dtNotifcarEmail = clsCNRegAprobaSolicitud.CNEnviarEmailLimiteEOB(Convert.ToInt32(cSolAproba));

                        }
                        catch
                        {
                            MessageBox.Show("No se pudo enviar correo de notificación de la solicitud de excepción de límite", "Registro de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        lGrabado = true;
                    }
                    else
                    {
                        cSolAproba = dtSolExcepcion.Rows[0]["idSolAproba"].ToString();
                        cMensaje = dtSolExcepcion.Rows[0]["cMensaje"].ToString();
                        mensaje = "Límite por Transacción superado \n \n" +
                               limites + "\n" +
                             cMensaje + ". \n \n" +
                             "Nro de Solicitud: " + cSolAproba + "\n \n";
                        lGrabado = false;
                    }

                    MessageBox.Show(mensaje, "Número de Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo enviar la solicitud de excepción de límite", "Registro de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
    }
}