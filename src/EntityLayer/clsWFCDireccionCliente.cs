﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWFCDireccionCliente
    {
        public int idDireccion { get; set; }

        public int idCli { get; set; }
        public int idUbigeo { get; set; }

        public int idTipoDireccion { get; set; }
        public string cDireccion { get; set; }
        public int idTipoZona { get; set; }
        public string cDesZona { get; set; }
        public int idTipoVia { get; set; }
        public string cDesVia { get; set; }
        //public string cDepartamento { get; set; }

        
        /* public string cInterior { get; set; } */
        public string cManzana { get; set; }
        public string cLote { get; set; }
        /*
        public string cKilometro { get; set; }
        public string cBlock { get; set; }
        public string cEtapa { get; set; }
         */
        public string cNumero { get; set; }
        public string cReferenciaDireccion { get; set; }
        public int idSuministro { get; set; }
        public string cCodSuministro { get; set; }
        public int idSector { get; set; }
        public int idTipoConstruccion { get; set; }
        public int idTipoVivienda { get; set; }
        public string cNombrePropietario { get; set; }
        public int nAñoReside { get; set;  }
        public bool lDirPrincipal { get; set; }

        public string Estado { get; set; }
    }
}
