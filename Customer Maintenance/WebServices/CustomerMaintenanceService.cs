using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using CustomerMaintenance.CustomerServiceReference;

namespace CustomerMaintenance.WebServices
{
    public class CustomerService : WebServiceBase
    {
        public CustomerService(ServiceUserSettings userSettings)
            : base(userSettings)
        {
        }

        public void UpdateContact(UpdateContact contact)
        {
            using (var servicePortClient = CustomerServicePortClient(GetBindingTransportCredentialOnly(), _userSettings.BaseUrl))
            {
                servicePortClient.UpdateContact(contact);
            }
        }

        public async Task<UpdateContact_Result> UpdateContactAsync(UpdateContact contact)
        {
            using (var servicePortClient = CustomerServicePortClient(GetBindingTransportCredentialOnly(), _userSettings.BaseUrl))
            {
                return await servicePortClient.UpdateContactAsync(contact);
            }
        }

        public void GetContact(string hashCode, ref ReadContact contact)
        {
            using (var servicePortClient = CustomerServicePortClient(GetBindingTransportCredentialOnly(), _userSettings.BaseUrl))
            {
                servicePortClient.GetContact(hashCode, ref contact);
            }
        }


        private Customer_PortClient CustomerServicePortClient(BasicHttpBinding navWSBinding, string baseURL)
        {
            Customer_PortClient servicePortClient = new Customer_PortClient(navWSBinding, new EndpointAddress(baseURL));
            servicePortClient.ClientCredentials.Windows.ClientCredential = GetNetworkCredentials();
            servicePortClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;

            return servicePortClient;
        }
    }
}
