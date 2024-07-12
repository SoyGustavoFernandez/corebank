namespace CRE.Presentacion
{
    partial class frmMantCheckListEvalCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantCheckListEvalCre));
            this.dtgListaDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.conProducto1 = new GEN.ControlesBase.conProducto();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaDocumentos
            // 
            this.dtgListaDocumentos.AllowUserToAddRows = false;
            this.dtgListaDocumentos.AllowUserToDeleteRows = false;
            this.dtgListaDocumentos.AllowUserToResizeColumns = false;
            this.dtgListaDocumentos.AllowUserToResizeRows = false;
            this.dtgListaDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDocumentos.Location = new System.Drawing.Point(10, 113);
            this.dtgListaDocumentos.MultiSelect = false;
            this.dtgListaDocumentos.Name = "dtgListaDocumentos";
            this.dtgListaDocumentos.ReadOnly = true;
            this.dtgListaDocumentos.RowHeadersVisible = false;
            this.dtgListaDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDocumentos.Size = new System.Drawing.Size(645, 491);
            this.dtgListaDocumentos.TabIndex = 61;
            this.dtgListaDocumentos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaDocumentos_CellValueChanged);
            this.dtgListaDocumentos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgListaDocumentos_CurrentCellDirtyStateChanged);
            // 
            // conProducto1
            // 
            this.conProducto1.Location = new System.Drawing.Point(14, 9);
            this.conProducto1.Name = "conProducto1";
            this.conProducto1.Size = new System.Drawing.Size(374, 98);
            this.conProducto1.TabIndex = 62;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(399, 610);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 6;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(465, 610);
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
            this.btnGrabar1.Location = new System.Drawing.Point(531, 610);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(596, 610);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(399, 57);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 63;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // frmMantCheckListEvalCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 699);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.conProducto1);
            this.Controls.Add(this.dtgListaDocumentos);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMantCheckListEvalCre";
            this.Text = "Mantenimiento de check list - Créditos";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.dtgListaDocumentos, 0);
            this.Controls.SetChildIndex(this.conProducto1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.dtgBase dtgListaDocumentos;
        private GEN.ControlesBase.conProducto conProducto1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
    }
}

