using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADFirmas
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsFirma retornaFirma(int idCli)
        {
            clsFirma firma = null;
            DataTable dt = objEjeSp.EjecSP("CLI_RetFirmaCli_sp", idCli);

            if (dt.Rows.Count > 0)
            {
                firma = new clsFirma();
                firma.idCli = (int)dt.Rows[0]["idCli"];
                firma.dFechaReg = (DateTime)dt.Rows[0]["dFechaReg"];
                firma.idUsuReg = (int)dt.Rows[0]["idUsuReg"];
                if (!(dt.Rows[0]["dFechaMod"] is System.DBNull))
                {
                    firma.dFechaMod = (DateTime)dt.Rows[0]["dFechaMod"];
                }
                if (!(dt.Rows[0]["idUsuMod"] is System.DBNull))
                {
                    firma.idUsuMod = (int)dt.Rows[0]["idUsuMod"];
                }                
                firma.idEstado = (int)dt.Rows[0]["idEstado"];

                Byte[] data = new Byte[0];
                data = (Byte[])(dt.Rows[0]["imgFirma"]);
                MemoryStream mem = new MemoryStream(data);
                firma.imgFirma = Image.FromStream(mem);
                mem.Flush();
                mem.Close();
            }

            return firma;
        }

        public void insertarFirma(clsFirma firma)
        {
            MemoryStream ms = new MemoryStream();
            firma.imgFirma.Save(ms, ImageFormat.Jpeg);

            objEjeSp.EjecSP("CLI_InsActFirmaCli_sp", firma.idCli, ms.ToArray(),
                                                    firma.dFechaReg, firma.idUsuReg, firma.idEstado);
            ms.Flush();
            ms.Close();
        }
    }
}
