using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using EntityLayer;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNCtaContable
    {
        clsADCtaContable objctactb = new clsADCtaContable();
        public List<clsCtaContable> listarctabyidpadre(int idnodoPadre)
        {
            return objctactb.listarctabyidpadre(idnodoPadre);
        }

        public List<clsCtaContable> listarpadresnodo(int idnodoPadre)
        {
            return objctactb.listarpadresnodo(idnodoPadre);
        }

        public clsCtaContable detallectactb(string ctactb)
        {
            return objctactb.detallectactb(ctactb);

        }
        public DataTable CNInsertaCtaCtb(string cCuentaContable, string cDescripcion, bool lIndicaSBS, int idNaturalezaSBS)
        {
            return objctactb.ADInsertaCtaCtb(cCuentaContable, cDescripcion, lIndicaSBS, idNaturalezaSBS);
        }
        public DataTable CNInsertaCtaCtb(string cCuentaContable, bool lIndicaSBS, int idNaturalezaSBS)
        {
            return objctactb.ADInsertaCtaCtb(cCuentaContable,  lIndicaSBS,  idNaturalezaSBS);
        }
        public DataTable CNActualizaCtaCtb(string cCuentaContable, string cDescripcion, bool lIndicaSBS,int idNaturalezaSBS,bool lVigente)
        {
            return objctactb.ADActualizaCtaCtb(cCuentaContable, cDescripcion,lIndicaSBS,idNaturalezaSBS,lVigente );
        }
        public DataTable CNDesactivarCtaCtb(string cCuentaContable)
        {
            return objctactb.ADDesactivarCtaCtb(cCuentaContable);
        }
        public DataTable ReplicaCuentas(int idProdOri, int idProDes, int idTipCre, int idModulo)
        {
            return objctactb.ReplicaCuentas(idProdOri, idProDes, idTipCre, idModulo);
        }
    }
}
