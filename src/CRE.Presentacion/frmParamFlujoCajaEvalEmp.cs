using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using System.IO;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmParamFlujoCajaEvalEmp : frmBase
    {
        private clsCNEvalEmp EvalEmp = new clsCNEvalEmp();

        DataTable dtIngresos = new DataTable("dtIngresos");
        DataTable dtEgresos = new DataTable("dtIngresos");

        public frmParamFlujoCajaEvalEmp()
        {
            InitializeComponent();
        }

        private void frmParamFlujoCajaEvalEmp_Load(object sender, EventArgs e)
        {
            CargarDatos();                        
        }

        private void CargarDatos()
        {
            DataSet dsParametrosFlujoCajaEvalEmp = EvalEmp.CNdsObtenerParametrosFlujoCajaEvalEmp();

            DataTable dtConceptos = dsParametrosFlujoCajaEvalEmp.Tables[0];//Conceptos de Conceptos            
            DataTable dtParametros = dsParametrosFlujoCajaEvalEmp.Tables[1];//Conceptos de Parametros

            if (dtParametros.Rows.Count == 0)//Crear parámetros por defecto
            {
                MessageBox.Show("Aún no se han registrado Parámetros para el Flujo de Caja de la Evaluación Empresarial.", "Parámetros Flujo Caja - Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = true;

                dtIngresos.Columns.Add("IdParametrosFlujoCaja", typeof(int));
                dtIngresos.Columns.Add("cConcepIngresoEgreso", typeof(string));
                dtIngresos.Columns.Add("nPorcent", typeof(Decimal));
                dtIngresos.Columns.Add("idConcepIngresoEgreso", typeof(int));
                dtIngresos.Columns.Add("simbolo", typeof(string));
                dtIngresos.Columns.Add("lVigente", typeof(bool));

                dtEgresos = dtIngresos.Clone();

                //Llenar Ingresos /Egresos
                for (int i = 0; i < dtConceptos.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtConceptos.Rows[i]["idTipoIngresoEgreso"]) == 1)//INGRESO
                    {
                        DataRow filaIngresos = dtIngresos.NewRow();
                        filaIngresos["IdParametrosFlujoCaja"] = 0;
                        filaIngresos["cConcepIngresoEgreso"] = dtConceptos.Rows[i]["cConcepIngresoEgreso"];
                        filaIngresos["nPorcent"] = 0.0;
                        filaIngresos["idConcepIngresoEgreso"] = dtConceptos.Rows[i]["idConcepIngresoEgreso"];
                        filaIngresos["simbolo"] = "%";
                        dtIngresos.Rows.Add(filaIngresos);
                    }
                    if (Convert.ToInt32(dtConceptos.Rows[i]["idTipoIngresoEgreso"]) == 2)//EGRESO
                    {
                        DataRow filaEgresos = dtEgresos.NewRow();
                        filaEgresos["IdParametrosFlujoCaja"] = 0;
                        filaEgresos["cConcepIngresoEgreso"] = dtConceptos.Rows[i]["cConcepIngresoEgreso"];
                        filaEgresos["nPorcent"] = 0.0;
                        filaEgresos["idConcepIngresoEgreso"] = dtConceptos.Rows[i]["idConcepIngresoEgreso"];
                        filaEgresos["simbolo"] = "%";
                        dtEgresos.Rows.Add(filaEgresos);
                    }
                }

                foreach (DataColumn columna in dtIngresos.Columns)
                {
                    columna.ReadOnly = false;
                }
                foreach (DataColumn columna in dtEgresos.Columns)
                {
                    columna.ReadOnly = false;
                }
                dtgIngresos.DataSource  = dtIngresos;
                dtgEgresos.DataSource   = dtEgresos;

                DarFormatoVisibilidadGrid();
                HabilitarCamposGrid();
            }
            else
            {
                dtIngresos.Columns.Add("IdParametrosFlujoCaja", typeof(int));
                dtIngresos.Columns.Add("cConcepIngresoEgreso", typeof(string));
                dtIngresos.Columns.Add("nPorcent", typeof(Decimal));
                dtIngresos.Columns.Add("idConcepIngresoEgreso", typeof(int));                
                dtIngresos.Columns.Add("simbolo", typeof(string));

                dtEgresos = dtIngresos.Clone();

                for (int f = 0; f < dtParametros.Rows.Count; f++)
                {
                    if (Convert.ToInt32(dtConceptos.Rows[f]["idTipoIngresoEgreso"]) == 1)//INGRESO
                    {
                        DataRow filaIngresos = dtIngresos.NewRow();
                        filaIngresos["IdParametrosFlujoCaja"] = dtParametros.Rows[f]["IdParametrosFlujoCaja"];
                        filaIngresos["cConcepIngresoEgreso"]    = dtParametros.Rows[f]["cConcepIngresoEgreso"];
                        filaIngresos["nPorcent"] = dtParametros.Rows[f]["nPorcent"];
                        filaIngresos["idConcepIngresoEgreso"] = dtParametros.Rows[f]["idConcepIngresoEgreso"];
                        filaIngresos["simbolo"] = "%";
                        dtIngresos.Rows.Add(filaIngresos);
                    }
                    if (Convert.ToInt32(dtConceptos.Rows[f]["idTipoIngresoEgreso"]) == 2)//EGRESO
                    {
                        DataRow filaEgresos = dtEgresos.NewRow();
                        filaEgresos["IdParametrosFlujoCaja"] = dtParametros.Rows[f]["IdParametrosFlujoCaja"];
                        filaEgresos["cConcepIngresoEgreso"]  = dtParametros.Rows[f]["cConcepIngresoEgreso"];
                        filaEgresos["nPorcent"] = dtParametros.Rows[f]["nPorcent"];
                        filaEgresos["idConcepIngresoEgreso"] = dtParametros.Rows[f]["idConcepIngresoEgreso"];
                        filaEgresos["simbolo"] = "%";
                        dtEgresos.Rows.Add(filaEgresos);
                    }
                }
                dtgIngresos.DataSource  = dtIngresos;
                dtgEgresos.DataSource   = dtEgresos;

                DarFormatoVisibilidadGrid();

                this.btnEditar.Enabled = true;
            }
        }

        private void DarFormatoVisibilidadGrid()
        {
            if (dtgIngresos.Rows.Count != 0)
            {
                for (int c = 0; c < dtgIngresos.Columns.Count; c++)
                {
                    if (dtgIngresos.Columns[c].Name.Equals("nPorcent") || dtgIngresos.Columns[c].Name.Equals("simbolo") || dtgIngresos.Columns[c].Name.Equals("cConcepIngresoEgreso"))
                        {
                            dtgIngresos.Columns[c].Visible = true;
                            if (dtgIngresos.Columns[c].Name.Equals("simbolo"))
                            {
                                dtgIngresos.Columns[c].Width = 30;
                                dtgIngresos.Columns[c].HeaderText = "";
                            }
                            if (dtgIngresos.Columns[c].Name.Equals("nPorcent"))
                            {
                                dtgIngresos.Columns[c].HeaderText = "Porcentaje";
                            }
                            if (dtgIngresos.Columns[c].Name.Equals("cConcepIngresoEgreso"))
                            {
                                dtgIngresos.Columns[c].Width = 150;
                                dtgIngresos.Columns[c].HeaderText = "";
                            }
                        }
                    else
                        dtgIngresos.Columns[c].Visible = false;
                    dtgIngresos.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            if (dtgEgresos.Rows.Count != 0)
            {
                for (int c = 0; c < dtgEgresos.Columns.Count; c++)
                {
                    if (dtgEgresos.Columns[c].Name.Equals("nPorcent") || dtgEgresos.Columns[c].Name.Equals("simbolo") || dtgEgresos.Columns[c].Name.Equals("cConcepIngresoEgreso"))
                    {
                        dtgEgresos.Columns[c].Visible = true;
                        if (dtgEgresos.Columns[c].Name.Equals("simbolo"))
                        {
                            dtgEgresos.Columns[c].Width = 30;
                            dtgEgresos.Columns[c].HeaderText = "";
                        }
                        if (dtgEgresos.Columns[c].Name.Equals("nPorcent"))
                        {
                            dtgEgresos.Columns[c].HeaderText = "Porcentaje";
                        }
                        if (dtgEgresos.Columns[c].Name.Equals("cConcepIngresoEgreso"))
                        {
                            dtgEgresos.Columns[c].Width = 150;
                            dtgEgresos.Columns[c].HeaderText = "";
                        }
                    }
                    else
                        dtgEgresos.Columns[c].Visible = false;
                    dtgEgresos.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void HabilitarCamposGrid()
        {
            if (dtgIngresos.Rows.Count != 0)
            {
                dtgIngresos.ReadOnly = false;
                foreach (DataGridViewColumn columna in dtgIngresos.Columns)
                {
                    if (columna.Name.Equals("nPorcent") == false)
                        columna.ReadOnly = true;
                }
            }
            if (dtgEgresos.Rows.Count != 0)
            {
                dtgEgresos.ReadOnly = false;
                foreach (DataGridViewColumn columna in dtgEgresos.Columns)
                {
                    if (columna.Name.Equals("nPorcent") == false)
                        columna.ReadOnly = true;
                }
            }            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (CamposValidos()==false)
                return ;

            DataTable dtParametrosFlujoCaja = new DataTable ("dtParametrosFlujoCaja");
            dtParametrosFlujoCaja           = dtIngresos.Clone();
                
            for (int f = 0; f < dtIngresos.Rows.Count; f++)
            {
                DataRow filaParametros = dtParametrosFlujoCaja.NewRow();
                filaParametros["IdParametrosFlujoCaja"]         = dtIngresos.Rows[f]["IdParametrosFlujoCaja"];
                filaParametros["nPorcent"]                      = dtIngresos.Rows[f]["nPorcent"];
                filaParametros["idConcepIngresoEgreso"] = dtIngresos.Rows[f]["idConcepIngresoEgreso"];
                dtParametrosFlujoCaja.Rows.Add(filaParametros);
            }
            for (int f = 0; f < dtEgresos.Rows.Count; f++)
            {
                DataRow filaParametros = dtParametrosFlujoCaja.NewRow();
                filaParametros["IdParametrosFlujoCaja"]         = dtEgresos.Rows[f]["IdParametrosFlujoCaja"];
                filaParametros["nPorcent"]                      = dtEgresos.Rows[f]["nPorcent"];
                filaParametros["idConcepIngresoEgreso"] = dtEgresos.Rows[f]["idConcepIngresoEgreso"];
                dtParametrosFlujoCaja.Rows.Add(filaParametros);
            }

            dtParametrosFlujoCaja.TableName = "dtParametrosFlujoCaja";
            DataSet dsParametrosFlujoCaja   = new DataSet("dsParametrosFlujoCaja");
                dsParametrosFlujoCaja.Tables.Add(dtParametrosFlujoCaja);
            String XmlParametrosFlujoCaja   = dsParametrosFlujoCaja.GetXml();
            XmlParametrosFlujoCaja          = clsCNFormatoXML.EncodingXML(XmlParametrosFlujoCaja);

            DataTable dtRespuesta = EvalEmp.CNdtInsertarParametrosFlujoCajaEvalEmp(XmlParametrosFlujoCaja);

            MessageBox.Show("Se ha Grabado correctamente.", "Grabar Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dsParametrosFlujoCaja.Tables.Clear();
            dtParametrosFlujoCaja = null;

            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnEditar.Enabled = false;
        }

        private Boolean CamposValidos()
        {
            for (int f = 0; f <  dtIngresos.Rows.Count; f++)
            {
                if (Convert.ToDecimal (dtIngresos.Rows[f]["nPorcent"])>100)
                {
                    MessageBox.Show("El porcentaje no puede ser MAYOR que 100%. Revise las cantidades en INGRESOS.", "Grabar Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgIngresos.CurrentCell = dtgIngresos[1, f];
                    return false;
                }
            }

            for (int f = 0; f < dtEgresos.Rows.Count; f++)
            {
                if (Convert.ToDecimal (dtEgresos.Rows[f]["nPorcent"]) > 100)
                {
                    MessageBox.Show("El porcentaje no puede ser MAYOR que 100%. Revise las cantidades en EGRESOS.", "Grabar Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgEgresos.CurrentCell = dtgEgresos[1, f];                   
                    return false;
                }
            }
            return true;
        }
        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCamposGrid();
            this.btnGrabar.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = true;
        }

        private void dtgIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox  =   e.Control as TextBox;
            int columnIng   =   dtgIngresos.CurrentCell.ColumnIndex;
            if (columnIng   ==  1 && txtbox != null)
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
        }
        private void dtgEgresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox  =   e.Control as TextBox;
            int columnIng   =   dtgIngresos.CurrentCell.ColumnIndex;
            if (columnIng   ==  1 && txtbox != null)
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);                
        }

        void txtbox_KeyPressNoPermitirDigitar(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
              e.Handled = true;    
            }
        }

        private void dtgIngresos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgIngresos.CurrentCell != null)
            {
                int columnIng = dtgIngresos.CurrentCell.ColumnIndex;
                if (columnIng == 1)
                    dtgIngresos.EndEdit();
            }
        }

        private void dtgEgresos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEgresos.CurrentCell != null)
            {
                int columnIng = dtgEgresos.CurrentCell.ColumnIndex;
                if (columnIng == 1)
                    dtgEgresos.EndEdit();
            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtIngresos = new DataTable("dtIngresos");
            dtEgresos = new DataTable("dtIngresos");
            this.dtgIngresos.DataSource = null;
            this.dtgEgresos.DataSource = null;
            CargarDatos();
            this.btnGrabar.Enabled = false;
        }

        private void frmParamFlujoCajaEvalEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //En caso cierre la ventana cuando se esté editando
            if (dtgIngresos.CurrentCell!=null)
            {
                int columnIng = dtgIngresos.CurrentCell.ColumnIndex;
                if (columnIng == 1)
                    dtgIngresos.EndEdit();
            }

            if (dtgEgresos.CurrentCell != null)
            {
                int columnIng = dtgEgresos.CurrentCell.ColumnIndex;
                if (columnIng == 1)
                    dtgEgresos.EndEdit(); 
            }                       
        }    
    }
}
