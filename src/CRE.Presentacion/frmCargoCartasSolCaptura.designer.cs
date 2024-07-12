namespace CRE.Presentacion
{
    partial class frmCargoCartasSolCaptura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoCartasSolCaptura));
            this.dtgCreditosAprobados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbDatosCliente = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodCliente = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombreCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcImprimirConCargo = new GEN.ControlesBase.chcBase(this.components);
            this.dtgDocsSustentatorios = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAprobados)).BeginInit();
            this.grbDatosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocsSustentatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCreditosAprobados
            // 
            this.dtgCreditosAprobados.AllowUserToAddRows = false;
            this.dtgCreditosAprobados.AllowUserToDeleteRows = false;
            this.dtgCreditosAprobados.AllowUserToResizeColumns = false;
            this.dtgCreditosAprobados.AllowUserToResizeRows = false;
            this.dtgCreditosAprobados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosAprobados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosAprobados.Location = new System.Drawing.Point(6, 113);
            this.dtgCreditosAprobados.MultiSelect = false;
            this.dtgCreditosAprobados.Name = "dtgCreditosAprobados";
            this.dtgCreditosAprobados.ReadOnly = true;
            this.dtgCreditosAprobados.RowHeadersVisible = false;
            this.dtgCreditosAprobados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosAprobados.Size = new System.Drawing.Size(195, 111);
            this.dtgCreditosAprobados.TabIndex = 23;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(280, 230);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 25;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // grbDatosCliente
            // 
            this.grbDatosCliente.Controls.Add(this.txtCodCliente);
            this.grbDatosCliente.Controls.Add(this.txtNombreCli);
            this.grbDatosCliente.Controls.Add(this.txtNumDoc);
            this.grbDatosCliente.Controls.Add(this.lblBase3);
            this.grbDatosCliente.Controls.Add(this.lblBase2);
            this.grbDatosCliente.Controls.Add(this.lblBase1);
            this.grbDatosCliente.Location = new System.Drawing.Point(7, 6);
            this.grbDatosCliente.Name = "grbDatosCliente";
            this.grbDatosCliente.Size = new System.Drawing.Size(407, 85);
            this.grbDatosCliente.TabIndex = 26;
            this.grbDatosCliente.TabStop = false;
            this.grbDatosCliente.Text = "Datos del cliente:";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.Location = new System.Drawing.Point(152, 10);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(176, 20);
            this.txtCodCliente.TabIndex = 16;
            // 
            // txtNombreCli
            // 
            this.txtNombreCli.Enabled = false;
            this.txtNombreCli.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNombreCli.Location = new System.Drawing.Point(152, 56);
            this.txtNombreCli.Name = "txtNombreCli";
            this.txtNombreCli.Size = new System.Drawing.Size(247, 20);
            this.txtNombreCli.TabIndex = 21;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNumDoc.Location = new System.Drawing.Point(152, 33);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(176, 20);
            this.txtNumDoc.TabIndex = 17;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 61);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(145, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Nombre o Razón Social:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 36);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(123, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Nro. de Documento:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(114, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Código del cliente:";
            // 
            // chcImprimirConCargo
            // 
            this.chcImprimirConCargo.AutoSize = true;
            this.chcImprimirConCargo.Location = new System.Drawing.Point(7, 230);
            this.chcImprimirConCargo.Name = "chcImprimirConCargo";
            this.chcImprimirConCargo.Size = new System.Drawing.Size(112, 17);
            this.chcImprimirConCargo.TabIndex = 27;
            this.chcImprimirConCargo.Text = "Imprimir con cargo";
            this.chcImprimirConCargo.UseVisualStyleBackColor = true;
            // 
            // dtgDocsSustentatorios
            // 
            this.dtgDocsSustentatorios.AllowUserToAddRows = false;
            this.dtgDocsSustentatorios.AllowUserToDeleteRows = false;
            this.dtgDocsSustentatorios.AllowUserToResizeColumns = false;
            this.dtgDocsSustentatorios.AllowUserToResizeRows = false;
            this.dtgDocsSustentatorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocsSustentatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocsSustentatorios.Location = new System.Drawing.Point(254, 113);
            this.dtgDocsSustentatorios.MultiSelect = false;
            this.dtgDocsSustentatorios.Name = "dtgDocsSustentatorios";
            this.dtgDocsSustentatorios.ReadOnly = true;
            this.dtgDocsSustentatorios.RowHeadersVisible = false;
            this.dtgDocsSustentatorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocsSustentatorios.Size = new System.Drawing.Size(152, 111);
            this.dtgDocsSustentatorios.TabIndex = 28;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(4, 97);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(59, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Cuentas:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(251, 97);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(83, 13);
            this.lblBase5.TabIndex = 29;
            this.lblBase5.Text = "Documentos:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(346, 230);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 30;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmCargoCartasSolCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 306);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgDocsSustentatorios);
            this.Controls.Add(this.chcImprimirConCargo);
            this.Controls.Add(this.grbDatosCliente);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.dtgCreditosAprobados);
            this.Name = "frmCargoCartasSolCaptura";
            this.Text = "Cargo Cartas Solicitud Captura";
            this.Load += new System.EventHandler(this.frmCargoCartasSolCaptura_Load);
            this.Controls.SetChildIndex(this.dtgCreditosAprobados, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbDatosCliente, 0);
            this.Controls.SetChildIndex(this.chcImprimirConCargo, 0);
            this.Controls.SetChildIndex(this.dtgDocsSustentatorios, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAprobados)).EndInit();
            this.grbDatosCliente.ResumeLayout(false);
            this.grbDatosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocsSustentatorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCreditosAprobados;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbDatosCliente;
        private GEN.ControlesBase.chcBase chcImprimirConCargo;
        private GEN.ControlesBase.dtgBase dtgDocsSustentatorios;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCliente;
        private GEN.ControlesBase.txtBase txtNombreCli;
        private GEN.ControlesBase.txtBase txtNumDoc;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir1;

    }
}