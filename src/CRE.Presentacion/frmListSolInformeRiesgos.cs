using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmListSolInformeRiesgos : frmBase
    {
        #region Variables globales
        public int nidSolInfRiesgo = 0;
        public int nidSolCre = 0;
        public string cMotivoSolInformeRiesgo = "";
        public string cCapitalPropuesto = string.Empty;
        public string cNombreAsesor = string.Empty;
        public string cNomCorto = string.Empty;

        clsCNInformeRiesgos InformeRiesgos = new clsCNInformeRiesgos();
        DataTable dtSolInformesRiesgos = new DataTable("dtSolInformesRiesgos");
        DataTable dtSolInformesRiesgosTodos = new DataTable("dtSolInformesRiesgosTodos");
        String cNombreFormulario = "Lista solicitudes de informe de riesgos";
        #endregion

        public frmListSolInformeRiesgos()
        {
            InitializeComponent();

            //Recuperar la lista de todas las 'Solicitudes de Informe de riegos'
            cargarTodo();
        }

        #region Metodos
        private void cargarTodo()
        {
            int idUsuarioSis = clsVarGlobal.PerfilUsu.idUsuario;
            dtSolInformesRiesgos = InformeRiesgos.ListarSolicitudesInformeRiesgo(idUsuarioSis);
            dtgSolInformeRiesgos.DataSource = dtSolInformesRiesgos;

            dtSolInformesRiesgosTodos = InformeRiesgos.ListarSolicitudesInformeRiesgo(0);
            dtgSolInformeRiesgosTodos.DataSource = dtSolInformesRiesgosTodos;

            DarFormatoGridSolicitudInformes();
            DarFormatoGridSolicitudInformesTodos();
        }

        private void DarFormatoGridSolicitudInformes()
        {
            foreach (DataGridViewColumn item in dtgSolInformeRiesgos.Columns)
            {
                item.Visible = false;
            }

            dtgSolInformeRiesgos.Columns["idSolInfRiesgo"].Visible = true;
            dtgSolInformeRiesgos.Columns["idSolCre"].Visible = true;
            dtgSolInformeRiesgos.Columns["cNombre"].Visible = true;
            dtgSolInformeRiesgos.Columns["nCapitalSolicitado"].Visible = true;
            dtgSolInformeRiesgos.Columns["cMoneda"].Visible = true;
            dtgSolInformeRiesgos.Columns["TipoCredito"].Visible = true;
            dtgSolInformeRiesgos.Columns["cOperacion"].Visible = true;
            dtgSolInformeRiesgos.Columns["cNombreAsesor"].Visible = true;
            dtgSolInformeRiesgos.Columns["cNomCorto"].Visible = true;
            dtgSolInformeRiesgos.Columns["dFechaRegistro"].Visible = true;
            dtgSolInformeRiesgos.Columns["cAnalistaRsg"].Visible = true;

            dtgSolInformeRiesgos.Columns["idSolInfRiesgo"].HeaderText = "Solicitud Inf. Riesgo";
            dtgSolInformeRiesgos.Columns["idSolCre"].HeaderText = "Solicitud de Crédito";
            dtgSolInformeRiesgos.Columns["cNombre"].HeaderText = "Cliente";
            dtgSolInformeRiesgos.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolInformeRiesgos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolInformeRiesgos.Columns["TipoCredito"].HeaderText = "Tipo de crédito";
            dtgSolInformeRiesgos.Columns["cOperacion"].HeaderText = "Operación";
            dtgSolInformeRiesgos.Columns["cNombreAsesor"].HeaderText = "Asesor";
            dtgSolInformeRiesgos.Columns["cNomCorto"].HeaderText = "Oficina";
            dtgSolInformeRiesgos.Columns["dFechaRegistro"].HeaderText = "Fecha Solicitud";
            dtgSolInformeRiesgos.Columns["cAnalistaRsg"].HeaderText = "Analista de Riesgo";


            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.Name = "boton";
                buttons.HeaderText = "";
                buttons.Text = "Registrar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 0;
            }
            dtgSolInformeRiesgos.Columns.Add(buttons);

            foreach (DataGridViewColumn item in dtgSolInformeRiesgos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void DarFormatoGridSolicitudInformesTodos()
        {
            foreach (DataGridViewColumn item in dtgSolInformeRiesgosTodos.Columns)
            {
                item.Visible = false;
            }

            dtgSolInformeRiesgosTodos.Columns["idSolInfRiesgo"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["idSolCre"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cNombre"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["nCapitalSolicitado"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cMoneda"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["TipoCredito"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cOperacion"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cNombreAsesor"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cNomCorto"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["dFechaRegistro"].Visible = true;
            dtgSolInformeRiesgosTodos.Columns["cAnalistaRsg"].Visible = true;

            dtgSolInformeRiesgosTodos.Columns["idSolInfRiesgo"].HeaderText = "Solicitud Inf. Riesgo";
            dtgSolInformeRiesgosTodos.Columns["idSolCre"].HeaderText = "Solicitud de Crédito";
            dtgSolInformeRiesgosTodos.Columns["cNombre"].HeaderText = "Cliente";
            dtgSolInformeRiesgosTodos.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolInformeRiesgosTodos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolInformeRiesgosTodos.Columns["TipoCredito"].HeaderText = "Tipo de crédito";
            dtgSolInformeRiesgosTodos.Columns["cOperacion"].HeaderText = "Operación";
            dtgSolInformeRiesgosTodos.Columns["cNombreAsesor"].HeaderText = "Asesor";
            dtgSolInformeRiesgosTodos.Columns["cNomCorto"].HeaderText = "Oficina";
            dtgSolInformeRiesgosTodos.Columns["dFechaRegistro"].HeaderText = "Fecha Solicitud";
            dtgSolInformeRiesgosTodos.Columns["cAnalistaRsg"].HeaderText = "Analista de Riesgo";

            foreach (DataGridViewColumn item in dtgSolInformeRiesgosTodos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        #endregion

        #region Eventos
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            int nfilaseleccionada = Convert.ToInt32(this.dtgSolInformeRiesgos.CurrentRow.Index);
            //dtgCategoriasOficinas.Rows[nFila].Cells["MidHistCatOficina"].Value.ToString()
            nidSolInfRiesgo = Convert.ToInt32(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["idSolInfRiesgo"].Value.ToString());
            nidSolCre = Convert.ToInt32(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["idSolCre"].Value.ToString());
            cMotivoSolInformeRiesgo = dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cMotivo"].Value.ToString();
            cCapitalPropuesto = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["nCapitalPropuesto"].Value);
            cNombreAsesor = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cNombreAsesor"].Value);
            cNomCorto = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cNomCorto"].Value);
            this.Close();
        }

        private void dtgSolInformeRiesgos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtSolInformesRiesgos.Rows.Count > 0)
            {
                //Verificar que se estée haciendo click en el boton "Registrar Informe riesgo"
                if (dtgSolInformeRiesgos.CurrentCell.OwningColumn.Name.Equals("boton"))
                {
                    int nfilaseleccionada = Convert.ToInt32(this.dtgSolInformeRiesgos.CurrentRow.Index);
                    /*nidSolInfRiesgo         = Convert.ToInt32(dtSolInformesRiesgos.Rows[nfilaseleccionada]["idSolInfRiesgo"]);
                    nidSolCre               = Convert.ToInt32(dtSolInformesRiesgos.Rows[nfilaseleccionada]["idSolCre"]);
                    cMotivoSolInformeRiesgo = dtSolInformesRiesgos.Rows[nfilaseleccionada]["cMotivo"].ToString();*/
                    nidSolInfRiesgo = Convert.ToInt32(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["idSolInfRiesgo"].Value.ToString());
                    nidSolCre = Convert.ToInt32(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["idSolCre"].Value.ToString());
                    cMotivoSolInformeRiesgo = dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cMotivo"].Value.ToString();
                    cCapitalPropuesto = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["nCapitalPropuesto"].Value);
                    cNombreAsesor = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cNombreAsesor"].Value);
                    cNomCorto = Convert.ToString(dtgSolInformeRiesgos.Rows[nfilaseleccionada].Cells["cNomCorto"].Value);
                    this.Close();
                }
            }
        }

        private void frmListSolInformeRiesgos_Load(object sender, EventArgs e)
        {
            dtgSolInformeRiesgos.Columns["idSolCre"].Width = 130;
            dtgSolInformeRiesgos.Columns["idSolInfRiesgo"].Width = 130;
            if (dtSolInformesRiesgos.Rows.Count > 0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=1 fila=0 (visible en el dataGridView)
                dtgSolInformeRiesgos.CurrentCell = dtgSolInformeRiesgos[2, 0];
                //Hacer que en la pantalla se muestre seleccionado la primera columna
                dtgSolInformeRiesgos.Rows[0].Selected = true;
            }
        }

        private void btnAsignarse_Click(object sender, EventArgs e)
        {
            if (dtgSolInformeRiesgosTodos.Rows.Count > 0)
            {
                int nfila, idUsuarioSis, idSolInfRiesgoAsignar;
                nfila = Convert.ToInt32(this.dtgSolInformeRiesgosTodos.CurrentRow.Index);
                idSolInfRiesgoAsignar = Convert.ToInt32(dtgSolInformeRiesgosTodos.Rows[nfila].Cells["idSolInfRiesgo"].Value.ToString());
                idUsuarioSis = clsVarGlobal.PerfilUsu.idUsuario;

                DialogResult dialConfirmar = MessageBox.Show("¿Está seguro de asignarse la solicitud de informe Nº " + idSolInfRiesgoAsignar.ToString() + "?", cNombreFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialConfirmar == DialogResult.Yes)
                {
                    DataTable dt = InformeRiesgos.autoAsignarseSolicitudInformeRsg(idSolInfRiesgoAsignar, idUsuarioSis);
                    if (dt.Rows[0]["idMsje"].ToString() == "0")
                    {
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarTodo();

                    }
                    else if (dt.Rows[0]["idMsje"].ToString() == "2")
                    {
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cargarTodo();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cargarTodo();
                    }
                }
                else
                {
                    return;
                }
            }


        }
        #endregion


    }
}
