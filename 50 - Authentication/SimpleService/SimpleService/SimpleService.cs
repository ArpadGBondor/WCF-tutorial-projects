using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in both code and config file together.
    public class SimpleService : ISimpleService
    {
        public string GetUserName()
        {
            Console.WriteLine(
                "Is Authenticated: {0}",
                ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated);
            Console.WriteLine(
                "Authentication type: {0}",
                ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType);
            Console.WriteLine(
                "Authenticated username: {0}",
                ServiceSecurityContext.Current.PrimaryIdentity.Name);
            return "Authenticated username: " +
                ServiceSecurityContext.Current.PrimaryIdentity.Name.ToString();
        }
    }
}
