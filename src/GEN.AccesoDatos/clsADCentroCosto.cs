using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADCentroCosto
    {
        public clsLstCentroCosto ADListCentroCosto(int idPadre)
        {
            clsLstCentroCosto lstCentroCosto = new clsLstCentroCosto();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("GEN_ListaCentroCosto_SP", idPadre);
            foreach (DataRow item in ds.Rows)
            {
                lstCentroCosto.Add(new clsCentroCosto()
                {
                   IdCentroCosto = Convert.ToInt32(item["IdCentroCosto"].ToString()),
                   cCentroCosto =  item["cCentroCosto"].ToString(),
                   IdCentroCostoPadre = Convert.ToInt32(item["IdCentroCostoPadre"].ToString()),
                   lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                   nOrden = Convert.ToInt32(item["nOrden"].ToString()),                    
                });
            }
            return lstCentroCosto;
        }
    }
}
