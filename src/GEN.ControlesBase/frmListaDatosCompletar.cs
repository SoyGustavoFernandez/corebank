using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using GEN.ControlesBase;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmListaDatosCompletar : frmBase
    {
        #region Variables Globales
        
        int nFila;
        DataTable dtListarProf = new DataTable();
        DataTable dtListarCargo = new DataTable();
        clsCNProfesion ObjDatos = new clsCNProfesion();
        clsCNClienteCargo objClienteCargo = new clsCNClienteCargo();
      
        
        public Boolean aceptado = false;
        
        public int idDato = 0;
        int idBusq = 1;


        #endregion

        #region Eventos
        public frmListaDatosCompletar()
        {
            InitializeComponent();
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusDatos.Text))
            {

                if (idBusq == 1) // profesion
                {
                    BuscarDatosProfesion(txtBusDatos.Text);
                    dtgDatos.Focus();
                }
                else if (idBusq == 2) // cargo 
                {
                    BuscarDatosCargo(txtBusDatos.Text);
                    dtgDatos.Focus();
                }
                
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para la búsqueda", "Registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void dtgDatos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDatos.Rows.Count > 0)
            {
                nFila = e.RowIndex;

                if (idBusq == 1)
                {
                    idDato = Convert.ToInt32(dtListarProf.Rows[nFila]["idProfesion"].ToString());

                }
                else if (idBusq == 2)
                {
                    idDato = Convert.ToInt32(dtListarCargo.Rows[nFila]["idCliCargo"].ToString());
                }


            }

        }

        private void dtgDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }

        }

        private void dtgDatos_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                Aceptar();
            }
        }

        private void dtgDatos_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();

        }

        private void txtBusDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtBusDatos.Text))
                {

                    if (idBusq == 1)
                    {
                        string cProf = txtBusDatos.Text.Trim();
                        BuscarDatosProfesion(cProf);
                        dtgDatos.Focus();
                    }
                    else if (idBusq == 2)
                    {
                        string cCargo = txtBusDatos.Text.Trim();
                        BuscarDatosCargo(cCargo);
                        dtgDatos.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para la búsqueda", "Registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBusDatos.Focus();
                    return;
                }

            }
        }

        #endregion

        #region Metodos
        private void Aceptar()
        {
            if (dtgDatos.Rows.Count > 0)
            {
                this.aceptado = true;
                if (idBusq == 1)
                {
                    idDato = Convert.ToInt32(dtListarProf.Rows[nFila]["idProfesion"].ToString());

                }
                else if (idBusq == 2)
                {
                    idDato = Convert.ToInt32(dtListarCargo.Rows[nFila]["idCliCargo"].ToString());
                }

            }
            else
            {
                idDato = 0;
            }
            this.Dispose();

        }

        public frmListaDatosCompletar(int idBusqueda)
        {
            InitializeComponent();
            this.idBusq = idBusqueda;
        
        }


        private void BuscarDatosProfesion(string cProf)
        {
            dtListarProf = ObjDatos.ListarProfesionBusqueda(cProf);
            if (dtListarProf.Rows.Count > 0)
            {
                dtgDatos.DataSource = dtListarProf;
                FormatoGridProfesiones();
            }
            else
            {
                dtgDatos.DataSource = "";
                txtBusDatos.Focus();
            }
        }
        private void BuscarDatosCargo(string cCargo)
        {

            dtListarCargo = objClienteCargo.CNListaClienteCargosBus(cCargo);
            if (dtListarCargo.Rows.Count > 0)
            {
                dtgDatos.DataSource = dtListarCargo;
                FormatoGridCargo();
            }
            else
            {
                dtgDatos.DataSource = "";
                txtBusDatos.Focus();
            }
        }
        private void FormatoGridProfesiones()
        {
            foreach (DataGridViewColumn item in dtgDatos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDatos.Columns["idProfesion"].Visible = true;
            dtgDatos.Columns["cProfesion"].Visible = true;

            dtgDatos.Columns["idProfesion"].Width = 30;
            dtgDatos.Columns["cProfesion"].Width = 200;
            
            dtgDatos.Columns["idProfesion"].HeaderText = "Nro.";
            dtgDatos.Columns["cProfesion"].HeaderText = "Desc. Profesion";
        }

        private void FormatoGridCargo()
        {
            foreach (DataGridViewColumn item in dtgDatos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDatos.Columns["idCliCargo"].Visible = true;
            dtgDatos.Columns["cClienteCargo"].Visible = true;

            dtgDatos.Columns["idCliCargo"].Width = 30;
            dtgDatos.Columns["cClienteCargo"].Width = 200;

            dtgDatos.Columns["idCliCargo"].HeaderText = "Nro.";
            dtgDatos.Columns["cClienteCargo"].HeaderText = "Desc. Cargo";
        }



        
        
        
        #endregion

   

      
        
    }
}
