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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmControlSolApertura : frmBase
    {
        private clsCNRechazoSolApe objSolApe = new clsCNRechazoSolApe();
        private DataTable dtSolApe = new DataTable();
        private int p_idCta = 0;
        clsCNDeposito clsDeposito = new clsCNDeposito();

        public frmControlSolApertura()
        {
            InitializeComponent();
        }

        private void frmControlSolApertura_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dtgIntervinientes.AutoGenerateColumns = false;
        }
        private void CargarDatos()
        {
            dtSolApe = objSolApe.CNListSolApe(clsVarGlobal.nIdAgencia);
            dtgListSolicitudes.DataSource = dtSolApe;
            if (dtSolApe.Rows.Count>0)
            {
                formatoGrid();
                HabilitarGridDetalle(true);
            }
           
        }
        private void formatoGrid()
        {   
            dtgListSolicitudes.Columns["Row"].Visible= true;
            dtgListSolicitudes.Columns["cNroCuenta"].Visible= true;
            dtgListSolicitudes.Columns["idCuenta"].Visible= false;
            dtgListSolicitudes.Columns["cProducto"].Visible= true;
            dtgListSolicitudes.Columns["idmoneda"].Visible = false;
            dtgListSolicitudes.Columns["cnombre"].Visible = false;
            dtgListSolicitudes.Columns["idTipoCuenta"].Visible = false;
            dtgListSolicitudes.Columns["nMontoDeposito"].Visible= true;

            dtgListSolicitudes.Columns["Row"].HeaderText = "Nro.";
            dtgListSolicitudes.Columns["cNroCuenta"].HeaderText = "Cuenta";
            dtgListSolicitudes.Columns["cProducto"].HeaderText = "Producto";
            dtgListSolicitudes.Columns["nMontoDeposito"].HeaderText = "Monto";
            dtgListSolicitudes.Columns["lIndAte"].HeaderText = "X";
            dtgListSolicitudes.Columns["Row"].Width = 10;
            dtgListSolicitudes.Columns["cNroCuenta"].Width = 80;
            dtgListSolicitudes.Columns["cProducto"].Width = 80;
            dtgListSolicitudes.Columns["nMontoDeposito"].Width = 40;
            dtgListSolicitudes.Columns["lIndAte"].Width = 20;
        }

        private void dtgListSolicitudes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarControles();
     //       btnRechazar.Enabled = false;
            int fila = e.RowIndex;
            if (dtgListSolicitudes.Rows.Count>0)
            {
                p_idCta = Convert.ToInt32(dtgListSolicitudes.Rows[fila].Cells["idCuenta"].Value.ToString());
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
                //--===================================================================================
                //--ValidarBloqueo de la Cuenta
                //--===================================================================================
                string cMsg = "";
                clsCNOperacionDep clsBloq = new clsCNOperacionDep();
                if (!clsBloq.ValidarBloqueoCta(p_idCta, 11, ref cMsg))
                {
                    MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnRechazar.Enabled = false;
                    return;
                }
                txtNrocuenta.Text = dtgListSolicitudes.Rows[fila].Cells["cNroCuenta"].Value.ToString();
                txtCliente.Text = dtgListSolicitudes.Rows[fila].Cells["cnombre"].Value.ToString();
                txtProducto.Text = dtgListSolicitudes.Rows[fila].Cells["cProducto"].Value.ToString();
                txtMonto.Text = dtgListSolicitudes.Rows[fila].Cells["nMontoDeposito"].Value.ToString();
                cboTipoCuenta.SelectedValue = Convert.ToInt32(dtgListSolicitudes.Rows[fila].Cells["idTipoCuenta"].Value.ToString());
                cboMoneda.SelectedValue = Convert.ToInt32(dtgListSolicitudes.Rows[fila].Cells["idmoneda"].Value.ToString());
                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(p_idCta);
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                }
                else
                {
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                    btnRechazar.Enabled = false;
                    return;
                }
                dtSolApe.Columns["lIndAte"].ReadOnly = false;
           //     btnRechazar.Enabled = true;
                
            }
            
        }
        private void LimpiarControles()
        {
            txtNrocuenta.Clear();
            txtCliente.Clear();
            txtProducto.Clear();
            txtMonto.Text="0.00";
            cboTipoCuenta.SelectedValue =1;
            cboMoneda.SelectedValue = 1;
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            //Validación de que se haya seleccionado al menos una cuenta
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgListSolicitudes.Rows.Count > 0)
            {
                while (fila < this.dtgListSolicitudes.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgListSolicitudes.Rows[fila].Cells["lIndAte"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    MessageBox.Show("Tiene que seleccionar al menos una cuenta","Validación de Control de Solicitud de Apertura",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //Seleccionando sólo las cuentas a rechazar
            DataTable dtSolDenegada = new DataTable();
            dtSolDenegada.Columns.Add("idCuenta",typeof(Int32));
            for (int i = 0; i < dtgListSolicitudes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgListSolicitudes.Rows[i].Cells["lIndAte"].Value.ToString())==true)
                {
                    DataRow dr = dtSolDenegada.NewRow();
                    dr["idCuenta"] = Convert.ToInt32(dtgListSolicitudes.Rows[i].Cells["idCuenta"].Value.ToString());
                    dtSolDenegada.Rows.Add(dr);
                }
            }
            DataSet dsSolDenegada = new DataSet("dsSolDenegada");
            dsSolDenegada.Tables.Add(dtSolDenegada);
            string xmlSolDenegadas = dsSolDenegada.GetXml();
            xmlSolDenegadas = clsCNFormatoXML.EncodingXML(xmlSolDenegadas);
            dsSolDenegada.Tables.Clear();

            int idusuario = clsVarGlobal.User.idUsuario;
            DateTime dFechaAte = clsVarGlobal.dFecSystem;
            //Grabar
            DataTable dtRpta = objSolApe.CNGrabaRechazoSolApe(xmlSolDenegadas, idusuario, dFechaAte);
            if (Convert.ToInt16(dtRpta.Rows[0][0].ToString())==1)
            {
                MessageBox.Show("Los datos se guardaron satisfactoriamente", "Control de Solicitud de Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                CargarDatos();
                btnRechazar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al grabar los datos", "Validación de Control de Solicitud de Apertura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked)
            {
                for (int i = 0; i < dtSolApe.Rows.Count; i++)
                {
                    dtSolApe.Columns["lIndAte"].ReadOnly = false;
                    dtgListSolicitudes.Rows[i].Cells["lIndAte"].Value = true;
                }
                dtgListSolicitudes.Refresh();
            }
            else
            {
                this.chcBase1.Checked = false;
                btnRechazar.Enabled = false;
                foreach (DataRow NRow in dtSolApe.Rows)
                {
                    NRow["lIndAte"] = false;
                }
                dtgListSolicitudes.Refresh();

            }
        }
        public void HabilitarGridDetalle(Boolean bVal)
        {
            // dtValorados.
            this.dtgListSolicitudes.ReadOnly = !bVal;
            this.dtgListSolicitudes.Columns["Row"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["cNroCuenta"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["cProducto"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["idmoneda"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["cnombre"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["idTipoCuenta"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["nMontoDeposito"].ReadOnly = bVal;
            this.dtgListSolicitudes.Columns["lIndAte"].ReadOnly = !bVal;     
            for (int i = 0; i < this.dtgListSolicitudes.Rows.Count; i++)
            {
                this.dtgListSolicitudes.Rows[i].Cells["lIndAte"].ReadOnly = !bVal;
            }

        }

        private void dtgListSolicitudes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dtgListSolicitudes.IsCurrentCellDirty)
            {
                dtgListSolicitudes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgListSolicitudes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgListSolicitudes.Rows.Count > 0)
            {
                while (fila < this.dtgListSolicitudes.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgListSolicitudes.Rows[fila].Cells["lIndAte"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    btnRechazar.Enabled = false;
                }
                else
                {
                    btnRechazar.Enabled = true;
                }
            }
        }

        private void dtgListSolicitudes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgListSolicitudes.Rows.Count > 0)
            {
                while (fila < this.dtgListSolicitudes.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgListSolicitudes.Rows[fila].Cells["lIndAte"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    btnRechazar.Enabled = false;
                }
                else
                {
                    btnRechazar.Enabled = true;
                }
            }
        }
    }
}
