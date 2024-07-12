namespace CRE.Presentacion
{
    partial class frmAprobacionCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionCartaFianza));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCartaFianza = new GEN.ControlesBase.txtBase(this.components);
            this.txtSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtPlazoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaInicioAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnListaAprob1 = new GEN.BotonesBase.btnListaAprob();
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCartaFianza);
            this.groupBox2.Controls.Add(this.txtSolicitud);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.txtPlazoAprobado);
            this.groupBox2.Controls.Add(this.txtFechaInicioAprobado);
            this.groupBox2.Controls.Add(this.txtMontoAprobado);
            this.groupBox2.Controls.Add(this.lblBase10);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Location = new System.Drawing.Point(14, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la carta fianza solicitada";
            // 
            // txtCartaFianza
            // 
            this.txtCartaFianza.Enabled = false;
            this.txtCartaFianza.Location = new System.Drawing.Point(370, 19);
            this.txtCartaFianza.Name = "txtCartaFianza";
            this.txtCartaFianza.ReadOnly = true;
            this.txtCartaFianza.Size = new System.Drawing.Size(154, 20);
            this.txtCartaFianza.TabIndex = 27;
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Enabled = false;
            this.txtSolicitud.Location = new System.Drawing.Point(125, 19);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.ReadOnly = true;
            this.txtSolicitud.Size = new System.Drawing.Size(127, 20);
            this.txtSolicitud.TabIndex = 26;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(258, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(108, 13);
            this.lblBase3.TabIndex = 25;
            this.lblBase3.Text = "Nro Carta Fianza:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 24);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(60, 13);
            this.lblBase4.TabIndex = 24;
            this.lblBase4.Text = "Solicitud:";
            // 
            // txtPlazoAprobado
            // 
            this.txtPlazoAprobado.Enabled = false;
            this.txtPlazoAprobado.Location = new System.Drawing.Point(370, 71);
            this.txtPlazoAprobado.Name = "txtPlazoAprobado";
            this.txtPlazoAprobado.ReadOnly = true;
            this.txtPlazoAprobado.Size = new System.Drawing.Size(154, 20);
            this.txtPlazoAprobado.TabIndex = 23;
            // 
            // txtFechaInicioAprobado
            // 
            this.txtFechaInicioAprobado.Enabled = false;
            this.txtFechaInicioAprobado.Location = new System.Drawing.Point(125, 71);
            this.txtFechaInicioAprobado.Name = "txtFechaInicioAprobado";
            this.txtFechaInicioAprobado.ReadOnly = true;
            this.txtFechaInicioAprobado.Size = new System.Drawing.Size(175, 20);
            this.txtFechaInicioAprobado.TabIndex = 22;
            // 
            // txtMontoAprobado
            // 
            this.txtMontoAprobado.Enabled = false;
            this.txtMontoAprobado.Location = new System.Drawing.Point(125, 45);
            this.txtMontoAprobado.Name = "txtMontoAprobado";
            this.txtMontoAprobado.ReadOnly = true;
            this.txtMontoAprobado.Size = new System.Drawing.Size(399, 20);
            this.txtMontoAprobado.TabIndex = 21;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(316, 74);
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
            this.lblBase9.Location = new System.Drawing.Point(16, 76);
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
            this.lblBase8.Location = new System.Drawing.Point(16, 48);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(105, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Monto Aprobado:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(442, 230);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 3;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(508, 230);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnListaAprob1
            // 
            this.btnListaAprob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprob1.BackgroundImage")));
            this.btnListaAprob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprob1.Location = new System.Drawing.Point(495, 22);
            this.btnListaAprob1.Name = "btnListaAprob1";
            this.btnListaAprob1.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprob1.TabIndex = 1;
            this.btnListaAprob1.Text = "&Lista Aprob.";
            this.btnListaAprob1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprob1.UseVisualStyleBackColor = true;
            this.btnListaAprob1.Click += new System.EventHandler(this.btnListaAprob1_Click);
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Enabled = false;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli1.TabIndex = 5;
            // 
            // frmAprobacionCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 308);
            this.Controls.Add(this.btnListaAprob1);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmAprobacionCartaFianza";
            this.Text = "Imprimir Acta Aprobación Carta Fianza";
            this.Load += new System.EventHandler(this.frmAprobacionCartaFianza_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.btnListaAprob1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtPlazoAprobado;
        private GEN.ControlesBase.txtBase txtFechaInicioAprobado;
        private GEN.ControlesBase.txtBase txtMontoAprobado;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnListaAprob btnListaAprob1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.txtBase txtCartaFianza;
        private GEN.ControlesBase.txtBase txtSolicitud;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
    }
}