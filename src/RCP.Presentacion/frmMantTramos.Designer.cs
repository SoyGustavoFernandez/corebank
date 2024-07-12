namespace RCP.Presentacion
{
    partial class frmMantTramos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantTramos));
            this.cboTramo = new GEN.ControlesBase.cboTramo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombreTramo = new GEN.ControlesBase.txtBase(this.components);
            this.txtAtrasoMinimo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAtrasoMaximo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtDescripcionTramo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.cboTipoTramo = new GEN.ControlesBase.cboTipoTramo(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbDatosTramo = new System.Windows.Forms.GroupBox();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbDatosTramo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTramo
            // 
            this.cboTramo.FormattingEnabled = true;
            this.cboTramo.Location = new System.Drawing.Point(168, 12);
            this.cboTramo.Name = "cboTramo";
            this.cboTramo.Size = new System.Drawing.Size(333, 21);
            this.cboTramo.TabIndex = 0;
            this.cboTramo.SelectedIndexChanged += new System.EventHandler(this.cboTramo_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(113, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tramo:";
            // 
            // txtNombreTramo
            // 
            this.txtNombreTramo.Location = new System.Drawing.Point(156, 19);
            this.txtNombreTramo.Name = "txtNombreTramo";
            this.txtNombreTramo.Size = new System.Drawing.Size(333, 20);
            this.txtNombreTramo.TabIndex = 0;
            // 
            // txtAtrasoMinimo
            // 
            this.txtAtrasoMinimo.Location = new System.Drawing.Point(156, 116);
            this.txtAtrasoMinimo.Name = "txtAtrasoMinimo";
            this.txtAtrasoMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtAtrasoMinimo.TabIndex = 3;
            // 
            // txtAtrasoMaximo
            // 
            this.txtAtrasoMaximo.Location = new System.Drawing.Point(389, 116);
            this.txtAtrasoMaximo.Name = "txtAtrasoMaximo";
            this.txtAtrasoMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtAtrasoMaximo.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(284, 119);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Atraso máximo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(58, 92);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(92, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Tipo de tramo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(34, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(116, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Nombre del tramo:";
            // 
            // txtDescripcionTramo
            // 
            this.txtDescripcionTramo.Location = new System.Drawing.Point(156, 45);
            this.txtDescripcionTramo.Multiline = true;
            this.txtDescripcionTramo.Name = "txtDescripcionTramo";
            this.txtDescripcionTramo.Size = new System.Drawing.Size(333, 38);
            this.txtDescripcionTramo.TabIndex = 1;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 48);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(137, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Descripción del tramo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(55, 119);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(95, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Atraso minimo:";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(156, 142);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 5;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // cboTipoTramo
            // 
            this.cboTipoTramo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTramo.FormattingEnabled = true;
            this.cboTipoTramo.Location = new System.Drawing.Point(156, 89);
            this.cboTipoTramo.Name = "cboTipoTramo";
            this.cboTipoTramo.Size = new System.Drawing.Size(333, 21);
            this.cboTipoTramo.TabIndex = 2;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(258, 214);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(324, 214);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(391, 214);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(457, 214);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbDatosTramo
            // 
            this.grbDatosTramo.Controls.Add(this.txtNombreTramo);
            this.grbDatosTramo.Controls.Add(this.txtAtrasoMinimo);
            this.grbDatosTramo.Controls.Add(this.txtAtrasoMaximo);
            this.grbDatosTramo.Controls.Add(this.cboTipoTramo);
            this.grbDatosTramo.Controls.Add(this.lblBase2);
            this.grbDatosTramo.Controls.Add(this.chcVigente);
            this.grbDatosTramo.Controls.Add(this.lblBase3);
            this.grbDatosTramo.Controls.Add(this.lblBase6);
            this.grbDatosTramo.Controls.Add(this.lblBase4);
            this.grbDatosTramo.Controls.Add(this.lblBase5);
            this.grbDatosTramo.Controls.Add(this.txtDescripcionTramo);
            this.grbDatosTramo.Location = new System.Drawing.Point(12, 34);
            this.grbDatosTramo.Name = "grbDatosTramo";
            this.grbDatosTramo.Size = new System.Drawing.Size(505, 174);
            this.grbDatosTramo.TabIndex = 1;
            this.grbDatosTramo.TabStop = false;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(192, 214);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // frmMantTramos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 303);
            this.Controls.Add(this.cboTramo);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbDatosTramo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnEditar1);
            this.Name = "frmMantTramos";
            this.Text = "Mantenimiento de tramos";
            this.Load += new System.EventHandler(this.frmMantTramos_Load);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbDatosTramo, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTramo, 0);
            this.grbDatosTramo.ResumeLayout(false);
            this.grbDatosTramo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTramo cboTramo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombreTramo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrasoMinimo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrasoMaximo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtDescripcionTramo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.cboTipoTramo cboTipoTramo;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.GroupBox grbDatosTramo;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
    }
}