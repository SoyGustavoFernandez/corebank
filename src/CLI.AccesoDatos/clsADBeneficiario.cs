using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADBeneficiario
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();        
        
        public clslisBeneficiario listarbeneficiarios(int idSocio)
        {
            clslisBeneficiario lista = new clslisBeneficiario();

            DataTable dt = objEjeSp.EjecSP("CLI_listaBeneficiariosSocio_sp", idSocio);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsBeneficiario()
                    {
                        idCli = (int)item["idCli"],
                        cApeCasBen = (string)item["cApeCasBen"],
                        cApeMatBen = (string)item["cApeMatBen"],
                        cApePatBen = (string)item["cApePatBen"],
                        cBeneficiario = (string)item["cBeneficiario"],
                        cDireccion = (string)item["cDireccion"],
                        cDocIdeBen = item["cDocIdeBen"].ToString(),
                        cNombres = (string)item["cNombres"],
                        dFecBajBen = item["dFecBajBen"] == DBNull.Value ? null : (DateTime?)item["dFecBajBen"],
                        dFecModBen = item["dFecModBen"] == DBNull.Value ? null : (DateTime?)item["dFecModBen"],
                        dFecRegBen = (DateTime)item["dFecRegBen"],
                        idBeneficiario = (int)item["idBeneficiario"],
                        idEstado = (int)item["idEstado"],
                        idMotivBaj = (int)item["idMotivBaj"],
                        idTipoRela = (int)item["idTipoRela"],
                        idUbigeo = (int)item["idUbigeo"],
                        idUsuModBen = item["idUsuModBen"] == DBNull.Value ? null : (int?)item["idUsuModBen"],
                        idUsuRegBen = (int)item["idUsuRegBen"],
                        nBeneficio = (decimal)item["nBeneficio"]
                    });

                }

            }

            return lista;
        }
		public DataTable listarBeneficiariosComoTabla(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_listaBeneficiariosSocio_sp", idSocio);
        }

        public DataTable listarSituacIndemizacBenef(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_listarSituacIndemizacBenef_sp", idSocio);
        }
		public DataTable listarSituacDevolucionBenef(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_listarSituacDevolucionBenef_sp", idSocio);
        }
    }
}
