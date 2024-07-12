namespace GEN.ControlesBase
{
    partial class FrmBuscaActivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscaActivo));
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgListaActivos = new GEN.ControlesBase.dtgBase(this.components);
            this.idActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.txtCodActivo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNomActivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblCriterio1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaActivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(360, 17);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 13;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(762, 243);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgListaActivos
            // 
            this.dtgListaActivos.AllowUserToAddRows = false;
            this.dtgListaActivos.AllowUserToDeleteRows = false;
            this.dtgListaActivos.AllowUserToResizeColumns = false;
            this.dtgListaActivos.AllowUserToResizeRows = false;
            this.dtgListaActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaActivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idActivo,
            this.idCatalogo,
            this.cProducto,
            this.idGrupoActivo,
            this.cNombreGrupo});
            this.dtgListaActivos.Location = new System.Drawing.Point(9, 83);
            this.dtgListaActivos.MultiSelect = false;
            this.dtgListaActivos.Name = "dtgListaActivos";
            this.dtgListaActivos.ReadOnly = true;
            this.dtgListaActivos.RowHeadersVisible = false;
            this.dtgListaActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaActivos.Size = new System.Drawing.Size(813, 154);
            this.dtgListaActivos.TabIndex = 10;
            // 
            // idActivo
            // 
            this.idActivo.DataPropertyName = "idActivo";
            this.idActivo.FillWeight = 13.43451F;
            this.idActivo.HeaderText = "Cod Activo";
            this.idActivo.Name = "idActivo";
            this.idActivo.ReadOnly = true;
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.FillWeight = 13.43451F;
            this.idCatalogo.HeaderText = "Cod Catálogo";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 44.33471F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // idGrupoActivo
            // 
            this.idGrupoActivo.DataPropertyName = "idGrupoActivo";
            this.idGrupoActivo.HeaderText = "idGrupoActivo";
            this.idGrupoActivo.Name = "idGrupoActivo";
            this.idGrupoActivo.ReadOnly = true;
            this.idGrupoActivo.Visible = false;
            // 
            // cNombreGrupo
            // 
            this.cNombreGrupo.DataPropertyName = "cNombreGrupo";
            this.cNombreGrupo.FillWeight = 37.97048F;
            this.cNombreGrupo.HeaderText = "Sub Grupo";
            this.cNombreGrupo.Name = "cNombreGrupo";
            this.cNombreGrupo.ReadOnly = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(696, 243);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(12, 24);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(91, 13);
            this.lblCriterio.TabIndex = 12;
            this.lblCriterio.Text = "Código Activo:";
            // 
            // txtCodActivo
            // 
            this.txtCodActivo.Location = new System.Drawing.Point(109, 21);
            this.txtCodActivo.Name = "txtCodActivo";
            this.txtCodActivo.Size = new System.Drawing.Size(225, 20);
            this.txtCodActivo.TabIndex = 14;
            this.txtCodActivo.Click += new System.EventHandler(this.txtCodActivo_Click);
            this.txtCodActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodActivo_KeyPress);
            // 
            // txtNomActivo
            // 
            this.txtNomActivo.Location = new System.Drawing.Point(109, 49);
            this.txtNomActivo.Name = "txtNomActivo";
            this.txtNomActivo.Size = new System.Drawing.Size(225, 20);
            this.txtNomActivo.TabIndex = 16;
            this.txtNomActivo.Click += new System.EventHandler(this.txtNomActivo_Click);
            this.txtNomActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomActivo_KeyPress);
            // 
            // lblCriterio1
            // 
            this.lblCriterio1.AutoSize = true;
            this.lblCriterio1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio1.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio1.Location = new System.Drawing.Point(12, 52);
            this.lblCriterio1.Name = "lblCriterio1";
            this.lblCriterio1.Size = new System.Drawing.Size(96, 13);
            this.lblCriterio1.TabIndex = 15;
            this.lblCriterio1.Text = "Nombre Activo:";
            // 
            // FrmBuscaActivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 319);
            this.Controls.Add(this.txtNomActivo);
            this.Controls.Add(this.lblCriterio1);
            this.Controls.Add(this.txtCodActivo);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgListaActivos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCriterio);
            this.Name = "FrmBuscaActivo";
            this.Text = "Busqueda de Activo";
            this.Load += new System.EventHandler(this.FrmBuscaActivo_Load);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtgListaActivos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.txtCodActivo, 0);
            this.Controls.SetChildIndex(this.lblCriterio1, 0);
            this.Controls.SetChildIndex(this.txtNomActivo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnBusqueda btnBusqueda1;
        private BotonesBase.btnSalir btnSalir1;
        private dtgBase dtgListaActivos;
        private BotonesBase.BtnAceptar btnAceptar;
        private lblBase lblCriterio;
        private txtCBNumerosEnteros txtCodActivo;
        private txtBase txtNomActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreGrupo;
        private lblBase lblCriterio1;
    }
}