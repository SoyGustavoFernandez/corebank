using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmCompenHorasExtras : frmBase
    {
        DataTable dtListaSolicitud;
        DataTable dtListaCompensacion;
        int idClienteUsuario;
        public frmCompenHorasExtras()
        {
            InitializeComponent();
        }

        private void frmCompenHorasExtras_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColaborador.txtCod.Text.Trim() == "")
            {
                conBusColaborador.txtCod.Focus();
                conBusColaborador.txtCod.Enabled = true;

                Limpiar();
                btnNuevo1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = false;
                if (dtgSolAprobadas.Rows.Count > 0)
                    dtListaSolicitud.Rows.Clear();
                MessageBox.Show("No se encontró registro", "Justificación de Inasistencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                idClienteUsuario = Convert.ToInt32(conBusColaborador.idCliPer);
                conBusColaborador.txtCod.Enabled = false;
                BuscarSolicitud();
                BuscarCompensaciones();
            }
        }
        private void Limpiar()
        {
            dtFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtFechaFin.Value = clsVarGlobal.dFecSystem;
            RBTurnos.Checked = false;
            RBHoras.Checked = false;
            cboTurnoUsuario.SelectedIndex = -1;
            dtHoraInicio.Value = DateTime.Now;
            dtHoraFin.Value = DateTime.Now;
            //txtMinutos.Text = "";
        }
        private void HabilitarControles(Boolean val)
        {
            dtFechaInicio.Enabled = val;
            dtFechaFin.Enabled = val;
            RBTurnos.Enabled = val;
            RBHoras.Enabled = val;
            cboTurnoUsuario.Enabled = val;
            dtHoraInicio.Enabled = val;
            dtHoraFin.Enabled = val;
            
        }
        private void BuscarSolicitud()
        {
            clsCNHorasExtrasCompens Solicitud = new clsCNHorasExtrasCompens();
            dtListaSolicitud = Solicitud.SolicitudesPendientes(Convert.ToInt32(conBusColaborador.txtCod.Text));

            dtListaSolicitud.DefaultView.RowFilter = ("idEstadoSol = 2");

            if (dtgSolAprobadas.ColumnCount > 0)
            {
                dtgSolAprobadas.Columns.Remove("idSolAproba");
                dtgSolAprobadas.Columns.Remove("dFecSolici");
                dtgSolAprobadas.Columns.Remove("cSustento");
                dtgSolAprobadas.Columns.Remove("cEstadoSol");
                dtgSolAprobadas.Columns.Remove("nValAproba");
                dtgSolAprobadas.Columns.Remove("idEstadoSol");
            }

            this.dtgSolAprobadas.DataSource = dtListaSolicitud.DefaultView;

            dtgSolAprobadas.Columns["idSolAproba"].Width = 25;
            dtgSolAprobadas.Columns["idSolAproba"].HeaderText = "N°Sol.";
            dtgSolAprobadas.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolAprobadas.Columns["dFecSolici"].Width = 35;
            dtgSolAprobadas.Columns["dFecSolici"].HeaderText = "Fec. Sol";
            dtgSolAprobadas.Columns["dFecSolici"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolAprobadas.Columns["cSustento"].Width = 170;
            dtgSolAprobadas.Columns["cSustento"].HeaderText = "Descripcion";
            dtgSolAprobadas.Columns["cSustento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolAprobadas.Columns["cEstadoSol"].Visible = false;

            dtgSolAprobadas.Columns["nValAproba"].Width = 35;
            dtgSolAprobadas.Columns["nValAproba"].HeaderText = "Minutos";
            dtgSolAprobadas.Columns["nValAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgSolAprobadas.Columns["idEstadoSol"].Visible = false;
                        
            Limpiar();

            int TotalMin = 0;
            for (int i = 0; i < dtgSolAprobadas.Rows.Count; i++) {
                TotalMin = TotalMin + Convert.ToInt32(dtgSolAprobadas.Rows[i].Cells["nValAproba"].Value);           
            }
            txtMinutosExtras.Text = TotalMin.ToString();

        }

        private void BuscarCompensaciones()
        {
            clsCNHorasExtrasCompens Compensacion = new clsCNHorasExtrasCompens();
            dtListaCompensacion = Compensacion.DatosCompensaciones(Convert.ToInt32(conBusColaborador.txtCod.Text));
            dtListaCompensacion.Columns.Add("lEst", typeof(Boolean));

            int TotalMinCompen = 0;
            for (int i = 0; i < dtListaCompensacion.Rows.Count; i++)
            {
                dtListaCompensacion.Rows[i]["lEst"] = Convert.ToInt32(dtListaCompensacion.Rows[i]["lEstado"]);
                TotalMinCompen = TotalMinCompen + Convert.ToInt32(dtListaCompensacion.Rows[i]["nMinCompensados"]);           
            }
            txtMinCompen.Text = TotalMinCompen.ToString();
            txtFaltaCompensar.Text = (Convert.ToInt32(txtMinutosExtras.Text) - Convert.ToInt32(txtMinCompen.Text)).ToString();

            if (dtgCompensaciones.ColumnCount > 0)
            {
                dtgCompensaciones.Columns.Remove("idCompensacion");
                dtgCompensaciones.Columns.Remove("dFechaInicio");
                dtgCompensaciones.Columns.Remove("dFechaFin");
                dtgCompensaciones.Columns.Remove("HoraInicio");
                dtgCompensaciones.Columns.Remove("HoraFin");
                dtgCompensaciones.Columns.Remove("lEstado");
                dtgCompensaciones.Columns.Remove("nMinCompensados");
                dtgCompensaciones.Columns.Remove("lEst");
            }

            this.dtgCompensaciones.DataSource = dtListaCompensacion.DefaultView;

            dtgCompensaciones.Columns["idCompensacion"].Visible = false;

             dtgCompensaciones.Columns["dFechaInicio"].Width = 25;
             dtgCompensaciones.Columns["dFechaInicio"].HeaderText = "Fecha";
             dtgCompensaciones.Columns["dFechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
             dtgCompensaciones.Columns["dFechaFin"].Visible = false;

             dtgCompensaciones.Columns["HoraInicio"].Width = 28;
             dtgCompensaciones.Columns["HoraInicio"].HeaderText = "H. Inicio";
             dtgCompensaciones.Columns["HoraInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
             dtgCompensaciones.Columns["HoraFin"].Width = 25;
             dtgCompensaciones.Columns["HoraFin"].HeaderText = "H. Fin";
             dtgCompensaciones.Columns["HoraFin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

             dtgCompensaciones.Columns["nMinCompensados"].Width = 20;
             dtgCompensaciones.Columns["nMinCompensados"].HeaderText = "Minutos";
             dtgCompensaciones.Columns["nMinCompensados"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

             dtgCompensaciones.Columns["lEstado"].Visible = false;
             dtgCompensaciones.Columns["lEst"].Width = 25;
             dtgCompensaciones.Columns["lEst"].HeaderText = "OK";
             dtgCompensaciones.Columns["lEst"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                      
           
            HabilitarControles(false);
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtMinutosExtras.Text = "";
            if (dtgSolAprobadas.Rows.Count > 0)
                dtListaSolicitud.Rows.Clear();
            if (dtgCompensaciones.Rows.Count > 0)
                dtListaCompensacion.Rows.Clear();
            conBusColaborador.txtCod.Enabled = true;
            conBusColaborador.txtCod.Focus();
            conBusColaborador.txtCod.Text = "";
            conBusColaborador.txtNom.Text = "";
            conBusColaborador.txtCargo.Text = "";
            HabilitarControles(false);
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(true);

            cboTurnoUsuario.Enabled = false;
            dtHoraInicio.Enabled = false;
            dtHoraFin.Enabled = false;
            
            cboTurnoUsuario.ListarTurnosFechaUsuario(Convert.ToInt32(conBusColaborador.txtCod.Text), dtFechaInicio.Value);
            cboTurnoUsuario.SelectedIndex = -1;

            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            //validaciones generales
            if (Convert.ToDateTime(dtFechaInicio.Value).Date< clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de Inicio no puede ser anterior a la de Hoy", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFechaInicio.Focus();
                return;
            }

            if (Convert.ToDateTime(dtFechaInicio.Value).Date > Convert.ToDateTime(dtFechaFin.Value).Date)
            {
                MessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Final", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFechaInicio.Focus();
                return;
            }
            if ((Convert.ToDateTime(dtFechaFin.Value.Date) - Convert.ToDateTime(dtFechaInicio.Value.Date)).TotalDays > 1)
            {
                MessageBox.Show("La fecha de Inicio y la Fecha Final no pueden diferenciarse por más de 1 día", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFechaInicio.Focus();
                return;
            }
            
            if (RBHoras.Checked == false && RBTurnos.Checked == false)
            {
                MessageBox.Show("Debe elegir el tipo de selección de Horario por 'Turnos' o por 'Horas'", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RBHoras.Focus();
                return;
            }
            if (RBTurnos.Checked == true)
            {
                if (cboTurnoUsuario.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el turno a Compensar", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTurnoUsuario.Focus();
                    return;
                }
            }

            DateTime FechaHoraActual = Convert.ToDateTime(DateTime.Now.ToShortTimeString());  
            DateTime FecInicio = dtFechaInicio.Value.Date;
            DateTime FecFin = dtFechaFin.Value.Date;
            int lTurno = Convert.ToInt32(RBTurnos.Checked);
            int idTurno = 0;
            if (lTurno == 1)
                idTurno = Convert.ToInt32(cboTurnoUsuario.SelectedValue);
            DateTime HoraInicio = Convert.ToDateTime(dtHoraInicio.Value.ToShortTimeString());
            DateTime HoraFin = Convert.ToDateTime(dtHoraFin.Value.ToShortTimeString());          
            clsCNHorasExtrasCompens Compensacion = new clsCNHorasExtrasCompens();    

            //Hallar la Cant. de Minutos a Compensar-----------------------------------------------
            int MinutosXCompensar = 0;            
            double minutos=0;
            if (FecInicio == FecFin)
                minutos = (dtHoraFin.Value - dtHoraInicio.Value).TotalMinutes;
            if (FecInicio != FecFin)
                minutos = 1440 - (dtHoraInicio.Value - dtHoraFin.Value).TotalMinutes; 
            MinutosXCompensar = Convert.ToInt32(Math.Round(Convert.ToDecimal(minutos), 0));


            //Validaciones sobre la Cant de MINUTOS a compensar, y validaciones específicas
             if (RBHoras.Checked == true)
            {
                if (FecInicio == clsVarGlobal.dFecSystem.Date)//si las horas corresponden al mismo dia
                    {
                        if (HoraInicio < FechaHoraActual)
                        {
                            MessageBox.Show("La Fecha y Hora de Inicio no puede ser anterior a la Fecha y Hora de Hoy", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFechaInicio.Focus();
                            return;
                        }
                    }
                   if (Convert.ToDateTime(dtFechaInicio.Value).Date == Convert.ToDateTime(dtFechaFin.Value).Date)
                   {
                       if (HoraInicio > HoraFin)
                       {
                           MessageBox.Show("La Hora de Inicio no puede ser mayor a la Hora Final", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                           dtFechaInicio.Focus();
                           return;
                       }
                       if (HoraInicio == HoraFin)
                       {
                           MessageBox.Show("La Hora de Inicio la Hora Final no pueden ser iguales", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                           dtFechaInicio.Focus();
                           return;
                       }
                       if (MinutosXCompensar > Convert.ToInt32(txtFaltaCompensar.Text))
                       {
                           MessageBox.Show("Los minutos que se desean Compensar exceden a los minutos Disponibles", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                           return;
                       }
                   }
            }


             if (RBTurnos.Checked == true)
             {
                DataTable CantMin=Compensacion.ConsultarCantMinutos(Convert.ToInt32(cboTurnoUsuario.SelectedValue));
                dtHoraInicio.Value=Convert.ToDateTime(CantMin.Rows[0]["tHoraIngreso"].ToString());

                if (Convert.ToInt32(CantMin.Rows[0][0]) > Convert.ToInt32(txtFaltaCompensar.Text))
                {
                    MessageBox.Show("Los minutos que se desean Compensar exceden a los minutos Disponibles", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToDateTime(dtFechaInicio.Value).Date == clsVarGlobal.dFecSystem)
                {
                    if (dtHoraInicio.Value < FechaHoraActual)
                    {
                        MessageBox.Show("La Fecha y Hora de Inicio no puede ser anterior a la Fecha y Hora de Hoy", "Compensación de Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFechaInicio.Focus();
                        return;
                    }
                }
                               
            }
                       

            //Guardar la Compensacion            
             Compensacion.GuardarCompensacion(Convert.ToInt32(conBusColaborador.txtCod.Text.Trim()),FecInicio, FecFin, lTurno, idTurno, HoraInicio, HoraFin,MinutosXCompensar,
                                              clsVarGlobal.User.idUsuario, clsVarApl.dicVarGen["dFechaGRH"] );

             BuscarSolicitud();
             BuscarCompensaciones();
        }

        private void dtFechaInicio_Validating(object sender, CancelEventArgs e)
        {
            cboTurnoUsuario.ListarTurnosFechaUsuario(Convert.ToInt32(conBusColaborador.txtCod.Text), dtFechaInicio.Value);
            cboTurnoUsuario.SelectedIndex = -1;
        }

        private void RBTurnos_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTurnos.Checked == true) {
                this.cboTurnoUsuario.Enabled = true;

                this.dtHoraInicio.Enabled = false;
                this.dtHoraInicio.Value = DateTime.Now;
                this.dtHoraFin.Enabled = false;
                this.dtHoraFin.Value = DateTime.Now;
            }
        }

        private void RBHoras_CheckedChanged(object sender, EventArgs e)
        {
            if (RBHoras.Checked == true)
            {
                this.cboTurnoUsuario.Enabled = false;
                this.cboTurnoUsuario.SelectedIndex = -1;

                this.dtHoraInicio.Enabled = true;               
                this.dtHoraFin.Enabled = true;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idClienteUsuario = Convert.ToInt32(conBusColaborador.txtCod.Text);
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsUsuHoraExtra", new clsCNHorasExtrasCompens().CNHoraextra(idClienteUsuario)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("idClienteUsuario", idClienteUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));

            string reportpath = "rptHorasExtras.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        
    }
}
