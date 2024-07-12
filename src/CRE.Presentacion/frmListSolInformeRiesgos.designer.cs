namespace CRE.Presentacion
{
    partial class frmListSolInformeRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListSolInformeRiesgos));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgSolInformeRiesgos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgSolInformeRiesgosTodos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblPersonal = new GEN.ControlesBase.lblBase();
            this.btnAsignarse = new GEN.BotonesBase.btnBlanco();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolInformeRiesgos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolInformeRiesgosTodos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 4);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(270, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Solicitudes de Informe de riesgos pendientes:";
            // 
            // dtgSolInformeRiesgos
            // 
            this.dtgSolInformeRiesgos.AllowUserToAddRows = false;
            this.dtgSolInformeRiesgos.AllowUserToDeleteRows = false;
            this.dtgSolInformeRiesgos.AllowUserToResizeColumns = false;
            this.dtgSolInformeRiesgos.AllowUserToResizeRows = false;
            this.dtgSolInformeRiesgos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgSolInformeRiesgos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolInformeRiesgos.Location = new System.Drawing.Point(12, 322);
            this.dtgSolInformeRiesgos.MultiSelect = false;
            this.dtgSolInformeRiesgos.Name = "dtgSolInformeRiesgos";
            this.dtgSolInformeRiesgos.ReadOnly = true;
            this.dtgSolInformeRiesgos.RowHeadersVisible = false;
            this.dtgSolInformeRiesgos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolInformeRiesgos.Size = new System.Drawing.Size(1268, 240);
            this.dtgSolInformeRiesgos.TabIndex = 5;
            this.dtgSolInformeRiesgos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolInformeRiesgos_CellContentClick);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(1151, 568);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 8;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(1217, 568);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgSolInformeRiesgosTodos
            // 
            this.dtgSolInformeRiesgosTodos.AllowUserToAddRows = false;
            this.dtgSolInformeRiesgosTodos.AllowUserToDeleteRows = false;
            this.dtgSolInformeRiesgosTodos.AllowUserToResizeColumns = false;
            this.dtgSolInformeRiesgosTodos.AllowUserToResizeRows = false;
            this.dtgSolInformeRiesgosTodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgSolInformeRiesgosTodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolInformeRiesgosTodos.Location = new System.Drawing.Point(9, 20);
            this.dtgSolInformeRiesgosTodos.MultiSelect = false;
            this.dtgSolInformeRiesgosTodos.Name = "dtgSolInformeRiesgosTodos";
            this.dtgSolInformeRiesgosTodos.ReadOnly = true;
            this.dtgSolInformeRiesgosTodos.RowHeadersVisible = false;
            this.dtgSolInformeRiesgosTodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolInformeRiesgosTodos.Size = new System.Drawing.Size(1268, 283);
            this.dtgSolInformeRiesgosTodos.TabIndex = 9;
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPersonal.ForeColor = System.Drawing.Color.Navy;
            this.lblPersonal.Location = new System.Drawing.Point(12, 306);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(107, 13);
            this.lblPersonal.TabIndex = 10;
            this.lblPersonal.Text = "Bandeja Personal";
            // 
            // btnAsignarse
            // 
            this.btnAsignarse.BackgroundImage = global::CRE.Presentacion.Properties.Resources.add;
            this.btnAsignarse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAsignarse.Location = new System.Drawing.Point(9, 568);
            this.btnAsignarse.Name = "btnAsignarse";
            this.btnAsignarse.Size = new System.Drawing.Size(60, 50);
            this.btnAsignarse.TabIndex = 11;
            this.btnAsignarse.Text = "Asinarse";
            this.btnAsignarse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignarse.UseVisualStyleBackColor = true;
            this.btnAsignarse.Click += new System.EventHandler(this.btnAsignarse_Click);
            // 
            // frmListSolInformeRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 643);
            this.Controls.Add(this.btnAsignarse);
            this.Controls.Add(this.lblPersonal);
            this.Controls.Add(this.dtgSolInformeRiesgosTodos);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgSolInformeRiesgos);
            this.Name = "frmListSolInformeRiesgos";
            this.Text = "Lista de Solicitudes de Informe de Riesgos";
            this.Load += new System.EventHandler(this.frmListSolInformeRiesgos_Load);
            this.Controls.SetChildIndex(this.dtgSolInformeRiesgos, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.dtgSolInformeRiesgosTodos, 0);
            this.Controls.SetChildIndex(this.lblPersonal, 0);
            this.Controls.SetChildIndex(this.btnAsignarse, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolInformeRiesgos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolInformeRiesgosTodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgSolInformeRiesgos;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.ControlesBase.dtgBase dtgSolInformeRiesgosTodos;
        private GEN.ControlesBase.lblBase lblPersonal;
        private GEN.BotonesBase.btnBlanco btnAsignarse;
    }
}