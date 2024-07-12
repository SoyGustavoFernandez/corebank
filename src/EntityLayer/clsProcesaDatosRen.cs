using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data;
namespace EntityLayer
{
    //class clsProcesaDatosRen
    //{
    //}

    [DataContract]
    public class clsProcesaDatosRen
    {
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

        //public string cDatos { get; set; }
        /*public string cErrorF { get; set; }
        public string cDniF { get; set; }
        public string cDigitoVerif { get; set; }
        public string cApellidoPater { get; set; }
        public string cApellidoMater { get; set; }
        public string cApellidoCasada { get; set; }
        public string cNombres { get; set; }
        public string cUbigeoDep { get; set; }
        public string cUbigeoProv { get; set; }
        public string cUbigeoDist { get; set; }
        public string cNomDep { get; set; }
        public string cNomProv { get; set; }
        public string cNomDist { get; set; }
        public string cEstadoCivil { get; set; }
        public string cGradoInstr { get; set; }
        public string cEstatura { get; set; }
        public string cSexo { get; set; }
        public string cDocSustTipo { get; set; }
        public string cDocSustNumero { get; set; }
        public string cUbigeoDepNac { get; set; }
        public string cUbigeoProvNac { get; set; }
        public string cUbigeoDistNac { get; set; }
        public string cNomDepNac { get; set; }
        public string cNomProvNac { get; set; }
        public string cNomDistNac { get; set; }
        public string cFechaNac { get; set; }
        public string cNomPadre { get; set; }
        public string cNomMadre { get; set; }
        public string cFechaInsc { get; set; }
        public string cFechaExpe { get; set; }
        public string cConstanciaVota { get; set; }
        public string cRestrccion { get; set; }
        public string cPrefijoDireccion { get; set; }
        public string cDireccion { get; set; }
        public string cNumDireccion { get; set; }
        public string cBlock { get; set; }
        public string cInterior { get; set; }
        public string cUrbanizacion { get; set; }
        public string cEtapa { get; set; }
        public string cManzana { get; set; }
        public string cLote { get; set; }
        public string cPrefiBlock { get; set; }
        public string cPrefiDep { get; set; }
        public string cPrefiUrba { get; set; }
        public string cReservadoF { get; set; }
        public string cLongFoto { get; set; }
        public string cLongFirma { get; set; }
        public string cReservConCeros { get; set; }
        public string cReservConEspacios { get; set; }
        public string cFotoF { get; set; }
        public string cFirmaF { get; set; }*/

        public void GetData(string cData, string cPhoto, string cSign)
        {
            this.cFotoF = cPhoto;//string.Empty;
            this.cFirmaF = cSign;//string.Empty;
            separarDatos(cData);

            return;
        }

        public void GetDataDt(DataTable dtDatos)
        {
            cErrorF = dtDatos.Rows[0]["cError"].ToString();
            cDniF = dtDatos.Rows[0]["cDni"].ToString();
            cDigitoVerif = dtDatos.Rows[0]["cDigitoVerif"].ToString();
            cApellidoPater = dtDatos.Rows[0]["cApellidoPater"].ToString();
            cApellidoMater = dtDatos.Rows[0]["cApellidoMater"].ToString();
            cApellidoCasada = dtDatos.Rows[0]["cApellidoCasada"].ToString();
            cNombres = dtDatos.Rows[0]["cNombres"].ToString();
            cUbigeoDep = dtDatos.Rows[0]["cUbigeoDep"].ToString();
            cUbigeoProv = dtDatos.Rows[0]["cUbigeoProv"].ToString();
            cUbigeoDist = dtDatos.Rows[0]["cUbigeoDist"].ToString();
            cNomDep = dtDatos.Rows[0]["cNomDep"].ToString();
            cNomProv = dtDatos.Rows[0]["cNomProv"].ToString();
            cNomDist = dtDatos.Rows[0]["cNomDist"].ToString();
            cEstadoCivil = dtDatos.Rows[0]["cEstadoCivil"].ToString();
            cGradoInstr = dtDatos.Rows[0]["cGradoInstr"].ToString();
            cEstatura = dtDatos.Rows[0]["cEstatura"].ToString();
            cSexo = dtDatos.Rows[0]["cSexo"].ToString();
            cDocSustTipo = dtDatos.Rows[0]["cDocSustTipo"].ToString();
            cDocSustNumero = dtDatos.Rows[0]["cDocSustNumero"].ToString();
            cUbigeoDepNac = dtDatos.Rows[0]["cUbigeoDepNac"].ToString();
            cUbigeoProvNac = dtDatos.Rows[0]["cUbigeoProvNac"].ToString();
            cUbigeoDistNac = dtDatos.Rows[0]["cUbigeoDistNac"].ToString();
            cNomDepNac = dtDatos.Rows[0]["cNomDepNac"].ToString();
            cNomProvNac = dtDatos.Rows[0]["cNomProvNac"].ToString();
            cNomDistNac = dtDatos.Rows[0]["cNomDistNac"].ToString();
            cFechaNac = dtDatos.Rows[0]["cFechaNac"].ToString();
            cNomPadre = dtDatos.Rows[0]["cNomPadre"].ToString();
            cNomMadre = dtDatos.Rows[0]["cNomMadre"].ToString();
            cFechaInsc = dtDatos.Rows[0]["cFechaInsc"].ToString();
            cFechaExpe = dtDatos.Rows[0]["cFechaExpe"].ToString();
            cConstanciaVota = dtDatos.Rows[0]["cConstanciaVota"].ToString();
            cRestrccion = dtDatos.Rows[0]["cRestrccion"].ToString();
            cPrefijoDireccion = dtDatos.Rows[0]["cPrefijoDireccion"].ToString();
            cDireccion = dtDatos.Rows[0]["cDireccion"].ToString();
            cNumDireccion = dtDatos.Rows[0]["cNumDireccion"].ToString();
            cBlock = dtDatos.Rows[0]["cBlock"].ToString();
            cInterior = dtDatos.Rows[0]["cInterior"].ToString();
            cUrbanizacion = dtDatos.Rows[0]["cUrbanizacion"].ToString();
            cEtapa = dtDatos.Rows[0]["cEtapa"].ToString();
            cManzana = dtDatos.Rows[0]["cManzana"].ToString();
            cLote = dtDatos.Rows[0]["cLote"].ToString();
            cPrefiBlock = dtDatos.Rows[0]["cPrefiBlock"].ToString();
            cPrefiDep = dtDatos.Rows[0]["cPrefiDep"].ToString();
            cPrefiUrba = dtDatos.Rows[0]["cPrefiUrba"].ToString();
            cReservadoF = dtDatos.Rows[0]["cReservadoF"].ToString();
            cLongFoto = dtDatos.Rows[0]["cLongFoto"].ToString();
            cLongFirma = dtDatos.Rows[0]["cLongFirma"].ToString();
            cReservConCeros = dtDatos.Rows[0]["cReservConCeros"].ToString();
            cReservConEspacios = dtDatos.Rows[0]["cReservConEspacios"].ToString();
            cFotoF = dtDatos.Rows[0]["cFotoF"].ToString();
            cFirmaF = dtDatos.Rows[0]["cFirmaF"].ToString();
            return;
        }

        public void GetDataNA()
        {
            cErrorF = "9999";
            cDniF = "NA";
            cDigitoVerif = "NA";
            cApellidoPater = "NA";
            cApellidoMater = "NA";
            cApellidoCasada = "NA";
            cNombres = "NA";
            cUbigeoDep = "NA";
            cUbigeoProv = "NA";
            cUbigeoDist = "NA";
            cNomDep = "NA";
            cNomProv = "NA";
            cNomDist = "NA";
            cEstadoCivil = "NA";
            cGradoInstr = "NA";
            cEstatura = "NA";
            cSexo = "NA";
            cDocSustTipo = "NA";
            cDocSustNumero = "NA";
            cUbigeoDepNac = "NA";
            cUbigeoProvNac = "NA";
            cUbigeoDistNac = "NA";
            cNomDepNac = "NA";
            cNomProvNac = "NA";
            cNomDistNac = "NA";
            cFechaNac = "19000101";
            cNomPadre = "NA";
            cNomMadre = "NA";
            cFechaInsc = "19000101";
            cFechaExpe = "19000101";
            cConstanciaVota = "NA";
            cRestrccion = "";
            cPrefijoDireccion = "NA";
            cDireccion = "NA";
            cNumDireccion = "NA";
            cBlock = "NA";
            cInterior = "NA";
            cUrbanizacion = "NA";
            cEtapa = "NA";
            cManzana = "NA";
            cLote = "NA";
            cPrefiBlock = "NA";
            cPrefiDep = "NA";
            cPrefiUrba = "NA";
            cReservadoF = "NA";
            cLongFoto = "NA";
            cLongFirma = "NA";
            cReservConCeros = "NA";
            cReservConEspacios = "NA";
            cFotoF = "";
            cFirmaF = "";
            return;
        }



        public void separarDatos(string cDatos)
        {
            cErrorF = cDatos.Substring(128, 4);
            cDniF = cDatos.Substring(132, 8);
            cDigitoVerif = cDatos.Substring(140, 1);
            cApellidoPater = cDatos.Substring(141, 40);
            cApellidoMater = cDatos.Substring(181, 40);
            cApellidoCasada = cDatos.Substring(221, 40);
            cNombres = cDatos.Substring(261, 60);
            cUbigeoDep = cDatos.Substring(321, 2);
            cUbigeoProv = cDatos.Substring(323, 2);
            cUbigeoDist = cDatos.Substring(325, 2);
            cNomDep = cDatos.Substring(327, 40);
            cNomProv = cDatos.Substring(367, 40);
            cNomDist = cDatos.Substring(407, 40);
            cEstadoCivil = cDatos.Substring(447, 1);
            cGradoInstr = cDatos.Substring(448, 2);
            cEstatura = cDatos.Substring(450, 3);
            cSexo = cDatos.Substring(453, 1);
            cDocSustTipo = cDatos.Substring(454, 3);
            cDocSustNumero = cDatos.Substring(457, 20);
            cUbigeoDepNac = cDatos.Substring(477, 2);
            cUbigeoProvNac = cDatos.Substring(479, 2);
            cUbigeoDistNac = cDatos.Substring(481, 2);
            cNomDepNac = cDatos.Substring(483, 40);
            cNomProvNac = cDatos.Substring(523, 40);
            cNomDistNac = cDatos.Substring(563, 40);
            cFechaNac = cDatos.Substring(603, 8);
            cNomPadre = cDatos.Substring(611, 60);
            cNomMadre = cDatos.Substring(671, 60);
            cFechaInsc = cDatos.Substring(731, 8);
            cFechaExpe = cDatos.Substring(739, 8);
            cConstanciaVota = cDatos.Substring(747, 1);
            cRestrccion = cDatos.Substring(748, 2);
            cPrefijoDireccion = cDatos.Substring(750, 2);
            cDireccion = cDatos.Substring(752, 60);
            cNumDireccion = cDatos.Substring(812, 4);
            cBlock = cDatos.Substring(816, 3);
            cInterior = cDatos.Substring(819, 8);
            cUrbanizacion = cDatos.Substring(827, 30);
            cEtapa = cDatos.Substring(857, 4);
            cManzana = cDatos.Substring(861, 4);
            cLote = cDatos.Substring(865, 4);
            cPrefiBlock = cDatos.Substring(869, 2);
            cPrefiDep = cDatos.Substring(871, 2);
            cPrefiUrba = cDatos.Substring(873, 2);
            cReservadoF = cDatos.Substring(875, 20);
            cLongFoto = cDatos.Substring(895, 9);
            cLongFirma = cDatos.Substring(904, 9);
            cReservConCeros = cDatos.Substring(913, 18);
            cReservConEspacios = cDatos.Substring(931, 14);
            //int nLongFoto = Convert.ToInt32(cLongFoto);
            //int nLongFirma = Convert.ToInt32(cLongFirma);
            //cFoto = cDatos.Substring(945, nLongFoto);
            //cFirma = cDatos.Substring(945 + nLongFoto, nLongFirma);
        }
    }
}
