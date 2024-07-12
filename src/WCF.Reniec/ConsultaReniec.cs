using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Reniec
{
    public class ConsultaReniec
    {
        public Persona ConsultaDirectaReniec(string cNroDni)
        {
            Persona persona = new Persona();

            if (cNroDni.Equals("42424933"))
            {
                persona.cDniF = "42424933";
                persona.cApellidoPater = "LEON";
                persona.cApellidoMater = "VILCA";
                persona.cApellidoCasada = "";
                persona.cNombres = "DAVID";
                persona.cFechaExpe = "20140405";
                persona.cDireccion = "JR.8 DE NOVIEMBRE 1260";
                persona.cNomPadre = "FELIX";
                persona.cNomProvNac = "09";
                persona.cNomDistNac = "01";
                
            }
            else if (cNroDni.Equals("08845622"))
            {
                persona.cDniF = "08845622";
                persona.cApellidoPater = "PONCE";
                persona.cApellidoMater = "AGAPITO";
                persona.cApellidoCasada = "";
                persona.cNombres = "ESTHER";
                persona.cFechaExpe = "20111111";
                persona.cDireccion = "MZ.A' LT.30 BARRIO 4 SECTOR 2 PACHACAMAC";
                persona.cNomPadre = "ZACARIAS";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "01";                
            }
            else if (cNroDni.Equals("10526062"))
	        {
                persona.cDniF = "10526062";
                persona.cApellidoPater = "ZEVALLOS";
                persona.cApellidoMater = "DIAZ";
                persona.cApellidoCasada = "";
                persona.cNombres = "KATTY FIORELLA";
                persona.cFechaExpe = "20100929";
                persona.cDireccion = "AV.SAN ANTONIO 111 JOSE CARLOS MARIATEGUI";
                persona.cNomPadre = "BARTOLOME";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "32";                
	        }
            else if (cNroDni.Equals("33404155"))
	        {
                persona.cDniF = "33404155";
                persona.cApellidoPater = "AQUINO";
                persona.cApellidoMater = "CHIROQUE";
                persona.cApellidoCasada = "";
                persona.cNombres = "MARIA ESPERANZA";
                persona.cFechaExpe = "20080926";
                persona.cDireccion = "JR. GRAU 190";
                persona.cNomPadre = "BALTAZAR";                
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "04";
	        }
            else if (cNroDni.Equals("40040990"))
            {
                persona.cDniF = "40040990";
                persona.cApellidoPater = "ESTRELLA";
                persona.cApellidoMater = "SARATE";
                persona.cApellidoCasada = "";
                persona.cNombres = "SARA MARIBEL";
                persona.cFechaExpe = "20140327";
                persona.cDireccion = "AV FRANCISCO BOLOGNESI 671";
                persona.cNomPadre = "CARLOS";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "01";                
            }

            return persona;
        }

        public Persona ConsultaIndirectaReniec(string cNroDni)
        {
            Persona persona = new Persona();

            if (cNroDni.Equals("42424933"))
            {
                persona.cDniF = "42424933";
                persona.cApellidoPater = "LEON";
                persona.cApellidoMater = "VILCA";
                persona.cApellidoCasada = "";
                persona.cNombres = "DAVID";
                persona.cFechaExpe = "20140405";
                persona.cDireccion = "JR.8 DE NOVIEMBRE 1260";
                persona.cNomPadre = "FELIX";
                persona.cNomProvNac = "09";
                persona.cNomDistNac = "01";

            }
            else if (cNroDni.Equals("08845622"))
            {
                persona.cDniF = "08845622";
                persona.cApellidoPater = "PONCE";
                persona.cApellidoMater = "AGAPITO";
                persona.cApellidoCasada = "";
                persona.cNombres = "ESTHER";
                persona.cFechaExpe = "20111111";
                persona.cDireccion = "MZ.A' LT.30 BARRIO 4 SECTOR 2 PACHACAMAC";
                persona.cNomPadre = "ZACARIAS";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "01";
            }
            else if (cNroDni.Equals("10526062"))
            {
                persona.cDniF = "10526062";
                persona.cApellidoPater = "ZEVALLOS";
                persona.cApellidoMater = "DIAZ";
                persona.cApellidoCasada = "";
                persona.cNombres = "KATTY FIORELLA";
                persona.cFechaExpe = "20100929";
                persona.cDireccion = "AV.SAN ANTONIO 111 JOSE CARLOS MARIATEGUI";
                persona.cNomPadre = "BARTOLOME";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "32";
            }
            else if (cNroDni.Equals("33404155"))
            {
                persona.cDniF = "33404155";
                persona.cApellidoPater = "AQUINO";
                persona.cApellidoMater = "CHIROQUE";
                persona.cApellidoCasada = "";
                persona.cNombres = "MARIA ESPERANZA";
                persona.cFechaExpe = "20080926";
                persona.cDireccion = "JR. GRAU 190";
                persona.cNomPadre = "BALTAZAR";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "04";
            }
            else if (cNroDni.Equals("40040990"))
            {
                persona.cDniF = "40040990";
                persona.cApellidoPater = "ESTRELLA";
                persona.cApellidoMater = "SARATE";
                persona.cApellidoCasada = "";
                persona.cNombres = "SARA MARIBEL";
                persona.cFechaExpe = "20140327";
                persona.cDireccion = "AV FRANCISCO BOLOGNESI 671";
                persona.cNomPadre = "CARLOS";
                persona.cNomProvNac = "01";
                persona.cNomDistNac = "01";
            }

            return persona;
        }
    }
}