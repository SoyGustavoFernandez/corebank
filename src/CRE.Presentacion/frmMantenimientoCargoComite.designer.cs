namespace CRE.Presentacion
{
    partial class frmMantenimientoCargoComite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCargoComite));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboCargoPersonalcs1 = new GEN.ControlesBase.cboCargoPersonalcs(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lstCargosAgencia = new GEN.ControlesBase.lstBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboArea1 = new GEN.ControlesBase.cboArea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(169, 319);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(235, 319);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(103, 319);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(301, 319);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboCargoPersonalcs1
            // 
            this.cboCargoPersonalcs1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargoPersonalcs1.Enabled = false;
            this.cboCargoPersonalcs1.FormattingEnabled = true;
            this.cboCargoPersonalcs1.Location = new System.Drawing.Point(95, 66);
            this.cboCargoPersonalcs1.Name = "cboCargoPersonalcs1";
            this.cboCargoPersonalcs1.Size = new System.Drawing.Size(187, 21);
            this.cboCargoPersonalcs1.TabIndex = 7;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 69);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(47, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Cargo:";
            // 
            // lstCargosAgencia
            // 
            this.lstCargosAgencia.FormattingEnabled = true;
            this.lstCargosAgencia.Location = new System.Drawing.Point(22, 104);
            this.lstCargosAgencia.Name = "lstCargosAgencia";
            this.lstCargosAgencia.Size = new System.Drawing.Size(349, 199);
            this.lstCargosAgencia.TabIndex = 9;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(95, 12);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(187, 21);
            this.cboAgencias1.TabIndex = 10;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // cboArea1
            // 
            this.cboArea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea1.Enabled = false;
            this.cboArea1.FormattingEnabled = true;
            this.cboArea1.Location = new System.Drawing.Point(95, 39);
            this.cboArea1.Name = "cboArea1";
            this.cboArea1.Size = new System.Drawing.Size(187, 21);
            this.cboArea1.TabIndex = 11;
            this.cboArea1.SelectedIndexChanged += new System.EventHandler(this.cboArea1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 42);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(39, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Área:";
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(37, 319);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 12;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // frmMantenimientoCargoComite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 406);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.cboArea1);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.lstCargosAgencia);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboCargoPersonalcs1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMantenimientoCargoComite";
            this.Text = "Mantenimiento de Cargo x Comité";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboCargoPersonalcs1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lstCargosAgencia, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.cboArea1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.cboCargoPersonalcs cboCargoPersonalcs1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lstBase lstCargosAgencia;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.cboArea cboArea1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
    }
}

