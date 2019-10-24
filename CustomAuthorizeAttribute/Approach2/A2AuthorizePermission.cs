// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizeAttribute.Approach2
{
    //Defines the Attribute which will be used in controller
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
                //Appending value "CustomAuthPermissionPolicy" is to identify which handler to be invoked from Custom Auth Policy Provider.
                //value "CustomAuthPermissionPolicy" is user defined, it can be any value and any delimiter based on user requirement.
                Policy = "CustomAuthPermissionPolicy:"+ _permissions; 
            }
        }
    }
}
