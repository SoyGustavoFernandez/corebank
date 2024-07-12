using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmAprobNotaSalida : frmBase
    {

        #region Variables Globales

        //Declarar variables globales
        private const string cTituloMensajes = "Aprobación y denegación de notas de salida";
        private clsCNNotaSalida objServNotSal = new clsCNNotaSalida();
        private List<clsNotaSalida> lstNotaSalida;

        #endregion

        #region Eventos

        //Colocar los eventos de los controles del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            IniForm();
        }

        private void btnBusqNotSalida_Click(object sender, EventArgs e)
        {
            string cEstLog = Convert.ToInt32(EstLog.SOLICITADO).ToString();

            lstNotaSalida = objServNotSal.CNListarNotaSalida(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, Convert.ToInt32(cboAgencia.SelectedValue), cEstLog, 0);

            if (lstNotaSalida.Count == 0)
            {
                LimpiarControles();
            }
            else
            {
                dtgNotSalida.DataSource = lstNotaSalida;
                FormatoDtgNotSalida();
                dtgNotSalida.Rows[0].Selected = true;
                btnAprobar.Enabled = true;
                btnDenegar.Enabled = true;
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            int idEstLog = Convert.ToInt16(EstLog.APROBADO);
            if (!Validar()) return;

            clsNotaSalida objNotaSalida = (clsNotaSalida)dtgNotSalida.SelectedRows[0].DataBoundItem;
            objNotaSalida.idEstadoLog = idEstLog;
            objNotaSalida.idUsuAprob = clsVarGlobal.User.idUsuario;
            objNotaSalida.dFechaAprobacion = clsVarGlobal.dFecSystem;
            objNotaSalida.idAgenciaAprob = clsVarGlobal.nIdAgencia;
            clsDBResp objDBResp = objServNotSal.CNAprobDenegNotaSalida(objNotaSalida);
            if (objDBResp.nMsje == 0)
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAprobar.Enabled = false;
                btnDenegar.Enabled = false;
                btnBusqNotSalida.PerformClick();
            }
            else
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            int idEstLog = Convert.ToInt16(EstLog.DENEGADO);

            clsNotaSalida objNotaSalida = (clsNotaSalida)dtgNotSalida.SelectedRows[0].DataBoundItem;
            objNotaSalida.idEstadoLog = idEstLog;
            objNotaSalida.idUsuAprob = clsVarGlobal.User.idUsuario;
            objNotaSalida.dFechaAprobacion = clsVarGlobal.dFecSystem;
            objNotaSalida.idAgenciaAprob = clsVarGlobal.nIdAgencia;
            clsDBResp objDBResp = objServNotSal.CNAprobDenegNotaSalida(objNotaSalida);
            if (objDBResp.nMsje == 0)
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAprobar.Enabled = false;
                btnDenegar.Enabled = false;
                btnBusqNotSalida.PerformClick();
            }
            else
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgNotSalida_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNotSalida.SelectedRows.Count > 0 )
            {
                var objNotaSalida = dtgNotSalida.SelectedRows[0].DataBoundItem as clsNotaSalida;
                txtNumNS.Text = objNotaSalida.idNotaSalida.ToString();
                cboAgeNS.SelectedValue = objNotaSalida.idAgenciaReg;
                txtAlmacen.Text = objNotaSalida.cNombreAlmacen;
                txtUsuReg.Text = objNotaSalida.cUsuReg;
                txtUsuAprob.Text = objNotaSalida.cUsuAprob;
                dtpFechaNS.Value = objNotaSalida.dFechaRegistro;
                txtActividad.Text = objNotaSalida.cActividadLog;
                dtgItems.DataSource = typeof(List<clsDetNotaSalida>);
                dtgItems.DataSource = objNotaSalida.LstDetNotSalida;
                FormatoDtgDetNotSalida();
                if (objNotaSalida.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO))
                {
                    btnAprobar.Enabled = true;
                    btnDenegar.Enabled = true;
                }
                else
                {
                    btnAprobar.Enabled = false;
                    btnDenegar.Enabled = false;
                    dtgItems.ReadOnly = true; 
                }
            }
        }

        private void dtgItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dtgItems.Rows)
            {
                row.Cells["cProducto"].Value = ((clsCatalogo)row.Cells["objCatalogo"].Value).cProducto;
            }
        }

        private void dtgItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgItems.CurrentRow != null)
                {
                    clsDetNotaSalida objDetNotSalida = (clsDetNotaSalida)dtgItems.CurrentRow.DataBoundItem;
                    if (objDetNotSalida.nCantidadApro > objDetNotSalida.nCantidadSol)
                    {
                        MessageBox.Show("La cantidad aprobada no puede ser mayor a la cantidad solicitada", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtgItems.CurrentRow.Cells["nCantidadApro"].Value = 0m;
                    }
                }
            }
        }

        private void dtgItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgItems.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgItems.CurrentRow.Cells["nCantidadApro"].EditedFormattedValue.ToString()))
                {
                    dtgItems.EditingControl.Text = "0";
                    return;
                }
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || Convert.ToInt32(e.KeyChar).In(8,13,46))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmAprobNotaSalida()
        {
            InitializeComponent(); 
        }

        private void IniForm()
        {
            
            btnAprobar.Enabled = false;
            btnDenegar.Enabled = false;
            btnBusqNotSalida.Enabled = true;

            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencia.Enabled = true;
                cboAgencia.SelectedValue = 0;
            }
            else
            {
                cboAgencia.Enabled = false;
                cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            }

            dtpFechaIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;

        }

        private bool Validar()
        {
            if (dtgNotSalida.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la nota de salida a aprobar o denegar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsNotaSalida objNotSalida = (clsNotaSalida)dtgNotSalida.SelectedRows[0].DataBoundItem;

            decimal cantidad = 0;
            foreach (clsDetNotaSalida item in objNotSalida.LstDetNotSalida)
            {
                cantidad += Convert.ToDecimal(item.nCantidadApro);
            }
            if (cantidad == 0)
            {
                MessageBox.Show("La cantidad Total a Aprobar no puede ser CERO", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string msjItem = string.Empty;


            var lstItemsSinStock = objNotSalida.LstDetNotSalida.Where(x => x.nStock < x.nCantidadApro).ToList();
            foreach (clsDetNotaSalida item in lstItemsSinStock)
            {
                msjItem = string.Empty;
                msjItem += "La cantidad Aprobada es mayor al stock del item : " + item.objCatalogo.cProducto + ".\n";
                MessageBox.Show(msjItem, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            msjItem = "";
            var lstItemsNoValid = objNotSalida.LstDetNotSalida.Where(x => x.nCantidadApro == 0 && x.nStock > 0).ToList();
            foreach (clsDetNotaSalida item in lstItemsNoValid)
            {
                msjItem += "La cantidad Aprobada del Item : " + item.objCatalogo.cProducto + " es 0.\n";
            }

            if (msjItem != "")
            {
                msjItem += " \n ¿Desea Continuar?";
                DialogResult dRes = MessageBox.Show(msjItem, cTituloMensajes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes != DialogResult.Yes)
                {
                    return false;
                }
            }
            

            
            return true;
        }

        private void LimpiarControles()
        {
            //Asignar los valores de inicio
            btnAprobar.Enabled = false;
            btnDenegar.Enabled = false;
            dtgNotSalida.DataSource = typeof(List<clsNotaSalida>);
            dtgItems.DataSource = typeof(List<clsDetNotaSalida>);
            txtNumNS.Clear();
            txtUsuReg.Clear();
            txtActividad.Clear();
            txtUsuAprob.Clear();
            cboAgeNS.SelectedIndex = -1;
        }

        private void FormatoDtgNotSalida()
        {
            foreach (DataGridViewColumn column in dtgNotSalida.Columns)
            {
                column.Visible = false;
            }

            dtgNotSalida.Columns["idNotaSalida"].Visible = true;
            dtgNotSalida.Columns["cNombreAlmacen"].Visible = true;
            dtgNotSalida.Columns["cUsuReg"].Visible = true;
            dtgNotSalida.Columns["dFechaRegistro"].Visible = true;
            dtgNotSalida.Columns["cEstLog"].Visible = true;

            dtgNotSalida.Columns["idNotaSalida"].HeaderText = "Nro. NS";
            dtgNotSalida.Columns["cNombreAlmacen"].HeaderText = "Almacén";
            dtgNotSalida.Columns["cUsuReg"].HeaderText = "Usu. Registro";
            dtgNotSalida.Columns["dFechaRegistro"].HeaderText = "Fec. Registro";
            dtgNotSalida.Columns["cEstLog"].HeaderText = "Estado";

            dtgNotSalida.Columns["idNotaSalida"].FillWeight = 10;
            dtgNotSalida.Columns["cNombreAlmacen"].FillWeight = 37;
            dtgNotSalida.Columns["cUsuReg"].FillWeight = 23;
            dtgNotSalida.Columns["cEstLog"].FillWeight = 15;
            dtgNotSalida.Columns["dFechaRegistro"].FillWeight = 15;
        }

        private void FormatoDtgDetNotSalida()
        {
            dtgItems.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgItems.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgItems.Columns["cUnidMedida"].Visible = true;
            dtgItems.Columns["cProducto"].Visible = true;
            dtgItems.Columns["nCantidadSol"].Visible = true;
            dtgItems.Columns["nCantidadApro"].Visible = true;
            dtgItems.Columns["nStock"].Visible = true;

            dtgItems.Columns["cUnidMedida"].HeaderText = "Unidad";
            dtgItems.Columns["cProducto"].HeaderText = "Producto";
            dtgItems.Columns["nCantidadSol"].HeaderText = "Cant. Solicitada";
            dtgItems.Columns["nCantidadApro"].HeaderText = "Cant. Aprobada";
            dtgItems.Columns["nStock"].HeaderText = "Stock";

            dtgItems.Columns["cUnidMedida"].DisplayIndex = 0;
            dtgItems.Columns["cProducto"].DisplayIndex = 1;
            dtgItems.Columns["nStock"].DisplayIndex = 2;
            dtgItems.Columns["nCantidadSol"].DisplayIndex = 3;
            dtgItems.Columns["nCantidadApro"].DisplayIndex = 4;

            dtgItems.Columns["cUnidMedida"].FillWeight = 45;
            dtgItems.Columns["cProducto"].FillWeight = 200;
            dtgItems.Columns["nStock"].FillWeight = 50;
            dtgItems.Columns["nCantidadSol"].FillWeight = 60;
            dtgItems.Columns["nCantidadApro"].FillWeight = 60;

            dtgItems.Columns["nCantidadApro"].ReadOnly = false;
        }

        #endregion
  
    }
}
