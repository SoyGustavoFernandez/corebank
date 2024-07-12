using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADCaracteristCta
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable listarCaractCta()
        {
            return objEjeSp.EjecSP("Gen_ListaCaractCta_sp");
        }

        public DataTable listarCaractCtaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinCaracteristicaCta");
        }
    }
}
