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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmSalidaGarantia : frmBase
    {
        #region Variable Globales

        int idGarantia;
        clsCNGarantia cngarantia = new clsCNGarantia();
        DataSet dsGarantias;

        #endregion

        public frmSalidaGarantia()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            cargarMotivos();
            cargarModalidad();            
            habilitarTodosControles(false);
            this.btnEditarSalida.Enabled = false;            
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli != 0)
            {
                cargarGarantias();
            }
            else
            {
                btnCancelar1.PerformClick();
            }
        }

        private void dtgBase1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarGarantia();
        }

        private void dtgBase1_SelectionChanged(object sender, EventArgs e)
        {
            seleccionarGarantia();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            idGarantia = 0;
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            dtgGarantias.DataSource=null;
            dtgPropietarios.DataSource = null;           
            habilitarTodosControles(false);
            this.btnEditarSalida.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var resul = MessageBox.Show("Por favor confirmar el registro de la salida de la garantía", "Salida de Garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul== DialogResult.Yes)
                {
                    var idGarAux = idGarantia;
                    int idTipoGarantia = 0;
                    int idMotivo=(int)this.cboMotivoSalida.SelectedValue;
                    int idModalidad=this.cboModalidadVEnta.Enabled?(int)this.cboModalidadVEnta.SelectedValue:0;

                    var dtResulReg = cngarantia.CNRegistrarSalidaGarantia(
                        idGarantia,
                        idTipoGarantia,
                        clsVarGlobal.dFecSystem,
                        idMotivo,
                        this.txtValorAdjudicacion.nDecValor,
                        this.txtGastoAdjudicacion.nDecValor,
                        this.txtVentaGarantia.nDecValor,
                        this.txtGastoVenta.nDecValor,
                        idModalidad,
                        clsVarGlobal.User.idUsuario);

                    if ((int)dtResulReg.Rows[0][0] == 1)
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Registro de salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(dtResulReg.Rows[0][1].ToString(), "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cargarGarantias();                    
                    foreach (DataGridViewRow item in dtgGarantias.Rows)
                    {
                        if ((int)item.Cells["idGarantia"].Value == idGarAux)
                        {
                            item.Selected = true;
                            dtgGarantias.FirstDisplayedScrollingRowIndex = item.Index;
                        }
                    }                    
                    idGarantia = 0;
                    habilitarTodosControles(false);
                    this.cboMotivoSalida.Enabled = false;                
                }                
            }
        }

        private void cboMotivoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboMotivoSalida.SelectedIndex > -1)
            {
                if ((bool)((DataRowView)cboMotivoSalida.SelectedItem)["lRegVentaGar"] == true)
                {
                    habilitarContolesVenta(true);
                }
                else
                {
                    habilitarContolesVenta(false);                   
                }
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (dtgGarantias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe de seleccionar una garantia por favor", "Validar selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            if ((int)dtgGarantias.SelectedRows[0].Cells["idEstadoGarantia"].Value == 3)
            {
                MessageBox.Show("La garantía seleccionada ya esta liberada", "Validación de salida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                habilitarTodosControles(false);
                return lValida;
            }

            var dtCreditoVigentes = cngarantia.CNValidarGarEstadoCre(idGarantia);

            if (dtCreditoVigentes.Rows.Count > 0)
            {
                var cCodCre = "";
                foreach (DataRow item in dtCreditoVigentes.Rows)
                {
                    cCodCre = cCodCre + Environment.NewLine +  item[0].ToString();
                }
                MessageBox.Show("No puede dar salida a la garantía ya que \n existe créditos vigentes vinculados a la garantía \n Nro(s) de cuenta(s):" + cCodCre, "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                habilitarTodosControles(false);
                return lValida;
            }

            if (this.cboMotivoSalida.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione el motivo de salida", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida; 
            }

            if (this.cboModalidadVEnta.Enabled == true && this.cboModalidadVEnta.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la modalidad de venta de la garantía adjudicada", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }
            if (this.cboModalidadVEnta.Enabled && String.IsNullOrEmpty(this.txtValorAdjudicacion.Text))
            {
                MessageBox.Show("Ingrese el valor de adjudicación", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtValorAdjudicacion.Focus();
                return lValida;
            }
            if (this.cboModalidadVEnta.Enabled && String.IsNullOrEmpty(this.txtGastoAdjudicacion.Text))
            {
                MessageBox.Show("Ingrese gasto de adjudicación", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGastoAdjudicacion.Focus();
                return lValida;
            }
            if (this.cboModalidadVEnta.Enabled && String.IsNullOrEmpty(this.txtVentaGarantia.Text))
            {
                MessageBox.Show("Ingrese la venta de garantía sin impuesto", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtVentaGarantia.Focus();
                return lValida;
            }
            if (this.cboModalidadVEnta.Enabled && String.IsNullOrEmpty(this.txtGastoVenta.Text))
            {
                MessageBox.Show("Ingrese gasto de venta", "Validar créditos vinculados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGastoVenta.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgGarantias.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGarantias.Columns["idCli"].Visible = false;
            dtgGarantias.Columns["cMoneda"].Visible = false;
            dtgGarantias.Columns["idMoneda"].Visible = false; 
            dtgGarantias.Columns["idEstadoGarantia"].Visible = false;

            dtgGarantias.Columns["idGarantia"].HeaderText = "Cod.Gar.";
            dtgGarantias.Columns["cGarantia"].HeaderText = "Descripción";
            dtgGarantias.Columns["dFecRegistro"].HeaderText = "Fec.Reg.";
            dtgGarantias.Columns["cDesGrupo"].HeaderText = "Grupo";
            dtgGarantias.Columns["cClaseGarantia"].HeaderText = "Clase";
            dtgGarantias.Columns["cTipoGarantia"].HeaderText = "Tipo";
            dtgGarantias.Columns["cSimbolo"].HeaderText = "M";
            dtgGarantias.Columns["nMonGarantia"].HeaderText = "Monto";
            dtgGarantias.Columns["cEstadoGarantia"].HeaderText = "Estado";

            dtgGarantias.Columns["idGarantia"].Width = 40;
            dtgGarantias.Columns["cGarantia"].Width = 150;
            dtgGarantias.Columns["dFecRegistro"].Width = 60;
            dtgGarantias.Columns["cDesGrupo"].Width = 60;
            dtgGarantias.Columns["cClaseGarantia"].Width = 70;
            dtgGarantias.Columns["cTipoGarantia"].Width = 120;
            dtgGarantias.Columns["cSimbolo"].Width = 20;
            dtgGarantias.Columns["nMonGarantia"].Width = 60;
            dtgGarantias.Columns["cEstadoGarantia"].Width = 90;

            dtgGarantias.Columns["nMonGarantia"].DefaultCellStyle.Format = "N2";
            dtgGarantias.Columns["nMonGarantia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGarantias.Columns["cSimbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGarantias.Columns["idGarantia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewRow item in dtgGarantias.Rows)
            {
                if ((int)item.Cells["idMoneda"].Value == 1)
                {
                    item.Cells["cSimbolo"].Style.BackColor = Color.Blue;
                }
                else
                {
                    item.Cells["cSimbolo"].Style.BackColor = Color.Green;
                }
                item.Cells["cSimbolo"].Style.ForeColor = Color.White;
            }
        }

        private void formatoGridDetalle()
        {
            foreach (DataGridViewColumn item in dtgPropietarios.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgPropietarios.Columns["nPorcentaje"].Visible=false;

            dtgPropietarios.Columns["idCliGarantia"].HeaderText = "Cod.Cli.Gar.";
            dtgPropietarios.Columns["idGarantia"].HeaderText = "Código Garantía";
            dtgPropietarios.Columns["idCli"].HeaderText = "Código de Cliente";
            dtgPropietarios.Columns["cNombre"].HeaderText = "Nombres";
            dtgPropietarios.Columns["nPorcen"].HeaderText = "%";

            dtgPropietarios.Columns["idCliGarantia"].Width = 100;
            dtgPropietarios.Columns["idGarantia"].Width = 120;
            dtgPropietarios.Columns["idCli"].Width = 120;
            dtgPropietarios.Columns["nPorcen"].Width = 80;

            dtgPropietarios.Columns["nPorcen"].DefaultCellStyle.Format = "0.00%";
            dtgPropietarios.Columns["idCliGarantia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPropietarios.Columns["idGarantia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPropietarios.Columns["idCli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void seleccionarGarantia()
        {
            if (dtgGarantias.SelectedRows.Count > 0)
            {
                idGarantia = (int)dtgGarantias.SelectedRows[0].Cells["idGarantia"].Value;

                var dtPropiestarios = dsGarantias.Tables[1].Clone();

                (from item in dsGarantias.Tables[1].AsEnumerable()
                 where (int)item["idGarantia"] == idGarantia
                 select item).CopyToDataTable(dtPropiestarios, LoadOption.OverwriteChanges);

                dtgPropietarios.DataSource = dtPropiestarios;
                formatoGridDetalle();
                dtgPropietarios.ClearSelection();
            }
        }

        private void cargarGarantias()
        {
            dsGarantias = cngarantia.CNListaGarantiasIdClienteYDetalle(conBusCli1.idCli, 0);

            if (dsGarantias.Tables.Count>0)
            {
                var dtGarantias = dsGarantias.Tables[0];
                if (dtGarantias.Rows.Count>0)
                {
                    dtgGarantias.DataSource = dtGarantias;
                    formatoGrid();
                    btnCancelar1.Enabled = true;
                    btnEditarSalida.Enabled = true;                    
                    dtgGarantias.Focus();                    
                }
                else
                {
                    btnCancelar1.Enabled = true;
                }
            }            
        }
        
        private void cargarMotivos()
        {
            this.cboMotivoSalida.ValueMember="idMotivoSalida";
            this.cboMotivoSalida.DisplayMember="cMotivoSalida";
            this.cboMotivoSalida.DataSource = cngarantia.CNListarMotivoSalida();
        }

        private void cargarModalidad()
        {
            this.cboModalidadVEnta.ValueMember = "idModalidadVentaGarantia";
            this.cboModalidadVEnta.DisplayMember = "cModalidadVentaGarantia";
            this.cboModalidadVEnta.DataSource = cngarantia.CNListarModalidadVentaGarantia();
        }

        private void habilitarContolesVenta(bool lEstado)
        {
            this.txtGastoAdjudicacion.Enabled = lEstado;
            this.txtGastoVenta.Enabled = lEstado;
            this.txtValorAdjudicacion.Enabled = lEstado;
            this.txtVentaGarantia.Enabled = lEstado;
            this.cboModalidadVEnta.Enabled = lEstado;

            this.cboModalidadVEnta.SelectedIndex = -1;
            this.txtGastoAdjudicacion.Text = "";
            this.txtGastoVenta.Text = "";
            this.txtValorAdjudicacion.Text = "";
            this.txtVentaGarantia.Text = "";
        }        
        #endregion        

        private void habilitarTodosControles(Boolean val)
        {
            this.dtgGarantias.Enabled = !val;
            this.cboMotivoSalida.Enabled = val;
            this.cboMotivoSalida.SelectedIndex = -1;            
            habilitarContolesVenta(false);
            this.btnGrabar1.Enabled = val;
            this.btnEditarSalida.Enabled = !val;
            this.btnCancelarSalida.Enabled = val;

        }

        private void btnEditarSalida_Click(object sender, EventArgs e)
        {
            habilitarTodosControles(true);
        }

        private void btnCancelarSalida_Click(object sender, EventArgs e)
        {
            habilitarTodosControles(false);
        }

        private void darFormatoTxtDecimal(txtNumRea txtNR)
        {            
            txtNR.Text = txtNR.nDecValor.ToString("N2");
        }
        private void txtValorAdjudicacion_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtValorAdjudicacion);
        }

        private void txtGastoAdjudicacion_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtGastoAdjudicacion);
        }

        private void txtVentaGarantia_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtVentaGarantia);
        }

        private void txtGastoVenta_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtGastoVenta);
        }

        
    }
}
