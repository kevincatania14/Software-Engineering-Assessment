using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GithubAnalyser.BusinessLogic.Helpers
{
    /// <summary>
    /// TLS 1.2 is more secure than the previous cryptographic protocols such as SSL 2.0, SSL 3.0, TLS 1.0, 
    /// and TLS 1.1. Essentially, TLS 1.2 keeps data being transferred across the network more secure.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// Enabling TLS is mostly ideal if sensitive data is being passed
        /// </summary>
        public void EnableTLS()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
