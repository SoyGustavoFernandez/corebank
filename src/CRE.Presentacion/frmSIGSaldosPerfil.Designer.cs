namespace CRE.Presentacion
{
    partial class frmSIGSaldosPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSIGSaldosPerfil));
            this.cboPersonalCreditosJefeOficina = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblAsesor = new GEN.ControlesBase.lblBase();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblZona = new GEN.ControlesBase.lblBase();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.SuspendLayout();
            // 
            // cboPersonalCreditosJefeOficina
            // 
            this.cboPersonalCreditosJefeOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCreditosJefeOficina.FormattingEnabled = true;
            this.cboPersonalCreditosJefeOficina.Location = new System.Drawing.Point(82, 115);
            this.cboPersonalCreditosJefeOficina.Name = "cboPersonalCreditosJefeOficina";
            this.cboPersonalCreditosJefeOficina.Size = new System.Drawing.Size(197, 21);
            this.cboPersonalCreditosJefeOficina.TabIndex = 63;
            // 
            // lblAsesor
            // 
            this.lblAsesor.AutoSize = true;
            this.lblAsesor.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAsesor.ForeColor = System.Drawing.Color.Navy;
            this.lblAsesor.Location = new System.Drawing.Point(22, 122);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(51, 13);
            this.lblAsesor.TabIndex = 62;
            this.lblAsesor.Text = "Asesor:";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(82, 88);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(197, 21);
            this.cboAgencias1.TabIndex = 61;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 96);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 60;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblZona.ForeColor = System.Drawing.Color.Navy;
            this.lblZona.Location = new System.Drawing.Point(32, 69);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(41, 13);
            this.lblZona.TabIndex = 59;
            this.lblZona.Text = "Zona:";
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(82, 62);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(197, 21);
            this.cboZona1.TabIndex = 58;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 42);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 64;
            this.lblBase1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(82, 36);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(197, 20);
            this.dtpFecha.TabIndex = 65;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(82, 142);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 66;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(148, 142);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 68;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(7, 5);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(278, 28);
            this.lblBaseCustom1.TabIndex = 69;
            this.lblBaseCustom1.Text = "REPORTE SIG SALDOS PERFIL";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSIGSaldosPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 219);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cboPersonalCreditosJefeOficina);
            this.Controls.Add(this.lblAsesor);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.cboZona1);
            this.Name = "frmSIGSaldosPerfil";
            this.Text = "Reporte SIG Saldos Perfil";
            this.Load += new System.EventHandler(this.frmSIGSaldosPerfil_Load);
            this.Controls.SetChildIndex(this.cboZona1, 0);
            this.Controls.SetChildIndex(this.lblZona, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.lblAsesor, 0);
            this.Controls.SetChildIndex(this.cboPersonalCreditosJefeOficina, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditosJefeOficina;
        private GEN.ControlesBase.lblBase lblAsesor;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblZona;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
    }
}