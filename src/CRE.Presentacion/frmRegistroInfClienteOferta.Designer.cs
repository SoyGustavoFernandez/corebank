namespace CRE.Presentacion
{
    partial class frmRegistroInfClienteOferta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroInfClienteOferta));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipContacto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboDetTipContacto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpCorto1 = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(274, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Seleccione la forma de contacto con el cliente:";
            // 
            // cboTipContacto
            // 
            this.cboTipContacto.FormattingEnabled = true;
            this.cboTipContacto.Location = new System.Drawing.Point(292, 21);
            this.cboTipContacto.Name = "cboTipContacto";
            this.cboTipContacto.Size = new System.Drawing.Size(121, 21);
            this.cboTipContacto.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(58, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(228, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Seleccione la respuesta mas cercana :";
            // 
            // cboDetTipContacto
            // 
            this.cboDetTipContacto.FormattingEnabled = true;
            this.cboDetTipContacto.Location = new System.Drawing.Point(292, 44);
            this.cboDetTipContacto.Name = "cboDetTipContacto";
            this.cboDetTipContacto.Size = new System.Drawing.Size(234, 21);
            this.cboDetTipContacto.TabIndex = 5;
            this.cboDetTipContacto.SelectedIndexChanged += new System.EventHandler(this.cboDetTipContacto_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(180, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Si selecciona OTROS escriba :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 91);
            this.richTextBox1.MaxLength = 100;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(315, 53);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(369, 94);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(451, 94);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 97);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(126, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Seleccione la fecha :";
            // 
            // dtpCorto1
            // 
            this.dtpCorto1.Location = new System.Drawing.Point(144, 97);
            this.dtpCorto1.Name = "dtpCorto1";
            this.dtpCorto1.Size = new System.Drawing.Size(200, 20);
            this.dtpCorto1.TabIndex = 12;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 75);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(222, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Si selecciona Cobrará mas adelante :";
            // 
            // frmRegistroInfClienteOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 195);
            this.ControlBox = false;
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.dtpCorto1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboDetTipContacto);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboTipContacto);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRegistroInfClienteOferta";
            this.Text = "Registro de información de cliente de Oferta";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipContacto, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboDetTipContacto, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtpCorto1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipContacto;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboDetTipContacto;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpCorto1;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}