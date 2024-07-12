using GEN.ControlesBase;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmMapaHojaRuta: frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        GMapOverlay gmoCapa;
        public int idHojaRuta;
        DataTable dtGestiones = new DataTable();

        public frmMapaHojaRuta()
        {
            InitializeComponent();
        }

        private void frmMapaHojaRuta_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrlMapa_Load(object sender, EventArgs e)
        {
            dtGestiones = cnHojaRuta.listarUbicacionesGestiones(idHojaRuta);

            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;            
            ctrlMapa.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;

            ctrlMapa.CanDragMap = true;
            ctrlMapa.DragButton = MouseButtons.Left;

            gmoCapa = new GMapOverlay("Capa 1");

            List<PointLatLng> plUbicaciones = new List<PointLatLng>();

            foreach (DataRow drGestion in dtGestiones.Rows)
            {
                if (drGestion["nLatitud"] == DBNull.Value || drGestion["nLongitud"] == DBNull.Value)
                    continue;
                GMapMarker gmmGestion = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(Convert.ToDouble(drGestion["nLatitud"]), Convert.ToDouble(drGestion["nLongitud"])),Properties.Resources.ubicacion);
                gmmGestion.ToolTipText = "Cliente: " + drGestion["cNombreCliente"].ToString() 
                                        + "\nFecha y Hora Visita: " + drGestion["dFechaRegisCliente"].ToString()
                                        + "\nUbigeo: " + drGestion["cUbigeo"].ToString();
                gmoCapa.Markers.Add(gmmGestion);
                plUbicaciones.Add(new PointLatLng(Convert.ToDouble(drGestion["nLatitud"]), Convert.ToDouble(drGestion["nLongitud"])));
            }

            GMapRoute ruta = new GMapRoute(plUbicaciones, "Ruta");
            gmoCapa.Routes.Add(ruta);
            ctrlMapa.Overlays.Add(gmoCapa);
            ctrlMapa.Position = obtenerCentro(plUbicaciones);
            ctrlMapa.MapProvider = GMapProviders.BingMap;            
            ctrlMapa.MinZoom = 3;
            ctrlMapa.MaxZoom = 17;
            ctrlMapa.Zoom = 12;
        }


        public static PointLatLng obtenerCentro(List<PointLatLng> listUbicaciones)
        {
            int nTotal = 0;

            double X = 0;
            double Y = 0;
            double Z = 0;

            foreach (var i in listUbicaciones)
            {
                if (i.Lat == 0 && i.Lng == 0) continue;
                double lat = i.Lat * Math.PI / 180;
                double lon = i.Lng * Math.PI / 180;

                double x = Math.Cos(lat) * Math.Cos(lon);
                double y = Math.Cos(lat) * Math.Sin(lon);
                double z = Math.Sin(lat);

                X += x;
                Y += y;
                Z += z;
                nTotal += 1;
            }

            X = X / nTotal;
            Y = Y / nTotal;
            Z = Z / nTotal;

            double nLon = Math.Atan2(Y, X);
            double nHyp = Math.Sqrt(X * X + Y * Y);
            double nLat = Math.Atan2(Z, nHyp);

            return new PointLatLng(nLat * 180 / Math.PI, nLon * 180 / Math.PI);
        }
    
    }
}
