namespace GEN.ControlesBase
{
    partial class frmSelAutTratamientoDatosBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelAutTratamientoDatosBase));
            this.dtgDatoAutorizacion = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.cprogressbar = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoAutorizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatoAutorizacion
            // 
            this.dtgDatoAutorizacion.AllowUserToAddRows = false;
            this.dtgDatoAutorizacion.AllowUserToDeleteRows = false;
            this.dtgDatoAutorizacion.AllowUserToResizeColumns = false;
            this.dtgDatoAutorizacion.AllowUserToResizeRows = false;
            this.dtgDatoAutorizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgDatoAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatoAutorizacion.Location = new System.Drawing.Point(10, 10);
            this.dtgDatoAutorizacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtgDatoAutorizacion.MultiSelect = false;
            this.dtgDatoAutorizacion.Name = "dtgDatoAutorizacion";
            this.dtgDatoAutorizacion.ReadOnly = true;
            this.dtgDatoAutorizacion.RowHeadersVisible = false;
            this.dtgDatoAutorizacion.RowTemplate.Height = 24;
            this.dtgDatoAutorizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatoAutorizacion.Size = new System.Drawing.Size(558, 127);
            this.dtgDatoAutorizacion.TabIndex = 1;
            this.dtgDatoAutorizacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatoAutorizacion_CellContentClick);
            this.dtgDatoAutorizacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatoAutorizacion_CellEndEdit);
            this.dtgDatoAutorizacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatoAutorizacion_CellEnter);
            this.dtgDatoAutorizacion.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatoAutorizacion_RowEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(508, 140);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(444, 140);
            this.btnAceptar1.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 10;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
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
            this.cprogressbar.Location = new System.Drawing.Point(212, 11);
            this.cprogressbar.MarqueeAnimationSpeed = 2000;
            this.cprogressbar.Name = "cprogressbar";
            this.cprogressbar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cprogressbar.OuterMargin = -11;
            this.cprogressbar.OuterWidth = 8;
            this.cprogressbar.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.cprogressbar.ProgressWidth = 14;
            this.cprogressbar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F);
            this.cprogressbar.Size = new System.Drawing.Size(126, 125);
            this.cprogressbar.StartAngle = 270;
            this.cprogressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cprogressbar.SubscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SubscriptText = "";
            this.cprogressbar.SuperscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SuperscriptText = "";
            this.cprogressbar.TabIndex = 21;
            this.cprogressbar.Text = "Buscando";
            this.cprogressbar.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.cprogressbar.Value = 67;
            this.cprogressbar.Visible = false;
            // 
            // frmSelAutTratamientoDatosBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 222);
            this.Controls.Add(this.cprogressbar);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgDatoAutorizacion);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSelAutTratamientoDatosBase";
            this.Text = "Seleccione autorización de uso de datos";
            this.Load += new System.EventHandler(this.frmSelAutTratamientoDatosBase_Load);
            this.Controls.SetChildIndex(this.dtgDatoAutorizacion, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.cprogressbar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoAutorizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgDatoAutorizacion;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private CircularProgressBar.CircularProgressBar cprogressbar;
    }
}