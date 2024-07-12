using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmAperturaCaja : frmBase
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            this.cboAgencias.SelectedValue = 1;
          
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAgencias.SelectedIndex > -1)
            {
                if (this.cboAgencias.SelectedValue is DataRowView) return;
                int nItem= Convert.ToInt32(this.cboAgencias.SelectedValue);
                DateTime dFecOperacion = clsVarGlobal.dFecSystem;
                int idAgencia=Convert.ToInt32(cboAgencias.SelectedValue);
                cboTipResponsableCaja1.cargarTipoResponsableCajaOpe(idAgencia, dFecOperacion);
                cboTipResponsableCaja1_SelectedIndexChanged(sender, e);
            }
        }

        private void chcApeCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcApeCaja.Checked)
            {
                this.btnAceptar.Enabled = true;
                this.chcCorteFracc.Checked = false;
            }
            else
            {
                this.btnAceptar.Enabled = false;
                this.chcCorteFracc.Checked = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Validar Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }

            if (this.cboAgencias.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Validar Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboTipResponsableCaja1.SelectedIndex <=-1)
            {
                MessageBox.Show("Debe Seleccionar el tipo de responsable", "Validar Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }

            if (this.cboColaborador.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe Seleccionar un Colaborador", "Validar Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar el Sustento Respectivo", "Validar Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSustento.Focus();
                this.txtSustento.Select();
                return;
            }

            //=========================================================
            //--Validar que el mismo usuario no pueda habilitarse
            //=========================================================
            if (clsVarGlobal.User.idUsuario.ToString()==this.cboColaborador.SelectedValue.ToString())
            {
                MessageBox.Show("El Mismo Usuario no Puede Habilitarse", "Validar Habilitación de Caja y Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            
            //=========================================================
            //--Asignar datos para Registrar
            //=========================================================
            int nAgeRes = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            int nColRes = Convert.ToInt32(this.cboColaborador.SelectedValue.ToString());
            string cSust = this.txtSustento.Text.Trim();
            int idTepResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            //=========================================================
            //--Registrar Habilitación de caja cerrada
            //=========================================================
            if (this.chcApeCaja.Checked)
            {               
                if (ValidarCierreOpe()=="ERROR")
                {
                    return;
                }

                var Msg = MessageBox.Show("Esta Seguro de Aperturar su Caja?...", "Aperturar Caja Cerrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }

                clsCNControlOpe RegApeCajCerra = new clsCNControlOpe();
                string cRpta = RegApeCajCerra.RegApeCajaCerrada(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                                                                nColRes, nAgeRes, cSust,1,idTepResCaj);
                if (cRpta == "OK")
                {
                    MessageBox.Show("La Apertura de la Caja, se Realizó Correctamente...", "Aperturar Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(cRpta, "Aperturar Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //=========================================================
            //--Registrar Habilitación de Corte Fraccionario
            //=========================================================
            if (this.chcCorteFracc.Checked)
            {
                if (ValidarCorte()=="0")
                {
                    return;
                }

                var Msg = MessageBox.Show("Está Seguro de Habilitar su Billetaje?...", "Aperturar Caja Cerrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }

                clsCNControlOpe RegHabCor = new clsCNControlOpe();
                string cRpta = RegHabCor.RegApeCajaCerrada(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                                                                nColRes, nAgeRes, cSust, 2, idTepResCaj);
                if (cRpta == "OK")
                {
                    MessageBox.Show("La Habilitación del Billetaje, se Realizó Correctamente...", "Aperturar Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(cRpta, "Habilitar Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.btnAceptar.Enabled = false;
        }

        private void grbBase2_Enter(object sender, EventArgs e)
        {

        }

        private void chcCorteFracc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcCorteFracc.Checked)
            {
                this.btnAceptar.Enabled = true;
                this.chcApeCaja.Checked = false;
            }
            else
            {
                this.btnAceptar.Enabled = false;
                this.chcApeCaja.Checked = false;
            }
        }

        private string ValidarCorte()
        {
            string msge = "";
            int nAgeRes = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            int nColRes = Convert.ToInt32(this.cboColaborador.SelectedValue.ToString());
            clsCNControlOpe ValCorteFra = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cRpta = ValCorteFra.ValAutCorteFracc(clsVarGlobal.dFecSystem, nColRes, nAgeRes, 1, ref msge, idTipResCaj);
            if (msge == "OK")
            {
                if (cRpta == "0")
                {
                    MessageBox.Show("No tiene Billetaje Registrado", "Validar Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return cRpta;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return cRpta;
            }
            return cRpta;
        }

        private string ValidarCierreOpe()
        {
            string msge = "";
            int nAgeRes = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            int nColRes = Convert.ToInt32(this.cboColaborador.SelectedValue.ToString());
            clsCNControlOpe ValCorteFra = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cRpta = ValCorteFra.ValAutCorteFracc(clsVarGlobal.dFecSystem, nColRes, nAgeRes, 2, ref msge, idTipResCaj);
            if (msge == "OK")
            {
                switch (cRpta)
                {
                    case "0":
                        MessageBox.Show("No ha Registrado su Caja", "Validar Caja por Operador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return "ERROR";
                    case "A":
                        MessageBox.Show("Su Caja no se Encuentra Cerrado", "Validar Caja por Operador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return "ERROR";
                    default:
                        return "OK";
                }                
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Caja por Operador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR";
            }            
        }


       
        private void cboTipResponsableCaja1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cboTipResponsableCaja1.SelectedIndex > -1  )
            {
                string cTxtTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                if (!cTxtTipResCaj.Equals("System.Data.DataRowView"))
                {
                    string idTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                    int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                    ListarColAgencia(idTipResCaj,idAgencia);
                    cboColaborador.SelectedIndex = -1;
                }
               

            }
        }
        private void ListarColAgencia(string cTipRes, int idAge)
        {
      
            string msg = "";
            DateTime dtFecConsulta = clsVarGlobal.dFecSystem;
            clsCNControlOpe LisColAge = new clsCNControlOpe();

            DataTable tbColAge = LisColAge.LisRespHab(5, idAge, cTipRes, clsVarGlobal.User.idUsuario, ref msg, dtFecConsulta);

            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
        }
    }
}
