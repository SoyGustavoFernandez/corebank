using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.KasNet.Modelo
{
    public class ReqDebtConsult
    {
        public string nroSumin { get; set; }
        public string traceConsulta { get; set; }
        public string fechaConsulta { get; set; }
        public string horaConsulta { get; set; }
        public string codEmpresa { get; set; }
        public string codServicio { get; set; }
        public string codAgencia { get; set; }
        public string codCanal { get; set; }
        public string terminal { get; set; }
    }
}