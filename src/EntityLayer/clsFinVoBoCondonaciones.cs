using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsFinVoBoNivelesAproba
    {
        public clsFinVoBoNivelesAproba()
        {
            this.idVoBoNivelesAproba = 0;
            this.cComentario = "";
            this.idUsuarioReg = 0;
            this.idPerfil = 0;
            this.dFechaVoBo	= new DateTime();	
            this.idEstadoAproba	= 0;	
            this.idSolicitudAproba = 0;
            this.lVigente = false;
        }

        public int idVoBoNivelesAproba { get; set; }
		public string cComentario		{get;set;}
		public int idUsuarioReg		    {get;set;}
		public int idPerfil			    {get;set;}
        public DateTime dFechaVoBo      {get;set;} 
		public int idEstadoAproba		{get;set;}
		public int idSolicitudAproba	{get;set;}
		public bool lVigente			 {get;set;}
    }
}
