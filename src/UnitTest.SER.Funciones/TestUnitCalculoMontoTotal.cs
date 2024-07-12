
using EntityLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SER.Funciones;
using System.Collections.Generic;

namespace TestUnit
{
    [TestClass]
    public class TestUnitCalculoMontoTotal
    {

        private readonly clsCalculoComision objMetodo;
        private readonly List<clsTarifarioGiros> listaTarifarios;

        public TestUnitCalculoMontoTotal()
        {
            objMetodo = new clsCalculoComision();

            listaTarifarios = new List<clsTarifarioGiros>();

            listaTarifarios.Add(new clsTarifarioGiros { idGiroTarifario = 1, idMoneda = 1, idTipoPersona = 1, idTipComGiro = 1, nMontoMinimo = 0, nMontoMaximo = 1000, nMontoComision = 5m });
            listaTarifarios.Add(new clsTarifarioGiros { idGiroTarifario = 2, idMoneda = 1, idTipoPersona = 1, idTipComGiro = 2, nMontoMinimo = 1000.01m, nMontoMaximo = 10000, nMontoComision = 0.5m });
            listaTarifarios.Add(new clsTarifarioGiros { idGiroTarifario = 3, idMoneda = 1, idTipoPersona = 1, idTipComGiro = 2, nMontoMinimo = 10000.01m, nMontoMaximo = 99999999, nMontoComision = 1.5m });
        }

        //pruebas unitarias con montos en escala I

        [TestMethod]
        public void PruebaConMontoEnEscalaI_01()
        {
            var datos = objMetodo.CalcularMontoTotal(1000m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.05m, datos.nITF);

            Assert.AreEqual(0.05m, datos.nRedondeo);

            Assert.AreEqual(1005.0m, datos.nMontoTotal);

        }


        [TestMethod]
        public void PruebaConMontoEnEscalaI_02()
        {
            var datos = objMetodo.CalcularMontoTotal(999.99m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.09m, datos.nRedondeo);

            Assert.AreEqual(1004.9m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaI_03()
        {
            var datos = objMetodo.CalcularMontoTotal(999.01m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.01m, datos.nRedondeo);

            Assert.AreEqual(1004m, datos.nMontoTotal);

        }


        //pruebas unitarias con montos en escala II

        [TestMethod]
        public void PruebaConMontoEnEscalaII_01()
        {
            var datos = objMetodo.CalcularMontoTotal(1000.01m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5m, datos.nComision);

            Assert.AreEqual(0.05m, datos.nITF);

            Assert.AreEqual(0.06m, datos.nRedondeo);

            Assert.AreEqual(1005m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_02()
        {
            var datos = objMetodo.CalcularMontoTotal(1005m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.03m, datos.nComision);

            Assert.AreEqual(0.05m, datos.nITF);

            Assert.AreEqual(0.08m, datos.nRedondeo);

            Assert.AreEqual(1010m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_03()
        {
            var datos = objMetodo.CalcularMontoTotal(10000m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(50m, datos.nComision);

            Assert.AreEqual(0.5m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(10050.5m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_04()
        {
            var datos = objMetodo.CalcularMontoTotal(9999.99m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(50m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0.04m, datos.nRedondeo);

            Assert.AreEqual(10050.4m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_05()
        {
            var datos = objMetodo.CalcularMontoTotal(9999.15m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(50m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0m, datos.nRedondeo);

            Assert.AreEqual(10049.6m, datos.nMontoTotal);

        }

        //pruebas unitarias con montos en escala III

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_01()
        {
            var datos = objMetodo.CalcularMontoTotal(10000.01m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(150m, datos.nComision);

            Assert.AreEqual(0.5m, datos.nITF);

            Assert.AreEqual(0.01m, datos.nRedondeo);

            Assert.AreEqual(10150.5m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_02()
        {
            var datos = objMetodo.CalcularMontoTotal(10550m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(158.25m, datos.nComision);

            Assert.AreEqual(0.50m, datos.nITF);

            Assert.AreEqual(0.05m, datos.nRedondeo);

            Assert.AreEqual(10708.7m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_03()
        {
            var datos = objMetodo.CalcularMontoTotal(15000.75m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(225.01m, datos.nComision);

            Assert.AreEqual(0.75m, datos.nITF);

            Assert.AreEqual(0.01m, datos.nRedondeo);

            Assert.AreEqual(15226.5m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_04()
        {
            var datos = objMetodo.CalcularMontoTotal(20005.25m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(1m, datos.nITF);

            Assert.AreEqual(0.03m, datos.nRedondeo);

            Assert.AreEqual(20306.3m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_05()
        {
            var datos = objMetodo.CalcularMontoTotal(10001.50m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(0.5m, datos.nITF);

            Assert.AreEqual(0.02m, datos.nRedondeo);

            Assert.AreEqual(10152m, datos.nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_06()
        {
            var datos = objMetodo.CalcularMontoTotal(30003.99m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(1.5m, datos.nITF);

            Assert.AreEqual(0.05m, datos.nRedondeo);

            Assert.AreEqual(30455.5m, datos.nMontoTotal);

        }


        [TestMethod]
        public void PruebaConMontoEnEscalaI()
        {
            Assert.AreEqual(105.0m, (objMetodo.CalcularMontoTotal(100m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(162.0m, (objMetodo.CalcularMontoTotal(157m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(219.0m, (objMetodo.CalcularMontoTotal(214m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                            
            Assert.AreEqual(276.0m, (objMetodo.CalcularMontoTotal(271m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(333.0m, (objMetodo.CalcularMontoTotal(328m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(390.0m, (objMetodo.CalcularMontoTotal(385m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(447.0m, (objMetodo.CalcularMontoTotal(442m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                             
            Assert.AreEqual(504.0m, (objMetodo.CalcularMontoTotal(499m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                               
            Assert.AreEqual(561.0m, (objMetodo.CalcularMontoTotal(556m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(618.0m, (objMetodo.CalcularMontoTotal(613m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                               
            Assert.AreEqual(675.0m, (objMetodo.CalcularMontoTotal(670m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(732.0m, (objMetodo.CalcularMontoTotal(727m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(789.0m, (objMetodo.CalcularMontoTotal(784m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(846.0m, (objMetodo.CalcularMontoTotal(841m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(903.0m, (objMetodo.CalcularMontoTotal(898m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                              
            Assert.AreEqual(960.0m, (objMetodo.CalcularMontoTotal(955m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII()
        {
            Assert.AreEqual(1006.00m, (objMetodo.CalcularMontoTotal(1001m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(1258.30m, (objMetodo.CalcularMontoTotal(1252m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(1510.50m, (objMetodo.CalcularMontoTotal(1503m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(1762.80m, (objMetodo.CalcularMontoTotal(1754m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(2015.10m, (objMetodo.CalcularMontoTotal(2005m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(2267.30m, (objMetodo.CalcularMontoTotal(2256m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(2519.60m, (objMetodo.CalcularMontoTotal(2507m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(2771.80m, (objMetodo.CalcularMontoTotal(2758m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(3024.20m, (objMetodo.CalcularMontoTotal(3009m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(3276.40m, (objMetodo.CalcularMontoTotal(3260m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                               
            Assert.AreEqual(3528.70m, (objMetodo.CalcularMontoTotal(3511m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(3780.90m, (objMetodo.CalcularMontoTotal(3762m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(4033.20m, (objMetodo.CalcularMontoTotal(4013m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(4285.50m, (objMetodo.CalcularMontoTotal(4264m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(4537.70m, (objMetodo.CalcularMontoTotal(4515m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(4790.00m, (objMetodo.CalcularMontoTotal(4766m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(5042.30m, (objMetodo.CalcularMontoTotal(5017m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(5294.50m, (objMetodo.CalcularMontoTotal(5268m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(5546.80m, (objMetodo.CalcularMontoTotal(5519m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(5799.10m, (objMetodo.CalcularMontoTotal(5770m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(6051.40m, (objMetodo.CalcularMontoTotal(6021m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(6303.60m, (objMetodo.CalcularMontoTotal(6272m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(6555.90m, (objMetodo.CalcularMontoTotal(6523m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(6808.10m, (objMetodo.CalcularMontoTotal(6774m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(7060.40m, (objMetodo.CalcularMontoTotal(7025m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(7312.70m, (objMetodo.CalcularMontoTotal(7276m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(7564.90m, (objMetodo.CalcularMontoTotal(7527m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(7817.20m, (objMetodo.CalcularMontoTotal(7778m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(8069.50m, (objMetodo.CalcularMontoTotal(8029m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(8321.80m, (objMetodo.CalcularMontoTotal(8280m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(8574.00m, (objMetodo.CalcularMontoTotal(8531m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(8826.30m, (objMetodo.CalcularMontoTotal(8782m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(9078.60m, (objMetodo.CalcularMontoTotal(9033m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(9330.80m, (objMetodo.CalcularMontoTotal(9284m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(9583.10m, (objMetodo.CalcularMontoTotal(9535m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(9835.30m, (objMetodo.CalcularMontoTotal(9786m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
        }

        [TestMethod]

        public void PruebaConMontoEnEscalaIII()
        {
            Assert.AreEqual(10151.50m, (objMetodo.CalcularMontoTotal(10001m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

            Assert.AreEqual(10406.20m, (objMetodo.CalcularMontoTotal(10252m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(10661.00m, (objMetodo.CalcularMontoTotal(10503m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(10915.80m, (objMetodo.CalcularMontoTotal(10754m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(11170.60m, (objMetodo.CalcularMontoTotal(11005m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(11425.30m, (objMetodo.CalcularMontoTotal(11256m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(11680.10m, (objMetodo.CalcularMontoTotal(11507m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(11934.90m, (objMetodo.CalcularMontoTotal(11758m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                    
            Assert.AreEqual(12189.70m, (objMetodo.CalcularMontoTotal(12009m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(12444.50m, (objMetodo.CalcularMontoTotal(12260m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(12699.20m, (objMetodo.CalcularMontoTotal(12511m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                    
            Assert.AreEqual(12954.00m, (objMetodo.CalcularMontoTotal(12762m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(13208.80m, (objMetodo.CalcularMontoTotal(13013m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(13463.60m, (objMetodo.CalcularMontoTotal(13264m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(13718.30m, (objMetodo.CalcularMontoTotal(13515m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(13973.10m, (objMetodo.CalcularMontoTotal(13766m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                
            Assert.AreEqual(14227.90m, (objMetodo.CalcularMontoTotal(14017m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(14482.70m, (objMetodo.CalcularMontoTotal(14268m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(14737.40m, (objMetodo.CalcularMontoTotal(14519m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(14992.20m, (objMetodo.CalcularMontoTotal(14770m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(15247.00m, (objMetodo.CalcularMontoTotal(15021m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(15501.80m, (objMetodo.CalcularMontoTotal(15272m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(15756.60m, (objMetodo.CalcularMontoTotal(15523m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(16011.30m, (objMetodo.CalcularMontoTotal(15774m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(16266.10m, (objMetodo.CalcularMontoTotal(16025m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(16775.70m, (objMetodo.CalcularMontoTotal(16527m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                               
            Assert.AreEqual(17030.40m, (objMetodo.CalcularMontoTotal(16778m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(17285.20m, (objMetodo.CalcularMontoTotal(17029m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(17540.00m, (objMetodo.CalcularMontoTotal(17280m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(17794.80m, (objMetodo.CalcularMontoTotal(17531m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(18049.50m, (objMetodo.CalcularMontoTotal(17782m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(18304.40m, (objMetodo.CalcularMontoTotal(18033m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                 
            Assert.AreEqual(18559.10m, (objMetodo.CalcularMontoTotal(18284m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                  
            Assert.AreEqual(18813.90m, (objMetodo.CalcularMontoTotal(18535m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(19068.60m, (objMetodo.CalcularMontoTotal(18786m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(19323.50m, (objMetodo.CalcularMontoTotal(19037m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(19578.20m, (objMetodo.CalcularMontoTotal(19288m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(19833.00m, (objMetodo.CalcularMontoTotal(19539m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);
                                                                                   
            Assert.AreEqual(20087.80m, (objMetodo.CalcularMontoTotal(19790m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoTotal);

        }
    }
}