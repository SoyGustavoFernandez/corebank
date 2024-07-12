using System;

namespace CAJ.AccesoDatos
{
    /// <summary>
    /// Description of SingletonClass1
    /// </summary>
    public sealed class SingletonClass1
    {
        private static SingletonClass1 instance = new SingletonClass1();
        public string nombre = "alan";
        public static SingletonClass1 Instance
        {
            get
            {
                return instance;
            }
        }

        private SingletonClass1()
        {
        }
    }

    public class MyClass
    {
        
        MyClass()
        {
            string nombre = SingletonClass1.Instance.nombre;


        }
        
    }
}
