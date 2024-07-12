namespace CLI.Presentacion
{
    partial class frmSoliciDesbloqClienteBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoliciDesbloqClienteBN));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.txtNomRazon = new GEN.ControlesBase.txtBase(this.components);
            this.rbtEsCliente = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtNoEsCliente = new GEN.ControlesBase.rbtBase(this.components);
            this.cboTipoDocumento = new GEN.ControlesBase.cboTipoDocumento(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMotivos = new GEN.ControlesBase.cboMotivos(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMotivoDesbloq = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(527, 265);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(461, 265);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 75);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo Doc.:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 102);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Nro Doc.:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 128);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(127, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Nomb./Razon Social:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(86, 99);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(194, 20);
            this.txtNroDoc.TabIndex = 2;
            // 
            // txtNomRazon
            // 
            this.txtNomRazon.Enabled = false;
            this.txtNomRazon.Location = new System.Drawing.Point(147, 125);
            this.txtNomRazon.Name = "txtNomRazon";
            this.txtNomRazon.Size = new System.Drawing.Size(418, 20);
            this.txtNomRazon.TabIndex = 3;
            // 
            // rbtEsCliente
            // 
            this.rbtEsCliente.AutoSize = true;
            this.rbtEsCliente.Enabled = false;
            this.rbtEsCliente.ForeColor = System.Drawing.Color.Navy;
            this.rbtEsCliente.Location = new System.Drawing.Point(90, 23);
            this.rbtEsCliente.Name = "rbtEsCliente";
            this.rbtEsCliente.Size = new System.Drawing.Size(34, 17);
            this.rbtEsCliente.TabIndex = 16;
            this.rbtEsCliente.TabStop = true;
            this.rbtEsCliente.Text = "Si";
            this.rbtEsCliente.UseVisualStyleBackColor = true;
            // 
            // rbtNoEsCliente
            // 
            this.rbtNoEsCliente.AutoSize = true;
            this.rbtNoEsCliente.Enabled = false;
            this.rbtNoEsCliente.ForeColor = System.Drawing.Color.Navy;
            this.rbtNoEsCliente.Location = new System.Drawing.Point(130, 22);
            this.rbtNoEsCliente.Name = "rbtNoEsCliente";
            this.rbtNoEsCliente.Size = new System.Drawing.Size(39, 17);
            this.rbtNoEsCliente.TabIndex = 17;
            this.rbtNoEsCliente.TabStop = true;
            this.rbtNoEsCliente.Text = "No";
            this.rbtNoEsCliente.UseVisualStyleBackColor = true;
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.Enabled = false;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(86, 72);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(194, 21);
            this.cboTipoDocumento.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboMotivos);
            this.grbBase1.Controls.Add(this.lblBase22);
            this.grbBase1.Controls.Add(this.cboTipoPersona);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtMotivoDesbloq);
            this.grbBase1.Controls.Add(this.cboTipoDocumento);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.rbtNoEsCliente);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.rbtEsCliente);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtNomRazon);
            this.grbBase1.Controls.Add(this.txtNroDoc);
            this.grbBase1.Location = new System.Drawing.Point(12, 5);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(578, 255);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Informacion de Base Negativa";
            // 
            // cboMotivos
            // 
            this.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivos.FormattingEnabled = true;
            this.cboMotivos.Location = new System.Drawing.Point(130, 167);
            this.cboMotivos.Name = "cboMotivos";
            this.cboMotivos.Size = new System.Drawing.Size(261, 21);
            this.cboMotivos.TabIndex = 4;
            this.cboMotivos.MouseHover += new System.EventHandler(this.cboMotivos_MouseHover);
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(3, 170);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(120, 13);
            this.lblBase22.TabIndex = 154;
            this.lblBase22.Text = "Motivo Desbloqueo:";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.Enabled = false;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(86, 45);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(194, 21);
            this.cboTipoPersona.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 48);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(61, 13);
            this.lblBase6.TabIndex = 23;
            this.lblBase6.Text = "Tipo Per.:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.SystemColors.Control;
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Enabled = false;
            this.btnBusqueda.Location = new System.Drawing.Point(505, 17);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 22;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Visible = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(4, 193);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(73, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Descripción";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(70, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Es Cliente?";
            // 
            // txtMotivoDesbloq
            // 
            this.txtMotivoDesbloq.Location = new System.Drawing.Point(130, 194);
            this.txtMotivoDesbloq.Multiline = true;
            this.txtMotivoDesbloq.Name = "txtMotivoDesbloq";
            this.txtMotivoDesbloq.Size = new System.Drawing.Size(435, 54);
            this.txtMotivoDesbloq.TabIndex = 5;
            // 
            // frmSoliciDesbloqClienteBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 342);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmSoliciDesbloqClienteBN";
            this.Text = "Solicitud de Desbloqueo de Cliente en Base Negativa";
            this.Load += new System.EventHandler(this.frmSoliciDesbloqClienteBN_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.txtBase txtNomRazon;
        private GEN.ControlesBase.rbtBase rbtEsCliente;
        private GEN.ControlesBase.rbtBase rbtNoEsCliente;
        private GEN.ControlesBase.cboTipoDocumento cboTipoDocumento;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtMotivoDesbloq;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMotivos cboMotivos;
        private GEN.ControlesBase.lblBase lblBase22;
    }
}