using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GEN.AdminArchivos
{
    public class clsArchivo
    {
        private static OpenFileDialog openFile;
        private static SaveFileDialog saveFile;
        private static string PathFile = "";

        public static bool copiarArchivo(string nombreArchivo, string rutaOrigen, string rutaDestino)
        {
            //Combina Ruta Origen, Destino y Nombre de Archivo
            string rutaArchivoOrigen = System.IO.Path.Combine(rutaOrigen, nombreArchivo);
            string rutaArchivoDestino = System.IO.Path.Combine(rutaDestino, nombreArchivo);

            if (!System.IO.Directory.Exists(rutaDestino))
            {
                System.IO.Directory.CreateDirectory(rutaDestino);
            }

            try
            {
                System.IO.File.Copy(rutaArchivoOrigen, rutaArchivoDestino, true);
                //MessageBox.Show(string.Concat("Archivo ", nombreArchivo, " se copió correctamente.").Trim(), "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static bool copiarArchivo(string NameFileOri, string NameFileDes, string rutaOrigen, string rutaDestino)
        {
            //Combina Ruta Origen, Destino y Nombre de Archivo
            string rutaArchivoOrigen = System.IO.Path.Combine(rutaOrigen, NameFileOri);
            string rutaArchivoDestino = System.IO.Path.Combine(rutaDestino, NameFileDes);

            if (!System.IO.Directory.Exists(rutaDestino))
            {
                System.IO.Directory.CreateDirectory(rutaDestino);
            }

            try
            {
                System.IO.File.Copy(rutaArchivoOrigen, rutaArchivoDestino, true);
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static string abrirArchivo()
        {
            openFile = new OpenFileDialog();

            openFile.Title = "SOLINTELS: Seleccione un archivo....";
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "SolIntEls Archivos (*.doc)|*.doc";
            openFile.FilterIndex = 0;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PathFile = openFile.FileName;
            }
            return PathFile;
        }

        public static string guardarArchivo()
        {
            saveFile = new SaveFileDialog();

            saveFile.Title = "...:::SOLINTELS:::...";
            saveFile.InitialDirectory = "c:\\";
            saveFile.Filter = "SolIntEls Archivos (*.txt)|*.txt";
            saveFile.FilterIndex = 0;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                PathFile = saveFile.FileName;
            }

            return PathFile;
        }
    }
}
