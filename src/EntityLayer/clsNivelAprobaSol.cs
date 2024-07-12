using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class clsNivelAprobaSol
    {
        public int idNivelAprobaSol	{get;set;}			
		public int idSolicitudAproba {get;set;}			
		public int idNivelAprobaBase{get;set;}		
		public int idEstadoAproba{get;set;}
        public bool lVigente { get; set; }	
    }
}
