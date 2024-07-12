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
using GEN.CapaNegocio;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class frmVisitaRealizadaSinVinculacion : frmBase
    {
        List<clsVisita> lista;
        clsCNVisitas objVisita;
        BindingSource bs;
        public clsVisita objSel; 
        int idSolicitud = 0;
        int idCli = 0;
        int idGrupoSolidario = 0;
        int idSolicitudGrupoSol = 0;
        bool lIndividual = true;
        private bool lLectura = false;

        public frmVisitaRealizadaSinVinculacion(int _idGrupoSolidario, int _idSolicitudGrupoSol, bool _lInd, bool _lLectura)
        {
            InitializeComponent();
            this.objVisita = new clsCNVisitas();
            this.idGrupoSolidario = _idGrupoSolidario;
            this.idSolicitudGrupoSol = _idSolicitudGrupoSol;
            this.lIndividual = _lInd;
            this.lLectura = _lLectura;
            this.bs = new BindingSource();
        }

        public frmVisitaRealizadaSinVinculacion(int _idCli, int _idSolicitud, bool _lLectura)
        {
            InitializeComponent();
            this.objVisita = new clsCNVisitas();
            this.idCli = _idCli;
            this.idSolicitud = _idSolicitud;
            this.lIndividual = true;
            this.lLectura = _lLectura;
            this.bs = new BindingSource();
        }

        private void frmVisitaRealizadaSinVinculacion_Load(object sender, EventArgs e)
        {
            if (this.lIndividual)
            {
                DataTable dtRes; 
                if (!lLectura)
                { 
                    dtRes = this.objVisita.CNWSListarVisita(clsVarGlobal.User.idUsuario, this.idCli, idSolicitud, EstadoVisita.VISITADO);
                }
                else
                {
                    dtRes = this.objVisita.CNListarVisitasVinculadasIndividual(idSolicitud);
                }

                this.lista = dtRes.ToList<clsVisita>().ToList();
                this.bs.DataSource = lista;
                this.dtgVisitas.DataSource = bs;
                this.formatoGrid();
            }
            else
            {
                DataTable dtRes;
                if (!lLectura)
                {
                    dtRes = this.objVisita.CNListarVisitaUsuarioGrupoSolidario(clsVarGlobal.User.idUsuario, this.idGrupoSolidario, idSolicitudGrupoSol, EstadoVisita.VISITADO);
                }
                else
                {
                    dtRes = this.objVisita.CNListarVisitasVinculadasGrupoSol(idSolicitudGrupoSol);
                }
                this.lista = dtRes.ToList<clsVisita>().ToList();
                this.bs.DataSource = lista;
                this.dtgVisitas.DataSource = bs;
                this.formatoGrid();
            }

            ControlesEditar();
        }

        #region Public
        #endregion

        #region Private

        private void formatoGrid()
        {
            dtgVisitas.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgVisitas.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
            }

            dtgVisitas.Columns["idVisita"].Visible = true;
            dtgVisitas.Columns["cPerfil"].Visible = true;
            dtgVisitas.Columns["cWinUser"].Visible = true;
            dtgVisitas.Columns["dFechaVisita"].Visible = true;
            dtgVisitas.Columns["idCliente"].Visible = true;
            dtgVisitas.Columns["cNombre"].Visible = true;
            dtgVisitas.Columns["cDireccion"].Visible = true;
            
            dtgVisitas.Columns["lVinc"].Visible = true;

            dtgVisitas.Columns["idVisita"].HeaderText = "Visita";
            dtgVisitas.Columns["cPerfil"].HeaderText = "Perfil";
            dtgVisitas.Columns["cWinUser"].HeaderText = "Usuario";
            dtgVisitas.Columns["dFechaVisita"].HeaderText = "Fecha";
            dtgVisitas.Columns["idCliente"].HeaderText = "Cod Cli";
            dtgVisitas.Columns["cNombre"].HeaderText = "Nombres";
            dtgVisitas.Columns["cDireccion"].HeaderText = "Dirección";
            dtgVisitas.Columns["lVinc"].HeaderText = "Vinculado";

            dtgVisitas.Columns["idVisita"].DisplayIndex = 1;
            dtgVisitas.Columns["cPerfil"].DisplayIndex = 2;
            dtgVisitas.Columns["cWinUser"].DisplayIndex = 3;
            dtgVisitas.Columns["dFechaVisita"].DisplayIndex = 4;
            dtgVisitas.Columns["idCliente"].DisplayIndex = 5;
            dtgVisitas.Columns["cNombre"].DisplayIndex = 6;
            dtgVisitas.Columns["cDireccion"].DisplayIndex = 7;
            dtgVisitas.Columns["lVinc"].DisplayIndex = 0;

            dtgVisitas.Columns["idVisita"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["cPerfil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["cWinUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["dFechaVisita"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["idCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["cDireccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["lVinc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgVisitas.Columns["lVinc"].ReadOnly = false;
        }
        #endregion

        private void btnDetalle2_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            clsVisita obj = new clsVisita();
            obj = (clsVisita)dtgVisitas.SelectedRows[0].DataBoundItem;
            frmVisita frmVisita = new frmVisita(obj.idVisita, 0);
            frmVisita.ShowDialog();
        }

        private void btn_Vincular1_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            string cSeleccion = "";
            foreach (clsVisita item in lista)
            {
                if (item.lVinc)
                {
                    cSeleccion += "" + item.idVisita + ","; 
                }
            }

            if (lIndividual)
            {
                DialogResult result = MessageBox.Show("Se está intentando vincular la visita " + cSeleccion + " la Solicitud Nro " + idSolicitud, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    //MessageBox.Show(idVisita.ToString() + " ->" + idSolicitud);
                    DataTable res = objVisita.CNVincularVisitaSolicitud(idSolicitud, cSeleccion);

                    if (Convert.ToInt32(res.Rows[0]["nResultado"]) == 1)
                    {
                        MessageBox.Show(res.Rows[0]["cMensaje"].ToString(), "Vincular Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Rows[0]["cMensaje"].ToString(), "Vincular Visita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Se está intentando vincular la visita " + cSeleccion + " la Solicitud de grupo solidario Nro " + idSolicitudGrupoSol, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    DataTable res = objVisita.CNVincularVisitaSolicitudGrupoSolidario(idSolicitudGrupoSol, cSeleccion);

                    if (Convert.ToInt32(res.Rows[0]["nResultado"]) == 1)
                    {
                        MessageBox.Show(res.Rows[0]["cMensaje"].ToString(), "Vincular Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show(res.Rows[0]["cMensaje"].ToString(), "Vincular Visita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            
        }

        private void ControlesEditar()
        {
            if (this.lLectura)
            {
                btn_Vincular1.Visible = false;
                dtgVisitas.Columns["lVinc"].ReadOnly = true;
            }
            else 
            {
                btn_Vincular1.Visible = true;
                dtgVisitas.Columns["lVinc"].ReadOnly = false;
            }
        }
    }
}
