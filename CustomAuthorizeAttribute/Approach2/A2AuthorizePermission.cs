// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizeAttribute.Approach2
{
    public class A2AuthorizePermission:AuthorizeAttribute
    {
        private string _permissions;

        public string Permissions
        {
            get
            {
                return _permissions;
            }
            set
            {
                _permissions = value;

                //The Policy property should be set for the GetPolicyAsync() Method in CustomAuthPolicyProvider to be invoked
                Policy = "CustomAuthPermissionPolicy:"+ _permissions; 
            }
        }
    }
}
