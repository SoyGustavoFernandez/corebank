namespace GEN.ControlesBase
{
    partial class frmVisitaRealizadaSinVinculacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitaRealizadaSinVinculacion));
            this.dtgVisitas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnDetalle2 = new GEN.BotonesBase.btnDetalle();
            this.btn_Vincular1 = new GEN.BotonesBase.Btn_Vincular();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVisitas
            // 
            this.dtgVisitas.AllowUserToAddRows = false;
            this.dtgVisitas.AllowUserToDeleteRows = false;
            this.dtgVisitas.AllowUserToResizeColumns = false;
            this.dtgVisitas.AllowUserToResizeRows = false;
            this.dtgVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVisitas.Location = new System.Drawing.Point(5, 33);
            this.dtgVisitas.MultiSelect = false;
            this.dtgVisitas.Name = "dtgVisitas";
            this.dtgVisitas.ReadOnly = true;
            this.dtgVisitas.RowHeadersVisible = false;
            this.dtgVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVisitas.Size = new System.Drawing.Size(585, 163);
            this.dtgVisitas.TabIndex = 2;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.BackColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.White;
            this.lblBaseCustom1.Location = new System.Drawing.Point(5, 5);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Padding = new System.Windows.Forms.Padding(3);
            this.lblBaseCustom1.Size = new System.Drawing.Size(585, 23);
            this.lblBaseCustom1.TabIndex = 3;
            this.lblBaseCustom1.Text = "VISITAS SIN VINCULACIÓN A SOLICITUD DE CRÉDITO";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetalle2
            // 
            this.btnDetalle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle2.BackgroundImage")));
            this.btnDetalle2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle2.Location = new System.Drawing.Point(398, 200);
            this.btnDetalle2.Name = "btnDetalle2";
            this.btnDetalle2.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle2.TabIndex = 7;
            this.btnDetalle2.Text = "&Detallar";
            this.btnDetalle2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle2.texto = "&Detallar";
            this.btnDetalle2.UseVisualStyleBackColor = true;
            this.btnDetalle2.Click += new System.EventHandler(this.btnDetalle2_Click);
            // 
            // btn_Vincular1
            // 
            this.btn_Vincular1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Vincular1.BackgroundImage")));
            this.btn_Vincular1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Vincular1.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vincular1.Image")));
            this.btn_Vincular1.Location = new System.Drawing.Point(464, 200);
            this.btn_Vincular1.Name = "btn_Vincular1";
            this.btn_Vincular1.Size = new System.Drawing.Size(60, 50);
            this.btn_Vincular1.TabIndex = 8;
            this.btn_Vincular1.Text = "&Vincular";
            this.btn_Vincular1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Vincular1.UseVisualStyleBackColor = true;
            this.btn_Vincular1.Click += new System.EventHandler(this.btn_Vincular1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(530, 200);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmVisitaRealizadaSinVinculacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 275);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btn_Vincular1);
            this.Controls.Add(this.btnDetalle2);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.dtgVisitas);
            this.Name = "frmVisitaRealizadaSinVinculacion";
            this.Text = "Visitas sin Vinculación";
            this.Load += new System.EventHandler(this.frmVisitaRealizadaSinVinculacion_Load);
            this.Controls.SetChildIndex(this.dtgVisitas, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.btnDetalle2, 0);
            this.Controls.SetChildIndex(this.btn_Vincular1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgVisitas;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnDetalle btnDetalle2;
        private BotonesBase.Btn_Vincular btn_Vincular1;
        private BotonesBase.btnSalir btnSalir1;
    }
}