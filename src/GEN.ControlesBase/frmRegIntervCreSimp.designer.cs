namespace GEN.ControlesBase
{
    partial class frmRegIntervCreSimp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegIntervCreSimp));
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoIntervCre1 = new GEN.ControlesBase.cboTipoIntervCre(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(8, 9);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(683, 100);
            this.conBusCuentaCli1.TabIndex = 2;
            this.conBusCuentaCli1.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli1_MyKey);
            this.conBusCuentaCli1.MyClic += new System.EventHandler(this.conBusCuentaCli1_MyClic);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoIntervCre1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.dtgBase1);
            this.grbBase1.Controls.Add(this.btnQuitar1);
            this.grbBase1.Controls.Add(this.btnAgregar1);
            this.grbBase1.Controls.Add(this.conBusCli1);
            this.grbBase1.Location = new System.Drawing.Point(8, 115);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(683, 298);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Registro de Intervinientes";
            // 
            // cboTipoIntervCre1
            // 
            this.cboTipoIntervCre1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIntervCre1.Enabled = false;
            this.cboTipoIntervCre1.FormattingEnabled = true;
            this.cboTipoIntervCre1.Location = new System.Drawing.Point(176, 108);
            this.cboTipoIntervCre1.Name = "cboTipoIntervCre1";
            this.cboTipoIntervCre1.Size = new System.Drawing.Size(179, 21);
            this.cboTipoIntervCre1.TabIndex = 10;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(23, 112);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(130, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Tipo de Intervención:";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(13, 138);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(592, 154);
            this.dtgBase1.TabIndex = 7;
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Enabled = false;
            this.btnQuitar1.Location = new System.Drawing.Point(611, 199);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 6;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(611, 138);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 5;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 19);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(665, 83);
            this.conBusCli1.TabIndex = 4;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(619, 419);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(556, 419);
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
            this.btnGrabar1.Location = new System.Drawing.Point(493, 419);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(20, 433);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 7;
            this.pbxAyuda1.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxAyuda1, "Para el caso de productos convenio y carta fianza se permite quitar al cónyugue,\r" +
        "\npara otros casos debe consultar con su inmediato superior");
            // 
            // FrmRegIntervieneCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 494);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegIntervCreSimp";
            this.Text = "Registro de Intervinientes en el Crédito";
            this.Load += new System.EventHandler(this.FrmRegIntervieneCre_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboTipoIntervCre cboTipoIntervCre1;
        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}