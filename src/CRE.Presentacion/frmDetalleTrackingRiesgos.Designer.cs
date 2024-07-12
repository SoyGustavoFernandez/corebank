namespace CRE.Presentacion
{
    partial class frmDetalleTrackingRiesgos
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
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblNombSol = new System.Windows.Forms.Label();
            this.dtgTrakingRiesgos = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrakingRiesgos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolicitud.Location = new System.Drawing.Point(113, 9);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(17, 17);
            this.lblSolicitud.TabIndex = 175;
            this.lblSolicitud.Text = "0";
            // 
            // lblNombSol
            // 
            this.lblNombSol.AutoSize = true;
            this.lblNombSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombSol.Location = new System.Drawing.Point(12, 9);
            this.lblNombSol.Name = "lblNombSol";
            this.lblNombSol.Size = new System.Drawing.Size(95, 17);
            this.lblNombSol.TabIndex = 174;
            this.lblNombSol.Text = "ID Solicitud:";
            // 
            // dtgTrakingRiesgos
            // 
            this.dtgTrakingRiesgos.AllowUserToAddRows = false;
            this.dtgTrakingRiesgos.AllowUserToDeleteRows = false;
            this.dtgTrakingRiesgos.AllowUserToResizeColumns = false;
            this.dtgTrakingRiesgos.AllowUserToResizeRows = false;
            this.dtgTrakingRiesgos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTrakingRiesgos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTrakingRiesgos.Location = new System.Drawing.Point(12, 29);
            this.dtgTrakingRiesgos.MultiSelect = false;
            this.dtgTrakingRiesgos.Name = "dtgTrakingRiesgos";
            this.dtgTrakingRiesgos.ReadOnly = true;
            this.dtgTrakingRiesgos.RowHeadersVisible = false;
            this.dtgTrakingRiesgos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTrakingRiesgos.Size = new System.Drawing.Size(738, 250);
            this.dtgTrakingRiesgos.TabIndex = 173;
            this.dtgTrakingRiesgos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgTrakingRiesgos_CellFormatting);
            this.dtgTrakingRiesgos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgTrakingRiesgos_CellPainting);
            // 
            // frmDetalleTrackingRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 308);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.lblNombSol);
            this.Controls.Add(this.dtgTrakingRiesgos);
            this.Name = "frmDetalleTrackingRiesgos";
            this.Text = "Detalle Tracking de Riesgos";
            this.Load += new System.EventHandler(this.frmDetalleTrackingRiesgos_Load);
            this.Controls.SetChildIndex(this.dtgTrakingRiesgos, 0);
            this.Controls.SetChildIndex(this.lblNombSol, 0);
            this.Controls.SetChildIndex(this.lblSolicitud, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrakingRiesgos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblNombSol;
        private GEN.ControlesBase.dtgBase dtgTrakingRiesgos;
    }
}