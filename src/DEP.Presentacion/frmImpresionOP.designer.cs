namespace DEP.Presentacion
{
    partial class frmImpresionOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionOP));
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgSolOP = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgValorado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnDetalle = new GEN.BotonesBase.btnDetalle();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(330, 33);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 125;
            this.lblBase4.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(389, 29);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(196, 21);
            this.cboMoneda.TabIndex = 123;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 21);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(118, 13);
            this.lblBase2.TabIndex = 124;
            this.lblBase2.Text = "Agencia solicitante:";
            // 
            // dtgSolOP
            // 
            this.dtgSolOP.AllowUserToAddRows = false;
            this.dtgSolOP.AllowUserToDeleteRows = false;
            this.dtgSolOP.AllowUserToResizeColumns = false;
            this.dtgSolOP.AllowUserToResizeRows = false;
            this.dtgSolOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolOP.Location = new System.Drawing.Point(10, 88);
            this.dtgSolOP.MultiSelect = false;
            this.dtgSolOP.Name = "dtgSolOP";
            this.dtgSolOP.ReadOnly = true;
            this.dtgSolOP.RowHeadersVisible = false;
            this.dtgSolOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolOP.Size = new System.Drawing.Size(795, 177);
            this.dtgSolOP.TabIndex = 126;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(586, 51);
            this.grbBase1.TabIndex = 127;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtro";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(126, 17);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(186, 21);
            this.cboAgencias.TabIndex = 130;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(604, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 128;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(10, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(795, 21);
            this.label1.TabIndex = 129;
            this.label1.Text = "Listado de Solicitudes de Ordenes de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgValorado
            // 
            this.dtgValorado.AllowUserToAddRows = false;
            this.dtgValorado.AllowUserToDeleteRows = false;
            this.dtgValorado.AllowUserToResizeColumns = false;
            this.dtgValorado.AllowUserToResizeRows = false;
            this.dtgValorado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValorado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValorado.Location = new System.Drawing.Point(12, 282);
            this.dtgValorado.MultiSelect = false;
            this.dtgValorado.Name = "dtgValorado";
            this.dtgValorado.ReadOnly = true;
            this.dtgValorado.RowHeadersVisible = false;
            this.dtgValorado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValorado.Size = new System.Drawing.Size(587, 246);
            this.dtgValorado.TabIndex = 130;
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle.BackgroundImage")));
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.Enabled = false;
            this.btnDetalle.Location = new System.Drawing.Point(611, 282);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle.TabIndex = 131;
            this.btnDetalle.Text = "&Detallar";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.texto = "&Detallar";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(611, 331);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 132;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(611, 380);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 133;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(611, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 134;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(611, 478);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 135;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmImpresionOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 561);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dtgValorado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.dtgSolOP);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmImpresionOP";
            this.Text = "Impresión de Ordenes de Pago";
            this.Load += new System.EventHandler(this.frmImpresionOP_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtgSolOP, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtgValorado, 0);
            this.Controls.SetChildIndex(this.btnDetalle, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgSolOP;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.cboAgencia cboAgencias;
        private GEN.ControlesBase.dtgBase dtgValorado;
        private GEN.BotonesBase.btnDetalle btnDetalle;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
    }
}