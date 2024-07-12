using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmRegistroAccionistas : frmBase
    {
        clsCNAccionistasEmp cnAcciones = new clsCNAccionistasEmp();
        private int idAccionista=0;

        string cNomUser = clsVarGlobal.User.cNomUsu;
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;

        public frmRegistroAccionistas()
        {
            InitializeComponent();
        }
        private void EnableBoton(bool lActivo)
        {
            btnEditar1.Enabled = lActivo;
            btnNuevo1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;
        }
        private void EnableControl(bool lActivo)
        {
            //conBusCli.Enabled = lActivo;
            cboTipoAccionEmp1.Enabled = lActivo;
            cboTipoAccionesEmp1.Enabled = lActivo;
            txtNroAcciones.Enabled = lActivo;
            txtNroFolio.Enabled = lActivo;
            txtValNominal.Enabled = lActivo;
            dtpFecAdquisicion.Enabled = lActivo;
            txtObservaciones.Enabled = lActivo;
            txtCodAccionista.Enabled = lActivo;
            txtDescAccionista.Enabled = lActivo;
            cboTipoEmision.Enabled = lActivo;
            txtPorcParticipacion.Enabled = lActivo;
            cboTipoOperacion.Enabled = lActivo;
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (idAccionista == 0)
            {
                MessageBox.Show("El cliente no tiene registrado acciones","Mensaje registro accionista",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            conBusCli.Enabled = false;
            EnableBoton(false);
            chcVigente.Enabled = true;
            EnableControl(true);
        }    

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            conBusCli.Enabled = true;
            chcVigente.Enabled = false;
            EnableControl(false);
        
            conBusCli.limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            limpiarGrupo();

        }
        private void  limpiarGrupo(){
            chcVigente.Checked = false;
            cboTipoAccionEmp1.SelectedIndex = -1;
            cboTipoAccionesEmp1.SelectedIndex = -1;
            cboTipoOperacion.SelectedIndex = -1;
            txtNroAcciones.Text = "0.00";
            txtValNominal.Text = "0.00";
            txtNroFolio.Text = "0.00";
            dtpFecAdquisicion.Value = clsVarGlobal.dFecSystem;
            txtObservaciones.Clear();
            txtCodAccionista.Clear();
            txtDescAccionista.Clear();
            txtPorcParticipacion.Clear();
            cboTipoEmision.SelectedIndex = -1;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (conBusCli.idCli==0)
            {
                return;
            }
            limpiarGrupo();
            EnableBoton(false);
            chcVigente.Checked = true;           
            chcVigente.Enabled = false;
            EnableControl(true);
            conBusCli.Enabled = false;
           
            idAccionista=0;
        }
        private bool validar()
        {

            if (cboTipoAccionesEmp1.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir tipo de acciones ", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboTipoAccionEmp1.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir tipo de acción", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }         
            if (txtNroAcciones.Text == "")
            {
                MessageBox.Show("Debe ingresar el numero de acciones", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtNroAcciones.Text) <= 0)
            {
                MessageBox.Show("El numero de acciones debe ser mayor a cero", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtValNominal.Text == "")
            {
                MessageBox.Show("Debe ingresar el valor nominal de las acciones", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtValNominal.Text) <= 0)
            {
                MessageBox.Show("El valor nominal de acciones debe ser mayor a cero", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtNroFolio.Text == "")
            {
                MessageBox.Show("Debe ingresar el numero de folio de las acciones", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtNroFolio.Text) <= 0)
            {
                MessageBox.Show("El numero de folio de acciones debe ser mayor a cero", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtObservaciones.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un comentario u observación", "Registro de accionista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dtpFecAdquisicion.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de adquisición debe ser ser menor a la fecha del sistema", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            EnableBoton(true);
            DataTable dtResultado;
            dtResultado = cnAcciones.CNRegistraAccionesEmp(idAccionista, conBusCli.idCli, (int)(cboTipoAccionesEmp1.SelectedValue), (int)(cboTipoAccionEmp1.SelectedValue), 
                Convert.ToDecimal(txtNroAcciones.Text), Convert.ToDecimal(txtValNominal.Text),txtObservaciones.Text,               
                clsVarGlobal.User.idUsuario, dtpFecAdquisicion.Value,clsVarGlobal.dFecSystem, chcVigente.Checked,Convert.ToInt32(txtNroFolio.Text),
                    txtCodAccionista.Text, txtDescAccionista.Text, Convert.ToDecimal(txtPorcParticipacion.Text), (int)(cboTipoEmision.SelectedValue), (int)(cboTipoOperacion.SelectedValue));
            if (dtResultado.Rows.Count>0)
            {
                if (dtResultado.Rows[0][0].ToString() == "1")
                {

                    MessageBox.Show(dtResultado.Rows[0][1].ToString() , "Graba Accionistas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    EnableControl(false);
                    conBusCli.Enabled = true;
                    btnCancelar1.Enabled = true;
                }
                else
                {EnableBoton(false);
                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Graba Accionistas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmRegistroAccionistas_Load(object sender, EventArgs e)
        {  
            DataTable dtTipoEmision;
            dtTipoEmision = cnAcciones.CNListaTipoEmisionAccione();
            cboTipoEmision.ValueMember = "idTipoEmision";
            cboTipoEmision.DisplayMember = "cTipoEmisionAcciones";
            cboTipoEmision.DataSource = dtTipoEmision;

            DataTable dtTipoOperacion;
            dtTipoOperacion = cnAcciones.CNListaTipoOperacionAcciones();
            cboTipoOperacion.ValueMember = "idTipoOpeAccion";
            cboTipoOperacion.DisplayMember = "cTipoOpeAccion";
            cboTipoOperacion.DataSource = dtTipoOperacion;
            EnableBoton(true);
            EnableControl(false);
            limpiarGrupo();
          
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
           DataTable dtAcciones = cnAcciones.CNListaAccionesRegistrasdas(conBusCli.idCli);
           if (dtAcciones.Rows.Count<=0)
           {
               return;
           }
           else if (dtAcciones.Rows.Count == 1)
           {
               DataRow dtRows = dtAcciones.Rows[0];
               idAccionista = (int)dtRows["idAccionista"];
               cboTipoAccionEmp1.SelectedValue = (int)dtRows["idTipoAccion"];
               cboTipoAccionesEmp1.SelectedValue = (int)dtRows["idTipoAcciones"];
               txtNroAcciones.Text = dtRows["nNroAcciones"].ToString();
               txtNroFolio.Text = dtRows["nNroFolio"].ToString();
               txtValNominal.Text = dtRows["nValorNominal"].ToString();
               dtpFecAdquisicion.Value = Convert.ToDateTime(dtRows["dFecAdquisicion"]);
               txtObservaciones.Text = dtRows["cObservacion"].ToString();
               chcVigente.Checked = Convert.ToBoolean(dtRows["lVigente"]);
               txtPorcParticipacion.Text = dtRows["nPorcParticipacion"].ToString();
               txtDescAccionista.Text = dtRows["cDescAccionista"].ToString();
               cboTipoEmision.SelectedValue = (int)dtRows["nTipoEmision"];
               txtCodAccionista.Text = dtRows["cCodAccionista"].ToString();
               cboTipoOperacion.SelectedValue = (int)dtRows["idTipoOpeAccion"];

           }
           else
           {
               frmBuscarAccionesReg frAcc = new frmBuscarAccionesReg(dtAcciones);
              frAcc.ShowDialog();
               if (frAcc.dtRows!=null)
               {
                   idAccionista = (int)frAcc.dtRows["idAccionista"];
                   cboTipoAccionEmp1.SelectedValue = (int)frAcc.dtRows["idTipoAccion"];
                   cboTipoAccionesEmp1.SelectedValue = (int)frAcc.dtRows["idTipoAcciones"];
                   txtNroAcciones.Text = frAcc.dtRows["nNroAcciones"].ToString();
                   txtNroFolio.Text = frAcc.dtRows["nNroFolio"].ToString();
                   txtValNominal.Text = frAcc.dtRows["nValorNominal"].ToString();
                   dtpFecAdquisicion.Value =Convert.ToDateTime(frAcc.dtRows["dFecAdquisicion"]);
                   txtObservaciones.Text = frAcc.dtRows["cObservacion"].ToString();
                   chcVigente.Checked = Convert.ToBoolean(frAcc.dtRows["lVigente"]);
                   txtPorcParticipacion.Text = frAcc.dtRows["nPorcParticipacion"].ToString();
                   txtDescAccionista.Text = frAcc.dtRows["cDescAccionista"].ToString();
                   cboTipoEmision.SelectedValue = (int)frAcc.dtRows["nTipoEmision"];
                   txtCodAccionista.Text = frAcc.dtRows["cCodAccionista"].ToString();
                   cboTipoOperacion.SelectedValue = (int)frAcc.dtRows["idTipoOpeAccion"];
               }
               
           }

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string dFecOpe = Convert.ToString(dFechaSistema);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            DateTime dFechaConsul = dFechaSistema;

            string dFechaConsulta = dFechaConsul.ToString("yyyy/MM/dd");

            DataTable dtData = cnAcciones.CNListaAccionistas();
            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsData", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaC", dFechaConsulta.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                string reportPath = "rptListaAccionistas.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta fecha.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
