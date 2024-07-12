using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsLogCargaDatosConci
    {
        public int idLogCargaDatos { get; set; }
        public string cUsuarioReg { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaCorebank { get; set; }
        public int idCanal { get; set; }
        public DateTime dFechaCarga { get; set; }
        public bool lResultadoExitoso { get; set; }
        public string cArchivoCargado { get; set; }
        public int idCabecera { get; set; }
        public List<LogExcepciones> logExcepciones { get; set; }

        public class LogExcepciones
        {
            public int idLogExcepcion { get; set; }
            public int idLogCargaDatos { get; set; }
            public string cUsuarioReg { get; set; }
            public DateTime dFechaReg { get; set; }
            public string cMensajeError { get; set; }
        }
    }
}
