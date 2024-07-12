using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SER.Funciones
{
    public class clsCalculoComision
    {
        //====================================================================
        // Métodos para el cálculo de la comisión
        //====================================================================

        public decimal CalcularItf(decimal nMontoGiro)
        {
            decimal nITF = 0.005m;
            int nMontoGiroEntero = (int)(Math.Floor((double)nMontoGiro / 1000) * 1000);
            decimal nMontoITF = (nITF / 100) * nMontoGiroEntero;

            return nMontoITF;
        }

        public decimal CalcularRedondeoMinimo(decimal nParteDecimal)
        {
            decimal multiploCercano = Math.Floor(nParteDecimal / 0.1m) * 0.1m;
            decimal nMontoRedondeo = Math.Round(nParteDecimal - multiploCercano, 2);

            return nMontoRedondeo;
        }

        public decimal CalcularRedondeoMaximo(decimal nParteDecimal)
        {
            decimal multiploCercano = Math.Ceiling(nParteDecimal / 0.1m) * 0.1m;
            decimal montoRedondeo = multiploCercano - nParteDecimal;

            if (montoRedondeo == 0.1m)
            {
                return 0;
            }
            if (montoRedondeo < 0.1m)
            {
                return Math.Abs(montoRedondeo);
            }
            return 0;
        }

        public decimal CalcularRedondeo(decimal nNumero)
        {
            decimal nNumeroMultiplicado = nNumero * 100;
            decimal nNumeroSumado = nNumeroMultiplicado + 0.5m;
            decimal nValorTruncado = Math.Truncate(nNumeroSumado);
            decimal nResultado = nValorTruncado / 100;

            return nResultado;
        }

        private clsTarifarioGiros ObtenerTarifa(decimal nMonto, int idMoneda, int idTipoPersona, List<clsTarifarioGiros> objTarifario)
        {
            var result = (from item in objTarifario
                          where idMoneda == item.idMoneda &&
                          idTipoPersona == item.idTipoPersona &&
                          nMonto >= item.nMontoMinimo &&
                          nMonto <= item.nMontoMaximo
                          select item).ToList<clsTarifarioGiros>();
            if (result.Count > 0)
                return result[0];
            else
                throw new Exception("No se encuentra un tarifario configurado.");
        }

        //====================================================================
        // Función para el cálculo del monto total a partir del monto de giro
        //====================================================================

        public clsDatosCalculoComision CalcularMontoTotal(decimal nMontoGiro, int idMoneda, int idTipoPersona, List<clsTarifarioGiros> objTarifario, bool lCalcularRedondeo, clsTarifarioGiros aDatosTarifario = null)
        {
            if (nMontoGiro <= 0)
            {
                throw new Exception("El monto a girar debe de ser mayor a 0.");
            }

            int idTipoComision = 0;
            decimal nMontoComision = 0;
            decimal nMontoRedondeo = 0;
            decimal nMontoITF = 0;
            decimal nMontoTotal = 0;
            var objDatos = new clsDatosCalculoComision();

            if (aDatosTarifario == null)
            {
                aDatosTarifario = ObtenerTarifa(nMontoGiro, idMoneda, idTipoPersona, objTarifario);
                idTipoComision = aDatosTarifario.idTipComGiro;
                nMontoComision = aDatosTarifario.nMontoComision;
            }
            else
            {
                idTipoComision = aDatosTarifario.idTipComGiro;
                nMontoComision = aDatosTarifario.nMontoComision;
            }

            if (idTipoComision == (int)TipoComision.Simple)
            {
                nMontoTotal = (nMontoGiro + nMontoComision);

                //calculo de itf 

                if (nMontoGiro >= 1000)
                {
                    nMontoITF = CalcularItf(nMontoGiro);
                    nMontoTotal = nMontoTotal + nMontoITF;
                }

                //calculo de redondeo

                decimal nParteDecimal = nMontoTotal % 1;

                if (nParteDecimal != 0)
                {
                    nMontoRedondeo = CalcularRedondeoMinimo(nParteDecimal);
                    nMontoTotal = nMontoTotal - nMontoRedondeo;
                }
            }
            else if (idTipoComision == (int)TipoComision.Porcentual)
            {
                //calculo de comisión

                nMontoComision = (nMontoComision / 100) * nMontoGiro;
                nMontoComision = CalcularRedondeo(nMontoComision);
                nMontoTotal = (nMontoGiro + nMontoComision);

                //calculo de itf 

                if (nMontoGiro >= 1000)
                {
                    nMontoITF = CalcularItf(nMontoGiro);
                    nMontoTotal = nMontoTotal + nMontoITF;
                }

                if (lCalcularRedondeo == true)
                {
                    //calculo de redondeo

                    decimal nParteDecimal = nMontoTotal % 1;
                    if (nParteDecimal != 0)
                    {
                        nMontoRedondeo = CalcularRedondeoMinimo(nParteDecimal);
                        nMontoTotal = nMontoTotal - nMontoRedondeo;
                    }
                }
            }

            objDatos.nMontoGiro = nMontoGiro;
            objDatos.nRedondeo = nMontoRedondeo;
            objDatos.nComision = nMontoComision;
            objDatos.nITF = nMontoITF;
            objDatos.nMontoTotal = nMontoTotal;
            objDatos.objTarifario = aDatosTarifario;

            return objDatos;
        }

        //====================================================================
        // Función para el cálculo del monto de giro a partir del monto total
        //====================================================================

        public clsDatosCalculoComision CalcularMontoGiro(decimal nMontoTotal, int idMoneda, int idTipoPersona, List<clsTarifarioGiros> objTarifario, bool lCalcularRedondeo)
        {

            if (nMontoTotal <= 0)
            {
                throw new Exception("El monto a girar debe de ser mayor a 0.");
            }

            var objDatos = new clsDatosCalculoComision();

            clsTarifarioGiros objDatosTarifario = null;
            clsTarifarioGiros objDatosTarifario_1 = null;

            decimal nMontoComision = 0;
            decimal nMontoComision_1 = 0;
            decimal nMontoITF = 0;
            decimal nMontoRedondeo = 0;
            decimal nMontoGiro = 0;
            decimal nMontoGiroAnterior = 0;

            //optencion de la comision del monto


            objDatosTarifario = ObtenerTarifa(nMontoTotal, idMoneda, idTipoPersona, objTarifario);

            if (objDatosTarifario == null)
            {
                throw new Exception("No existe ningún tarifario para el monto a girar.");
            }

            nMontoComision = objDatosTarifario.nMontoComision;

            if (nMontoTotal >= 1000.01m)
            {
                nMontoComision = (nMontoComision / 100) * nMontoTotal;
                nMontoComision = CalcularRedondeo(nMontoComision);
            }

            //optencion del monto de giro

            nMontoGiro = nMontoTotal - nMontoComision;

            if (nMontoGiro <= 0)
            {
                throw new Exception("El monto a girar es menor o igual a cero.");
            }

            while (true)
            {
                objDatosTarifario_1 = ObtenerTarifa(nMontoGiro, idMoneda, idTipoPersona, objTarifario);
                nMontoComision_1 = objDatosTarifario_1.nMontoComision;

                if (nMontoGiro >= 1000.01m)
                {
                    nMontoComision_1 = (nMontoComision_1 / 100) * nMontoGiro;
                    nMontoComision_1 = CalcularRedondeo(nMontoComision_1);
                }
                if (nMontoGiro >= 1000)
                {
                    nMontoITF = CalcularItf(nMontoGiro);
                }

                decimal montoEquivalente = nMontoGiro + nMontoComision_1 + nMontoITF; //10002.72M

                if (montoEquivalente == nMontoTotal)
                {
                    objDatos.nMontoTotal = nMontoTotal;

                    objDatos.nMontoGiro = nMontoGiro;

                    objDatos.nComision = nMontoComision_1;

                    objDatos.nITF = nMontoITF;

                    objDatos.nRedondeo = 0;

                    break;
                }
                else if (montoEquivalente < nMontoTotal)
                {
                    nMontoGiroAnterior = nMontoGiro;
                    nMontoGiro = nMontoGiro + 0.01m;
                }
                else if (montoEquivalente > nMontoTotal)
                {
                    if (nMontoGiroAnterior != 0)
                    {
                        nMontoGiro = nMontoGiroAnterior;

                        objDatos.nMontoTotal = nMontoTotal;
                        objDatos.nMontoGiro = nMontoGiro;

                        objDatosTarifario_1 = ObtenerTarifa(nMontoGiro, idMoneda, idTipoPersona, objTarifario);
                        nMontoComision_1 = objDatosTarifario_1.nMontoComision;
                        if (nMontoGiro >= 1000.01m)
                        {
                            nMontoComision_1 = (nMontoComision_1 / 100) * nMontoGiro;
                            nMontoComision_1 = CalcularRedondeo(nMontoComision_1);
                        }

                        objDatos.nComision = nMontoComision_1;

                        if (nMontoGiro < 1000)
                            objDatos.nITF = 0;
                        else
                            objDatos.nITF = CalcularItf(nMontoGiro);

                        objDatos.nRedondeo = 0;

                        break;
                    }
                    else
                    {
                        nMontoGiro = nMontoGiro - 0.01m;
                    }
                }
            }

            if (lCalcularRedondeo == true)
            {
                //calculo de redondeo 

                decimal nParteDecimal = objDatos.nMontoGiro % 1;

                if (nParteDecimal != 0)
                {
                    nMontoRedondeo = CalcularRedondeoMaximo(nParteDecimal);
                    objDatos.nMontoGiro += nMontoRedondeo;
                }

                //recalculo de ITF

                if (objDatos.nMontoGiro < 1000)
                    objDatos.nITF = 0;
                else
                    objDatos.nITF = CalcularItf(objDatos.nMontoGiro);

                //recalculo de comisión


                objDatosTarifario = ObtenerTarifa(objDatos.nMontoGiro, idMoneda, idTipoPersona, objTarifario);

                nMontoComision = objDatosTarifario.nMontoComision;

                if (objDatos.nMontoGiro >= 1000.01m)
                {
                    nMontoComision = (nMontoComision / 100) * objDatos.nMontoGiro;
                    nMontoComision = CalcularRedondeo(nMontoComision);
                }

                objDatos.nComision = nMontoComision;


                //recalculo del monto a girar

                var prueba = nMontoTotal - objDatos.nITF - objDatos.nComision;

                nParteDecimal = prueba % 1;

                if (nParteDecimal != 0)
                    objDatos.nRedondeo = CalcularRedondeoMaximo(nParteDecimal);
            }

            return objDatos;
        }

    }
}
