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

namespace GEN.ControlesBase
{
    public partial class frmBuscarAdeudado : frmBase
    {
        clsCNControlOpe Adeudo = new clsCNControlOpe();
        public DataTable dtExternoAdeudado;
        private DataTable dtInternoAdeudo;
        string idEntidad;
        string idMoneda;
        string idEstado;
        string cDescripcionLinea;

        public frmBuscarAdeudado()
        {
            InitializeComponent();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            try
            {
                idEntidad = cboEntidad.SelectedValue.ToString();
            }
            catch (Exception)
            {

                idEntidad = "%";
            }
            try
            {
                idMoneda = cboMoneda.SelectedValue.ToString();
            }
            catch (Exception)
            {

                idMoneda = "%";
            }
            try
            {
                idEstado = cboEstado.SelectedValue.ToString();
            }
            catch (Exception)
            {
                idEstado = "%";
            }

            cDescripcionLinea = txtDesccripcionLinea.Text;
            llenarGridAdeudado();
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked)
            {

                cboTipoEntidad.SelectedValue = -1;
                cboEntidad.SelectedValue = -1;
                cboMoneda.SelectedValue = -1;
                cboEstado.SelectedValue = -1;

                txtDesccripcionLinea.Clear();


                idEntidad = "%";
                idMoneda = "%";
                idEstado = "%";
                cDescripcionLinea = "%";

                cboTipoEntidad.Enabled = false;
                cboEntidad.Enabled = false;
                cboMoneda.Enabled = false;
                cboEstado.Enabled = false;
                txtDesccripcionLinea.Enabled = false;
                txtDesccripcionLinea.Clear();


                //llenarGridAdeudado();
            }
            else
            {
                dtgListaAdeudados.DataSource = null;
                cboTipoEntidad.Enabled = true;
                cboEntidad.Enabled = true;
                cboMoneda.Enabled = true;
                cboEstado.Enabled = true;
                txtDesccripcionLinea.Enabled = true;
            }


        }

        void llenarGridAdeudado()
        {
            dtInternoAdeudo = Adeudo.CNConsultaAdeudado(-1, idEntidad, idMoneda, idEstado, cDescripcionLinea);
            dtgListaAdeudados.DataSource = dtInternoAdeudo;


            dtgListaAdeudados.Columns["idEntidad"].Visible = false;
            dtgListaAdeudados.Columns["idTipoOperacion"].Visible = false;
            dtgListaAdeudados.Columns["idTipoLinea"].Visible = false;
            dtgListaAdeudados.Columns["idTipoDeuda"].Visible = false;
            dtgListaAdeudados.Columns["idMoneda"].Visible = false;
            dtgListaAdeudados.Columns["idEstado"].Visible = false;
            dtgListaAdeudados.Columns["idTipoEntidad"].Visible = false;


            dtgListaAdeudados.Columns["idAdeudado"].HeaderText = "Adeudado";
            //dtgListaAdeudados.Columns["cNroPagre"].HeaderText = "Nro de Pagare";
            dtgListaAdeudados.Columns["cNombreCorto"].HeaderText = "Entidad Financiera";
            dtgListaAdeudados.Columns["cDescripcionLinea"].HeaderText = "Descripción";
            dtgListaAdeudados.Columns["dFechaContrato"].HeaderText = "Fecha de Contrato";
            dtgListaAdeudados.Columns["cMoneda"].HeaderText = "Moneda";
            dtgListaAdeudados.Columns["dFechaCancelacion"].HeaderText = "Fecha de Cancelación";
            dtgListaAdeudados.Columns["nMonFinanciado"].HeaderText = "Monto Financiado";

            dtgListaAdeudados.Columns["idAdeudado"].Width = 60;
            //dtgListaAdeudados.Columns["cNroPagre"].Width = 95;
            dtgListaAdeudados.Columns["cNombreCorto"].Width = 125;
            dtgListaAdeudados.Columns["cDescripcionLinea"].Width = 140;
            dtgListaAdeudados.Columns["dFechaContrato"].Width = 75;
            dtgListaAdeudados.Columns["cMoneda"].Width = 74;
            dtgListaAdeudados.Columns["dFechaCancelacion"].Width = 73;
            dtgListaAdeudados.Columns["nMonFinanciado"].Width = 105;

        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(cboTipoEntidad.SelectedValue), "1");
        }

        private void frmBuscarAdeudado_Load(object sender, EventArgs e)
        {
            //cargando estado de adeudados
            DataTable dtListarEstadiAdeudo = Adeudo.listarEstadoAdeudado();
            cboEstado.DataSource = dtListarEstadiAdeudo;
            cboEstado.ValueMember = "idEstado";
            cboEstado.DisplayMember = "cDescripcion";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string idAdeudado;
            if (dtgListaAdeudados.RowCount > 0)
            {
                idAdeudado = dtgListaAdeudados.CurrentRow.Cells["idAdeudado"].Value.ToString();
                DataTable dt2 = dtInternoAdeudo.Select("idAdeudado=" + idAdeudado).CopyToDataTable();
                dtExternoAdeudado = dt2;
            }
            this.Dispose();
        }

    }
}
