namespace CRE.Presentacion
{
    partial class frmRegistroCanales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroCanales));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtCodCanal = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.chbActivo = new System.Windows.Forms.CheckBox();
            this.chbInterno = new System.Windows.Forms.CheckBox();
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(151, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Mantenimieto de Canales";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 66);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(98, 65);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(139, 20);
            this.txtDescripcion.TabIndex = 10;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(26, 133);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(92, 133);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 12;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtCodCanal
            // 
            this.txtCodCanal.Enabled = false;
            this.txtCodCanal.Location = new System.Drawing.Point(97, 37);
            this.txtCodCanal.Name = "txtCodCanal";
            this.txtCodCanal.Size = new System.Drawing.Size(139, 20);
            this.txtCodCanal.TabIndex = 14;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 38);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(76, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Cod. Canal:";
            // 
            // chbActivo
            // 
            this.chbActivo.AutoSize = true;
            this.chbActivo.ForeColor = System.Drawing.Color.Navy;
            this.chbActivo.Location = new System.Drawing.Point(17, 98);
            this.chbActivo.Name = "chbActivo";
            this.chbActivo.Size = new System.Drawing.Size(56, 17);
            this.chbActivo.TabIndex = 15;
            this.chbActivo.Text = "Activo";
            this.chbActivo.UseVisualStyleBackColor = true;
            // 
            // chbInterno
            // 
            this.chbInterno.AutoSize = true;
            this.chbInterno.ForeColor = System.Drawing.Color.Navy;
            this.chbInterno.Location = new System.Drawing.Point(97, 99);
            this.chbInterno.Name = "chbInterno";
            this.chbInterno.Size = new System.Drawing.Size(59, 17);
            this.chbInterno.TabIndex = 16;
            this.chbInterno.Text = "Interno";
            this.chbInterno.UseVisualStyleBackColor = true;
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.ForeColor = System.Drawing.Color.Navy;
            this.chbVigente.Location = new System.Drawing.Point(183, 99);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(62, 17);
            this.chbVigente.TabIndex = 17;
            this.chbVigente.Text = "Vigente";
            this.chbVigente.UseVisualStyleBackColor = true;
            this.chbVigente.CheckedChanged += new System.EventHandler(this.chbVigente_CheckedChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(158, 134);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 18;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmRegistroCanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 216);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.chbVigente);
            this.Controls.Add(this.chbInterno);
            this.Controls.Add(this.chbActivo);
            this.Controls.Add(this.txtCodCanal);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRegistroCanales";
            this.Text = "Registrar Canales";
            this.Load += new System.EventHandler(this.frmRegistroCanales_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtCodCanal, 0);
            this.Controls.SetChildIndex(this.chbActivo, 0);
            this.Controls.SetChildIndex(this.chbInterno, 0);
            this.Controls.SetChildIndex(this.chbVigente, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtBase txtCodCanal;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.CheckBox chbActivo;
        private System.Windows.Forms.CheckBox chbInterno;
        private System.Windows.Forms.CheckBox chbVigente;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}