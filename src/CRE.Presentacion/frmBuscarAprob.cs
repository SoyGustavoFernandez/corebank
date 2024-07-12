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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;



namespace CRE.Presentacion
{
    public partial class frmBuscarAprob : frmBase
    {
        #region Variables Globales
       
        clsCNBuscarCli listarCli = new clsCNBuscarCli();
        clsCNBuscaPersonal listarPerfiles = new clsCNBuscaPersonal();
        private const string cTituloMsjes = "Autorización de Desembolso";
        public string cNivAprob, cPerfil, cNombre, cNivelAprobacion, cidUsuarioAprobador;
        public int idUsuario;
        public int idPerfil;
        
        #endregion
        #region Eventos
        public frmBuscarAprob()
        {
            InitializeComponent();
            this.btnAceptar1.Enabled = false;


        }
        private void conBusCli1_KeyPress(object sender, KeyPressEventArgs e)
        {
            RellenarDatos();
        }

        private void conBusCli1_Click(object sender, EventArgs e)
        {
            RellenarDatos();
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgClientes.RowCount >= 1)
            {
                if (MessageBox.Show("¿Esta seguro de utilizar este perfil, para Aprobar/Denegar esta solicitud de crédito?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idNivAprobIdentificador = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idNivelAprobacion"].Value.ToString());
                    if (idNivAprobIdentificador == 1)
                    {
                        MessageBox.Show("Este perfil no tiene autorizacion para aprobar créditos", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cNivAprob = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNivelAprobacion"].Value.ToString();
                        cPerfil = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cPerfil"].Value.ToString();
                        cNombre = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                        cNivelAprobacion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idNivelAprobacion"].Value.ToString();
                        cidUsuarioAprobador = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idUsuario"].Value.ToString();
                        this.idUsuario = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idUsuario"].Value);
                        this.idPerfil = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idPerfil"].Value);
                        this.Dispose();
                    }
                }
            }
            //this.Dispose();
        }

        private void conBusCol1_Click(object sender, EventArgs e)
        {
            RellenarDatos();
        }

        private void conBusCol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            RellenarDatos();
        }

        #endregion
        #region Metodos
        public void RellenarDatos()
        {
            string cCodigo = Convert.ToString(conBusCol1.txtCod.Text.Trim());
            string cSeleccionBd = "2";

            DataTable dtPerfiles = new DataTable();
            dtPerfiles = listarPerfiles.ListarUsuariosAprob(cSeleccionBd, cCodigo);

            if (dtPerfiles.Rows.Count == 0)
            {
                MessageBox.Show("No tiene asignado algún perfil de aprobación de créditos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.btnAceptar1.Enabled = false;
                dtgClientes.DataSource = null;
                dtgClientes.Enabled = false;
            }
            else
            {
                dtgClientes.Enabled = true;
                dtgClientes.DataSource = dtPerfiles;
                formatoGridClientes();
                this.btnAceptar1.Enabled = true;
            }
        }

        private void formatoGridClientes()
        {
            foreach (DataGridViewColumn column in this.dtgClientes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgClientes.Columns["cNivelAprobacion"].Visible = true;
            dtgClientes.Columns["cPerfil"].Visible = true;

            dtgClientes.Columns["cNivelAprobacion"].HeaderText = "Nivel de Aprobacion";
            dtgClientes.Columns["cPerfil"].HeaderText = "Perfil";

            dtgClientes.Columns["cNivelAprobacion"].Width = 50;
            dtgClientes.Columns["cPerfil"].Width = 50;

        }

        #endregion
    }
}
