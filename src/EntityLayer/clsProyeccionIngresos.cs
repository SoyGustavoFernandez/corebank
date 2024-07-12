using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsProyeccionIngresos
    {
        public Guid idIngresoEstacional { get; set; }
        public int idEvalCre { get; set; }
        public int idMoneda { get; set; }

        public string cParcela { get; set; }
        public decimal nExtension { get; set; }

        // Etapa Cultivo
        public int idCultivo { get; set; }
        public string cCultivo { get; set; }

        // Variedad
        public int idVariedad { get; set; }
        public string cVariedad { get; set; }

        // Etapa de Produccion
        public int idEtapaProduccion { get; set; }
        public string cEtapaProduccion { get; set; }

        // Condición de Terreno
        public int idCondicionTerreno { get; set; }
        public string cCondicionTerreno { get; set; }

        // Condicion de Tenencia
        public int idCondicionTenencia { get; set; }
        public string cCondicionTenencia { get; set; }

        // Unidad
        public int idUnidad { get; set; }
        public string cUnidad { get; set; }

        // Rendimientos
        public decimal nRendAnterior { get; set; }
        public decimal nRendMinimo { get; set; }
        public decimal nRendMaximo { get; set; }
        public decimal nRendPonderado
        {
            get { return (nRendAnterior + nRendMinimo * 2 + nRendMaximo) / 4; }
            set { }
        }

        public decimal nCantidadVenta
        {
            get { return nRendPonderado * nExtension; }
            set { }
        }

        public decimal nPrecioVenta { get; set; }

        public decimal nIngresos
        {
            get { return nPrecioVenta * nCantidadVenta; }
            set { }
        }

        public int nFecha { get; set; }

        public string cFechaTabla 
        {
            get { return Convert.ToDateTime(DateTime.ParseExact(nFecha.ToString(), "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None)).ToString("MM - yyyy").ToString(); }
            set { } 
        }

        public decimal nMontoInversionTotal
        {
            get { return listaInversionInsumo != null ? listaInversionInsumo.Sum(t => t.nTotal) : 0; }
            set { }
        }

        public bool lInversionRealizada
        {
            get { return nMontoInversionTotal > 0 ? true : false; }
            set { }
        }

        public List<clsInversionInsumo> listaInversionInsumo { get; set; }

        public clsProyeccionIngresos()
	    {
            listaInversionInsumo = new List<clsInversionInsumo>();
	    }
    }
}
