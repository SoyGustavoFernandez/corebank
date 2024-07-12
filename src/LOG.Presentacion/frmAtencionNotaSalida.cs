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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using LOG.CapaNegocio;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmAtencionNotaSalida : frmBase
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
            txtSustento.Enabled = false;

            if (clsVarGlobal.User.idAgeCol == 1)
                cboAgencia.Enabled = true;
            else
            {
                cboAgencia.Enabled = false;
                cboAgencia.SelectedValue = clsVarGlobal.User.idAgeCol;
            }
            cboEstadoProcLog.listarEstadoProcesoAdj(5);
        }

        private void btnBusqNotSalida_Click(object sender, EventArgs e)
        {
            string cEstLog = Convert.ToString(cboEstadoProcLog.SelectedValue);//string.Format("{0},{1}", Convert.ToInt16(EstLog.APROBADO),Convert.ToInt16(EstLog.ATENDIDO));
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccionar la Agencia...", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LimpiarControles();

            lstNotaSalida = objServNotSal.CNListarNotaSalida(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, Convert.ToInt32(cboAgencia.SelectedValue), cEstLog, 0);

            if (lstNotaSalida.Count == 0)
            {
                LimpiarControles();
            }
            else
            {
                dtgNotSalida.DataSource = lstNotaSalida;                
                FormatoDtgNotSalida();
                dtgNotSalida.CurrentCell = dtgNotSalida.Rows[0].Cells[0];
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgNotSalida.CurrentRow != null)
            {
                clsNotaSalida objNotSalida = (clsNotaSalida)dtgNotSalida.CurrentRow.DataBoundItem;

                if (objNotSalida.idEstadoLog != Convert.ToInt16(EstLog.ATENDIDO))
                {
                    MessageBox.Show("Nota de salida no ATENDIDA, no se puede imprimir la confirmidad.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtsData = new clsRPTCNLogistica().CNDataAtencionNotaSalida(objNotSalida.idNotaSalida);
                DataTable dtsDetData = new clsRPTCNLogistica().CNDetalleAtencionNotaSalida(objNotSalida.idNotaSalida);
                DataTable dtsRutaRep = new clsRPTCNAgencia().CNRutaLogo();

                List<ReportParameter> paramlist = new List<ReportParameter>();
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
                String cNomAgen = clsVarGlobal.cNomAge;
                String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
                //paramlist.Add(new ReportParameter("cAgencia", cNomAgen, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dtsRutaRep", dtsRutaRep));
                dtslist.Add(new ReportDataSource("dtsData", dtsData));
                dtslist.Add(new ReportDataSource("dtsDetData", dtsDetData));

                string reportpath = "RptAtencionNotaSalida.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione la nota de salida", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            int idEstLog = Convert.ToInt16(EstLog.ATENDIDO);
            if (!Validar())
                return;

            clsNotaSalida objNotaSalida = (clsNotaSalida)dtgNotSalida.SelectedRows[0].DataBoundItem;
            objNotaSalida.idEstadoLog = idEstLog;
            objNotaSalida.idUsuAten = clsVarGlobal.User.idUsuario;
            objNotaSalida.dFechaAten = clsVarGlobal.dFecSystem;
            objNotaSalida.idAgenciaAten = clsVarGlobal.nIdAgencia;
            objNotaSalida.cSustento = txtSustento.Text;
            clsDBResp objDBResp = objServNotSal.CNAtenderNotaSalida(objNotaSalida);
            if (objDBResp.nMsje == 0)
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAtender.Enabled = false;
                btnBusqNotSalida.PerformClick();
            }
            else
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objNotaSalida.idEstadoLog = Convert.ToInt16(EstLog.APROBADO);
                objNotaSalida.LstDetNotSalida.ForEach(x => x.nCantidadAten = 0);
                dtgNotSalida_SelectionChanged(dtgNotSalida, null);
            }
        }     

        private void dtgNotSalida_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNotSalida.SelectedRows.Count > 0)
            {
                clsNotaSalida objNotaSalida = (clsNotaSalida)dtgNotSalida.SelectedRows[0].DataBoundItem;
                txtNumNS.Text = objNotaSalida.idNotaSalida.ToString();
                cboAgeNS.SelectedValue = objNotaSalida.idAgenciaReg;
                txtUsuReg.Text = objNotaSalida.cUsuReg;
                txtUsuAprob.Text = objNotaSalida.cUsuAprob;
                txtAlmacen.Text = objNotaSalida.cNombreAlmacen;
                txtSustento.Text = objNotaSalida.cSustento;
                dtpFechaNS.Value = objNotaSalida.dFechaRegistro;
                txtActividad.Text = objNotaSalida.cActividadLog;
                dtgItems.DataSource = typeof(List<clsDetNotaSalida>);
                dtgItems.DataSource = objNotaSalida.LstDetNotSalida;

                int i = 0;
                foreach (var lista in objNotaSalida.LstDetNotSalida)
                {
                    dtgItems.Rows[i].Cells["nStock"].Value = lista.nStock;
                    i++;
                }
                //clsDetNotaSalida objDetNotSalida = (clsDetNotaSalida)dtgItems.CurrentRow.DataBoundItem;
                //dtgItems.CurrentRow.Cells["nStock"].Value = objDetNotSalida.nStock;
                
                FormatoDtgDetNotSalida();
                
                if (objNotaSalida.idEstadoLog == Convert.ToInt16(EstLog.APROBADO))
                {
                    btnAtender.Enabled = true;                  
                }
                else
                {
                    btnAtender.Enabled = false;
                    dtgItems.ReadOnly = true; 
                }
            }
        }

        private void dtgItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dtgItems.Rows)
            {
                if (row.Cells["objCatalogo"].Value != null)
                {
                    if (dtgItems.Columns.Contains("objCatalogo"))
                    {
                        row.Cells["cProducto"].Value = ((clsCatalogo)row.Cells["objCatalogo"].Value).cProducto;
                    }
                }
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
                    if (objDetNotSalida.nCantidadAten > objDetNotSalida.nCantidadApro)
                    {
                        MessageBox.Show("La cantidad atendida no puede ser mayor a la cantidad aprobada.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtgItems.CurrentRow.Cells["nCantidadAten"].Value = 0m;
                    }
                }
            }
        }

        private void dtgItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgItems.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgItems.CurrentRow.Cells["nCantidadAten"].EditedFormattedValue.ToString()))
                {
                    dtgItems.EditingControl.Text = "0";
                    return;
                }
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46)
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

        public frmAtencionNotaSalida()
        {
            InitializeComponent();
        }

        private void IniForm()
        {
            cboAgencia.Enabled = true;
            dtpFechaIni.Enabled = true;
            dtpFechaFin.Enabled = true;
            btnBusqNotSalida.Enabled = true;

            cboAgencia.SelectedValue = 0;
            dtpFechaIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private bool Validar()
        {
            if (dtgNotSalida.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la nota de salida a aprobar o denegar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsNotaSalida objNotSalida = (clsNotaSalida)dtgNotSalida.CurrentRow.DataBoundItem;

            decimal cantidad = 0;
            foreach (clsDetNotaSalida item in objNotSalida.LstDetNotSalida)
            {
                cantidad += Convert.ToDecimal(item.nCantidadAten);
            }
            if (cantidad == 0)
            {
                MessageBox.Show("La cantidad Total a Atender no puede ser CERO", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string msjItem = string.Empty;

            var lstItemsSinStock = objNotSalida.LstDetNotSalida.Where(x => x.nStock < x.nCantidadAten).ToList();
            foreach (clsDetNotaSalida item in lstItemsSinStock)
            {
                msjItem = string.Empty;
                msjItem += "La cantidad Atendida es mayor al stock del item : " + item.objCatalogo.cProducto + ".\n";
                MessageBox.Show(msjItem, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            List<clsDetNotaSalida> lstItemsNoValid = objNotSalida.LstDetNotSalida.Where(x => x.nCantidadAten == 0).ToList();

            msjItem = "";
            foreach (clsDetNotaSalida item in lstItemsNoValid)
            {
                //string msjItem = string.Empty;
                msjItem += "La cantidad atendida del Item : " + item.objCatalogo.cProducto + " es 0.\n" ;
            }

            if (msjItem != "")
            {
                msjItem += " \n ¿Desea Continuar?";
                DialogResult dRes = MessageBox.Show(msjItem, cTituloMensajes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }

        private void LimpiarControles()
        {
            //Asignar los valores de inicio
            dtgNotSalida.DataSource = typeof(List<clsNotaSalida>);
            dtgItems.DataSource = typeof(List<clsDetNotaSalida>);
            txtNumNS.Clear();
            txtUsuReg.Clear();
            txtActividad.Clear();
            txtUsuAprob.Clear();
            txtSustento.Clear();
            txtAlmacen.Clear();
            cboAgeNS.SelectedIndex = -1;
        }

        private void FormatoDtgNotSalida()
        {
            foreach (DataGridViewColumn column in dtgNotSalida.Columns)
            {
                column.Visible = false;
            }

            dtgNotSalida.Columns["idNotaSalida"].Visible = true;
            dtgNotSalida.Columns["cUsuReg"].Visible = true;
            dtgNotSalida.Columns["dFechaRegistro"].Visible = true;
            dtgNotSalida.Columns["cEstLog"].Visible = true;
            dtgNotSalida.Columns["cNombreAlmacen"].Visible = true;

            dtgNotSalida.Columns["idNotaSalida"].HeaderText = "Nro. NS";
            dtgNotSalida.Columns["cUsuReg"].HeaderText = "Usu. Registro";
            dtgNotSalida.Columns["dFechaRegistro"].HeaderText = "Fec. Registro";
            dtgNotSalida.Columns["cNombreAlmacen"].HeaderText = "Almacén";
            dtgNotSalida.Columns["cEstLog"].HeaderText = "Estado";

            dtgNotSalida.Columns["idNotaSalida"].FillWeight = 8;
            dtgNotSalida.Columns["cNombreAlmacen"].FillWeight = 42;
            dtgNotSalida.Columns["cUsuReg"].FillWeight = 20;
            dtgNotSalida.Columns["dFechaRegistro"].FillWeight = 15;
            dtgNotSalida.Columns["cEstLog"].FillWeight = 15;
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
            dtgItems.Columns["nCantidadAten"].Visible = true;
            dtgItems.Columns["nStock"].Visible = true;

            dtgItems.Columns["cUnidMedida"].HeaderText = "Unidad";
            dtgItems.Columns["cProducto"].HeaderText = "Producto";
            dtgItems.Columns["nCantidadSol"].HeaderText = "Cant. Solicitada";
            dtgItems.Columns["nCantidadApro"].HeaderText = "Cant. Aprobada";
            dtgItems.Columns["nCantidadAten"].HeaderText = "Cant. Atendida";
            dtgItems.Columns["nStock"].HeaderText = "Stock";

            dtgItems.Columns["cUnidMedida"].DisplayIndex = 0;
            dtgItems.Columns["cProducto"].DisplayIndex = 1;
            dtgItems.Columns["nStock"].DisplayIndex = 2;
            dtgItems.Columns["nCantidadSol"].DisplayIndex = 3;
            dtgItems.Columns["nCantidadApro"].DisplayIndex = 4;
            dtgItems.Columns["nCantidadAten"].DisplayIndex = 5;

            dtgItems.Columns["cUnidMedida"].FillWeight = 50;
            dtgItems.Columns["cProducto"].FillWeight = 150;
            dtgItems.Columns["nStock"].FillWeight = 50;
            dtgItems.Columns["nCantidadSol"].FillWeight = 60;
            dtgItems.Columns["nCantidadApro"].FillWeight = 60;
            dtgItems.Columns["nCantidadAten"].FillWeight = 60;
            dtgItems.Columns["nPrecioUnitario"].FillWeight = 60;
      
            dtgItems.Columns["nCantidadAten"].ReadOnly = false;
        }

        #endregion

    }
}
