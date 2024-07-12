namespace RSG.Presentacion
{
    partial class frmMantenCalificativoSobredeuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenCalificativoSobredeuda));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAlerta = new GEN.ControlesBase.chcBase(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.dtgCalificacion = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(386, 284);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 32;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(254, 284);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 31;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(452, 284);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 30;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(188, 284);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 28;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(320, 284);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 29;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcAlerta);
            this.grbBase1.Controls.Add(this.chcVigencia);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNombre);
            this.grbBase1.Location = new System.Drawing.Point(12, 213);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(500, 65);
            this.grbBase1.TabIndex = 27;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de calificación";
            // 
            // chcAlerta
            // 
            this.chcAlerta.AutoSize = true;
            this.chcAlerta.Location = new System.Drawing.Point(68, 42);
            this.chcAlerta.Name = "chcAlerta";
            this.chcAlerta.Size = new System.Drawing.Size(82, 17);
            this.chcAlerta.TabIndex = 70;
            this.chcAlerta.Text = "Es de alerta";
            this.chcAlerta.UseVisualStyleBackColor = true;
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Location = new System.Drawing.Point(427, 18);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(67, 17);
            this.chcVigencia.TabIndex = 69;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(68, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(330, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // dtgCalificacion
            // 
            this.dtgCalificacion.AllowUserToAddRows = false;
            this.dtgCalificacion.AllowUserToDeleteRows = false;
            this.dtgCalificacion.AllowUserToResizeColumns = false;
            this.dtgCalificacion.AllowUserToResizeRows = false;
            this.dtgCalificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCalificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCalificacion.Location = new System.Drawing.Point(12, 12);
            this.dtgCalificacion.MultiSelect = false;
            this.dtgCalificacion.Name = "dtgCalificacion";
            this.dtgCalificacion.ReadOnly = true;
            this.dtgCalificacion.RowHeadersVisible = false;
            this.dtgCalificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalificacion.Size = new System.Drawing.Size(500, 195);
            this.dtgCalificacion.TabIndex = 26;
            this.dtgCalificacion.SelectionChanged += new System.EventHandler(this.dtgCalificacion_SelectionChanged);
            // 
            // frmMantenCalificativoSobredeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 361);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgCalificacion);
            this.Name = "frmMantenCalificativoSobredeuda";
            this.Text = "Mantenimiento de calificación de sobreendeudamiento";
            this.Load += new System.EventHandler(this.frmMantenCalificativoSobredeuda_Load);
            this.Controls.SetChildIndex(this.dtgCalificacion, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.dtgBase dtgCalificacion;
        private GEN.ControlesBase.chcBase chcAlerta;
    }
}