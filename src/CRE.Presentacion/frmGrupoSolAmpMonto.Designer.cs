namespace CRE.Presentacion
{
    partial class frmGrupoSolAmpMonto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolAmpMonto));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.nudMonto = new GEN.ControlesBase.nudBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(54, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Monto:";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMonto.Location = new System.Drawing.Point(106, 46);
            this.nudMonto.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nudMonto.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(138, 20);
            this.nudMonto.TabIndex = 1;
            this.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(50, 77);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(147, 77);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(88, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Saldo Capital:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSaldoCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoCapital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSaldoCapital.Location = new System.Drawing.Point(106, 20);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.ReadOnly = true;
            this.txtSaldoCapital.Size = new System.Drawing.Size(123, 20);
            this.txtSaldoCapital.TabIndex = 5;
            this.txtSaldoCapital.Text = "0.00";
            this.txtSaldoCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmGrupoSolAmpMonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 139);
            this.Controls.Add(this.txtSaldoCapital);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.lblBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGrupoSolAmpMonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmGrupoSolAmpMonto";
            this.Load += new System.EventHandler(this.frmGrupoSolAmpMonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase nudMonto;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtSaldoCapital;
    }
}