using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNScoring
    {
        clsADScoring ADScoring = new clsADScoring();

        public clsCNScoring()
        {
            ADScoring =  new clsADScoring();
        }

        public clsCNScoring(bool lWS)
        {
            ADScoring = new clsADScoring(lWS);
        }

        public decimal obtValNivelEndeudamiento(clsVariableScoring clsVariable, decimal nMontoSolicitado, decimal nMontoRCC)
        {
            decimal nPuntuacion = 0.00m;

            if (Convert.ToDecimal(clsVariable.nRiesgoBajoValor) >= nMontoRCC + nMontoSolicitado)
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (Convert.ToDecimal(clsVariable.nRiesgoMedioValor) >= nMontoRCC + nMontoSolicitado)
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (Convert.ToDecimal(clsVariable.nRiesgoAltoValor) >= nMontoRCC + nMontoSolicitado)
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }
            return nPuntuacion;
        }

        public decimal obtValCalificacionRCC(clsVariableScoring clsVariable, int nCalificacionRCC, bool lBancarizado)
        {
            decimal nPuntuacion = 0.00m;

            if (Convert.ToInt32(clsVariable.nRiesgoBajoValor) == nCalificacionRCC)
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (nCalificacionRCC == -1)//SIN EXPERIENCIA CREDITICIA
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else//OTROS CASOS QUE NO CONCUERDEN CON LAS DOS PRIMERAS
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }
            return nPuntuacion;
        }

        public decimal obtValNumeroEntidadesRCC(clsVariableScoring clsVariable, int nNroEntidadesRCC)
        {
            decimal nPuntuacion = 0.00m;

            if (Convert.ToInt32(clsVariable.nRiesgoBajoValor) >= nNroEntidadesRCC)
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (Convert.ToInt32(clsVariable.nRiesgoMedioValor) >= nNroEntidadesRCC)
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (Convert.ToInt32(clsVariable.nRiesgoAltoValor) >= nNroEntidadesRCC)
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValExperienciaNegocio(clsVariableScoring clsVariable, int nExperienciaNegocio)
        {
            decimal nPuntuacion = 0.00m;

            if (VerificarSiEstaEnRango(clsVariable.nRiesgoBajoValor, nExperienciaNegocio))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoMedioValor, nExperienciaNegocio))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoAltoValor, nExperienciaNegocio))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValFormalizado(clsVariableScoring clsVariable, bool lFormalizado)
        {
            decimal nPuntuacion = 0.00m;

            if (lFormalizado)
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValEdad(clsVariableScoring clsVariable, int nEdad)
        {
            decimal nPuntuacion = 0.00m;

            string[] nEdadRiesgoAlto = clsVariable.nRiesgoAltoValor.Split(';');

            if (VerificarSiEstaEnRango(clsVariable.nRiesgoBajoValor, nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoMedioValor, nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(nEdadRiesgoAlto[0], nEdad) || VerificarSiEstaEnRango(nEdadRiesgoAlto[1], nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValDestino(clsVariableScoring clsVariable, int idDestino)
        {
            decimal nPuntuacion = 0.00m;

            if (VerificarSiIncluye(clsVariable.nRiesgoBajoValor, idDestino))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiIncluye(clsVariable.nRiesgoMedioValor, idDestino))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiIncluye(clsVariable.nRiesgoAltoValor, idDestino))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }


        public decimal obtValRatioCuotaExcedente(clsVariableScoring clsVariable, decimal nRatioCalculado)
        {
            decimal nPuntuacion = 0.00m;

            if (VerificarSiEstaEnRango(clsVariable.nRiesgoBajoValor, nRatioCalculado))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoMedioValor, nRatioCalculado))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoAltoValor, nRatioCalculado))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }
            return nPuntuacion;
        }

        public decimal obtValEstadoCivil(clsVariableScoring clsVariable, int idEstadoCivil)
        {
            decimal nPuntuacion = 0.00m;

            if (VerificarSiIncluye(clsVariable.nRiesgoBajoValor, idEstadoCivil))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiIncluye(clsVariable.nRiesgoMedioValor, idEstadoCivil))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiIncluye(clsVariable.nRiesgoAltoValor, idEstadoCivil))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValPlazoCredito(clsVariableScoring clsVariable, int nEdad)
        {
            decimal nPuntuacion = 0.00m;

            if (VerificarSiEstaEnRango(clsVariable.nRiesgoBajoValor, nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoMedioValor, nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
            }
            else if (VerificarSiEstaEnRango(clsVariable.nRiesgoAltoValor, nEdad))
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }

        public decimal obtValResidencia(clsVariableScoring clsVariable, int idUsuario, string cUbigeo, bool lServicioWeb)
        {
            decimal nPuntuacion = 0.00m;

            DataTable dtResultado = ADScoring.VerificarUbigeoAgencia(idUsuario, cUbigeo, lServicioWeb);

            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0][1]) == 1)
                {
                    nPuntuacion = clsVariable.nRiesgoBajoCalificacion * clsVariable.nPuntuacion;
                }
                else
                {
                    nPuntuacion = clsVariable.nRiesgoMedioCalificacion * clsVariable.nPuntuacion;
                }
            }
            else
            {
                nPuntuacion = clsVariable.nRiesgoAltoCalificacion * clsVariable.nPuntuacion;
            }

            return nPuntuacion;
        }



        public bool VerificarSiIncluye(string cRango, int nValor)
        {
            string[] cValores = cRango.Split(',');
            foreach (string item in cValores)
            {
                if (Convert.ToInt32(item) == nValor)
                    return true;
            }
            return false;
        }

        public bool VerificarSiEstaEnRango(string cRango, int nValor)
        {
            string[] cRangos = cRango.Split(',');
            int nMinimo = Convert.ToInt32(cRangos[0]);
            int nMaximo = Convert.ToInt32(cRangos[1]);
            if (nMinimo <= nValor && nValor <= nMaximo)
                return true;
            return false;
        }

        public bool VerificarSiEstaEnRango(string cRango, decimal nValor)
        {
            string[] cRangos = cRango.Split(',');
            decimal nMinimo = Convert.ToDecimal(cRangos[0]);
            decimal nMaximo = Convert.ToDecimal(cRangos[1]);
            if (nMinimo <= nValor && nValor <= nMaximo)
                return true;
            return false;
        }

        public DataTable ObtenerDatosClienteScoring(string cNroDocumento, bool lServicioWeb)
        {
            return ADScoring.ObtenerDatosClienteScoring(cNroDocumento, lServicioWeb);
        }

        public DataTable ObtenerVariables(bool lServicioWeb)
        {
            return ADScoring.ObtenerVariables(lServicioWeb);
        }

        public DataTable ObtenerMaximoMontos(bool lBancarizado, int idDestino, decimal nMontoMaximoRCC, bool lServicioWeb)
        {
            return ADScoring.ObtenerMaximoMontos(lBancarizado, idDestino, nMontoMaximoRCC, lServicioWeb);
        }

        public double obtenerTasaScoring(decimal nMonto, bool lServicioWeb)
        {
            DataTable dtTasa = ADScoring.ObtenerMaximoMontos(nMonto, lServicioWeb);
            double nTasa = 5.0000D;

            if (dtTasa.Rows.Count > 0)
            {
                nTasa = Convert.ToDouble(dtTasa.Rows[0][0]);
            }

            return nTasa;
        }

        public DataTable RegistroLogScoring(string cNroDocumento, decimal nCalificacion, int idUsuario, int idEstado, bool lServicioWeb)
        {
            return ADScoring.RegistroLogScoring(cNroDocumento, nCalificacion, idUsuario, idEstado, lServicioWeb);
        }

        public DataTable ActualizarLogScoring(string cNroDocumento, decimal nCalificacion, int idUsuario, int idEstadoCivil, int nEdad, string cCodigoUbigeo, int nExperienciaNegocio, bool lFormalizado, int idDestino, decimal nMontoSolicitado, int nPlazo, decimal nExcedente, decimal nObligaciones, bool lServicioWeb)
        {
            return ADScoring.ActualizarLogScoring(cNroDocumento, nCalificacion, idUsuario, idEstadoCivil, nEdad, cCodigoUbigeo, nExperienciaNegocio, lFormalizado, idDestino, nMontoSolicitado, nPlazo, nExcedente, nObligaciones, lServicioWeb);
        }


        public DataTable VerificarAccesoMovil(int idusuario)
        {
            return ADScoring.VerificarAccesoMovil(idusuario);
        }

        public DataTable CNObtieneMensaje(int idGrupoCamp)
        {
            return ADScoring.ADObtieneMensaje(idGrupoCamp);
        }

    }
}
