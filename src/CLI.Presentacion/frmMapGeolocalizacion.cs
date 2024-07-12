using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ToolTip = System.Windows.Forms.ToolTip;
using CLI.CapaNegocio;
using EntityLayer;

namespace CLI.Presentacion
{
    public partial class frmMapGeolocalizacion : frmBase
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        public double nLatInicial = 0;
        public double nLngInicial = 0;
        public string cliLatitud;
        public string cliLongitud;
        public string cliIdGeo;
        public string cDireccionOficina;
        public int nZoom = 13;

        public frmMapGeolocalizacion()
        {
            InitializeComponent();
        }

        private void frmMapGeolocalizacion_Load(object sender, EventArgs e)
        {
            txtLatitud.Text = Convert.ToString(nLatInicial);
            txtLongitud.Text = Convert.ToString(nLngInicial);
  
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.CanDragMap = true;
                gMapControl1.MapProvider = GMapProviders.GoogleMap;
                gMapControl1.Position = new PointLatLng(nLatInicial, nLngInicial);
                gMapControl1.MinZoom = 0;
                gMapControl1.MaxZoom = 24;
                gMapControl1.Zoom = nZoom;
                gMapControl1.AutoScroll = true;
                markerOverlay = new GMapOverlay("Marcador");
                marker = new GMarkerGoogle(new PointLatLng(nLatInicial, nLngInicial), GMarkerGoogleType.red_dot);
                markerOverlay.Markers.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = string.Format(cDireccionOficina);
                gMapControl1.Overlays.Add(markerOverlay);           

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            double nlat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double nlng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            txtLatitud.Text = nlat.ToString();
            txtLongitud.Text = nlng.ToString();
            marker.Position = new PointLatLng(nlat, nlng);
            marker.ToolTipText = string.Format(txtDireccion.Text);

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clsCNCliente RegGeolocalizacion = new clsCNCliente();
            DataTable dtLsitarAgeDir = RegGeolocalizacion.CNRegistrarGeolocalizacion(txtLatitud.Text, txtLongitud.Text, Convert.ToInt32(clsVarGlobal.User.idUsuario), clsVarGlobal.dFecSystem);

            string idGeoloc = Convert.ToString(dtLsitarAgeDir.Rows[0]["idGeolocalizacion"]);            
            cliLatitud = txtLatitud.Text;
            cliLongitud = txtLongitud.Text;
            cliIdGeo = idGeoloc;
            this.DialogResult = DialogResult.OK;
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            if (txtIdGeo.Text.Trim() == "")
            {
                btnRegistrar_Click(sender, e);
            }
            else 
            { 
                clsCNCliente RegGeolocalizacion = new clsCNCliente();
                DataTable dtLsitarAgeDir = RegGeolocalizacion.CNActualizarGeolocalizacion(Convert.ToInt32(txtIdGeo.Text), txtLatitud.Text, txtLongitud.Text, Convert.ToInt32(clsVarGlobal.User.idUsuario), clsVarGlobal.dFecSystem);
            
                cliLatitud = txtLatitud.Text;
                cliLongitud = txtLongitud.Text;
                cliIdGeo = txtIdGeo.Text; 
                this.DialogResult = DialogResult.OK;           
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
