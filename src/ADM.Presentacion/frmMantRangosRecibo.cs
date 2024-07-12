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
using CAJ.CapaNegocio;
using EntityLayer;
using ADM.CapaNegocio;
using DEP.CapaNegocio.AhorroWeb;

namespace ADM.Presentacion
{
    public partial class frmMantRangosRecibo : frmBase
    {
        #region Variables Globales
        Transaccion transaccion = Transaccion.Nuevo;
        clsCNControlOpe controlOpe = new clsCNControlOpe();
        DataTable tbConcep;
        string nPerfilMantRango = "";
        int nPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        clsCNAWGeneral objGeneral = new clsCNAWGeneral();
        #endregion

        public frmMantRangosRecibo()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerPerfilUsuario();
            CargarTiporecibos();
            CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));
        }

        
        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipRec.SelectedIndex >= 0)
            {
                if (cboTipRec.SelectedValue is DataRowView)
                {
                    return;
                }

                    CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));

            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (transaccion == Transaccion.Nuevo)
                {
                    controlOpe.InsertarDetalleConRec(Convert.ToInt32(cboConcepto1.SelectedValue),
                                                     Convert.ToInt32(cboAgencias1.SelectedValue),
                                                     txtValMin.nDecValor, txtValMax.nDecValor, clsVarGlobal.User.idUsuario);
                }
                if (transaccion == Transaccion.Edita)
                {
                    controlOpe.ActualizarDetalleConRec(Convert.ToInt32(cboConcepto1.SelectedValue),
                                                     Convert.ToInt32(cboAgencias1.SelectedValue),
                                                     txtValMin.nDecValor, txtValMax.nDecValor, clsVarGlobal.User.idUsuario);
                }


                MessageBox.Show("Los datos se guardaron satisfactoriamente", "Registro de Rango x Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarRangos();
                habilitarControles(false);
            }
        }
        
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
        }

        private void cboConcepto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcepto1.SelectedIndex >= 0)
            {
                if (cboConcepto1.SelectedValue is DataRowView)
                {
                    return;
                }
                cargarRangos();
            }
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias1.SelectedIndex >= 0)
            {
                if (cboAgencias1.SelectedValue is DataRowView)
                {
                    return;
                }
                cargarRangos();
            }
        }

        #endregion

        #region

        private void cargarRangos()
        {
            var dtRangos = controlOpe.ListarDetalleConRecidConcepto(Convert.ToInt32(cboConcepto1.SelectedValue), Convert.ToInt32(cboAgencias1.SelectedValue));
            if (dtRangos.Rows.Count > 0)
            {
                transaccion = Transaccion.Edita;
                txtValMin.Text = dtRangos.Rows[0]["nMontoMin"].ToString();
                txtValMax.Text = dtRangos.Rows[0]["nMontoMax"].ToString();
            }
            else
            {
                transaccion = Transaccion.Nuevo;
                txtValMin.Text = "0.00";
                txtValMax.Text = "0.00";
            }
        }

        private bool validar()
        {
            bool lVal = false;

            if (txtValMax.nDecValor <= txtValMin.nDecValor)
            {
                MessageBox.Show("El valor máximo no debe de se menor igual que el valor mínimo", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMax.Focus();
                return lVal;
            }

            if (txtValMin.nDecValor < 0M)
            {
                MessageBox.Show("El valor mínimo debe ser mayor igual a cero(0) ", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMin.Focus();
                return lVal;
            }

            if (txtValMax.nDecValor < 0M)
            {
                MessageBox.Show("El valor máximo debe ser mayor igual a cero(0) ", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMax.Focus();
                return lVal;
            }

            if (cboAgencias1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de seleccionar una agencia", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (cboConcepto1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de seleccionar un concepto", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void habilitarControles(bool lVal)
        {
            cboAgencias1.Enabled = !lVal;
            cboTipRec.Enabled = !lVal;
            cboConcepto1.Enabled = !lVal;
            btnCancelar1.Enabled = lVal;
            btnGrabar1.Enabled = lVal;
            btnEditar1.Enabled = !lVal;
            txtValMax.Enabled = lVal;
            txtValMin.Enabled = lVal;
        }

        private void CargarTiporecibos()
        {

            DataTable tbTipRec;
            //PERTENECE GRUPO EJECUTIVO
            if (nPerfilMantRango == "GrupoEjecutivo")
            {
                clsAWVariable objVar = objGeneral.obtenerVariable("cTipoReciboGrupoEjecutivoRango");
                string cIdTipoRecibo = objVar.cValVar;
                tbTipRec = controlOpe.LisTipRecRango(cIdTipoRecibo); 
            }
            else
            {
                tbTipRec = controlOpe.ListarTipRec();
            }

            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void CargarConceptos(int nTipRec)
        {
            //PERTENECE GRUPO EJECUTIVO
            if (nPerfilMantRango == "GrupoEjecutivo")
            {
                clsAWVariable objVar = objGeneral.obtenerVariable("cConceptosGrupoEjecutivo");
                string cIdConceptosRecibo = objVar.cValVar;
                tbConcep = controlOpe.LisConcepEjCorp(nTipRec, "", cIdConceptosRecibo);
                cboConcepto1.DataSource = tbConcep;
            }
            else
            {
                tbConcep = controlOpe.ListaConceptos(nTipRec, "");
                cboConcepto1.DataSource = tbConcep;
            }
         
            cboConcepto1.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto1.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            if (tbConcep.Rows.Count > 1)
            {
                cboConcepto1.SelectedIndex = 1;
            }
            else
            {
                cboConcepto1.SelectedIndex = -1;
            }
        }

        private List<EPerfil> obtenerListaPerfil()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            DataTable dtPerfil = new DataTable();

            clsCNMantenimiento obtenerPerfil = new clsCNMantenimiento();

            dtPerfil = obtenerPerfil.CNObtenerPerfilReporteExtorno("cGrupoEjecutivoMantConceptoRecibo");

            Char[] cSeparadorGrupoPerfil = { ';' };
            Char[] cSeparadorPerfil = { ':' };

            String[] cGrupoPerfil = Convert.ToString(dtPerfil.Rows[0]["cValVar"]).Split(cSeparadorGrupoPerfil);

            for (int i = 0; i < cGrupoPerfil.Length; i++)
            {
                String[] cPerfil = Convert.ToString(cGrupoPerfil[i]).Split(cSeparadorPerfil);
                EPerfil ePerfil = new EPerfil();
                ePerfil.idPerfil = Convert.ToString(cPerfil[1]);
                ePerfil.desRol = Convert.ToString(cPerfil[0]);
                listaPefil.Add(ePerfil);

            }

            return listaPefil;
        }
        private void obtenerPerfilUsuario()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            Char[] cSeparadorIdPerfil = { ',' };
            listaPefil = obtenerListaPerfil();
            foreach (EPerfil item in listaPefil)
            {
                String[] nIdPerfil = Convert.ToString(item.idPerfil).Split(cSeparadorIdPerfil);

                foreach (string idPerfil in nIdPerfil)
                {
                    if (idPerfil == Convert.ToString(nPerfil))
                    {
                        nPerfilMantRango = item.desRol;
                    }
                }
            }
        }

        #endregion

        
    }
}
