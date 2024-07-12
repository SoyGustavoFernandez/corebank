namespace ADM.Presentacion
{
    partial class frmDestinoCmpxOficina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDestinoCmpxOficina));
            this.cboDestinoCmp = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgAccesoCmp = new GEN.ControlesBase.dtgBase(this.components);
            this.lDestino = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAccesoCmp)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDestinoCmp
            // 
            this.cboDestinoCmp.FormattingEnabled = true;
            this.cboDestinoCmp.Location = new System.Drawing.Point(151, 12);
            this.cboDestinoCmp.Name = "cboDestinoCmp";
            this.cboDestinoCmp.Size = new System.Drawing.Size(162, 21);
            this.cboDestinoCmp.TabIndex = 2;
            this.cboDestinoCmp.SelectedIndexChanged += new System.EventHandler(this.cboDestinoCmp_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(132, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Destino Comprobante";
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(24, 47);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(62, 17);
            this.chcTodos.TabIndex = 5;
            this.chcTodos.Text = "Todas?";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(185, 273);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(253, 273);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgAccesoCmp
            // 
            this.dtgAccesoCmp.AllowUserToAddRows = false;
            this.dtgAccesoCmp.AllowUserToDeleteRows = false;
            this.dtgAccesoCmp.AllowUserToResizeColumns = false;
            this.dtgAccesoCmp.AllowUserToResizeRows = false;
            this.dtgAccesoCmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAccesoCmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAccesoCmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lDestino,
            this.cNombreAge,
            this.idAgencia});
            this.dtgAccesoCmp.Location = new System.Drawing.Point(24, 70);
            this.dtgAccesoCmp.MultiSelect = false;
            this.dtgAccesoCmp.Name = "dtgAccesoCmp";
            this.dtgAccesoCmp.ReadOnly = true;
            this.dtgAccesoCmp.RowHeadersVisible = false;
            this.dtgAccesoCmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAccesoCmp.Size = new System.Drawing.Size(289, 195);
            this.dtgAccesoCmp.TabIndex = 8;
            this.dtgAccesoCmp.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAccesoCmp_CellValueChanged);
            // 
            // lDestino
            // 
            this.lDestino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lDestino.DataPropertyName = "lDestino";
            this.lDestino.HeaderText = "Acc";
            this.lDestino.Name = "lDestino";
            this.lDestino.ReadOnly = true;
            this.lDestino.Width = 40;
            // 
            // cNombreAge
            // 
            this.cNombreAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Oficina";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            this.cNombreAge.Width = 225;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(117, 273);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmDestinoCmpxOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 356);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.dtgAccesoCmp);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboDestinoCmp);
            this.Name = "frmDestinoCmpxOficina";
            this.Text = "Destino de comprobante por agencia";
            this.Load += new System.EventHandler(this.frmDestinoCmpxOficina_Load);
            this.Controls.SetChildIndex(this.cboDestinoCmp, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgAccesoCmp, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAccesoCmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboDestinoCmp;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgAccesoCmp;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
    }
}