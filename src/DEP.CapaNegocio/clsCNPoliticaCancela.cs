using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Collections;

namespace DEP.CapaNegocio
{
    public class clsCNPoliticaCancela
    {
        clsCNDeposito clsCNDep = new clsCNDeposito();
        private Decimal ntasaCanSimple = 0.0833m;

        public ArrayList cancelaDepositoCorriente(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura)
        {
            ArrayList arlDatCancela = new ArrayList();
            Decimal nInteres = 0.0m;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days - 1;

            DateTime dFechaCancelacion = clsVarGlobal.dFecSystem;
            string cObservacion = "";
            bool lPlazoCumplido = true;

            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);
            nInteres = nMonto * nTasaDia * nPlazoCumplido;

            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(nTasaDia);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);
            return arlDatCancela;
        }

        public ArrayList cancelaDepositoPlazo(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura)
        {
            ArrayList arlDatCancela = new ArrayList();

            Decimal nInteres = 0.0m;

            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            DateTime dFechaCancelacion = dFechaApertura.AddDays(nPlazo + 1);
            string cObservacion = "";
            bool lPlazoCumplido = false;

            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days;

            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);

            if (nPlazoCumplido - nPlazo + 1 >= 0)
            {
                nTasaDia = Math.Round(nTasa / 3000.00m, 8);
                lPlazoCumplido = true;
                cObservacion = "Se cancelará con la tasa pactada, cumplió el plazo";
            }
            else
            {
                nTasaDia = Math.Round(ntasaCanSimple / 3000.00m, 8);
                lPlazoCumplido = false;
                cObservacion = "Se cancelará con tasa simple(TM) de:" + ntasaCanSimple.ToString() + ", \n aún no se cumple el plazo";
            }

            nInteres = Math.Round(nMonto * nTasaDia * nPlazoCumplido, 4);


            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(ntasaCanSimple);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);

            return arlDatCancela;
        }

        public ArrayList cancelaDepositoPlazoCash(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura, Decimal nIntEntregado)
        {
            ArrayList arlDatCancela = new ArrayList();

            Decimal nInteres = 0.0m;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days;

            DateTime dFechaCancelacion = dFechaApertura.AddDays(nPlazo + 1);
            string cObservacion = "";
            bool lPlazoCumplido = false;

            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);
            if (nPlazoCumplido - nPlazo + 1 >= 0)
            {
                nTasaDia = Math.Round(nTasa / 3000.00m, 8);
                lPlazoCumplido = true;
                cObservacion = "Se cancelará con la tasa pactada, cumplió el plazo";
                nInteres = nIntEntregado;
            }
            else
            {

                nTasaDia = Math.Round(ntasaCanSimple / 3000.00m, 8);
                lPlazoCumplido = false;
                cObservacion = "Se cancelará con tasa simple(TM) de:" + ntasaCanSimple.ToString() + ", \n aún no se cumple el plazo y se restará el interes adelantado";
                nInteres = (nMonto * nTasaDia * nPlazoCumplido) - nIntEntregado;
            }

            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(ntasaCanSimple);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);

            return arlDatCancela;
        }

        public ArrayList cancelaDepositoJuntaDiario(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura)
        {
            ArrayList arlDatCancela = new ArrayList();

            Decimal nInteres = 0.0m;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days;

            DateTime dFechaCancelacion = dFechaApertura.AddDays(nPlazo + 1);
            string cObservacion = "";
            bool lPlazoCumplido = false;


            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);
            if (nPlazoCumplido - nPlazo + 3 >= 0)
            {
                nTasaDia = Math.Round(nTasa / 3000.00m, 8);
                lPlazoCumplido = true;
                cObservacion = "Se cancelará con la tasa pactada, cumplió el plazo";
                if (!validarCancelacionJuntaDiario(idCuenta))
                {
                    nTasaDia = 0.00m;
                    lPlazoCumplido = false;
                    cObservacion = "Se cancelará con tasa(TM) de:" + nTasaDia.ToString() + ", \n no se completó con los depositos";
                }
            }
            else
            {
                nTasaDia = 0.00m;
                lPlazoCumplido = false;
                cObservacion = "Se cancelará con tasa(TM) de:" + nTasaDia.ToString() + ", \n aún no se cumple el plazo";
            }

            nInteres = nMonto * nTasaDia * nPlazoCumplido;

            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(nTasaDia);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);
            return arlDatCancela;
        }
        public ArrayList cancelaDepositoCrecerSocio(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura, Decimal nIntGenerado)
        {
            ArrayList arlDatCancela = new ArrayList();

            Decimal nInteres = 0.0m;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days;

            DateTime dFechaCancelacion = dFechaApertura.AddDays(nPlazo + 31);
            string cObservacion = "";
            bool lPlazoCumplido = false;

            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);
            if (nPlazoCumplido - nPlazo + 31 >= 0)
            {
                nInteres = nIntGenerado;
                lPlazoCumplido = true;
                cObservacion = "Se cancelará con la tasa pactada, cumplió el plazo";
            }
            else
            {
                nTasaDia = Math.Round(ntasaCanSimple / 3000.00m, 8);
                nInteres = Math.Round(nMonto * nTasaDia * nPlazoCumplido, 4);
                lPlazoCumplido = false;
                cObservacion = "Se cancelará con tasa simple(TM) de:" + ntasaCanSimple.ToString() + ", \n aún no se cumple el plazo";

            }

            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(ntasaCanSimple);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);
            return arlDatCancela;
        }

        public bool validarDepositoJuntaDiario(int nPlazo, DateTime dFechaApertura)
        {
            bool lValido = false;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;

            if (((dFechaSistema - dFechaApertura).Days - nPlazo + 2) == 0)
            {
                lValido = true;
            }

            return lValido;
        }
        public bool validarCancelacionJuntaDiario(int idCuenta)
        {
            bool lValido = false;

            if (clsCNDep.CNValCanCtaDepPro(idCuenta).Rows[0][0].ToString() == "1")
            {
                lValido = true;
            }

            return lValido;
        }

        public ArrayList cancelaDepositoCts(int idCuenta, Decimal nMonto, int nPlazo, int idMoneda, Decimal nTasa, DateTime dFechaApertura)
        {
            ArrayList arlDatCancela = new ArrayList();
            Decimal nInteres = 0.0m;
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nPlazoCumplido = (dFechaSistema - dFechaApertura).Days - 1;

            DateTime dFechaCancelacion = clsVarGlobal.dFecSystem;
            string cObservacion = "";
            bool lPlazoCumplido = true;

            Decimal nTasaDia = Math.Round(nTasa / 3000.00m, 8);
            nInteres = nMonto * nTasaDia * nPlazoCumplido;

            arlDatCancela.Add(nInteres);
            arlDatCancela.Add(dFechaCancelacion);
            arlDatCancela.Add(lPlazoCumplido);
            arlDatCancela.Add(nTasaDia);
            arlDatCancela.Add(cObservacion);
            arlDatCancela.Add(nPlazoCumplido);
            return arlDatCancela;
        }
    }
}
