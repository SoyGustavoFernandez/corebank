#region Directivas
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
#endregion
namespace DEP.Presentacion
{
    public partial class frmManOpeModPago : frmBase
    {
        #region Variables
        clsCNOperacionDep cnOpeDep = new clsCNOperacionDep();
        //Lista principal de Datos
        clsListaModPagoOperacion lstDatoModOpe = new clsListaModPagoOperacion();
        //Lista Repaldo de Datos
        clsListaModPagoOperacion lstCopiaDatoModOpe = new clsListaModPagoOperacion();
        #endregion
        #region Eventos
        public frmManOpeModPago()
        {
            InitializeComponent();
        }

        private void frmMantOperacionTipoPago_Load(object sender, EventArgs e)
        {
            lstDatoModOpe = cnOpeDep.ListaModPagoOperacion();
            dtgManOpeModPago.DataSource = lstDatoModOpe;
            habilitarBotones(false);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            FormatoGrids(false);
            habilitarBotones(true);

            //copia la lista a un respaldo
            lstCopiaDatoModOpe.Clear();
            foreach (var item in lstDatoModOpe)
            {
                lstCopiaDatoModOpe.Add(new clsModPagoOperacion()
                {
                    cDesTipoPago = item.cDesTipoPago,
                    idTipoPago = item.idTipoPago,
                    lOpeApertura = item.lOpeApertura,
                    lOpeCancelacion = item.lOpeCancelacion,
                    lOpeDeposito = item.lOpeDeposito,
                    lOpePagoComPago = item.lOpePagoComPago,
                    lOpeRetiro = item.lOpeRetiro,
                    lPagoCredito = item.lPagoCredito
                });
            }
        }
       
        private void btnGrabar1_Click(object sender, EventArgs e)
        {            
            DataTable dtRes=cnOpeDep.GrabarModPagoOperacion(lstDatoModOpe.obtenerXml());
            string cResultado = dtRes.Rows[0]["mResp"].ToString();
            if (Convert.ToInt32(dtRes.Rows[0]["nResp"].ToString()) == 1)
            {
                MessageBox.Show(cResultado, "Editar Modalidad Pago Por Operación", MessageBoxButtons.OK,MessageBoxIcon.Information);
                FormatoGrids(true);
                habilitarBotones(false);
            }
            else
            {
                MessageBox.Show(cResultado, "Editar Modalidad Pago Por Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            FormatoGrids(true);
            habilitarBotones(false);
            
            //Retorna al estado anterior
            dtgManOpeModPago.DataSource = null;
            lstDatoModOpe.Clear();
            foreach (var item in lstCopiaDatoModOpe)
            {
               lstDatoModOpe.Add(new clsModPagoOperacion()
                {
                    cDesTipoPago = item.cDesTipoPago,
                    idTipoPago = item.idTipoPago,
                    lOpeApertura = item.lOpeApertura,
                    lOpeCancelacion = item.lOpeCancelacion,
                    lOpeDeposito = item.lOpeDeposito,
                    lOpePagoComPago = item.lOpePagoComPago,
                    lOpeRetiro = item.lOpeRetiro,
                    lPagoCredito = item.lPagoCredito
                });
            }            
            dtgManOpeModPago.DataSource = lstDatoModOpe;
            dtgManOpeModPago.Refresh();

            //Limpia copia de Lista
            lstCopiaDatoModOpe.Clear();
        }
#endregion
        #region Metodo
        private void FormatoGrids(bool lValor)
        {
            dtgManOpeModPago.ReadOnly = lValor;

            foreach (DataGridViewColumn item in dtgManOpeModPago.Columns)
            {
                item.ReadOnly = lValor;
                if (item.HeaderText == "Modalidad de Pago")
                {
                    item.ReadOnly = !lValor;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void habilitarBotones(bool lValor)
        {
            btnGrabar1.Enabled = lValor;
            btnEditar1.Enabled = !lValor;
            btnCancelar1.Enabled = lValor;
        }
        #endregion
    }
}