﻿using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCopiarEval : frmBase
    {
        private clsEvalCred objEvalCred;
        private List<clsEvalCredito> listEvaluaciones;
        private clsCNEvaluacion clsCNEvaluacion;
        private string cMsjCaptionForm;

        public bool lEjecutado;

        public frmCopiarEval()
        {
            InitializeComponent();

            this.conBusCli.BorderStyle = BorderStyle.None;
            this.lEjecutado = false;
            this.clsCNEvaluacion = new clsCNEvaluacion();
            this.cMsjCaptionForm = "Copiado de Evaluación";
        }

        public frmCopiarEval(clsEvalCred _objEvalCred, string cTituloForm = "frmNuevaEvPyme")
        {
            InitializeComponent();

            this.conBusCli.BorderStyle = BorderStyle.None;
            this.lEjecutado = false;
            this.clsCNEvaluacion = new clsCNEvaluacion();
            this.cMsjCaptionForm = "Copiado de Evaluación";

            if (_objEvalCred != null)
            {
                this.objEvalCred = _objEvalCred;

                conBusCli.CargardatosCli(this.objEvalCred.idCli);
                conBusCli.Enabled = false;
            }
        }

        #region Métodos Privados
        private void formatearDataGridView()
        {
            this.dtgEvalCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgEvalCreditos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvalCreditos.MultiSelect = false;
            this.dtgEvalCreditos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvalCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvalCreditos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvalCreditos.RowHeadersVisible = false;
            this.dtgEvalCreditos.ReadOnly = true;
        }

        private void formatearColumnasDGV()
        {
            foreach (DataGridViewColumn column in this.dtgEvalCreditos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgEvalCreditos.Columns["cEstado"].DisplayIndex = 1;
            dtgEvalCreditos.Columns["idSolicitud"].DisplayIndex = 2;
            dtgEvalCreditos.Columns["idEvalCred"].DisplayIndex = 3;
            dtgEvalCreditos.Columns["cProducto"].DisplayIndex = 4;
            dtgEvalCreditos.Columns["cMoneda"].DisplayIndex = 5;
            dtgEvalCreditos.Columns["nCapitalPropuesto"].DisplayIndex = 6;
            dtgEvalCreditos.Columns["cModalidadCredito"].DisplayIndex = 7;
            dtgEvalCreditos.Columns["cTipEvalCred"].DisplayIndex = 8;

            dtgEvalCreditos.Columns["idSolicitud"].Visible = true;
            dtgEvalCreditos.Columns["idEvalCred"].Visible = true;
            dtgEvalCreditos.Columns["cMoneda"].Visible = true;
            dtgEvalCreditos.Columns["nCapitalPropuesto"].Visible = true;
            dtgEvalCreditos.Columns["cModalidadCredito"].Visible = true;
            dtgEvalCreditos.Columns["cTipEvalCred"].Visible = true;
            dtgEvalCreditos.Columns["cProducto"].Visible = true;
            dtgEvalCreditos.Columns["cEstado"].Visible = true;

            dtgEvalCreditos.Columns["idSolicitud"].HeaderText = "Solicitud";
            dtgEvalCreditos.Columns["idEvalCred"].HeaderText = "Evaluación";
            dtgEvalCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgEvalCreditos.Columns["nCapitalPropuesto"].HeaderText = "Monto Sol./Aprob.";
            dtgEvalCreditos.Columns["cModalidadCredito"].HeaderText = "Modalidad";
            dtgEvalCreditos.Columns["cTipEvalCred"].HeaderText = "Tipo de Evaluación";
            dtgEvalCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgEvalCreditos.Columns["cEstado"].HeaderText = "Estado";

            dtgEvalCreditos.Columns["cEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgEvalCreditos.Columns["nCapitalPropuesto"].DefaultCellStyle.Format = "n2";
        }

        private void frmCopiarEval_Load(object sender, EventArgs e)
        {
            if (this.objEvalCred != null)
            {
                this.chcSoloAprob.CheckedChanged -= new System.EventHandler(this.chcSoloAprob_CheckedChanged);
                this.dtgEvalCreditos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEvalCreditos_DataBindingComplete);

                // Recuperamos Datos
                DataTable dt = this.clsCNEvaluacion.ListaEvalPorClienteMonedaTipoEval(
                    this.objEvalCred.idCli, this.objEvalCred.idTipEvalCred, this.objEvalCred.idMoneda, this.objEvalCred.idEvalCred);

                this.listEvaluaciones = DataTableToList.ConvertTo<clsEvalCredito>(dt) as List<clsEvalCredito>;

                if (this.listEvaluaciones.Count > 0)
                {
                    // Mostramos en el grid
                    var lista = from p in this.listEvaluaciones
                                select p;

                    this.bindingEvalCreditos.DataSource = lista;
                    this.dtgEvalCreditos.DataSource = this.bindingEvalCreditos;
                    formatearDataGridView();
                    formatearColumnasDGV();

                    this.dtgEvalCreditos.Focus();

                    this.dtgEvalCreditos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEvalCreditos_DataBindingComplete);
                    this.chcSoloAprob.CheckedChanged += new System.EventHandler(this.chcSoloAprob_CheckedChanged);

                    chcSoloAprob_CheckedChanged(this.chcSoloAprob, new EventArgs());
                }
            }
            else
            {
                this.listEvaluaciones = new List<clsEvalCredito>();
            }
        }

        public void limpiarForm()
        {
            this.conBusCli.limpiarControles();
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();
        }
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarForm();
            //Habilitar(false);
        }

        private void chcSoloAprob_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSoloAprob.CheckState == CheckState.Checked)
            {
                var lista = from p in this.listEvaluaciones
                            where p.idEstado.In(2, 5)
                            select p;

                this.bindingEvalCreditos.DataSource = lista;
                formatearColumnasDGV();
            }
            else
            {
                var lista = from p in this.listEvaluaciones
                            select p;

                this.bindingEvalCreditos.DataSource = lista;
                formatearColumnasDGV();
            }
        }

        private void dtgEvalCreditos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int idEstado = 0;
            foreach (DataGridViewRow row in this.dtgEvalCreditos.Rows)
            {
                idEstado = Convert.ToInt32(row.Cells["idEstado"].Value);

                if (idEstado.In(2, 5))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                }
            }

            this.dtgEvalCreditos.ClearSelection();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgEvalCreditos.Enabled == false ||
                this.dtgEvalCreditos.SelectedRows.Count == 0 ||
                this.dtgEvalCreditos.CurrentRow == null) return;

            int rowIndex = this.dtgEvalCreditos.CurrentRow.Index;

            string cMensaje = @"No se copiarán los siguientes:

  - Evaluación cualitativa.
  - Deudas financieras.
  - Destino del crédito.
  - Ciclo de ventas y variaciones.

Por lo que deberá ingresar de forma manual.";

            DialogResult dr = MessageBox.Show(cMensaje, this.cMsjCaptionForm, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                DataTable dt = this.clsCNEvaluacion.CopiarEvalucionCredito(this.objEvalCred.idEvalCred, this.listEvaluaciones[rowIndex].idEvalCred);

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
                    {
                        this.lEjecutado = true;
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), this.cMsjCaptionForm, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), this.cMsjCaptionForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion
    }
}