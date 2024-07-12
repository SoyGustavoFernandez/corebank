namespace CRE.Presentacion
{
    partial class frmConsultaSeguroOncologico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaSeguroOncologico));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboSiniestro = new System.Windows.Forms.ComboBox();
            this.txtEstablecimiento = new System.Windows.Forms.TextBox();
            this.tmpFinCobertura = new GEN.ControlesBase.TimerPicker();
            this.tmpIniCobertura = new GEN.ControlesBase.TimerPicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(534, 105);
            this.conBusCli.TabIndex = 2;
            this.conBusCli.ChangeDocumentoID += new System.EventHandler(this.conBusCli_ChangeDocumentoID);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.cboSiniestro);
            this.groupBox1.Controls.Add(this.txtEstablecimiento);
            this.groupBox1.Controls.Add(this.tmpFinCobertura);
            this.groupBox1.Controls.Add(this.tmpIniCobertura);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 202);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Seguro Oncológico";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(402, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(468, 146);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboSiniestro
            // 
            this.cboSiniestro.FormattingEnabled = true;
            this.cboSiniestro.Location = new System.Drawing.Point(153, 104);
            this.cboSiniestro.Name = "cboSiniestro";
            this.cboSiniestro.Size = new System.Drawing.Size(375, 21);
            this.cboSiniestro.TabIndex = 7;
            // 
            // txtEstablecimiento
            // 
            this.txtEstablecimiento.Location = new System.Drawing.Point(153, 74);
            this.txtEstablecimiento.Name = "txtEstablecimiento";
            this.txtEstablecimiento.Size = new System.Drawing.Size(375, 20);
            this.txtEstablecimiento.TabIndex = 6;
            // 
            // tmpFinCobertura
            // 
            this.tmpFinCobertura.Location = new System.Drawing.Point(153, 44);
            this.tmpFinCobertura.Name = "tmpFinCobertura";
            this.tmpFinCobertura.Size = new System.Drawing.Size(375, 20);
            this.tmpFinCobertura.TabIndex = 5;
            this.tmpFinCobertura.Value = new System.DateTime(2023, 12, 12, 15, 30, 34, 902);
            // 
            // tmpIniCobertura
            // 
            this.tmpIniCobertura.Location = new System.Drawing.Point(153, 14);
            this.tmpIniCobertura.Name = "tmpIniCobertura";
            this.tmpIniCobertura.Size = new System.Drawing.Size(375, 20);
            this.tmpIniCobertura.TabIndex = 4;
            this.tmpIniCobertura.Value = new System.DateTime(2023, 12, 12, 15, 30, 28, 146);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "¿Registrado como Siniestro?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Establecimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin Cobertura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio Cobertura:";
            // 
            // frmConsultaSeguroOncologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 364);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmConsultaSeguroOncologico";
            this.Text = "Consulta de Seguro Oncológico";
            this.Load += new System.EventHandler(this.frmConsultaSeguroOncologico_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.ComboBox cboSiniestro;
        private System.Windows.Forms.TextBox txtEstablecimiento;
        private GEN.ControlesBase.TimerPicker tmpFinCobertura;
        private GEN.ControlesBase.TimerPicker tmpIniCobertura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}