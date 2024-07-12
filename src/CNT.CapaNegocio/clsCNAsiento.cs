using CNT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EntityLayer;
using System.IO;

namespace CNT.CapaNegocio
{
    public class clsCNAsiento
    {
        clsADAsiento objctactb = new clsADAsiento();
        public DataTable CNConsultaAsiento(int nVoucher)
        {
            return objctactb.ADConsultaAsiento(nVoucher);
        }
        public DataTable CNInsertaAsiento(DateTime dFecha, int idAgencia, int idTipAsi, string cXmlAsiento, string cGlosa,int idUsuRegistra)
        {
            return objctactb.ADInsertaAsiento(dFecha, idAgencia,  idTipAsi, cXmlAsiento, cGlosa,idUsuRegistra);
        }
        public DataTable CNActualizaAsiento(DateTime dFecha, int idAgencia, int idTipAsi, int nVoucher, string cXmlAsiento, int idUsuReg, int idAgeReg, string cGlosaAct)
        {
            return objctactb.ADActualizaAsiento(dFecha, idAgencia, idTipAsi, nVoucher, cXmlAsiento, idUsuReg, idAgeReg, cGlosaAct);
        }
        public DataTable CNEliminarAsiento(DateTime dFecha, int idAgencia, int nVoucher, int idUsuReg, int idAgeReg, string cGlosa)
        {
            return objctactb.ADEliminarAsientoManual(dFecha, idAgencia, nVoucher, idUsuReg, idAgeReg, cGlosa);
        }
        public DataTable CNPLELibroDiario(DateTime dFecIni, DateTime dFecFin, int idMoneda)
        {
            return objctactb.ADPLELibroDiario(dFecIni, dFecFin, idMoneda);
        }
        public DataTable CNPLERegCompras(DateTime dFecIni, DateTime dFecFin)
        {
            return objctactb.ADPLERegCompras(dFecIni, dFecFin);
        }
        public DataTable CNPLELibroMayor(DateTime dFecIni, DateTime dFecFin, int idMoneda)
        {
            return objctactb.ADPLELibroMayor(dFecIni, dFecFin, idMoneda);
        }
        public string cNomArcPLELibroDiario(string idMoneda, int numRow, DateTime dFecFin)
        {
            switch (idMoneda)
            {
                case "0":
                    idMoneda = "1";
                    break;
                case "2":
                    idMoneda = "1";
                    break;
                case "3":
                    idMoneda = "2";
                    break;
                default:
                    idMoneda = "1";
                    break;
            }
            string cNomArch = "LE" + clsVarApl.dicVarGen["cRUC"] +
                          dFecFin.Year.ToString() +
                          dFecFin.Month.ToString("00") +
                          "00" +
                          "050100" + //CODIGO
                          "00" +
                          "1" +//O
                          "1" +//I:Indicador del contenido del libro o registro
                          idMoneda +//MONEDA
                          "1.txt";
            return cNomArch;
        }
        public string cNomArcPLELibroMayor(string idMoneda, int numRow, DateTime dFecFin)
        {
            switch (idMoneda)
            {
                case "0":
                    idMoneda = "1";
                    break;
                case "2":
                    idMoneda = "1";
                    break;
                case "3":
                    idMoneda = "2";
                    break;
                default:
                    idMoneda = "1";
                    break;
            }
            string cNomArch="LE" + clsVarApl.dicVarGen["cRUC"] +
                            dFecFin.Year.ToString() +
                            dFecFin.Month.ToString("00") +
                            "00" +
                            "060100" +//CODIGO
                            "00" +
                            "1" +//O
                            "1" +//I:Indicador del contenido del libro o registro
                            idMoneda +
                            "1.txt";
            return cNomArch;
        }
        public DataTable CNPLERegVentas(DateTime dFecIni, DateTime dFecFin)
        {
            return objctactb.ADPLERegVentas(dFecIni, dFecFin);
        }
        public DataSet CNTotalLibroDia(DateTime dFecha, int idAsiento, int idMoneda, int idAgencia)
        {
            return objctactb.ADTotalLibroDia(dFecha, idAsiento, idMoneda, idAgencia);
        }
        public DataTable CNPLELibroGeneral(DateTime dFecIni, DateTime dFecFin, int idMoneda, string idLibro, string cNombreSp)
        {
            return objctactb.ADPLELibroGeneral(dFecIni, dFecFin, idMoneda, idLibro, cNombreSp);
        }
        public string monedaLibro(string idMoneda)
        {
            switch (idMoneda)
            {
                case "0":
                    idMoneda = "1";
                    break;
                case "2":
                    idMoneda = "1";
                    break;
                case "3":
                    idMoneda = "2";
                    break;
                default:
                    idMoneda = "1";
                    break;
            }
            return idMoneda;
        }
        //Código de oportunidad de presentación del EEFF
        private string obtenerColCC(string idLibro)
        {
            string cVal = "01";
            return cVal;
        }
        public string cNomArcPLELibro(string idMoneda, DateTime dFecFin, string cCodigo, int NroOpe)
        {
            idMoneda = monedaLibro(idMoneda);
            string columnaDD = "";
            string columnaCC = "";
            if (cCodigo == "010100" || cCodigo == "010200")
            {
                columnaDD = "00";
                columnaCC = "00";
            }
            else
            {
                columnaDD = dFecFin.Day.ToString("00");
                columnaCC = obtenerColCC(cCodigo);
            }
            if (NroOpe > 0)
            {
                NroOpe = 1;
            }
            string cNomArch = "LE" + clsVarApl.dicVarGen["cRUC"] +
                            dFecFin.Year.ToString() +
                            dFecFin.Month.ToString("00") +
                            columnaDD +
                            cCodigo +//CODIGO
                            columnaCC +
                            "1" +//O    ---Indicador de operaciones
                            NroOpe.ToString() +//I:Indicador del contenido del libro o registro
                            idMoneda +
                            "1.txt";
            return cNomArch;
        }
        public int ExportarArchivo(DataTable dtLibro, string cNomArc)
        {
            try
            {
                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena;

                for (int i = 0; i < dtLibro.Rows.Count; i++)
                {
                    pcCadena = dtLibro.Rows[i]["cCadena"].ToString();
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
                return 1;
            }
            catch (Exception)
            {
                
                return 0;
            }               
            
        }
        public DataTable CNPLELibroGeneralInvBal(DateTime dFecProceso, string cNombreSp)
        {
            return objctactb.ADPLELibroGeneralInvBal(dFecProceso,  cNombreSp);
        }
        public DataTable CNListaLESBS()
        {
            return objctactb.CNListaLESBS();
        }
    }
}
