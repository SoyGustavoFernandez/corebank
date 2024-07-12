using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmMantenimientoPaqueteSeguros : frmBase
    {
        #region Variables Globales
        clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        clsMantenimientoPaqueteSeguro oPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        clsMantenimientoPaqueteSeguro oPaqueteSeguroTemp = new clsMantenimientoPaqueteSeguro();
        public List<clsMantenimientoPaqueteSeguro> listaPaqueteSeguro = new List<clsMantenimientoPaqueteSeguro>();
        public List<clsSeguroComplementario> _listaSegurosComplementario = new List<clsSeguroComplementario>();
        public List<clsAgencia> _listaPaqueteSeguroEstablecimiento = new List<clsAgencia>();
        public List<clsPerfil> _listaPaqueteSeguroPerfil = new List<clsPerfil>();
        DataSet dtListaDetallesPlanSeguros = new DataSet();
        public int idUsuario = clsVarGlobal.User.idUsuario, nfilaseleccionada;
        BindingSource BindingSourceSeguro = new BindingSource();
        BindingSource BindingSourceEstabl = new BindingSource();
        BindingSource BindingSourcePerfil = new BindingSource();
        #endregion;

        public frmMantenimientoPaqueteSeguros()
        {
            InitializeComponent();
            ActualizarPrecioPaquete();
        }
        public void asignarDatos(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            oPaqueteSeguro = _clsMantenimientoPaqueteSeguro;            
            this.chcBase1.CheckedChanged -= new System.EventHandler(this.chcBase1_CheckedChanged);
            chcBase1.Checked = oPaqueteSeguro.cEstado;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            txtPrecioPaqueteSeguro.Enabled = false;
            cboDetalleGasto1.listarDetalleGastoEnSolicitud();
            cboDetalleGasto1.SelectedValue = oPaqueteSeguro.idDetalleGasto;
            cboMoneda1.MonedasYTodos();
            cboMoneda1.SelectedIndex = 0;
            dtListaDetallesPlanSeguros = PaqueteSeguro.CNObtenerPaqueteSeguro(oPaqueteSeguro);
            if (dtListaDetallesPlanSeguros.Tables[0].Rows.Count > 0)
            {
                oPaqueteSeguro = dtListaDetallesPlanSeguros.Tables[0].ToList<clsMantenimientoPaqueteSeguro>()[0];
                oPaqueteSeguroTemp = dtListaDetallesPlanSeguros.Tables[0].ToList<clsMantenimientoPaqueteSeguro>()[0];
                oPaqueteSeguro.listaSeguroCommplementario.AddRange(dtListaDetallesPlanSeguros.Tables[1].ToList<clsSeguroComplementario>());
                oPaqueteSeguro.listaPaqueteSeguroEstablecimiento.AddRange(dtListaDetallesPlanSeguros.Tables[2].ToList<clsAgencia>());
                oPaqueteSeguro.listaPaqueteSeguroPerfil.AddRange(dtListaDetallesPlanSeguros.Tables[3].ToList<clsPerfil>());
            }
            llenarGridPaqueteSeguroConfig();
            llenarGridPaqueteSeguroEstablecimiento();
            llenarGridPaqueteSeguroPerfil();
        }
        public void frmMantenimientoPaqueteSeguros_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            string correos = oPaqueteSeguro.cCorreoReporte;
            string[] correosSeparados = { };
            txtCorreo.Multiline = true;
            txtCorreo.ScrollBars = ScrollBars.Vertical;
            if (correos != null)
            {
                correosSeparados = correos.Split(',');
                correosSeparados = correosSeparados
                    .Select(correo => correo.Trim())
                    .Where(correo => !string.IsNullOrWhiteSpace(correo))
                    .ToArray();
                txtCorreo.Text = string.Join(Environment.NewLine, correosSeparados);
            }
            txtCorreo.ReadOnly = false;
            int idMoneda = oPaqueteSeguro.idMoneda;
            if (idMoneda == 1)
            {
                cboMoneda1.SelectedIndex = 0;
            }
            else if (idMoneda == 2)
            {
                cboMoneda1.SelectedIndex = 1;
            }
            if (oPaqueteSeguro.idPaqueteSeguro > 0)
            {
                chcBase1.Checked = oPaqueteSeguro.cEstado;
            }
            else
            {
                chcBase1.Checked = true;
            }

            txtNombrePaquete.Text = oPaqueteSeguro.cNombreCorto;
            txtPrecioPaqueteSeguro.Text = Convert.ToDecimal(oPaqueteSeguro.nPrecio).ToString();
            txtLinkPaqueteSeguro.Text = oPaqueteSeguro.cLink;
            txtNombrePaqueteSeguro.Text = oPaqueteSeguro.cNombreCompleto;
            ActualizarPrecioPaquete();
        }
        public void llenarGridPaqueteSeguroConfig()
        {
                _listaSegurosComplementario = oPaqueteSeguro.listaSeguroCommplementario.Where(x => x.lSelecciona == true).ToList();
                int order = 1;
                foreach (clsSeguroComplementario item in _listaSegurosComplementario)
                {
                    item.nOrden = order;
                    order++;
                }
                     

            BindingSourceSeguro.DataSource = _listaSegurosComplementario;
            dtgPaqueteSegComplementario.DataSource = BindingSourceSeguro;
            dtgPaqueteSegComplementario.ScrollBars = ScrollBars.Both;
            dtgPaqueteSegComplementario.AutoResizeColumns();
            dtgPaqueteSegComplementario.ClearSelection();
            foreach (DataGridViewColumn columna in dtgPaqueteSegComplementario.Columns)
            {
                columna.Visible = false;
            }
            dtgPaqueteSegComplementario.Columns["nOrden"].Visible = true;
            dtgPaqueteSegComplementario.Columns["cSeguro"].Visible = true;
            dtgPaqueteSegComplementario.Columns["nPrecio"].Visible = true ;
            dtgPaqueteSegComplementario.Columns["nOrden"].DisplayIndex = 0;
            dtgPaqueteSegComplementario.Columns["cSeguro"].DisplayIndex = 1;
            dtgPaqueteSegComplementario.Columns["nPrecio"].DisplayIndex = 2;
            dtgPaqueteSegComplementario.Columns["nOrden"].HeaderText = "Orden";
            dtgPaqueteSegComplementario.Columns["cSeguro"].HeaderText = "Nombre Seguro";
            dtgPaqueteSegComplementario.Columns["nPrecio"].HeaderText = "Precio";
            dtgPaqueteSegComplementario.Refresh();
            ActualizarPrecioPaquete();
        }

        private void ActualizarPrecioPaquete()
        {
            decimal precio = 0;
            if (dtgPaqueteSegComplementario.Rows.Count > 0)
            {
                foreach (DataGridViewRow row1 in dtgPaqueteSegComplementario.Rows)
                {
                    if (Convert.ToBoolean(row1.Cells["lSelecciona"].Value))
                    {
                        precio += Convert.ToDecimal(row1.Cells["nPrecio"].Value);
                    }
                }
            }
            txtPrecioPaqueteSeguro.Text = precio.ToString();
        }

        public void llenarGridPaqueteSeguroEstablecimiento()
        {
            _listaPaqueteSeguroEstablecimiento = oPaqueteSeguro.listaPaqueteSeguroEstablecimiento.ToList();
            BindingSourceEstabl.DataSource = _listaPaqueteSeguroEstablecimiento;
            dtgPaqueteSegEstablecimiento.DataSource = BindingSourceEstabl;
            dtgPaqueteSegEstablecimiento.ScrollBars = ScrollBars.Both;
            dtgPaqueteSegEstablecimiento.ClearSelection();
            foreach (DataGridViewColumn columna in dtgPaqueteSegEstablecimiento.Columns)
            {
                columna.Visible = false;
            }
            dtgPaqueteSegEstablecimiento.Columns["cZona"].Visible = true;
            dtgPaqueteSegEstablecimiento.Columns["cZona"].DisplayIndex = 0;
            dtgPaqueteSegEstablecimiento.Columns["cZona"].HeaderText = "Zona";
            dtgPaqueteSegEstablecimiento.Columns["cNombreAge"].Visible = true;
            dtgPaqueteSegEstablecimiento.Columns["cNombreAge"].DisplayIndex = 1;
            dtgPaqueteSegEstablecimiento.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgPaqueteSegEstablecimiento.Refresh();
        }
        public void llenarGridPaqueteSeguroPerfil()
        {
            _listaPaqueteSeguroPerfil = oPaqueteSeguro.listaPaqueteSeguroPerfil.ToList();
            BindingSourcePerfil.DataSource = _listaPaqueteSeguroPerfil;
            dtgPaqueteSegPerfil.DataSource = BindingSourcePerfil;
            dtgPaqueteSegPerfil.ScrollBars = ScrollBars.Both;
            dtgPaqueteSegPerfil.AutoResizeColumns();
            dtgPaqueteSegPerfil.ClearSelection();
            foreach (DataGridViewColumn columna in dtgPaqueteSegPerfil.Columns)
            {
                columna.Visible = false;
            }
            dtgPaqueteSegPerfil.Columns["cPerfil"].Visible = true;
            dtgPaqueteSegPerfil.Columns["cPerfil"].HeaderText = "Perfil";
            dtgPaqueteSegPerfil.Refresh();
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            validarDatos();
        }
        public void validarDatos()
        {
            string texto = txtCorreo.Text;
            string correos = Regex.Replace(texto, @"\n+", ",");
            clsMantenimientoPaqueteSeguro clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();

            if (string.IsNullOrEmpty(txtNombrePaqueteSeguro.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre para el nuevo Plan", "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombrePaqueteSeguro.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNombrePaquete.Text))
            {
                MessageBox.Show("Debe ingresar nombre corto para el Plan.", "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombrePaquete.Focus();
                return;
            }

            if (Convert.ToDecimal(txtPrecioPaqueteSeguro.Text) <= 0)
            {
                MessageBox.Show("El precio del plan debe se mayor a cero, adicione seguros complementarios", "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioPaqueteSeguro.Focus();
                return;
            }

            if (!clsUtils.EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido para el envío de reportes", "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCorreo.Focus();
                return;
            }

            clsMantenimientoPaqueteSeguro.idPaqueteSeguro = oPaqueteSeguro.idPaqueteSeguro;
            clsMantenimientoPaqueteSeguro.cNombreCompleto = txtNombrePaqueteSeguro.Text;
            clsMantenimientoPaqueteSeguro.cNombreCorto = txtNombrePaquete.Text;
            clsMantenimientoPaqueteSeguro.nPrecio = Convert.ToDecimal(txtPrecioPaqueteSeguro.Text);
            clsMantenimientoPaqueteSeguro.idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            clsMantenimientoPaqueteSeguro.cEstado = Convert.ToBoolean(chcBase1.Checked);
            clsMantenimientoPaqueteSeguro.cCorreoReporte = correos;
            clsMantenimientoPaqueteSeguro.idDetalleGasto = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
            clsMantenimientoPaqueteSeguro.idUsuario = idUsuario;
            string NombrePaqueteSeguro = cboDetalleGasto1.Text;
            string NombrePaqueteSeguros = NombrePaqueteSeguro.Replace("SEGURO ", "").ToUpper();
            string cDetalleGasto = NombrePaqueteSeguros + "  + ";
            string cNombreAdicional = clsMantenimientoPaqueteSeguro.cNombreCompleto.Replace(cDetalleGasto, "");
            clsMantenimientoPaqueteSeguro.cNombreAdicional = cNombreAdicional;
            clsMantenimientoPaqueteSeguro.idConcepto = oPaqueteSeguro.idConcepto;

            //Agregar a un datatable
            DataTable dtPaqueteSeguro = new DataTable();
            dtPaqueteSeguro.Columns.Add("idPaquete", typeof(string));
            dtPaqueteSeguro.Columns.Add("cNombreCorto", typeof(string));
            dtPaqueteSeguro.Columns.Add("cNombreCompleto", typeof(string));
            dtPaqueteSeguro.Columns.Add("nPrecio", typeof(decimal));
            dtPaqueteSeguro.Columns.Add("idMoneda", typeof(int));
            dtPaqueteSeguro.Columns.Add("cLink", typeof(string));
            dtPaqueteSeguro.Columns.Add("cCorreoReporte", typeof(string));
            dtPaqueteSeguro.Columns.Add("idUsuario", typeof(int));
            dtPaqueteSeguro.Columns.Add("cEstado", typeof(int));
            dtPaqueteSeguro.Columns.Add("idDetalleGasto", typeof(int));
            dtPaqueteSeguro.Columns.Add("idConcepto", typeof(int));
            dtPaqueteSeguro.Columns.Add("cNombreAdicional", typeof(string));
            dtPaqueteSeguro.Columns["nPrecio"].ExtendedProperties["Precision"] = 14;
            dtPaqueteSeguro.Rows.Add(clsMantenimientoPaqueteSeguro.idPaqueteSeguro, clsMantenimientoPaqueteSeguro.cNombreCorto, clsMantenimientoPaqueteSeguro.cNombreCompleto,
                clsMantenimientoPaqueteSeguro.nPrecio, clsMantenimientoPaqueteSeguro.idMoneda, clsMantenimientoPaqueteSeguro.cLink, clsMantenimientoPaqueteSeguro.cCorreoReporte,
                clsMantenimientoPaqueteSeguro.idUsuario, Convert.ToInt32(clsMantenimientoPaqueteSeguro.cEstado), clsMantenimientoPaqueteSeguro.idDetalleGasto,
                clsMantenimientoPaqueteSeguro.idConcepto, clsMantenimientoPaqueteSeguro.cNombreAdicional);

            //Agregar al datatable los seguros complementarios
            DataTable dtSegurosComplementario = new DataTable();
            dtSegurosComplementario.Columns.Add("idSeguro", typeof(int));
            dtSegurosComplementario.Columns.Add("lVigente", typeof(int));
            foreach (var item in _listaSegurosComplementario)
            {
                DataRow newRow = dtSegurosComplementario.NewRow();
                newRow["idSeguro"] = item.idSeguro;
                newRow["lVigente"] = Convert.ToInt32(item.lVigente);
                if(!item.lVigente)
                {
                    MessageBox.Show("No se puede agregar seguros complementarios no vigentes.", "Seguros Complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtSegurosComplementario.Rows.Add(newRow);
            }

            //Agregar al datatable los seguros complementarios
            DataTable dtSegurosEstable = new DataTable();
            dtSegurosEstable.Columns.Add("idAgencia", typeof(int));
            dtSegurosEstable.Columns.Add("cNombreAge", typeof(string));
            dtSegurosEstable.Columns.Add("lEstado", typeof(int));
            foreach (var item in _listaPaqueteSeguroEstablecimiento)
            {
                DataRow newRow = dtSegurosEstable.NewRow();
                newRow["idAgencia"] = item.idAgencia;
                newRow["cNombreAge"] = item.cNombreAge;
                newRow["lEstado"] = Convert.ToInt32(item.lEstado);
                dtSegurosEstable.Rows.Add(newRow);
            }

            //Agregar al datatable los seguros complementarios
            DataTable dtSegurosPerfil = new DataTable();
            dtSegurosPerfil.Columns.Add("idPerfil", typeof(int));
            dtSegurosPerfil.Columns.Add("cPerfil", typeof(string));
            dtSegurosPerfil.Columns.Add("lVigente", typeof(int));
            foreach (var item in _listaPaqueteSeguroPerfil)
            {
                DataRow newRow = dtSegurosPerfil.NewRow();
                newRow["idPerfil"] = item.idPerfil;
                newRow["cPerfil"] = item.cPerfil;
                newRow["lVigente"] = Convert.ToInt32(item.lVigente);
                dtSegurosPerfil.Rows.Add(newRow);
            }
            DataSet dsPaqueteSeguro = new DataSet("dsPaqueteSeguro");
            dsPaqueteSeguro.Tables.Add(dtPaqueteSeguro);
            dsPaqueteSeguro.Tables.Add(dtSegurosComplementario);
            dsPaqueteSeguro.Tables.Add(dtSegurosEstable);
            dsPaqueteSeguro.Tables.Add(dtSegurosPerfil);
            string xmlDatosPlanSeguro = dsPaqueteSeguro.GetXml();
            xmlDatosPlanSeguro = clsCNFormatoXML.EncodingXML(xmlDatosPlanSeguro);
            DataTable dtMatenimientoPaqSeg = PaqueteSeguro.CNMantenimientoPaqueteSeguros(xmlDatosPlanSeguro);
            MessageBox.Show(dtMatenimientoPaqSeg.Rows[0]["cMensaje"].ToString(), "Mantenimiento de seguros", MessageBoxButtons.OK, ((int)dtMatenimientoPaqSeg.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
            this.Close();
        }
        private void btnMiniEditarSeguro_Click(object sender, EventArgs e)
        {
            frmSegurosComplementarios frmsegurosComplementarios = new frmSegurosComplementarios(oPaqueteSeguro);
            frmsegurosComplementarios.ShowDialog();
            llenarGridPaqueteSeguroConfig();
        }
      
        private void btnMiniQuitarSeguro_Click(object sender, EventArgs e)
        {
            if (dtgPaqueteSegComplementario.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar el seguro que desea eliminar", "Mantenimiento de Planes de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de desafiliar el seguro?", "Eliminar Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int nfilaseleccionada = Convert.ToInt32(dtgPaqueteSegComplementario.CurrentCell.RowIndex);
                    oPaqueteSeguro.listaSeguroCommplementario.RemoveAll(x => x.idSeguro == Convert.ToInt32(dtgPaqueteSegComplementario.Rows[nfilaseleccionada].Cells["idSeguro"].Value.ToString()));

                }
                llenarGridPaqueteSeguroConfig();
            }

        }
        private void btnMiniAgregarPerfil_Click(object sender, EventArgs e)
        {
            frmConfigurarPerfilesPaqSeguro frmConfigurarPerfilesPaqSeguro = new frmConfigurarPerfilesPaqSeguro();
            frmConfigurarPerfilesPaqSeguro.asignarDatos(oPaqueteSeguro);
            frmConfigurarPerfilesPaqSeguro.ShowDialog();
            llenarGridPaqueteSeguroPerfil();
        }
        private void btnMiniAgregarEstablecimiento_Click(object sender, EventArgs e)
        {
            frmConfigurarAgenciaPaqSeguro frmConfigurarEstablecimientoPaqSeguro = new frmConfigurarAgenciaPaqSeguro();
            frmConfigurarEstablecimientoPaqSeguro.asignarDatos(oPaqueteSeguro);
            frmConfigurarEstablecimientoPaqSeguro.ShowDialog();
            llenarGridPaqueteSeguroEstablecimiento();
        }
        private void btnMiniQuitarEstablecimiento_Click(object sender, EventArgs e)
        {

            if (dtgPaqueteSegEstablecimiento.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar la agencia que desea eliminar", "Mantenimiento de Paquetes de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int nfilaseleccionada = Convert.ToInt32(dtgPaqueteSegEstablecimiento.CurrentCell.RowIndex);
                if (MessageBox.Show("¿Está seguro de eliminar la agencia?", "Eliminar Agencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    oPaqueteSeguro.listaPaqueteSeguroEstablecimiento.RemoveAll(x => x.idAgencia == Convert.ToInt32(dtgPaqueteSegEstablecimiento.Rows[nfilaseleccionada].Cells["idAgencia"].Value.ToString()));
                }
                llenarGridPaqueteSeguroEstablecimiento();
            }
        }
        private void btnMiniQuitarPerfil_Click(object sender, EventArgs e)
        {
            if (dtgPaqueteSegPerfil.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar el perfil que desea eliminar", "Mantenimiento de Planes de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int nfilaseleccionada = Convert.ToInt32(dtgPaqueteSegPerfil.CurrentCell.RowIndex);
                if (MessageBox.Show("¿Está seguro de eliminar el perfil ?", "Eliminar Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    oPaqueteSeguro.listaPaqueteSeguroPerfil.RemoveAll(x => x.idPerfil == Convert.ToInt32(dtgPaqueteSegPerfil.Rows[nfilaseleccionada].Cells["idPerfil"].Value.ToString()));
                }
                llenarGridPaqueteSeguroPerfil();
            }
        }

        private void txtLinkPaqueteSeguro_TextChanged(object sender, EventArgs e)
        {
            if (txtLinkPaqueteSeguro.Text.Length > 200)
            {
                txtLinkPaqueteSeguro.Text = txtLinkPaqueteSeguro.Text.Substring(0, 200);
                txtLinkPaqueteSeguro.SelectionStart = 200;
            }
        }

        private void txtPrecioPaqueteSeguro_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            if (decimal.TryParse(txtPrecioPaqueteSeguro.Text, out value))
            {
                int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
                if (decimalPlaces > 2)
                {
                    value = Math.Round(value, 2);
                    txtPrecioPaqueteSeguro.Text = value.ToString("0.00");
                    txtPrecioPaqueteSeguro.SelectionStart = txtPrecioPaqueteSeguro.Text.Length;
                }
            }
            else
            {
                txtPrecioPaqueteSeguro.Text = string.Empty;
            }
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (!chcBase1.Checked)
            {
                if (oPaqueteSeguroTemp.cEstado == true && oPaqueteSeguroTemp.idPaqueteSeguro > 0)
                {
                    if (MessageBox.Show("Desea desactivar el plan: " + txtNombrePaqueteSeguro.Text + " ? ", "Confirmación de desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        chcBase1.Checked = false;
                    }
                    else
                    {
                        chcBase1.Checked = true;
                    }
                }
            }
        }
    }
}