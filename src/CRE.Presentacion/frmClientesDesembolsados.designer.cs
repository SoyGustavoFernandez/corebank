namespace CRE.Presentacion
{
    partial class frmClientesDesembolsados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesDesembolsados));
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboTipoCliente = new GEN.ControlesBase.cboTipoCliente(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnImpResumen = new GEN.BotonesBase.btnBlanco();
            this.SuspendLayout();
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(114, 42);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(139, 20);
            this.dtpFecIni.TabIndex = 2;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(114, 75);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(139, 20);
            this.dtpFecFin.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(31, 46);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(75, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Fecha Inicio";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(31, 79);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(60, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Fin";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(20, 141);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(224, 141);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Location = new System.Drawing.Point(114, 106);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(139, 21);
            this.cboTipoCliente.TabIndex = 8;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(31, 110);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Tipo Cliente";
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Image = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnBlanco1.Location = new System.Drawing.Point(88, 141);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 10;
            this.btnBlanco1.Text = "&Tot Des";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(114, 8);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(139, 21);
            this.cboAgencia1.TabIndex = 11;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(33, 11);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Agencia";
            // 
            // btnImpResumen
            // 
            this.btnImpResumen.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnImpResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpResumen.Location = new System.Drawing.Point(156, 141);
            this.btnImpResumen.Name = "btnImpResumen";
            this.btnImpResumen.Size = new System.Drawing.Size(60, 50);
            this.btnImpResumen.TabIndex = 13;
            this.btnImpResumen.Text = "&Resumen";
            this.btnImpResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpResumen.UseVisualStyleBackColor = true;
            this.btnImpResumen.Click += new System.EventHandler(this.btnImpResumen_Click);
            // 
            // frmClientesDesembolsados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 224);
            this.Controls.Add(this.btnImpResumen);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.btnBlanco1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipoCliente);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Name = "frmClientesDesembolsados";
            this.Text = "Clientes Desembolsados";
            this.Load += new System.EventHandler(this.frmClientesDesembolsados_Load);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoCliente, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnBlanco1, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnImpResumen, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboTipoCliente cboTipoCliente;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnBlanco btnImpResumen;
    }
}