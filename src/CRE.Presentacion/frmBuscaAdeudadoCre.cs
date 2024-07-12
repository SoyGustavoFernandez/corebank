using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using CRE.Presentacion;
using EntityLayer;
using System.Windows.Forms;


namespace GEN.ControlesBase
{
    public partial class frmBuscaAdeudadoCre : frmBase
    {
        clsCNCredito ListaAdeudado = new clsCNCredito();
        DataTable dtLisAdeudadoCre = new DataTable();
        public string cDescripcion;
        public int IdAdeudado;

        public frmBuscaAdeudadoCre()
        {
            InitializeComponent();              
        }

        public void cargadatos(Int32 idProducto, Int32 idDestinoCre, Decimal nMonto, Int32 idMoneda, Int32 nIdAgencia)
        {                      
            dtLisAdeudadoCre = ListaAdeudado.CNBuscaAdeudado(idProducto, idDestinoCre, nMonto, idMoneda,nIdAgencia);
            this.dtgAdeudadoCre.DataSource = dtLisAdeudadoCre;
            if (dtgAdeudadoCre.Rows.Count>0)
            {
                ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existe Adeudado para estas caracteristicas", "Adeudado de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void insertaDatos()
        {
            Int32 nFilaActual = Convert.ToInt32(this.dtgAdeudadoCre.SelectedCells[0].RowIndex);
            IdAdeudado = Convert.ToInt32(this.dtgAdeudadoCre.Rows[nFilaActual].Cells["idAdeudado"].Value);
            cDescripcion = Convert.ToString(this.dtgAdeudadoCre.Rows[nFilaActual].Cells["cDescripcionLinea"].Value);
            this.Dispose();
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {            
            this.insertaDatos();
        }

        private void frmBuscaAdeudadoCre_Load(object sender, EventArgs e)
        {
            dtgAdeudadoCre.Columns["idAdeudado"].HeaderText = "N° Adeudado";
            dtgAdeudadoCre.Columns["cDescripcionLinea"].HeaderText = "Descripción";
            dtgAdeudadoCre.Columns["cMoneda"].HeaderText = "Moneda";
            dtgAdeudadoCre.Columns["nSaldo"].HeaderText = "Capital";
            dtgAdeudadoCre.Columns["cDescripTipoLinea"].HeaderText = "Tipo Linea";
            dtgAdeudadoCre.Columns["cDescripTipoDeuda"].HeaderText = "Tipo Deuda";
            dtgAdeudadoCre.Columns[0].Width = 85;
            dtgAdeudadoCre.Columns[1].Width = 110;
            dtgAdeudadoCre.Columns[2].Width = 80;
            dtgAdeudadoCre.Columns[3].Width = 70;
            dtgAdeudadoCre.Columns[4].Width = 85;
            dtgAdeudadoCre.Columns[5].Width = 90;

        }

        

       

    }
}
