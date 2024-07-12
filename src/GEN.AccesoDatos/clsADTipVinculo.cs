using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADTipVinculo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public clslisTipoVinculo ListaTipVinculo()
        {
            clslisTipoVinculo listatipovinculo= new clslisTipoVinculo();
            DataTable dt= objEjeSp.EjecSP("Gen_ListaTipVinculo_Sp");
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    listatipovinculo.Add(new clsTipoVinculo()
                    {
                        idTipoVinculo = (int)item["idTipoVinculo"],
                        cTipoVinculo = item["cTipoVinculo"].ToString(),
                        nTipVinPer = (int)item["nTipVinPer"]
                    });
                }
                
            }
             return listatipovinculo;
        }
    }
}
