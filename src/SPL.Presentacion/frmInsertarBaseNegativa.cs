using EntityLayer;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmInsertarBaseNegativa : frmBase
    {

        #region Variables Globales

        DataTable tabla;
        List<string> Columnas = new List<string>();
        bool GuardarUnico = true;
        bool EstadoEdicionUnico = false;
        bool EstadoEdicionMultiple = false;

        #endregion

        public frmInsertarBaseNegativa()
        {
            InitializeComponent();
            CargarListaColumnas();
        }

        #region Eventos

        private void frmInsertarBaseNegativa_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }
                
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiarcontroles();
            btnNuevo1.Enabled = false;
            
            if (GuardarUnico)
            {
                btnGrabar1.Enabled = true;
                btnBusqueda1.Enabled = false;
                txtPaterno.Enabled=true;
                txtMaterno.Enabled=true;
                txtCasada.Enabled=true;
                txtNombre.Enabled=true;
                this.cboTipoDocumento1.Enabled=true;
                this.txtCBDNI1.Enabled=true;
                txtTipoLista.Enabled=true;
                this.cboTipoPersona1.Enabled = true;
                txtNombre.Focus();
                EstadoEdicionUnico = true;
                EstadoEdicionMultiple = false;
            }
            else
            {
                btnBusqueda1.Enabled = true;
                btnGrabar1.Enabled = false;
                btnSalir1.Enabled = true;
                btnNuevo1.Enabled = false;
                txtPath.Enabled = true;
                EstadoEdicionUnico = false;
                EstadoEdicionMultiple = true;

            }
        }
        
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            Cargar();           
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!GuardarUnico)
            {
                try
                {
                    clsListaPersonaNegativa lista = new clsListaPersonaNegativa();
                    clsCNPersonaNegativa ps = new clsCNPersonaNegativa();

                    for (int i = 0; i < dtgListaNegativa.Rows.Count; i++)
                    {
                        clsPersonaNegativa personaNeg = new clsPersonaNegativa();
                        personaNeg.idTipoPersona = Convert.ToInt32(tabla.Rows[i]["idTipoPersona"]);
                        personaNeg.cNombres = Convert.ToString(tabla.Rows[i]["cNombres"]);
                        personaNeg.cApePaterno = Convert.ToString(tabla.Rows[i]["cApePaterno"]);
                        personaNeg.cApeMaterno = Convert.ToString(tabla.Rows[i]["cApeMaterno"]);
                        personaNeg.cApeCasado = Convert.ToString(tabla.Rows[i]["cApeCasado"]);
                        personaNeg.cNombre = Convert.ToString(tabla.Rows[i]["cNombre"]);
                        personaNeg.idTipoDoc = Convert.ToInt32(tabla.Rows[i]["idTipoDoc"]);
                        personaNeg.cNumDoc = Convert.ToString(tabla.Rows[i]["cNumDoc"]);
                        personaNeg.idTipoLista = Convert.ToInt32(tabla.Rows[i]["idTipoLista"]);
                        personaNeg.dFechaRegistro = clsVarGlobal.dFecSystem;

                        lista.Add(personaNeg);
                    }
                    ps.InsertarListaNegativa(lista);
                    MessageBox.Show("Los datos han sido exportados exitosamente", "Registro Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarcontroles();
                    EstadoEdicionMultiple = false;
                    EstadoEdicionUnico = false;
                    btnSalir1.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo exportar la información a la tabla", "Registro Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
            }
            else
            {
                try
                {
                    clsListaPersonaNegativa lista = new clsListaPersonaNegativa();
                    clsCNPersonaNegativa ps = new clsCNPersonaNegativa();
                    clsPersonaNegativa personaNeg = new clsPersonaNegativa();
                    personaNeg.idTipoPersona = Convert.ToInt32(cboTipoPersona1.SelectedValue);
                    personaNeg.cNombres = txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
                    personaNeg.cApePaterno = txtPaterno.Text;
                    personaNeg.cApeMaterno = txtMaterno.Text;
                    personaNeg.cApeCasado = txtCasada.Text;
                    personaNeg.cNombre = txtNombre.Text;
                    personaNeg.idTipoDoc = Convert.ToInt32(cboTipoDocumento1.SelectedValue);
                    personaNeg.cNumDoc = txtCBDNI1.Text;
                    personaNeg.idTipoLista = Convert.ToInt32(txtTipoLista.Text);
                    personaNeg.dFechaRegistro = clsVarGlobal.dFecSystem;
                    lista.Add(personaNeg);

                    ps.InsertarListaNegativa(lista);
                    MessageBox.Show("Los datos han sido guardados exitosamente", "Registro Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarcontroles();
                    EstadoEdicionMultiple = false;
                    EstadoEdicionUnico = false;
                    btnSalir1.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudieron guardar los datos", "Registro Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            GuardarUnico = true; 
            
            if (EstadoEdicionMultiple)
            {
                var confirmacion = MessageBox.Show("¿Desea deshacer todos los cambios?", "Registro Base Negativa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmacion == DialogResult.Yes)
                {
                    EstadoEdicionMultiple = false;
                    EstadoEdicionUnico = false;
                    limpiarcontroles();
                }
                else
                {
                    tbcBase1.SelectedIndex = 1;
                    EstadoEdicionMultiple = true;
                }                    
            }    
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            GuardarUnico = false;

            if (EstadoEdicionUnico)
            {
                var confirmacion = MessageBox.Show("¿Desea deshacer todos los cambios?", "Registro Base Negativa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmacion == DialogResult.Yes)
                {
                    EstadoEdicionMultiple = false;
                    EstadoEdicionUnico = false;
                    limpiarcontroles();
                }
                else
                {
                    tbcBase1.SelectedIndex = 0;
                    EstadoEdicionUnico = true;
                }
            }    
        }

        #endregion

        #region Metodos

        private void limpiarcontroles()
        {
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtCasada.Text = "";
            txtNombre.Text = "";
            txtCBDNI1.Text = "";
            txtTipoLista.Text = "";
            txtPath.Text = "";
            dtgListaNegativa.DataSource = null;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnBusqueda1.Enabled = false;
            txtPaterno.Enabled = false;
            txtMaterno.Enabled = false;
            txtCasada.Enabled = false;
            txtNombre.Enabled = false;
            this.cboTipoDocumento1.Enabled = false;
            this.txtCBDNI1.Enabled = false;
            txtTipoLista.Enabled = false;
            this.cboTipoPersona1.Enabled = false;
            txtPath.Enabled = false;
        }

        private bool ValidarHoja(DataTable dt)
        {
            foreach (var item in Columnas)
            {
                if (!dt.Columns.Contains(item))
                {
                    MessageBox.Show("La tabla no tiene la columna " + item + " ", "Registro Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPath.Text = "";
                    return false;
                }
            }
            return true;
        }

        private void Cargar()
        {
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();
            txtPath.Text = OpenDialog.FileName;

            if (String.IsNullOrEmpty(txtPath.Text))
            {
                return;
            }


            try
            {
                ExcelHandler ex = new ExcelHandler();
                tabla = ex.ImportExcelToDataTable(txtPath.Text);

                if (ValidarHoja(tabla))
                {
                    dtgListaNegativa.DataSource = tabla;
                    btnGrabar1.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido cargar la hoja de Excel", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        private void CargarListaColumnas()
        {
            Columnas.Add("idTipoPersona");
            Columnas.Add("cNombres");
            Columnas.Add("cApePaterno");
            Columnas.Add("cApeMaterno");
            Columnas.Add("cApeCasado");
            Columnas.Add("cNombre");
            Columnas.Add("idTipoDoc");
            Columnas.Add("cNumDoc");
            Columnas.Add("idTipoLista");
            Columnas.Add("dFechaRegistro");
        }

        #endregion
    }
}
