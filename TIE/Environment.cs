using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIE
{
    internal class Environment(string name, string url, string max)
    {
        private string _name = name;
        private string _apiKey = default;
        private string _clientId = default;
        private string _clientSecret = default;
        private string _clientToken = default;
        private long _clientTokenExpiresAt = default;
        private string _clientJsonPayload = "{ \"clientId\": \"{clientId}\", \"secret\": \"{secret}\", \"type\": \"OWNER\"}";
        private string _url = url;
        private string _max = max;
                
        public string Name { get { return _name; } set{_name = value; } }
        public string Url { get { return _url; } set { _url = value; } }
        public string ApiKey { get { return _apiKey; } set { _apiKey = value; } }
        public string Max { get { return _max; } set { _max = value; } }
        public string ClientId { get { return _clientId; } set { _clientId = value; } }
        public string ClientSecret { get { return _clientSecret; } set { _clientSecret = value; } }
        public string ClientToken { get { return _clientToken; } set { _clientToken = value; } }
        public string ClientPayload 
        { 
            get 
            {
                return _clientJsonPayload.Replace("{clientId}", _clientId).Replace("{secret}", _clientSecret);
            } 
        }

        public long ClientTokenExpiresAt{ get { return _clientTokenExpiresAt; } set { _clientTokenExpiresAt = value; } }

        public bool IsClientAppAuth() 
        {
            if(_clientId != default && _clientSecret != default)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        /// <summary>
        /// check to see if the token has expired compared to the system time.
        /// </summary>
        /// <param name="systemTime"></param>
        /// <returns></returns>
        public bool HasClientTokenExpired()
        {
            if(_clientTokenExpiresAt != default)
            {
                DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(_clientTokenExpiresAt).DateTime;
                if (dt > DateTime.Now)
                {
                    return false;
                }
            }
            return true;
        }

        override
        public string ToString()
        {
            return _name + " | " + _url;
            //return "Name: " + _name + " API KEY: " + _apiKey + " URL: " + _url + " Max: " + _max;
        }
    }
}
