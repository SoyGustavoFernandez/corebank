using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmAprobadoresViaticos : frmBase
    {
        #region Variables
        private clsCNCuentasPorPagar cnCuentasPorPagar = new clsCNCuentasPorPagar();
        private clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();       
        private List<clsPerfil> lisPerfilesSol = new List<clsPerfil>();
        private List<clsPerfil> lisPerfilesApr = new List<clsPerfil>();
        private List<clsPerfil> lisPerfilesNiv = new List<clsPerfil>();
        #endregion

        #region Metodos


        public frmAprobadoresViaticos()
        {
            InitializeComponent();
        }

        private void cargarPerfiles()
        {
            lisPerfilesSol = Perfiles.ListarPerfiles();
            lisPerfilesSol.Add(new clsPerfil {cPerfil = "TODOS", idPerfil = 0});

            lisPerfilesApr = Perfiles.ListarPerfiles();
            lisPerfilesApr.Add(new clsPerfil { cPerfil = "TODOS", idPerfil = 0 });

            lisPerfilesNiv = Perfiles.ListarPerfiles();
            lisPerfilesNiv.Add(new clsPerfil { cPerfil = "TODOS", idPerfil = 0 });

            
            
            cboSolicitante.DataSource = lisPerfilesSol;
            cboSolicitante.DisplayMember = "cPerfil";
            cboSolicitante.ValueMember = "idPerfil";
            cboSolicitante.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboSolicitante.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboAprobador.DataSource = lisPerfilesApr;
            cboAprobador.DisplayMember = "cPerfil";
            cboAprobador.ValueMember = "idPerfil";
            cboAprobador.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboAprobador.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboPerfilNivel.DataSource = lisPerfilesNiv;
            cboPerfilNivel.DisplayMember = "cPerfil";
            cboPerfilNivel.ValueMember = "idPerfil";
            cboPerfilNivel.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboPerfilNivel.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cargarEtapa()
        {
            DataTable dtEtapa = new DataTable();
            dtEtapa.Columns.Add("idEtapa", typeof(int));
            dtEtapa.Columns.Add("cEtapa", typeof(string));


            DataRow dr = dtEtapa.NewRow();
            dr["idEtapa"] = 1;
            dr["cEtapa"] = "SOLICITUD";
            DataRow dr2 = dtEtapa.NewRow();
            dr2["idEtapa"] = 2;
            dr2["cEtapa"] = "RENDICIÓN";

            dtEtapa.Rows.Add(dr);
            dtEtapa.Rows.Add(dr2);

            cboEtapa.DisplayMember = dtEtapa.Columns["cEtapa"].ToString();
            cboEtapa.ValueMember = dtEtapa.Columns["idEtapa"].ToString();
            cboEtapa.DataSource = dtEtapa;

        }

        private void cargarAlcances()
        {
            DataTable dtAlcance = new DataTable();
            dtAlcance.Columns.Add("idAlcance", typeof(int));
            dtAlcance.Columns.Add("cAlcance", typeof(string));

            DataRow dr = dtAlcance.NewRow();
            dr["idAlcance"] = 1;
            dr["cAlcance"] = "OFICINA";
            DataRow dr2 = dtAlcance.NewRow();
            dr2["idAlcance"] = 2;
            dr2["cAlcance"] = "REGIÓN/ZONA";

            dtAlcance.Rows.Add(dr);
            dtAlcance.Rows.Add(dr2);

            cboAlcance.ValueMember = dtAlcance.Columns["idAlcance"].ToString();
            cboAlcance.DisplayMember = dtAlcance.Columns["cAlcance"].ToString();
            cboAlcance.DataSource = dtAlcance;
        }

        private void cargarConfiguracion()
        {
            DataTable dtListaConfig = cnCuentasPorPagar.listarConfiguracionAprobadores(
                    (int)cboTipoEntrega1.SelectedValue,
                    (int)cboEtapa.SelectedValue,
                    (int)cboSolicitante.SelectedValue,
                    (int)cboAprobador.SelectedValue
                );
            dtgConfigAprobadores.DataSource = dtListaConfig;

           if (dtListaConfig.Rows.Count == 0 && (int)cboSolicitante.SelectedValue != 0 && (int)cboAprobador.SelectedValue != 0)
            {
                btnAgregar1.Visible = true;
            }
            else {
                btnAgregar1.Visible = false;
            }
        }

        private void formatearGrid()
        {
             foreach(DataGridViewColumn item in dtgConfigAprobadores.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

             dtgConfigAprobadores.Columns["cPerfilSolicita"].Visible = true;
             dtgConfigAprobadores.Columns["cPerfilAPrueba"].Visible = true;

             dtgConfigAprobadores.Columns["cPerfilSolicita"].HeaderText = "Pefil Que Solicita";
             dtgConfigAprobadores.Columns["cPerfilAPrueba"].HeaderText = "Perfil Que Aprueba";

             dtgConfigAprobadores.Columns["cPerfilSolicita"].FillWeight = 50;
             dtgConfigAprobadores.Columns["cPerfilAPrueba"].FillWeight = 50;

             DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
             {
                 btnRemove.Name = "btnQuitar";
                 btnRemove.HeaderText = "Quitar";
                 btnRemove.Text = "x";
                 btnRemove.UseColumnTextForButtonValue = true;
                 btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                 btnRemove.FlatStyle = FlatStyle.Standard;
                 btnRemove.CellTemplate.Style.BackColor = Color.Honeydew;
                 dtgConfigAprobadores.Columns.Add(btnRemove);
             }
        }

        private void formatearGridAlcances()
        {
            foreach (DataGridViewColumn item in dtgPerfilAlcance.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPerfilAlcance.Columns["cPerfil"].Visible = true;
            dtgPerfilAlcance.Columns["cAlcance"].Visible = true;
            dtgPerfilAlcance.Columns["cPerfil"].HeaderText = "Perfil";
            dtgPerfilAlcance.Columns["cAlcance"].HeaderText = "Alcance";
            dtgPerfilAlcance.Columns["cPerfil"].FillWeight = 60;
            dtgPerfilAlcance.Columns["cAlcance"].FillWeight = 40;

            DataGridViewButtonColumn btnRemove2 = new DataGridViewButtonColumn();
            {
                btnRemove2.Name = "btnQuitar";
                btnRemove2.HeaderText = "Quitar";
                btnRemove2.Text = "x";
                btnRemove2.UseColumnTextForButtonValue = true;
                btnRemove2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnRemove2.FlatStyle = FlatStyle.Standard;
                btnRemove2.CellTemplate.Style.BackColor = Color.Honeydew;
                dtgPerfilAlcance.Columns.Add(btnRemove2);
            }
        }

        private void cargarAlcancesDePerfiles()
        {
            DataTable dtListaConfig = cnCuentasPorPagar.listarPerfilesAlcanceEntrega(
                    (int)cboPerfilNivel.SelectedValue
                );
            dtgPerfilAlcance.DataSource = dtListaConfig;

            if (dtgPerfilAlcance.Rows.Count == 0 && (int)cboPerfilNivel.SelectedValue != 0)
            {
                btnAgregar2.Visible = true;
                cboAlcance.Visible = true;
                lblAlcance.Visible = true;
            }
            else
            {
                btnAgregar2.Visible = false;
                cboAlcance.Visible = false;
                lblAlcance.Visible = false;
            }
        }
        #endregion

        private void frmAprobadoresViaticos_Load(object sender, EventArgs e)
        {
            cboEtapa.SelectedIndexChanged -= cboEtapa_SelectedIndexChanged;
            cboTipoEntrega1.SelectedIndexChanged -= cboTipoEntrega_SelectedIndexChanged;
            cboSolicitante.SelectedIndexChanged -= cboSolicitante_SelectedIndexChanged;
            cboAprobador.SelectedIndexChanged -= cboAprobador_SelectedIndexChanged;
            cboAlcance.SelectedIndexChanged -= cboAlcance_SelectedIndexChanged;
            cboPerfilNivel.SelectedIndexChanged -= cboPerfilNivel_SelectedIndexChanged;

            cargarPerfiles();
            cboTipoEntrega1.cargarTipoEntrega();
            cargarEtapa();
            cargarAlcances();

            cboSolicitante.SelectedValue = 0;
            cboAprobador.SelectedValue = 0;
            cboPerfilNivel.SelectedValue = 0;
            cboAlcance.SelectedValue = 0;

            cargarConfiguracion();
            formatearGrid();
            cargarAlcancesDePerfiles();
            formatearGridAlcances();

            cboEtapa.SelectedIndexChanged       += cboEtapa_SelectedIndexChanged;
            cboTipoEntrega1.SelectedIndexChanged += cboTipoEntrega_SelectedIndexChanged;
            cboSolicitante.SelectedIndexChanged += cboSolicitante_SelectedIndexChanged;
            cboAprobador.SelectedIndexChanged   += cboAprobador_SelectedIndexChanged;
            cboAlcance.SelectedIndexChanged += cboAlcance_SelectedIndexChanged;
            cboPerfilNivel.SelectedIndexChanged += cboPerfilNivel_SelectedIndexChanged;
        }

        #region Eventos
        private void cboTipoEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConfiguracion();
        }

        private void cboEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConfiguracion();
        }

        private void cboSolicitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConfiguracion();
        }

        private void cboAprobador_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConfiguracion();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (cboSolicitante.SelectedValue == null) {
                MessageBox.Show("Se debe seleccionar un Perfil Solicitante válido", "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAprobador.SelectedValue == null)
            {
                MessageBox.Show("Se debe seleccionar un Perfil Aprobador válido", "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dRes = MessageBox.Show("¿Está seguro de agregar esta configuración?",
                "configuración de Aprobadores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRes == DialogResult.Yes)
            {
                DataTable dtResultado = cnCuentasPorPagar.agregarAprobadorEntrega(
                        (int)cboTipoEntrega1.SelectedValue,
                        (int)cboEtapa.SelectedValue,
                        (int)cboSolicitante.SelectedValue,
                        (int)cboAprobador.SelectedValue,
                        clsVarGlobal.PerfilUsu.idUsuario
                    );

                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 1)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarConfiguracion();
                    }
                    else
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            if (cboPerfilNivel.SelectedValue == null)
            {
                MessageBox.Show("Se debe seleccionar un Perfil válido", "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAlcance.SelectedValue == null)
            {
                MessageBox.Show("Se debe seleccionar un Alcance para su configuración", "Configuración de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dRes = MessageBox.Show("¿Está seguro de agregar esta configuración?",
                "Configuración de Aprobadores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRes == DialogResult.Yes)
            {
                DataTable dtResultado = cnCuentasPorPagar.agregarPerfilAlcanceEntrega(
                        (int)cboAlcance.SelectedValue,
                        (int)cboPerfilNivel.SelectedValue,
                        clsVarGlobal.PerfilUsu.idUsuario
                    );

                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 1)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarAlcancesDePerfiles();
                    }
                    else
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cboAlcance_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarAlcancesDePerfiles();
        }

        private void cboPerfilNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarAlcancesDePerfiles();
            cboAlcance.SelectedValue = 0;
        }

        private void dtgConfigAprobadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgConfigAprobadores.CurrentRow == null)
            {
                return;
            }

            int btnQuitar = dtgConfigAprobadores.Columns["btnQuitar"].Index;

            if (dtgConfigAprobadores.CurrentCell.ColumnIndex.Equals(btnQuitar))
            {
                DialogResult dRes = MessageBox.Show("¿Está seguro de quitar esta configuración?",
                    "Configuración de Aprobadores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    DataTable dtResultado = cnCuentasPorPagar.quitarAprobadorEntrega(
                            (int)cboEtapa.SelectedValue,
                            Convert.ToInt32(dtgConfigAprobadores.Rows[dtgConfigAprobadores.CurrentCell.RowIndex].Cells["idConfiguracion"].Value),
                            clsVarGlobal.PerfilUsu.idUsuario
                        );

                    if (dtResultado.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 1)
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarConfiguracion();
                        }
                        else
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Aprobadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }
        }
        #endregion

        private void dtgPerfilAlcance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnQuitar = dtgPerfilAlcance.Columns["btnQuitar"].Index;

            if (dtgPerfilAlcance.CurrentCell.ColumnIndex.Equals(btnQuitar))
            {
                DialogResult dRes = MessageBox.Show("¿Está seguro de quitar esta configuración?",
                    "configuración de Perfiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    DataTable dtResultado = cnCuentasPorPagar.quitarPerfilEntregaEntrega(
                            Convert.ToInt32(dtgPerfilAlcance.Rows[dtgPerfilAlcance.CurrentCell.RowIndex].Cells["idAlcance"].Value),
                            clsVarGlobal.PerfilUsu.idUsuario
                        );

                    if (dtResultado.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 1)
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarAlcancesDePerfiles();
                        }
                        else
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), "Configuración de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }
        }
    }
}
