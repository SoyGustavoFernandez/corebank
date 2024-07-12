namespace CNE.Presentacion
{
    partial class frmPDPGestionaPagoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPGestionaPagoDialog));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtItem = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdInsPago = new GEN.ControlesBase.txtBase(this.components);
            this.cboPDPEstado = new GEN.ControlesBase.cboPDPEstado(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPDPEmisor = new GEN.ControlesBase.cboPDPEmisor(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.rbtSuccess = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtFailed = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(70, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(39, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Item:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(58, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Emisor:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(31, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Id.Ins.Pago:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(59, 101);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(50, 13);
            this.lblBase5.TabIndex = 6;
            this.lblBase5.Text = "Estado:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(38, 129);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(71, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Respuesta:";
            // 
            // txtItem
            // 
            this.txtItem.Enabled = false;
            this.txtItem.Location = new System.Drawing.Point(115, 19);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(100, 20);
            this.txtItem.TabIndex = 8;
            // 
            // txtIdInsPago
            // 
            this.txtIdInsPago.Enabled = false;
            this.txtIdInsPago.Location = new System.Drawing.Point(115, 72);
            this.txtIdInsPago.Name = "txtIdInsPago";
            this.txtIdInsPago.Size = new System.Drawing.Size(100, 20);
            this.txtIdInsPago.TabIndex = 10;
            // 
            // cboPDPEstado
            // 
            this.cboPDPEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDPEstado.FormattingEnabled = true;
            this.cboPDPEstado.Location = new System.Drawing.Point(115, 98);
            this.cboPDPEstado.Name = "cboPDPEstado";
            this.cboPDPEstado.Size = new System.Drawing.Size(121, 21);
            this.cboPDPEstado.TabIndex = 11;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtFailed);
            this.grbBase1.Controls.Add(this.rbtSuccess);
            this.grbBase1.Controls.Add(this.cboPDPEmisor);
            this.grbBase1.Controls.Add(this.txtItem);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboPDPEstado);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtIdInsPago);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(329, 161);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Información";
            // 
            // cboPDPEmisor
            // 
            this.cboPDPEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDPEmisor.Enabled = false;
            this.cboPDPEmisor.FormattingEnabled = true;
            this.cboPDPEmisor.Location = new System.Drawing.Point(115, 45);
            this.cboPDPEmisor.Name = "cboPDPEmisor";
            this.cboPDPEmisor.Size = new System.Drawing.Size(121, 21);
            this.cboPDPEmisor.TabIndex = 15;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(281, 179);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(215, 179);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // rbtSuccess
            // 
            this.rbtSuccess.AutoSize = true;
            this.rbtSuccess.ForeColor = System.Drawing.Color.Navy;
            this.rbtSuccess.Location = new System.Drawing.Point(115, 125);
            this.rbtSuccess.Name = "rbtSuccess";
            this.rbtSuccess.Size = new System.Drawing.Size(66, 17);
            this.rbtSuccess.TabIndex = 17;
            this.rbtSuccess.TabStop = true;
            this.rbtSuccess.Text = "Success";
            this.rbtSuccess.UseVisualStyleBackColor = true;
            // 
            // rbtFailed
            // 
            this.rbtFailed.AutoSize = true;
            this.rbtFailed.ForeColor = System.Drawing.Color.Navy;
            this.rbtFailed.Location = new System.Drawing.Point(183, 125);
            this.rbtFailed.Name = "rbtFailed";
            this.rbtFailed.Size = new System.Drawing.Size(53, 17);
            this.rbtFailed.TabIndex = 18;
            this.rbtFailed.TabStop = true;
            this.rbtFailed.Text = "Failed";
            this.rbtFailed.UseVisualStyleBackColor = true;
            // 
            // frmPDPGestionaPagoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 261);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmPDPGestionaPagoDialog";
            this.Text = "Instrucción de Pago";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtItem;
        private GEN.ControlesBase.txtBase txtIdInsPago;
        private GEN.ControlesBase.cboPDPEstado cboPDPEstado;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.cboPDPEmisor cboPDPEmisor;
        private GEN.ControlesBase.rbtBase rbtFailed;
        private GEN.ControlesBase.rbtBase rbtSuccess;
    }
}