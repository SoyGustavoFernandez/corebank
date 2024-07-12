using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WEB.AhorroWeb.Models
{
    public class Captcha
    {
        #region Variables Privadas
        private const string cKey = "6LeOzOQUAAAAAAtOOvtizKdoZVP-QHt2cEnh2r4W";
        private string cCaptcha { get; set; }
        #endregion

        #region Constructores
        public Captcha(string cCaptcha)
        {
            this.cCaptcha = cCaptcha;
        }

        public bool captchaValido()
        {            
            var objWebClient = new WebClient();
            var result = objWebClient.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", cKey, this.cCaptcha));
            var obj = JObject.Parse(result);

            return (bool)obj.SelectToken("success");
        }
        #endregion
    }
}