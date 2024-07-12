namespace CRE.Presentacion
{
    partial class frmRegDocExpediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegDocExpediente));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.rtbDescripDoc = new System.Windows.Forms.RichTextBox();
            this.cboTipoFolioExpediente1 = new GEN.ControlesBase.cboTipoFolioExpediente(this.components);
            this.cboCondicionExp1 = new GEN.ControlesBase.cboCondicionExp(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoDocumento = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoExpediente = new GEN.ControlesBase.cboTipoExpediente(this.components);
            this.cboDocumentosExpedientePadre = new GEN.ControlesBase.cboBase(this.components);
            this.cboDocumentosExpediente = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.nudNroFolios = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroFolios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(500, 293);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 86);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(96, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Observaciones:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(434, 293);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(368, 293);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 2;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Cond. documento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 52);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(82, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Tipo de folio:";
            // 
            // rtbDescripDoc
            // 
            this.rtbDescripDoc.AccessibleDescription = "";
            this.rtbDescripDoc.Location = new System.Drawing.Point(13, 103);
            this.rtbDescripDoc.Name = "rtbDescripDoc";
            this.rtbDescripDoc.Size = new System.Drawing.Size(539, 63);
            this.rtbDescripDoc.TabIndex = 0;
            this.rtbDescripDoc.Text = "";
            // 
            // cboTipoFolioExpediente1
            // 
            this.cboTipoFolioExpediente1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFolioExpediente1.FormattingEnabled = true;
            this.cboTipoFolioExpediente1.Location = new System.Drawing.Point(129, 48);
            this.cboTipoFolioExpediente1.Name = "cboTipoFolioExpediente1";
            this.cboTipoFolioExpediente1.Size = new System.Drawing.Size(156, 21);
            this.cboTipoFolioExpediente1.TabIndex = 2;
            this.cboTipoFolioExpediente1.SelectedIndexChanged += new System.EventHandler(this.cboTipoFolioExpediente1_SelectedIndexChanged);
            // 
            // cboCondicionExp1
            // 
            this.cboCondicionExp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionExp1.FormattingEnabled = true;
            this.cboCondicionExp1.Location = new System.Drawing.Point(129, 19);
            this.cboCondicionExp1.Name = "cboCondicionExp1";
            this.cboCondicionExp1.Size = new System.Drawing.Size(156, 21);
            this.cboCondicionExp1.TabIndex = 1;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(301, 26);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Número de folios:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(301, 52);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(123, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Tipo de Documento:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(430, 48);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(122, 21);
            this.cboTipoDocumento.TabIndex = 4;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoExpediente);
            this.grbBase1.Controls.Add(this.cboDocumentosExpedientePadre);
            this.grbBase1.Controls.Add(this.cboDocumentosExpediente);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Location = new System.Drawing.Point(8, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(558, 101);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Documentos Comunes";
            // 
            // cboTipoExpediente
            // 
            this.cboTipoExpediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoExpediente.FormattingEnabled = true;
            this.cboTipoExpediente.Location = new System.Drawing.Point(139, 18);
            this.cboTipoExpediente.Name = "cboTipoExpediente";
            this.cboTipoExpediente.Size = new System.Drawing.Size(228, 21);
            this.cboTipoExpediente.TabIndex = 8;
            this.cboTipoExpediente.SelectedIndexChanged += new System.EventHandler(this.cboTipoExpediente_SelectedIndexChanged_1);
            // 
            // cboDocumentosExpedientePadre
            // 
            this.cboDocumentosExpedientePadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentosExpedientePadre.FormattingEnabled = true;
            this.cboDocumentosExpedientePadre.Location = new System.Drawing.Point(139, 45);
            this.cboDocumentosExpedientePadre.Name = "cboDocumentosExpedientePadre";
            this.cboDocumentosExpedientePadre.Size = new System.Drawing.Size(400, 21);
            this.cboDocumentosExpedientePadre.TabIndex = 1;
            this.cboDocumentosExpedientePadre.SelectedIndexChanged += new System.EventHandler(this.cboDocumentosExpedientePadre_SelectedIndexChanged);
            // 
            // cboDocumentosExpediente
            // 
            this.cboDocumentosExpediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentosExpediente.FormattingEnabled = true;
            this.cboDocumentosExpediente.Location = new System.Drawing.Point(139, 72);
            this.cboDocumentosExpediente.Name = "cboDocumentosExpediente";
            this.cboDocumentosExpediente.Size = new System.Drawing.Size(400, 21);
            this.cboDocumentosExpediente.TabIndex = 2;
            this.cboDocumentosExpediente.SelectedIndexChanged += new System.EventHandler(this.cboDocumentosExpediente_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 75);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(77, 13);
            this.lblBase8.TabIndex = 7;
            this.lblBase8.Text = "Documento:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 48);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(116, 13);
            this.lblBase7.TabIndex = 7;
            this.lblBase7.Text = "Documento Grupo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(10, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(103, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Tipo Expediente:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.nudNroFolios);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboTipoDocumento);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboCondicionExp1);
            this.grbBase2.Controls.Add(this.rtbDescripDoc);
            this.grbBase2.Controls.Add(this.cboTipoFolioExpediente1);
            this.grbBase2.Location = new System.Drawing.Point(8, 113);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(558, 172);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Registro de Contenido del Expediente";
            // 
            // nudNroFolios
            // 
            this.nudNroFolios.Location = new System.Drawing.Point(430, 20);
            this.nudNroFolios.Name = "nudNroFolios";
            this.nudNroFolios.Size = new System.Drawing.Size(122, 20);
            this.nudNroFolios.TabIndex = 3;
            // 
            // frmRegDocExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 374);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegDocExpediente";
            this.Text = "Registro de Contenido del Expediente";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroFolios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.RichTextBox rtbDescripDoc;
        private GEN.ControlesBase.cboTipoFolioExpediente cboTipoFolioExpediente1;
        private GEN.ControlesBase.cboCondicionExp cboCondicionExp1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipoDocumento;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.nudBase nudNroFolios;
        private GEN.ControlesBase.cboBase cboDocumentosExpediente;
        private GEN.ControlesBase.cboBase cboDocumentosExpedientePadre;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboTipoExpediente cboTipoExpediente;

    }
}