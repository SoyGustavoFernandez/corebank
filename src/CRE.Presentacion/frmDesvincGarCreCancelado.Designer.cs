namespace CRE.Presentacion
{
    partial class frmDesvincGarCreCancelado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesvincGarCreCancelado));
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAnular1 = new GEN.BotonesBase.btnAnular();
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.conBusCli1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(20, 427);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 24;
            this.pbxAyuda1.TabStop = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 134);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(272, 13);
            this.lblBase2.TabIndex = 21;
            this.lblBase2.Text = "Créditos cancelados con garantías vinculadas:";
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(46, 425);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(253, 35);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Solo puede realizar la desvinculación de créditos con garantías vinculadas";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 292);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(131, 13);
            this.lblBase1.TabIndex = 23;
            this.lblBase1.Text = "Garantías vinculadas:";
            // 
            // btnAnular1
            // 
            this.btnAnular1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular1.BackgroundImage")));
            this.btnAnular1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular1.Enabled = false;
            this.btnAnular1.Location = new System.Drawing.Point(420, 425);
            this.btnAnular1.Name = "btnAnular1";
            this.btnAnular1.Size = new System.Drawing.Size(60, 50);
            this.btnAnular1.TabIndex = 20;
            this.btnAnular1.Text = "Anu&lar";
            this.btnAnular1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular1.UseVisualStyleBackColor = true;
            this.btnAnular1.Click += new System.EventHandler(this.btnAnular1_Click);
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgGarantias.Location = new System.Drawing.Point(12, 308);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(532, 101);
            this.dtgGarantias.TabIndex = 19;
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Location = new System.Drawing.Point(12, 150);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(532, 139);
            this.dtgSolicitudes.TabIndex = 18;
            this.dtgSolicitudes.SelectionChanged += new System.EventHandler(this.dtgSolicitudes_SelectionChanged);
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.Controls.Add(this.txtCodInst);
            this.conBusCli1.Controls.Add(this.txtCodAge);
            this.conBusCli1.Controls.Add(this.txtDireccion);
            this.conBusCli1.Controls.Add(this.txtCodCli);
            this.conBusCli1.Controls.Add(this.txtNombre);
            this.conBusCli1.Controls.Add(this.txtNroDoc);
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 17;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(354, 425);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 16;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(484, 425);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 15;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmDesvincGarCreCancelado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 503);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAnular1);
            this.Controls.Add(this.dtgGarantias);
            this.Controls.Add(this.dtgSolicitudes);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmDesvincGarCreCancelado";
            this.Text = "Desvinculación de creditos con garantias";
            this.Load += new System.EventHandler(this.frmDesvincGarCreCancelado_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.dtgSolicitudes, 0);
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.btnAnular1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.conBusCli1.ResumeLayout(false);
            this.conBusCli1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnAnular btnAnular1;
        private GEN.ControlesBase.dtgBase dtgGarantias;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}