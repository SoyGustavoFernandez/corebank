using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCargoCartasSolCaptura : frmBase
    {
        clsCNCredito Credito = new clsCNCredito();

        private DataTable dtCreditos;
        private DataTable dtDocsSustenCaptura;
        
        public frmCargoCartasSolCaptura()
        {
            InitializeComponent();
        }

        public frmCargoCartasSolCaptura(DataTable DtCreditos, String nIdCliente, String nNumDoc, String cNombreCli)
        {
            InitializeComponent();
            
            txtCodCliente.Text=nIdCliente.ToString();
            txtNumDoc.Text=nNumDoc.ToString();
            txtNombreCli.Text = cNombreCli.ToString();
            
            this.dtCreditos = DtCreditos;
            //Recuperar la lista de los documentos sustentatorios para la captura de credito 
            dtDocsSustenCaptura = Credito.ListaDocsSustentatoriosCapturaCredito();
            DarFormatoGridDocumentosSustentatorios();

            //Recuperar las cuentas aprobadas para captura a judiciales
            dtgCreditosAprobados.DataSource = dtCreditos;
            DarFormatoGridCreditosAprobados();
        }
        private void ArmarTablaOpciones()
        {
            //Añadir columnas
            for (int j = 0; j < dtDocsSustenCaptura.Rows.Count; j++)
            {
                dtCreditos.Columns.Add(dtDocsSustenCaptura.Rows[j]["cNombreDoc"].ToString(), typeof(bool));
            }

            //Inicializar todos los campos a false
            for (int i = 0; i < dtCreditos.Columns.Count; i++)
            {
                if (dtCreditos.Columns[i].ColumnName.Equals("cNroCuenta")==false)
	            {
                    for (int j = 0; j < dtCreditos.Rows.Count; j++)
                    {
                        dtCreditos.Rows[j][i] = false;
                    }
	            }
			}         
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se ha implementado aún esta opción", "Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DarFormatoGridDocumentosSustentatorios()
        {
            //Añadir columna lAplica
            dtDocsSustenCaptura.Columns.Add("lAplica", typeof(bool));
            for (int i = 0; i < dtDocsSustenCaptura.Rows.Count; i++)
            {
                dtDocsSustenCaptura.Rows[i]["lAplica"] = false;
            }

            dtgDocsSustentatorios.ReadOnly = false;
            dtgDocsSustentatorios.DataSource = dtDocsSustenCaptura;
            dtgDocsSustentatorios.Columns["lAplica"].HeaderText = "Aplica";
            dtgDocsSustentatorios.Columns["nIdDocSustenCaptura"].Visible = false;
            dtgDocsSustentatorios.Columns["cNombreDoc"].HeaderText = "Documento";
        }

        private void DarFormatoGridCreditosAprobados()
        {
            //Asignar permisos de Edición
            dtgCreditosAprobados.ReadOnly = false;
            for (int i = 0; i < dtgCreditosAprobados.ColumnCount; i++)
            {
                dtgCreditosAprobados.Columns["cNroCuenta"].ReadOnly = true;
            }

            dtgCreditosAprobados.Columns["idSolAproba"].Visible = false;
            dtgCreditosAprobados.Columns["idCuenta"].Visible = false;
            dtgCreditosAprobados.Columns["cMoneda"].Visible = false;
            dtgCreditosAprobados.Columns["cProducto"].Visible = false;
            dtgCreditosAprobados.Columns["cNroCuenta"].HeaderText = "Número de cuenta";
        }

        private void frmCargoCartasSolCaptura_Load(object sender, EventArgs e)
        {
            //DOCUMENTOS SUSTENTATORIOS
            dtgDocsSustentatorios.Columns["cNombreDoc"].Width = 100;
            //Dar permisos de edición
            for (int i = 0; i < dtgDocsSustentatorios.Columns.Count; i++)
            {
                if (dtgDocsSustentatorios.Columns[i].Name.Equals("lAplica")==false)
                {
                    dtgDocsSustentatorios.Columns[i].ReadOnly = true;
                }
            }

            //CUENTAS APROBADAS PARA CAPTURA DE CRÉDITO
            dtgCreditosAprobados.Columns["cNroCuenta"].Width = 150;
        }
    }
}
