using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmClientesConCampaña : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();

        DataTable dtRegion = new DataTable();
        DataTable dtOficina = new DataTable();
        DataTable dtEstablecimiento = new DataTable();
        DataTable dtAsesor = new DataTable();
        DataTable dtOfertasCre = new DataTable();
        DataTable dtCampania = new DataTable();

        List<clsOfertaCred> lstOfertas;
        
        int idGrupoCamp;
        int idRegion;
        int idOficina;
        int idEstablecimiento;
        int idAsesor;

        int orden = 0;
        int columna = 0;

        public frmClientesConCampaña()
        {
            InitializeComponent();

            int idPerfilUsu = clsVarGlobal.PerfilUsu.idPerfil;
            int idUsuario = clsVarGlobal.PerfilUsu.idUsuario;

            cargarCampania();
            cargarRegion();
            limpiarEtiquetas();
        }
        public void cargarCampania()
        {
            dtCampania = cnCredito.CNListarCampania(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            cboCampania.ValueMember = "idGrupoCamp";
            cboCampania.DisplayMember = "cGrupoCamp";
            cboCampania.DataSource = dtCampania;
        }
        public void cargarRegion()
        {
            dtRegion = cnCredito.CNListarRegion(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            cboRegion.ValueMember = "idZona";
            cboRegion.DisplayMember = "cDesZona";
            cboRegion.DataSource = dtRegion;
        }
        public void cargarOficina(int idUsuario, int idPerfil, int idZona) 
        {
            dtOficina = cnCredito.CNListarAgencia(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idZona);
                
            cboOficina.ValueMember = "idAgencia";
            cboOficina.DisplayMember = "cNomCorto";
            cboOficina.DataSource = dtOficina;
        }
        public void cargarEstablecimiento(int idUsuario, int idPerfil, int idAgencia)
        {
            dtEstablecimiento = cnCredito.CNListarEstablecimiento(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idAgencia);
            cboEstablecimiento.ValueMember = "idEstablecimiento";
            cboEstablecimiento.DisplayMember = "cNombreEstab";
            cboEstablecimiento.DataSource = dtEstablecimiento;
        
        }
        public void cargarAsesor(int idEstablecimiento)
        {
            dtAsesor = cnCredito.CNBuscarAsesor(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idEstablecimiento);
            
            cboAsesor.ValueMember = "idUsuario";
            cboAsesor.DisplayMember = "cNombre";
            cboAsesor.DataSource = dtAsesor;
        }
        public void cargarOfertasCre()
        {
            dtOfertasCre = cnCredito.CNBuscarOfertasCre(idGrupoCamp, idRegion, idOficina, idEstablecimiento, idAsesor);
            lstOfertas = (dtOfertasCre.Rows.Count > 0) ? dtOfertasCre.ToList<clsOfertaCred>() as List<clsOfertaCred> : new List<clsOfertaCred>();

            configurarDTG(lstOfertas);
        }
        private void ajustarCuadricula()
        {
            if (clsVarGlobal.PerfilUsu.idPerfil == 34 || clsVarGlobal.PerfilUsu.idPerfil == 85 || clsVarGlobal.PerfilUsu.idPerfil == 56)
            {
                dtgOfertasCre.Columns[0].Width = 60;
                dtgOfertasCre.Columns[1].Width = 65;
                dtgOfertasCre.Columns[2].Width = 210;
                dtgOfertasCre.Columns[3].Width = 60;
                dtgOfertasCre.Columns[4].Width = 65;
                dtgOfertasCre.Columns[5].Width = 65;
                dtgOfertasCre.Columns[6].Width = 100;
                dtgOfertasCre.Columns[7].Width = 70;
                dtgOfertasCre.Columns[11].Width = 60;
                dtgOfertasCre.Columns["cOferta"].Width = 45;
                if (clsVarGlobal.PerfilUsu.idPerfil == 34)
                    dtgOfertasCre.Columns[12].Width = 60;
            }
            else
            {
                dtgOfertasCre.Columns[0].Width = 80;
                dtgOfertasCre.Columns[1].Width = 70;
                dtgOfertasCre.Columns[2].Width = 220;
                dtgOfertasCre.Columns[3].Width = 70;
                dtgOfertasCre.Columns[4].Width = 70;
                dtgOfertasCre.Columns[5].Width = 100;
            }
        }
        private void pintarCuadricula()
        {
            for (int i = 0; i < dtgOfertasCre.Rows.Count; i++)
            {
                if (dtgOfertasCre.Rows[i].Cells["idEstado"].Value == null)
                {
                    continue;
                }
                if (Convert.ToInt32(dtgOfertasCre.Rows[i].Cells["idEstado"].Value) == 2)
                {
                    dtgOfertasCre.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (Convert.ToInt32(dtgOfertasCre.Rows[i].Cells["idEstado"].Value) == 5)
                {
                    dtgOfertasCre.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                }
                if (Convert.ToInt32(dtgOfertasCre.Rows[i].Cells["idEstado"].Value) == 100)
                {
                    dtgOfertasCre.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }
        private void limpiarEtiquetas()
        {
            lblNombre.Text = "-";
            lblTelefono.Text = "-";
            lblCorreo.Text = "-";
            lblTContacto.Text = "-";
            lblRContacto.Text = "-";
            lblDireccion.Text = "-";
        }
        private void configurarDTG(List<clsOfertaCred> lstDataOfertas)
        {
            dtgOfertasCre.DataSource = null;
            dtgOfertasCre.Rows.Clear();
            dtgOfertasCre.Columns.Clear();
            dtgOfertasCre.Refresh();
            dtgOfertasCre.RowHeadersVisible = false;
            dtgOfertasCre.AllowUserToResizeRows = false;
            dtgOfertasCre.AllowUserToResizeColumns = false;

            dtgOfertasCre.DataSource = lstDataOfertas;

            this.dtgOfertasCre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgOfertasCre.ColumnHeadersHeight = 35;

            dtgOfertasCre.Columns["idCli"].HeaderText = "Cód. Cliente";
            dtgOfertasCre.Columns["cDocumentoID"].HeaderText = "DNI";
            dtgOfertasCre.Columns["cNombre"].HeaderText = "Apellidos y Nombres";
            dtgOfertasCre.Columns["cProducto"].HeaderText = "Producto";
            dtgOfertasCre.Columns["nMontoOferta"].HeaderText = "Oferta";
            dtgOfertasCre.Columns["nSaldoOferta"].HeaderText = "Saldo Oferta";
            dtgOfertasCre.Columns["cOperacion"].HeaderText = "Operación";
            dtgOfertasCre.Columns["nOperaciones"].HeaderText = "Nº Oper. Mes";
            dtgOfertasCre.Columns["cOferta"].HeaderText = "Origen";

            dtgOfertasCre.Columns["idSolicitud"].Visible = false;
            dtgOfertasCre.Columns["idEstado"].Visible = false;
            dtgOfertasCre.Columns["idOferta"].Visible = false;

            dtgOfertasCre.Columns[0].ReadOnly = true;
            dtgOfertasCre.Columns[1].ReadOnly = true;
            dtgOfertasCre.Columns[2].ReadOnly = true;
            dtgOfertasCre.Columns[3].ReadOnly = true;
            dtgOfertasCre.Columns[4].ReadOnly = true;
            dtgOfertasCre.Columns[5].ReadOnly = true;

            dtgOfertasCre.Columns[6].ReadOnly = true;
            dtgOfertasCre.Columns[7].ReadOnly = true;
            dtgOfertasCre.Columns[8].ReadOnly = true;
            dtgOfertasCre.Columns["cOferta"].ReadOnly = true;

            if (clsVarGlobal.PerfilUsu.idPerfil == 34)
            {
                pintarCuadricula();
                DataGridViewButtonColumn btnSolicitar = new DataGridViewButtonColumn();
                btnSolicitar.HeaderText = "";
                btnSolicitar.Name = "btnSolicitar";
                btnSolicitar.Text = "Solicitar";
                btnSolicitar.UseColumnTextForButtonValue = true;

                dtgOfertasCre.Columns.Add(btnSolicitar);

                DataGridViewButtonColumn btnContacto = new DataGridViewButtonColumn();
                btnContacto.HeaderText = "";
                btnContacto.Name = "btnContacto";
                btnContacto.Text = "Contacto";
                btnContacto.UseColumnTextForButtonValue = true;

                dtgOfertasCre.Columns.Add(btnContacto);

                ajustarCuadricula();
            }
            if (clsVarGlobal.PerfilUsu.idPerfil == 85 || clsVarGlobal.PerfilUsu.idPerfil == 56)
            {
                pintarCuadricula();
                DataGridViewButtonColumn btnAsignar = new DataGridViewButtonColumn();
                btnAsignar.HeaderText = "Actividad";
                btnAsignar.Name = "btnAsignar";
                btnAsignar.Text = "Reasignar";
                btnAsignar.UseColumnTextForButtonValue = true;

                dtgOfertasCre.Columns.Add(btnAsignar);
                ajustarCuadricula();
            }
            else
            {
                pintarCuadricula();
                ajustarCuadricula();
            }
        }
        private void ordenarColumna(int dtgColumnIndex)
        {
            if (dtgColumnIndex == 0)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.idCli).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.idCli).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
            if (dtgColumnIndex == 1)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.cDocumentoID).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.cDocumentoID).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
            if (dtgColumnIndex == 2)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.cNombre).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.cNombre).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
            if (dtgColumnIndex == 3)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.cProducto).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.cProducto).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
            if (dtgColumnIndex == 4)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.nMontoOferta).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.nMontoOferta).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
            if (dtgColumnIndex == 5)
            {
                if (dtgColumnIndex == columna && orden == 0)
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderByDescending(oferta => oferta.cOperacion).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 1;
                }
                else
                {
                    var lstOfertasOrdenadas = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                                         oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()))
                                                        .OrderBy(oferta => oferta.cOperacion).ToList();
                    configurarDTG(lstOfertasOrdenadas);
                    columna = dtgColumnIndex;
                    orden = 0;
                }
            }
        }
 
        private void cboCampania_SelectedIndexChanged(object sender, EventArgs e)
        {
            idGrupoCamp = Convert.ToInt32(cboCampania.SelectedValue.ToString());
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            idRegion = Convert.ToInt32(cboRegion.SelectedValue.ToString());
            cargarOficina(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idRegion);
        }

        private void cboOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            idOficina = Convert.ToInt32(cboOficina.SelectedValue.ToString());
            cargarEstablecimiento(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idOficina);
        }

        private void cboEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue.ToString());
            cargarAsesor(idEstablecimiento);
        }

        private void cboAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAsesor = Convert.ToInt32(cboAsesor.SelectedValue.ToString());
        }

        private void btnBuscarOfertas_Click(object sender, EventArgs e)
        {
            limpiarEtiquetas();
            cargarOfertasCre();
        }
                
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (lstOfertas == null)
            {
                cargarOfertasCre();
            }

            var lstClientesFiltrados = lstOfertas.Where(oferta => oferta.cDocumentoID.ToLower().Contains(txtCliente.Text.ToLower().Trim()) ||
                                                               oferta.cNombre.ToLower().Contains(txtCliente.Text.ToLower().Trim()));

            configurarDTG(lstClientesFiltrados.ToList());
        }
        
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            frmBloquearClienteEAI objFrmBloquearClienteEAI = new frmBloquearClienteEAI();
            objFrmBloquearClienteEAI.ShowDialog();
        }
        private void dtgOfertasCre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12 && clsVarGlobal.PerfilUsu.idPerfil == 34 && e.RowIndex != -1)
            {
                int idCli = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells["idCli"].Value.ToString());
                int idOferta = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells["idOferta"].Value.ToString());
                Decimal nSaldoOferta = Convert.ToDecimal(dtgOfertasCre.Rows[e.RowIndex].Cells["nSaldoOferta"].Value.ToString());
                String cDocumentoID = Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells["cDocumentoID"].Value.ToString());

                int? idEstadoCred = 0;
                DataTable dtValidaOfertasCre = new DataTable();
                DataTable dtNroCredEAI = new DataTable();
                dtValidaOfertasCre = cnCredito.CNBuscarOfertasCre(idGrupoCamp, idRegion, idOficina, idEstablecimiento, idAsesor);

                dtNroCredEAI = cnCredito.CNNroCredEAI(clsVarGlobal.dFecSystem, idCli);
                List<clsOfertasCred> lstOfertas = (dtValidaOfertasCre.Rows.Count > 0) ? dtValidaOfertasCre.ToList<clsOfertasCred>() as List<clsOfertasCred> : new List<clsOfertasCred>();

                foreach (var item in lstOfertas)
                {
                    if (item.idOferta == idOferta)
                    {
                        idEstadoCred = item.idEstado;
                    }
                }

                if (Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells["idEstado"].Value ?? string.Empty) == "5" || idEstadoCred == 5)
                {
                    if (dtNroCredEAI.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtNroCredEAI.Rows[0]["nNroCreditos"]) >= 2)
                        {
                            MessageBox.Show("El Cliente realizó 02 desembolsos en el presente mes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                if (idCli == 0)
                {
                    MessageBox.Show("Debe realizar el mantenimiento del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmRegistroClientes a = new frmRegistroClientes();
                    a.ShowDialog();
                    cargarOfertasCre();
                    return;
                }

                frmSolicitudClienteAprobado objFrmSolicitudClienteAprobado = new frmSolicitudClienteAprobado(clsVarGlobal.PerfilUsu.idUsuario, idEstablecimiento, idCli, cDocumentoID, idOferta, dtNroCredEAI, nSaldoOferta);
                objFrmSolicitudClienteAprobado.ShowDialog();

                if (objFrmSolicitudClienteAprobado.lSolicitudAprob == true)
                    cargarOfertasCre();
            }

            if (e.ColumnIndex == 13 && clsVarGlobal.PerfilUsu.idPerfil == 34 && e.RowIndex != -1)
            {
                int idCli = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells[0].Value.ToString());
                String cDocumentoID = Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells[1].Value.ToString());
                int idOferta = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells["idOferta"].Value.ToString());

                if (idCli == 0)
                {
                    MessageBox.Show("Debe realizar el mantenimiento del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmRegistroClientes a = new frmRegistroClientes();
                    a.ShowDialog();
                    cargarOfertasCre();
                    return;
                }

                frmRegistroInfClienteOferta objfrmRegistroInfClienteOferta = new frmRegistroInfClienteOferta(idCli, cDocumentoID);
                objfrmRegistroInfClienteOferta.ShowDialog();
                pintarCuadricula();
            }

            if (e.ColumnIndex <= 8 || e.ColumnIndex >= 11)
            {
                int idCli;
                if (e.RowIndex == -1)
                {
                    ordenarColumna(e.ColumnIndex);
                }
                else
                {
                    idCli = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells["idCli"].Value.ToString());

                    String cDocumentoID = Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells["cDocumentoID"].Value.ToString());
                    int idOferta = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells["idOferta"].Value.ToString());

                    DataTable dtGestionCliente = new DataTable();
                    dtGestionCliente = cnCredito.CNRecuperaGestionCli(cDocumentoID, idOferta);

                    if (idCli == 0 && clsVarGlobal.PerfilUsu.idPerfil == 34)
                    {
                        MessageBox.Show("Debe realizar el mantenimiento del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmRegistroClientes a = new frmRegistroClientes();
                        a.ShowDialog();
                        cargarOfertasCre();
                        return;
                    }

                    limpiarEtiquetas();

                    lblNombre.Text = Convert.ToString(dtGestionCliente.Rows[0]["cNombreCliOferta"].ToString());
                    lblTelefono.Text = Convert.ToString(dtGestionCliente.Rows[0]["cNumeroTelefonico"].ToString());
                    lblCorreo.Text = Convert.ToString(dtGestionCliente.Rows[0]["cCorreoCli"].ToString());
                    lblTContacto.Text = Convert.ToString(dtGestionCliente.Rows[0]["cTipContacto"].ToString());
                    lblRContacto.Text = Convert.ToString(dtGestionCliente.Rows[0]["cRespuesta"].ToString());
                    lblDireccion.Text = Convert.ToString(dtGestionCliente.Rows[0]["cDireccion"].ToString());

                    lblNombre.AutoSize = false;
                    lblCorreo.AutoSize = false;
                    lblDireccion.AutoSize = false;

                    dtGestionCliente.Clear();
                }
            }

            if (e.ColumnIndex == 9 && (clsVarGlobal.PerfilUsu.idPerfil == 56 || clsVarGlobal.PerfilUsu.idPerfil == 85))
            {

                int idCli = Convert.ToInt32(dtgOfertasCre.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells["idEstado"].Value ?? string.Empty) == "2")
                {
                    MessageBox.Show("Esta oferta se encuentra lista para desembolso, no se puede asignar a otro Asesor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells["idEstado"].Value ?? string.Empty) == "5")
                {
                    MessageBox.Show("Esta oferta ya fue desembolsada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmReasignarClienteAprobado objfrmReasignarClienteAprobado = new frmReasignarClienteAprobado(Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells[1].Value.ToString()),
                                                                                                            Convert.ToString(dtgOfertasCre.Rows[e.RowIndex].Cells[2].Value.ToString()),
                                                                                                            dtAsesor);
                objfrmReasignarClienteAprobado.ShowDialog();
            }
        }


    }
}

public class clsOfertasCred
{
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Producto { get; set; }
    public Decimal Oferta { get; set; }
    public string Operación { get; set; }
    public int? idSolicitud { get; set; }
    public int? idEstado { get; set; }
    public int idOferta { get; set; }

    public clsOfertasCred()
    {
        DNI = string.Empty;
        Nombre = string.Empty;
        Producto = string.Empty;
        Oferta = 0;
        Operación = string.Empty;
        idSolicitud = null;
        idEstado = null;
        idOferta = 0;
    }
}

public class clsOfertaCred
{
    public int? idCli { get; set; }
    public string cDocumentoID { get; set; }
    public string cNombre { get; set; }
    public string cProducto { get; set; }
    public Decimal nMontoOferta { get; set; }
    public Decimal nSaldoOferta { get; set; }
    public string cOperacion { get; set; }
    public int nOperaciones { get; set; }
    public int? idSolicitud { get; set; }
    public int? idEstado { get; set; }
    public int idOferta { get; set; }
    public string cOferta { get; set; }

    public clsOfertaCred()
    {
        idCli = null;
        cDocumentoID = string.Empty;
        cNombre = string.Empty;
        cProducto = string.Empty;
        nMontoOferta = 0;
        nSaldoOferta = 0;
        cOperacion = string.Empty;
        nOperaciones = 0;
        idSolicitud = null;
        idEstado = null;
        idOferta = 0;
        cOferta = null;
    }
}