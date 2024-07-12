namespace GEN.ControlesBase
{
    partial class frmBuscaActivoPorCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaActivoPorCli));
            this.dtgActivosUsuario = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblProducto = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblAgencia = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.lblMoneda = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivosUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgActivosUsuario
            // 
            this.dtgActivosUsuario.AllowUserToAddRows = false;
            this.dtgActivosUsuario.AllowUserToDeleteRows = false;
            this.dtgActivosUsuario.AllowUserToResizeColumns = false;
            this.dtgActivosUsuario.AllowUserToResizeRows = false;
            this.dtgActivosUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivosUsuario.Location = new System.Drawing.Point(11, 101);
            this.dtgActivosUsuario.MultiSelect = false;
            this.dtgActivosUsuario.Name = "dtgActivosUsuario";
            this.dtgActivosUsuario.ReadOnly = true;
            this.dtgActivosUsuario.RowHeadersVisible = false;
            this.dtgActivosUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivosUsuario.Size = new System.Drawing.Size(497, 328);
            this.dtgActivosUsuario.TabIndex = 3;
            this.dtgActivosUsuario.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActivosUsuario_CellValueChanged_1);
            this.dtgActivosUsuario.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgActivosUsuario_CurrentCellDirtyStateChanged);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(448, 435);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(13, 435);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 5;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.Navy;
            this.lblProducto.Location = new System.Drawing.Point(15, 81);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(132, 17);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "lblBaseCustom1";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblAgencia.ForeColor = System.Drawing.Color.Navy;
            this.lblAgencia.Location = new System.Drawing.Point(15, 59);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(132, 17);
            this.lblAgencia.TabIndex = 7;
            this.lblAgencia.Text = "lblBaseCustom1";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(37, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Serie";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(58, 9);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(247, 20);
            this.txtSerie.TabIndex = 9;
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(320, 5);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 10;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // conBusCol1
            // 
            this.conBusCol1.cEstado = "0";
            this.conBusCol1.Location = new System.Drawing.Point(13, 5);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(390, 90);
            this.conBusCol1.TabIndex = 11;
            this.conBusCol1.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario_1);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(15, 36);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(132, 17);
            this.lblMoneda.TabIndex = 12;
            this.lblMoneda.Text = "lblBaseCustom1";
            // 
            // frmBuscaActivoPorCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 513);
            this.Controls.Add(this.conBusCol1);
            this.Controls.Add(this.btnMiniBusq1);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgActivosUsuario);
            this.Controls.Add(this.lblMoneda);
            this.Name = "frmBuscaActivoPorCli";
            this.Text = "Activos por Colaborador";
            this.Load += new System.EventHandler(this.frmBuscaActivoPorCli_Load);
            this.Controls.SetChildIndex(this.lblMoneda, 0);
            this.Controls.SetChildIndex(this.dtgActivosUsuario, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.lblProducto, 0);
            this.Controls.SetChildIndex(this.lblAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq1, 0);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivosUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgActivosUsuario;
        private BotonesBase.BtnAceptar btnAceptar1;
        private chcBase chcTodos;
        private lblBaseCustom lblProducto;
        private lblBaseCustom lblAgencia;
        private lblBase lblBase1;
        private txtBase txtSerie;
        private BotonesBase.btnMiniBusq btnMiniBusq1;
        private ConBusCol conBusCol1;
        private lblBaseCustom lblMoneda;
    }
}