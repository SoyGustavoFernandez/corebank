namespace CNT.Presentacion
{
    partial class frmSaldoSuspenso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldoSuspenso));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcDetalle = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(83, 105);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 2;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(151, 105);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(136, 18);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(93, 20);
            this.dtpFecha.TabIndex = 4;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Fecha de Proceso:";
            // 
            // chcDetalle
            // 
            this.chcDetalle.AutoSize = true;
            this.chcDetalle.Location = new System.Drawing.Point(102, 78);
            this.chcDetalle.Name = "chcDetalle";
            this.chcDetalle.Size = new System.Drawing.Size(90, 17);
            this.chcDetalle.TabIndex = 7;
            this.chcDetalle.Text = "Incluir Detalle";
            this.chcDetalle.UseVisualStyleBackColor = true;
            this.chcDetalle.CheckedChanged += new System.EventHandler(this.chcDetalle_CheckedChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(24, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Agencia:";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(136, 44);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(134, 21);
            this.cboAgencia1.TabIndex = 10;
            // 
            // frmSaldoSuspenso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 187);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.chcDetalle);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmSaldoSuspenso";
            this.Text = "Saldo Int. Suspenso";
            this.Load += new System.EventHandler(this.frmSaldoCredito_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.chcDetalle, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcDetalle;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
    }
}