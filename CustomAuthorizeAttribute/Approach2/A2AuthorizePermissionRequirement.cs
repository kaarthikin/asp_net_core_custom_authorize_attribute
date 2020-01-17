// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizeAttribute.Approach2
{
    //IAuthorizationRequirement is needed for creating AuthorizationHandler
    //and also when dynalically creating policy, object are created only for requirement which inturn invokes the AuthorizationHandler
    public class A2AuthorizePermissionRequirement: IAuthorizationRequirement
    {
        public string Permissions { get; private set; }

        public A2AuthorizePermissionRequirement(string permissions)
        {
            Permissions = permissions;
        }
    }
}
