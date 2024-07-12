using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmReasinarCartera : frmBase
    {
        clsCNCarteraRecupera cnCarteraRecupera = new clsCNCarteraRecupera();
        DataTable dtCarteraOrigen = new DataTable();
        DataTable dtCarteraDestino = new DataTable();
        int totalSeleccionados = 0;
           

        public frmReasinarCartera()
        {
            InitializeComponent();
        }

        private void cboUsuRecuperadoresOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadoresOrigen.SelectedIndex >= 0)
            {
                cargarDatosOrigen();
            }
        }

        private void cboUsuRecuperadoresDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadoresDestino.SelectedIndex >= 0)
            {
                cargarDatosDestino();
            }
        }

        public void limpiarFormulario()
        {
            this.cboUsuRecuperadoresDestino.SelectedIndex = -1;
            this.cboUsuRecuperadoresOrigen.SelectedIndex = -1;
            dtCarteraOrigen.Clear();
            dtgCarteraOrigen.DataSource = dtCarteraOrigen;
            formatoGridCarteraOrigen();
            dtCarteraDestino.Clear();            
            dtgCarteraDestino.DataSource = dtCarteraDestino;
            lblNroCreditosOrigen.Text = "Crédito(s)";
            lblNroCreditosDestino.Text = "Crédito(s)";  
        }

        public void cargarDatosOrigen()
        {
            DataRow[] rowSeleccionadas = null;
            if (totalSeleccionados > 0) 
            {
                rowSeleccionadas = dtCarteraOrigen.Select("lSeleCta=true");
            }
            dtgCarteraOrigen.ReadOnly = false;
            int idUsuario = Convert.ToInt32(cboUsuRecuperadoresOrigen.SelectedValue);
            dtCarteraOrigen = cnCarteraRecupera.ListarCarteraRecuperacionByUsu(idUsuario, conBusUbig1.nIdNodo, Convert.ToInt32(cboAgencia1.SelectedValue));
            dtCarteraOrigen.Columns["lSeleCta"].ReadOnly = false;
            dtgCarteraOrigen.DataSource = dtCarteraOrigen;
            formatoGridCarteraOrigen();
            //=========================================================
            //Merge
            if (rowSeleccionadas != null) 
            {
                foreach (DataRow row in rowSeleccionadas)
                {
                    bool lEncontrado = false;
                    foreach (DataRow rowOrigen in dtCarteraOrigen.Rows)
                    {
                        if (Convert.ToInt32(row["idAsigCartRecuperaciones"]) == Convert.ToInt32(rowOrigen["idAsigCartRecuperaciones"]))
                        {
                            rowOrigen["lSeleCta"] = true;
                            lEncontrado = true;
                            break;
                        }
                    }
                    if (!lEncontrado)
                    {
                        dtCarteraOrigen.ImportRow(row);
                    }
                }
            }
            //=========================================================
            lblNroCreditosOrigen.Text = dtCarteraOrigen.Rows.Count + " Crédito(s)";
                  
        }

        public void cargarDatosDestino()
        {            
            int idUsuario = Convert.ToInt32(cboUsuRecuperadoresDestino.SelectedValue);
            dtCarteraDestino = cnCarteraRecupera.ListarCarteraRecuperacionByUsu(idUsuario, 173, 0);
            dtCarteraDestino.Columns["lSeleCta"].ReadOnly = false;
            dtgCarteraDestino.DataSource = dtCarteraDestino;
            lblNroCreditosDestino.Text = dtCarteraDestino.Rows.Count + " Crédito(s)";            
        }

        private void frmReasinarCartera_Load(object sender, EventArgs e)
        {
            this.cboUsuRecuperadoresOrigen.CargarUsuariosReasignacion();
            this.cboUsuRecuperadoresDestino.SelectedIndex = -1;
            this.cboUsuRecuperadoresOrigen.SelectedIndex = -1;
            conBusUbig1.cargar();
            conBusUbig1.cargarUbigeo(173);
            conBusUbig1.cboPais.Enabled = false;
            conBusUbig1.cboDepartamento.SelectedIndexChanged += conBusUbig1_SelectedIndexChanged;
            conBusUbig1.cboProvincia.SelectedIndexChanged += conBusUbig1_SelectedIndexChanged;
            conBusUbig1.cboDistrito.SelectedIndexChanged += conBusUbig1_SelectedIndexChanged;
            conBusUbig1.cboAnexo.SelectedIndexChanged += conBusUbig1_SelectedIndexChanged;            
            
        }

        void conBusUbig1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosOrigen();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarFormulario();  
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                DialogResult drResultadoReasignar = MessageBox.Show("Esta seguro de realizar la reasignación?", "Reasignación de cartera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultadoReasignar == DialogResult.Yes)
                {
                    DataTable dtTempCarteraOrigen = dtCarteraOrigen.Copy();
                    dtTempCarteraOrigen.Columns.Remove("cNombre");
                    dtTempCarteraOrigen.Columns.Remove("nUbigeo");
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtTempCarteraOrigen);
                    string xml = ds.GetXml();
                    DataTable dtResultado = cnCarteraRecupera.reasignarCartera(xml, Convert.ToInt32(cboUsuRecuperadoresOrigen.SelectedValue), Convert.ToInt32(cboUsuRecuperadoresDestino.SelectedValue), clsVarGlobal.User.idUsuario, txtMotivoTransferencia.Text.Trim());
                    if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Se realizó la reasignación correctamente.", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        totalSeleccionados = 0;
                        cargarDatosOrigen();
                        cargarDatosDestino();
                        txtMotivoTransferencia.Text = "";
                    }                    
                }
            }
            
        }

        private bool Validacion()
        {
            if (Convert.ToInt32(cboUsuRecuperadoresOrigen.SelectedValue) == Convert.ToInt32(cboUsuRecuperadoresDestino.SelectedValue))
            {
                MessageBox.Show("No puede realizar la reasignacion al mismo usuario", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboUsuRecuperadoresOrigen.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el recuperador origen.", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (totalSeleccionados <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un credito.", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboUsuRecuperadoresDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el recuperador destino.", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMotivoTransferencia.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar el motivo.", "Reasignación de cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;            
            }
            return true;
        }

        private void dtgCarteraOrigen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((bool)dtgCarteraOrigen.Rows[e.RowIndex].Cells["lSeleCta"].Value)
                {
                    totalSeleccionados++;
                    seleccionarCreditoMismoCliente(Convert.ToInt32(dtgCarteraOrigen.Rows[e.RowIndex].Cells["idCli"].Value), true);
                }
                else
                {
                    totalSeleccionados--;
                    seleccionarCreditoMismoCliente(Convert.ToInt32(dtgCarteraOrigen.Rows[e.RowIndex].Cells["idCli"].Value), false);
                }
            }
        }
        
        private void seleccionarCreditoMismoCliente(int idCliente, bool seleccionar)
        {
            foreach (DataRow row in dtCarteraOrigen.Rows)
            {
                if (idCliente == Convert.ToInt32(row["idCli"]))
                { 
                    row["lSeleCta"] = seleccionar;
                    if (seleccionar)
                    {
                        totalSeleccionados++;
                    }
                    else
                    {
                        totalSeleccionados--;
                    }
                }
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosOrigen();
        }


        private void formatoGridCarteraOrigen()
        {
            foreach (DataGridViewColumn columna in dtgCarteraOrigen.Columns)
            {
                columna.Visible = false;
            }

            dtgCarteraOrigen.Columns["lSeleCta"].Visible = true;
            dtgCarteraOrigen.Columns["idCuenta"].Visible = true;
            dtgCarteraOrigen.Columns["idCli"].Visible = true;
            dtgCarteraOrigen.Columns["cNombre"].Visible = true;
            dtgCarteraOrigen.Columns["nAtraso"].Visible = true;
            dtgCarteraOrigen.Columns["nCapitalDesembolso"].Visible = true;
            dtgCarteraOrigen.Columns["nSaldoCapital"].Visible = true;
            dtgCarteraOrigen.Columns["nUbigeo"].Visible = true;

            dtgCarteraOrigen.Columns["lSeleCta"].HeaderText = "";
            dtgCarteraOrigen.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCarteraOrigen.Columns["idCli"].HeaderText = "Cod. Cli.";
            dtgCarteraOrigen.Columns["cNombre"].HeaderText = "Nombre";
            dtgCarteraOrigen.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCarteraOrigen.Columns["nCapitalDesembolso"].HeaderText = "Desembolso";
            dtgCarteraOrigen.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";
            dtgCarteraOrigen.Columns["nUbigeo"].HeaderText = "Ubigeo";
            
            dtgCarteraOrigen.Columns["lSeleCta"].Width = 30;
            dtgCarteraOrigen.Columns["idCuenta"].Width = 50;
            dtgCarteraOrigen.Columns["idCli"].Width = 50;
            dtgCarteraOrigen.Columns["cNombre"].Width = 120;
            dtgCarteraOrigen.Columns["nAtraso"].Width = 50;
            dtgCarteraOrigen.Columns["nCapitalDesembolso"].Width = 50;
            dtgCarteraOrigen.Columns["nSaldoCapital"].Width = 50;
            dtgCarteraOrigen.Columns["nUbigeo"].Width = 50;
            
        }
        
    }
}
