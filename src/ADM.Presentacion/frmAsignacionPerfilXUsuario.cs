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
using System.IO;
using GEN.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmAsignacionPerfilXUsuario : frmBase
    {
        #region Variables

        clsCNMantenimiento PerfilByUsuario = new clsCNMantenimiento();
        DataTable dtAsignados = new DataTable();
        DataTable dtNoAsignados = new DataTable();
        string cDocumentoSesion;
        byte[] vDocumentoSesion;
        string cExtension;
       
        #endregion

        public frmAsignacionPerfilXUsuario()
        {
            InitializeComponent();            
            
        }

        #region Eventos

        private void frmAsignacionPerfilXUsuario_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            dtpIni.Value = clsVarGlobal.dFecSystem;
            dtpFin.Value = clsVarGlobal.dFecSystem.AddDays(1.00);
            cargarTiposPerfil();
            habilitarControles(false);
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            cargarUsuario();            
        }       

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (dtgPerfilNoAsignado.SelectedRows.Count > 0)
            {
                if (validar())
                {
                    if (MessageBox.Show("¿Esta Seguro de Asignar los perfiles?", "Asignar Perfiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        var dtPerfil = dtAsignados.Clone();
                        DataRow drNuevo = dtPerfil.NewRow();
                        drNuevo["cPerfil"] = dtgPerfilNoAsignado.SelectedRows[0].Cells["cPerfil"].Value.ToString();
                        drNuevo["idPerfil"] = Convert.ToInt32(dtgPerfilNoAsignado.SelectedRows[0].Cells["idPerfil"].Value.ToString());
                        drNuevo["idPerfilUsu"] = 0;
                        drNuevo["idUsuario"] = Convert.ToInt32(conBusCol1.idUsu);
                        drNuevo["lPrincipal"] = Convert.ToInt32(cboTipoPerfil.SelectedValue) == 1 ? true : false;
                        drNuevo["dFecIni"] = dtpIni.Value.Date;
                        drNuevo["dFecFin"] = dtpFin.Value.Date;
                        drNuevo["idUsuReg"] = clsVarGlobal.User.idUsuario;
                        drNuevo["lVigente"] = true;
                        dtPerfil.Rows.Add(drNuevo);
                        dtPerfil.AcceptChanges();

                        /*========================================================================================
                          REGISTRO DE RASTREO
                        ========================================================================================*/
                        this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Inicio-Asignacion de perfil a usuario", this.btnAgregar1);
                        /*========================================================================================
                         * FIN DEL REGISTRO DE RASTREO
                         ========================================================================================*/
                        DataSet ds = new DataSet("dsPerfilAsignado");
                        ds.Tables.Add(dtPerfil);
                        String XmlPerfilAsignado = ds.GetXml();
                        XmlPerfilAsignado = clsCNFormatoXML.EncodingXML(XmlPerfilAsignado);

                        PerfilByUsuario.GrabarPerfilAsignado(XmlPerfilAsignado,cDocumentoSesion,vDocumentoSesion,cExtension);

                        MessageBox.Show("Los Perfiles Fueron Asignados Correctamente", "Asignar Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarUsuario();
                    }

                    /*========================================================================================
                   * REGISTRO DE RASTREO
                   ========================================================================================*/

                    this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Fin-Asignacion de perfil a usuario", this.btnAgregar1);
                    /*========================================================================================
                     * FIN DEL REGISTRO DE RASTREO
                     ========================================================================================*/
                }
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dtAsignados.Rows.Count > 0)
            {
                var dtPerfil = dtAsignados.Clone();
                DataRow drPerfilEliminado = dtPerfil.NewRow();
                drPerfilEliminado["cPerfil"] = dtgPerfilAsignado.SelectedRows[0].Cells["cPerfil"].Value.ToString();
                drPerfilEliminado["idPerfil"] = Convert.ToInt32(dtgPerfilAsignado.SelectedRows[0].Cells["idPerfil"].Value);
                drPerfilEliminado["idPerfilUsu"] = Convert.ToInt32(dtgPerfilAsignado.SelectedRows[0].Cells["idPerfilUsu"].Value);
                drPerfilEliminado["idUsuario"] = Convert.ToInt32(dtgPerfilAsignado.SelectedRows[0].Cells["idUsuario"].Value);
                drPerfilEliminado["idUsuReg"] = clsVarGlobal.User.idUsuario;
                drPerfilEliminado["lVigente"] = false;
                dtPerfil.Rows.Add(drPerfilEliminado);
                dtPerfil.AcceptChanges();

                if (MessageBox.Show("¿Está seguro de eliminar el perfil?", "Eliminar Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    cDocumentoSesion = "";
                    vDocumentoSesion = new byte[0];
                    cExtension = "";
                    DataSet ds = new DataSet("dsPerfilAsignado");
                    ds.Tables.Add(dtPerfil);
                    String XmlPerfilAsignado = ds.GetXml();
                    XmlPerfilAsignado = clsCNFormatoXML.EncodingXML(XmlPerfilAsignado);
                    PerfilByUsuario.GrabarPerfilAsignado(XmlPerfilAsignado,cDocumentoSesion,vDocumentoSesion,cExtension);
                    MessageBox.Show("El perfil fue eliminado correctamente", "Eliminar Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarUsuario();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            conBusCol1.txtCod.Focus();
        }
        
        private void cboTipoPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboTipoPerfil.SelectedValue is DataRowView))
            {
                if (cboTipoPerfil.SelectedIndex >= 0)
                {
                    if (Convert.ToInt32(cboTipoPerfil.SelectedValue) == 1)
                    {
                        lblA.Visible = false;
                        lblDe.Visible = false;
                        dtpIni.Visible = false;
                        dtpFin.Visible = false;
                    }
                    else
                    {
                        lblA.Visible = true;
                        lblDe.Visible = true;
                        dtpIni.Visible = true;
                        dtpFin.Visible = true;
                    }
                }
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cArchivo = fDialog.FileName;
                FileInfo fInfo = new FileInfo(cArchivo);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                txtDocSustento.Text = cArchivo;
                cDocumentoSesion = fInfo.Name;
                vDocumentoSesion = br.ReadBytes((int)numBytes);
                cExtension = fInfo.Extension;
                fStream.Flush();
                fStream.Close();
                br.Close();
            }
        }
               
        #endregion

        #region Metodos

        private void cargarUsuario()
        {
            int idUsuario;
            if (String.IsNullOrEmpty(conBusCol1.idUsu))
            {
                idUsuario = -1;
            }
            else
            {
                habilitarControles(true);
                idUsuario = Convert.ToInt32(conBusCol1.idUsu);
                dtAsignados = mostraPerfilesXUsuario(idUsuario, 1);
                dtNoAsignados = mostraPerfilesXUsuario(idUsuario, 0);
                dtgPerfilNoAsignado.DataSource = dtNoAsignados;
                dtgPerfilAsignado.DataSource = dtAsignados;
                formatoGrids();
                
            }
        }

        private bool validar()
        {
            bool lVal = false;

            if ((dtpFin.Value.Date - dtpIni.Value.Date).Ticks <= 0 && Convert.ToInt32(cboTipoPerfil.SelectedValue) == 2)
            {
                MessageBox.Show("La fecha final debe de ser mayor a la fecha inicial", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFin.Value = clsVarGlobal.dFecSystem.AddDays(1); ;
                return lVal;
            }

            if ((dtpIni.Value.Date - clsVarGlobal.dFecSystem).Ticks < 0 && Convert.ToInt32(cboTipoPerfil.SelectedValue) == 2)
            {
                MessageBox.Show("La fecha inicial debe de ser mayor a la fecha del sistema", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpIni.Value = clsVarGlobal.dFecSystem;
                return lVal;
            }

            int nValPrincipal = 0;
            if (dtgPerfilAsignado.Rows.Count > 0)
            {
                for (int i = 0; i < dtgPerfilAsignado.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgPerfilAsignado.Rows[i].Cells["lPrincipal"].Value) == true)
                    {
                        nValPrincipal++;
                    }
                }
                if (nValPrincipal > 0  && Convert.ToInt32(cboTipoPerfil.SelectedValue) == 1)
                {
                    MessageBox.Show("Ya se registro un perfil como PRINCIPAL", "Asignación de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return lVal;
                }
            }

            if (txtDocSustento.Text == "")
            {
                MessageBox.Show("Debe de adjuntar documento de sustento", "Asignación de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void formatoGrids()
        {
            foreach (DataGridViewColumn item in dtgPerfilAsignado.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;                
            }

            foreach (DataGridViewColumn item in dtgPerfilNoAsignado.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPerfilAsignado.Columns["cPerfil"].Visible = true;
            dtgPerfilAsignado.Columns["lPrincipal"].Visible = true;
            dtgPerfilAsignado.Columns["dFecIni"].Visible = true;
            dtgPerfilAsignado.Columns["dFecFin"].Visible = true;

            dtgPerfilNoAsignado.Columns["cPerfil"].Visible = true;

            dtgPerfilAsignado.Columns["cPerfil"].HeaderText = "Perfil Asignado";
            dtgPerfilAsignado.Columns["lPrincipal"].HeaderText = "Principal";
            dtgPerfilAsignado.Columns["dFecIni"].HeaderText = "Fec.Ini";
            dtgPerfilAsignado.Columns["dFecFin"].HeaderText = "Fec.Fin";

            dtgPerfilNoAsignado.Columns["cPerfil"].HeaderText = "Perfil No Asignado";

            dtgPerfilAsignado.Columns["cPerfil"].Width = 180;
            dtgPerfilAsignado.Columns["lPrincipal"].Width = 55;
        }
        
        private DataTable mostraPerfilesXUsuario(int idUsuario, int idOpcion)
        {
            return PerfilByUsuario.ListarPerfilAsigXUsuario(idUsuario, idOpcion);
        }

        private void cargarTiposPerfil()
        {
            var dtTipoPerfil = new DataTable();
            dtTipoPerfil.Columns.Add("idTipoPerfil", typeof(int));
            dtTipoPerfil.Columns.Add("cTipoPerfil", typeof(string));

            var drPerfil = dtTipoPerfil.NewRow();
            drPerfil["idTipoPerfil"] = 1;
            drPerfil["cTipoPerfil"] = "PRINCIPAL";

            dtTipoPerfil.Rows.Add(drPerfil);

            var drPerfil2 = dtTipoPerfil.NewRow();
            drPerfil2["idTipoPerfil"] = 2;
            drPerfil2["cTipoPerfil"] = "SECUNDARIO";

            dtTipoPerfil.Rows.Add(drPerfil2);

            dtTipoPerfil.AcceptChanges();

            cboTipoPerfil.DataSource = dtTipoPerfil;
            cboTipoPerfil.DisplayMember = "cTipoPerfil";
            cboTipoPerfil.ValueMember = "idTipoPerfil";
        }

        private void limpiarControles()
        {
            dtgPerfilAsignado.DataSource = null;
            dtgPerfilNoAsignado.DataSource = null;
            conBusCol1.idUsu = "";
            conBusCol1.txtCargo.Text = "";
            conBusCol1.txtCod.Text = "";
            conBusCol1.txtNom.Text = "";
            txtDocSustento.Text = "";
        }

        private void habilitarControles(bool lVal)
        {
            conBusCol1.Enabled = !lVal;
            cboTipoPerfil.Enabled = lVal;
            btnAgregar1.Enabled = lVal;
            btnEliminar1.Enabled = lVal;
            btnCancelar.Enabled = lVal;
            btnMiniAgregar1.Enabled = lVal;
        }

        #endregion
    }
}
