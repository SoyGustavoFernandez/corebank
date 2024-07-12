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
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using GEN.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmCartasNotifica : frmBase
    {
        #region Variables

        clsCNCartaRecupera cartarecupera = new clsCNCartaRecupera();
        CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();

        #endregion

        public frmCartasNotifica()
        {
            InitializeComponent();
        }

        public frmCartasNotifica(int idCli)
        {
            InitializeComponent();
            conBusCli1.idCli = idCli;
            conBusCli1.CargardatosCli(conBusCli1.idCli);
            conBusCli1.Enabled = false;
            cargarCreditos(conBusCli1.idCli);
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            if (conBusCli1.idCli>0)
            {
                if (dtgCreditos.Rows.Count > 0)
                {
                    cargarCartasGeneradas(Convert.ToInt32(dtgCreditos.Rows[0].Cells["idCuenta"].Value));
                }
            }
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli>0)
            {
                cargarCreditos(conBusCli1.idCli);

                if (dtgCreditos.Rows.Count>0)
                {
                   cargarCartasGeneradas(Convert.ToInt32(dtgCreditos.Rows[0].Cells["idCuenta"].Value));
                }
            }

        }

        private void dtgCreditos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cargarCartasGeneradas(Convert.ToInt32(dtgCreditos.CurrentRow.Cells["idCuenta"].Value));
        }

        #endregion

        #region Metodos

        private void cargarCreditos(int idCuenta)
        {
            var dtCreditos = cncredito.CNdtLisCrexCli(conBusCli1.idCli);
            if (dtCreditos.Rows.Count > 0)
            {
                this.dtgTipoCarta.DataSource = null;
                dtgCreditos.DataSource = dtCreditos;
                formatoGridCreditos();
            }
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }
            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;
            dtgCreditos.Columns["nAtraso"].Visible = true;
            dtgCreditos.Columns["nSalTot"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Des.";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo";

        }

        private void cargarCartasGeneradas(int idCuenta)
        {
            var dtCartasGenradas = cartarecupera.NotificacionesGeneradas(idCuenta);
            dtgTipoCarta.Columns.Clear();
            dtgTipoCarta.DataSource = dtCartasGenradas;
            formatoGridCartas();
        }

        private void formatoGridCartas()
        {
            foreach (DataGridViewColumn columna in dtgTipoCarta.Columns)
            {
                columna.Visible = false;
            }

            dtgTipoCarta.Columns["cTipoNotificacion"].Visible = true;
            dtgTipoCarta.Columns["nGeneradas"].Visible = true;

            dtgTipoCarta.Columns["cTipoNotificacion"].HeaderText = "Tipo notificación";
            dtgTipoCarta.Columns["nGeneradas"].HeaderText = "Notificaciones generadas";

            dtgTipoCarta.Columns["cTipoNotificacion"].Width = 350;
            dtgTipoCarta.Columns["nGeneradas"].Width = 100;
        }

        #endregion
    }
}
