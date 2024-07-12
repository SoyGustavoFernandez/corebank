namespace CRE.Presentacion
{
    partial class frmTrackingRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrackingRiesgos));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstSolCred = new GEN.ControlesBase.cboEstSolCred();
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtCodigoSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodCliente = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.dtgOpinionRiesgos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblNombSol = new System.Windows.Forms.Label();
            this.tbRiesgos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgExcepcionCanal = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDoc = new System.Windows.Forms.Label();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOpinionRiesgos)).BeginInit();
            this.tbRiesgos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepcionCanal)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEstSolCred);
            this.grbBase2.Controls.Add(this.btnBusCliente);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtCodigoSol);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtCodCliente);
            this.grbBase2.Controls.Add(this.lblBase23);
            this.grbBase2.Location = new System.Drawing.Point(12, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(387, 98);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "DATOS DE CLIENTE";
            // 
            // cboEstSolCred
            // 
            this.cboEstSolCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstSolCred.FormattingEnabled = true;
            this.cboEstSolCred.Location = new System.Drawing.Point(115, 71);
            this.cboEstSolCred.Name = "cboEstSolCred";
            this.cboEstSolCred.Size = new System.Drawing.Size(198, 21);
            this.cboEstSolCred.TabIndex = 180;
            this.cboEstSolCred.SelectedIndexChanged += new System.EventHandler(this.cboEstSolCred_SelectedIndexChanged);
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(319, 15);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 179;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 74);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(96, 13);
            this.lblBase2.TabIndex = 177;
            this.lblBase2.Text = "Estado Crédito:";
            // 
            // txtCodigoSol
            // 
            this.txtCodigoSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigoSol.Location = new System.Drawing.Point(115, 45);
            this.txtCodigoSol.MaxLength = 9;
            this.txtCodigoSol.Name = "txtCodigoSol";
            this.txtCodigoSol.Size = new System.Drawing.Size(198, 20);
            this.txtCodigoSol.TabIndex = 10;
            this.txtCodigoSol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSol_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Num. Solicitud:";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodCliente.Location = new System.Drawing.Point(115, 19);
            this.txtCodCliente.MaxLength = 9;
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(198, 20);
            this.txtCodCliente.TabIndex = 3;
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodCliente_KeyPress);
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(13, 22);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(96, 13);
            this.lblBase23.TabIndex = 0;
            this.lblBase23.Text = "Código Cliente:";
            // 
            // dtgOpinionRiesgos
            // 
            this.dtgOpinionRiesgos.AllowUserToAddRows = false;
            this.dtgOpinionRiesgos.AllowUserToDeleteRows = false;
            this.dtgOpinionRiesgos.AllowUserToResizeRows = false;
            this.dtgOpinionRiesgos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOpinionRiesgos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOpinionRiesgos.Location = new System.Drawing.Point(6, 3);
            this.dtgOpinionRiesgos.MultiSelect = false;
            this.dtgOpinionRiesgos.Name = "dtgOpinionRiesgos";
            this.dtgOpinionRiesgos.ReadOnly = true;
            this.dtgOpinionRiesgos.RowHeadersVisible = false;
            this.dtgOpinionRiesgos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOpinionRiesgos.Size = new System.Drawing.Size(796, 337);
            this.dtgOpinionRiesgos.TabIndex = 156;
            this.dtgOpinionRiesgos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgOpinionRiesgos_CellContentClick);
            this.dtgOpinionRiesgos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgOpinionRiesgos_CellFormatting);
            this.dtgOpinionRiesgos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgOpinionRiesgos_CellPainting);
            // 
            // lblNombSol
            // 
            this.lblNombSol.AutoSize = true;
            this.lblNombSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombSol.Location = new System.Drawing.Point(405, 30);
            this.lblNombSol.Name = "lblNombSol";
            this.lblNombSol.Size = new System.Drawing.Size(69, 17);
            this.lblNombSol.TabIndex = 171;
            this.lblNombSol.Text = "Nombre:";
            // 
            // tbRiesgos
            // 
            this.tbRiesgos.Controls.Add(this.tabPage1);
            this.tbRiesgos.Controls.Add(this.tabPage2);
            this.tbRiesgos.Location = new System.Drawing.Point(12, 116);
            this.tbRiesgos.Name = "tbRiesgos";
            this.tbRiesgos.SelectedIndex = 0;
            this.tbRiesgos.Size = new System.Drawing.Size(817, 372);
            this.tbRiesgos.TabIndex = 173;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgOpinionRiesgos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Opinión de Riesgos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgExcepcionCanal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Excepciones Canal de Riesgos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgExcepcionCanal
            // 
            this.dtgExcepcionCanal.AllowUserToAddRows = false;
            this.dtgExcepcionCanal.AllowUserToDeleteRows = false;
            this.dtgExcepcionCanal.AllowUserToResizeColumns = false;
            this.dtgExcepcionCanal.AllowUserToResizeRows = false;
            this.dtgExcepcionCanal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExcepcionCanal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcepcionCanal.Location = new System.Drawing.Point(6, 3);
            this.dtgExcepcionCanal.MultiSelect = false;
            this.dtgExcepcionCanal.Name = "dtgExcepcionCanal";
            this.dtgExcepcionCanal.ReadOnly = true;
            this.dtgExcepcionCanal.RowHeadersVisible = false;
            this.dtgExcepcionCanal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcepcionCanal.Size = new System.Drawing.Size(796, 337);
            this.dtgExcepcionCanal.TabIndex = 157;
            this.dtgExcepcionCanal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExcepcionCanal_CellContentClick);
            this.dtgExcepcionCanal.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgExcepcionCanal_CellFormatting);
            this.dtgExcepcionCanal.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgExcepcionCanal_CellPainting);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(765, 494);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 174;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(699, 494);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 175;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 176;
            this.label1.Text = "Documento:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(508, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 17);
            this.lblNombre.TabIndex = 177;
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoc.Location = new System.Drawing.Point(508, 56);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(0, 17);
            this.lblDoc.TabIndex = 178;
            // 
            // frmTrackingRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 572);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.tbRiesgos);
            this.Controls.Add(this.lblNombSol);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmTrackingRiesgos";
            this.Text = "Tracking de Riesgos";
            this.Load += new System.EventHandler(this.frmTrackingRiesgos_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblNombSol, 0);
            this.Controls.SetChildIndex(this.tbRiesgos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblDoc, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOpinionRiesgos)).EndInit();
            this.tbRiesgos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepcionCanal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCliente;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgOpinionRiesgos;
        private System.Windows.Forms.Label lblNombSol;
        private System.Windows.Forms.TabControl tbRiesgos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigoSol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDoc;
        private GEN.ControlesBase.dtgBase dtgExcepcionCanal;
        private GEN.BotonesBase.btnBusCliente btnBusCliente;
        private GEN.ControlesBase.cboEstSolCred cboEstSolCred;

    }
}