namespace GEN.ControlesBase
{
    partial class frmManTipoAutorizacionBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTipoAutorizacionBase));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTiempoVigencia = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTipoAutorizacion = new GEN.ControlesBase.txtBase(this.components);
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgTipoAutorizacion = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cprogressbar = new CircularProgressBar.CircularProgressBar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoAutorizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtTiempoVigencia);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtTipoAutorizacion);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(10, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(477, 68);
            this.grbBase1.TabIndex = 18;
            this.grbBase1.TabStop = false;
            // 
            // txtTiempoVigencia
            // 
            this.txtTiempoVigencia.FormatoDecimal = false;
            this.txtTiempoVigencia.Location = new System.Drawing.Point(116, 37);
            this.txtTiempoVigencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtTiempoVigencia.Name = "txtTiempoVigencia";
            this.txtTiempoVigencia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTiempoVigencia.nNumDecimales = 0;
            this.txtTiempoVigencia.nvalor = 0D;
            this.txtTiempoVigencia.Size = new System.Drawing.Size(56, 20);
            this.txtTiempoVigencia.TabIndex = 45;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(177, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 44;
            this.lblBase2.Text = "años";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 39);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 43;
            this.lblBase1.Text = "Tiempo vigencia:";
            // 
            // txtTipoAutorizacion
            // 
            this.txtTipoAutorizacion.Location = new System.Drawing.Point(116, 15);
            this.txtTipoAutorizacion.Name = "txtTipoAutorizacion";
            this.txtTipoAutorizacion.Size = new System.Drawing.Size(285, 20);
            this.txtTipoAutorizacion.TabIndex = 40;
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.Location = new System.Drawing.Point(342, 39);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 4;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(109, 13);
            this.lblBase5.TabIndex = 38;
            this.lblBase5.Text = "Tipo autorización:";
            // 
            // dtgTipoAutorizacion
            // 
            this.dtgTipoAutorizacion.AllowUserToAddRows = false;
            this.dtgTipoAutorizacion.AllowUserToDeleteRows = false;
            this.dtgTipoAutorizacion.AllowUserToResizeColumns = false;
            this.dtgTipoAutorizacion.AllowUserToResizeRows = false;
            this.dtgTipoAutorizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTipoAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoAutorizacion.Location = new System.Drawing.Point(10, 85);
            this.dtgTipoAutorizacion.MultiSelect = false;
            this.dtgTipoAutorizacion.Name = "dtgTipoAutorizacion";
            this.dtgTipoAutorizacion.ReadOnly = true;
            this.dtgTipoAutorizacion.RowHeadersVisible = false;
            this.dtgTipoAutorizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoAutorizacion.Size = new System.Drawing.Size(477, 318);
            this.dtgTipoAutorizacion.TabIndex = 19;
            this.dtgTipoAutorizacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoAutorizacion_CellContentClick);
            this.dtgTipoAutorizacion.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoAutorizacion_RowEnter);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(256, 419);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(194, 419);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(442, 419);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(317, 419);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(380, 419);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cprogressbar
            // 
            this.cprogressbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cprogressbar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cprogressbar.AnimationSpeed = 500;
            this.cprogressbar.BackColor = System.Drawing.Color.Transparent;
            this.cprogressbar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cprogressbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cprogressbar.InnerColor = System.Drawing.Color.White;
            this.cprogressbar.InnerMargin = 0;
            this.cprogressbar.InnerWidth = 0;
            this.cprogressbar.Location = new System.Drawing.Point(160, 156);
            this.cprogressbar.MarqueeAnimationSpeed = 2000;
            this.cprogressbar.Name = "cprogressbar";
            this.cprogressbar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cprogressbar.OuterMargin = -11;
            this.cprogressbar.OuterWidth = 8;
            this.cprogressbar.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.cprogressbar.ProgressWidth = 14;
            this.cprogressbar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F);
            this.cprogressbar.Size = new System.Drawing.Size(180, 180);
            this.cprogressbar.StartAngle = 270;
            this.cprogressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cprogressbar.SubscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SubscriptText = "";
            this.cprogressbar.SuperscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SuperscriptText = "";
            this.cprogressbar.TabIndex = 20;
            this.cprogressbar.Text = "Procesando";
            this.cprogressbar.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.cprogressbar.Value = 67;
            this.cprogressbar.Visible = false;
            // 
            // frmManTipoAutorizacionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 493);
            this.Controls.Add(this.cprogressbar);
            this.Controls.Add(this.dtgTipoAutorizacion);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManTipoAutorizacionBase";
            this.Text = "Mantenimiento tipo autorización";
            this.Load += new System.EventHandler(this.frmManTipoAutorizacion_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgTipoAutorizacion, 0);
            this.Controls.SetChildIndex(this.cprogressbar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoAutorizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtTipoAutorizacion;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgTipoAutorizacion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtTiempoVigencia;
        private CircularProgressBar.CircularProgressBar cprogressbar;
    }
}