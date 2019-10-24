// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthorizeAttribute.Approach2
{
    public class CustomAuthPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public CustomAuthPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            //Initializing default policy provider.
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            //If A1Authorize attribute is used in controller, and if this CustomAuthPolicyProvider is registered in startup.cs
            //When A1Authorize attribute is invoked, this function will be called.
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        //This method will be called by the asp.net core pipeline only when Authorize Attribute has Policy Property set
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            try
            {
                //All custom policies created by us will have " : " as delimiter to identify policy name and values
                //Any delimiter or character can be choosen, and it is upto user choice

                var policy = policyName.Split(":").FirstOrDefault(); //Name for policy and values are set in A2AuthorizePermission Attribute
                var attributeValue= policyName.Split(":").LastOrDefault();

                if (policy!=null)
                {
                    //Dynamically building the AuthorizationPolicy and adding the respective requirement based on the policy names which we define in Authroize Attribute.
                    var policyBuilder = new AuthorizationPolicyBuilder();

                    if (policy == "CustomAuthPermissionPolicy")
                    {
                        //Authorize Hanlders are created based on Authroize Requirement type.
                        //Adding the object of A2AuthorizePermissionRequirement will invoke the A2AuthorizePermissionHandler
                        policyBuilder.AddRequirements(new A2AuthorizePermissionRequirement(attributeValue));
                        return Task.FromResult(policyBuilder.Build());
                    }
                }
                return FallbackPolicyProvider.GetPolicyAsync(policyName);
            }
            catch(Exception)
            {
                return FallbackPolicyProvider.GetPolicyAsync(policyName);
            }
        }
    }
}
