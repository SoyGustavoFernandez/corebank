namespace CNE.Presentacion
{
    partial class frmPDPIngresoValorPatriFide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPIngresoValorPatriFide));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtValorDDI = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtValorGarantia = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtSaldoFide = new GEN.ControlesBase.txtNumerico(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 53);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(126, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Saldo Fideicometido:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(154, 24);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(103, 28);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(201, 137);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(267, 137);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(68, 79);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Valor D.D.I.:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(22, 105);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(126, 13);
            this.lblBase4.TabIndex = 10;
            this.lblBase4.Text = "Valor de la Garantia:";
            // 
            // txtValorDDI
            // 
            this.txtValorDDI.Format = "n2";
            this.txtValorDDI.Location = new System.Drawing.Point(154, 76);
            this.txtValorDDI.Name = "txtValorDDI";
            this.txtValorDDI.Size = new System.Drawing.Size(96, 20);
            this.txtValorDDI.TabIndex = 13;
            this.txtValorDDI.TextChanged += new System.EventHandler(this.txtValorDDI_TextChanged);
            // 
            // txtValorGarantia
            // 
            this.txtValorGarantia.Format = "n2";
            this.txtValorGarantia.Location = new System.Drawing.Point(154, 102);
            this.txtValorGarantia.Name = "txtValorGarantia";
            this.txtValorGarantia.Size = new System.Drawing.Size(96, 20);
            this.txtValorGarantia.TabIndex = 14;
            // 
            // txtSaldoFide
            // 
            this.txtSaldoFide.Format = "n2";
            this.txtSaldoFide.Location = new System.Drawing.Point(154, 50);
            this.txtSaldoFide.Name = "txtSaldoFide";
            this.txtSaldoFide.Size = new System.Drawing.Size(96, 20);
            this.txtSaldoFide.TabIndex = 15;
            // 
            // frmPDPIngresoValorPatriFide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 218);
            this.Controls.Add(this.txtSaldoFide);
            this.Controls.Add(this.txtValorGarantia);
            this.Controls.Add(this.txtValorDDI);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmPDPIngresoValorPatriFide";
            this.Text = "Ingreso de Valores Anexo 32A";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtValorDDI, 0);
            this.Controls.SetChildIndex(this.txtValorGarantia, 0);
            this.Controls.SetChildIndex(this.txtSaldoFide, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumerico txtValorDDI;
        private GEN.ControlesBase.txtNumerico txtValorGarantia;
        private GEN.ControlesBase.txtNumerico txtSaldoFide;
    }
}