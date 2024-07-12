namespace CRE.Presentacion
{
    partial class frmRptHistorialExpediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptHistorialExpediente));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.cboTipoExpediente1 = new GEN.ControlesBase.cboTipoExpediente(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCBEstadoActual = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgHistorialExpe = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorialExpe)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(8, 6);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(539, 113);
            this.conBusCli1.TabIndex = 2;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // cboTipoExpediente1
            // 
            this.cboTipoExpediente1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoExpediente1.Enabled = false;
            this.cboTipoExpediente1.FormattingEnabled = true;
            this.cboTipoExpediente1.Location = new System.Drawing.Point(385, 129);
            this.cboTipoExpediente1.Name = "cboTipoExpediente1";
            this.cboTipoExpediente1.Size = new System.Drawing.Size(162, 21);
            this.cboTipoExpediente1.TabIndex = 4;
            this.cboTipoExpediente1.SelectedValueChanged += new System.EventHandler(this.cboTipoExpediente1_SelectedValueChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 132);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(89, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Estado Actual:";
            // 
            // txtCBEstadoActual
            // 
            this.txtCBEstadoActual.Location = new System.Drawing.Point(98, 129);
            this.txtCBEstadoActual.Name = "txtCBEstadoActual";
            this.txtCBEstadoActual.ReadOnly = true;
            this.txtCBEstadoActual.Size = new System.Drawing.Size(167, 20);
            this.txtCBEstadoActual.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(279, 132);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Tipo Expediente:";
            // 
            // dtgHistorialExpe
            // 
            this.dtgHistorialExpe.AllowUserToAddRows = false;
            this.dtgHistorialExpe.AllowUserToDeleteRows = false;
            this.dtgHistorialExpe.AllowUserToResizeColumns = false;
            this.dtgHistorialExpe.AllowUserToResizeRows = false;
            this.dtgHistorialExpe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHistorialExpe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorialExpe.Location = new System.Drawing.Point(11, 156);
            this.dtgHistorialExpe.MultiSelect = false;
            this.dtgHistorialExpe.Name = "dtgHistorialExpe";
            this.dtgHistorialExpe.ReadOnly = true;
            this.dtgHistorialExpe.RowHeadersVisible = false;
            this.dtgHistorialExpe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistorialExpe.Size = new System.Drawing.Size(536, 207);
            this.dtgHistorialExpe.TabIndex = 7;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(487, 370);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(421, 370);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 9;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(355, 370);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmRptHistorialExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 454);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgHistorialExpe);
            this.Controls.Add(this.txtCBEstadoActual);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoExpediente1);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmRptHistorialExpediente";
            this.Text = "Reporte historial de expedientes";
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.cboTipoExpediente1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtCBEstadoActual, 0);
            this.Controls.SetChildIndex(this.dtgHistorialExpe, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorialExpe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.cboTipoExpediente cboTipoExpediente1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBLetra txtCBEstadoActual;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgHistorialExpe;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}