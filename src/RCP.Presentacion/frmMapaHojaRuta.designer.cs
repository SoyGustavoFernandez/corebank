namespace RCP.Presentacion
{
    partial class frmMapaHojaRuta
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
            this.ctrlMapa = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // ctrlMapa
            // 
            this.ctrlMapa.Bearing = 0F;
            this.ctrlMapa.CanDragMap = true;
            this.ctrlMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMapa.EmptyTileColor = System.Drawing.Color.Transparent;
            this.ctrlMapa.GrayScaleMode = false;
            this.ctrlMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.ctrlMapa.LevelsKeepInMemmory = 5;
            this.ctrlMapa.Location = new System.Drawing.Point(0, 0);
            this.ctrlMapa.MarkersEnabled = true;
            this.ctrlMapa.MaxZoom = 2;
            this.ctrlMapa.MinZoom = 2;
            this.ctrlMapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.ctrlMapa.Name = "ctrlMapa";
            this.ctrlMapa.NegativeMode = false;
            this.ctrlMapa.PolygonsEnabled = true;
            this.ctrlMapa.RetryLoadTile = 0;
            this.ctrlMapa.RoutesEnabled = true;
            this.ctrlMapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.ctrlMapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.ctrlMapa.ShowTileGridLines = false;
            this.ctrlMapa.Size = new System.Drawing.Size(1037, 706);
            this.ctrlMapa.TabIndex = 2;
            this.ctrlMapa.Zoom = 0D;
            this.ctrlMapa.Load += new System.EventHandler(this.ctrlMapa_Load);
            // 
            // frmMapaHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 728);
            this.Controls.Add(this.ctrlMapa);
            this.Name = "frmMapaHojaRuta";
            this.Text = "Mapa Hoja de Ruta";
            this.Load += new System.EventHandler(this.frmMapaHojaRuta_Load);
            this.Controls.SetChildIndex(this.ctrlMapa, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl ctrlMapa;
    }
}