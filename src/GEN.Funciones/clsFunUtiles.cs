using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Data;
using System.Management;
using System.Net.Sockets;
using System.Net;

namespace GEN.Funciones
{   
    /// <summary>
    /// 
    /// </summary>
    public class clsFunUtiles
    {             

        /// <summary>
        /// retorna la concatenación de Macs de la pc
        /// </summary>
        /// <returns>Macs concatenadas</returns>
        public string obtenerMac()
        {
           NetworkInterface[] nets = NetworkInterface.GetAllNetworkInterfaces();
           string mac = "";
           foreach (NetworkInterface adapter in nets)
           {
               IPInterfaceProperties properties = adapter.GetIPProperties();
               PhysicalAddress address = adapter.GetPhysicalAddress();
               byte[] bytes = address.GetAddressBytes();
               for (int i = 0; i < bytes.Length; i++)
               {
                   mac += bytes[i].ToString("X2");
                   if (i != bytes.Length - 1)
                   {
                       mac += "-";
                   }
               }
           }
           mac = mac.Replace("00-00-00-00-00-00-00-E0", "");
           return mac;
        }
        public string obtenerIdentificadorPC()
        {
            string cNumeroSerieHDD = string.Empty;
            string cNombrePc = string.Empty;
            string cNumeroSeriePlacaMadre = string.Empty;
            string cIdentificadorPC = string.Empty;

            ManagementObjectSearcher oSearcherHDD = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject item in oSearcherHDD.Get())
            {
                cNumeroSerieHDD = item["SerialNumber"] != null ? item["SerialNumber"].ToString().Trim() : cNumeroSerieHDD;
                break;
            }

			cNombrePc = obtenerNomPc();
            if (cNumeroSerieHDD.Length > 0)
            {
                cNumeroSerieHDD = "H" + cNumeroSerieHDD;
            }
			if (cNombrePc.Length > 0)
            {
				cNombrePc = "-PC" + cNombrePc;
            }

			cIdentificadorPC = cNumeroSerieHDD + cNombrePc;

            return cIdentificadorPC;
        }
        /// <summary>
        /// Retorna nombre de la pc donde se esta ejecutando
        /// </summary>
        /// <returns>Nombre de la pc</returns>
        public string obtenerNomPc()
        {
            return System.Windows.Forms.SystemInformation.ComputerName;
        }

        /// <summary>
        /// Retorna datos del Sistema Operativo
        /// </summary>
        /// <returns>Datos del Sistema Operativo</returns>
        public string obtenerDatSO()
        {
            OperatingSystem dobjdatso = Environment.OSVersion;

            return dobjdatso.VersionString;
        }

        /// <summary>
        /// Realiza el truncamiento del itf segun resolucion del bcr
        /// </summary>
        /// <param name="nValor"></param>
        /// <param name="nDecimales"></param>
        /// <param name="nMoneda"></param>
        /// <returns></returns>
        public Decimal truncar(Decimal nValor, int nDecimales, int nMoneda)
        {
            decimal nItf = Convert.ToDecimal(0.00);

            if (nMoneda == 2)
            {
                nItf = truncarNumero((nValor), nDecimales);
            }
            else if (nMoneda == 1)
            {
                decimal nMonItf = truncarNumero((nValor), nDecimales);

                decimal nRes = (nMonItf % Convert.ToDecimal(0.05));

                if (Math.Round(nRes, 2) == Convert.ToDecimal(0.05))
                {
                    nItf = nMonItf;
                }
                else
                {
                    nItf = nMonItf - Math.Round(nRes, 2);
                }

            }

            return Convert.ToDecimal (nItf);
        }

        /// <summary>
        /// realiza el redondeo a favor del cliente segun resolucion del bcr
        /// </summary>
        /// <param name="nValor">monto a redondear</param>
        /// <param name="nMonFavCli">redondeo a favor del cliente</param>
        /// <param name="nMoneda">moneda de la operacion</param>
        /// <param name="lIndOpeEfectivo">indicador si operacion es en efectivo</param>
        /// <param name="lIndIngreso">indicador si operacion es de ingreso</param>
        /// <returns>Valor redondeado</returns>
        public Decimal redondearBCR(Decimal nValor, ref Decimal nMonFavCli, int nMoneda, bool lIndOpeEfectivo,bool lIndIngreso)
        {
            

            Decimal nMonRed = nValor;
            Decimal nvalRed = 0.00m;
            if (nMoneda == 1 && lIndOpeEfectivo == true && lIndIngreso == true)
            {
                Decimal nRes = Math.Round((nValor % 0.1m),2);
                if (nRes >= 0.0m && nRes <= 0.09m)
                {
                    nvalRed = 0.00m;
                    nMonFavCli = nRes;
                }
                else
                {
                    nRes = 0.00m;
                }

                nMonRed = nMonRed - nMonFavCli;
            }
            else if (nMoneda == 1 && lIndOpeEfectivo == true && lIndIngreso == false)
            {
                Decimal nRes = Math.Round((nValor % 0.1m), 2);
                if (nRes > 0.0m && nRes <= 0.09m)
                {
                    nvalRed = 0.00m;
                    nMonFavCli = 0.1m- nRes;
                }
                else
                {
                    nRes = 0.00m;
                }

                nMonRed = nMonRed + nMonFavCli;
            }
            return nMonRed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public decimal truncarNumero(decimal value, int length)
        {

            string[] param = value.ToString().Split('.');
            if (value.ToString().IndexOf(".")>0)
            {
                if (param[1].Length >= length)

                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, length));

                else

                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, param[1].Length));
            }
            else
            {
                return Convert.ToDecimal(value);
            }
            

        }

        /// <summary>
        /// Validacion de identificacion de documento RUC persona juridica y natural
        /// </summary>
        /// <param name="cNumDoc">numero de documento</param>
        /// <returns>retorna si es correcto o no</returns>
        public bool validarNumeroRUC(string cNumDoc) 
        {
            bool lVal = false;
            if (!string.IsNullOrEmpty(cNumDoc))
            {
                #region Formula anterior
                //    int nSuma = 0;

                //    int[] arlHash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };


                //    int nIdenLongDoc = cNumDoc.Length;
                //    string cIdenComponente = cNumDoc.Substring(0, nIdenLongDoc - 1);
                //    int nIdenLongComp = cIdenComponente.Length;
                //    int ndiferencia = arlHash.Length - nIdenLongComp;

                //    for (int i = nIdenLongComp - 1; i >= 0; i--)
                //    {
                //        nSuma += (cIdenComponente[i] - '0') * arlHash[i + ndiferencia];
                //    }
                //    nSuma = 11 - (nSuma % 11);
                //    if (nSuma == 11)
                //    {
                //        nSuma = 0;
                //    }

                //    char cUltimoCaracter = char.ToUpperInvariant(cNumDoc[nIdenLongDoc - 1]);

                //    if (nIdenLongDoc == 11)
                //    {
                //        // identificacion correspondiente a un ruc persona juridica          
                //        return nSuma.Equals(cUltimoCaracter - '0');
                //    }
                //    else if (char.IsDigit(cUltimoCaracter))
                //    {
                //        // validacion ruc persona natural         
                //        char[] arlHashNum = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                //        return cUltimoCaracter.Equals(arlHashNum[nSuma]);
                //    }
                //    else if (char.IsLetter(cUltimoCaracter))
                //    {
                //        // identificacion on caracter incluido en el documento          
                //        char[] arlHashLetra = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                //        return cUltimoCaracter.Equals(arlHashLetra[nSuma]);
                //    }
                //}
                //return false;
                #endregion
                int dig01 = Convert.ToInt32(cNumDoc.Substring(0, 1)) * 5;
                int dig02  = Convert.ToInt32(cNumDoc.Substring(1, 1)) * 4;
                int dig03  = Convert.ToInt32(cNumDoc.Substring(2, 1)) * 3;
                int dig04  = Convert.ToInt32(cNumDoc.Substring(3, 1)) * 2;
                int dig05  = Convert.ToInt32(cNumDoc.Substring(4, 1)) * 7;
                int dig06  = Convert.ToInt32(cNumDoc.Substring(5, 1)) * 6;
                int dig07  = Convert.ToInt32(cNumDoc.Substring(6, 1)) * 5;
                int dig08  = Convert.ToInt32(cNumDoc.Substring(7, 1)) * 4;
                int dig09  = Convert.ToInt32(cNumDoc.Substring(8, 1)) * 3;
                int dig10  = Convert.ToInt32(cNumDoc.Substring(9, 1)) * 2;
                int dig11 = Convert.ToInt32(cNumDoc.Substring(10, 1));

                int suma = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10;
                int residuo  = suma % 11;
                int resta = 11 - residuo;

                int digChk ;
                if( resta == 10 )
                    digChk = 0;
                else if(resta == 11)
                    digChk = 1;
                else
                    digChk = resta;
                if (dig11 == digChk)
                    lVal = true;
                else
                    lVal = false;
            }
            return lVal;
        }

        /// <summary>
        /// Modifica el tamaño de una imagen
        /// </summary>
        /// <returns>Imagen</returns>
        /// /// <returns>nuevo ancho</returns>
        /// /// <returns>nuevo alto</returns>
        public Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(Convert.ToInt32(srcImage.HorizontalResolution), Convert.ToInt32(srcImage.HorizontalResolution));
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }
        public void validarCeldas(DataGridView dtg, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Se ingresó un valor invalido en la celda.\nVer Columna \""
                    + dtg.CurrentCell.OwningColumn.HeaderText + "\" y fila " + (e.RowIndex + 1) + ".",
                    "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if ((e.Exception) is ConstraintException)
            {
                dtg.Rows[e.RowIndex].ErrorText = "an error";
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        public int obtenerPlazoMeses(int nTipoPeriodo, int nCuotas, int nPlazoCuota)
        {
            return (nTipoPeriodo == 1) ? nCuotas : (int)Math.Round(((nCuotas * nPlazoCuota) / 30.000), 0);
        }

        public string obtenerIP()
        {
            string returnAddress = String.Empty;

            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                // Read the IP configuration for each network
                IPInterfaceProperties properties = network.GetIPProperties();

                if (network.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                       network.OperationalStatus == OperationalStatus.Up &&
                       !network.Description.ToLower().Contains("virtual") &&
                       !network.Description.ToLower().Contains("pseudo"))
                {
                    // Each network interface may have multiple IP addresses
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // We're only interested in IPv4 addresses for now
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                            continue;

                        // Ignore loopback addresses (e.g., 127.0.0.1)
                        if (IPAddress.IsLoopback(address.Address))
                            continue;

                        returnAddress = address.Address.ToString();
                    }
                }
            }

            return returnAddress;
        }

        public string obtenerIPUsuario()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect("10.5.5.100", 1433);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                socket.Close();
            }
            return localIP;
        }

        /// <summary>
        /// Finds the MAC address of the NIC with maximum speed.
        /// </summary>
        /// <returns>The MAC address.</returns>
        public string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {                   
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }
    }
}
