namespace CRE.Presentacion
{
    partial class frmBloquearClienteEAI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloquearClienteEAI));
            this.conBusCliSimp = new GEN.ControlesBase.ConBusCliSimp();
            this.cboMotivoBloq = new GEN.ControlesBase.cboBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSustentoBloq = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBloquear = new GEN.BotonesBase.btnBlanco();
            this.btnDesbloquear = new GEN.BotonesBase.btnBlanco();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSustentoDesbloq = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCliSimp
            // 
            this.conBusCliSimp.BackColor = System.Drawing.Color.Transparent;
            this.conBusCliSimp.idCli = 0;
            this.conBusCliSimp.Location = new System.Drawing.Point(6, 19);
            this.conBusCliSimp.Name = "conBusCliSimp";
            this.conBusCliSimp.Size = new System.Drawing.Size(350, 92);
            this.conBusCliSimp.TabIndex = 2;
            this.conBusCliSimp.EventoPostBuscar += new System.EventHandler(this.conBusCliSimp_EventoPostBuscar);
            // 
            // cboMotivoBloq
            // 
            this.cboMotivoBloq.FormattingEnabled = true;
            this.cboMotivoBloq.Location = new System.Drawing.Point(146, 19);
            this.cboMotivoBloq.Name = "cboMotivoBloq";
            this.cboMotivoBloq.Size = new System.Drawing.Size(209, 21);
            this.cboMotivoBloq.TabIndex = 3;
            this.cboMotivoBloq.SelectedIndexChanged += new System.EventHandler(this.cboMotivoBloq_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(304, 443);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(238, 443);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(121, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Motivo de Bloqueo :";
            // 
            // txtSustentoBloq
            // 
            this.txtSustentoBloq.Location = new System.Drawing.Point(9, 64);
            this.txtSustentoBloq.MaxLength = 1000;
            this.txtSustentoBloq.Multiline = true;
            this.txtSustentoBloq.Name = "txtSustentoBloq";
            this.txtSustentoBloq.Size = new System.Drawing.Size(346, 75);
            this.txtSustentoBloq.TabIndex = 60;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(6, 43);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(142, 13);
            this.lblBase15.TabIndex = 61;
            this.lblBase15.Text = "Sustento / Comentario:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.conBusCliSimp);
            this.grbBase1.Location = new System.Drawing.Point(8, 14);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(366, 130);
            this.grbBase1.TabIndex = 62;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "DATOS DEL CLIENTE";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.txtSustentoBloq);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.cboMotivoBloq);
            this.grbBase2.Location = new System.Drawing.Point(9, 150);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(365, 154);
            this.grbBase2.TabIndex = 63;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "DATOS DEL BLOQUEO";
            // 
            // btnBloquear
            // 
            this.btnBloquear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBloquear.Image = global::CRE.Presentacion.Properties.Resources.Bloq;
            this.btnBloquear.Location = new System.Drawing.Point(172, 443);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(60, 50);
            this.btnBloquear.TabIndex = 64;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDesbloquear.Image = global::CRE.Presentacion.Properties.Resources.Desbloq;
            this.btnDesbloquear.Location = new System.Drawing.Point(106, 443);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(60, 50);
            this.btnDesbloquear.TabIndex = 65;
            this.btnDesbloquear.Text = "Desbloq.";
            this.btnDesbloquear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtSustentoDesbloq);
            this.grbBase3.Location = new System.Drawing.Point(9, 310);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(365, 123);
            this.grbBase3.TabIndex = 66;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "DATOS DE DESBLOQUEO";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 21);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(142, 13);
            this.lblBase2.TabIndex = 62;
            this.lblBase2.Text = "Sustento / Comentario:";
            // 
            // txtSustentoDesbloq
            // 
            this.txtSustentoDesbloq.Location = new System.Drawing.Point(9, 40);
            this.txtSustentoDesbloq.MaxLength = 1000;
            this.txtSustentoDesbloq.Multiline = true;
            this.txtSustentoDesbloq.Name = "txtSustentoDesbloq";
            this.txtSustentoDesbloq.Size = new System.Drawing.Size(346, 75);
            this.txtSustentoDesbloq.TabIndex = 61;
            // 
            // frmBloquearClienteEAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 521);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnBloquear);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmBloquearClienteEAI";
            this.Text = "Bloqueo Manual de Cliente Efectivo al Instante";
            this.Load += new System.EventHandler(this.frmBloquearClienteEAI_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnBloquear, 0);
            this.Controls.SetChildIndex(this.btnDesbloquear, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCliSimp conBusCliSimp;
        private GEN.ControlesBase.cboBase cboMotivoBloq;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtSustentoBloq;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnBlanco btnBloquear;
        private GEN.BotonesBase.btnBlanco btnDesbloquear;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtSustentoDesbloq;
    }
}