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
    public partial class frmSolicitudJustificacion : frmBase
    {
        DataTable dtInasist;
        DataTable dtMotivos;
        DataTable dtSolicitud;

        int idClienteUsuario = 0;

        public frmSolicitudJustificacion()
        {
            InitializeComponent();
        }

        private void frmSolicitudJustificacion_Load(object sender, EventArgs e)
        {
            CargarPeriodo();
            this.cboPeriodo.SelectedIndex = -1;

        }
        private void CargarPeriodo() {

            clsCNPeriodoPlanilla objPeriodoPlanilla = new clsCNPeriodoPlanilla();
            DataTable dtPeriodo = objPeriodoPlanilla.CNListarPeriodoVigenteTipoPlanilla(1);
            dtPeriodo.DefaultView.RowFilter = ("idEstado = 2");
            cboPeriodo.DataSource = dtPeriodo;
            cboPeriodo.ValueMember = dtPeriodo.Columns["idPeriodo"].ToString();
            cboPeriodo.DisplayMember = dtPeriodo.Columns["cPeriodo"].ToString();    
        }

        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conBusCol1.txtCod.Text.Trim() != "")
            {
                CargarJustInasist();
            }        
        }

        private void CargarJustInasist()
        {

            CargardtgInasistencia(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()), Convert.ToInt32(cboPeriodo.SelectedValue));


                clsCNJustificaciones SolicitudPendiente = new clsCNJustificaciones();
                dtSolicitud = SolicitudPendiente.DatosSolicitud(idClienteUsuario, Convert.ToInt32(cboPeriodo.SelectedValue));

                if (dtSolicitud.Rows.Count > 0) {
                    dtgInasistencias.ReadOnly = false;
                    lblEstadoSolicitud.Text=dtSolicitud.Rows[0]["cEstadoSol"].ToString();
                    lblNroSolicitud.Text = dtSolicitud.Rows[0]["idSolAproba"].ToString();
                    lblFechaSol.Text = Convert.ToDateTime(dtSolicitud.Rows[0]["dFecSolici"]).ToShortDateString().ToString();
                    lblUsuarioSol.Text = dtSolicitud.Rows[0]["cNombre"].ToString();
                    txtDocSustento.Text=dtSolicitud.Rows[0]["cSustento"].ToString();
                    txtDocSustento.Enabled = false;
                    
                    if (Convert.ToInt32(dtSolicitud.Rows[0]["idEstadoSol"]) == 1)
                    {
                        lblAlerta.Text = "* No se podrá enviar otra solicitud hasta tener respuesta de ésta";
                        lblAlerta.ForeColor = System.Drawing.Color.Red;
                        CBNewSolic.Visible = false;
                        CBNewSolic.Checked = false;
                    }
                    if (Convert.ToInt32(dtSolicitud.Rows[0]["idEstadoSol"]) == 4)
                    {
                        lblAlerta.Text = "* Si desea puede enviar una nueva Solicitud Nueva";
                        lblAlerta.ForeColor = System.Drawing.Color.Green;
                        CBNewSolic.Visible = true;
                        CBNewSolic.Checked = false;
                    }
                    for (int i = 0; i < dtSolicitud.Rows.Count; i++) {
                        for (int j = 0; j < dtgInasistencias.Rows.Count; j++) {
                            if (Convert.ToInt32(dtgInasistencias.Rows[j].Cells["idKardexAsis"].Value) == Convert.ToInt32(dtSolicitud.Rows[i]["idKardeAsist"])) {
                                dtgInasistencias.Rows[j].Cells["cmb"].Value = Convert.ToInt32(dtSolicitud.Rows[i]["idMotivo"]);
                                dtgInasistencias.Rows[j].Cells["lJustificar"].Value = true;                            
                            }                       
                        }               
                    }
                    dtgInasistencias.ReadOnly = true;
                    btnEnviar1.Enabled = false;                    
                    btnCancelar1.Enabled = true;
                }

                if (dtSolicitud.Rows.Count == 0)
                {
                    
                    dtgInasistencias.ReadOnly = false;
                    dtgInasistencias.Columns["idKardexAsis"].ReadOnly = true;
                    dtgInasistencias.Columns["dFechaIngreso"].ReadOnly = true;
                    dtgInasistencias.Columns["dFechaSalida"].ReadOnly = true;
                    dtgInasistencias.Columns["tHoraIngreso"].ReadOnly = true;
                    dtgInasistencias.Columns["tHoraSalida"].ReadOnly = true;
                    dtgInasistencias.Columns["lJustificar"].ReadOnly = false;
                    dtgInasistencias.Columns["idMotivo"].ReadOnly = false;
                    dtgInasistencias.Columns["cmb"].ReadOnly = false;

                    lblEstadoSolicitud.Text = "--SIN SOLICITUD--";
                    lblNroSolicitud.Text = "";
                    lblFechaSol.Text = "";
                    lblUsuarioSol.Text = "";
                    lblAlerta.Text = "";
                    txtDocSustento.Clear();
                    CBNewSolic.Visible = false;
                    CBNewSolic.Checked = false;
                    txtDocSustento.Enabled = true;

                    btnEnviar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                }
        }

        private void CargardtgInasistencia( int idUsuario, int idPeriodo) {

            clsCNJustificaciones Inasistencia = new clsCNJustificaciones();
            dtInasist = Inasistencia.Inasistencias(idUsuario, idPeriodo);
            dtInasist.Columns.Add("lJustificar", typeof(Boolean));
            dtInasist.Columns.Add("idMotivo", typeof(int));

            Int32 nNumDir = dtInasist.Rows.Count;
            for (int i = 0; i < nNumDir; i++)
            {
                dtInasist.Rows[i]["lJustificar"] = 0;
                dtInasist.Rows[i]["idMotivo"] = 0;                    
            }

            if (dtgInasistencias.ColumnCount > 0)
            {
                dtgInasistencias.Columns.Remove("idKardexAsis");
                dtgInasistencias.Columns.Remove("dFechaIngreso");
                dtgInasistencias.Columns.Remove("dFechaSalida");
                dtgInasistencias.Columns.Remove("tHoraIngreso");
                dtgInasistencias.Columns.Remove("tHoraSalida");
                dtgInasistencias.Columns.Remove("cmb");
                dtgInasistencias.Columns.Remove("lJustificar");
                dtgInasistencias.Columns.Remove("idMotivo");
            }
            dtgInasistencias.DataSource = dtInasist.DefaultView;

            clsCNMotivoInasistencia motivos = new clsCNMotivoInasistencia();
            dtMotivos = motivos.CNListarMotivosJustificacion();
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Motivo";
            cmb.Name = "cmb";
            cmb.FillWeight = 100;
            cmb.MaxDropDownItems = 5;
            cmb.DataSource = dtMotivos;
            cmb.DisplayMember = dtMotivos.Columns[1].ToString();
            cmb.ValueMember = dtMotivos.Columns[0].ToString();
            dtgInasistencias.Columns.Add(cmb);            
                        
            dtgInasistencias.Columns["idKardexAsis"].Visible = false;
            dtgInasistencias.Columns["dFechaIngreso"].Width = 50;
            dtgInasistencias.Columns["dFechaSalida"].Width = 50;
            dtgInasistencias.Columns["tHoraIngreso"].Width = 40;
            dtgInasistencias.Columns["tHoraSalida"].Width = 40;            
            dtgInasistencias.Columns["lJustificar"].Width = 25;
            dtgInasistencias.Columns["cmb"].Width = 100;
            dtgInasistencias.Columns["dFechaIngreso"].HeaderText = "Fecha Ingreso";
            dtgInasistencias.Columns["dFechaSalida"].HeaderText = "Fecha Salida";
            dtgInasistencias.Columns["tHoraIngreso"].HeaderText = "Hora Ingreso";
            dtgInasistencias.Columns["tHoraSalida"].HeaderText = "Hora Salida";            
            dtgInasistencias.Columns["lJustificar"].HeaderText = "Just.";
            dtgInasistencias.Columns["idMotivo"].Visible = false;
            dtgInasistencias.Columns["cmb"].HeaderText = "Motivo";
            dtgInasistencias.Columns["dFechaIngreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInasistencias.Columns["dFechaSalida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInasistencias.Columns["tHoraIngreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInasistencias.Columns["tHoraSalida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInasistencias.Columns["lJustificar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInasistencias.Columns["cmb"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
               
        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusCol1.txtCod.Text.Trim() == "")
            {                     
                conBusCol1.txtCod.Focus();
                conBusCol1.txtCod.Enabled = true;
                cboPeriodo.Enabled = false; 
                cboPeriodo.SelectedValue = 0;
                if(dtgInasistencias.Rows.Count>0)
                    dtInasist.Rows.Clear();       
                txtDocSustento.Clear();
                lblNroSolicitud.Text = "";
                lblEstadoSolicitud.Text = "";
                lblUsuarioSol.Text = "";
                lblFechaSol.Text = "";
                lblAlerta.Text = "";
                CBNewSolic.Visible = false;
                CBNewSolic.Checked = false;
                btnEnviar1.Enabled = false;
                btnCancelar1.Enabled = false;
                MessageBox.Show("No se encontró registro", "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               
                return;
            }
            else
            {
                idClienteUsuario = Convert.ToInt32(conBusCol1.idCliPer);
                conBusCol1.txtCod.Enabled = false;
                cboPeriodo.Enabled = true;
                cboPeriodo.SelectedValue = 0;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {          
            cboPeriodo.SelectedValue = 0;
            txtDocSustento.Clear();
            lblNroSolicitud.Text = "";
            lblEstadoSolicitud.Text = "";
            lblUsuarioSol.Text = "";
            lblFechaSol.Text = "";
            lblAlerta.Text = "";
            CBNewSolic.Visible = false;
            CBNewSolic.Checked = false;

            conBusCol1.txtCod.Clear();
            conBusCol1.txtNom.Clear();
            conBusCol1.txtCargo.Clear();

            conBusCol1.txtCod.Enabled = true;
            conBusCol1.txtCod.Focus();
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {           
            int idPrimerMotivo = 0;
            string cSustento = "El día(s) a Justificar es(son): ";
            int cont=0;

        //revisar fila x fila todas las que serán justificadas
          Int32 nNumDir = dtgInasistencias.Rows.Count;            
          for (int i = 0; i < nNumDir; i++)
             {
                if (Convert.ToInt32(dtgInasistencias.Rows[i].Cells["lJustificar"].Value) == 1)
                {
                    cont=cont+1;
                    if (Convert.ToString(dtgInasistencias.Rows[i].Cells["cmb"].Value) == "")
                    {

                        MessageBox.Show("Seleccione el Motivo de Justificación del día " + Convert.ToDateTime(dtgInasistencias.Rows[i].Cells["dFechaIngreso"].Value).ToShortDateString(), "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtgInasistencias.Rows[i].Cells["cmb"].Value.ToString() != ""){
                        cSustento += (Convert.ToDateTime(dtgInasistencias.Rows[i].Cells["dFechaIngreso"].Value)).ToShortDateString()+", ";                        
                        dtgInasistencias.Rows[i].Cells["idMotivo"].Value=Convert.ToInt32(dtgInasistencias.Rows[i].Cells["cmb"].Value);
                    }
                    if(idPrimerMotivo == 0)
                        idPrimerMotivo=Convert.ToInt32(dtgInasistencias.Rows[i].Cells["cmb"].Value);
                }
             }

           cSustento = cSustento + " " + txtDocSustento.Text.Trim();

            //validaciones
            if (cont==0)
            {
                 MessageBox.Show("No se ha seleccionado ninguna inasistencia para enviar la solicitud de Justificación", "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
            }
            if (txtDocSustento.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese el Nro de Documento que respalda la Justificación y la Descripción del Motivo", "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDocSustento.Focus();
                return;
            }
            
            clsCNJustificaciones solicitud = new clsCNJustificaciones();
            //Si hay una solicitud Rechazada, primero se anula
            if (CBNewSolic.Visible == true && CBNewSolic.Checked == true)
            {                
                solicitud.AnularSolicRechazada(Convert.ToInt32(dtSolicitud.Rows[0]["idSolAproba"]));
            }

            //Enviar a Guardar toda la tabla de Inasistencias
            DataSet dsJust = new DataSet("dsInasistencias");
            dsJust.Tables.Add(dtInasist);
            string xmlJustificacion = dsJust.GetXml();
            xmlJustificacion = clsCNFormatoXML.EncodingXML(xmlJustificacion);
            dsJust.Tables.Clear();
                        
            int idJustificacion = solicitud.GuardarSolicitud(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()), txtDocSustento.Text.Trim() ,xmlJustificacion);
            
           //ENVIAR LA SOLICITUD           
            DataTable tbSolApr = solicitud.EnviarSolicitud(Convert.ToInt32(clsVarGlobal.nIdAgencia), idClienteUsuario, 65, 1, -1, 0,
                                      0, idJustificacion, clsVarApl.dicVarGen["dFechaGRH"], idPrimerMotivo, cSustento, 1, 
                                      Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario),false);
            
            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            CargarJustInasist();              
 
        }

        private void CBNewSolic_CheckedChanged(object sender, EventArgs e)
        {
            if (CBNewSolic.Visible == true)
            {
                if (Convert.ToBoolean(CBNewSolic.Checked) == true)
                {
                    CargardtgInasistencia(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()), Convert.ToInt32(cboPeriodo.SelectedValue));

                    lblNroSolicitud.Text = "";
                    lblEstadoSolicitud.Text = "NUEVA SOLICITUD";
                    lblUsuarioSol.Text = "";
                    lblFechaSol.Text = "";
                    lblAlerta.Text = "";
                    txtDocSustento.Clear();
                    txtDocSustento.Enabled = true;
                                       
                    dtgInasistencias.ReadOnly = false;
                    dtgInasistencias.Columns["idKardexAsis"].ReadOnly = true;
                    dtgInasistencias.Columns["dFechaIngreso"].ReadOnly = true;
                    dtgInasistencias.Columns["dFechaSalida"].ReadOnly = true;
                    dtgInasistencias.Columns["tHoraIngreso"].ReadOnly = true;
                    dtgInasistencias.Columns["tHoraSalida"].ReadOnly = true;
                    dtgInasistencias.Columns["lJustificar"].ReadOnly = false;
                    dtgInasistencias.Columns["idMotivo"].ReadOnly = false;
                    dtgInasistencias.Columns["cmb"].ReadOnly = false;

                    btnEnviar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                }

                else { 
                    dtgInasistencias.ReadOnly = false;
                    lblEstadoSolicitud.Text=dtSolicitud.Rows[0]["cEstadoSol"].ToString();
                    lblNroSolicitud.Text = dtSolicitud.Rows[0]["idSolAproba"].ToString();
                    lblFechaSol.Text = Convert.ToDateTime(dtSolicitud.Rows[0]["dFecSolici"]).ToShortDateString().ToString();
                    lblUsuarioSol.Text = dtSolicitud.Rows[0]["cNombre"].ToString();
                    txtDocSustento.Text=dtSolicitud.Rows[0]["cSustento"].ToString();
                    txtDocSustento.Enabled = false;
                    
                    lblAlerta.Text = "* Si desea puede enviar una nueva Solicitud Nueva";
                    lblAlerta.ForeColor = System.Drawing.Color.Green;
                    CBNewSolic.Visible = true;
                    CBNewSolic.Checked = false;
                    
                    for (int i = 0; i < dtSolicitud.Rows.Count; i++) {
                        for (int j = 0; j < dtgInasistencias.Rows.Count; j++) {
                            if (Convert.ToInt32(dtgInasistencias.Rows[j].Cells["idKardexAsis"].Value) == Convert.ToInt32(dtSolicitud.Rows[i]["idKardeAsist"])) {
                                dtgInasistencias.Rows[j].Cells["cmb"].Value = Convert.ToInt32(dtSolicitud.Rows[i]["idMotivo"]);
                                dtgInasistencias.Rows[j].Cells["lJustificar"].Value = true;                            
                            }                       
                        }               
                    }
                    dtgInasistencias.ReadOnly = true;
                    btnEnviar1.Enabled = false;                    
                    btnCancelar1.Enabled = true;                
                }
            }
        }        
    }
}
