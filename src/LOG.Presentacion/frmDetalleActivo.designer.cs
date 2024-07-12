namespace LOG.Presentacion
{
    partial class frmDetalleActivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleActivo));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.txtRubro = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase21 = new GEN.ControlesBase.lblBase();
            this.txtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.txtModelo = new GEN.ControlesBase.txtBase(this.components);
            this.txtMarca = new GEN.ControlesBase.txtBase(this.components);
            this.txtMaterial = new GEN.ControlesBase.txtBase(this.components);
            this.txtColor = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(415, 322);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(349, 322);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(24, 234);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(451, 82);
            this.txtObservaciones.TabIndex = 15;
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(21, 215);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(96, 13);
            this.lblBase32.TabIndex = 14;
            this.lblBase32.Text = "Observaciones:";
            // 
            // txtRubro
            // 
            this.txtRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRubro.Location = new System.Drawing.Point(82, 36);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(393, 20);
            this.txtRubro.TabIndex = 3;
            // 
            // lblBase21
            // 
            this.lblBase21.AutoSize = true;
            this.lblBase21.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase21.ForeColor = System.Drawing.Color.Navy;
            this.lblBase21.Location = new System.Drawing.Point(27, 40);
            this.lblBase21.Name = "lblBase21";
            this.lblBase21.Size = new System.Drawing.Size(46, 13);
            this.lblBase21.TabIndex = 2;
            this.lblBase21.Text = "Rubro:";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(82, 94);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(393, 20);
            this.txtSerie.TabIndex = 7;
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Location = new System.Drawing.Point(82, 123);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(393, 20);
            this.txtModelo.TabIndex = 9;
            // 
            // txtMarca
            // 
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Location = new System.Drawing.Point(82, 65);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(393, 20);
            this.txtMarca.TabIndex = 5;
            // 
            // txtMaterial
            // 
            this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterial.Location = new System.Drawing.Point(82, 181);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(393, 20);
            this.txtMaterial.TabIndex = 13;
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Location = new System.Drawing.Point(82, 152);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(393, 20);
            this.txtColor.TabIndex = 11;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(31, 99);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(42, 13);
            this.lblBase7.TabIndex = 6;
            this.lblBase7.Text = "Serie:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(21, 128);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(52, 13);
            this.lblBase6.TabIndex = 8;
            this.lblBase6.Text = "Modelo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(27, 69);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Marca:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 185);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Material:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(30, 156);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(43, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Color:";
            // 
            // txtCodInst
            // 
            this.txtCodInst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodInst.Location = new System.Drawing.Point(158, 10);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(317, 20);
            this.txtCodInst.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(125, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Codigo Institucional:";
            // 
            // frmDetalleActivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 397);
            this.Controls.Add(this.txtCodInst);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtRubro);
            this.Controls.Add(this.lblBase21);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblBase7);
            this.Name = "frmDetalleActivo";
            this.Text = "Detalle de Activo";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtColor, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMaterial, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtModelo, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblBase21, 0);
            this.Controls.SetChildIndex(this.txtRubro, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCodInst, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.txtBase txtRubro;
        private GEN.ControlesBase.lblBase lblBase21;
        private GEN.ControlesBase.txtBase txtSerie;
        private GEN.ControlesBase.txtBase txtModelo;
        private GEN.ControlesBase.txtBase txtMarca;
        private GEN.ControlesBase.txtBase txtMaterial;
        private GEN.ControlesBase.txtBase txtColor;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}

