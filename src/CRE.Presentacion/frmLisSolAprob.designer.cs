namespace CRE.Presentacion
{
    partial class frmLisSolAprob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLisSolAprob));
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboEstadoSolicitud = new System.Windows.Forms.ComboBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(5, 42);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(961, 199);
            this.dtgBase1.TabIndex = 2;
            this.dtgBase1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgBase1_ColumnHeaderMouseClick);
            this.dtgBase1.SelectionChanged += new System.EventHandler(this.dtgBase1_SelectionChanged);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(842, 247);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(908, 247);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(634, 12);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(332, 21);
            this.cboEstadoSolicitud.TabIndex = 47;
            this.cboEstadoSolicitud.SelectedIndexChanged += new System.EventHandler(this.cboEstadoSolicitud_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(478, 15);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(120, 13);
            this.lblBase6.TabIndex = 46;
            this.lblBase6.Text = "Estado de Solicitud:";
            // 
            // frmLisSolAprob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 322);
            this.Controls.Add(this.cboEstadoSolicitud);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLisSolAprob";
            this.Text = "Listado de Solicitudes Aprobadas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboEstadoSolicitud, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.ComboBox cboEstadoSolicitud;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}

