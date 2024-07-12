namespace CRE.Presentacion
{
    partial class frmSIGSaldoProvTraMora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSIGSaldoProvTraMora));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtRpt3 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtRpt2 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtRpt1 = new GEN.ControlesBase.rbtBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.cboCalificacion1 = new GEN.ControlesBase.cboCalificacion(this.components);
            this.lblCalificacion = new GEN.ControlesBase.lblBase();
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(236, 245);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(170, 245);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(104, 245);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 6;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(4, 6);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(329, 25);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "SISTEMA DE INFORMACIÓN GERENCIAL";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 167);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(96, 163);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(209, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtRpt3);
            this.grbBase1.Controls.Add(this.rbtRpt2);
            this.grbBase1.Controls.Add(this.rbtRpt1);
            this.grbBase1.Location = new System.Drawing.Point(13, 38);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(320, 92);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione reporte";
            // 
            // rbtRpt3
            // 
            this.rbtRpt3.AutoSize = true;
            this.rbtRpt3.ForeColor = System.Drawing.Color.Navy;
            this.rbtRpt3.Location = new System.Drawing.Point(6, 65);
            this.rbtRpt3.Name = "rbtRpt3";
            this.rbtRpt3.Size = new System.Drawing.Size(161, 17);
            this.rbtRpt3.TabIndex = 2;
            this.rbtRpt3.Text = "SIG - 003 Tramos por Liberar";
            this.rbtRpt3.UseVisualStyleBackColor = true;
            this.rbtRpt3.CheckedChanged += new System.EventHandler(this.rbtCarteraPotencial_CheckedChanged);
            // 
            // rbtRpt2
            // 
            this.rbtRpt2.AutoSize = true;
            this.rbtRpt2.ForeColor = System.Drawing.Color.Navy;
            this.rbtRpt2.Location = new System.Drawing.Point(6, 42);
            this.rbtRpt2.Name = "rbtRpt2";
            this.rbtRpt2.Size = new System.Drawing.Size(127, 17);
            this.rbtRpt2.TabIndex = 1;
            this.rbtRpt2.Text = "SIG - 002 Provisiones";
            this.rbtRpt2.UseVisualStyleBackColor = true;
            this.rbtRpt2.CheckedChanged += new System.EventHandler(this.rbtProducto_CheckedChanged);
            // 
            // rbtRpt1
            // 
            this.rbtRpt1.AutoSize = true;
            this.rbtRpt1.Checked = true;
            this.rbtRpt1.ForeColor = System.Drawing.Color.Navy;
            this.rbtRpt1.Location = new System.Drawing.Point(6, 19);
            this.rbtRpt1.Name = "rbtRpt1";
            this.rbtRpt1.Size = new System.Drawing.Size(238, 17);
            this.rbtRpt1.TabIndex = 0;
            this.rbtRpt1.TabStop = true;
            this.rbtRpt1.Text = "SIG - 001 Saldo, Cartera, Mora y Nro Clientes";
            this.rbtRpt1.UseVisualStyleBackColor = true;
            this.rbtRpt1.CheckedChanged += new System.EventHandler(this.rbtOficina_CheckedChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(96, 136);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(209, 21);
            this.cboAgencias1.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 139);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Agencia:";
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(96, 216);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(109, 17);
            this.chcBase1.TabIndex = 9;
            this.chcBase1.Text = "¿Reporte Online?";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // cboCalificacion1
            // 
            this.cboCalificacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalificacion1.FormattingEnabled = true;
            this.cboCalificacion1.Location = new System.Drawing.Point(96, 189);
            this.cboCalificacion1.Name = "cboCalificacion1";
            this.cboCalificacion1.Size = new System.Drawing.Size(209, 21);
            this.cboCalificacion1.TabIndex = 10;
            // 
            // lblCalificacion
            // 
            this.lblCalificacion.AutoSize = true;
            this.lblCalificacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalificacion.ForeColor = System.Drawing.Color.Navy;
            this.lblCalificacion.Location = new System.Drawing.Point(16, 192);
            this.lblCalificacion.Name = "lblCalificacion";
            this.lblCalificacion.Size = new System.Drawing.Size(77, 13);
            this.lblCalificacion.TabIndex = 2;
            this.lblCalificacion.Text = "Calificación:";
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(38, 245);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 11;
            this.btnImprimir2.Text = "Detallado";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // frmSIGSaldoProvTraMora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 323);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.cboCalificacion1);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblCalificacion);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmSIGSaldoProvTraMora";
            this.Text = "Sistema de Información Gerencial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSIGSaldoProvTraMora_FormClosing);
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCalificacion, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.cboCalificacion1, 0);
            this.Controls.SetChildIndex(this.btnImprimir2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtRpt3;
        private GEN.ControlesBase.rbtBase rbtRpt2;
        private GEN.ControlesBase.rbtBase rbtRpt1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.cboCalificacion cboCalificacion1;
        private GEN.ControlesBase.lblBase lblCalificacion;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
    }
}

