namespace DEP.Presentacion
{
    partial class frmRecepcionValorado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionValorado));
            this.tbcValorados = new GEN.ControlesBase.tbcBase(this.components);
            this.tabOP = new System.Windows.Forms.TabPage();
            this.btnRechazarOP = new GEN.BotonesBase.btnRechazar();
            this.btnSalirOP = new GEN.BotonesBase.btnSalir();
            this.btnCancelarOP = new GEN.BotonesBase.btnCancelar();
            this.btnRecibidoOP = new GEN.BotonesBase.btnRecibido();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDescriOP = new GEN.ControlesBase.txtBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtgSolOP = new GEN.ControlesBase.dtgBase(this.components);
            this.tabCertificados = new System.Windows.Forms.TabPage();
            this.btnRechazarConstancia = new GEN.BotonesBase.btnRechazar();
            this.btnSalirCert = new GEN.BotonesBase.btnSalir();
            this.btnCancelarCert = new GEN.BotonesBase.btnCancelar();
            this.btnRecibidoCert = new GEN.BotonesBase.btnRecibido();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescriCert = new GEN.ControlesBase.txtBase(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dtgCertificado = new GEN.ControlesBase.dtgBase(this.components);
            this.tbcValorados.SuspendLayout();
            this.tabOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).BeginInit();
            this.tabCertificados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcValorados
            // 
            this.tbcValorados.Controls.Add(this.tabOP);
            this.tbcValorados.Controls.Add(this.tabCertificados);
            this.tbcValorados.Location = new System.Drawing.Point(5, 6);
            this.tbcValorados.Name = "tbcValorados";
            this.tbcValorados.SelectedIndex = 0;
            this.tbcValorados.Size = new System.Drawing.Size(679, 483);
            this.tbcValorados.TabIndex = 2;
            // 
            // tabOP
            // 
            this.tabOP.Controls.Add(this.btnRechazarOP);
            this.tabOP.Controls.Add(this.btnSalirOP);
            this.tabOP.Controls.Add(this.btnCancelarOP);
            this.tabOP.Controls.Add(this.btnRecibidoOP);
            this.tabOP.Controls.Add(this.lblBase1);
            this.tabOP.Controls.Add(this.txtDescriOP);
            this.tabOP.Controls.Add(this.label1);
            this.tabOP.Controls.Add(this.dtgSolOP);
            this.tabOP.Location = new System.Drawing.Point(4, 22);
            this.tabOP.Name = "tabOP";
            this.tabOP.Padding = new System.Windows.Forms.Padding(3);
            this.tabOP.Size = new System.Drawing.Size(671, 457);
            this.tabOP.TabIndex = 0;
            this.tabOP.Text = "Recepción de ordenes de pago";
            this.tabOP.UseVisualStyleBackColor = true;
            this.tabOP.Click += new System.EventHandler(this.tabOP_Click);
            // 
            // btnRechazarOP
            // 
            this.btnRechazarOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazarOP.BackgroundImage")));
            this.btnRechazarOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazarOP.Location = new System.Drawing.Point(407, 399);
            this.btnRechazarOP.Name = "btnRechazarOP";
            this.btnRechazarOP.Size = new System.Drawing.Size(60, 50);
            this.btnRechazarOP.TabIndex = 143;
            this.btnRechazarOP.Text = "&Rechaza";
            this.btnRechazarOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazarOP.UseVisualStyleBackColor = true;
            this.btnRechazarOP.Click += new System.EventHandler(this.btnRechazarOP_Click);
            // 
            // btnSalirOP
            // 
            this.btnSalirOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirOP.BackgroundImage")));
            this.btnSalirOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirOP.Location = new System.Drawing.Point(592, 399);
            this.btnSalirOP.Name = "btnSalirOP";
            this.btnSalirOP.Size = new System.Drawing.Size(60, 50);
            this.btnSalirOP.TabIndex = 142;
            this.btnSalirOP.Text = "&Salir";
            this.btnSalirOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirOP.UseVisualStyleBackColor = true;
            this.btnSalirOP.Click += new System.EventHandler(this.btnSalirOP_Click);
            // 
            // btnCancelarOP
            // 
            this.btnCancelarOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarOP.BackgroundImage")));
            this.btnCancelarOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarOP.Location = new System.Drawing.Point(526, 399);
            this.btnCancelarOP.Name = "btnCancelarOP";
            this.btnCancelarOP.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarOP.TabIndex = 141;
            this.btnCancelarOP.Text = "&Cancelar";
            this.btnCancelarOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarOP.UseVisualStyleBackColor = true;
            this.btnCancelarOP.Click += new System.EventHandler(this.btnCancelarOP_Click);
            // 
            // btnRecibidoOP
            // 
            this.btnRecibidoOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecibidoOP.BackgroundImage")));
            this.btnRecibidoOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecibidoOP.Location = new System.Drawing.Point(467, 399);
            this.btnRecibidoOP.Name = "btnRecibidoOP";
            this.btnRecibidoOP.Size = new System.Drawing.Size(60, 50);
            this.btnRecibidoOP.TabIndex = 140;
            this.btnRecibidoOP.Text = "&Recibido";
            this.btnRecibidoOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecibidoOP.UseVisualStyleBackColor = true;
            this.btnRecibidoOP.Click += new System.EventHandler(this.btnRecibidoOP_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 323);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 139;
            this.lblBase1.Text = "Descripción:";
            // 
            // txtDescriOP
            // 
            this.txtDescriOP.Location = new System.Drawing.Point(93, 323);
            this.txtDescriOP.Multiline = true;
            this.txtDescriOP.Name = "txtDescriOP";
            this.txtDescriOP.Size = new System.Drawing.Size(562, 71);
            this.txtDescriOP.TabIndex = 138;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 21);
            this.label1.TabIndex = 137;
            this.label1.Text = "Listado de Valorados para su Recepción";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgSolOP
            // 
            this.dtgSolOP.AllowUserToAddRows = false;
            this.dtgSolOP.AllowUserToDeleteRows = false;
            this.dtgSolOP.AllowUserToResizeColumns = false;
            this.dtgSolOP.AllowUserToResizeRows = false;
            this.dtgSolOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolOP.Location = new System.Drawing.Point(6, 36);
            this.dtgSolOP.MultiSelect = false;
            this.dtgSolOP.Name = "dtgSolOP";
            this.dtgSolOP.ReadOnly = true;
            this.dtgSolOP.RowHeadersVisible = false;
            this.dtgSolOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolOP.Size = new System.Drawing.Size(654, 281);
            this.dtgSolOP.TabIndex = 136;
            // 
            // tabCertificados
            // 
            this.tabCertificados.Controls.Add(this.btnRechazarConstancia);
            this.tabCertificados.Controls.Add(this.btnSalirCert);
            this.tabCertificados.Controls.Add(this.btnCancelarCert);
            this.tabCertificados.Controls.Add(this.btnRecibidoCert);
            this.tabCertificados.Controls.Add(this.lblBase2);
            this.tabCertificados.Controls.Add(this.txtDescriCert);
            this.tabCertificados.Controls.Add(this.label2);
            this.tabCertificados.Controls.Add(this.dtgCertificado);
            this.tabCertificados.Location = new System.Drawing.Point(4, 22);
            this.tabCertificados.Name = "tabCertificados";
            this.tabCertificados.Padding = new System.Windows.Forms.Padding(3);
            this.tabCertificados.Size = new System.Drawing.Size(671, 457);
            this.tabCertificados.TabIndex = 1;
            this.tabCertificados.Text = "Recepción de constancias";
            this.tabCertificados.UseVisualStyleBackColor = true;
            // 
            // btnRechazarConstancia
            // 
            this.btnRechazarConstancia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazarConstancia.BackgroundImage")));
            this.btnRechazarConstancia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazarConstancia.Location = new System.Drawing.Point(414, 398);
            this.btnRechazarConstancia.Name = "btnRechazarConstancia";
            this.btnRechazarConstancia.Size = new System.Drawing.Size(60, 50);
            this.btnRechazarConstancia.TabIndex = 146;
            this.btnRechazarConstancia.Text = "&Rechaza";
            this.btnRechazarConstancia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazarConstancia.UseVisualStyleBackColor = true;
            this.btnRechazarConstancia.Visible = false;
            this.btnRechazarConstancia.Click += new System.EventHandler(this.btnRechazarConstancia_Click);
            // 
            // btnSalirCert
            // 
            this.btnSalirCert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirCert.BackgroundImage")));
            this.btnSalirCert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirCert.Location = new System.Drawing.Point(600, 398);
            this.btnSalirCert.Name = "btnSalirCert";
            this.btnSalirCert.Size = new System.Drawing.Size(60, 50);
            this.btnSalirCert.TabIndex = 145;
            this.btnSalirCert.Text = "&Salir";
            this.btnSalirCert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirCert.UseVisualStyleBackColor = true;
            this.btnSalirCert.Click += new System.EventHandler(this.btnSalirCert_Click);
            // 
            // btnCancelarCert
            // 
            this.btnCancelarCert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarCert.BackgroundImage")));
            this.btnCancelarCert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarCert.Location = new System.Drawing.Point(533, 398);
            this.btnCancelarCert.Name = "btnCancelarCert";
            this.btnCancelarCert.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarCert.TabIndex = 144;
            this.btnCancelarCert.Text = "&Cancelar";
            this.btnCancelarCert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarCert.UseVisualStyleBackColor = true;
            this.btnCancelarCert.Click += new System.EventHandler(this.btnCancelarCert_Click);
            // 
            // btnRecibidoCert
            // 
            this.btnRecibidoCert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecibidoCert.BackgroundImage")));
            this.btnRecibidoCert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecibidoCert.Location = new System.Drawing.Point(474, 398);
            this.btnRecibidoCert.Name = "btnRecibidoCert";
            this.btnRecibidoCert.Size = new System.Drawing.Size(60, 50);
            this.btnRecibidoCert.TabIndex = 143;
            this.btnRecibidoCert.Text = "&Recibido";
            this.btnRecibidoCert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecibidoCert.UseVisualStyleBackColor = true;
            this.btnRecibidoCert.Click += new System.EventHandler(this.btnRecibidoCert_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 323);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 141;
            this.lblBase2.Text = "Descripción:";
            // 
            // txtDescriCert
            // 
            this.txtDescriCert.Location = new System.Drawing.Point(98, 323);
            this.txtDescriCert.Multiline = true;
            this.txtDescriCert.Name = "txtDescriCert";
            this.txtDescriCert.Size = new System.Drawing.Size(562, 71);
            this.txtDescriCert.TabIndex = 140;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(655, 21);
            this.label2.TabIndex = 139;
            this.label2.Text = "Listado de Certificados para su Recepción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgCertificado
            // 
            this.dtgCertificado.AllowUserToAddRows = false;
            this.dtgCertificado.AllowUserToDeleteRows = false;
            this.dtgCertificado.AllowUserToResizeColumns = false;
            this.dtgCertificado.AllowUserToResizeRows = false;
            this.dtgCertificado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCertificado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCertificado.Location = new System.Drawing.Point(6, 41);
            this.dtgCertificado.MultiSelect = false;
            this.dtgCertificado.Name = "dtgCertificado";
            this.dtgCertificado.ReadOnly = true;
            this.dtgCertificado.RowHeadersVisible = false;
            this.dtgCertificado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCertificado.Size = new System.Drawing.Size(654, 276);
            this.dtgCertificado.TabIndex = 138;
            // 
            // frmRecepcionValorado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 514);
            this.Controls.Add(this.tbcValorados);
            this.Name = "frmRecepcionValorado";
            this.Text = "Recepción de Valorados";
            this.Load += new System.EventHandler(this.frmRecepcionValorado_Load);
            this.Controls.SetChildIndex(this.tbcValorados, 0);
            this.tbcValorados.ResumeLayout(false);
            this.tabOP.ResumeLayout(false);
            this.tabOP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).EndInit();
            this.tabCertificados.ResumeLayout(false);
            this.tabCertificados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcValorados;
        private System.Windows.Forms.TabPage tabOP;
        private System.Windows.Forms.TabPage tabCertificados;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.dtgBase dtgSolOP;
        private System.Windows.Forms.Label label2;
        private GEN.ControlesBase.dtgBase dtgCertificado;
        private GEN.BotonesBase.btnSalir btnSalirOP;
        private GEN.BotonesBase.btnCancelar btnCancelarOP;
        private GEN.BotonesBase.btnRecibido btnRecibidoOP;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtDescriOP;
        private GEN.BotonesBase.btnSalir btnSalirCert;
        private GEN.BotonesBase.btnCancelar btnCancelarCert;
        private GEN.BotonesBase.btnRecibido btnRecibidoCert;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtDescriCert;
        private GEN.BotonesBase.btnRechazar btnRechazarOP;
        private GEN.BotonesBase.btnRechazar btnRechazarConstancia;
    }
}