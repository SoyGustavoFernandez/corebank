using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.Reniec
{
    [DataContract]
    public class Persona
    {
        /*[DataMember]
        public string cNroDni { get; set; }

        [DataMember]
        public string cNombres { get; set; }

        [DataMember]
        public string cApellidos { get; set; }

        [DataMember]
        public string cDireccion { get; set; }

        [DataMember]
        public string cTelefono { get; set; }*/

        /* --- */
        [DataMember]
        public string cErrorF { get; set; }
        [DataMember]
        public string cDniF { get; set; }
        [DataMember]
        public string cDigitoVerif { get; set; }
        [DataMember]
        public string cApellidoPater { get; set; }
        [DataMember]
        public string cApellidoMater { get; set; }
        [DataMember]
        public string cApellidoCasada { get; set; }
        [DataMember]
        public string cNombres { get; set; }
        [DataMember]
        public string cUbigeoDep { get; set; }
        [DataMember]
        public string cUbigeoProv { get; set; }
        [DataMember]
        public string cUbigeoDist { get; set; }
        [DataMember]
        public string cNomDep { get; set; }
        [DataMember]
        public string cNomProv { get; set; }
        [DataMember]
        public string cNomDist { get; set; }
        [DataMember]
        public string cEstadoCivil { get; set; }
        [DataMember]
        public string cGradoInstr { get; set; }
        [DataMember]
        public string cEstatura { get; set; }
        [DataMember]
        public string cSexo { get; set; }
        [DataMember]
        public string cDocSustTipo { get; set; }
        [DataMember]
        public string cDocSustNumero { get; set; }
        [DataMember]
        public string cUbigeoDepNac { get; set; }
        [DataMember]
        public string cUbigeoProvNac { get; set; }
        [DataMember]
        public string cUbigeoDistNac { get; set; }
        [DataMember]
        public string cNomDepNac { get; set; }
        [DataMember]
        public string cNomProvNac { get; set; }
        [DataMember]
        public string cNomDistNac { get; set; }
        [DataMember]
        public string cFechaNac { get; set; }
        [DataMember]
        public string cNomPadre { get; set; }
        [DataMember]
        public string cNomMadre { get; set; }
        [DataMember]
        public string cFechaInsc { get; set; }
        [DataMember]
        public string cFechaExpe { get; set; }
        [DataMember]
        public string cConstanciaVota { get; set; }
        [DataMember]
        public string cRestrccion { get; set; }
        [DataMember]
        public string cPrefijoDireccion { get; set; }
        [DataMember]
        public string cDireccion { get; set; }
        [DataMember]
        public string cNumDireccion { get; set; }
        [DataMember]
        public string cBlock { get; set; }
        [DataMember]
        public string cInterior { get; set; }
        [DataMember]
        public string cUrbanizacion { get; set; }
        [DataMember]
        public string cEtapa { get; set; }
        [DataMember]
        public string cManzana { get; set; }
        [DataMember]
        public string cLote { get; set; }
        [DataMember]
        public string cPrefiBlock { get; set; }
        [DataMember]
        public string cPrefiDep { get; set; }
        [DataMember]
        public string cPrefiUrba { get; set; }
        [DataMember]
        public string cReservadoF { get; set; }
        [DataMember]
        public string cLongFoto { get; set; }
        [DataMember]
        public string cLongFirma { get; set; }
        [DataMember]
        public string cReservConCeros { get; set; }
        [DataMember]
        public string cReservConEspacios { get; set; }
        [DataMember]
        public string cFotoF { get; set; }
        [DataMember]
        public string cFirmaF { get; set; }


    }
}