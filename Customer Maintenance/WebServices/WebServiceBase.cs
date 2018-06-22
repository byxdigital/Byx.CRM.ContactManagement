using System.Net;
using System.ServiceModel;

namespace CustomerMaintenance.WebServices
{
    public class WebServiceBase
    {
        protected ServiceUserSettings _userSettings;

        public WebServiceBase(ServiceUserSettings userSettings)
        {
            _userSettings = userSettings;
        }

        protected BasicHttpBinding GetBindingTransportCredentialOnly()
        {
            var binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

            return binding;
        }

        protected NetworkCredential GetNetworkCredentials()
        {
            return new NetworkCredential(_userSettings.UserAccount, _userSettings.Password);
        }
    }

    public class ServiceUserSettings
    {
        public string UserAccount { get; set; }
        public string Password { get; set; }
        public string BaseUrl { get; set; }
    }
}
