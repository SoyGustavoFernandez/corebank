using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsMsjError
    {
        private List<string> listError;

        public bool lValido { get; set; }

        public clsMsjError()
        {
            this.listError = new List<string>();
        }

        /// <summary>
        /// Adicionar un Error
        /// </summary>
        /// <param name="msj"></param>
        public void AddError(string msj)
        {
            this.listError.Add(msj);
        }

        /// <summary>
        /// Retorna un listado de errores
        /// </summary>
        /// <returns></returns>
        public List<string> GetListError()
        {
            return this.listError;
        }

        /// <summary>
        /// Retorna una cadena de errores separados por espacios de linea(\n)
        /// </summary>
        /// <returns>String</returns>
        public string GetErrors()
        {
            string sError = "";
            foreach (string er in this.listError)
                sError += "  - " + er + "\n";

            return sError;
        }

        /// <summary>
        /// Retorna true si tiene errores
        /// </summary>
        /// <returns>bool</returns>
        public bool HasErrors
        {
            get
            { 
                return (this.listError.Count() > 0) ? true : false;
            }
        }

        /// <summary>
        /// Une un objeto de tipo clsMsjError a el objeto instanciado
        /// </summary>
        /// <param name="obj">objeto a unir con este objeto</param>
        public void addList(clsMsjError obj)
        {
            foreach (var err in obj.GetListError())
                this.listError.Add(err);
        }

        public void clearList()
        {
            this.listError.Clear();
        }
    }
}
