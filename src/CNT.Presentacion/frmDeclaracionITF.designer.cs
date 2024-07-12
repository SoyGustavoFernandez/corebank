namespace CNT.Presentacion
{
    partial class frmDeclaracionITF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclaracionITF));
            this.dtpFechaInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnValidar1 = new GEN.BotonesBase.btnValidar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtRUC = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnTransferir1 = new GEN.BotonesBase.btnTransferir();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.cboMeses = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(150, 23);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaInicial.TabIndex = 2;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(150, 49);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(63, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(63, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // btnValidar1
            // 
            this.btnValidar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar1.BackgroundImage")));
            this.btnValidar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar1.Location = new System.Drawing.Point(59, 211);
            this.btnValidar1.Name = "btnValidar1";
            this.btnValidar1.Size = new System.Drawing.Size(60, 50);
            this.btnValidar1.TabIndex = 8;
            this.btnValidar1.Text = "&Validar";
            this.btnValidar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar1.UseVisualStyleBackColor = true;
            this.btnValidar1.Click += new System.EventHandler(this.btnValidar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(195, 211);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtRUC
            // 
            this.txtRUC.Enabled = false;
            this.txtRUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.Location = new System.Drawing.Point(150, 75);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(111, 26);
            this.txtRUC.TabIndex = 10;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(63, 82);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(37, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "RUC:";
            // 
            // btnTransferir1
            // 
            this.btnTransferir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransferir1.BackgroundImage")));
            this.btnTransferir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTransferir1.Location = new System.Drawing.Point(127, 211);
            this.btnTransferir1.Name = "btnTransferir1";
            this.btnTransferir1.Size = new System.Drawing.Size(60, 50);
            this.btnTransferir1.TabIndex = 12;
            this.btnTransferir1.Text = "&Transferir";
            this.btnTransferir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransferir1.UseVisualStyleBackColor = true;
            this.btnTransferir1.Click += new System.EventHandler(this.btnTransferir1_Click);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(48, 22);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(15, 14);
            this.chcBase1.TabIndex = 13;
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // cboMeses
            // 
            this.cboMeses.Enabled = false;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(73, 46);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(120, 21);
            this.cboMeses.TabIndex = 14;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.nudAnio);
            this.grbBase1.Controls.Add(this.cboMeses);
            this.grbBase1.Controls.Add(this.chcBase1);
            this.grbBase1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(58, 120);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(199, 74);
            this.grbBase1.TabIndex = 15;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Declaración Mensual?";
            // 
            // nudAnio
            // 
            this.nudAnio.Enabled = false;
            this.nudAnio.Location = new System.Drawing.Point(73, 20);
            this.nudAnio.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(56, 21);
            this.nudAnio.TabIndex = 16;
            this.nudAnio.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // frmDeclaracionITF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 293);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnTransferir1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtRUC);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnValidar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Name = "frmDeclaracionITF";
            this.Text = "Declaración de ITF";
            this.Load += new System.EventHandler(this.frmDeclaracionITF_Load);
            this.Controls.SetChildIndex(this.dtpFechaInicial, 0);
            this.Controls.SetChildIndex(this.dtpFechaFinal, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnValidar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtRUC, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnTransferir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFechaInicial;
        private GEN.ControlesBase.dtpCorto dtpFechaFinal;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnValidar btnValidar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtRUC;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnTransferir btnTransferir1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.cboBase cboMeses;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.nudBase nudAnio;
    }
}