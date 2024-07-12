using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmAdministrarBandejaAnalista : frmBase
    {
        public frmAdministrarBandejaAnalista()
        {
            InitializeComponent();
        }
        #region Variables Globales
        clsCNMantenimiento clsMantenimiento = new clsCNMantenimiento();
        String cNombreFormulario = "Mant. Analista Riesgo / Zona";
        List<clsAnalistaRsgZona> listAnalistaRsgZona = new List<clsAnalistaRsgZona>();
        #endregion

        #region Metodos
        private void cargarAnalistas()
        {
            DataTable dt = clsMantenimiento.listarAnalistasRsg();
            this.cboAnalista.ValueMember = "idUsuario";
            this.cboAnalista.DisplayMember = "cNombre";
            this.cboAnalista.DataSource = dt;
        }
        private void cargarContenidoGrid()
        {
           
            listAnalistaRsgZona = clsMantenimiento.listarAnalistaRsgYZona();
            this.dtgAnalistaRsgZona.DataSource = listAnalistaRsgZona;
            formatearGrid();
        }
        private void formatearGrid()
        {
            foreach (DataGridViewColumn item in this.dtgAnalistaRsgZona.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            this.dtgAnalistaRsgZona.Columns["cNombre"].Visible = true;
            this.dtgAnalistaRsgZona.Columns["cDesZona"].Visible = true;

            this.dtgAnalistaRsgZona.Columns["cNombre"].HeaderText = "Nombres";
            this.dtgAnalistaRsgZona.Columns["cDesZona"].HeaderText = "Zona Asignada";

            DataGridViewImageColumn btnGrid = new DataGridViewImageColumn();
            {
                btnGrid.Name = "btnEliminar";
                btnGrid.HeaderText = "";
                btnGrid.HeaderText = "Quitar";
                btnGrid.Image = (System.Drawing.Image)Properties.Resources.btn_quitar;
                //buttons.Text = "Eliminar";
                //buttons.UseColumnTextForButtonValue = true;
                btnGrid.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //buttons.FlatStyle = FlatStyle.Standard;
                btnGrid.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            dtgAnalistaRsgZona.Columns.Add(btnGrid);
        }
        private void guardarRegistro()
        {
			int index = listAnalistaRsgZona.FindIndex(f => f.idZona == Convert.ToInt16(this.cboZona.SelectedValue));
			if (index >= 0)
			{
				MessageBox.Show("Ya existe un registro con esa zona", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

            DialogResult dialrConfirmar = MessageBox.Show("¿Está seguro de registrar?", cNombreFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialrConfirmar == DialogResult.Yes)
            {
                int idZona =  Convert.ToInt16(this.cboZona.SelectedValue);
                int idAnalista =  Convert.ToInt16(this.cboAnalista.SelectedValue);
                int idUsuarioReg = clsVarGlobal.PerfilUsu.idUsuario;
                DataTable dt = clsMantenimiento.guardarAnalistaRsgZona(idZona, idAnalista, idUsuarioReg);
                if (dt.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarContenidoGrid();
                }
                else if (dt.Rows[0]["idMsje"].ToString() == "2")
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                return;
            }

        }
        private void quitarRegistro(int idAnalistaRsgZona)
        {
            DialogResult dialrConfirmar = MessageBox.Show("¿Está seguro de quitar este registro?", cNombreFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialrConfirmar == DialogResult.Yes)
            {
                int idUsuarioReg = clsVarGlobal.PerfilUsu.idUsuario;
                DataTable dt = clsMantenimiento.quitarAnalistaRsgZona(idAnalistaRsgZona, idUsuarioReg);
                if (dt.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarContenidoGrid();
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                return;
            }

        }
        #endregion

        #region Eventos
        private void frmAdministrarBandejaAnalista_Load(object sender, EventArgs e)
        {
            this.Text = cNombreFormulario;
            cargarAnalistas();
            cargarContenidoGrid();
        }
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }
        private void dtgAnalistaRsgZona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgAnalistaRsgZona.CurrentCell.OwningColumn.Name.Equals("btnEliminar"))
            {
                int nValor = Convert.ToInt32(dtgAnalistaRsgZona.Rows[e.RowIndex].Cells["idAnalistaRsgZona"].Value.ToString());
                int idAnalistaRsgZona = nValor;//listAnalistaRsgZona.ElementAt(nfilaseleccionada).idAnalistaRsgZona;
                quitarRegistro(idAnalistaRsgZona);
                
            }
        }
        #endregion
    }
}
