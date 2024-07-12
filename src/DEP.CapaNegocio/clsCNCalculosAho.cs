using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityLayer;
using GEN.Funciones;
using DEP.AccesoDatos;

namespace DEP.CapaNegocio
{
    public class clsCNCalculosAho
    {
        Decimal nTEA = 0.00m;

        //============================================================================
        //---Calculo Ahorro Corriente
        //============================================================================
        public Decimal CalcularIntAhoCorriente(Decimal nTasInt, int nDiasTrans, Decimal nSalCapital)
        {
            //nTEA = nTasInt / 12.00;
            //nTEA = (Math.Pow((1 + nTEA / 100.00), 12) - 1) * 100;

            nTEA = nTasInt;
            //Decimal nFactor = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (1 / 12.00)) - 1) / 30;
            //Decimal nInteres = (nFactor * nSalCapital) * nDiasTrans;
            Decimal nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1) * nSalCapital;
            return Math.Round(nInteres,2);
        }

        //============================================================================
        //---Calculo Plazo Fijo
        //============================================================================
        public Decimal CalcularIntAhoPlazo(Decimal nTasInt, int nDiasTrans, Decimal nSalCapital)
        {
            //nTEA = nTasInt / 12.00;
            //nTEA = Convert.ToDecimal(Math.Pow((1 + nTEA / 100.00), 12) - 1) * 100;
            
            nTEA = nTasInt;
            Decimal nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1) * nSalCapital;
            return Math.Round(nInteres,2);
        }

        //============================================================================
        //---Calculo Interes Adelantado Plazo Fijo
        //============================================================================
        public Decimal CalcularIntAdelantado(Decimal nTasInt, int nDiasTrans, Decimal nSalCapital)
        {
            //nTEA = nTasInt / 12.00;
            //nTEA = (Math.Pow((1 + nTEA / 100.00), 12) - 1) * 100;

            nTEA = nTasInt;
            Decimal nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1);
            return Math.Round((nInteres * nSalCapital) / (nInteres + 1), 2);
        }
 
        //============================================================================
        //---Calculo Interes por Productos
        //============================================================================
        public Decimal CalcularInteresAho(Decimal nTasInt, int nDiasTrans, Decimal nSalCapital, int nTipCta)
        {
            Decimal nInteres = 0.00m;
            //--Primero Hallmos la TEA, Para los Calculos.
            //nTEA = nTasInt / 12.00;
            //nTEA = (Math.Pow((1 + nTEA / 100.00), 12) - 1) * 100;
           
            nTEA = nTasInt;
            switch (nTipCta)
            {
                case 1:  //--Calculo para Cuentas Corrientes
                    //Decimal nFactor = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (1 / 12.00)) - 1) / 30;
                    //nInteres = (nFactor * nSalCapital) * nDiasTrans;
                    nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1) * nSalCapital;
                    nInteres = Math.Round(nInteres, 2);
                    break;
                case 2: //--Calculo para Cuentas de Plazo Fijo
                    nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1) * nSalCapital;
                    nInteres = Math.Round(nInteres, 2);
                    break;
                case 3:  //--Calculo para Cuentas CTS
                    nInteres = Convert.ToDecimal(Math.Pow((1 + ((double)nTEA / 100.00)), (nDiasTrans / 360.00)) - 1) * nSalCapital;
                    nInteres = Math.Round(nInteres, 2);
                    break;                
            }
            return nInteres;
        }

        //============================================================================
        //---Calcular Pre Cancelación de Plazos Fijos
        //============================================================================
        public Decimal CalcularPreCancelacion(int idCuenta, DateTime dFechaCancel, Decimal nTasaCancel, ref decimal nCapital)
        {
            Decimal nInteres = 0.00m;

            clsADDeposito clsDeposito = new clsADDeposito();

            DataTable dtCancelCta= clsDeposito.ADPrecancelacionCtas(idCuenta, dFechaCancel, nTasaCancel);
            if (dtCancelCta.Rows.Count>0)
            {
                nInteres = Convert.ToDecimal(dtCancelCta.Rows[0]["nInteresTotal"]);
                nCapital = Convert.ToDecimal(dtCancelCta.Rows[0]["nMontoCapital"]);
            }
            
            return nInteres;
        }

        //--====================================================================
        //---método que calcula el plan de pagos de Depositos
        //--====================================================================
        public DataTable CalculaPpgDep(Decimal nMonDepos, DateTime dFecApe,  DateTime dFecDepos, int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag, Decimal nMonComis)
        {
            int nDiaAcumul = 0;
            clsFunUtiles FunUtiles = new clsFunUtiles();
            //DateTime dFecNewCuo = dFecDesemb.adddays(Convert.ToDouble (nDiaGraCta));
            DateTime dFecNewCuo = dFecApe.AddDays(Convert.ToDouble (nDiaGraCta));
            DateTime DfecVeriFec;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));
            ppg.Columns.Add("capital", typeof(Decimal));
            ppg.Columns.Add("interes", typeof(Decimal));
            ppg.Columns.Add("comisiones", typeof(Decimal));
            ppg.Columns.Add("itf", typeof(Decimal));
            ppg.Columns.Add("imp_cuota", typeof(Decimal));

            int nNumMesCuo = 0;
            int nNumAñoCuo = 0;

            if (nTipPerPag == 1) //Fecha Fija
            {
                if (nDiaGraCta == 0)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(0));
                }
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = i;
                    if (i == 1) // Si primera cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month;                       
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else
                    {
                        if (i == 2)  // Segunda cuota validamos
                        {
                            if (dFecApe < dFecDepos)
                            {
                                nNumMesCuo = dFecDepos.Month;
                            }
                            else
                            {
                                nNumMesCuo = dFecNewCuo.Month + 1;
                            }
                        }
                        else
                        {
                            nNumMesCuo = dFecNewCuo.Month + 1;
                        }

                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    if (i>1)
                    {
                        nDiaFecAux = nDiaFecPag;
                        while (true)
                        {
                            if (DateTime.TryParse((nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString()), out DfecVeriFec))
                            {
                                dFecNewCuo = DateTime.Parse(nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString());
                                break;
                            }
                            nDiaFecAux = nDiaFecAux - 1;
                        }
                    }
                    else
                    {
                        dFecNewCuo = dFecApe;   
                    }
                    

                    fila["fecha"] = dFecNewCuo;
                    if (i == 1)
                    {
                        //fila["dias"] = (dFecNewCuo - dFecDesemb).Days;
                        fila["dias"] = (dFecNewCuo - dFecApe).Days;
                    }
                    else
                    {
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(ppg.Rows[i - 2]["fecha"])).Days;            
                    }
                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;
                    fila["capital"] = Math.Round(nMonDepos,2);
                    fila["comisiones"] = 0.00;
                    fila["interes"] = 0.00;
                    Decimal nItf;
                    nItf = FunUtiles.truncar(((nMonDepos) * Convert.ToDecimal(clsVarGlobal.nITF) / 100.00m), 2, 1);
                    fila["Itf"] = Math.Round(nItf, 2);
                    fila["imp_cuota"] = Math.Round(nMonDepos,2) + Math.Round(nItf, 2);
                           
                    ppg.Rows.Add(fila);
                }
            }
            ppg.AcceptChanges();
            return ppg;
        }

        //--=============================================================================================================
        //---Método que calcula el plan de pagos de Depositos Mensuales de sus Intereses
        //--=============================================================================================================
        public DataTable CalculaPpgDepMensual(Decimal nMonDepos, DateTime dFecApe, int nPlazo, Decimal nTasa)
        {
            clsCNCalculosAho nInteres = new clsCNCalculosAho();

            DateTime dFecNewCuo = dFecApe.AddDays(Convert.ToDouble (nPlazo));

            DateTime dFechaAux = dFecApe;
            DateTime dFechaNew = dFecApe;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("concepto", typeof(string));
            ppg.Columns.Add("interes", typeof(Decimal));            
            ppg.Columns.Add("capital", typeof(Decimal));
            ppg.Columns.Add("dias_acu", typeof(int));
            ppg.Columns.Add("comisiones", typeof(Decimal));

            //-------------------------------------------------------
            //--Insertamos el primer Registro con fecha apertura
            //-------------------------------------------------------
            DataRow filaini = ppg.NewRow();
            filaini["cuota"] = 0;
            filaini["fecha"] = dFecApe;
            filaini["dias"] = 0;
            filaini["concepto"] = "Deposito";
            filaini["interes"] = 0;
            filaini["capital"] = nMonDepos;            
            filaini["dias_acu"] = 0;
            filaini["comisiones"] = 0;
            ppg.Rows.Add(filaini);

            int k = 0,n=0,igualdad=0;

            for (int i = 1; i <= nPlazo; i++)
            {                
                n = n + 1;
   
                dFechaAux = Convert.ToDateTime(dFecApe).AddDays(i);
                dFechaNew = Convert.ToDateTime(dFecApe).AddDays(i+1);
                if (dFechaAux.Month != dFechaNew.Month)
                {                    
                    k = k + 1;
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = k;
                    fila["fecha"] = dFechaAux;
                    fila["dias"] = n;
                    fila["concepto"] = "Cap. Interés";
                    fila["interes"] = Math.Round(nInteres.CalcularInteresAho(nTasa, n, nMonDepos, 2), 2);
                    fila["capital"] = nMonDepos;                    
                    fila["dias_acu"] = i;
                    fila["comisiones"] = 0;
                    ppg.Rows.Add(fila);
                    n = 0;
                    if (i==nPlazo)
                    {
                        igualdad = 1;
                    }
                }

                //-------------------------------------------------------
                //--Cuando Cumple el Plazo
                //-------------------------------------------------------
                if (i == nPlazo && igualdad==0)
                {
                    k = k + 1;
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = k;
                    fila["fecha"] = dFechaAux;
                    fila["dias"] = n;
                    fila["concepto"] = "Cap. Interés";
                    fila["interes"] = Math.Round(nInteres.CalcularInteresAho(nTasa, n, nMonDepos, 2), 2);
                    fila["capital"] = nMonDepos;                    
                    fila["dias_acu"] = i;
                    fila["comisiones"] = 0;
                    ppg.Rows.Add(fila);   
                }

                //-------------------------------------------------------
                //--Calculamos los Intereses Mensuales
                //-------------------------------------------------------
                //for (int s = 0; s < ppg.Rows.Count; s++)
                //{
                //    nInteres.CalcularInteresAho(nTasa, nPlazo, nMonDepos,2);
                //}

            }

            ppg.AcceptChanges();
            return ppg;
        }
    }
}
