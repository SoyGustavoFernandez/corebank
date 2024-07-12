namespace CRE.Presentacion
{
    partial class FrmPosConDetCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosConDetCliente));
            this.tbcDatosCredito = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.conDatosReprogramacion = new GEN.ControlesBase.conDatosReprogramacion();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtGestorRecuperaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtFechaDesembolso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoDesembolsado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtExpediente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtAsesor = new GEN.ControlesBase.txtBase(this.components);
            this.dtgIntervinientes = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgPlanPagos = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgPagoKardex = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtgGastosPendientes = new GEN.ControlesBase.dtgBase(this.components);
            this.tbcDatosCredito.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoKardex)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcDatosCredito
            // 
            this.tbcDatosCredito.Controls.Add(this.tabPage1);
            this.tbcDatosCredito.Controls.Add(this.tabPage2);
            this.tbcDatosCredito.Controls.Add(this.tabPage3);
            this.tbcDatosCredito.Controls.Add(this.tabPage4);
            this.tbcDatosCredito.Location = new System.Drawing.Point(24, 28);
            this.tbcDatosCredito.Name = "tbcDatosCredito";
            this.tbcDatosCredito.SelectedIndex = 0;
            this.tbcDatosCredito.Size = new System.Drawing.Size(842, 226);
            this.tbcDatosCredito.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.conDatosReprogramacion);
            this.tabPage1.Controls.Add(this.lblBase11);
            this.tabPage1.Controls.Add(this.txtGestorRecuperaciones);
            this.tabPage1.Controls.Add(this.lblBase9);
            this.tabPage1.Controls.Add(this.txtMoneda);
            this.tabPage1.Controls.Add(this.lblBase7);
            this.tabPage1.Controls.Add(this.lblBase6);
            this.tabPage1.Controls.Add(this.txtCuenta);
            this.tabPage1.Controls.Add(this.lblBase5);
            this.tabPage1.Controls.Add(this.txtEstado);
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.txtFechaDesembolso);
            this.tabPage1.Controls.Add(this.lblBase3);
            this.tabPage1.Controls.Add(this.txtMontoDesembolsado);
            this.tabPage1.Controls.Add(this.lblBase2);
            this.tabPage1.Controls.Add(this.txtExpediente);
            this.tabPage1.Controls.Add(this.lblBase1);
            this.tabPage1.Controls.Add(this.txtAsesor);
            this.tabPage1.Controls.Add(this.dtgIntervinientes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(834, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos del Crédito";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // conDatosReprogramacion
            // 
            this.conDatosReprogramacion.idCuenta = 0;
            this.conDatosReprogramacion.lAlerta = false;
            this.conDatosReprogramacion.lMostrarMontoCuota = false;
            this.conDatosReprogramacion.Location = new System.Drawing.Point(321, 6);
            this.conDatosReprogramacion.Margin = new System.Windows.Forms.Padding(0);
            this.conDatosReprogramacion.Name = "conDatosReprogramacion";
            this.conDatosReprogramacion.Size = new System.Drawing.Size(337, 35);
            this.conDatosReprogramacion.TabIndex = 18;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(5, 177);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(50, 13);
            this.lblBase11.TabIndex = 16;
            this.lblBase11.Text = "Gestor:";
            // 
            // txtGestorRecuperaciones
            // 
            this.txtGestorRecuperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGestorRecuperaciones.Location = new System.Drawing.Point(62, 174);
            this.txtGestorRecuperaciones.Name = "txtGestorRecuperaciones";
            this.txtGestorRecuperaciones.ReadOnly = true;
            this.txtGestorRecuperaciones.Size = new System.Drawing.Size(252, 20);
            this.txtGestorRecuperaciones.TabIndex = 17;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 129);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(56, 13);
            this.lblBase9.TabIndex = 15;
            this.lblBase9.Text = "Moneda:";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(173, 126);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(142, 20);
            this.txtMoneda.TabIndex = 14;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(318, 49);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(91, 13);
            this.lblBase7.TabIndex = 13;
            this.lblBase7.Text = "Intervinientes:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(89, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "N° de Cuenta:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(173, 6);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(142, 20);
            this.txtCuenta.TabIndex = 0;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 105);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(117, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Estado del Crédito:";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(173, 102);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(142, 20);
            this.txtEstado.TabIndex = 4;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 81);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(137, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Fecha de Desembolso:";
            // 
            // txtFechaDesembolso
            // 
            this.txtFechaDesembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaDesembolso.Location = new System.Drawing.Point(173, 78);
            this.txtFechaDesembolso.Name = "txtFechaDesembolso";
            this.txtFechaDesembolso.ReadOnly = true;
            this.txtFechaDesembolso.Size = new System.Drawing.Size(142, 20);
            this.txtFechaDesembolso.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(134, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Monto Desembolsado:";
            // 
            // txtMontoDesembolsado
            // 
            this.txtMontoDesembolsado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDesembolsado.Location = new System.Drawing.Point(173, 54);
            this.txtMontoDesembolsado.Name = "txtMontoDesembolsado";
            this.txtMontoDesembolsado.ReadOnly = true;
            this.txtMontoDesembolsado.Size = new System.Drawing.Size(142, 20);
            this.txtMontoDesembolsado.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 33);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(125, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Expediente Anterior:";
            // 
            // txtExpediente
            // 
            this.txtExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpediente.Location = new System.Drawing.Point(173, 30);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.ReadOnly = true;
            this.txtExpediente.Size = new System.Drawing.Size(142, 20);
            this.txtExpediente.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 153);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Asesor:";
            // 
            // txtAsesor
            // 
            this.txtAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsesor.Location = new System.Drawing.Point(63, 150);
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.ReadOnly = true;
            this.txtAsesor.Size = new System.Drawing.Size(252, 20);
            this.txtAsesor.TabIndex = 5;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(321, 65);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(485, 126);
            this.dtgIntervinientes.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgPlanPagos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(834, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plan de Pagos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgPlanPagos
            // 
            this.dtgPlanPagos.AllowUserToAddRows = false;
            this.dtgPlanPagos.AllowUserToDeleteRows = false;
            this.dtgPlanPagos.AllowUserToResizeColumns = false;
            this.dtgPlanPagos.AllowUserToResizeRows = false;
            this.dtgPlanPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPlanPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanPagos.Location = new System.Drawing.Point(3, 3);
            this.dtgPlanPagos.MultiSelect = false;
            this.dtgPlanPagos.Name = "dtgPlanPagos";
            this.dtgPlanPagos.ReadOnly = true;
            this.dtgPlanPagos.RowHeadersVisible = false;
            this.dtgPlanPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanPagos.Size = new System.Drawing.Size(825, 191);
            this.dtgPlanPagos.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgPagoKardex);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(834, 200);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kardex de Pago";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgPagoKardex
            // 
            this.dtgPagoKardex.AllowUserToAddRows = false;
            this.dtgPagoKardex.AllowUserToDeleteRows = false;
            this.dtgPagoKardex.AllowUserToResizeColumns = false;
            this.dtgPagoKardex.AllowUserToResizeRows = false;
            this.dtgPagoKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPagoKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagoKardex.Location = new System.Drawing.Point(3, 0);
            this.dtgPagoKardex.MultiSelect = false;
            this.dtgPagoKardex.Name = "dtgPagoKardex";
            this.dtgPagoKardex.ReadOnly = true;
            this.dtgPagoKardex.RowHeadersVisible = false;
            this.dtgPagoKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPagoKardex.Size = new System.Drawing.Size(825, 191);
            this.dtgPagoKardex.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtgGastosPendientes);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(834, 200);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Gastos pendientes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtgGastosPendientes
            // 
            this.dtgGastosPendientes.AllowUserToAddRows = false;
            this.dtgGastosPendientes.AllowUserToDeleteRows = false;
            this.dtgGastosPendientes.AllowUserToResizeColumns = false;
            this.dtgGastosPendientes.AllowUserToResizeRows = false;
            this.dtgGastosPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgGastosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGastosPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGastosPendientes.Location = new System.Drawing.Point(3, 3);
            this.dtgGastosPendientes.MultiSelect = false;
            this.dtgGastosPendientes.Name = "dtgGastosPendientes";
            this.dtgGastosPendientes.ReadOnly = true;
            this.dtgGastosPendientes.RowHeadersVisible = false;
            this.dtgGastosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGastosPendientes.Size = new System.Drawing.Size(828, 194);
            this.dtgGastosPendientes.TabIndex = 0;
            // 
            // FrmPosConDetCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 295);
            this.Controls.Add(this.tbcDatosCredito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPosConDetCliente";
            this.Text = "Detalle Posicion Consolidada CLiente";
            this.Load += new System.EventHandler(this.FrmPosConDetCliente_Load);
            this.Controls.SetChildIndex(this.tbcDatosCredito, 0);
            this.tbcDatosCredito.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoKardex)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcDatosCredito;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.conDatosReprogramacion conDatosReprogramacion;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtGestorRecuperaciones;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtFechaDesembolso;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtMontoDesembolsado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtExpediente;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtAsesor;
        private GEN.ControlesBase.dtgBase dtgIntervinientes;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.dtgBase dtgPlanPagos;
        private System.Windows.Forms.TabPage tabPage3;
        private GEN.ControlesBase.dtgBase dtgPagoKardex;
        private System.Windows.Forms.TabPage tabPage4;
        private GEN.ControlesBase.dtgBase dtgGastosPendientes;
    }
}