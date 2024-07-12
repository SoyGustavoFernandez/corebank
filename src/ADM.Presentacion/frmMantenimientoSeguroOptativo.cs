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
using ADM.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoSeguroOptativo : frmBase
    {
        #region Variables Globales
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt = new clsMantenimientoSeguroOptativo();
        clsCNConfigurarSeguroOptativo clsMantenimiento   = new clsCNConfigurarSeguroOptativo();
        clsMantenimientoPlanSeguroVida clsListaPlanSeguro;
        List <clsMantenimientoPlanSeguroVida> listListaPlanSeguro = new List <clsMantenimientoPlanSeguroVida>();
        public int idUsuario = clsVarGlobal.User.idUsuario, nfilaseleccionada;

        #region SeguroOncologico
        List<clsFrmEditarSeguroOptativo> lstObjSeguroOptativoNuevo = new List<clsFrmEditarSeguroOptativo>();
        clsHistoricoSegurosOptativos objHistoricoSegurosOptativos = new clsHistoricoSegurosOptativos();
        List<Productos> lstProducto = new List<Productos>();
        List<Perfiles> lstPerfil = new List<Perfiles>();
        List<Agencias> lstAgencia = new List<Agencias>();
        List<PlanesSeguroOptativo> lstPlanes = new List<PlanesSeguroOptativo>();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        #endregion
        #endregion

        public frmMantenimientoSeguroOptativo()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmMantenimientoSeguroOptativo_Load(object sender, EventArgs e)
        {
            ListarSegurosOpt();
            MapeoInicialHistoricoSeguros();
        }

        private void dtgSeguroOptativo_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void btnMiniEditarSeguro_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgSeguroOptativo.CurrentCell.RowIndex);

            DataTable dtgListaPlanSeguro = clsMantenimiento.CNListaPlanSeguro(clsDatosSeguroOpt.idTipoSeguro);
            listListaPlanSeguro.RemoveRange(0, listListaPlanSeguro.Count());
            foreach (DataRow fila in dtgListaPlanSeguro.Rows)
            {
                clsListaPlanSeguro = new clsMantenimientoPlanSeguroVida
                {
                    idTipoPlan     = Convert.ToInt32(fila["idTipoPlan"]),
                    idTipoSeguro   = Convert.ToInt32(fila["idTipoSeguro"]),
                    cDescripcion   = fila["cDescripcion"].ToString(),
                    nPrecioMensual = Convert.ToDecimal(fila["nPrecioMensual"]),
                    lRedondear = Convert.ToBoolean(fila["lRedondear"]),
                    //Si lRedondear es TRUE, el nPrecioTotal se redondea a los enteros
                    nPrecioTotal = Convert.ToBoolean(fila["lRedondear"]) ? Math.Round(Convert.ToDecimal(fila["nPrecioMensual"]) * Convert.ToInt32(fila["nMeses"])) : Convert.ToDecimal(fila["nPrecioMensual"]) * Convert.ToInt32(fila["nMeses"]),
                    nMeses = Convert.ToInt32(fila["nMeses"]),
                    idConcepto = Convert.ToInt32(fila["idConcepto"]),
                    nMinMes = Convert.ToInt32(fila["nMinMes"]),
                    nMaxMes = Convert.ToInt32(fila["nMaxMes"]),
                    lFijo = Convert.ToBoolean(fila["lFijo"]),
                    lSolicitud = Convert.ToBoolean(fila["lSolicitud"])
                };
                listListaPlanSeguro.Add(clsListaPlanSeguro);
            }
            clsDatosSeguroOpt.listaValseguro = listListaPlanSeguro;

            frmEditarSeguroOptativo EditarSegOpt = new frmEditarSeguroOptativo(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            EditarSegOpt.ShowDialog();
            ListarSegurosOpt();
            dtgSeguroOptativo.CurrentCell = dtgSeguroOptativo.Rows[nfilaseleccionada].Cells["cTipoSeguro"];
            SeleccionarProducto();
            MapeoInicialHistoricoSeguros();
        }

        private void btnMiniAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dtgProductos.RowCount != 0)
            {
                nfilaseleccionada = Convert.ToInt32(dtgProductos.CurrentCell.RowIndex);
            }
            clsDatosSeguroOpt.nEstado = 0;
            ObtenerDatosProducto();
            
            frmConfigurarProductosSegOpt AgregarProductoSeguro = new frmConfigurarProductosSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            AgregarProductoSeguro.ShowDialog();
            ListarProductos();
            SeleccionarProducto();
            MapeoInicialHistoricoSeguros();

            if (dtgProductos.SelectedRows.Count > 0)
            {
                if (AgregarProductoSeguro.idSubProducto == clsDatosSeguroOpt.idSubProducto)
                {
                    dtgProductos.CurrentCell = dtgProductos.Rows[nfilaseleccionada].Cells["cSubProducto"];
                }
                else if (AgregarProductoSeguro.idSubProducto != clsDatosSeguroOpt.idSubProducto)
                {
                    int nEstado = 0;
                    foreach (DataGridViewRow fila in dtgProductos.Rows)
                    {
                        nEstado += 1;
                        if (Convert.ToInt32(fila.Cells["idSubProducto"].Value) == AgregarProductoSeguro.idSubProducto)
                        {
                            dtgProductos.CurrentCell = dtgProductos.Rows[nEstado - 1].Cells["cSubProducto"];
                        }
                    }
                }
            }
        }

        private void btnMiniQuitarProducto_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgProductos.CurrentCell.RowIndex);
            ObtenerDatosProducto();
            int nEstado = 0;
            
            if (clsDatosSeguroOpt.idSubProducto == 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar todos los sub productos?", "Eliminar sub productos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtSubProSegOptConfig = clsMantenimiento.CNEliminarSubProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idSubProducto, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroProducto("REGISTRO DE PRODUCTO ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
                    MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar el sub producto?", "Eliminar sub producto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtSubProSegOptConfig = clsMantenimiento.CNEliminarSubProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idSubProducto, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroProducto("REGISTRO DE PRODUCTO ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
                    MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }

            ListarProductos();
            SeleccionarProducto();
            if (dtgProductos.RowCount != 0)
            {
                if (nfilaseleccionada != 0)
                {
                    if (nEstado == 0)
                    {
                        dtgProductos.CurrentCell = dtgProductos.Rows[nfilaseleccionada].Cells["cSubProducto"];
                    }
                    else
                    {
                        dtgProductos.CurrentCell = dtgProductos.Rows[nfilaseleccionada - 1].Cells["cSubProducto"];
                    }
                }
            }
        }

        private void btnMiniEditarProducto_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgProductos.CurrentCell.RowIndex);
            ObtenerDatosProducto();
            clsDatosSeguroOpt.nEstado = 1;
            
            frmConfigurarProductosSegOpt EditarProductoSegruo = new frmConfigurarProductosSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            EditarProductoSegruo.ShowDialog();
            ListarProductos();
            MapeoInicialHistoricoSeguros();
            dtgProductos.CurrentCell = dtgProductos.Rows[nfilaseleccionada].Cells["cSubProducto"];
        }

        private void btnMiniAgregarPefiles_Click(object sender, EventArgs e)
        {
            if (dtgPerfiles.RowCount != 0)
            {
                nfilaseleccionada = Convert.ToInt32(dtgPerfiles.CurrentCell.RowIndex);
            }
            ObtenerDatosPerfil();
            clsDatosSeguroOpt.nEstado = 0;
            
            frmConfigurarPerfileSegOpt AgregarPerfilSeguro = new frmConfigurarPerfileSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            AgregarPerfilSeguro.ShowDialog();
            ListarPefil();
            SeleccionarProducto();
            MapeoInicialHistoricoSeguros();

            if (dtgPerfiles.RowCount != 0)
            {
                if (AgregarPerfilSeguro.idPerfil == clsDatosSeguroOpt.idPerfil)
                {
                    dtgPerfiles.CurrentCell = dtgPerfiles.Rows[nfilaseleccionada].Cells["cPerfil"];
                }
                else if (AgregarPerfilSeguro.idPerfil != clsDatosSeguroOpt.idPerfil)
                {
                    int nEstado = 0;
                    foreach (DataGridViewRow fila in dtgPerfiles.Rows)
                    {
                        nEstado += 1;
                        if (Convert.ToInt32(fila.Cells["idPerfil"].Value) == AgregarPerfilSeguro.idPerfil)
                        {
                            dtgPerfiles.CurrentCell = dtgPerfiles.Rows[nEstado - 1].Cells["cPerfil"];
                        }
                    }
                }
            }
        }

        private void btnMiniQuitarPerfiles_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgPerfiles.CurrentCell.RowIndex);
            ObtenerDatosPerfil();
            int nEstado = 0;
            
            if (clsDatosSeguroOpt.idPerfil == 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar todos los perfiles?", "Eliminar perfiles", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtSubProSegOptConfig = clsMantenimiento.CNEliminarPefilProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idPerfil, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPerfil("REGISTRO DE PERFIL ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar el perfil?", "Eliminar perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtSubProSegOptConfig = clsMantenimiento.CNEliminarPefilProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idPerfil, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPerfil("REGISTRO DE PERFIL ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }
            ListarPefil();
            SeleccionarProducto();
            
            if (dtgPerfiles.RowCount != 0)
            {
                if (nfilaseleccionada != 0)
                {
                    if (nEstado == 0)
                    {
                        dtgPerfiles.CurrentCell = dtgPerfiles.Rows[nfilaseleccionada].Cells["cPerfil"];
                    }
                    else
                    {
                        dtgPerfiles.CurrentCell = dtgPerfiles.Rows[nfilaseleccionada - 1].Cells["cPerfil"];
                    }
                }
            }
        }

        private void btnMiniEditarPerfiles_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgPerfiles.CurrentCell.RowIndex);
            ObtenerDatosPerfil();
            clsDatosSeguroOpt.nEstado = 1;
            
            frmConfigurarPerfileSegOpt EditarPerfilSeguro = new frmConfigurarPerfileSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            EditarPerfilSeguro.ShowDialog();
            ListarPefil();
            MapeoInicialHistoricoSeguros();
            dtgPerfiles.CurrentCell = dtgPerfiles.Rows[nfilaseleccionada].Cells["cPerfil"];
        }

        private void btnMiniAgregarAgencia_Click(object sender, EventArgs e)
        {
            if (dtgAgencia.RowCount != 0)
            {
                nfilaseleccionada = Convert.ToInt32(dtgAgencia.CurrentCell.RowIndex);
            }
            clsDatosSeguroOpt.nEstado = 0;
            ObtenerDatosAgencia();
            
            frmConfigurarOficinasSegOpt AgregarAgenciaSeguro = new frmConfigurarOficinasSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            AgregarAgenciaSeguro.ShowDialog();
            ListarAgencia();
            SeleccionarProducto();
            MapeoInicialHistoricoSeguros();
            
            if (dtgAgencia.RowCount != 0)
            {
                if (AgregarAgenciaSeguro.idAgencia == clsDatosSeguroOpt.idAgencia)
                {
                    dtgAgencia.CurrentCell = dtgAgencia.Rows[nfilaseleccionada].Cells["cNombreAge"];
                }
                else if (AgregarAgenciaSeguro.idAgencia != clsDatosSeguroOpt.idAgencia)
                {
                    int nEstado = 0;
                    foreach (DataGridViewRow fila in dtgAgencia.Rows)
                    {
                        nEstado += 1;
                        if (Convert.ToInt32(fila.Cells["idAgencia"].Value) == AgregarAgenciaSeguro.idAgencia)
                        {
                            dtgAgencia.CurrentCell = dtgAgencia.Rows[nEstado - 1].Cells["cNombreAge"];
                        }
                    }
                }
            }
        }

        private void btnMiniQuitarAgencia_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgAgencia.CurrentCell.RowIndex);
            ObtenerDatosAgencia();
            int nEstado = 0;
            
            if (clsDatosSeguroOpt.idAgencia == 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar todas las agencias?", "Eliminar agencias", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtAgenciaSegOptConfig = clsMantenimiento.CNEliminarOficinaProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idAgencia, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroAgencia("REGISTRO DE AGENCIA ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar la agencia?", "Eliminar agencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtAgenciaSegOptConfig = clsMantenimiento.CNEliminarOficinaProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro, clsDatosSeguroOpt.idAgencia, idUsuario);
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroAgencia("REGISTRO DE AGENCIA ELIMINADO", AccionHistorico.ELIMINAR, clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            MapeoInicialHistoricoSeguros();
                    nEstado += 1;
                }
            }
            ListarAgencia();
            SeleccionarProducto();
            
            if (dtgAgencia.RowCount != 0)
            {
                if (nfilaseleccionada != 0)
                {
                    if (nEstado == 0)
                    {
                        dtgAgencia.CurrentCell = dtgAgencia.Rows[nfilaseleccionada].Cells["cDesZona"];
                    }
                    else
                    {
                        dtgAgencia.CurrentCell = dtgAgencia.Rows[nfilaseleccionada - 1].Cells["cDesZona"];
                    }
                }
            }
        }

        private void btnMiniEditarAgencia_Click(object sender, EventArgs e)
        {
            nfilaseleccionada = Convert.ToInt32(dtgAgencia.CurrentCell.RowIndex);
            ObtenerDatosAgencia();
            clsDatosSeguroOpt.nEstado = 1;
            
            frmConfigurarOficinasSegOpt EditarAgenciaSeguro = new frmConfigurarOficinasSegOpt(clsDatosSeguroOpt, objHistoricoSegurosOptativos);
            EditarAgenciaSeguro.ShowDialog();
            ListarAgencia();
            MapeoInicialHistoricoSeguros();
            dtgAgencia.CurrentCell = dtgAgencia.Rows[nfilaseleccionada].Cells["cDesZona"];
        }
        #endregion

        #region Metodos
        void ListarSegurosOpt()
        {
            dtgSeguroOptativo.DataSource = clsMantenimiento.CNListaSeguroOptativo();
            AsignarValorSeguro();
        }

        void ListarProductos()
        {
            dtgProductos.DataSource = clsMantenimiento.CNListarSubProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro);
            AsignarValorProductos();
        }
       
        void ListarPefil()
        {
            dtgPerfiles.DataSource = clsMantenimiento.CNListarPefilProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro);
            AsignarValorPefil();
        }

        void ListarAgencia()
        {
            dtgAgencia.DataSource = clsMantenimiento.CNListarOficinaProSegOptConfig(clsDatosSeguroOpt.idTipoSeguro);
            AsignarValoresAgencia();
        }

        void AsignarValoresAgencia()
        {
            if (dtgAgencia.RowCount >= 0)
            {
                dtgAgencia.Columns["cDesZona"].Width    = 80;
                dtgAgencia.Columns["cNombreAge"].Width  = 80;
                dtgAgencia.Columns["lAutorizado"].Width = 80;

                dtgAgencia.ReadOnly = true;
                dtgAgencia.Columns["idTipoSeguro"].Visible          = false;
                dtgAgencia.Columns["idConfigSeguroAgencia"].Visible = false;
                dtgAgencia.Columns["idZona"].Visible                = false;
                dtgAgencia.Columns["cDesZona"].Visible              = true;
                dtgAgencia.Columns["idAgencia"].Visible             = false;
                dtgAgencia.Columns["cNombreAge"].Visible            = true;
                dtgAgencia.Columns["idAgencia"].Visible             = false;
                dtgAgencia.Columns["lAutorizado"].Visible           = true;


                dtgAgencia.Columns["cDesZona"].HeaderText    = "Zona";
                dtgAgencia.Columns["cNombreAge"].HeaderText  = "Agencia";
                dtgAgencia.Columns["lAutorizado"].HeaderText = "Autorizado";
            }
        }

        void AsignarValorPefil()
        {
            if (dtgPerfiles.RowCount >= 0)
            {
                dtgPerfiles.Columns["cPerfil"].Width     = 80;
                dtgPerfiles.Columns["lAutorizado"].Width = 80;

                dtgPerfiles.ReadOnly = true;
                dtgPerfiles.Columns["idTipoSeguro"].Visible        = false;
                dtgPerfiles.Columns["idConfigSeguroPefil"].Visible = false;
                dtgPerfiles.Columns["idPerfil"].Visible            = false;
                dtgPerfiles.Columns["cPerfil"].Visible             = true;
                dtgPerfiles.Columns["lAutorizado"].Visible         = true;

                dtgPerfiles.Columns["cPerfil"].HeaderText     = "Perfil";
                dtgPerfiles.Columns["lAutorizado"].HeaderText = "Autorizado";
            }
        }

        void AsignarValorProductos()
        {
            if (dtgProductos.RowCount >= 0)
            {
                dtgProductos.Columns["cTipoCredito"].Width  = 80;
                dtgProductos.Columns["cSubTipo"].Width      = 80;
                dtgProductos.Columns["cProducto"].Width     = 70;
                dtgProductos.Columns["cSubProducto"].Width  = 90;
                dtgProductos.Columns["idSubProducto"].Width = 30;
                dtgProductos.Columns["lAutorizado"].Width   = 60;

                dtgProductos.ReadOnly                                   = true;
                dtgProductos.Columns["idTipoSeguro"].Visible            = false;
                dtgProductos.Columns["idConfigSeguroProducto"].Visible  = false;
                dtgProductos.Columns["cTipoCredito"].Visible            = true;
                dtgProductos.Columns["idTipoCredito"].Visible           = false;
                dtgProductos.Columns["cSubTipo"].Visible                = true;
                dtgProductos.Columns["idSubTipo"].Visible               = false;
                dtgProductos.Columns["cProducto"].Visible               = true;
                dtgProductos.Columns["idProducto"].Visible              = false;
                dtgProductos.Columns["cSubProducto"].Visible            = true;
                dtgProductos.Columns["idSubProducto"].Visible           = false;
                dtgProductos.Columns["lAutorizado"].Visible             = true;

                dtgProductos.Columns["cTipoCredito"].HeaderText  = "Tipo credito";
                dtgProductos.Columns["cSubTipo"].HeaderText      = "Sub Tipo";
                dtgProductos.Columns["cProducto"].HeaderText     = "Producto";
                dtgProductos.Columns["cSubProducto"].HeaderText  = "Sub Producto";
                dtgProductos.Columns["idSubProducto"].HeaderText = "Producto";
                dtgProductos.Columns["lAutorizado"].HeaderText   = "Autorizado";
            }
        }

        void AsignarValorSeguro()
        {
            for (int i = 0; i < dtgSeguroOptativo.Columns.Count; i++)
            {
                dtgSeguroOptativo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgSeguroOptativo.RowCount > 0)
            {
                dtgSeguroOptativo.Columns["idTipoSeguro"].AutoSizeMode              = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["cTipoSeguro"].AutoSizeMode               = DataGridViewAutoSizeColumnMode.AllCells;
                dtgSeguroOptativo.Columns["nValor"].AutoSizeMode                    = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["idTipoValSegOptativo"].AutoSizeMode      = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["cTipoValSegOptativo"].AutoSizeMode       = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["idConcepto"].AutoSizeMode                = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["cConcepto"].AutoSizeMode                 = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["idTipoPagoSeguroOptativo"].AutoSizeMode  = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["cTipoPagoSeguroOptativo"].AutoSizeMode   = DataGridViewAutoSizeColumnMode.None;
                dtgSeguroOptativo.Columns["lVigente"].AutoSizeMode                  = DataGridViewAutoSizeColumnMode.None;

                dtgSeguroOptativo.Columns["nValor"].Width                   = 70;
                dtgSeguroOptativo.Columns["cTipoValSegOptativo"].Width      = 100;
                dtgSeguroOptativo.Columns["cConcepto"].Width                = 200;
                dtgSeguroOptativo.Columns["cTipoPagoSeguroOptativo"].Width  = 85;
                dtgSeguroOptativo.Columns["lVigente"].Width                 = 60;

                dtgSeguroOptativo.ReadOnly                                      = true;
                dtgSeguroOptativo.Columns["idTipoSeguro"].Visible               = false;
                dtgSeguroOptativo.Columns["cTipoSeguro"].Visible                = true;
                dtgSeguroOptativo.Columns["nValor"].Visible                     = true;
                dtgSeguroOptativo.Columns["idTipoValSegOptativo"].Visible       = false;
                dtgSeguroOptativo.Columns["cTipoValSegOptativo"].Visible        = true;
                dtgSeguroOptativo.Columns["idConcepto"].Visible                 = false;
                dtgSeguroOptativo.Columns["cConcepto"].Visible                  = true;
                dtgSeguroOptativo.Columns["idTipoPagoSeguroOptativo"].Visible   = false;
                dtgSeguroOptativo.Columns["cTipoPagoSeguroOptativo"].Visible    = true;
                dtgSeguroOptativo.Columns["lVigente"].Visible                   = true;

                dtgSeguroOptativo.Columns["cTipoSeguro"].HeaderText             = "Tipo Seguro";
                dtgSeguroOptativo.Columns["nValor"].HeaderText                  = "Prima";
                dtgSeguroOptativo.Columns["cTipoValSegOptativo"].HeaderText     = "Tipo Valor";
                dtgSeguroOptativo.Columns["cConcepto"].HeaderText               = "Concepto Recibo";
                dtgSeguroOptativo.Columns["cTipoPagoSeguroOptativo"].HeaderText = "Tipo Pago";
                dtgSeguroOptativo.Columns["lVigente"].HeaderText                = "Vigente";
            }
        }

        void OptenerDatosSeguro()
        {
            if (dtgSeguroOptativo.SelectedRows.Count > 0)
            {
                clsDatosSeguroOpt.idTipoSeguro              = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.cTipoSeguro               = dtgSeguroOptativo.CurrentRow.Cells["cTipoSeguro"].Value.ToString();
                clsDatosSeguroOpt.nValor                    = Convert.ToDecimal(dtgSeguroOptativo.CurrentRow.Cells["nValor"].Value);
                clsDatosSeguroOpt.cTipoValSegOptativo       = dtgSeguroOptativo.CurrentRow.Cells["cTipoValSegOptativo"].Value.ToString();
                clsDatosSeguroOpt.idTipoValSegOptativo      = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoValSegOptativo"].Value.ToString());
                clsDatosSeguroOpt.cConcepto                 = dtgSeguroOptativo.CurrentRow.Cells["cConcepto"].Value.ToString();
                clsDatosSeguroOpt.idConcepto                = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idConcepto"].Value.ToString());
                clsDatosSeguroOpt.cTipoPagoSeguroOptativo   = dtgSeguroOptativo.CurrentRow.Cells["cTipoPagoSeguroOptativo"].Value.ToString();
                clsDatosSeguroOpt.idTipoPagoSeguroOptativo  = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoPagoSeguroOptativo"].Value.ToString());
                clsDatosSeguroOpt.lvigente                  = Convert.ToBoolean(dtgSeguroOptativo.CurrentRow.Cells["lvigente"].Value);
            }
        }
        
        void ObtenerDatosProducto()
        {
            if (dtgProductos.RowCount == 0)
            {
                clsDatosSeguroOpt.idSubProducto   = 1;
                clsDatosSeguroOpt.nEstadoProducto = 1;
                clsDatosSeguroOpt.idTipoSeguro    = Convert.ToInt32(dtgSeguroOptativo.SelectedRows[0].Cells["idTipoSeguro"].Value.ToString());
            }
            else if (dtgProductos.RowCount != 0)
            {
                clsDatosSeguroOpt.nEstadoProducto        = 2;
                clsDatosSeguroOpt.idConfigSeguroProducto = Convert.ToInt32(dtgProductos.SelectedRows[0].Cells["idConfigSeguroProducto"].Value.ToString());
                clsDatosSeguroOpt.idTipoCredito          = Convert.ToInt32(dtgProductos.SelectedRows[0].Cells["idTipoCredito"].Value.ToString());
                clsDatosSeguroOpt.idSubTipo              = Convert.ToInt32(dtgProductos.SelectedRows[0].Cells["idSubTipo"].Value.ToString());
                clsDatosSeguroOpt.idProducto             = Convert.ToInt32(dtgProductos.SelectedRows[0].Cells["idProducto"].Value.ToString());
                clsDatosSeguroOpt.idSubProducto          = Convert.ToInt32(dtgProductos.SelectedRows[0].Cells["idSubProducto"].Value.ToString());
                clsDatosSeguroOpt.idTipoSeguro           = Convert.ToInt32(dtgSeguroOptativo.SelectedRows[0].Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.lAutorizadoProducto    = Convert.ToBoolean(dtgProductos.CurrentRow.Cells["lAutorizado"].Value);
            }
        }

        void ObtenerDatosPerfil()
        {
            if (dtgPerfiles.RowCount == 0)
            {
                clsDatosSeguroOpt.idPerfil      = 1;
                clsDatosSeguroOpt.idTipoSeguro  = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.nEstadoPerfil = 1;
            }
            else if (dtgPerfiles.RowCount != 0)
            {
                clsDatosSeguroOpt.idPerfil          = Convert.ToInt32(dtgPerfiles.CurrentRow.Cells["idPerfil"].Value.ToString());
                clsDatosSeguroOpt.idTipoSeguro      = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.lAutorizadoPerfil = Convert.ToBoolean(dtgPerfiles.CurrentRow.Cells["lAutorizado"].Value);
                clsDatosSeguroOpt.nEstadoPerfil     = 2;
            }
            
        }

        void ObtenerDatosAgencia()
        {
            if (dtgAgencia.RowCount == 0)
            {
                clsDatosSeguroOpt.idAgencia      = 1;
                clsDatosSeguroOpt.idTipoSeguro   = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.nEstadoAgencia = 1;
            }
            else if (dtgAgencia.RowCount != 0)
            {
                clsDatosSeguroOpt.idZona             = Convert.ToInt32(dtgAgencia.CurrentRow.Cells["idZona"].Value.ToString());
                clsDatosSeguroOpt.idAgencia          = Convert.ToInt32(dtgAgencia.CurrentRow.Cells["idAgencia"].Value.ToString());
                clsDatosSeguroOpt.idTipoSeguro       = Convert.ToInt32(dtgSeguroOptativo.CurrentRow.Cells["idTipoSeguro"].Value.ToString());
                clsDatosSeguroOpt.lAutorizadoAgencia = Convert.ToBoolean(dtgAgencia.CurrentRow.Cells["lAutorizado"].Value);
                clsDatosSeguroOpt.nEstadoAgencia     = 2;
            }
        }

        void SeleccionarProducto()
        {
            OptenerDatosSeguro();
            ListarProductos();
            ListarPefil();
            ListarAgencia();
            EstadoBotones();
            ValidarPaquetes();
        }

        private void ValidarPaquetes()
        {
            //Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            //Valido que el seguro seleccionado no sea de paquetes
            clsDatosSeguroOpt.lEsPaqueteSeguro = lstPaqueteSeguros.Any(x => x.idTipoSeguro == clsDatosSeguroOpt.idTipoSeguro);
            editarControles(clsDatosSeguroOpt.lEsPaqueteSeguro);
        }

        private void editarControles(bool esPaquete)
        {
            btnMiniAgregarProducto.Enabled = !esPaquete;
            btnMiniEditarProducto.Enabled = !esPaquete;
            btnMiniQuitarProducto.Enabled = !esPaquete;

            btnMiniAgregarPefiles.Enabled = !esPaquete;
            btnMiniEditarPerfiles.Enabled = !esPaquete;
            btnMiniQuitarPerfiles.Enabled = !esPaquete;

            btnMiniAgregarAgencia.Enabled = !esPaquete;
            btnMiniEditarAgencia.Enabled = !esPaquete;
            btnMiniQuitarAgencia.Enabled = !esPaquete;
        }

        void EstadoBotones()
        {
            if (dtgProductos.RowCount == 0)
            {
                btnMiniEditarProducto.Enabled = false;
                btnMiniQuitarProducto.Enabled = false;
            }
            else
            {
                btnMiniEditarProducto.Enabled = true;
                btnMiniQuitarProducto.Enabled = true;
            }
            if (dtgPerfiles.RowCount == 0)
            {
                btnMiniEditarPerfiles.Enabled = false;
                btnMiniQuitarPerfiles.Enabled = false;
            }
            else
            {
                btnMiniEditarPerfiles.Enabled = true;
                btnMiniQuitarPerfiles.Enabled = true;
            }
            if (dtgAgencia.RowCount == 0)
            {
                btnMiniEditarAgencia.Enabled = false;
                btnMiniQuitarAgencia.Enabled = false;
            }
            else
            {
                btnMiniEditarAgencia.Enabled = true;
                btnMiniQuitarAgencia.Enabled = true;
            }
        }


        #region SeguroOncologico

        private void MapeoInicialHistoricoSeguros()
        {
            InicializarObjetos();
            Productos objProducto = new Productos();
            Perfiles objPerfil = new Perfiles();
            Agencias objAgencia = new Agencias();
            PlanesSeguroOptativo objPlanes = new PlanesSeguroOptativo();

            try
            {
                //Listo todos los items asociados a los seguros
                DataTable lstProductosTMP = clsMantenimiento.CNListarSubProSegOptConfig(0);
                DataTable lstPerfilesTMP = clsMantenimiento.CNListarPefilProSegOptConfig(0);
                DataTable lstAgenciasTMP = clsMantenimiento.CNListarOficinaProSegOptConfig(0);
                DataTable lstPlanesTMP = clsMantenimiento.CNListaPlanSeguro(0);

                //RECORRO CABECERA DE SEGUROS
                foreach (DataGridViewRow row in dtgSeguroOptativo.Rows)
                {
                    clsFrmEditarSeguroOptativo objSeguroOptativoNuevo = new clsFrmEditarSeguroOptativo();
                    objSeguroOptativoNuevo.nTipoSeguro = Convert.ToInt32(row.Cells["idTipoSeguro"].Value);
                    objSeguroOptativoNuevo.cTipoSeguro = row.Cells["cTipoSeguro"].Value.ToString();
                    objSeguroOptativoNuevo.nPrimaSeguro = Convert.ToInt32(row.Cells["nValor"].Value);
                    objSeguroOptativoNuevo.nTipoValor = Convert.ToInt32(row.Cells["idTipoValSegOptativo"].Value);
                    objSeguroOptativoNuevo.cTipoValor = row.Cells["cTipoValSegOptativo"].Value.ToString();
                    objSeguroOptativoNuevo.nConceptoRecibo = Convert.ToInt32(row.Cells["idConcepto"].Value);
                    objSeguroOptativoNuevo.cConceptoRecibo = row.Cells["cConcepto"].Value.ToString();
                    objSeguroOptativoNuevo.nTipoPago = Convert.ToInt32(row.Cells["idTipoPagoSeguroOptativo"].Value);
                    objSeguroOptativoNuevo.cTipoPago = row.Cells["cTipoPagoSeguroOptativo"].Value.ToString();
                    objSeguroOptativoNuevo.lVigente = Convert.ToBoolean(row.Cells["lVigente"].Value);
                    objSeguroOptativoNuevo.idAccion = AccionHistorico.NINGUNA;

                    //RECORRO LISTA DE PRODUCTOS
                    foreach (DataRow rowProductos in lstProductosTMP.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["idTipoSeguro"].Value) == Convert.ToInt32(rowProductos["idTipoSeguro"]))
                        {
                            objProducto = new Productos();
                            objProducto.nTipoSeguro = Convert.ToInt32(rowProductos["idTipoSeguro"]);
                            objProducto.nSubProducto = Convert.ToInt32(rowProductos["idSubProducto"]);
                            objProducto.cAutorizado = Convert.ToBoolean(rowProductos["lAutorizado"]) ? "SI" : "NO";
                            lstProducto.Add(objProducto);
                        }
    }

                    //RECORRO LISTA DE PERFILES
                    foreach (DataRow rowPerfiles in lstPerfilesTMP.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["idTipoSeguro"].Value) == Convert.ToInt32(rowPerfiles["idTipoSeguro"]))
                        {
                            objPerfil = new Perfiles();
                            objPerfil.nTipoSeguro = Convert.ToInt32(rowPerfiles["idTipoSeguro"]);
                            objPerfil.nPerfil = Convert.ToInt32(rowPerfiles["idPerfil"]);
                            objPerfil.cAutorizado = Convert.ToBoolean(rowPerfiles["lAutorizado"]) ? "SI" : "NO";
                            lstPerfil.Add(objPerfil);
                        }
                    }

                    //RECORRO LISTA DE AGENCIAS
                    foreach (DataRow rowAgencias in lstAgenciasTMP.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["idTipoSeguro"].Value) == Convert.ToInt32(rowAgencias["idTipoSeguro"]))
                        {
                            objAgencia = new Agencias();
                            objAgencia.nTipoSeguro = Convert.ToInt32(rowAgencias["idTipoSeguro"]);
                            objAgencia.nAgencia = Convert.ToInt32(rowAgencias["idAgencia"]);
                            objAgencia.cAutorizado = Convert.ToBoolean(rowAgencias["lAutorizado"]) ? "SI" : "NO";
                            lstAgencia.Add(objAgencia);
                        }
                    }

                    //RECORRO LISTA DE PLANES
                    foreach (DataRow rowPlanes in lstPlanesTMP.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["idTipoSeguro"].Value) == Convert.ToInt32(rowPlanes["idTipoSeguro"]))
                        {
                            objPlanes = new PlanesSeguroOptativo();
                            objPlanes.nTipoPlan = Convert.ToInt32(rowPlanes["idTipoPlan"]);
                            objPlanes.nTipoSeguro = Convert.ToInt32(rowPlanes["idTipoSeguro"]);
                            objPlanes.nPrecio = Convert.ToDecimal(rowPlanes["nPrecioMensual"]);
                            objPlanes.nMeses = Convert.ToInt32(rowPlanes["nMeses"]);
                            objPlanes.cDescripcion = rowPlanes["cDescripcion"].ToString();
                            objPlanes.cFijo = Convert.ToBoolean(rowPlanes["lFijo"]) ? "SI" : "NO";
                            objPlanes.cSolicitud = Convert.ToBoolean(rowPlanes["lSolicitud"]) ? "SI" : "NO";
                            objPlanes.cRedondear = Convert.ToBoolean(rowPlanes["lRedondear"]) ? "SI" : "NO";
                            lstPlanes.Add(objPlanes);
                        }
                    }

                    objSeguroOptativoNuevo.lstProducto = lstProducto.FindAll(x => x.nTipoSeguro == objSeguroOptativoNuevo.nTipoSeguro);
                    objSeguroOptativoNuevo.lstPerfil = lstPerfil.FindAll(x => x.nTipoSeguro == objSeguroOptativoNuevo.nTipoSeguro);
                    objSeguroOptativoNuevo.lstAgencia = lstAgencia.FindAll(x => x.nTipoSeguro == objSeguroOptativoNuevo.nTipoSeguro);
                    objSeguroOptativoNuevo.lstPlanSeguroOptativo = lstPlanes.FindAll(x => x.nTipoSeguro == objSeguroOptativoNuevo.nTipoSeguro);
                    lstObjSeguroOptativoNuevo.Add(objSeguroOptativoNuevo);
                }

                objHistoricoSegurosOptativos.objSeguroOptativoNuevo = lstObjSeguroOptativoNuevo;

                if (objHistoricoSegurosOptativos.objSeguroOptativoAnterior == null)
                    objHistoricoSegurosOptativos.objSeguroOptativoAnterior = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.Select(item => item.Clonar()).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarObjetos()
        {
            objHistoricoSegurosOptativos = new clsHistoricoSegurosOptativos();
            lstObjSeguroOptativoNuevo = new List<clsFrmEditarSeguroOptativo>();
            lstProducto = new List<Productos>();
            lstPerfil = new List<Perfiles>();
            lstAgencia = new List<Agencias>();
            lstPlanes = new List<PlanesSeguroOptativo>();
        }
        #endregion

        #endregion
    }
}