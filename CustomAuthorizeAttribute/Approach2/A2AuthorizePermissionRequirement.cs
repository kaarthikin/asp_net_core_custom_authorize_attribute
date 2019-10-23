// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthorizeAttribute.Approach2
{
    public class A2AuthorizePermissionRequirement: IAuthorizationRequirement
    {
        public string Permissions { get; private set; }

        public A2AuthorizePermissionRequirement(string permissions)
        {
            Permissions = permissions;
        }
    }
}
