// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthorizeAttribute.Approach2
{
    //The actual logic of Authorize Attribute is defined in Handler. 
    public class A2AuthorizePermissionHandler : AuthorizationHandler<A2AuthorizePermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, A2AuthorizePermissionRequirement requirement)
        {
            if (string.IsNullOrEmpty(requirement.Permissions))
            {
                context.Fail();
            }

            var userName = context.User.Identity.Name;
            var assignedPermissionsForUser = MockData.UserPermissions.Where(x => x.Key == userName).Select(x => x.Value).ToList();


            var requiredPermissions = requirement.Permissions.Split(",");
            foreach (var x in requiredPermissions)
            {
                if (assignedPermissionsForUser.Contains(x))
                {
                    //context.Succeed authorize's the user. 
                    //Note: If multiple authorize attributes are available, if you want the user to be authorized in both the all the attributes, then dont set the context.success here. Just return task completed
                    //setting context.succeed here will not take the control next attribute, it will be marked as authorized in all lower level attributes.
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }  
            }
            //Setting user as not authorized
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
