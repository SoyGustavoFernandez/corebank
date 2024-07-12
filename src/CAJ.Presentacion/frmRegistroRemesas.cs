using GEN.ControlesBase;
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
using CAJ.CapaNegocio;
using System.Globalization;

namespace CAJ.Presentacion
{
    public partial class frmRegistroRemesas : frmBase
    {
        public int idEstablecimiento;
	    public int idTipoRemesa;
	    public int idEstadoRemesa;
        public int idRemesa;
	    DateTime dFechaDesde;
        DateTime dFechaHasta;
        DataTable dtRemesa;
        clsCNRemesa objCNRemesa = new clsCNRemesa();

        public frmRegistroRemesas()
        {
            InitializeComponent();
        }

        private void frmRegistroRemesas_Load(object sender, EventArgs e)
        {
            iniForm();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (dtgListaRemesa.RowCount > 0)
            {
                idRemesa = Convert.ToInt32(dtgListaRemesa.Rows[dtgListaRemesa.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                abrirFrmSolicitudEfectivo(2);
            }
            else
            {
                MessageBox.Show("Seleccione una Cuenta", "Busqueda Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idRemesa = 0;
            abrirFrmSolicitudEfectivo(1);
        }

        private void btnAbrirEstab_Click(object sender, EventArgs e)
        {
            abrirFormularioEstablecimiento();
        }

        private void abrirFormularioEstablecimiento()
        {

            frmBuscaEstablecimiento frmAgencia = new frmBuscaEstablecimiento();
            frmAgencia.ShowDialog();

            if (frmAgencia.pnIdEstablecimientoPadre != 0 && frmAgencia.pnidEstablecimiento != 0)
            {
                idEstablecimiento = frmAgencia.pnidEstablecimiento;
                txtEstablecimiento.Text = frmAgencia.pcNombreEstablecimiento;
            }
        }

        private void abrirFrmSolicitudEfectivo(int nTipoAccion)
        {
            frmSolicitudEfectivo frmRevisar = new frmSolicitudEfectivo();
            frmRevisar.nTipoAccion = nTipoAccion;
            frmRevisar.idRemesa = idRemesa;
            frmRevisar.ActualizarLista = 0;
            frmRevisar.ShowDialog();

            if (frmRevisar.ActualizarLista == 1)
            {
                cboTipoRemesa.SelectedValue = frmRevisar.objTmpRemesa.idTipoRemesa;
                cboEstadoRemesa.SelectedValue = frmRevisar.objTmpRemesa.idEstadoRemesa;
                listarRemesa();
            }
        }

        public void iniForm()
        {
            btnAbrirEstab.Enabled = false;
            txtEstablecimiento.Enabled = false;
            btnRemesaTodos.Enabled = false;
            cboTipoRemesa.Enabled = false;

            cboEstadoRemesa.ListarEstadoRemesas(1);
            cboTipoRemesa.SelectedValue = 1;
            cboEstadoRemesa.SelectedValue = 0;
            dtpFechaDesde.Value = clsVarGlobal.dFecSystem;
            dtpFechaHasta.Value = clsVarGlobal.dFecSystem;

            idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            txtEstablecimiento.Text = clsVarGlobal.User.cEstablecimiento;

            DataTable dtAccesoOficinas = objCNRemesa.CNListarEstadoRemesa(1, clsVarGlobal.PerfilUsu.idPerfil, 0);
            DataRow[] cEstado = dtAccesoOficinas.Select("idEstadoRemesa = '" + 4 + "'");
            if (cEstado.Length != 0)
            {
                btnAbrirEstab.Enabled = true;
                txtEstablecimiento.Enabled = true;
                btnRemesaTodos.Enabled = true;
                FiltrarTodosRemesa();
            }
            DataTable dtAccesoRemesaSalida = objCNRemesa.CNListarEstadoRemesa(2, clsVarGlobal.PerfilUsu.idPerfil, 0);
            if (dtAccesoRemesaSalida.Rows.Count > 0)
            {
                cboTipoRemesa.Enabled = true;
            }
            DataTable dtAccesoAprobado = objCNRemesa.CNListarEstadoRemesa(1, clsVarGlobal.PerfilUsu.idPerfil, 0);
            DataRow[] cEstado1 = dtAccesoOficinas.Select("idEstadoRemesa = '" + 2 + "'");
            if (cEstado1.Length != 0)
            {
                FiltrarTodosRemesa();
            }

            listarRemesa();

            clsCNRemesa ListarAcceso = new clsCNRemesa();
            DataTable dtAccesoBtnNuevo = ListarAcceso.CNListarEstadoRemesa(0, clsVarGlobal.PerfilUsu.idPerfil, 0);
            if (dtAccesoBtnNuevo.Rows.Count == 2)
            {
                btnNuevo.Visible = true;
            }
            else
            {
                btnNuevo.Visible = false;
            }
        }
        public void listarRemesa()
        {
            dtRemesa = new DataTable();
            idTipoRemesa = Convert.ToInt32(cboTipoRemesa.SelectedValue);
            idEstadoRemesa = Convert.ToInt32(cboEstadoRemesa.SelectedValue);
            dFechaDesde = dtpFechaDesde.Value;
            dFechaHasta = dtpFechaHasta.Value;

            dtRemesa = new clsCNRemesa().CNListarRemesa(clsVarGlobal.User.idUsuario, idEstablecimiento, idTipoRemesa, idEstadoRemesa, dFechaDesde, dFechaHasta);
            dtgListaRemesa.DataSource = "";
            dtgListaRemesa.Columns.Clear();
            dtgListaRemesa.DataSource = dtRemesa;
            formatoGrid();
        }
        public void formatoGrid()
        {
            if (idTipoRemesa == 1)
            {
                dtgListaRemesa.Columns["idRemesa"].Visible = true;
                dtgListaRemesa.Columns["cTipoRemesa"].Visible = true;
                dtgListaRemesa.Columns["cEstadoRemesa"].Visible = true;
                dtgListaRemesa.Columns["cNombreEstab"].Visible = true;
                dtgListaRemesa.Columns["cModalidad"].Visible = true;
                dtgListaRemesa.Columns["cNombreHabilitar"].Visible = true;
                dtgListaRemesa.Columns["nMontoSolicitado"].Visible = true;
                dtgListaRemesa.Columns["dFechaHoraRegistro"].Visible = true;
                dtgListaRemesa.Columns["dFechaRespuesta"].Visible = true;

                dtgListaRemesa.Columns["idRemesa"].HeaderText = "Id";
                dtgListaRemesa.Columns["cTipoRemesa"].HeaderText = "Tipo";
                dtgListaRemesa.Columns["cEstadoRemesa"].HeaderText = "Estado";
                dtgListaRemesa.Columns["cNombreEstab"].HeaderText = "Establecimiento";
                dtgListaRemesa.Columns["cModalidad"].HeaderText = "Modalidad";
                dtgListaRemesa.Columns["cNombreHabilitar"].HeaderText = "Habilitador";
                dtgListaRemesa.Columns["nMontoSolicitado"].HeaderText = "Monto";
                dtgListaRemesa.Columns["dFechaHoraRegistro"].HeaderText = "Fecha Hora registro";
                dtgListaRemesa.Columns["dFechaRespuesta"].HeaderText = "Fecha decisión";

                dtgListaRemesa.Columns["idRemesa"].FillWeight = 4;
                dtgListaRemesa.Columns["cTipoRemesa"].FillWeight = 10;
                dtgListaRemesa.Columns["cEstadoRemesa"].FillWeight = 11;
                dtgListaRemesa.Columns["cNombreEstab"].FillWeight = 16;
                dtgListaRemesa.Columns["cModalidad"].FillWeight = 14;
                dtgListaRemesa.Columns["cNombreHabilitar"].FillWeight = 19;
                dtgListaRemesa.Columns["nMontoSolicitado"].FillWeight = 6;
                dtgListaRemesa.Columns["dFechaHoraRegistro"].FillWeight = 12;
                dtgListaRemesa.Columns["dFechaRespuesta"].FillWeight = 8;

                dtgListaRemesa.Columns["idRemesa"].DisplayIndex = 0;
                dtgListaRemesa.Columns["cTipoRemesa"].DisplayIndex = 1;
                dtgListaRemesa.Columns["cEstadoRemesa"].DisplayIndex = 2;
                dtgListaRemesa.Columns["cNombreEstab"].DisplayIndex = 3;
                dtgListaRemesa.Columns["cModalidad"].DisplayIndex = 4;
                dtgListaRemesa.Columns["cNombreHabilitar"].DisplayIndex = 5;
                dtgListaRemesa.Columns["nMontoSolicitado"].DisplayIndex = 7;
                dtgListaRemesa.Columns["dFechaHoraRegistro"].DisplayIndex = 7;
                dtgListaRemesa.Columns["dFechaRespuesta"].DisplayIndex = 8;
            }
            else 
            {
                dtgListaRemesa.Columns["idRemesa"].Visible = true;
                dtgListaRemesa.Columns["cTipoRemesa"].Visible = true;
                dtgListaRemesa.Columns["cEstadoRemesa"].Visible = true;
                dtgListaRemesa.Columns["cNombreEstab"].Visible = true;
                dtgListaRemesa.Columns["cNombreRemesante"].Visible = true;
                dtgListaRemesa.Columns["cEntidad"].Visible = true;
                dtgListaRemesa.Columns["nMontoRemesa"].Visible = true;
                dtgListaRemesa.Columns["dFechaRegistro"].Visible = true;
                dtgListaRemesa.Columns["dFechaRecepcion"].Visible = true;

                dtgListaRemesa.Columns["idRemesa"].HeaderText = "Id";
                dtgListaRemesa.Columns["cTipoRemesa"].HeaderText = "Tipo";
                dtgListaRemesa.Columns["cEstadoRemesa"].HeaderText = "Estado";
                dtgListaRemesa.Columns["cNombreEstab"].HeaderText = "Establecimiento";
                dtgListaRemesa.Columns["cNombreRemesante"].HeaderText = "Remesante";
                dtgListaRemesa.Columns["cEntidad"].HeaderText = "Entidad";
                dtgListaRemesa.Columns["nMontoRemesa"].HeaderText = "Monto";
                dtgListaRemesa.Columns["dFechaRegistro"].HeaderText = "Fecha registro";
                dtgListaRemesa.Columns["dFechaRecepcion"].HeaderText = "Fecha recepción completa";

                dtgListaRemesa.Columns["idRemesa"].FillWeight = 3;
                dtgListaRemesa.Columns["cTipoRemesa"].FillWeight = 8;
                dtgListaRemesa.Columns["cEstadoRemesa"].FillWeight = 15;
                dtgListaRemesa.Columns["cNombreEstab"].FillWeight = 12;
                dtgListaRemesa.Columns["cNombreRemesante"].FillWeight = 20;
                dtgListaRemesa.Columns["cEntidad"].FillWeight = 22;
                dtgListaRemesa.Columns["nMontoRemesa"].FillWeight = 7;
                dtgListaRemesa.Columns["dFechaRegistro"].FillWeight = 7;
                dtgListaRemesa.Columns["dFechaRecepcion"].FillWeight = 7;

                dtgListaRemesa.Columns["idRemesa"].DisplayIndex = 0;
                dtgListaRemesa.Columns["cTipoRemesa"].DisplayIndex = 1;
                dtgListaRemesa.Columns["cEstadoRemesa"].DisplayIndex = 2;
                dtgListaRemesa.Columns["cNombreEstab"].DisplayIndex = 3;
                dtgListaRemesa.Columns["cNombreRemesante"].DisplayIndex = 4;
                dtgListaRemesa.Columns["cEntidad"].DisplayIndex = 5;
                dtgListaRemesa.Columns["nMontoRemesa"].DisplayIndex = 6;
                dtgListaRemesa.Columns["dFechaRegistro"].DisplayIndex = 7;
                dtgListaRemesa.Columns["dFechaRecepcion"].DisplayIndex = 8;
            }            

        }

        private void btnFiltrarRemesa_Click(object sender, EventArgs e)
        {
            listarRemesa();
        }

        private void btnRemesaTodos_Click(object sender, EventArgs e)
        {
            FiltrarTodosRemesa();
            listarRemesa();
        }

        public void FiltrarTodosRemesa()
        {
            idEstablecimiento = 0;
            txtEstablecimiento.Text = "-* TODOS *-";
        }

        private void cboTipoRemesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoRemesa.SelectedValue) == 1)
            {
                cboEstadoRemesa.ListarEstadoRemesas(1);
                idEstadoRemesa = 0;
                cboEstadoRemesa.SelectedValue = idEstadoRemesa;
            }
            else
            {
                cboEstadoRemesa.ListarEstadoRemesas(2);
                idEstadoRemesa = 0;
                cboEstadoRemesa.SelectedValue = idEstadoRemesa;
            }
        }
    }
}
