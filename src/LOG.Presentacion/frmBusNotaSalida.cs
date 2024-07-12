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
    public partial class frmBusNotaSalida : frmBase
    {
        #region Variables Globales

        //Declarar variables globales
        public clsNotaSalida objNotaSalida;
        private const string cTituloMensajes = "Busqueda de Nota de salida";
        public bool lTodos = true;

        #endregion

        #region Eventos
        //Colocar los eventos de los controles del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            IniForm();
            if (lTodos)
            {
                cboAgencias.Enabled = true;
                cboAgencias.SelectedValue = 0;
            }
            else
            {
                cboAgencias.Enabled = false;
                cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            }

            pnlDetalle.Visible = lTodos;
            btnImprimir.Visible = lTodos;
            btnAceptar.Visible = !lTodos;

        }
        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmBusNotaSalida()
        {
            InitializeComponent();
        } 

        private void IniForm()
        {
            cboAgencias.SelectedIndex = -1;
            cboEstadoProcLog.listarEstadoProcesoAdj(1);
            DataTable dtData = (DataTable)cboEstadoProcLog.DataSource;
            DataRow dr = dtData.NewRow();
            dr[0] = 0;
            dr[1] = "TODOS";
            dtData.Rows.Add(dr);
            cboEstadoProcLog.DataSource = dtData;
            cboEstadoProcLog.ValueMember = dtData.Columns[0].ToString();
            cboEstadoProcLog.DisplayMember = dtData.Columns[1].ToString(); 
            cboEstadoProcLog.SelectedValue = 0;
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }   

        private void Aceptar()
        {
            if (dtgNotSalida.CurrentRow != null)
            {
                objNotaSalida = (clsNotaSalida)dtgNotSalida.CurrentRow.DataBoundItem;
                Dispose();
            }
            else
            {
                MessageBox.Show("Seleccione un registro de la tabla", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listarDetalle()
        {
            if (dtgNotSalida.CurrentRow != null)
            {
                objNotaSalida = (clsNotaSalida)dtgNotSalida.CurrentRow.DataBoundItem;
                txtSustento.Text = objNotaSalida.cSustento;
                dtgItems.DataSource = objNotaSalida.LstDetNotSalida;

                int i = 0;
                foreach (var lista in objNotaSalida.LstDetNotSalida)
                {
                    dtgItems.Rows[i].Cells["nStock"].Value = lista.nStock;
                    dtgItems.Rows[i].Cells["cProducto"].Value = lista.cProducto;
                    i++;
                }

                FormatoDtgDetNotSalida();
            }
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

            dtgItems.Columns["cProducto"].DisplayIndex = 0;
            dtgItems.Columns["cUnidMedida"].DisplayIndex = 1;
            dtgItems.Columns["nStock"].DisplayIndex = 2;
            dtgItems.Columns["nCantidadSol"].DisplayIndex = 3;
            dtgItems.Columns["nCantidadApro"].DisplayIndex = 4;
            dtgItems.Columns["nCantidadAten"].DisplayIndex = 5;

            dtgItems.Columns["cUnidMedida"].FillWeight = 8;
            dtgItems.Columns["cProducto"].FillWeight = 60;
            dtgItems.Columns["nStock"].FillWeight = 8;
            dtgItems.Columns["nCantidadSol"].FillWeight = 8;
            dtgItems.Columns["nCantidadApro"].FillWeight = 8;
            dtgItems.Columns["nCantidadAten"].FillWeight = 8;

            dtgItems.Columns["nCantidadAten"].ReadOnly = false;
        }
        #endregion

        private void dtgNotSalida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lTodos)
            {
                listarDetalle();
            }
            else
            {
                Aceptar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!ValidarBusqueda()) return;

            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            string cEstLog = Convert.ToString(cboEstadoProcLog.SelectedValue);
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idUsuario = clsVarGlobal.User.idUsuario;
            if (lTodos)
            {
                idUsuario = 0;
            }

            List<clsNotaSalida> lstNotaSalida = new clsCNNotaSalida().CNListarNotaSalida(dFecIni, dFecFin, idAgencia, cEstLog, idUsuario);
            dtgNotSalida.DataSource = typeof(List<clsNotaSalida>);
            dtgNotSalida.DataSource = lstNotaSalida;
            FormatoDtgNotSalida();
            if (lstNotaSalida.Count > 0)
            {
                dtgNotSalida.CurrentCell = dtgNotSalida.Rows[0].Cells["idNotaSalida"];
            }

            dtgItems.DataSource = null;
            txtSustento.Text = "";
        }

        private bool ValidarBusqueda()
        {           
            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia de la nota de salida.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (cboEstadoProcLog.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el estado de la nota de salida.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;       
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
            dtgNotSalida.Columns["cNombreAlmacen"].Visible = true;
            dtgNotSalida.Columns["cEstLog"].Visible = true;

            dtgNotSalida.Columns["idNotaSalida"].HeaderText = "Nro. NS";
            dtgNotSalida.Columns["cUsuReg"].HeaderText = "Usu. Registro";
            dtgNotSalida.Columns["dFechaRegistro"].HeaderText = "Fec. Registro";
            dtgNotSalida.Columns["cNombreAlmacen"].HeaderText = "Almacen Solicitado";
            dtgNotSalida.Columns["cEstLog"].HeaderText = "Estado";

            dtgNotSalida.Columns["idNotaSalida"].FillWeight = 5;
            dtgNotSalida.Columns["cUsuReg"].FillWeight = 15;
            dtgNotSalida.Columns["dFechaRegistro"].FillWeight = 10;
            dtgNotSalida.Columns["cNombreAlmacen"].FillWeight = 22;
            dtgNotSalida.Columns["cEstLog"].FillWeight = 8;

            dtgNotSalida.Columns["idNotaSalida"].DisplayIndex = 1;
            dtgNotSalida.Columns["cUsuReg"].DisplayIndex = 2;
            dtgNotSalida.Columns["dFechaRegistro"].DisplayIndex = 3;
            dtgNotSalida.Columns["cNombreAlmacen"].DisplayIndex = 4;
            dtgNotSalida.Columns["cEstLog"].DisplayIndex = 5;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgNotSalida.CurrentRow != null && objNotaSalida != null)
            {
                int idNotaSalida = objNotaSalida.idNotaSalida;

                clsCNNotaSalida objCargaNotaSalida = new clsCNNotaSalida();
                DataTable dtNotaSalida = objCargaNotaSalida.CNCargaNotaSalida(idNotaSalida);

                List<ReportParameter> paramlist = new List<ReportParameter>();
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
                string cNomAgen = clsVarGlobal.cNomAge;
                string cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                paramlist.Add(new ReportParameter("cNomAgencia", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutLogo, false));
                paramlist.Add(new ReportParameter("idNotaSalida", idNotaSalida.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("DSNotaSalida", dtNotaSalida));

                string reportpath = "rptRequerimientoNPAlmacen.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una Solicitud de Requerimiento", "Solicitud Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
