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
using PRE.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmPeriodoPresupuesto : frmBase
    {
        #region Variables Globales
        
        DataTable dtPeriodos;        
        private String cTipoOperacion = "N";    //Puede ser N --> Nuevo, A--> Actualizar
        private int nEstadoPeriodo = 0;
        String cTituloMensaje = "Periodo presupuestal";
        clsCNPeriodos cnperiodos = new clsCNPeriodos();

        #endregion       

        #region Eventos
        public frmPeriodoPresupuesto()
        {
            InitializeComponent();
        }

        private void frmPeriodoPresupuesto_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            habilitarControles(false);
            limpiarControles();
            verPeriodos();
            formatoDTGPeriodos();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {            
            nuevoPeriodo();
            this.btnNuevo1.Enabled = false;
            cTipoOperacion = "N";
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgPeriodos.Rows.Count <= 0)
            {
                MessageBox.Show("No existen periodos presupuestales", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            habilitarControles(true);
            siguienteEstado();
            cTipoOperacion = "A";
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            String cAnioPeriodo = this.txtAnioPeriodo.Text;
            int idEstado = Convert.ToInt32(this.cboEstadoPeriodoPresupuesto1.SelectedValue);
            int idUsuReg = clsVarGlobal.User.idUsuario;
            DateTime dFechaReg = clsVarGlobal.dFecSystem;
            if (cTipoOperacion == "N")
            {
                if (MessageBox.Show("¿Está seguro de crear el Periodo: " + cAnioPeriodo + "?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    insertarPeriodo(0, cAnioPeriodo, idEstado, idUsuReg, dFechaReg);
                }                
            }
            else if (cTipoOperacion == "A")
            {
                if (!existeEjecucionEnDTG(Convert.ToInt32( this.cboEstadoPeriodoPresupuesto1.SelectedValue)))
                {
                    int idPeriodo = (int)this.dtgPeriodos.CurrentRow.Cells["idPeriodo"].Value;
                    if (verificaConsistenciaPres(idPeriodo))
                    {                        
                        insertarPeriodo(idPeriodo, cAnioPeriodo, idEstado, idUsuReg, dFechaReg);
                    } 
                }                
            }
            this.cboEstadoPeriodoPresupuesto1.CargarTodosPeriodos();            
            verPeriodos();
            habilitarControles(false);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {            
            limpiarControles();
            habilitarControles(false);
            this.cboEstadoPeriodoPresupuesto1.CargarTodosPeriodos();
            verPeriodos();            
        }
        private void dtgPeriodos_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDetalles();
           
        }
        private void cboEstadoPeriodoPresupuesto1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cboEstadoPeriodoPresupuesto1.SelectedValue = nEstadoPeriodo;
        }
                

        #endregion

        #region Metodos
       
        private void verPeriodos()
        {
            dtPeriodos = cnperiodos.listarPeriodosTodos();                     
            this.dtgPeriodos.DataSource = dtPeriodos.DefaultView;                                   
        }
        private void formatoDTGPeriodos()
        {
            foreach (DataGridViewColumn item in dtgPeriodos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            this.dtgPeriodos.Columns["cPeriodos"].Visible = true;
            this.dtgPeriodos.Columns["cEstado"].Visible = true;
            this.dtgPeriodos.Columns["cPeriodos"].HeaderText = "Periodos";
            this.dtgPeriodos.Columns["cEstado"].HeaderText = "Estado";
        }
        private void mostrarDetalles()
        {
            if (this.dtgPeriodos.SelectedRows.Count > 0)
            {
                this.txtAnioPeriodo.Text = Convert.ToString(this.dtgPeriodos.CurrentRow.Cells["cPeriodos"].Value);
                this.cboEstadoPeriodoPresupuesto1.SelectedValue = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Cells["idEstado"].Value);
                habilitarControles(false);
            }
        }
        private void habilitarControles(Boolean Val)
        {
            this.txtAnioPeriodo.Enabled = Val;
            this.txtAnioPeriodo.ReadOnly = Val;
            this.cboEstadoPeriodoPresupuesto1.Enabled = Val;
            this.dtgPeriodos.Enabled = !Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnGrabar1.Enabled = Val;
            this.btnCancelar1.Enabled = Val;

        }
        private void limpiarControles()
        {
            this.cboEstadoPeriodoPresupuesto1.SelectedIndex = -1;
            this.txtAnioPeriodo.Clear();
        }
        private void nuevoPeriodo()
        {          
            this.cboEstadoPeriodoPresupuesto1.SelectedIndex = 0;
            int dSigPeriodo = (int)(Convert.ToInt32(clsVarGlobal.dFecSystem.ToString("yyyy")));
            while (existePeriodoEnDTG(dSigPeriodo))
            {
                dSigPeriodo = dSigPeriodo + 1;    
            }                    
            this.txtAnioPeriodo.Text = "" + dSigPeriodo;
            //if (existePeriodoEnDTG(dSigPeriodo))
            //{
            //    MessageBox.Show("Ya existe periodo " + dSigPeriodo, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    mostrarDetalles();
            //}else {
                habilitarControles(true);
                this.cboEstadoPeriodoPresupuesto1.Enabled = false;
                this.txtAnioPeriodo.Focus();
            //}            
        }
        private Boolean existePeriodoEnDTG(int cPeriodoSig)
        {
            foreach (DataGridViewRow Row in dtgPeriodos.Rows)
            {
                int cValor = Convert.ToInt32(Row.Cells["cPeriodos"].Value);
                if (cValor == cPeriodoSig)
                {
                    return true;
                }
            }
            return false;
        }
        private void siguienteEstado() 
        {           
            int nEstadoActual = Convert.ToInt32(this.cboEstadoPeriodoPresupuesto1.SelectedValue);
            if (nEstadoActual == cboEstadoPeriodoPresupuesto1.DevuelveUltimoIDEstado())
            {
                MessageBox.Show("No se puede modificar, periodo cerrado", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarControles(false);
            }
            else {
                nEstadoPeriodo = nEstadoActual + 1;
                this.cboEstadoPeriodoPresupuesto1.SelectedValue = nEstadoPeriodo;
            }            
        }
        private void insertarPeriodo(int idPeriodo, string cPeriodo, int idEstado, int idUsu, DateTime dFecha)
        {
            DataTable dtResultado = cnperiodos.InsertarPeriodo(idPeriodo, cPeriodo, idEstado, idUsu, dFecha);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        private Boolean verificaConsistenciaPres(int idPeriodo)
        {
            DataTable dtResultado = cnperiodos.VerificaConsistenciaPresupuesto(idPeriodo);            
            int nResultado = Convert.ToInt32( dtResultado.Rows[0]["nRespuesta"].ToString());
            if (nResultado == -1)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (nResultado == 0)
            {
                if (MessageBox.Show("Existen valores con 0.00. ¿Está seguro de cambiar el estado del periodo?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de cambiar el estado del periodo?", cTituloMensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
        }
        
        private Boolean existeEjecucionEnDTG(int idEstado)
        {
            if (idEstado == 2) //2 = ejecucion
            {
                foreach (DataGridViewRow Row in dtgPeriodos.Rows)
                {
                    int cValor = Convert.ToInt32(Row.Cells["idEstado"].Value);
                    if (cValor == idEstado)
                    {
                        MessageBox.Show("Ya existe un periodo en ejecución", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }            
            return false;            
        }

        #endregion 
    

        

      

              

        
    }
}
