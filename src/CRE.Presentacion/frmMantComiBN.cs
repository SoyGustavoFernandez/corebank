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
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmMantComiBN : frmBase
    {
        clsCNCredito cncredito = new clsCNCredito();

        public frmMantComiBN()
        {
            InitializeComponent();
        }

        private void frmMantComiBN_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            filtrarOpeCre();
            cargarTipoComision();
            //this.cboMoneda1.SelectedIndex = -1;
            //this.cboTipoComision.SelectedIndex = -1;
            //this.cboTipoOperacion1.SelectedIndex = -1;
        }

        private void filtrarOpeCre()
        {
            var dtOperaciones = (DataTable)cboTipoOperacion1.DataSource;
            var dtAux = dtOperaciones.Clone();
            (from item in dtOperaciones.AsEnumerable()
             where ((int)item["idTipoOperacion"]).In(1,2)
             select item).CopyToDataTable(dtAux, LoadOption.OverwriteChanges);
            cboTipoOperacion1.DataSource = dtAux;
        }

        private void cargarTipoComision()
        {
            DataTable dtTipComi = new DataTable();
            dtTipComi.Columns.Add("idTipoComision", typeof(int));
            dtTipComi.Columns.Add("cTipoComision", typeof(string));

            var dr = dtTipComi.NewRow();

            dr["idTipoComision"] = 1;
            dr["cTipoComision"] = "Corresponsalía";
            dtTipComi.Rows.Add(dr);

            dr = dtTipComi.NewRow();
            dr["idTipoComision"] = 2;
            dr["cTipoComision"] = "Oficina Compartida";
            dtTipComi.Rows.Add(dr);

            dtTipComi.AcceptChanges();

            this.cboTipoComision.ValueMember = "idTipoComision";
            this.cboTipoComision.DisplayMember = "cTipoComision";
            this.cboTipoComision.DataSource = dtTipComi;
        }

        private void filtarBusqueda()
        {
            if (this.cboMoneda1.SelectedIndex==-1)
            {
                return;
            }

            if (this.cboTipoComision.SelectedIndex == -1)
            {
                return;
            }

            if (this.cboTipoOperacion1.SelectedIndex == -1)
            {
                return;
            }
            var idMoneda = (int)this.cboMoneda1.SelectedValue;
            var idTipoComision = (int)this.cboTipoComision.SelectedValue;
            var idTipoOperacion = (int)this.cboTipoOperacion1.SelectedValue;
            var dtComision = cncredito.CNBuscarComisionBN(idTipoComision, idTipoOperacion, idMoneda);

            if (dtComision.Rows.Count > 0)
            {
                txtComMin.Text = dtComision.Rows[0]["nComisionMin"].ToString();
                txtDescripción.Text = dtComision.Rows[0]["cComisionBN"].ToString();
                txtPorComi.Text = dtComision.Rows[0]["nPorcomision"].ToString();
                var lEstado = (bool)dtComision.Rows[0]["lVigente"];
                rbtActivo.Checked = lEstado;
                rbtnInactivo.Checked = !lEstado;
            }

        }


        private void cboTipoComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtarBusqueda();
        }

        private void cboTipoOperacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtarBusqueda();
        }

        private void cboMoneda1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtarBusqueda();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var idMoneda = (int)this.cboMoneda1.SelectedValue;
            var idTipoComision = (int)this.cboTipoComision.SelectedValue;
            var idTipoOperacion = (int)this.cboTipoOperacion1.SelectedValue;
            var nComisionMin = txtComMin.nvalor;
            var nPorcomision = txtPorComi.nvalor;
            var cComisionBN = txtDescripción.Text;
            var lVigente = rbtActivo.Checked;

            cncredito.CNGuardarComisionBN(idTipoComision, idTipoOperacion, idMoneda, cComisionBN, nComisionMin, nPorcomision, lVigente);
            MessageBox.Show("Los datos se guardaron correctamente", "Comisión BN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filtarBusqueda();
            habilitarEdicion(false);
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            filtarBusqueda();
            habilitarEdicion(false);
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion(true);
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void habilitarEdicion(bool lestado)
        {
            txtPorComi.Enabled = lestado;
            txtComMin.Enabled = lestado;
            rbtActivo.Enabled = lestado;
            rbtnInactivo.Enabled = lestado;
            this.cboMoneda1.Enabled = !lestado;
            this.cboTipoComision.Enabled = !lestado;
            this.cboTipoOperacion1.Enabled = !lestado;
        }

        private bool validar()
        {
            bool lEstado = false;
            if (txtDescripción.Text=="")
            {
                MessageBox.Show("Ingrese la descripción de la comisión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lEstado;
            }

            if (txtDescripción.Text == "")
            {
                MessageBox.Show("Ingrese la descripción de la comisión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lEstado;
            }

            lEstado = true;
            return lEstado;
        }
    }
}
