namespace CRE.Presentacion
{
    partial class frmMantCategoriaOfi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantCategoriaOfi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblValor = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblPeriodo = new GEN.ControlesBase.lblBase();
            this.cboPeriodoCateOfi = new GEN.ControlesBase.cboPeriodoCateOfi(this.components);
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboCategoriaOficina = new GEN.ControlesBase.cboCategoriaOficina(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Controls.Add(this.lblPeriodo);
            this.groupBox1.Controls.Add(this.cboPeriodoCateOfi);
            this.groupBox1.Controls.Add(this.chbVigente);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboCategoriaOficina);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.Navy;
            this.lblValor.Location = new System.Drawing.Point(319, 13);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(13, 13);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "-";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodo.Location = new System.Drawing.Point(2, 5);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(83, 26);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Perido de\r\nClasificación:";
            // 
            // cboPeriodoCateOfi
            // 
            this.cboPeriodoCateOfi.FormattingEnabled = true;
            this.cboPeriodoCateOfi.Location = new System.Drawing.Point(86, 10);
            this.cboPeriodoCateOfi.Name = "cboPeriodoCateOfi";
            this.cboPeriodoCateOfi.Size = new System.Drawing.Size(227, 21);
            this.cboPeriodoCateOfi.TabIndex = 1;
            this.cboPeriodoCateOfi.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoCateOfi_SelectedIndexChanged);
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.Enabled = false;
            this.chbVigente.Location = new System.Drawing.Point(244, 51);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(62, 17);
            this.chbVigente.TabIndex = 7;
            this.chbVigente.Text = "Vigente";
            this.chbVigente.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(181, 76);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(46, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(97, 79);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Descripción:";
            // 
            // cboCategoriaOficina
            // 
            this.cboCategoriaOficina.DisplayMember = "cDescripcion";
            this.cboCategoriaOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoriaOficina.FormattingEnabled = true;
            this.cboCategoriaOficina.Location = new System.Drawing.Point(181, 49);
            this.cboCategoriaOficina.Name = "cboCategoriaOficina";
            this.cboCategoriaOficina.Size = new System.Drawing.Size(46, 21);
            this.cboCategoriaOficina.TabIndex = 4;
            this.cboCategoriaOficina.ValueMember = "idCategoriaOfi";
            this.cboCategoriaOficina.SelectedIndexChanged += new System.EventHandler(this.cboCategoriaOficina1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(97, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(68, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Categoria:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(174, 128);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(307, 128);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(240, 128);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(108, 128);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(41, 128);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // frmMantCategoriaOfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 211);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMantCategoriaOfi";
            this.Text = "Mantenimiento de categorias de oficinas";
            this.Load += new System.EventHandler(this.frmMantCategoriaOfi_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboCategoriaOficina cboCategoriaOficina;
        private System.Windows.Forms.CheckBox chbVigente;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblPeriodo;
        private GEN.ControlesBase.cboPeriodoCateOfi cboPeriodoCateOfi;
        private GEN.ControlesBase.lblBaseCustom lblValor;
    }
}