namespace SPL.Presentacion
{
    partial class frmAdminSplaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminSplaft));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtUmbral = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtFechaUmbral = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaTipoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo2 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar2 = new GEN.BotonesBase.btnGrabar();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 59);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Umbral";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 247);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(94, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo de cambio";
            // 
            // txtUmbral
            // 
            this.txtUmbral.Enabled = false;
            this.txtUmbral.Location = new System.Drawing.Point(111, 56);
            this.txtUmbral.Name = "txtUmbral";
            this.txtUmbral.Size = new System.Drawing.Size(192, 20);
            this.txtUmbral.TabIndex = 4;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Location = new System.Drawing.Point(111, 244);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(192, 20);
            this.txtTipoCambio.TabIndex = 5;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(335, 91);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 6;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(191, 358);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(117, 358);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // txtFechaUmbral
            // 
            this.txtFechaUmbral.Enabled = false;
            this.txtFechaUmbral.Location = new System.Drawing.Point(335, 56);
            this.txtFechaUmbral.Name = "txtFechaUmbral";
            this.txtFechaUmbral.Size = new System.Drawing.Size(144, 20);
            this.txtFechaUmbral.TabIndex = 9;
            // 
            // txtFechaTipoCambio
            // 
            this.txtFechaTipoCambio.Enabled = false;
            this.txtFechaTipoCambio.Location = new System.Drawing.Point(335, 244);
            this.txtFechaTipoCambio.Name = "txtFechaTipoCambio";
            this.txtFechaTipoCambio.Size = new System.Drawing.Size(144, 20);
            this.txtFechaTipoCambio.TabIndex = 10;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Agencia";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(111, 17);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(192, 21);
            this.cboAgencia1.TabIndex = 12;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(419, 91);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 13;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo2
            // 
            this.btnNuevo2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo2.BackgroundImage")));
            this.btnNuevo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo2.Location = new System.Drawing.Point(335, 287);
            this.btnNuevo2.Name = "btnNuevo2";
            this.btnNuevo2.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo2.TabIndex = 14;
            this.btnNuevo2.Text = "&Nuevo";
            this.btnNuevo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo2.UseVisualStyleBackColor = true;
            this.btnNuevo2.Click += new System.EventHandler(this.btnNuevo2_Click);
            // 
            // btnGrabar2
            // 
            this.btnGrabar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar2.BackgroundImage")));
            this.btnGrabar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar2.Enabled = false;
            this.btnGrabar2.Location = new System.Drawing.Point(419, 287);
            this.btnGrabar2.Name = "btnGrabar2";
            this.btnGrabar2.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar2.TabIndex = 15;
            this.btnGrabar2.Text = "&Grabar";
            this.btnGrabar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar2.UseVisualStyleBackColor = true;
            this.btnGrabar2.Click += new System.EventHandler(this.btnGrabar2_Click);
            // 
            // frmAdminSplaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.btnGrabar2);
            this.Controls.Add(this.btnNuevo2);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtFechaTipoCambio);
            this.Controls.Add(this.txtFechaUmbral);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.txtTipoCambio);
            this.Controls.Add(this.txtUmbral);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmAdminSplaft";
            this.Text = "frmAdminSplaft";
            this.Load += new System.EventHandler(this.frmAdminSplaft_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtUmbral, 0);
            this.Controls.SetChildIndex(this.txtTipoCambio, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.txtFechaUmbral, 0);
            this.Controls.SetChildIndex(this.txtFechaTipoCambio, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo2, 0);
            this.Controls.SetChildIndex(this.btnGrabar2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtUmbral;
        private GEN.ControlesBase.txtBase txtTipoCambio;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtBase txtFechaUmbral;
        private GEN.ControlesBase.txtBase txtFechaTipoCambio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo2;
        private GEN.BotonesBase.btnGrabar btnGrabar2;
    }
}