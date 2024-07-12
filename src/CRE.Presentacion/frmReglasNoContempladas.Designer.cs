namespace CRE.Presentacion
{
    partial class frmReglasNoContempladas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReglasNoContempladas));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnBusSolicitud1 = new GEN.BotonesBase.btnBusSolicitud();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnOtrasRNC = new GEN.BotonesBase.Boton();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnDetalle1 = new GEN.BotonesBase.btnDetalle();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNombreRegla = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtIdRegla = new GEN.ControlesBase.txtBase(this.components);
            this.btnSolicitar1 = new GEN.BotonesBase.btnSolicitar();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.txtNumerico1 = new GEN.ControlesBase.txtNumerico(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Código Solicitud:";
            // 
            // btnBusSolicitud1
            // 
            this.btnBusSolicitud1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusSolicitud1.BackgroundImage")));
            this.btnBusSolicitud1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusSolicitud1.Location = new System.Drawing.Point(652, 6);
            this.btnBusSolicitud1.Name = "btnBusSolicitud1";
            this.btnBusSolicitud1.Size = new System.Drawing.Size(60, 50);
            this.btnBusSolicitud1.TabIndex = 7;
            this.btnBusSolicitud1.Text = "&Buscar Solicitud";
            this.btnBusSolicitud1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusSolicitud1.UseVisualStyleBackColor = true;
            this.btnBusSolicitud1.Click += new System.EventHandler(this.btnBusSolicitud1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnCancelar1);
            this.grbBase1.Controls.Add(this.btnOtrasRNC);
            this.grbBase1.Controls.Add(this.btnSalir1);
            this.grbBase1.Controls.Add(this.btnImprimir1);
            this.grbBase1.Controls.Add(this.btnDetalle1);
            this.grbBase1.Controls.Add(this.txtSustento);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtNombreRegla);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtIdRegla);
            this.grbBase1.Controls.Add(this.btnSolicitar1);
            this.grbBase1.Controls.Add(this.dtgBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 62);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(719, 305);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Reglas de la solicitud";
            // 
            // btnOtrasRNC
            // 
            this.btnOtrasRNC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOtrasRNC.Location = new System.Drawing.Point(9, 247);
            this.btnOtrasRNC.Name = "btnOtrasRNC";
            this.btnOtrasRNC.Size = new System.Drawing.Size(60, 50);
            this.btnOtrasRNC.TabIndex = 19;
            this.btnOtrasRNC.Text = "Otras RNC";
            this.btnOtrasRNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOtrasRNC.UseVisualStyleBackColor = true;
            this.btnOtrasRNC.Click += new System.EventHandler(this.boton1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(640, 247);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 18;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(376, 247);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 17;
            this.btnImprimir1.Text = "Reporte";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnDetalle1
            // 
            this.btnDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle1.BackgroundImage")));
            this.btnDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle1.Location = new System.Drawing.Point(442, 247);
            this.btnDetalle1.Name = "btnDetalle1";
            this.btnDetalle1.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle1.TabIndex = 16;
            this.btnDetalle1.Text = "&Detallar";
            this.btnDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle1.texto = "&Detallar";
            this.btnDetalle1.UseVisualStyleBackColor = true;
            this.btnDetalle1.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(69, 159);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(631, 82);
            this.txtSustento.TabIndex = 9;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 159);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(62, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Sustento:";
            // 
            // txtNombreRegla
            // 
            this.txtNombreRegla.Enabled = false;
            this.txtNombreRegla.Location = new System.Drawing.Point(134, 137);
            this.txtNombreRegla.MaxLength = 300;
            this.txtNombreRegla.Name = "txtNombreRegla";
            this.txtNombreRegla.Size = new System.Drawing.Size(566, 20);
            this.txtNombreRegla.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 137);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 10;
            this.lblBase4.Text = "Regla:";
            // 
            // txtIdRegla
            // 
            this.txtIdRegla.Enabled = false;
            this.txtIdRegla.Location = new System.Drawing.Point(69, 137);
            this.txtIdRegla.Name = "txtIdRegla";
            this.txtIdRegla.Size = new System.Drawing.Size(63, 20);
            this.txtIdRegla.TabIndex = 9;
            // 
            // btnSolicitar1
            // 
            this.btnSolicitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitar1.BackgroundImage")));
            this.btnSolicitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolicitar1.Location = new System.Drawing.Point(508, 247);
            this.btnSolicitar1.Name = "btnSolicitar1";
            this.btnSolicitar1.Size = new System.Drawing.Size(60, 50);
            this.btnSolicitar1.TabIndex = 10;
            this.btnSolicitar1.Text = "Solicitar";
            this.btnSolicitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolicitar1.UseVisualStyleBackColor = true;
            this.btnSolicitar1.Click += new System.EventHandler(this.btnSolicitar1_Click);
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(12, 19);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(688, 115);
            this.dtgBase1.TabIndex = 9;
            this.dtgBase1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellEnter);
            // 
            // txtNumerico1
            // 
            this.txtNumerico1.Format = "n2";
            this.txtNumerico1.Location = new System.Drawing.Point(134, 26);
            this.txtNumerico1.Name = "txtNumerico1";
            this.txtNumerico1.Size = new System.Drawing.Size(100, 20);
            this.txtNumerico1.TabIndex = 9;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(574, 247);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 20;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmReglasNoContempladas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 401);
            this.Controls.Add(this.txtNumerico1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusSolicitud1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmReglasNoContempladas";
            this.Text = "frmReglasNoContempladas";
            this.Load += new System.EventHandler(this.frmReglasNoContempladas_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnBusSolicitud1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtNumerico1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusSolicitud btnBusSolicitud1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtIdRegla;
        private GEN.BotonesBase.btnSolicitar btnSolicitar1;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.txtNumerico txtNumerico1;
        private GEN.ControlesBase.txtBase txtNombreRegla;
        private GEN.BotonesBase.btnDetalle btnDetalle1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.Boton btnOtrasRNC;
        private GEN.BotonesBase.btnCancelar btnCancelar1;


    }
}