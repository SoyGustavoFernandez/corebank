using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRegistroCheques : frmBase
    {
        private int nIdChequeBco = 0;
        private int nIdCuentaInst = 0;
        private int nNroInicial = 0;
        private int nCantCheques = 0;
        clsCNMovimientoBanco objMov = new clsCNMovimientoBanco();

        public frmRegistroCheques()
        {
            InitializeComponent();
        }

        private void frmRegistroCheques_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            cboMoneda.SelectedValue = -1;
            Habilitar(3);
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst frmBuscar = new frmBusquedaCuentaInst();
            frmBuscar.ShowDialog();
            if (frmBuscar.pcNumeroCuenta == null) return;
            nIdCuentaInst = frmBuscar.pidCuentaInstitucion;
            this.cboEntidad.CargarEntidades(frmBuscar.pidTipoEntidad);
            this.cboEntidad.SelectedValue = frmBuscar.pidEntidad;
            this.txtNroCuenta.Text = frmBuscar.pcNumeroCuenta;
            this.cboMoneda.SelectedValue = frmBuscar.pidMoneda;
            LlenarGridViewCheques();
            Habilitar(1);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (txtNroCuenta.Text == "")
            {
                MessageBox.Show("Seleccione una cuenta primero.", "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgTalonarios.Rows.Count>0)
            {             
                this.txtNroInicial.Text = (Convert.ToInt32(dtgTalonarios.Rows[dtgTalonarios.Rows.Count-1].Cells["nNroFinal"].Value)+1).ToString().PadLeft(14,'0');
            }
            else
            {
                this.txtNroInicial.Text = "1".PadLeft(14, '0');
            }
            Habilitar(2);
            txtNroInicial.Enabled = true;
            this.txtNroInicial.Focus();
            txtNroInicial.SelectAll();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string cMsje = Validar();
            txtNroInicial.Enabled = false;
            if (cMsje == "")
            {
                clsCNMovimientoBanco chequeBco = new clsCNMovimientoBanco();
                DataTable dtGuardarChequeBco = chequeBco.GuardarChequeBco(nIdChequeBco, nIdCuentaInst,
                                    Convert.ToInt32(txtNroInicial.Text),
                                    Convert.ToInt32(txtCantCheques.Text),
                                    Convert.ToInt32(txtNumFinal.Text));
                if (dtGuardarChequeBco.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dtGuardarChequeBco.Rows[0]["cMsje"].ToString(), "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(1);
                    LlenarGridViewCheques();
                }
                else
                {
                    MessageBox.Show(dtGuardarChequeBco.Rows[0]["cMsje"].ToString(), "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(cMsje, "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Habilitar(1);
            txtNroInicial.Enabled = false;
        }

        private void txtNroInicial_TextChanged(object sender, EventArgs e)
        {
           nNroInicial=(txtNroInicial.Text=="") ? 1 : Convert.ToInt32(txtNroInicial.Text);
           nCantCheques = (txtCantCheques.Text == "") ? 0 : Convert.ToInt32(txtCantCheques.Text);
           txtNumFinal.Text = CalculaNroFinal(nNroInicial, nCantCheques).ToString().PadLeft(14,'0');           
        }

        private void txtCantCheques_TextChanged(object sender, EventArgs e)
        {
            nNroInicial = (txtNroInicial.Text == "") ? 1 : Convert.ToInt32(txtNroInicial.Text);
            nCantCheques = (txtCantCheques.Text == "") ? 0 : Convert.ToInt32(txtCantCheques.Text);
            txtNumFinal.Text = CalculaNroFinal(nNroInicial, nCantCheques).ToString().PadLeft(14, '0'); 
        }    

        private void txtNroInicial_Leave(object sender, EventArgs e)
        {
            if (txtCantCheques.Enabled)
            {
                txtNroInicial.Text = txtNroInicial.Text.PadLeft(14, '0');
            }
        }

        int CalculaNroFinal(int nNroInicial, int nCantCheques)
        {
            int resultado = 0;
            resultado = nNroInicial + nCantCheques - 1;
            if (resultado < 0 || nCantCheques == 0) return 0;
            else
            {
                return resultado;
            }
        }

        string Validar()
        {
            string cMsje = "";

            if (string.IsNullOrEmpty(txtCantCheques.Text))
            {
                cMsje = "Ingrese el numero de cheques del talonario.";
            }
            for (int i = 0; i < dtgTalonarios.Rows.Count; i++)
            {
                if (Convert.ToString(dtgTalonarios.Rows[i].Cells["lVigente"].Value) == "VIGENTE")
                {
                    cMsje = "El(los) Talonario(s) existente(s) deben estar en estado TERMINADO";
                }
            }
            return cMsje;
        }

        void LlenarGridViewCheques()
        {
            DataTable dtTalonarios = objMov.VerificarExisteTalonario(nIdCuentaInst);
            dtgTalonarios.DataSource = dtTalonarios;
            FormatoDataGridView();
        }

        void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) //nuevo o editar
            {
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnBuscarCuenta.Enabled = true;
                this.grbDatosCheques.Enabled = false;
            }
            else if (nOpcion == 2)//cancelar o Grabar
            {
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnBuscarCuenta.Enabled = false;
                this.grbDatosCheques.Enabled = true;

            }
            else if (nOpcion == 3)// inicio
            {
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = false;

            }

        }

        void FormatoDataGridView()
        {
            //DataGridViewColumn column = new DataGridViewColumn();
            //column.Name = "nNroTalonario";
            //column.HeaderText = "Nro. Talonario";
            //column.CellTemplate = new  DataGridViewTextBoxCell();
            //dtgTalonarios.Columns.Insert(1,column);
            //dtgTalonarios.Columns["nNroTalonario"].ValueType = typeof(Int32);

            //for (int i = 0; i < dtgTalonarios.Rows.Count;i++)
            //{               
            //    dtgTalonarios.Rows[i].Cells["nNroTalonario"].Value = i + 1;
            //}

            dtgTalonarios.Columns["nNroTalonario"].Visible = true;
            dtgTalonarios.Columns["idChequeBco"].Visible = false;
            dtgTalonarios.Columns["nNroActual"].Visible = false;
            dtgTalonarios.Columns["nNroInicial"].Visible = true;
            dtgTalonarios.Columns["nNroFinal"].Visible = true;
            dtgTalonarios.Columns["lVigente"].Visible = true;

            dtgTalonarios.Columns["nNroTalonario"].HeaderText = "Nro. Talonario";
            dtgTalonarios.Columns["nNroInicial"].HeaderText = "Nro. Inicio";
            dtgTalonarios.Columns["nNroFinal"].HeaderText = "Nro. Fin";
            dtgTalonarios.Columns["lVigente"].HeaderText = "Estado";
                        
        }

        void LimpiarCampos()
        {
            txtNroInicial.Text = "";
            txtCantCheques.Text = "";
            txtNumFinal.Text = "";
        }
    }
}
