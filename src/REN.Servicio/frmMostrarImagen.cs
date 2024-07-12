using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CLI.Servicio
{
    public partial class frmMostrarImagen : Form
    {
        private string cNombreArchivo { get; set; }
        private string cExtension { get; set; }
        private byte[] bArchivo { get; set; }
        public frmMostrarImagen()
        {
            InitializeComponent();
        }

        public frmMostrarImagen(string _cNombreArchivo, string _cExtension, byte[] _bArchivo)
        {
            InitializeComponent();
            cNombreArchivo = _cNombreArchivo;
            cExtension = _cExtension;
            bArchivo = _bArchivo;
        }

        private void renderizarImagen()
        {
            string cNombreImagen = cNombreArchivo;
            string cRuta = Directory.GetCurrentDirectory() + "\\IMGSustentoExpBio";
            if (!Directory.Exists(cRuta))
            {
                DirectoryInfo di = Directory.CreateDirectory(cRuta);
            }

            FileStream fs = new FileStream("IMGSustentoExpBio\\" + cNombreImagen, FileMode.Create);
            fs.Write(bArchivo, 0, Convert.ToInt32(bArchivo.Length));

            fs.Close();

            cRuta = cRuta + "\\" + cNombreImagen;
            pbImagen.Image = byteArrayImage(bArchivo);
            pbImagen.Refresh();
        }

        private void frmMostrarImagen_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(this.cNombreArchivo))
            {
                renderizarImagen();
            }
        }

        private Image byteArrayImage(byte[] bArchivo)
        {
            using (var ms = new MemoryStream(bArchivo))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
