using CAJ.CapaNegocio;
using GEN.CapaNegocio;
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

namespace ADM.Presentacion
{
    public partial class frmDestinoCmpxOficina : frmBase
    {
        #region Variables
        private clsCNAprobacion objAprobacion = new clsCNAprobacion();
        clsCNCajaChica objCajaChica = new clsCNCajaChica();
        DataTable dtAccesoXOficina;
        #endregion

        #region Eventos
        public frmDestinoCmpxOficina()
        {
            InitializeComponent();
        }

        private void cboDestinoCmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDestinoCmp.SelectedIndex <= 0)
            {
                return;
            }
            int idDestino = Convert.ToInt32(cboDestinoCmp.SelectedValue);
            CargaAccesoXAgencia(idDestino);
            chcTodos.Checked = false;
        }

        private void frmDestinoCmpxOficina_Load(object sender, EventArgs e)
        {
            CargarCboDestinos();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                foreach (DataRow NRow in dtAccesoXOficina.Rows)
                {
                    NRow["lDestino"] = true;
                }
            }
            else
            {
                foreach (DataRow NRow in dtAccesoXOficina.Rows)
                {
                    NRow["lDestino"] = false;
                }
            }
            dtgAccesoCmp.Refresh();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dt = dtAccesoXOficina.Copy();
            DataSet ds = new DataSet();
            string xml;

            dt.Columns.Remove("cNombreAge");
            ds.Tables.Add(dt);
            xml = ds.GetXml();

            int idDestino = Convert.ToInt32(cboDestinoCmp.SelectedValue);

            DataTable dtResultado = objAprobacion.ActualizaAccesoDestinoCmp(xml, idDestino);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show("Actualización correcta", "Asignación de Accesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgAccesoCmp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }
            string cValor = dtgAccesoCmp.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(cValor))
            {
                dtAccesoXOficina.Rows[e.RowIndex]["lDestino"] = 0;
            }
            else
            {
                dtAccesoXOficina.Rows[e.RowIndex]["lDestino"] = 1;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            CargaAccesoXAgencia(Convert.ToInt32(cboDestinoCmp.SelectedValue));
        }
        #endregion

        #region Metodos
        private void CargaAccesoXAgencia(int idDestino)
        {
            dtAccesoXOficina = objAprobacion.ConsultaAccesoTipoDestinoCmp(idDestino);
            dtAccesoXOficina.Columns["lDestino"].ReadOnly = false;
            dtgAccesoCmp.DataSource = dtAccesoXOficina;
            dtgAccesoCmp.ReadOnly = false;
            dtgAccesoCmp.Columns["cNombreAge"].ReadOnly = true;
            dtgAccesoCmp.Columns["lDestino"].ReadOnly = false;
        }

        private void CargarCboDestinos()
        {
            DataTable dtDestinoAux = objCajaChica.ListarDestinoComprPago(0);
            DataTable dtDestino = dtDestinoAux.Clone();
            DataRow drTodas = dtDestino.NewRow();

            drTodas["idDetinoComprPago"] = 0;
            drTodas["cDescripcion"] = "";
            drTodas["lAplIgv"] = 0;

            dtDestino.Rows.Add(drTodas);

            (from item in dtDestinoAux.AsEnumerable()
             select item).CopyToDataTable(dtDestino, LoadOption.OverwriteChanges);

            cboDestinoCmp.DataSource = dtDestino;
            cboDestinoCmp.ValueMember = "idDetinoComprPago";
            cboDestinoCmp.DisplayMember = "cDescripcion";
            cboDestinoCmp.SelectedValue = -1;
        }
        #endregion
    }
}
