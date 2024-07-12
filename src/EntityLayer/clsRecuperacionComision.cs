using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsRecuperacionComision
    {
        public int idRecuperacionComisionTipo { get; set; }
        public int idUsuario { get; set; }
        public int idZona  { get; set; }
        public int idEstablecimiento { get; set; }
        public decimal nMontoComisionBase { get; set; }
        public decimal nMontoAfectacion { get; set; }
        public decimal nMontoBonificacion { get; set; }
        public decimal nMontoComision { get; set; }
        public DateTime dFecha { get; set; }

        public clsRecuperacionComision()
        {
            this.idRecuperacionComisionTipo = 0;
            this.idUsuario = 0;
            this.idZona = 0;
            this.idEstablecimiento = 0;
            this.nMontoComisionBase = decimal.Zero;
            this.nMontoAfectacion = decimal.Zero;
            this.nMontoBonificacion = decimal.Zero;
            this.nMontoComision = decimal.Zero;
            this.dFecha = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month,
                                    DateTime.DaysInMonth(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month));
        }
    }

    public class clsRecuperacionComisionDetalle
    {
        public int idRecuperacionComisionTipo { get; set; }
        public int idZona { get; set; }
        public string cZona { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public int idUsuario { get; set; }
        public string cNombre { get; set; }

        public decimal nSaldoMIniActual { get; set; }
        public decimal nSaldoMActual { get; set; }

        public decimal nMoraContIniAct { get; set; }
        public decimal nMoraContActual { get; set; }
        public decimal nMoraContDiferencia { get; set; }

        public decimal nSaldoCARIni { get; set; }
        public decimal nSaldoCARAct { get; set; }
        public decimal nSaldoCARDiferencia { get; set; }

        public decimal nPcentMoraContIniAct { get; set; }
        public decimal nPcentMoraContActual { get; set; }
        public decimal nPcentMoraContDiferencia { get; set; }

        public decimal nPcentSaldoCARIni { get; set; }
        public decimal nPcentSaldoCARAct { get; set; }
        public decimal nPcentSaldoCARDiferencia { get; set; }

        public decimal nMontoMeta { get; set; }
        public decimal nMontoLogrado { get; set; }        
        public decimal nPcgMetaLogrado { get; set; }        
        public int nLimiteCondonacion { get; set; }
        public int nCondonaciones { get; set; }
        public decimal nFactor { get; set; }
        public decimal nMontoComisionBase { get; set; }
        public decimal nMontoAfectacion { get; set; }
        public decimal nMontoBonificacion { get; set; }
        public decimal nMontoComision { get; set; }
        public DateTime dFechaActualizacion { get; set; }

        public clsRecuperacionComisionDetalle()
        {
            this.idRecuperacionComisionTipo = 0;
            this.idZona = 0;
            this.cZona = string.Empty;
            this.idEstablecimiento = 0;
            this.cEstablecimiento = string.Empty;
            this.idUsuario = 0;
            this.cNombre = string.Empty;

            this.nSaldoMIniActual = decimal.Zero;
            this.nSaldoMActual = decimal.Zero;
            this.nMoraContIniAct = decimal.Zero;
            this.nMoraContActual = decimal.Zero;
            this.nSaldoCARIni = decimal.Zero;
            this.nSaldoCARAct = decimal.Zero;
            this.nMoraContDiferencia = decimal.Zero;
            this.nSaldoCARDiferencia = decimal.Zero;
            this.nPcentMoraContIniAct = decimal.Zero;
            this.nPcentMoraContActual = decimal.Zero;
            this.nPcentSaldoCARIni = decimal.Zero;
            this.nPcentSaldoCARAct = decimal.Zero;
            this.nPcentMoraContDiferencia = decimal.Zero;
            this.nPcentSaldoCARDiferencia = decimal.Zero;

            this.nMontoLogrado = decimal.Zero;
            this.nMontoMeta = decimal.Zero;
            this.nPcgMetaLogrado = decimal.Zero;            
            this.nLimiteCondonacion = 0;
            this.nCondonaciones = 0;
            this.nFactor = decimal.Zero;
            this.nMontoComisionBase = decimal.Zero;
            this.nMontoAfectacion = decimal.Zero;
            this.nMontoBonificacion = decimal.Zero;
            this.nMontoComision = decimal.Zero;
            this.dFechaActualizacion = clsVarGlobal.dFecSystem.AddMonths(-1);
        }
    }
}
