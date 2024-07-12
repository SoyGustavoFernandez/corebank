using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Data;

namespace CNT.AccesoDatos
{
    public class clsADCtaContable
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsCtaContable> listarctabyidpadre(int idnodoPadre)
        {
            List<clsCtaContable> lisctactb = new List<clsCtaContable>();

            DataTable dtCtaContable = objEjeSp.EjecSP("CNT_ListaCuentaContable_sp", idnodoPadre);
            if (dtCtaContable.Rows.Count>0)
            {
                foreach (DataRow item in dtCtaContable.Rows)
                {
                    lisctactb.Add(new clsCtaContable()
                    {
                        idCuenta = Convert.ToInt32(item["idcuenta"]),
                        idCuentaPadre = Convert.ToInt32(item["idCuentaPadre"]),
                        cCuentaContable = item["cCuentaContable"].ToString(),
                        cDescripcion = item["cDescripcion"].ToString(),
                        cDesCtaCtb = item["cDesCtaCtb"].ToString(),
                        nLongitud = Convert.ToInt32(item["nLongitud"]),
                        lVigente = Convert.ToBoolean(item["lVigente"]),
                        nValSoles = Convert.ToDecimal(item["nValSoles"]),
                        nValDolares = Convert.ToDecimal(item["nValDolares"]),
                        lIndicaSBS = Convert.ToBoolean(item["lIndicaSBS"]),
                        idNaturalezaCta = Convert.ToInt16(item["idNaturalezaCta"]),
                        nValorIntegrado = Convert.ToDecimal(item["nValIntegrado"])
                    });
                }                
            }
            
            return lisctactb;
        }


        public List<clsCtaContable> listarpadresnodo(int idnodoPadre)
        {
            List<clsCtaContable> lisctactb = new List<clsCtaContable>();

            DataTable dtCtaContable = objEjeSp.EjecSP("CNT_ListaPadresCtaCtb_sp", idnodoPadre);
            if (dtCtaContable.Rows.Count > 0)
            {
                foreach (DataRow item in dtCtaContable.Rows)
                {
                    lisctactb.Add(new clsCtaContable()
                    {
                        idCuenta = Convert.ToInt32(item["idcuenta"]),
                        idCuentaPadre = item["idCuentaPadre"].ToString()==""?0: Convert.ToInt32(item["idCuentaPadre"]),
                        cCuentaContable = item["cCuentaContable"].ToString(),
                        cDescripcion = item["cDescripcion"].ToString(),
                        cDesCtaCtb = item["cDesCtaCtb"].ToString(),
                        nLongitud = Convert.ToInt32(item["nLongitud"]),
                        lVigente = Convert.ToBoolean(item["lVigente"]),
                        lIndicaSBS = Convert.ToBoolean(item["lIndicaSBS"]),
                        idNaturalezaCta = Convert.ToInt16(item["idNaturalezaCta"])
                    });
                }
            }

            return lisctactb;
        }

        public clsCtaContable detallectactb(string ctactb)
        {
            clsCtaContable lisctactb = new clsCtaContable();
            DataTable dtCtaContable = objEjeSp.EjecSP("CNT_DetalleCuentaContable_sp", ctactb);
            if (dtCtaContable.Rows.Count > 0)
            {
                foreach (DataRow item in dtCtaContable.Rows)
                {
                    lisctactb.idCuenta = Convert.ToInt32(item["idcuenta"]);
                    lisctactb.idCuentaPadre = item["idCuentaPadre"].ToString()==""?0: Convert.ToInt32(item["idCuentaPadre"]);
                    lisctactb.cCuentaContable = item["cCuentaContable"].ToString();
                    lisctactb.cDescripcion = item["cDescripcion"].ToString();
                    lisctactb.cDesCtaCtb = item["cDesCtaCtb"].ToString();
                    lisctactb.nLongitud = Convert.ToInt32(item["nLongitud"]);
                    lisctactb.lVigente = Convert.ToBoolean(item["lVigente"]);
                    lisctactb.lAgencia = Convert.ToBoolean(item["lAgencia"]);
                    lisctactb.nAgencia = Convert.ToInt16(item["nAgencia"]);
                    lisctactb.nHijos = Convert.ToInt16(item["nHijos"]);
                    lisctactb.lIndicaSBS = Convert.ToBoolean(item["lIndicaSBS"]);
                    lisctactb.idNaturalezaCta = Convert.ToInt16(item["idNaturalezaCta"]);
                }
            }

            return lisctactb;
        }
        public DataTable ADInsertaCtaCtb(string cCuentaContable, string cDescripcion, bool lIndicaSBS,int idNaturalezaSBS)
        {
            return objEjeSp.EjecSP("CNT_InsertaCuenta_sp", cCuentaContable, cDescripcion, lIndicaSBS,idNaturalezaSBS);
        }
        public DataTable ADInsertaCtaCtb(string cCuentaContable, bool lIndicaSBS, int idNaturalezaSBS)
        {
            return objEjeSp.EjecSP("CNT_InsertaCuentasAgencia_sp", cCuentaContable, lIndicaSBS,  idNaturalezaSBS);
        }
        public DataTable ADActualizaCtaCtb(string cCuentaContable, string cDescripcion, bool lIndicaSBS, int idNaturalezaSBS, bool lVigente)
        {
            return objEjeSp.EjecSP("CNT_ActualizaCuenta_sp", cCuentaContable, cDescripcion,lIndicaSBS, idNaturalezaSBS,lVigente);
        }
        public DataTable ADDesactivarCtaCtb(string cCuentaContable)
        {
            return objEjeSp.EjecSP("CNT_DesactivaCuenta_sp", cCuentaContable);
        }
        public DataTable ReplicaCuentas(int idProdOri, int idProDes, int idTipCre, int idModulo)
        {
            return objEjeSp.EjecSP("CNT_ReplicaDinamicaCtb_sp", idProdOri, idProDes, idTipCre, idModulo);
        }
    }
}
