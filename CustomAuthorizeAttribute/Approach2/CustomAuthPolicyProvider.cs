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
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            try
            {
                //All custom policies created by us will have " : " as delimiter to identify policy name and values
                //Any delimiter or character can be choosen, and it is upto user choice

                var policy = policyName.Split(":").FirstOrDefault();
                var attributeValue= policyName.Split(":").LastOrDefault();

                if (policy!=null)
                {
                    var policyBuilder = new AuthorizationPolicyBuilder();

                    if (policy == "CustomAuthPermissionPolicy")
                    {
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
