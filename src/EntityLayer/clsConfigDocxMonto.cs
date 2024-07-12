using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{ 
        public class clsConfiguracionDocumento
        {
            public int id { get; set; }
            public int idPadre { get; set; }
            public bool lVisible { get; set; }
            public string cDescripcion { get; set; }
            public bool lObligatorio { get; set; }
            
            public bool actualizar(int ColumnIndex, bool lEstadoSel, bool lVisiblePadre, bool lObligatorioPadre, ref string cmensaje)
            {
                if (ColumnIndex == 4 && !lObligatorioPadre)
                {
                    this.lObligatorio = false; 
                    return true;
                }
                if (ColumnIndex == 2 && !lVisiblePadre)
                {
                    this.lVisible = false; 
                    return true;
                }

                if (ColumnIndex == 4 && this.lVisible == false && lEstadoSel)
                {
                    this.lObligatorio = false;
                    cmensaje = "Primero debe seleccionar la visibilidad";
                    return true;
                }
                this.lObligatorio = ColumnIndex == 2 ? lEstadoSel : this.lObligatorio;
                if (ColumnIndex == 2)
                {
                    this.lObligatorio = lEstadoSel;
                }
                return false;
            }
            public bool actualizar(int ColumnIndex, bool lEstadoSel, ref string cmensaje)
            {
           

                if (ColumnIndex == 4 && this.lVisible == false && lEstadoSel)
                {
                    this.lObligatorio = false;
                    cmensaje = "Primero debe seleccionar la visibilidad";
                    return true;
                }
                this.lObligatorio = ColumnIndex == 2 ? lEstadoSel : this.lObligatorio;
                if (ColumnIndex == 2)
                {
                    this.lObligatorio = lEstadoSel;
                }
                return false;
            }
        }
        public class clsListaConfiguracionDocumento : BindingList<clsConfiguracionDocumento>
        {
            public string obtenerXml()
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Serialize(ms, this);
                    ms.Position = 0;
                    xmlDoc.Load(ms);
                    return xmlDoc.InnerXml;
                }
            }

        } 
}
