using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;


namespace GRH.Presentacion
{
    public partial class frmSolicitudHorasExtras : frmBase
    {
        DataTable dtListaSolicitud;
        int idClienteUsuario;
        public frmSolicitudHorasExtras()
        {
            InitializeComponent();
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColaborador.txtCod.Text.Trim() == "")
            {
                conBusColaborador.txtCod.Focus();
                conBusColaborador.txtCod.Enabled = true;

                Limpiar();
                btnNuevo1.Enabled = false;
                btnEnviar1.Enabled = false;
                btnCancelar1.Enabled = false;
                if(dtgBase1.Rows.Count>0)
                    dtListaSolicitud.Rows.Clear();
                MessageBox.Show("No se encontró registro", "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                idClienteUsuario = Convert.ToInt32(conBusColaborador.idCliPer);
                conBusColaborador.txtCod.Enabled = false;               
                BuscarSolicitud();
            }
            
        }
        private void Limpiar() {
            dtFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtFechaFin.Value = clsVarGlobal.dFecSystem;
            dtHoraInicio.Value = DateTime.Now;
            dtHoraFin.Value = DateTime.Now;
            txtMinutos.Text = "";
            txtDescripcion.Text = "";        
        }
        private void HabilitarControles(Boolean val) {
            dtFechaInicio.Enabled = val;
            dtFechaFin.Enabled = val;
            dtHoraInicio.Enabled = val;
            dtHoraFin.Enabled = val;
            txtDescripcion.Enabled = val;        
        }

        private void BuscarSolicitud() { 
            
            clsCNHorasExtrasCompens Solicitud =new clsCNHorasExtrasCompens();
            dtListaSolicitud = Solicitud.SolicitudesPendientes(Convert.ToInt32(conBusColaborador.txtCod.Text));

            if (dtgBase1.ColumnCount > 0)
            {
                dtgBase1.Columns.Remove("idSolAproba");
                dtgBase1.Columns.Remove("dFecSolici");
                dtgBase1.Columns.Remove("cSustento");
                dtgBase1.Columns.Remove("cEstadoSol");
                dtgBase1.Columns.Remove("nValAproba");
                dtgBase1.Columns.Remove("idEstadoSol");
                dtgBase1.Columns.Remove("cOpinion"); 
            }

            this.dtgBase1.DataSource = dtListaSolicitud.DefaultView;

            dtgBase1.Columns["idSolAproba"].Width = 25;
            dtgBase1.Columns["idSolAproba"].HeaderText = "N°Sol.";
            dtgBase1.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["dFecSolici"].Width = 35;
            dtgBase1.Columns["dFecSolici"].HeaderText = "Fecha";
            dtgBase1.Columns["dFecSolici"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["cSustento"].Width = 180;
            dtgBase1.Columns["cSustento"].HeaderText = "Descripcion";
            dtgBase1.Columns["cSustento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["cEstadoSol"].Width = 35;
            dtgBase1.Columns["cEstadoSol"].HeaderText = "Estado";
            dtgBase1.Columns["cEstadoSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["nValAproba"].Visible = false;
            dtgBase1.Columns["idEstadoSol"].Visible = false;
            dtgBase1.Columns["cOpinion"].Visible = false;

            //Limpiar();
            HabilitarControles(false);
            btnNuevo1.Enabled = true;
            btnEnviar1.Enabled = false;
            btnCancelar1.Enabled = true;

        }

        private void frmSolicitudHorasExtras_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            Limpiar();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
            if (dtgBase1.Rows.Count > 0)
                dtListaSolicitud.Rows.Clear();
            conBusColaborador.txtCod.Enabled = true;
            conBusColaborador.txtCod.Focus();
            conBusColaborador.txtCod.Text = "";
            conBusColaborador.txtNom.Text = "";
            conBusColaborador.txtCargo.Text = "";
            HabilitarControles(false);
            btnNuevo1.Enabled = false;
            btnEnviar1.Enabled = false;
            btnCancelar1.Enabled = false;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(true);
            btnNuevo1.Enabled = false;
            btnEnviar1.Enabled = true;
            btnCancelar1.Enabled = true;
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToDateTime(dtFechaInicio.Value).Date > Convert.ToDateTime(dtFechaFin.Value).Date)) 
            {
                MessageBox.Show("La Fecha de Inicio no puede ser mayor a la Fecha Final", "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFechaInicio.Focus();
                return;
            }
            if ((Convert.ToDateTime(dtFechaInicio.Value).Date == Convert.ToDateTime(dtFechaFin.Value).Date) && (Convert.ToDateTime(dtHoraInicio.Value.ToShortTimeString()) > Convert.ToDateTime(dtHoraFin.Value.ToShortTimeString())))
            {
                MessageBox.Show("La Hora de Inicio no puede ser mayor a la Hora de Salida", "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtHoraInicio.Focus();
                return;
            }
            if ((Convert.ToDateTime(dtFechaInicio.Value).Date == Convert.ToDateTime(dtFechaFin.Value).Date) && (Convert.ToDateTime(dtHoraInicio.Value.ToShortTimeString()) == Convert.ToDateTime(dtHoraFin.Value.ToShortTimeString())))
            {
                MessageBox.Show("La Hora de Inicio y la Hora de Salida no pueden ser iguales", "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtHoraInicio.Focus();
                return;
            }
            if (txtDescripcion.Text.Trim()=="")
            {
                MessageBox.Show("Indique la Actividad que realizó en dichas Horas Extras", "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return;
            }
          

            TimeSpan Difminutos;
            double minutos;
            if ((Convert.ToDateTime(dtFechaInicio.Value).Date == Convert.ToDateTime(dtFechaFin.Value).Date))
            {
                Difminutos = (Convert.ToDateTime(dtHoraFin.Value.ToShortTimeString()) - Convert.ToDateTime(dtHoraInicio.Value.ToShortTimeString()));
                minutos = Difminutos.TotalMinutes;
            }
            else
            {
                Difminutos = (Convert.ToDateTime(dtHoraInicio.Value.ToShortTimeString()) - Convert.ToDateTime(dtHoraFin.Value.ToShortTimeString()));
                minutos = 1440 - (Difminutos.TotalMinutes);
            }

            decimal MinutosRedondeado = Math.Round(Convert.ToDecimal(minutos),0);
            this.txtMinutos.Text = MinutosRedondeado.ToString();


            string cSustento = "Fecha: " + Convert.ToDateTime(dtFechaInicio.Value).ToShortDateString() + ", de " + dtHoraInicio.Value.ToShortTimeString() + " hasta "+
                                dtHoraFin.Value.ToShortTimeString() + ", Actividad: " + txtDescripcion.Text;

            clsCNHorasExtrasCompens Solicitud = new clsCNHorasExtrasCompens();

            //ENVIAR LA SOLICITUD           
            DataTable tbSolApr = Solicitud.EnviarSolicitud(Convert.ToInt32(clsVarGlobal.nIdAgencia), idClienteUsuario, 66, 1, -1, 0,
                                      MinutosRedondeado, 0, clsVarApl.dicVarGen["dFechaGRH"], 0, cSustento, 1,
                                      Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario),0);
           
            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Solicitud de Reconocimiento de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            BuscarSolicitud();
            HabilitarControles(false);
            btnNuevo1.Enabled = true;
            btnEnviar1.Enabled = false;
            btnCancelar1.Enabled = true;
        }

        private void dtgBase1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipOpe = e.RowIndex;
            txtOpinion.Text = dtListaSolicitud.Rows[iFilaTipOpe]["cOpinion"].ToString();
        }
    }
}
