using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNProfesion
    {
        clsADProfesion objlistaProfesion = new clsADProfesion();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListarProfesion()
        {
            return objlistaProfesion.ListaProfesion();
        }
        // Busqueda de profesiones
        public DataTable ListarProfesionBusqueda(string cNombre)
        {
            return objlistaProfesion.ListaProfesionBusqueda(cNombre);
        }
        //===============================================================
        //LISTA ENTIDAD REGULADORA
        //===============================================================
        public DataTable CNListaEntidadReg()
        {
            return objlistaProfesion.ADListaEntidadReg();
        }
        //===============================================================
        //LISTA PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable CNListaProfesionByEntidad(int idEntidad)
        {
            return objlistaProfesion.ADListaProfesionByEntidad(idEntidad);
        }
        //===============================================================
        //GRABA PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable CNGrabaProfesion(int idProfesion, string cProfesion, string cCodSUNAT, string cCodSBS, bool lAplicaSunat, bool lAplicaSBS, bool lVigente)
        {
            return objlistaProfesion.ADGrabaProfesion(idProfesion, cProfesion, cCodSUNAT, cCodSBS, lAplicaSunat, lAplicaSBS, lVigente);
        }
        //===============================================================
        //VALIDA EL REGISTRO PROFESIONES U OCUPACIONES
        //===============================================================
        public DataTable CNValidaregProfesion(string cProfesion)
        {
            return objlistaProfesion.ADValidaregProfesion(cProfesion);
        }
    }
}
