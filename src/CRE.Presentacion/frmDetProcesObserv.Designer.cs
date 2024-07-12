namespace CRE.Presentacion
{
    partial class frmDetProcesObserv
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
            this.dtgObservaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblNombSol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgObservaciones
            // 
            this.dtgObservaciones.AllowUserToAddRows = false;
            this.dtgObservaciones.AllowUserToDeleteRows = false;
            this.dtgObservaciones.AllowUserToResizeColumns = false;
            this.dtgObservaciones.AllowUserToResizeRows = false;
            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.Location = new System.Drawing.Point(12, 29);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.Name = "dtgObservaciones";
            this.dtgObservaciones.ReadOnly = true;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.Size = new System.Drawing.Size(949, 356);
            this.dtgObservaciones.TabIndex = 156;
            this.dtgObservaciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgObservaciones_CellPainting);
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolicitud.Location = new System.Drawing.Point(113, 9);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(17, 17);
            this.lblSolicitud.TabIndex = 172;
            this.lblSolicitud.Text = "0";
            // 
            // lblNombSol
            // 
            this.lblNombSol.AutoSize = true;
            this.lblNombSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombSol.Location = new System.Drawing.Point(12, 9);
            this.lblNombSol.Name = "lblNombSol";
            this.lblNombSol.Size = new System.Drawing.Size(95, 17);
            this.lblNombSol.TabIndex = 171;
            this.lblNombSol.Text = "ID Solicitud:";
            // 
            // frmDetProcesObserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 415);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.lblNombSol);
            this.Controls.Add(this.dtgObservaciones);
            this.Name = "frmDetProcesObserv";
            this.Text = "Detalle del proceso de Observaciones";
            this.Load += new System.EventHandler(this.frmDetProcesObserv_Load);
            this.Controls.SetChildIndex(this.dtgObservaciones, 0);
            this.Controls.SetChildIndex(this.lblNombSol, 0);
            this.Controls.SetChildIndex(this.lblSolicitud, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgObservaciones;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblNombSol;
    }
}