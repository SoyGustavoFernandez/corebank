namespace CRE.Presentacion
{
    partial class frmExpedienteConfirmRecep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedienteConfirmRecep));
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnRecibido1 = new GEN.BotonesBase.btnRecibido();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.dtgExpedienteEnt = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExpedienteEnt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(553, 19);
            this.lblBase7.TabIndex = 82;
            this.lblBase7.Text = "EXPEDIENTES";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(439, 312);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 84;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(505, 312);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 85;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnRecibido1
            // 
            this.btnRecibido1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecibido1.BackgroundImage")));
            this.btnRecibido1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecibido1.Location = new System.Drawing.Point(373, 312);
            this.btnRecibido1.Name = "btnRecibido1";
            this.btnRecibido1.Size = new System.Drawing.Size(60, 50);
            this.btnRecibido1.TabIndex = 86;
            this.btnRecibido1.Text = "&Recibido";
            this.btnRecibido1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecibido1.UseVisualStyleBackColor = true;
            this.btnRecibido1.Click += new System.EventHandler(this.btnRecibido1_Click);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(12, 302);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 87;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // dtgExpedienteEnt
            // 
            this.dtgExpedienteEnt.AllowUserToAddRows = false;
            this.dtgExpedienteEnt.AllowUserToDeleteRows = false;
            this.dtgExpedienteEnt.AllowUserToResizeColumns = false;
            this.dtgExpedienteEnt.AllowUserToResizeRows = false;
            this.dtgExpedienteEnt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgExpedienteEnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExpedienteEnt.Location = new System.Drawing.Point(11, 40);
            this.dtgExpedienteEnt.MultiSelect = false;
            this.dtgExpedienteEnt.Name = "dtgExpedienteEnt";
            this.dtgExpedienteEnt.ReadOnly = true;
            this.dtgExpedienteEnt.RowHeadersVisible = false;
            this.dtgExpedienteEnt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExpedienteEnt.Size = new System.Drawing.Size(553, 256);
            this.dtgExpedienteEnt.TabIndex = 81;
            this.dtgExpedienteEnt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExpedienteEnt_CellContentClick);
            // 
            // frmExpedienteConfirmRecep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 396);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnRecibido1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtgExpedienteEnt);
            this.Name = "frmExpedienteConfirmRecep";
            this.Text = "Confirmación de Recepción de Expediente";
            this.Load += new System.EventHandler(this.frmExpedienteConfirmRecep_Load);
            this.Controls.SetChildIndex(this.dtgExpedienteEnt, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnRecibido1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExpedienteEnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnRecibido btnRecibido1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.dtgBase dtgExpedienteEnt;
    }
}