using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADProfesion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaProfesion()
        {
            return objEjeSp.EjecSP("Gen_ListaProfesion_Sp");
        }
        //busqueda de Profesiones
        public DataTable ListaProfesionBusqueda(string cNombre)
        {
            return objEjeSp.EjecSP("Gen_ListaProfesionBus_Sp", cNombre);
        }
        //===============================================================
        //LISTA ENTIDAD REGULADORA
        //===============================================================
        public DataTable ADListaEntidadReg()
        {
            return objEjeSp.EjecSP("GEN_ListaEntidadesReguladoras_sp");
        }
        //===============================================================
        //LISTA PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable ADListaProfesionByEntidad(int idEntidad)
        {
            return objEjeSp.EjecSP("GEN_ListaProfesionesByEntidad_sp", idEntidad);
        }
        //===============================================================
        //GRABA PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable ADGrabaProfesion(int idProfesion, string cProfesion, string cCodSUNAT, string cCodSBS, bool lAplicaSunat, bool lAplicaSBS, bool lVigente)
        {
            return objEjeSp.EjecSP("GEN_GrabaProfesion_sp", idProfesion, cProfesion, cCodSUNAT, cCodSBS, lAplicaSunat, lAplicaSBS, lVigente);
        }
        //===============================================================
        //VALIDA EL REGISTRO PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable ADValidaregProfesion(string cProfesion)
        {
            return objEjeSp.EjecSP("GEN_ValidaRegProfesion_sp", cProfesion);
        }
    }
}
