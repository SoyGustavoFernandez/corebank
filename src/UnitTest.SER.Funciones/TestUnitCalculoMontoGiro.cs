
using EntityLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SER.Funciones;
using System.Collections.Generic;

namespace TestUnit
{
    [TestClass]
    public class TestUnitCalculoMontoGiro
    {

        private readonly clsCalculoComision objMetodo;
        private readonly List<clsTarifarioGiros> listaTarifarios;

        public TestUnitCalculoMontoGiro()
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
            var datos = objMetodo.CalcularMontoGiro(1000m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(995.0m, datos.nMontoGiro);

        }


        [TestMethod]
        public void PruebaConMontoEnEscalaI_02()
        {
            var datos = objMetodo.CalcularMontoGiro(999.99m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.01m, datos.nRedondeo);

            Assert.AreEqual(995m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaI_03()
        {
            var datos = objMetodo.CalcularMontoGiro(999.01m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;
            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(994.01m, datos.nMontoGiro);

        }

        //pruebas unitarias con montos en escala II

        [TestMethod]
        public void PruebaConMontoEnEscalaII_01()
        {
            var datos = objMetodo.CalcularMontoGiro(1000.01m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;

            Assert.AreEqual(5.0m, datos.nComision);

            Assert.AreEqual(0.0m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(995.01m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_02()
        {
            var datos = objMetodo.CalcularMontoGiro(1005m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(5m, datos.nComision);

            Assert.AreEqual(0.05m, datos.nITF);

            Assert.AreEqual(0.05m, datos.nRedondeo);

            Assert.AreEqual(1000m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_03()
        {
            var datos = objMetodo.CalcularMontoGiro(10000m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(49.75m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0m, datos.nRedondeo);

            Assert.AreEqual(9949.80m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_04()
        {
            var datos = objMetodo.CalcularMontoGiro(9999.99m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(49.75m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0.01m, datos.nRedondeo);

            Assert.AreEqual(9949.80m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaII_05()
        {
            var datos = objMetodo.CalcularMontoGiro(9999.15m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;

            Assert.AreEqual(49.74m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(9948.96m, datos.nMontoGiro);

        }

        //pruebas unitarias con montos en escala III

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_01()
        {
            var datos = objMetodo.CalcularMontoGiro(10000.01m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;

            Assert.AreEqual(49.75m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(9949.81m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_02()
        {
            var datos = objMetodo.CalcularMontoGiro(10550m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(155.9m, datos.nComision);

            Assert.AreEqual(0.50m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(10393.60m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_03()
        {
            var datos = objMetodo.CalcularMontoGiro(15000.75m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;

            Assert.AreEqual(221.68m, datos.nComision);

            Assert.AreEqual(0.70m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(14778.37m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_04()
        {
            var datos = objMetodo.CalcularMontoGiro(20005.25m, 1, 1, listaTarifarios, false) as clsDatosCalculoComision;

            Assert.AreEqual(295.63m, datos.nComision);

            Assert.AreEqual(0.95m, datos.nITF);

            Assert.AreEqual(0.0m, datos.nRedondeo);

            Assert.AreEqual(19708.67m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_05()
        {
            var datos = objMetodo.CalcularMontoGiro(10001.50m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(49.76m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(00.01m, datos.nRedondeo);

            Assert.AreEqual(9951.30m, datos.nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII_06()
        {
            var datos = objMetodo.CalcularMontoGiro(10001.50m, 1, 1, listaTarifarios, true) as clsDatosCalculoComision;

            Assert.AreEqual(49.76m, datos.nComision);

            Assert.AreEqual(0.45m, datos.nITF);

            Assert.AreEqual(00.01m, datos.nRedondeo);

            Assert.AreEqual(9951.30m, datos.nMontoGiro);

        }




        [TestMethod]
        public void PruebaConMontoEnEscalaI()
        {
            Assert.AreEqual(75m, (objMetodo.CalcularMontoGiro(80, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(105m, (objMetodo.CalcularMontoGiro(110, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(135m, (objMetodo.CalcularMontoGiro(140, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(165m, (objMetodo.CalcularMontoGiro(170, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(195m, (objMetodo.CalcularMontoGiro(200, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(225m, (objMetodo.CalcularMontoGiro(230, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(255m, (objMetodo.CalcularMontoGiro(260, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(285m, (objMetodo.CalcularMontoGiro(290, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(315m, (objMetodo.CalcularMontoGiro(320, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(345m, (objMetodo.CalcularMontoGiro(350, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(375m, (objMetodo.CalcularMontoGiro(380, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(405m, (objMetodo.CalcularMontoGiro(410, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(435m, (objMetodo.CalcularMontoGiro(440, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(465m, (objMetodo.CalcularMontoGiro(470, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(495m, (objMetodo.CalcularMontoGiro(500, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(525m, (objMetodo.CalcularMontoGiro(530, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(555m, (objMetodo.CalcularMontoGiro(560, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(585m, (objMetodo.CalcularMontoGiro(590, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(615m, (objMetodo.CalcularMontoGiro(620, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(645m, (objMetodo.CalcularMontoGiro(650, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(675m, (objMetodo.CalcularMontoGiro(680, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(705m, (objMetodo.CalcularMontoGiro(710, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(735m, (objMetodo.CalcularMontoGiro(740, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(765m, (objMetodo.CalcularMontoGiro(770, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(795m, (objMetodo.CalcularMontoGiro(800, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(825m, (objMetodo.CalcularMontoGiro(830, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(855m, (objMetodo.CalcularMontoGiro(860, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(885m, (objMetodo.CalcularMontoGiro(890, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(915m, (objMetodo.CalcularMontoGiro(920, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(945m, (objMetodo.CalcularMontoGiro(950, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(975m, (objMetodo.CalcularMontoGiro(980, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);


        }
        [TestMethod]
        public void PruebaConMontoEnEscalaII()
        {
            Assert.AreEqual(1005.00m, (objMetodo.CalcularMontoGiro(1010, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1134.30m, (objMetodo.CalcularMontoGiro(1140, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1263.70m, (objMetodo.CalcularMontoGiro(1270, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1393.00m, (objMetodo.CalcularMontoGiro(1400, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1522.40m, (objMetodo.CalcularMontoGiro(1530, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1651.70m, (objMetodo.CalcularMontoGiro(1660, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1781.10m, (objMetodo.CalcularMontoGiro(1790, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(1910.4m, (objMetodo.CalcularMontoGiro(1920, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2039.70m, (objMetodo.CalcularMontoGiro(2050, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2169.10m, (objMetodo.CalcularMontoGiro(2180, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2298.50m, (objMetodo.CalcularMontoGiro(2310, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2427.80m, (objMetodo.CalcularMontoGiro(2440, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2557.20m, (objMetodo.CalcularMontoGiro(2570, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2686.50m, (objMetodo.CalcularMontoGiro(2700, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2815.90m, (objMetodo.CalcularMontoGiro(2830, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(2945.20m, (objMetodo.CalcularMontoGiro(2960, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3074.50m, (objMetodo.CalcularMontoGiro(3090, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3203.90m, (objMetodo.CalcularMontoGiro(3220, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3333.20m, (objMetodo.CalcularMontoGiro(3350, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3462.60m, (objMetodo.CalcularMontoGiro(3480, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3591.90m, (objMetodo.CalcularMontoGiro(3610, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3721.30m, (objMetodo.CalcularMontoGiro(3740, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3850.60m, (objMetodo.CalcularMontoGiro(3870, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(3980.00m, (objMetodo.CalcularMontoGiro(4000, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4109.30m, (objMetodo.CalcularMontoGiro(4130, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4238.70m, (objMetodo.CalcularMontoGiro(4260, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4368.00m, (objMetodo.CalcularMontoGiro(4390, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4497.40m, (objMetodo.CalcularMontoGiro(4520, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4626.70m, (objMetodo.CalcularMontoGiro(4650, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4756.10m, (objMetodo.CalcularMontoGiro(4780, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(4885.40m, (objMetodo.CalcularMontoGiro(4910, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5014.70m, (objMetodo.CalcularMontoGiro(5040, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5144.10m, (objMetodo.CalcularMontoGiro(5170, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5273.40m, (objMetodo.CalcularMontoGiro(5300, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5402.80m, (objMetodo.CalcularMontoGiro(5430, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5532.10m, (objMetodo.CalcularMontoGiro(5560, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5661.50m, (objMetodo.CalcularMontoGiro(5690, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5790.80m, (objMetodo.CalcularMontoGiro(5820, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(5920.20m, (objMetodo.CalcularMontoGiro(5950, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6049.50m, (objMetodo.CalcularMontoGiro(6080, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6178.90m, (objMetodo.CalcularMontoGiro(6210, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6308.20m, (objMetodo.CalcularMontoGiro(6340, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6437.60m, (objMetodo.CalcularMontoGiro(6470, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6566.90m, (objMetodo.CalcularMontoGiro(6600, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6696.30m, (objMetodo.CalcularMontoGiro(6730, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6825.60m, (objMetodo.CalcularMontoGiro(6860, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(6955.00m, (objMetodo.CalcularMontoGiro(6990, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7084.30m, (objMetodo.CalcularMontoGiro(7120, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7213.60m, (objMetodo.CalcularMontoGiro(7250, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7343.00m, (objMetodo.CalcularMontoGiro(7380, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7472.30m, (objMetodo.CalcularMontoGiro(7510, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7601.70m, (objMetodo.CalcularMontoGiro(7640, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7731.00m, (objMetodo.CalcularMontoGiro(7770, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7860.40m, (objMetodo.CalcularMontoGiro(7900, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(7989.70m, (objMetodo.CalcularMontoGiro(8030, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8119.00m, (objMetodo.CalcularMontoGiro(8160, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8248.40m, (objMetodo.CalcularMontoGiro(8290, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8377.80m, (objMetodo.CalcularMontoGiro(8420, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8507.10m, (objMetodo.CalcularMontoGiro(8550, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8636.50m, (objMetodo.CalcularMontoGiro(8680, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8765.80m, (objMetodo.CalcularMontoGiro(8810, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(8895.20m, (objMetodo.CalcularMontoGiro(8940, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9024.50m, (objMetodo.CalcularMontoGiro(9070, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9153.80m, (objMetodo.CalcularMontoGiro(9200, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9283.20m, (objMetodo.CalcularMontoGiro(9330, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9412.50m, (objMetodo.CalcularMontoGiro(9460, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9541.90m, (objMetodo.CalcularMontoGiro(9590, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9671.20m, (objMetodo.CalcularMontoGiro(9720, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9800.60m, (objMetodo.CalcularMontoGiro(9850, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(9929.90m, (objMetodo.CalcularMontoGiro(9980, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);

        }

        [TestMethod]
        public void PruebaConMontoEnEscalaIII()
        {

            Assert.AreEqual(9959.80m, (objMetodo.CalcularMontoGiro(10010, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10000.00m, (objMetodo.CalcularMontoGiro(10140, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10117.80m, (objMetodo.CalcularMontoGiro(10270, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10245.90m, (objMetodo.CalcularMontoGiro(10400, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10373.90m, (objMetodo.CalcularMontoGiro(10530, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10502.00m, (objMetodo.CalcularMontoGiro(10660, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10630.10m, (objMetodo.CalcularMontoGiro(10790, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10758.20m, (objMetodo.CalcularMontoGiro(10920, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(10886.30m, (objMetodo.CalcularMontoGiro(11050, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11014.30m, (objMetodo.CalcularMontoGiro(11180, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11142.40m, (objMetodo.CalcularMontoGiro(11310, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11270.40m, (objMetodo.CalcularMontoGiro(11440, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11398.50m, (objMetodo.CalcularMontoGiro(11570, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11526.60m, (objMetodo.CalcularMontoGiro(11700, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11654.70m, (objMetodo.CalcularMontoGiro(11830, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11782.80m, (objMetodo.CalcularMontoGiro(11960, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(11910.80m, (objMetodo.CalcularMontoGiro(12090, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12038.90m, (objMetodo.CalcularMontoGiro(12220, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12166.90m, (objMetodo.CalcularMontoGiro(12350, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12295.00m, (objMetodo.CalcularMontoGiro(12480, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12423.10m, (objMetodo.CalcularMontoGiro(12610, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12551.20m, (objMetodo.CalcularMontoGiro(12740, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12679.30m, (objMetodo.CalcularMontoGiro(12870, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12807.30m, (objMetodo.CalcularMontoGiro(13000, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(12935.40m, (objMetodo.CalcularMontoGiro(13130, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13063.40m, (objMetodo.CalcularMontoGiro(13260, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13191.50m, (objMetodo.CalcularMontoGiro(13390, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13319.60m, (objMetodo.CalcularMontoGiro(13520, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13447.70m, (objMetodo.CalcularMontoGiro(13650, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13575.80m, (objMetodo.CalcularMontoGiro(13780, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13703.80m, (objMetodo.CalcularMontoGiro(13910, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13831.90m, (objMetodo.CalcularMontoGiro(14040, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(13960.00m, (objMetodo.CalcularMontoGiro(14170, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14088.00m, (objMetodo.CalcularMontoGiro(14300, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14216.10m, (objMetodo.CalcularMontoGiro(14430, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14344.20m, (objMetodo.CalcularMontoGiro(14560, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14472.30m, (objMetodo.CalcularMontoGiro(14690, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14600.30m, (objMetodo.CalcularMontoGiro(14820, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14728.40m, (objMetodo.CalcularMontoGiro(14950, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14856.50m, (objMetodo.CalcularMontoGiro(15080, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(14984.60m, (objMetodo.CalcularMontoGiro(15210, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15112.60m, (objMetodo.CalcularMontoGiro(15340, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15240.70m, (objMetodo.CalcularMontoGiro(15470, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15368.80m, (objMetodo.CalcularMontoGiro(15600, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15496.80m, (objMetodo.CalcularMontoGiro(15730, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15624.90m, (objMetodo.CalcularMontoGiro(15860, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15753.00m, (objMetodo.CalcularMontoGiro(15990, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(15881.10m, (objMetodo.CalcularMontoGiro(16120, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16009.10m, (objMetodo.CalcularMontoGiro(16250, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16137.20m, (objMetodo.CalcularMontoGiro(16380, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16265.30m, (objMetodo.CalcularMontoGiro(16510, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16393.30m, (objMetodo.CalcularMontoGiro(16640, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16521.40m, (objMetodo.CalcularMontoGiro(16770, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16649.50m, (objMetodo.CalcularMontoGiro(16900, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16777.60m, (objMetodo.CalcularMontoGiro(17030, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(16905.70m, (objMetodo.CalcularMontoGiro(17160, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17033.70m, (objMetodo.CalcularMontoGiro(17290, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17161.80m, (objMetodo.CalcularMontoGiro(17420, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17289.80m, (objMetodo.CalcularMontoGiro(17550, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17417.90m, (objMetodo.CalcularMontoGiro(17680, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17546.00m, (objMetodo.CalcularMontoGiro(17810, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17674.10m, (objMetodo.CalcularMontoGiro(17940, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17802.20m, (objMetodo.CalcularMontoGiro(18070, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(17930.20m, (objMetodo.CalcularMontoGiro(18200, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18058.30m, (objMetodo.CalcularMontoGiro(18330, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18186.40m, (objMetodo.CalcularMontoGiro(18460, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18314.40m, (objMetodo.CalcularMontoGiro(18590, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18442.50m, (objMetodo.CalcularMontoGiro(18720, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18570.60m, (objMetodo.CalcularMontoGiro(18850, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18698.70m, (objMetodo.CalcularMontoGiro(18980, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18826.70m, (objMetodo.CalcularMontoGiro(19110, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(18954.80m, (objMetodo.CalcularMontoGiro(19240, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(19082.90m, (objMetodo.CalcularMontoGiro(19370, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(19210.90m, (objMetodo.CalcularMontoGiro(19500, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(19339.00m, (objMetodo.CalcularMontoGiro(19630, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(19467.10m, (objMetodo.CalcularMontoGiro(19760, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);
            Assert.AreEqual(19595.20m, (objMetodo.CalcularMontoGiro(19890, 1, 1, listaTarifarios, true) as clsDatosCalculoComision).nMontoGiro);


        }
    }
}