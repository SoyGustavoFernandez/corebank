namespace CRE.Presentacion
{
    partial class frmMantComiBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantComiBN));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoComision = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoOperacion1 = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtPorComi = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtComMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtDescripción = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.rbtActivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnInactivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoComision);
            this.grbBase1.Controls.Add(this.cboTipoOperacion1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboMoneda1);
            this.grbBase1.Controls.Add(this.txtPorComi);
            this.grbBase1.Controls.Add(this.txtComMin);
            this.grbBase1.Controls.Add(this.txtDescripción);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.rbtActivo);
            this.grbBase1.Controls.Add(this.rbtnInactivo);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(383, 217);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Juez";
            // 
            // cboTipoComision
            // 
            this.cboTipoComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComision.FormattingEnabled = true;
            this.cboTipoComision.Location = new System.Drawing.Point(154, 27);
            this.cboTipoComision.Name = "cboTipoComision";
            this.cboTipoComision.Size = new System.Drawing.Size(224, 21);
            this.cboTipoComision.TabIndex = 20;
            this.cboTipoComision.SelectedIndexChanged += new System.EventHandler(this.cboTipoComision_SelectedIndexChanged);
            // 
            // cboTipoOperacion1
            // 
            this.cboTipoOperacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion1.FormattingEnabled = true;
            this.cboTipoOperacion1.Location = new System.Drawing.Point(154, 54);
            this.cboTipoOperacion1.Name = "cboTipoOperacion1";
            this.cboTipoOperacion1.Size = new System.Drawing.Size(224, 21);
            this.cboTipoOperacion1.TabIndex = 19;
            this.cboTipoOperacion1.SelectedIndexChanged += new System.EventHandler(this.cboTipoOperacion1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 83);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Moneda:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(154, 80);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(224, 21);
            this.cboMoneda1.TabIndex = 17;
            this.cboMoneda1.SelectedIndexChanged += new System.EventHandler(this.cboMoneda1_SelectedIndexChanged);
            // 
            // txtPorComi
            // 
            this.txtPorComi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorComi.Enabled = false;
            this.txtPorComi.FormatoDecimal = false;
            this.txtPorComi.Location = new System.Drawing.Point(154, 161);
            this.txtPorComi.Name = "txtPorComi";
            this.txtPorComi.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorComi.nNumDecimales = 4;
            this.txtPorComi.nvalor = 0D;
            this.txtPorComi.Size = new System.Drawing.Size(224, 20);
            this.txtPorComi.TabIndex = 4;
            // 
            // txtComMin
            // 
            this.txtComMin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComMin.Enabled = false;
            this.txtComMin.FormatoDecimal = false;
            this.txtComMin.Location = new System.Drawing.Point(154, 135);
            this.txtComMin.Name = "txtComMin";
            this.txtComMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtComMin.nNumDecimales = 2;
            this.txtComMin.nvalor = 0D;
            this.txtComMin.Size = new System.Drawing.Size(224, 20);
            this.txtComMin.TabIndex = 3;
            // 
            // txtDescripción
            // 
            this.txtDescripción.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripción.Enabled = false;
            this.txtDescripción.Location = new System.Drawing.Point(154, 108);
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(224, 20);
            this.txtDescripción.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 30);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(90, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Tipo comisión:";
            // 
            // rbtActivo
            // 
            this.rbtActivo.AutoSize = true;
            this.rbtActivo.Enabled = false;
            this.rbtActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtActivo.Location = new System.Drawing.Point(154, 192);
            this.rbtActivo.Name = "rbtActivo";
            this.rbtActivo.Size = new System.Drawing.Size(55, 17);
            this.rbtActivo.TabIndex = 7;
            this.rbtActivo.TabStop = true;
            this.rbtActivo.Text = "Activo";
            this.rbtActivo.UseVisualStyleBackColor = true;
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Enabled = false;
            this.rbtnInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnInactivo.Location = new System.Drawing.Point(215, 192);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbtnInactivo.TabIndex = 8;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivo";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(17, 57);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(96, 13);
            this.lblBase7.TabIndex = 16;
            this.lblBase7.Text = "Tipo operación:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(17, 165);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(127, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Porcentaje comisión:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 138);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(111, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Comisión mínima:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 112);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Descripción:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 194);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 16;
            this.lblBase4.Text = "Estado:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(132, 246);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(198, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(264, 246);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(66, 246);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(330, 246);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmMantComiBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 329);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmMantComiBN";
            this.Text = "Mantenimiento de comisón de Banco de la Nación";
            this.Load += new System.EventHandler(this.frmMantComiBN_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtPorComi;
        private GEN.ControlesBase.txtNumRea txtComMin;
        private GEN.ControlesBase.txtBase txtDescripción;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.rbtnBase rbtActivo;
        private GEN.ControlesBase.rbtnBase rbtnInactivo;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoComision;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion1;
    }
}