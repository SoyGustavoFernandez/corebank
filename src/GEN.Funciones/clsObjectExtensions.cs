using System.Xml.Serialization;

namespace GEN.Funciones
{
    public static class clsObjectExtensions
    {
        public static string GetXml(this object objSerialize)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(objSerialize.GetType());
            serializer.Serialize(stringwriter, objSerialize);
            return stringwriter.ToString();
        }
    }
}
