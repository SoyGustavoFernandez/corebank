namespace GEN.ControlesBase
{
    partial class frmEvaluaSobreendeuda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluaSobreendeuda));
            this.dtgEvaluacion = new GEN.ControlesBase.dtgBase(this.components);
            this.lblMensaje = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgEvaluacion
            // 
            this.dtgEvaluacion.AllowUserToAddRows = false;
            this.dtgEvaluacion.AllowUserToDeleteRows = false;
            this.dtgEvaluacion.AllowUserToResizeColumns = false;
            this.dtgEvaluacion.AllowUserToResizeRows = false;
            this.dtgEvaluacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvaluacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEvaluacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaluacion.Location = new System.Drawing.Point(12, 30);
            this.dtgEvaluacion.MultiSelect = false;
            this.dtgEvaluacion.Name = "dtgEvaluacion";
            this.dtgEvaluacion.ReadOnly = true;
            this.dtgEvaluacion.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvaluacion.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEvaluacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaluacion.Size = new System.Drawing.Size(560, 200);
            this.dtgEvaluacion.TabIndex = 2;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Navy;
            this.lblMensaje.Location = new System.Drawing.Point(12, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(252, 13);
            this.lblMensaje.TabIndex = 6;
            this.lblMensaje.Text = "Detalles de riesgo de sobreendeudamiento";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(512, 236);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmEvaluaSobreendeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dtgEvaluacion);
            this.Name = "frmEvaluaSobreendeuda";
            this.Text = "Evalua sobreendeudamiento";
            this.Load += new System.EventHandler(this.frmEvaluaSobreendeuda_Load);
            this.Controls.SetChildIndex(this.dtgEvaluacion, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgEvaluacion;
        private GEN.ControlesBase.lblBase lblMensaje;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}