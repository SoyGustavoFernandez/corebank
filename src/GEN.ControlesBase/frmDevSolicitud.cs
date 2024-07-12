using CRE.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmDevSolicitud : frmBase
    {
        public int IdSolicitud { get; set; }
        public bool lDevolucion { get; set; }
        public bool lLectura { get; set; }

        public frmDevSolicitud()
        {
            InitializeComponent();
        }
        public frmDevSolicitud(int idSolicitud)
        {
            InitializeComponent();
            IdSolicitud = idSolicitud;
        }

        private void frmDevSolicitud_Load(object sender, EventArgs e)
        {
            clsCNCredito objCredito = new clsCNCredito();
            DataTable dtMotivos = new DataTable();
            dtMotivos = objCredito.CNListarMotivosDevolucion();
            DataRow row = dtMotivos.NewRow();
            row["IdMotivoDev"] = 0;
            row["cMotivoDev"] = "**SELECCIONE**";
            dtMotivos.Rows.InsertAt(row, 0);
            cboMotivoDevolucion.DisplayMember = "cMotivoDev";
            cboMotivoDevolucion.ValueMember = "idMotivoDev";
            cboMotivoDevolucion.DataSource = dtMotivos;
            if (lLectura == true)
            {
                btnAceptar1.Enabled = false;
                DataTable dtMotivosDev = objCredito.CNObtenerMotivoDevSol(IdSolicitud);
                if (dtMotivosDev.Rows.Count > 0)
                {
                    DataRow filaMotivo = dtMotivosDev.Rows[0];
                    cboMotivoDevolucion.SelectedValue = Convert.ToString(filaMotivo["IdMotivoDev"]);
                    txtComentario.Text = Convert.ToString(filaMotivo["cComentarioDev"]);
                    cboMotivoDevolucion.Enabled = false;
                    txtComentario.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado registros.", "Devolución", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (cboMotivoDevolucion.SelectedValue.ToString() =="0") {
                MessageBox.Show("Seleccione un motivo de devolución.", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtComentario.Text ==string.Empty)
            {
                MessageBox.Show("Debe ingresar un motivo para la devolución.", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dtDevolucion = new DataTable();
            clsCNCredito objCNCredito = new clsCNCredito();
            dtDevolucion = objCNCredito.CNDevolverSolicitud(IdSolicitud, Convert.ToInt32(cboMotivoDevolucion.SelectedValue), txtComentario.Text, clsVarGlobal.PerfilUsu.idUsuario, DateTime.Now);
            DataRow filaDevolucion = dtDevolucion.Rows[0];
            int idError = Convert.ToInt32(filaDevolucion["idError"]);
            string cMensaje = Convert.ToString(filaDevolucion["cMensaje"]);
            lDevolucion = idError == 0 ? true : false;

            MessageBox.Show(cMensaje, "Devolucion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
