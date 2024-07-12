using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmDevolverCreditosSinGlosa : frmBase
    {
        
        string xmlCreditos = "";
        clsCNCarteraRecupera cnCarteraRecupera = new clsCNCarteraRecupera();
        DataTable dtCreditos = new DataTable();

        public frmDevolverCreditosSinGlosa()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtCreditos.Rows.Clear();
            dtCreditos = cnCarteraRecupera.obtenerCreditosSinGlosa(Convert.ToString(cboPeriodo1.SelectedValue));
            if (dtCreditos.Rows.Count > 0)
            {

                dtgCreditos.DataSource = dtCreditos;
                dtCreditos.Columns["lSeleCta"].ReadOnly = false;
                dtgCreditos.Columns["lSeleCta"].ReadOnly = false;
                lblTotalCreditos.Text = dtCreditos.Rows.Count + " Crédito(s)";
            }
            dtgCreditos.ReadOnly = false;
            dtgCreditos.Enabled = true;
        }
        private void frmDevolverCreditosSinGlosa_Load(object sender, EventArgs e)
        {
            cboPeriodo1.cargarPeriodoSinTodos();
            cboPeriodo1.Enabled = false;
            cboPeriodo1.SelectedValue = clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year;
            cargar();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            int nSeleccionados = 0;
            nSeleccionados = dtgCreditos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["lSeleCta"].Value));

            DialogResult drResultadoReasignar = MessageBox.Show("Está a punto de devolver " + nSeleccionados + " créditos. ¿Está seguro de continuar realizando esta acción?", "Devolución de créditos sin glosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResultadoReasignar == DialogResult.Yes)
            {
                DataTable dtCred = dtCreditos.AsEnumerable().Where(x => Convert.ToBoolean(x["lSeleCta"])).CopyToDataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dtCred);
                xmlCreditos = ds.GetXml();
                ds.Tables.Clear();
                DataTable dtResultado = cnCarteraRecupera.DevolverCreditosSinGloza(clsVarGlobal.PerfilUsu.idUsuario, xmlCreditos, clsVarGlobal.dFecSystem);
                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se realizo correctamente la devolución", "Devolución de créditos sin glosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }
                else
                {
                    MessageBox.Show("Error al realizar la devolución: " + dtResultado.Rows[0][1], "Devolución de créditos sin glosa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validar()
        {
            int nSeleccionados = 0;
            nSeleccionados = dtgCreditos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["lSeleCta"].Value));

            if (nSeleccionados <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un crédito.", "Devolución de créditos sin glosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;                
            }
            return true;
        }

    }
}
