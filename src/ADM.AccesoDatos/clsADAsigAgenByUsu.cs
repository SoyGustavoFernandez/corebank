using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using GEN.Funciones;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADAsigAgenByUsu
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsAgenByUsu> ADGetAgenByUsu(int idAgenByUsu)
        {
            DataTable dtResult = objEjeSp.EjecSP("ADM_ListaAsigAgenUsu_Sp", idAgenByUsu);
            return MapeaTablaEntidadAgenByUsu(dtResult);
        }

        public clsDBResp ADGuardarAgenByUsu(clsAgenByUsu objAgenByUsu)
        {
            List<clsAgenByUsu> lstAgenByUsu = new List<clsAgenByUsu>();
            lstAgenByUsu.Add(objAgenByUsu);
            string xmlAgenByUsu = lstAgenByUsu.GetXml<clsAgenByUsu>();
            DataTable dtResult = objEjeSp.EjecSP("ADM_AsigAgenUsu_Sp", xmlAgenByUsu);
            return new clsDBResp(dtResult);
        }

        private List<clsAgenByUsu> MapeaTablaEntidadAgenByUsu(DataTable dtResult)
        {
            List<clsAgenByUsu> lstAgenByUsu = new List<clsAgenByUsu>();

            foreach (DataRow row in dtResult.Rows)
            {
                lstAgenByUsu.Add(
                    new clsAgenByUsu()
                    {
                        idAgenByUsu = Convert.ToInt32(row["idAgenByUsu"]),
                        idAgencia = Convert.ToInt16(row["idAgencia"]),
                        cAgencia = Convert.ToString(row["cAgencia"]),
                        idUsuAsig = Convert.ToInt32(row["idUsuAsig"]),
                        lPrincipal = Convert.ToBoolean(row["lPrincipal"]),
                        dFecha = Convert.ToDateTime(row["dFecha"]),
                        idUsuario = Convert.ToInt32(row["idUsuario"]),
                        lVigente = Convert.ToBoolean(row["lVigente"])
                    });
            }
            return lstAgenByUsu;
        }
    }
}