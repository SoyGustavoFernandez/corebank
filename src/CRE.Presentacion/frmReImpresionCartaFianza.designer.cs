namespace CRE.Presentacion
{
    partial class frmReImpresionCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReImpresionCartaFianza));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnListaAprob1 = new GEN.BotonesBase.btnListaAprob();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodCartaFianza = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtPlazoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaInicioAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(441, 178);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 56;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(507, 178);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 55;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnListaAprob1
            // 
            this.btnListaAprob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprob1.BackgroundImage")));
            this.btnListaAprob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprob1.Location = new System.Drawing.Point(507, 31);
            this.btnListaAprob1.Name = "btnListaAprob1";
            this.btnListaAprob1.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprob1.TabIndex = 54;
            this.btnListaAprob1.Text = "&Lista Aprob.";
            this.btnListaAprob1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprob1.UseVisualStyleBackColor = true;
            this.btnListaAprob1.Click += new System.EventHandler(this.btnListaAprob1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreCliente);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 69);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del cliente";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(96, 41);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(376, 20);
            this.txtNombreCliente.TabIndex = 3;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(97, 16);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(375, 20);
            this.txtDocumento.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(63, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Nombres:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(77, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Documento:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodCartaFianza);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.txtPlazoAprobado);
            this.groupBox2.Controls.Add(this.txtFechaInicioAprobado);
            this.groupBox2.Controls.Add(this.txtMontoAprobado);
            this.groupBox2.Controls.Add(this.lblBase10);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 85);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la carta fianza solicitada";
            // 
            // txtCodCartaFianza
            // 
            this.txtCodCartaFianza.Enabled = false;
            this.txtCodCartaFianza.Location = new System.Drawing.Point(123, 22);
            this.txtCodCartaFianza.Name = "txtCodCartaFianza";
            this.txtCodCartaFianza.ReadOnly = true;
            this.txtCodCartaFianza.Size = new System.Drawing.Size(122, 20);
            this.txtCodCartaFianza.TabIndex = 25;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(60, 29);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Código:";
            // 
            // txtPlazoAprobado
            // 
            this.txtPlazoAprobado.Enabled = false;
            this.txtPlazoAprobado.Location = new System.Drawing.Point(368, 48);
            this.txtPlazoAprobado.Name = "txtPlazoAprobado";
            this.txtPlazoAprobado.ReadOnly = true;
            this.txtPlazoAprobado.Size = new System.Drawing.Size(154, 20);
            this.txtPlazoAprobado.TabIndex = 23;
            // 
            // txtFechaInicioAprobado
            // 
            this.txtFechaInicioAprobado.Enabled = false;
            this.txtFechaInicioAprobado.Location = new System.Drawing.Point(123, 48);
            this.txtFechaInicioAprobado.Name = "txtFechaInicioAprobado";
            this.txtFechaInicioAprobado.ReadOnly = true;
            this.txtFechaInicioAprobado.Size = new System.Drawing.Size(175, 20);
            this.txtFechaInicioAprobado.TabIndex = 22;
            // 
            // txtMontoAprobado
            // 
            this.txtMontoAprobado.Enabled = false;
            this.txtMontoAprobado.Location = new System.Drawing.Point(368, 22);
            this.txtMontoAprobado.Name = "txtMontoAprobado";
            this.txtMontoAprobado.ReadOnly = true;
            this.txtMontoAprobado.Size = new System.Drawing.Size(154, 20);
            this.txtMontoAprobado.TabIndex = 21;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(314, 51);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(42, 13);
            this.lblBase10.TabIndex = 19;
            this.lblBase10.Text = "Plazo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(39, 51);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "Fecha inicio:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(251, 25);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(105, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Monto Aprobado:";
            // 
            // frmReImpresionCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 260);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnListaAprob1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmReImpresionCartaFianza";
            this.Text = "Re-Impresion Carta Fianza";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnListaAprob1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnListaAprob btnListaAprob1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.txtBase txtNombreCliente;
        private GEN.ControlesBase.txtBase txtDocumento;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtPlazoAprobado;
        private GEN.ControlesBase.txtBase txtFechaInicioAprobado;
        private GEN.ControlesBase.txtBase txtMontoAprobado;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtCodCartaFianza;
        private GEN.ControlesBase.lblBase lblBase3;

    }
}