using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.Text.RegularExpressions;

namespace GEN.ControlesBase
{
    public partial class frmBuscarEmailAhorros : frmBase
    {

        #region Variables Globales
        DataTable dtIntervinientes;
        DataTable dtIntervinientesRefres;

        clsCNDeposito clsDeposito = new clsCNDeposito();
        string cTitulo = "Buscar Correo Electrónico de Ahorros";
        string cNombre = "";
        string cCorreo = "";
        string cCorreoAdic = "";
        int idCli = 0;
        string cCorreoAsignado = "";

        #endregion

        #region Eventos
        
        public frmBuscarEmailAhorros()
        {
            InitializeComponent();
        }

        public frmBuscarEmailAhorros(DataTable dtInterv)
        {
            InitializeComponent();
            HabilitarCampos(false);
            this.btnGrabar1.Enabled = false;
            this.btnEditar1.Enabled = false;
            this.btnAceptar1.Enabled = true;
            dtIntervinientes = dtInterv;
            dtIntervinientesRefres = dtInterv;
            consultarDatosClientes(dtIntervinientes,1);

        }

        private void dtgBase1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cNombre = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
            cCorreo = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cCorreoCli"].Value.ToString();
            cCorreoAdic = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cCorreoCliAdicional"].Value.ToString();

            idCli = Convert.ToInt32(dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString());

            this.txtBase2.Text = cNombre;
            this.txtBase1.Text = cCorreo;
            this.txtBase3.Text = cCorreoAdic;
            this.btnEditar1.Enabled = true;

        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            this.btnGrabar1.Enabled = true;
            this.btnAceptar1.Enabled = false;
        }


        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            
            HabilitarCampos(false);
            this.btnGrabar1.Enabled = false;
            this.btnAceptar1.Enabled = true;
            this.btnEditar1.Enabled = false;

            int idCliente = idCli;
            string cCorreoActualizar = this.txtBase1.Text.ToString();
            string cCorreoAdicActualizar = this.txtBase3.Text.ToString();

            DataTable dtCorreosPorCliente = clsDeposito.CNActualizaCorreo(idCliente, cCorreoActualizar, cCorreoAdicActualizar, clsVarGlobal.User.idUsuario);

            int nIdMsj = Convert.ToInt32(dtCorreosPorCliente.Rows[0]["nIdMsj"].ToString());
            string cMsj = Convert.ToString(dtCorreosPorCliente.Rows[0]["cMsj"].ToString());
            if (nIdMsj == 1)
            {
                MessageBox.Show(cMsj, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(cMsj, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            dtgCorreosCliente.DataSource = null;
            consultarDatosClientes(dtIntervinientesRefres,2);
            
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            HabilitarCampos(false);
            this.btnGrabar1.Enabled = false;

            string idCli = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();
            string cNombreAsignado = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
            string cCorreoAsig = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cCorreoCli"].Value.ToString();
            string cCorreoAsigSec = dtgCorreosCliente.Rows[dtgCorreosCliente.SelectedCells[0].RowIndex].Cells["cCorreoCliAdicional"].Value.ToString();

            
            if (String.IsNullOrEmpty(cCorreoAsig))
            {
                MessageBox.Show("No puede asignar un cliente que no tenga correo electrónico principal.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("¿Se encuentra seguro que el Titular asignado para recibir el estado de cuenta es :\n"+cNombreAsignado+
                "\n con el correo electrónico : \n" + cCorreoAsig + "\n, es el indicado por el Cliente?", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cCorreoAsignado = cCorreoAsig;
                cCorreoAsignadoPrincipal();
                
                DataTable dtActualizar = clsDeposito.CNActualizaCorreoMtoClientes(Convert.ToInt32(idCli), cCorreoAsig, cCorreoAsigSec, clsVarGlobal.User.idUsuario);

                this.Close();
            }

        }

        private void txtBase1_Validating(object sender, CancelEventArgs e)
        {
            Regex xrEmail = new Regex(@"^[_A-z0-9-]+(.[_A-z0-9-]+)*@[A-z0-9-]+(.[A-z0-9-]+)*(.[A-z]{2,4})$");

            if (String.IsNullOrEmpty(this.txtBase1.Text.Trim()))
            {
            }
            else if (!xrEmail.IsMatch(this.txtBase1.Text))
            {
                MessageBox.Show("La texto introducido no tiene el formato de un email ", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBase1.Focus();

            }
        }

        private void txtBase3_Validating(object sender, CancelEventArgs e)
        {
            Regex xrEmail = new Regex(@"^[_A-z0-9-]+(.[_A-z0-9-]+)*@[A-z0-9-]+(.[A-z0-9-]+)*(.[A-z]{2,4})$");

            if (String.IsNullOrEmpty(this.txtBase3.Text.Trim()))
            {
            }
            else if (!xrEmail.IsMatch(this.txtBase3.Text))
            {
                MessageBox.Show("La texto introducido no tiene el formato de un email ", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBase1.Focus();

            }
        }


        #endregion

        
        #region Metodos 
        
        private void consultarDatosClientes(DataTable dtIntervi, int idPaso)
        {
            
            DataSet dsInterv = new DataSet("dsInterv");
            dsInterv.Tables.Add(dtIntervi);
            string xmlBusqCorreo = dsInterv.GetXml();
            DataTable dtCorreosPorCliente;
            
            if (idPaso == 1)
            {
                dtCorreosPorCliente = clsDeposito.CNBusquedaCorreo(xmlBusqCorreo,idPaso);
            }
            else if (idPaso == 2)
            {
                dtCorreosPorCliente = clsDeposito.CNBusquedaCorreo(xmlBusqCorreo,idPaso);
            }
            else
            {
                dtCorreosPorCliente = null;
            }
           
            dtgCorreosCliente.DataSource = dtCorreosPorCliente;
            formatearGrid();
            dsInterv.Tables.Remove(dtIntervi); 


        }

  
       private void formatearGrid()
       {
           foreach (DataGridViewColumn column in this.dtgCorreosCliente.Columns)
           {
               column.Visible = false;
               column.SortMode = DataGridViewColumnSortMode.NotSortable;
           }

           dtgCorreosCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

           dtgCorreosCliente.Columns["idCli"].Visible = true;
           dtgCorreosCliente.Columns["cNombre"].Visible = true;
           dtgCorreosCliente.Columns["cCorreoCli"].Visible = true;
           dtgCorreosCliente.Columns["cCorreoCliAdicional"].Visible = true;

           dtgCorreosCliente.Columns["idCli"].Width = 60;
           dtgCorreosCliente.Columns["cNombre"].Width = 250;
           dtgCorreosCliente.Columns["cCorreoCli"].Width = 200;
           dtgCorreosCliente.Columns["cCorreoCliAdicional"].Width = 200;

           dtgCorreosCliente.Columns["idCli"].HeaderText = "Nro Cliente";
           dtgCorreosCliente.Columns["cNombre"].HeaderText = "Apellidos y Nombres";
           dtgCorreosCliente.Columns["cCorreoCli"].HeaderText = "Correo Principal";
           dtgCorreosCliente.Columns["cCorreoCliAdicional"].HeaderText = "Correo Adicional";
           
           dtgCorreosCliente.Refresh();
       }

        private DataSet GetDataSet(DataGridView dgv)
        {
            var ds = new DataSet();
            var dt = new DataTable();

            foreach (var column in dgv.Columns.Cast<DataGridViewColumn>())
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            var objCellValues = new object[dgv.Columns.Count];
            foreach (var row in dgv.Rows.Cast<DataGridViewRow>())
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    objCellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(objCellValues);
            }
            ds.Tables.Add(dt);
            return ds;
        }

        private void HabilitarCampos(bool lVig)
        {
            this.txtBase2.Enabled = false;
            this.txtBase1.Enabled = lVig;
            this.txtBase3.Enabled = lVig;

        }

        public string cCorreoAsignadoPrincipal()
        {
            return cCorreoAsignado;
        }

        #endregion


      

    }
}
