﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GEN.BotonesBase;
using EntityLayer;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class frmVerPdfGestContact : frmBase
    {
        public string cArchivo;
        public byte[] bArchivoBinary;
        public frmVerPdfGestContact()
        {
            InitializeComponent();
        }

        public void verDocumento()
        {
            if (cArchivo != "")
            {
                byte[] bits;

                bits = Compresion.DescompressedByte(bArchivoBinary);

                string sFile = cArchivo;
                string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";
                if (!Directory.Exists(ruta))
                {
                    DirectoryInfo di = Directory.CreateDirectory(ruta);
                }

                FileStream fs = new FileStream("documentosTmp\\" + sFile, FileMode.Create);
                fs.Write(bits, 0, Convert.ToInt32(bits.Length));

                fs.Close();

                ruta = ruta + "\\" + sFile;
                contPdf.src = ruta;
            }
            else
            {

                MessageBox.Show("No se cargó ningun Archivo", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmVerPdfGestContact_Load(object sender, EventArgs e)
        {
            verDocumento();
        }
    }
}
