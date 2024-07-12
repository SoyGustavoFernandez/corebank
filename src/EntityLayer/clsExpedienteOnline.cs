using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsExpedienteOnline
    {

    }

    public class clsArchivo
    { 
        public int idArchivos	{ get; set; }			
		public string cNombreArchivo { get; set; }	
		public int idTipoArchivo { get; set; }
		public string cArchivo	{ get; set; }
		public string cDetalleArchivo	{ get; set; }	
		public int idCli { get; set; }
		public int idVisita	{ get; set; }
		public int idSolicitud { get; set; }	
		public int idModulo	{ get; set; }
		public int idCategoriaArchivo { get; set; }
		public int idUsuReg	{ get; set; }
        public string dFechaReg { get; set; }	
		public int idUsuMod	{ get; set; }
        public string dFechaMod { get; set; }
        public bool lVigente { get; set; }
        public int idDescTipoDoc { get; set; }
        public int idDetalleVisita { get; set; }

    }

    public class clsCategoriaArchivo
    { 
        public int idCategoriaArchivo{ get; set; }	
		public string cNombreCategoria{ get; set; }
        public bool lVigente { get; set; }
    }

    public class clsDescTipoDoc
    { 
        public int idDescTipoDoc { get; set; }	
        public string cDescTipoDoc{ get; set; }	
        public int idTipoVinculo{ get; set; }	
        public bool lObligatorio{ get; set; }	
        public int idCategoriaArchivo{ get; set; }	
        public int idModulo{ get; set; }
        public bool lVigente { get; set; }	
    }
}
