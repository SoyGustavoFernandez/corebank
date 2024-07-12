﻿using System;
using System.Text;
using WCF.Authorization.Modelo;

namespace WCF.Authorization.Negocio
{
    public class BasicAuth
    {
        private readonly string _User;
        private readonly string _Password;
        private const string Prefix = "Basic ";
        private clsCredencial _Creds;
        public string HeaderValue { set;  get; }

        #region Constructors
        public BasicAuth(string encodedHeader)
            : this(encodedHeader, Encoding.UTF8)
        {
        }

        public BasicAuth(string encodedHeader, Encoding encoding)
        {
            HeaderValue = encodedHeader;
            var decodedHeader = encodedHeader.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase)
                ? encoding.GetString(Convert.FromBase64String(encodedHeader.Substring(Prefix.Length)))
                : encoding.GetString(Convert.FromBase64String(encodedHeader));
            var credArray = decodedHeader.Split(':');
            if (credArray.Length > 0)
                _User = credArray[0];
            if (credArray.Length > 1)
                _Password = credArray[1];
        }

        public BasicAuth(string user, string password)
            : this(user, password, Encoding.UTF8)
        {
        }

        public BasicAuth(string user, string password, Encoding encoding)
        {
            _User = user;
            _Password = password;
            HeaderValue = Prefix + Convert.ToBase64String(encoding.GetBytes(string.Format("{0}:{1}", _User, _Password)));
        }
        #endregion

        public clsCredencial ObtenerCred
        {
            get { return _Creds ?? (_Creds = new clsCredencial { cUsuario = _User, cPassword = _Password }); }
        }
        
    }
}
