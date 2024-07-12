﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ClsPropSimpleCred
    {
        public clsActividadEconomica oActPrincipal { get; set; }

        public string cComPropCliente { get; set; }
        public string cComPropCredito { get; set; }

        public ClsPropSimpleCred()
        {
            oActPrincipal = new clsActividadEconomica();

            cComPropCliente = String.Empty;
            cComPropCredito = String.Empty;

        }
    }
}
