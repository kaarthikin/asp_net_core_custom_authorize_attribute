// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CustomAuthorizeAttribute.Approach1
{
    //Extenting from AuthorizeAttribute or Attribute is upto user choice.
    //You can consider using AuthorizeAttribute if you want to use the predefined properties and functions from Authorize Attribute.
    public class A1AuthorizePermission : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; } //Permission string to get from controller

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Validation if any permissions is given as input from controller
            if (string.IsNullOrEmpty(Permissions))
            {
                //Without any permissions validation cannot take place, so returning unauthorized
                context.Result = new UnauthorizedResult();
                return;
            }


            //The below line can be used if you are reading permissions from token
            //var permissionsFromToken=context.HttpContext.User.Claims.Where(x=>x.Type=="Permissions").Select(x=>x.Value).ToList()

            //Identity.Name will have windows logged in user id, in case of Windows Authentication
            //Indentity.Name will have user name passed from token, in case of JWT Authenntication and having claim type "ClaimTypes.Name"
            var userName = context.HttpContext.User.Identity.Name;
            var assignedPermissionsForUser = MockData.UserPermissions.Where(x => x.Key == userName).Select(x => x.Value).ToList();

            
            var requiredPermissions = Permissions.Split(","); //Multiple permissiosn can be received from controller, delimiter "," is used to get individual values
            foreach(var x in requiredPermissions)
            {
                if (assignedPermissionsForUser.Contains(x))
                    return; //User Authorized. Wihtout setting any result value and just returning is sufficent for authorizing user
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
