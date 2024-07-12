using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsRevisionDocCred
    {
        public int idRevisionDocCred { set; get; }
        public int idSolicitud{ set; get; }
        public int idEstado{ set; get; }
        public string cEstado { set; get; }
        public int? idUsuRevision { set; get; }
        public string cMotivo { get; set; }
        public string cComentRevisor { get; set; }
        public DateTime dFecha { set; get; }
        public List<clsDetRevisionDocCre> LstDetRevisionDocCres { set; get; }

        public clsRevisionDocCred()
        {
            LstDetRevisionDocCres = new List<clsDetRevisionDocCre>();
        }
    }

    public class clsDetRevisionDocCre
    {
        public int idDetRevisionDocCred { set; get; }
        public string cNomArchivo{ set; get; }
        public int idTipDocRevCred{ set; get; }
        public string cExtension{ set; get; }
		public byte[] vArchivo{ set; get; }
        public bool lVigente { set; get; }
        public System.Drawing.Bitmap iconDoc { set; get; }
    }
}
